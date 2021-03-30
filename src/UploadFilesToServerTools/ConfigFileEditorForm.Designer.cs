
namespace UploadFilesToServerTools
{
    partial class ConfigFileEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Pnl = new System.Windows.Forms.Panel();
            this.LblCurrentPathTips = new System.Windows.Forms.Label();
            this.LblCurrentConfigFilePath = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnSaveAs = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtViewPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtEditPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Pnl
            // 
            this.Pnl.AutoScroll = true;
            this.Pnl.Location = new System.Drawing.Point(21, 101);
            this.Pnl.Name = "Pnl";
            this.Pnl.Size = new System.Drawing.Size(653, 554);
            this.Pnl.TabIndex = 3;
            // 
            // LblCurrentPathTips
            // 
            this.LblCurrentPathTips.AutoSize = true;
            this.LblCurrentPathTips.Location = new System.Drawing.Point(19, 25);
            this.LblCurrentPathTips.Name = "LblCurrentPathTips";
            this.LblCurrentPathTips.Size = new System.Drawing.Size(113, 12);
            this.LblCurrentPathTips.TabIndex = 4;
            this.LblCurrentPathTips.Text = "当前配置文件路径：";
            // 
            // LblCurrentConfigFilePath
            // 
            this.LblCurrentConfigFilePath.AutoSize = true;
            this.LblCurrentConfigFilePath.Location = new System.Drawing.Point(138, 25);
            this.LblCurrentConfigFilePath.Name = "LblCurrentConfigFilePath";
            this.LblCurrentConfigFilePath.Size = new System.Drawing.Size(0, 12);
            this.LblCurrentConfigFilePath.TabIndex = 5;
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSave.Location = new System.Drawing.Point(21, 50);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(79, 35);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnSaveAs
            // 
            this.BtnSaveAs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSaveAs.Location = new System.Drawing.Point(127, 50);
            this.BtnSaveAs.Name = "BtnSaveAs";
            this.BtnSaveAs.Size = new System.Drawing.Size(79, 35);
            this.BtnSaveAs.TabIndex = 7;
            this.BtnSaveAs.Text = "另存为";
            this.BtnSaveAs.UseVisualStyleBackColor = true;
            this.BtnSaveAs.Click += new System.EventHandler(this.BtnSaveAs_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAdd.ForeColor = System.Drawing.Color.Green;
            this.BtnAdd.Location = new System.Drawing.Point(563, 62);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(111, 23);
            this.BtnAdd.TabIndex = 8;
            this.BtnAdd.Text = "新增配置项";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(268, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "使用者密码：";
            // 
            // TxtViewPassword
            // 
            this.TxtViewPassword.Location = new System.Drawing.Point(351, 50);
            this.TxtViewPassword.Name = "TxtViewPassword";
            this.TxtViewPassword.Size = new System.Drawing.Size(176, 21);
            this.TxtViewPassword.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(268, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "管理员密码：";
            // 
            // TxtEditPassword
            // 
            this.TxtEditPassword.Location = new System.Drawing.Point(351, 73);
            this.TxtEditPassword.Name = "TxtEditPassword";
            this.TxtEditPassword.Size = new System.Drawing.Size(176, 21);
            this.TxtEditPassword.TabIndex = 12;
            // 
            // ConfigFileEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 674);
            this.Controls.Add(this.TxtEditPassword);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtViewPassword);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnSaveAs);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.LblCurrentConfigFilePath);
            this.Controls.Add(this.LblCurrentPathTips);
            this.Controls.Add(this.Pnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ConfigFileEditorForm";
            this.Text = "配置文件编辑器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigFileEditorForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Pnl;
        private System.Windows.Forms.Label LblCurrentPathTips;
        private System.Windows.Forms.Label LblCurrentConfigFilePath;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnSaveAs;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtViewPassword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtEditPassword;
    }
}