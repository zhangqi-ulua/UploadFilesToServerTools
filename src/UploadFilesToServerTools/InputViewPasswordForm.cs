using System;
using System.Windows.Forms;

namespace UploadFilesToServerTools
{
    public partial class InputViewPasswordForm : Form
    {
        public string InputPassword;
        public InputViewPasswordForm()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            InputPassword = TxtPassword.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        // 在输入框中按下回车后自动提交
        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                BtnOk_Click(sender, e);
            }
        }
    }
}
