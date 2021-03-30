using LitJson;
using System.IO;
using System.Text;
using RNCryptor;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace UploadFilesToServerTools
{
    public class Utils
    {
        public const string CONFIG_FILE_EXTENSION = "ftpconf";
        public const string VIEW_PASSWORD_PREFIX = "ViewPassword:";

        private static Encryptor _Encryptor = new Encryptor();
        private static Decryptor _Decryptor = new Decryptor();

        /**
         * 二进制形式的配置文件格式：
         * 第1个4字节int写入加密后的“ViewPassword:用管理员密码加密后的使用者密码”对应的byte[]的长度，其作用是当用“管理员密码”进行编辑时，可以解密这行内容，拿到用于加密配置信息json的“使用者密码”，从而进行解密
         * 接下来写入上面所说的byte[]的内容
         * 最后写入用“使用者密码”加密的配置信息json对应的byte[]
         */
        public static void WriteConfigFile(ConfigFileVO vo, string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);
            BinaryWriter binWriter = new BinaryWriter(fs, Encoding.Default);
            if (vo.IsOnlyView == false)
            {
                // 用“管理员密码”加密后的使用者密码
                byte[] viewPasswordByteArray = Encoding.Default.GetBytes(VIEW_PASSWORD_PREFIX + vo.ViewPassword);
                byte[] encryptedViewPasswordByteArray = _Encryptor.Encrypt(viewPasswordByteArray, vo.EditPassword);
                // 先写入上面byte[]的长度
                binWriter.Write(encryptedViewPasswordByteArray.Length);
                // 再写入用“管理员密码”加密后的使用者密码
                binWriter.Write(encryptedViewPasswordByteArray);
            }
            else
            {
                binWriter.Write(vo.EncryptedViewPasswordByteArray.Length);
                binWriter.Write(vo.EncryptedViewPasswordByteArray);
            }
            // 最后写入用“使用者密码”加密的配置信息json
            byte[] configByteArray = Encoding.Default.GetBytes(JsonMapper.ToJson(vo.AllConfigs));
            byte[] encrypedConfigByteArray = _Encryptor.Encrypt(configByteArray, vo.ViewPassword);
            binWriter.Write(encrypedConfigByteArray);
            binWriter.Close();
            fs.Close();
        }

        public static ConfigFileVO ReadConfigFileByEditModel(string filePath, string editPassword, out string errorInfo)
        {
            FileStream fs = null;
            BinaryReader binReader = null;
            ConfigFileVO vo = new ConfigFileVO();
            vo.IsOnlyView = false;
            vo.ConfigFilePath = filePath;
            try
            {
                fs = new FileStream(filePath, FileMode.Open);
                binReader = new BinaryReader(fs, Encoding.Default);
                int totalLength = (int)fs.Length;
                int encryptedViewPasswordByteArrayLength = binReader.ReadInt32();
                byte[] encryptedViewPasswordByteArray = binReader.ReadBytes(encryptedViewPasswordByteArrayLength);
                byte[] viewPasswordByteArray = _Decryptor.Decrypt(encryptedViewPasswordByteArray, editPassword);
                string viewPasswordStr = Encoding.Default.GetString(viewPasswordByteArray);
                if (viewPasswordStr.StartsWith(VIEW_PASSWORD_PREFIX) == false)
                {
                    errorInfo = "解密失败，请确认是否输入了正确的用于编辑配置的管理员密码";
                    return null;
                }
                else
                {
                    vo.EditPassword = editPassword;
                    vo.ViewPassword = viewPasswordStr.Substring(VIEW_PASSWORD_PREFIX.Length);
                }

                byte[] encryptedConfigByteArray = binReader.ReadBytes(totalLength - 4 - encryptedViewPasswordByteArrayLength);
                byte[] configByteArray = _Decryptor.Decrypt(encryptedConfigByteArray, vo.ViewPassword);
                string configStr = Encoding.Default.GetString(configByteArray);
                vo.AllConfigs = JsonMapper.ToObject<List<OneConfigJsonVO>>(configStr);

                errorInfo = null;
                return vo;
            }
            catch
            {
                errorInfo = "解密失败，请确认是否输入了正确的用于编辑配置的管理员密码";
                return null;
            }
            finally
            {
                if (binReader != null)
                    binReader.Close();
                if (fs != null)
                    fs.Close();
            }
        }

        public static ConfigFileVO ReadConfigFileByViewModel(string filePath, string viewPassword, out string errorInfo)
        {
            FileStream fs = null;
            BinaryReader binReader = null;
            ConfigFileVO vo = new ConfigFileVO();
            vo.IsOnlyView = true;
            vo.ConfigFilePath = filePath;
            vo.ViewPassword = viewPassword;
            try
            {
                fs = new FileStream(filePath, FileMode.Open);
                binReader = new BinaryReader(fs, Encoding.Default);
                int totalLength = (int)fs.Length;
                int encryptedViewPasswordByteArrayLength = binReader.ReadInt32();
                vo.EncryptedViewPasswordByteArray = binReader.ReadBytes(encryptedViewPasswordByteArrayLength);
                byte[] encryptedConfigByteArray = binReader.ReadBytes(totalLength - 4 - encryptedViewPasswordByteArrayLength);
                byte[] configByteArray = _Decryptor.Decrypt(encryptedConfigByteArray, vo.ViewPassword);
                string configStr = Encoding.Default.GetString(configByteArray);
                vo.AllConfigs = JsonMapper.ToObject<List<OneConfigJsonVO>>(configStr);

                errorInfo = null;
                return vo;
            }
            catch
            {
                errorInfo = "解密失败，请确认是否输入了正确的用于读取配置的使用者密码";
                return null;
            }
            finally
            {
                if (binReader != null)
                    binReader.Close();
                if (fs != null)
                    fs.Close();
            }
        }

        public static void WriteBinaryFile(string text, string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);
            byte[] byteArray = Encoding.Default.GetBytes(text);
            BinaryWriter binWriter = new BinaryWriter(fs, Encoding.Default);
            binWriter.Write(byteArray);
            binWriter.Close();
            fs.Close();
        }

        public static string ReadBinaryFile(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            BinaryReader binReader = new BinaryReader(fs, Encoding.Default);
            byte[] buffer = new byte[fs.Length];
            binReader.Read(buffer, 0, (int)fs.Length);
            binReader.Close();
            fs.Close();
            return Encoding.Default.GetString(buffer);
        }

        /// <summary>
        /// 想拖拽接收文件或文件夹路径的文本框，需要注册DragEnter事件回调
        /// </summary>
        public static void TextBoxDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }

        /// <summary>
        /// 要求拖拽一个文件夹到文本框的DragDrop事件回调
        /// </summary>
        public static void TextBoxOneDirDragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) == true)
            {
                Array dragDropDirArray = e.Data.GetData(DataFormats.FileDrop) as Array;
                if (dragDropDirArray.Length != 1)
                {
                    MessageBox.Show("只允许拖入一个指定的文件夹", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string path = dragDropDirArray.GetValue(0).ToString();
                if (File.Exists(path) == true)
                {
                    MessageBox.Show("请拖入一个指定的文件夹而不是文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (Directory.Exists(path))
                    {
                        TextBox textBox = sender as TextBox;
                        textBox.Text = path;
                    }
                    else
                    {
                        MessageBox.Show("请拖入一个指定的文件夹", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("请拖入一个指定的文件夹", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// 获取文件字节数对应的文件大小显示，最大单位为GB，依次为MB、KB、B
        /// </summary>
        public static string GetFileLengthString(ulong fileLength)
        {
            if (fileLength < 1024)
                return fileLength + "B";
            else if (fileLength < 1048576)
                return Math.Round((double)fileLength / 1024, 2) + "KB";
            else if (fileLength < 1073741824)
                return Math.Round((double)fileLength / 1048576, 2) + "MB";
            else
                return Math.Round((double)fileLength / 1073741824, 2) + "GB";
        }

        public static string GetTimeString(long millisecond)
        {
            if (millisecond < 1000)
                return $"{millisecond}毫秒";
            if (millisecond < 60000)
                return $"{Math.Round((double)millisecond / 1000, 1)}秒";
            else
            {
                long totalSecond = millisecond / 1000;
                if (totalSecond < 3600)
                    return $"{totalSecond / 60}分{totalSecond % 60}秒";
                else
                {
                    long hour = totalSecond / 3600;
                    totalSecond = totalSecond % 3600;
                    return $"{hour}时{totalSecond / 60}分{totalSecond % 60}秒";
                }
            }
        }
    }
}
