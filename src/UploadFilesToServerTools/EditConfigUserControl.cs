using System.Drawing;
using System.Windows.Forms;

namespace UploadFilesToServerTools
{
    public partial class EditConfigUserControl : UserControl
    {
        // Host文本框默认的提示文字
        private const string _HOST_TIPS = "格式为：服务器域名或IP，比如www.xxx.com 或 127.0.0.1，端口为默认的22，无需且无法指定";

        private ConfigFileEditorForm _ParentForm;

        public EditConfigUserControl(ConfigFileEditorForm parentForm)
        {
            _ParentForm = parentForm;
            InitializeComponent();
            TxtLocalFolderPath.DragEnter += new DragEventHandler(Utils.TextBoxDragEnter);
            TxtLocalFolderPath.DragDrop += new DragEventHandler(Utils.TextBoxOneDirDragDrop);
            _SetHostTips(true);
        }

        public EditConfigUserControl(ConfigFileEditorForm parentForm, OneConfigJsonVO vo) : this(parentForm)
        {
            RefreshUI(vo);
        }

        public void RefreshUI(OneConfigJsonVO vo)
        {
            TxtRemark.Text = vo.Remark;
            if (string.IsNullOrEmpty(vo.Host))
                _SetHostTips(true);
            else
            {
                TxtHost.Text = vo.Host;
                _SetHostTips(false);
            }
            TxtUsername.Text = vo.Username;
            TxtPassword.Text = vo.Password;
            TxtServerFolderPath.Text = vo.ServerFolderPath;
            if (string.IsNullOrEmpty(vo.LocalFolderPath) == false)
                TxtLocalFolderPath.Text = vo.LocalFolderPath;
        }

        private void BtnChooseLocalFolder_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择对应本地要上传的文件夹";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TxtLocalFolderPath.Text = dialog.SelectedPath;
            }
        }

        private void BtnDelete_Click(object sender, System.EventArgs e)
        {
            _ParentForm.DeleteConfig(this);
        }

        public void SetGroupBoxTitle(string title)
        {
            GrpConfig.Text = title;
        }

        public OneConfigJsonVO CheckAndGetConfig(out string errorInfo)
        {
            OneConfigJsonVO vo = new OneConfigJsonVO();
            string inputRemark = TxtRemark.Text.Trim();
            if (string.IsNullOrEmpty(inputRemark))
            {
                errorInfo = "未输入备注名称";
                return null;
            }
            vo.Remark = inputRemark;
            string inputHost = TxtHost.Text.Replace(_HOST_TIPS, string.Empty).Trim();
            if (string.IsNullOrEmpty(inputHost))
            {
                errorInfo = "未输入Host";
                return null;
            }
            vo.Host = inputHost;
            string inputUsername = TxtUsername.Text.Trim();
            if (string.IsNullOrEmpty(inputUsername))
            {
                errorInfo = "未输入用户名";
                return null;
            }
            vo.Username = inputUsername;
            string inputPassword = TxtPassword.Text.Trim();
            if (string.IsNullOrEmpty(inputPassword))
            {
                errorInfo = "未输入密码";
                return null;
            }
            vo.Password = inputPassword;
            string inputServerFolderPath = TxtServerFolderPath.Text.Trim();
            if (string.IsNullOrEmpty(inputServerFolderPath))
            {
                errorInfo = "未输入服务器上传目录的路径";
                return null;
            }
            vo.ServerFolderPath = inputServerFolderPath;
            // 本地路径中的“/”换成“\”，并在最后加上“\”
            vo.LocalFolderPath = TxtLocalFolderPath.Text.Trim().Replace("/", "\\");
            if (string.IsNullOrEmpty(vo.LocalFolderPath) == false && vo.LocalFolderPath.EndsWith("\\") == false)
                vo.LocalFolderPath += "\\";

            // 把所有的“\”换成“/”
            vo.Host = vo.Host.Replace("\\", "/");
            vo.ServerFolderPath = vo.ServerFolderPath.Replace("\\", "/");

            // 将Host后面的“/”去掉
            while (vo.Host[vo.Host.Length - 1] == '/')
                vo.Host = vo.Host.Substring(0, vo.Host.Length - 1);
            // ServerFolderPath前后都加上“/”
            if (vo.ServerFolderPath.StartsWith("/") == false)
                vo.ServerFolderPath = "/" + vo.ServerFolderPath;
            // ServerFolderPath后面加上“/”
            if (vo.ServerFolderPath.EndsWith("/") == false)
                vo.ServerFolderPath += "/";

            errorInfo = null;
            return vo;
        }

        private void TxtHost_Enter(object sender, System.EventArgs e)
        {
            _SetHostTips(false);
        }

        private void TxtHost_Leave(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtHost.Text.Trim()))
                _SetHostTips(true);
        }

        private void _SetHostTips(bool isShowTips)
        {
            if (isShowTips)
            {
                TxtHost.Text = _HOST_TIPS;
                TxtHost.ForeColor = Color.Gray;
            }
            else
            {
                TxtHost.Text = TxtHost.Text.Replace(_HOST_TIPS, string.Empty);
                TxtHost.ForeColor = Color.Black;
            }
        }
    }
}
