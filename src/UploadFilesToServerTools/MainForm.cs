using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UploadFilesToServerTools
{
    public delegate void OperateUiDelegate(Object obj);

    public partial class MainForm : Form
    {
        // 配置组件之间的y轴距离
        private const int _CONFIG_CONTROL_DISTANCE_Y = 140;

        // 当前以使用者模式打开的配置文件路径
        private string _CurrentViewConfigFilePath;
        // 当前打开配置文件对应的未修改过的ConfigFileVO
        private ConfigFileVO _CurrentConfigFileVO;
        // 与当前界面显示的配置项顺序一一对应
        private List<ViewConfigUserControl> _ViewConfigUserControlList = new List<ViewConfigUserControl>();
        // 当前是否展示Log窗口
        private bool _IsShowLog = false;

        public MainForm()
        {
            InitializeComponent();

            BtnSaveLocalPathToConfigFile.Enabled = false;
            GrpConfig.Visible = false;
            _SetShowLogState(_IsShowLog);
        }

        private void BtnConfigFileEditor_Click(object sender, EventArgs e)
        {
            bool isOpenConfigFile = !string.IsNullOrEmpty(_CurrentViewConfigFilePath);
            DialogResult dialogResult;
            if (isOpenConfigFile == false)
            {
                MessageBoxManager.OK = "打开已有配置";
                MessageBoxManager.Cancel = "新建配置";
                MessageBoxManager.Register();
                dialogResult = MessageBox.Show(this, "请选择打开已有配置或者新建一个", "请选择", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                MessageBoxManager.Yes = "打开当前配置";
                MessageBoxManager.No = "打开其他配置";
                MessageBoxManager.Cancel = "新建配置";
                MessageBoxManager.Register();
                dialogResult = MessageBox.Show(this, $"您可以选择修改当前打开的配置文件{_CurrentViewConfigFilePath}\n也可以打开其他配置文件或者新建一个", "请选择", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            }

            MessageBoxManager.Unregister();
            // 选择一个配置文件打开
            if (dialogResult == DialogResult.OK || dialogResult == DialogResult.No)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "请选择要打开的配置文件";
                dialog.Filter = $"(*.{Utils.CONFIG_FILE_EXTENSION})|*.{Utils.CONFIG_FILE_EXTENSION}";
                dialog.Multiselect = false;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = dialog.FileName;
                    InputEditPasswordForm inputEditPasswordForm = new InputEditPasswordForm();
                    if (inputEditPasswordForm.ShowDialog() == DialogResult.OK)
                    {
                        // 校验管理员密码是否正确
                        string readConfigFileErrorInfo = null;
                        ConfigFileVO vo = Utils.ReadConfigFileByEditModel(filePath, inputEditPasswordForm.InputPassword, out readConfigFileErrorInfo);
                        if (readConfigFileErrorInfo != null)
                        {
                            MessageBox.Show(this, readConfigFileErrorInfo, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                            new ConfigFileEditorForm(vo).ShowDialog();
                    }
                }
            }
            // 直接打开当前配置文件
            else if (dialogResult == DialogResult.Yes)
            {
                InputEditPasswordForm inputEditPasswordForm = new InputEditPasswordForm();
                if (inputEditPasswordForm.ShowDialog() == DialogResult.OK)
                {
                    // 校验管理员密码是否正确
                    string readConfigFileErrorInfo = null;
                    ConfigFileVO vo = Utils.ReadConfigFileByEditModel(_CurrentViewConfigFilePath, inputEditPasswordForm.InputPassword, out readConfigFileErrorInfo);
                    if (readConfigFileErrorInfo != null)
                    {
                        MessageBox.Show(this, readConfigFileErrorInfo, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                        new ConfigFileEditorForm(vo).ShowDialog();
                }
            }
            // 新建配置文件
            else
            {
                new ConfigFileEditorForm(new ConfigFileVO(false)).ShowDialog();
            }
        }

        private void BtnLoadConfigFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "请选择要打开的配置文件";
            dialog.Filter = $"(*.{Utils.CONFIG_FILE_EXTENSION})|*.{Utils.CONFIG_FILE_EXTENSION}";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = dialog.FileName;
                InputViewPasswordForm inputViewPasswordForm = new InputViewPasswordForm();
                if (inputViewPasswordForm.ShowDialog() == DialogResult.OK)
                {
                    // 校验使用者密码是否正确
                    string readConfigFileErrorInfo = null;
                    ConfigFileVO vo = Utils.ReadConfigFileByViewModel(filePath, inputViewPasswordForm.InputPassword, out readConfigFileErrorInfo);
                    if (readConfigFileErrorInfo != null)
                    {
                        MessageBox.Show(this, readConfigFileErrorInfo, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        _CurrentViewConfigFilePath = dialog.FileName;
                        BtnSaveLocalPathToConfigFile.Enabled = true;
                        _CurrentConfigFileVO = vo;
                        LblCurrentConfigFilePath.Text = dialog.FileName;

                        Pnl.Controls.Clear();
                        _ViewConfigUserControlList.Clear();

                        foreach (OneConfigJsonVO oneConfig in vo.AllConfigs)
                        {
                            ViewConfigUserControl newControl = new ViewConfigUserControl(this, oneConfig);
                            _ViewConfigUserControlList.Add(newControl);
                            Pnl.Controls.Add(newControl);
                        }
                        ResetConfigControlLocation();
                    }
                }
            }
        }

        private void ResetConfigControlLocation()
        {
            for (int i = 0; i < _ViewConfigUserControlList.Count; i++)
            {
                _ViewConfigUserControlList[i].Location = new Point(0, i * _CONFIG_CONTROL_DISTANCE_Y);
            }
        }

        private void _SetShowLogState(bool isShow)
        {
            if (isShow)
            {
                BtnShowLog.Text = "隐  藏  日  志";
                RtxLog.Visible = true;
                Size = new Size(1314, Size.Height);
            }
            else
            {
                BtnShowLog.Text = "查  看  日  志";
                RtxLog.Visible = false;
                Size = new Size(742, Size.Height);
            }
        }

        private void BtnShowLog_Click(object sender, EventArgs e)
        {
            _IsShowLog = !_IsShowLog;
            _SetShowLogState(_IsShowLog);
        }

        private void BtnSaveLocalPathToConfigFile_Click(object sender, EventArgs e)
        {
            // 将每个配置项中填写的本地路径覆盖更新到配置文件
            for (int i = 0; i < _CurrentConfigFileVO.AllConfigs.Count; i++)
            {
                _CurrentConfigFileVO.AllConfigs[i].LocalFolderPath = _ViewConfigUserControlList[i].GetLocalFolderPath();
            }

            Utils.WriteConfigFile(_CurrentConfigFileVO, _CurrentViewConfigFilePath);
            MessageBox.Show(this, "覆盖更新本地路径成功", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 关闭时，同上一次保存时的每个配置中的本地路径比较，如果有差别，则提示保存
            if (_CurrentConfigFileVO == null)
                return;

            bool isAllSame = true;
            for (int i = 0; i < _CurrentConfigFileVO.AllConfigs.Count; i++)
            {
                if (_CurrentConfigFileVO.AllConfigs[i].LocalFolderPath.Equals(_ViewConfigUserControlList[i].GetLocalFolderPath()) == false)
                {
                    isAllSame = false;
                    break;
                }
            }
            if (isAllSame == false)
            {
                if (MessageBox.Show(this, "您有修改尚未保存，建议您保存后退出\n\n点击“是”取消退出操作\n点击“否”退出而不保存", "请确定", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    e.Cancel = true;
            }
        }

        private void AppendTextToConsole(Object text)
        {
            // 让富文本框获取焦点
            RtxLog.Focus();
            // 设置光标的位置到文本结尾
            RtxLog.Select(RtxLog.TextLength, 0);
            // 滚动到富文本框光标处
            RtxLog.ScrollToCaret();
            // 追加内容
            RtxLog.AppendText(text as string);
            // 换行
            RtxLog.AppendText(Environment.NewLine);
        }

        public void AppendTextToConsoleForOtherThread(string text)
        {
            OperateUiDelegate delegateFunc = new OperateUiDelegate(AppendTextToConsole);
            Invoke(delegateFunc, text);
        }
    }
}
