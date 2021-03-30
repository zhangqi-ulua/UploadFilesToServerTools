
namespace UploadFilesToServerTools
{
    partial class EditConfigUserControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.GrpConfig = new System.Windows.Forms.GroupBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtRemark = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtServerFolderPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtHost = new System.Windows.Forms.TextBox();
            this.BtnChooseLocalFolder = new System.Windows.Forms.Button();
            this.TxtLocalFolderPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GrpConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpConfig
            // 
            this.GrpConfig.Controls.Add(this.BtnDelete);
            this.GrpConfig.Controls.Add(this.TxtPassword);
            this.GrpConfig.Controls.Add(this.label7);
            this.GrpConfig.Controls.Add(this.TxtUsername);
            this.GrpConfig.Controls.Add(this.label6);
            this.GrpConfig.Controls.Add(this.TxtRemark);
            this.GrpConfig.Controls.Add(this.label5);
            this.GrpConfig.Controls.Add(this.TxtServerFolderPath);
            this.GrpConfig.Controls.Add(this.label4);
            this.GrpConfig.Controls.Add(this.TxtHost);
            this.GrpConfig.Controls.Add(this.BtnChooseLocalFolder);
            this.GrpConfig.Controls.Add(this.TxtLocalFolderPath);
            this.GrpConfig.Controls.Add(this.label3);
            this.GrpConfig.Controls.Add(this.label2);
            this.GrpConfig.Location = new System.Drawing.Point(3, 3);
            this.GrpConfig.Name = "GrpConfig";
            this.GrpConfig.Size = new System.Drawing.Size(611, 183);
            this.GrpConfig.TabIndex = 1;
            this.GrpConfig.TabStop = false;
            this.GrpConfig.Text = "模板";
            // 
            // BtnDelete
            // 
            this.BtnDelete.ForeColor = System.Drawing.Color.Red;
            this.BtnDelete.Location = new System.Drawing.Point(546, 21);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(49, 23);
            this.BtnDelete.TabIndex = 14;
            this.BtnDelete.Tag = "TagDelete";
            this.BtnDelete.Text = "删除";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(372, 83);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(223, 21);
            this.TxtPassword.TabIndex = 13;
            this.TxtPassword.Tag = "TagPassword";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(325, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "密码：";
            // 
            // TxtUsername
            // 
            this.TxtUsername.Location = new System.Drawing.Point(85, 83);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(223, 21);
            this.TxtUsername.TabIndex = 11;
            this.TxtUsername.Tag = "TagUsername";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "用户名：";
            // 
            // TxtRemark
            // 
            this.TxtRemark.Location = new System.Drawing.Point(85, 23);
            this.TxtRemark.Name = "TxtRemark";
            this.TxtRemark.Size = new System.Drawing.Size(449, 21);
            this.TxtRemark.TabIndex = 9;
            this.TxtRemark.Tag = "TagRemark";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "备注：";
            // 
            // TxtServerFolderPath
            // 
            this.TxtServerFolderPath.Location = new System.Drawing.Point(84, 113);
            this.TxtServerFolderPath.Name = "TxtServerFolderPath";
            this.TxtServerFolderPath.Size = new System.Drawing.Size(511, 21);
            this.TxtServerFolderPath.TabIndex = 7;
            this.TxtServerFolderPath.Tag = "TagServerFolderPath";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "上传目录：";
            // 
            // TxtHost
            // 
            this.TxtHost.Location = new System.Drawing.Point(85, 53);
            this.TxtHost.Name = "TxtHost";
            this.TxtHost.Size = new System.Drawing.Size(511, 21);
            this.TxtHost.TabIndex = 5;
            this.TxtHost.Tag = "TagHost";
            this.TxtHost.Enter += new System.EventHandler(this.TxtHost_Enter);
            this.TxtHost.Leave += new System.EventHandler(this.TxtHost_Leave);
            // 
            // BtnChooseLocalFolder
            // 
            this.BtnChooseLocalFolder.Location = new System.Drawing.Point(546, 141);
            this.BtnChooseLocalFolder.Name = "BtnChooseLocalFolder";
            this.BtnChooseLocalFolder.Size = new System.Drawing.Size(49, 23);
            this.BtnChooseLocalFolder.TabIndex = 4;
            this.BtnChooseLocalFolder.Tag = "TagChooseLocalFolder";
            this.BtnChooseLocalFolder.Text = "打开";
            this.BtnChooseLocalFolder.UseVisualStyleBackColor = true;
            this.BtnChooseLocalFolder.Click += new System.EventHandler(this.BtnChooseLocalFolder_Click);
            // 
            // TxtLocalFolderPath
            // 
            this.TxtLocalFolderPath.AllowDrop = true;
            this.TxtLocalFolderPath.Location = new System.Drawing.Point(121, 143);
            this.TxtLocalFolderPath.Name = "TxtLocalFolderPath";
            this.TxtLocalFolderPath.Size = new System.Drawing.Size(413, 21);
            this.TxtLocalFolderPath.TabIndex = 3;
            this.TxtLocalFolderPath.Tag = "TagLocalFolderPath";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "本地文件夹路径：\r\n（支持拖拽）";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Host：";
            // 
            // EditConfigUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrpConfig);
            this.Name = "EditConfigUserControl";
            this.Size = new System.Drawing.Size(619, 192);
            this.GrpConfig.ResumeLayout(false);
            this.GrpConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpConfig;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtUsername;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtRemark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtServerFolderPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtHost;
        private System.Windows.Forms.Button BtnChooseLocalFolder;
        private System.Windows.Forms.TextBox TxtLocalFolderPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
