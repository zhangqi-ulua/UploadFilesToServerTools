using RNCryptor;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace UploadFilesToServerTools
{
    public class Test
    {
        private static List<OneConfigJsonVO> _TestConfigList;

        static Test()
        {
            _TestConfigList = new List<OneConfigJsonVO>();
            {
                OneConfigJsonVO vo = new OneConfigJsonVO();
                vo.Host = "127.0.0.1";
                vo.Remark = "test1";
                vo.LocalFolderPath = null;
                vo.ServerFolderPath = "/res/";
                vo.Username = "root";
                vo.Password = "zhangqi";
                _TestConfigList.Add(vo);
            }
            {
                OneConfigJsonVO vo = new OneConfigJsonVO();
                vo.Host = "127.0.0.1";
                vo.Remark = "test2";
                vo.LocalFolderPath = @"D:\zhangqi\";
                vo.ServerFolderPath = "/res_temp/";
                vo.Username = "temp";
                vo.Password = "zhangqi2";
                _TestConfigList.Add(vo);
            }
        }

        public static void TestEditModelConfigFile()
        {
            string filePath = @"D:\test_config.ftpconf";
            string editPassword = "zhangqi";

            ConfigFileVO editModelVO = new ConfigFileVO();
            editModelVO.ConfigFilePath = filePath;
            editModelVO.EditPassword = editPassword;
            editModelVO.ViewPassword = "view";
            editModelVO.AllConfigs = _TestConfigList;

            Utils.WriteConfigFile(editModelVO, filePath);

            string errorInfo = null;
            ConfigFileVO readConfig = Utils.ReadConfigFileByEditModel(filePath, editPassword, out errorInfo);
            if (errorInfo == null)
            {
                Debug.Print(readConfig.ConfigFilePath);
                Debug.Print(readConfig.AllConfigs[1].Password);
            }
            else
            {
                Debug.Print(errorInfo);
            }
        }

        public static void TestViewModelConfigFile()
        {
            string filePath = @"D:\test_config.ftpconf";
            string viewPassword = "view";

            string errorInfo = null;
            ConfigFileVO readConfig = Utils.ReadConfigFileByViewModel(filePath, viewPassword, out errorInfo);
            if (errorInfo == null)
            {
                Debug.Print(readConfig.ConfigFilePath);
                Debug.Print(readConfig.AllConfigs[1].Password);
                Debug.Assert(readConfig.EditPassword == null);
                Debug.Assert(readConfig.EncryptedViewPasswordByteArray != null && readConfig.EncryptedViewPasswordByteArray.Length > 0);
            }
            else
            {
                Debug.Print(errorInfo);
            }
        }

        public static void TestRNCryptor()
        {
            string text = "测试文字加密";
            string password = "zhangqi";
            byte[] textByteArray = Encoding.Default.GetBytes(text);

            Encryptor encryptor = new Encryptor();
            byte[] encryptedByteArrayResult1 = encryptor.Encrypt(textByteArray, password);
            byte[] encryptedByteArrayResult2 = encryptor.Encrypt(textByteArray, password);
            Debug.Print($"比较加密后的1、2：{_IsByteArrayEquals(encryptedByteArrayResult1, encryptedByteArrayResult2)}");
            Debug.Print($"加密后的1转为的字符串：{Encoding.Default.GetString(encryptedByteArrayResult1)}");
            Debug.Print($"加密后的2转为的字符串：{Encoding.Default.GetString(encryptedByteArrayResult2)}");

            // 解密
            Decryptor decryptor = new Decryptor();
            byte[] decryptedTextByteArray1 = decryptor.Decrypt(encryptedByteArrayResult1, password);
            byte[] decryptedTextByteArray2 = decryptor.Decrypt(encryptedByteArrayResult2, password);
            Debug.Print($"比较解密后的1、2：{_IsByteArrayEquals(decryptedTextByteArray1, decryptedTextByteArray2)}");
        }

        private static bool _IsByteArrayEquals(byte[] byteArray1, byte[] byteArray2)
        {
            if (byteArray1.Length != byteArray2.Length)
                return false;

            for (int i = 0; i < byteArray1.Length; i++)
            {
                if (byteArray1[i] != byteArray2[i])
                    return false;
            }

            return true;
        }
    }
}
