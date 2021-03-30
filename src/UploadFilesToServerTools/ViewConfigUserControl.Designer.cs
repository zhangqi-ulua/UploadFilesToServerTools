
namespace UploadFilesToServerTools
{
    partial class ViewConfigUserControl
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
            this.BtnUpload = new System.Windows.Forms.Button();
            this.BtnChooseLocalFolder = new System.Windows.Forms.Button();
            this.TxtLocalFolderPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LblServerPath = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblUploadPath = new System.Windows.Forms.Label();
            this.LblUploadProgress = new System.Windows.Forms.Label();
            this.GrpConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpConfig
            // 
            this.GrpConfig.Controls.Add(this.LblUploadProgress);
            this.GrpConfig.Controls.Add(this.LblUploadPath);
            this.GrpConfig.Controls.Add(this.BtnUpload);
            this.GrpConfig.Controls.Add(this.BtnChooseLocalFolder);
            this.GrpConfig.Controls.Add(this.TxtLocalFolderPath);
            this.GrpConfig.Controls.Add(this.label3);
            this.GrpConfig.Controls.Add(this.LblServerPath);
            this.GrpConfig.Controls.Add(this.label2);
            this.GrpConfig.Location = new System.Drawing.Point(3, 3);
            this.GrpConfig.Name = "GrpConfig";
            this.GrpConfig.Size = new System.Drawing.Size(611, 133);
            this.GrpConfig.TabIndex = 1;
            this.GrpConfig.TabStop = false;
            this.GrpConfig.Text = "模板";
            // 
            // BtnUpload
            // 
            this.BtnUpload.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnUpload.Location = new System.Drawing.Point(20, 95);
            this.BtnUpload.Name = "BtnUpload";
            this.BtnUpload.Size = new System.Drawing.Size(75, 23);
            this.BtnUpload.TabIndex = 5;
            this.BtnUpload.Tag = "TagUpload";
            this.BtnUpload.Text = "上传";
            this.BtnUpload.UseVisualStyleBackColor = true;
            this.BtnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // BtnChooseLocalFolder
            // 
            this.BtnChooseLocalFolder.Location = new System.Drawing.Point(550, 54);
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
            this.TxtLocalFolderPath.Location = new System.Drawing.Point(125, 56);
            this.TxtLocalFolderPath.Name = "TxtLocalFolderPath";
            this.TxtLocalFolderPath.Size = new System.Drawing.Size(413, 21);
            this.TxtLocalFolderPath.TabIndex = 3;
            this.TxtLocalFolderPath.Tag = "TagLocalFolderPath";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "本地文件夹路径：\r\n（支持拖拽）";
            // 
            // LblServerPath
            // 
            this.LblServerPath.AutoSize = true;
            this.LblServerPath.Location = new System.Drawing.Point(125, 29);
            this.LblServerPath.Name = "LblServerPath";
            this.LblServerPath.Size = new System.Drawing.Size(0, 12);
            this.LblServerPath.TabIndex = 1;
            this.LblServerPath.Tag = "TagServerPath";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "服务器目录地址：";
            // 
            // LblUploadPath
            // 
            this.LblUploadPath.Location = new System.Drawing.Point(110, 95);
            this.LblUploadPath.Name = "LblUploadPath";
            this.LblUploadPath.Size = new System.Drawing.Size(489, 12);
            this.LblUploadPath.TabIndex = 6;
            // 
            // LblUploadProgress
            // 
            this.LblUploadProgress.Location = new System.Drawing.Point(110, 110);
            this.LblUploadProgress.Name = "LblUploadProgress";
            this.LblUploadProgress.Size = new System.Drawing.Size(489, 12);
            this.LblUploadProgress.TabIndex = 7;
            // 
            // ViewConfigUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrpConfig);
            this.Name = "ViewConfigUserControl";
            this.Size = new System.Drawing.Size(618, 140);
            this.GrpConfig.ResumeLayout(false);
            this.GrpConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpConfig;
        private System.Windows.Forms.Button BtnUpload;
        private System.Windows.Forms.Button BtnChooseLocalFolder;
        private System.Windows.Forms.TextBox TxtLocalFolderPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblServerPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblUploadPath;
        private System.Windows.Forms.Label LblUploadProgress;
    }
}
