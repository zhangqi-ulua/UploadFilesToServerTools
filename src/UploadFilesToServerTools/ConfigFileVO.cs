using System.Collections.Generic;

namespace UploadFilesToServerTools
{
    public class ConfigFileVO
    {
        // 该配置文件路径（如果是新建，则为null）
        public string ConfigFilePath;
        // 当前是否是使用者读取的模式，在该模式下无法查看和修改服务器账号等信息
        public bool IsOnlyView;
        // 使用者密码
        public string ViewPassword;
        // 管理员密码
        public string EditPassword;
        // 使用者模式下，无法读取管理员密码，从而只能将加密后的byte[]进行记录
        public byte[] EncryptedViewPasswordByteArray;
        // 各个配置
        public List<OneConfigJsonVO> AllConfigs;

        public ConfigFileVO()
        {
            this.AllConfigs = new List<OneConfigJsonVO>();
        }

        public ConfigFileVO(bool isOnlyView) : this()
        {
            this.IsOnlyView = isOnlyView;
        }

        public bool IsSameConfigFileVO(ConfigFileVO other)
        {
            if (other != null &&
                   ViewPassword == other.ViewPassword &&
                   EditPassword == other.EditPassword &&
                   EqualityComparer<byte[]>.Default.Equals(EncryptedViewPasswordByteArray, other.EncryptedViewPasswordByteArray))
            {
                if (AllConfigs.Count != other.AllConfigs.Count)
                    return false;
                for (int i = 0; i < AllConfigs.Count; i++)
                {
                    if (AllConfigs[i].Equals(other.AllConfigs[i]) == false)
                        return false;
                }
                return true;
            }
            else
                return false;
        }
    }
}
