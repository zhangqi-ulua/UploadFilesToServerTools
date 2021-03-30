using Renci.SshNet;
using Renci.SshNet.Async;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace UploadFilesToServerTools
{
    public partial class ViewConfigUserControl : UserControl
    {
        private MainForm _ParentForm;
        private OneConfigJsonVO _CurrentConfigJsonVO;

        // 当前正在上传文件的总大小（字节数）
        private ulong _CurrentUploadFileLength;

        public ViewConfigUserControl(MainForm parentForm, OneConfigJsonVO vo)
        {
            _ParentForm = parentForm;
            _CurrentConfigJsonVO = vo;

            InitializeComponent();
            TxtLocalFolderPath.DragEnter += new DragEventHandler(Utils.TextBoxDragEnter);
            TxtLocalFolderPath.DragDrop += new DragEventHandler(Utils.TextBoxOneDirDragDrop);

            RefreshUI(vo);
        }

        public void RefreshUI(OneConfigJsonVO vo)
        {
            GrpConfig.Text = vo.Remark;
            LblServerPath.Text = vo.GetServerUploadFolderPath();
            if (string.IsNullOrEmpty(vo.LocalFolderPath) == false)
                TxtLocalFolderPath.Text = vo.LocalFolderPath;
        }

        private void BtnChooseLocalFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择对应本地要上传的文件夹";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TxtLocalFolderPath.Text = dialog.SelectedPath;
            }
        }

        public string GetLocalFolderPath()
        {
            string tempPath = TxtLocalFolderPath.Text.Trim().Replace("/", "\\");
            if (string.IsNullOrEmpty(tempPath) == false && tempPath.EndsWith("\\") == false)
                tempPath += "\\";

            return tempPath;
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            string inputLocalFolderPath = GetLocalFolderPath();
            if (string.IsNullOrEmpty(inputLocalFolderPath))
            {
                MessageBox.Show(this, "未指定本地文件夹路径", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Directory.Exists(inputLocalFolderPath) == false)
            {
                MessageBox.Show(this, "指定的本地文件夹不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SftpClient client = null;
            try
            {
                client = new SftpClient(_CurrentConfigJsonVO.Host, _CurrentConfigJsonVO.Username, _CurrentConfigJsonVO.Password);
                client.Connect();
            }
            catch
            {
                MessageBox.Show(this, "连接服务器失败，请确认配置是否正确，服务器是否开启等", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (client.Exists(_CurrentConfigJsonVO.ServerFolderPath) == false)
            {
                MessageBox.Show(this, $"服务器中不存在要上传至的根目录{_CurrentConfigJsonVO.ServerFolderPath}，请检查路径是否正确以及该根目录是否已经建立", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BtnUpload.Text = "上传中";
            BtnUpload.Enabled = false;
            _ParentForm.AppendTextToConsoleForOtherThread($"开始执行上传任务“{_CurrentConfigJsonVO.Remark}”：");
            _ParentForm.AppendTextToConsoleForOtherThread($"服务器路径为：{_CurrentConfigJsonVO.GetServerUploadFolderPath()}");
            _ParentForm.AppendTextToConsoleForOtherThread($"本地路径为：{_CurrentConfigJsonVO.LocalFolderPath}");
            _Upload(client, _CurrentConfigJsonVO.ServerFolderPath, inputLocalFolderPath);
        }

        private async void _Upload(SftpClient client, string serverFolderPath, string localFolderPath)
        {
            // 注意：要保证localFolderPath以“\”结尾，否则在通过它求其下某个子文件夹相对它的相对路径是错误的
            // 比如某子文件夹路径为“D:\temp\1”，若用“D:\temp\”求其相对路径结果是“1”，而用“D:\temp”求则结果是“temp/1”
            localFolderPath = Path.GetFullPath(localFolderPath);
            Uri localRootFolderUri = new Uri(localFolderPath);
            DirectoryInfo localRootFolderDirectoryInfo = new DirectoryInfo(localFolderPath);
            List<DirectoryInfo> allChildDirectoryInfo = null;
            _GetAllChildDirectoryInfo(localRootFolderDirectoryInfo, ref allChildDirectoryInfo);

            Stopwatch stopwatch = new Stopwatch();
            long totalCostMillisecond = 0;

            // 将找到的所有子文件夹中的文件进行上传，注意检测服务器中是否有对应的文件夹，如果没有则创建
            foreach (DirectoryInfo oneFolder in allChildDirectoryInfo)
            {
                // 获取当前目录相对本地根目录的相对路径
                string relativePath = Uri.UnescapeDataString(localRootFolderUri.MakeRelativeUri(new Uri(oneFolder.FullName)).ToString());
                string serverPath = serverFolderPath + (string.IsNullOrEmpty(relativePath) ? string.Empty : relativePath + "/");
                if (client.Exists(serverPath) == false)
                {
                    _ParentForm.AppendTextToConsoleForOtherThread($"创建目录：{serverPath}");
                    client.CreateDirectory(serverPath);
                }
                // 上传该文件夹下的所有文件
                FileInfo[] allFileInfo = oneFolder.GetFiles();
                if (allFileInfo != null && allFileInfo.Length > 0)
                {
                    _ParentForm.AppendTextToConsoleForOtherThread($"上传以下本地文件到服务器目录：{serverPath}");
                    foreach (FileInfo fileInfo in allFileInfo)
                    {
                        string serverFilePath = serverPath + fileInfo.Name;
                        string localFilePath = localFolderPath + (string.IsNullOrEmpty(relativePath) ? string.Empty : relativePath.Replace("/", "\\") + "\\") + fileInfo.Name;
                        _CurrentUploadFileLength = (ulong)fileInfo.Length;
                        string fileSizeString = Utils.GetFileLengthString(_CurrentUploadFileLength);
                        _ParentForm.AppendTextToConsoleForOtherThread($"开始上传：{localFilePath}，总大小：{fileSizeString}");
                        LblUploadPath.Text = localFilePath;

                        using (var localStream = File.OpenRead(localFilePath))
                        {
                            stopwatch.Restart();
                            await client.UploadAsync(localStream, serverFilePath, true, _OnUploadProgressChanged);
                            stopwatch.Stop();
                            totalCostMillisecond += stopwatch.ElapsedMilliseconds;
                            _ParentForm.AppendTextToConsoleForOtherThread($"成功，用时{Utils.GetTimeString(stopwatch.ElapsedMilliseconds)}");
                        }
                    }
                }
            }

            BtnUpload.Text = "上传";
            BtnUpload.Enabled = true;
            LblUploadPath.Text = string.Empty;
            LblUploadProgress.Text = string.Empty;
            _ParentForm.AppendTextToConsoleForOtherThread($"任务完成，总用时{Utils.GetTimeString(totalCostMillisecond)}");
            _ParentForm.AppendTextToConsoleForOtherThread("—————————————————————————————————————————————");
            MessageBox.Show(this, "上传成功", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _OnUploadProgressChanged(ulong downloadedByteCount)
        {
            ChangeUploadProgressForOtherThread(downloadedByteCount);
        }

        /// <summary>
        /// 获取某个文件夹及其下所有子文件夹信息（会逐层遍历子文件夹）
        /// </summary>
        private void _GetAllChildDirectoryInfo(DirectoryInfo rootDirectory, ref List<DirectoryInfo> list)
        {
            if (list == null)
                list = new List<DirectoryInfo>();

            list.Add(rootDirectory);
            DirectoryInfo[] childDirectory = rootDirectory.GetDirectories();
            foreach (DirectoryInfo child in childDirectory)
            {
                _GetAllChildDirectoryInfo(child, ref list);
            }
        }

        public void ChangeUploadProgressForOtherThread(ulong downloadedByteCount)
        {
            OperateUiDelegate delegateFunc = new OperateUiDelegate(DelegateChangeUploadProgress);
            Invoke(delegateFunc, downloadedByteCount);
        }

        private void DelegateChangeUploadProgress(Object obj)
        {
            ulong downloadedByteCount = (ulong)obj;
            LblUploadProgress.Text = $"已上传 {downloadedByteCount * 100 / _CurrentUploadFileLength,3}% ({Utils.GetFileLengthString(downloadedByteCount)} / {Utils.GetFileLengthString(_CurrentUploadFileLength)})";
        }
    }
}
