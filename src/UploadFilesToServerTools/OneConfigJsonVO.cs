using System;
using System.Collections.Generic;

namespace UploadFilesToServerTools
{
    public class OneConfigJsonVO : IEquatable<OneConfigJsonVO>
    {
        public string Remark;
        public string Host;
        public string Username;
        public string Password;
        public string ServerFolderPath;
        public string LocalFolderPath;

        public string GetServerUploadFolderPath()
        {
            return $"{Host}{ServerFolderPath}";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as OneConfigJsonVO);
        }

        public bool Equals(OneConfigJsonVO other)
        {
            return other != null &&
                   Remark == other.Remark &&
                   Host == other.Host &&
                   Username == other.Username &&
                   Password == other.Password &&
                   ServerFolderPath == other.ServerFolderPath &&
                   LocalFolderPath == other.LocalFolderPath;
        }

        public override int GetHashCode()
        {
            int hashCode = -884692947;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Remark);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Host);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Username);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ServerFolderPath);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LocalFolderPath);
            return hashCode;
        }

        public static bool operator ==(OneConfigJsonVO left, OneConfigJsonVO right)
        {
            return EqualityComparer<OneConfigJsonVO>.Default.Equals(left, right);
        }

        public static bool operator !=(OneConfigJsonVO left, OneConfigJsonVO right)
        {
            return !(left == right);
        }
    }
}
