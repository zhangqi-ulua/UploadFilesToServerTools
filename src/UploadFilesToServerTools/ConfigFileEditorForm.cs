using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace UploadFilesToServerTools
{
    public partial class ConfigFileEditorForm : Form
    {
        // 配置组件之间的y轴距离
        private const int _CONFIG_CONTROL_DISTANCE_Y = 200;

        // 如果当前是打开已存在的配置文件，记录其路径
        private string _CurrentConfigFilePath;
        // 如果当前是打开已存在的配置文件，存储其ConfigFileVO
        private ConfigFileVO _CurrentConfigFileVO;

        // 与当前界面显示的配置项顺序一一对应
        private List<EditConfigUserControl> _EditConfigUserControlList = new List<EditConfigUserControl>();
        // 当前是否是保存成功后，强制关闭窗口
        private bool _IsForceClose = false;

        public ConfigFileEditorForm(ConfigFileVO vo)
        {
            InitializeComponent();

            _CurrentConfigFileVO = vo;
            // 新建的不传入配置文件路径，隐藏“另存为”按钮和路径
            if (string.IsNullOrEmpty(vo.ConfigFilePath))
            {
                LblCurrentPathTips.Visible = false;
                LblCurrentConfigFilePath.Visible = false;
                BtnSaveAs.Visible = false;
            }
            else
            {
                _CurrentConfigFilePath = vo.ConfigFilePath;
                LblCurrentConfigFilePath.Text = vo.ConfigFilePath;
            }

            TxtEditPassword.Text = vo.EditPassword;
            TxtViewPassword.Text = vo.ViewPassword;
            foreach (OneConfigJsonVO oneConfig in vo.AllConfigs)
            {
                EditConfigUserControl newControl = new EditConfigUserControl(this, oneConfig);
                _EditConfigUserControlList.Add(newControl);
                Pnl.Controls.Add(newControl);
            }
            ResetConfigControlLocation();
        }

        private ConfigFileVO _CheckAndGetConfigs(out string errorInfo)
        {
            ConfigFileVO vo = new ConfigFileVO();
            if (_EditConfigUserControlList.Count < 1)
            {
                errorInfo = "当前没有任何配置";
                return null;
            }
            /**
             * 使用者密码
             */
            string inputViewPassword = TxtViewPassword.Text.Trim();
            if (string.IsNullOrEmpty(inputViewPassword))
            {
                errorInfo = "未输入使用者密码";
                return null;
            }
            vo.ViewPassword = inputViewPassword;
            /**
             * 编辑密码
             */
            string inputEditPassword = TxtEditPassword.Text.Trim();
            if (string.IsNullOrEmpty(inputEditPassword))
            {
                errorInfo = "未输入管理员密码";
                return null;
            }
            vo.EditPassword = inputEditPassword;
            if (inputViewPassword.Equals(inputEditPassword))
            {
                errorInfo = "管理员密码不能与使用者密码相同";
                return null;
            }
            /**
             * 检查每一个配置项
             */
            bool isAllConfigCheckOk = true;
            StringBuilder errorStringBuilder = new StringBuilder();
            for (int i = 0; i < _EditConfigUserControlList.Count; i++)
            {
                string oneConfigErrorInfo = null;
                OneConfigJsonVO oneConfigVO = _EditConfigUserControlList[i].CheckAndGetConfig(out oneConfigErrorInfo);
                if (oneConfigVO == null)
                {
                    isAllConfigCheckOk = false;
                    errorStringBuilder.AppendLine($"第{i + 1}个配置项存在错误：{oneConfigErrorInfo}");
                }
                vo.AllConfigs.Add(oneConfigVO);
            }
            if (isAllConfigCheckOk == false)
            {
                errorInfo = errorStringBuilder.ToString();
                return null;
            }

            errorInfo = null;
            return vo;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            EditConfigUserControl newControl = new EditConfigUserControl(this);
            _EditConfigUserControlList.Add(newControl);
            Pnl.Controls.Add(newControl);
            ResetConfigControlLocation();
        }

        public void DeleteConfig(EditConfigUserControl control)
        {
            Pnl.Controls.Remove(control);
            _EditConfigUserControlList.Remove(control);
            ResetConfigControlLocation();
        }

        private void ResetConfigControlLocation()
        {
            for (int i = 0; i < _EditConfigUserControlList.Count; i++)
            {
                _EditConfigUserControlList[i].Location = new Point(0, i * _CONFIG_CONTROL_DISTANCE_Y - Pnl.VerticalScroll.Value);
                _EditConfigUserControlList[i].SetGroupBoxTitle((i + 1).ToString());
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string errorInfo = null;
            ConfigFileVO vo = _CheckAndGetConfigs(out errorInfo);
            if (vo == null)
            {
                MessageBox.Show(this, errorInfo, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_CurrentConfigFilePath == null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "请选择要保存的路径";
                dialog.Filter = $"(*.{Utils.CONFIG_FILE_EXTENSION})|*.{Utils.CONFIG_FILE_EXTENSION}";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Utils.WriteConfigFile(vo, dialog.FileName);
                    MessageBox.Show(this, $"保存配置文件成功，路径为{dialog.FileName}\n\n点击“确定”后将自动关闭此窗口", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _IsForceClose = true;
                    Close();
                }
            }
            else
            {
                Utils.WriteConfigFile(vo, _CurrentConfigFilePath);
                MessageBox.Show(this, $"保存配置文件成功，路径为{_CurrentConfigFilePath}\n\n点击“确定”后将自动关闭此窗口", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _IsForceClose = true;
                Close();
            }
        }

        private void BtnSaveAs_Click(object sender, EventArgs e)
        {
            string errorInfo = null;
            ConfigFileVO vo = _CheckAndGetConfigs(out errorInfo);
            if (vo == null)
            {
                MessageBox.Show(this, errorInfo, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "请选择要保存的路径";
            dialog.Filter = $"(*.{Utils.CONFIG_FILE_EXTENSION})|*.{Utils.CONFIG_FILE_EXTENSION}";
            // 默认选到当前打开的配置文件所在目录
            dialog.InitialDirectory = Path.GetDirectoryName(_CurrentConfigFilePath);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Utils.WriteConfigFile(vo, dialog.FileName);
                _IsForceClose = true;
                Close();
            }
        }

        private void ConfigFileEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_IsForceClose)
                return;
            // 满足以下条件需要提醒用户进行保存：1、新建配置文件并创建了配置项，2、打开已有配置并进行了修改
            // 如果是新建的配置文件并且没有新建配置项则忽略，否则在点击退出时，要弹窗提醒用户保存
            string errorInfo = null;
            if ((_CurrentConfigFilePath == null && _EditConfigUserControlList.Count > 0)
                || (_CurrentConfigFilePath != null && _CurrentConfigFileVO.IsSameConfigFileVO(_CheckAndGetConfigs(out errorInfo)) == false))
            {
                if (MessageBox.Show(this, "您有修改尚未保存，建议您保存后退出\n\n点击“是”取消退出操作\n点击“否”退出而不保存", "请确定", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    e.Cancel = true;
            }
        }
    }
}
