
namespace UploadFilesToServerTools
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnLoadConfigFile = new System.Windows.Forms.Button();
            this.BtnConfigFileEditor = new System.Windows.Forms.Button();
            this.Pnl = new System.Windows.Forms.Panel();
            this.GrpConfig = new System.Windows.Forms.GroupBox();
            this.BtnUpload = new System.Windows.Forms.Button();
            this.BtnChooseLocalFolder = new System.Windows.Forms.Button();
            this.TxtLocalFolderPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LblServerPath = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblCurrentConfigFilePath = new System.Windows.Forms.Label();
            this.BtnSaveLocalPathToConfigFile = new System.Windows.Forms.Button();
            this.BtnShowLog = new System.Windows.Forms.Button();
            this.RtxLog = new System.Windows.Forms.RichTextBox();
            this.Pnl.SuspendLayout();
            this.GrpConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnLoadConfigFile
            // 
            this.BtnLoadConfigFile.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnLoadConfigFile.Location = new System.Drawing.Point(21, 21);
            this.BtnLoadConfigFile.Name = "BtnLoadConfigFile";
            this.BtnLoadConfigFile.Size = new System.Drawing.Size(137, 37);
            this.BtnLoadConfigFile.TabIndex = 0;
            this.BtnLoadConfigFile.Text = "载入配置文件";
            this.BtnLoadConfigFile.UseVisualStyleBackColor = true;
            this.BtnLoadConfigFile.Click += new System.EventHandler(this.BtnLoadConfigFile_Click);
            // 
            // BtnConfigFileEditor
            // 
            this.BtnConfigFileEditor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnConfigFileEditor.Location = new System.Drawing.Point(511, 21);
            this.BtnConfigFileEditor.Name = "BtnConfigFileEditor";
            this.BtnConfigFileEditor.Size = new System.Drawing.Size(137, 37);
            this.BtnConfigFileEditor.TabIndex = 1;
            this.BtnConfigFileEditor.Text = "配置文件编辑器";
            this.BtnConfigFileEditor.UseVisualStyleBackColor = true;
            this.BtnConfigFileEditor.Click += new System.EventHandler(this.BtnConfigFileEditor_Click);
            // 
            // Pnl
            // 
            this.Pnl.AutoScroll = true;
            this.Pnl.Controls.Add(this.GrpConfig);
            this.Pnl.Location = new System.Drawing.Point(21, 103);
            this.Pnl.Name = "Pnl";
            this.Pnl.Size = new System.Drawing.Size(655, 554);
            this.Pnl.TabIndex = 2;
            // 
            // GrpConfig
            // 
            this.GrpConfig.Controls.Add(this.BtnUpload);
            this.GrpConfig.Controls.Add(this.BtnChooseLocalFolder);
            this.GrpConfig.Controls.Add(this.TxtLocalFolderPath);
            this.GrpConfig.Controls.Add(this.label3);
            this.GrpConfig.Controls.Add(this.LblServerPath);
            this.GrpConfig.Controls.Add(this.label2);
            this.GrpConfig.Location = new System.Drawing.Point(16, 20);
            this.GrpConfig.Name = "GrpConfig";
            this.GrpConfig.Size = new System.Drawing.Size(611, 133);
            this.GrpConfig.TabIndex = 0;
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
            // 
            // TxtLocalFolderPath
            // 
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
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "本地文件夹路径：";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "当前配置文件路径：";
            // 
            // LblCurrentConfigFilePath
            // 
            this.LblCurrentConfigFilePath.AutoSize = true;
            this.LblCurrentConfigFilePath.Location = new System.Drawing.Point(138, 75);
            this.LblCurrentConfigFilePath.Name = "LblCurrentConfigFilePath";
            this.LblCurrentConfigFilePath.Size = new System.Drawing.Size(0, 12);
            this.LblCurrentConfigFilePath.TabIndex = 4;
            // 
            // BtnSaveLocalPathToConfigFile
            // 
            this.BtnSaveLocalPathToConfigFile.Location = new System.Drawing.Point(186, 35);
            this.BtnSaveLocalPathToConfigFile.Name = "BtnSaveLocalPathToConfigFile";
            this.BtnSaveLocalPathToConfigFile.Size = new System.Drawing.Size(240, 23);
            this.BtnSaveLocalPathToConfigFile.TabIndex = 5;
            this.BtnSaveLocalPathToConfigFile.Text = "将当前对本地路径的修改保存到配置文件";
            this.BtnSaveLocalPathToConfigFile.UseVisualStyleBackColor = true;
            this.BtnSaveLocalPathToConfigFile.Click += new System.EventHandler(this.BtnSaveLocalPathToConfigFile_Click);
            // 
            // BtnShowLog
            // 
            this.BtnShowLog.Location = new System.Drawing.Point(688, 255);
            this.BtnShowLog.Name = "BtnShowLog";
            this.BtnShowLog.Size = new System.Drawing.Size(24, 164);
            this.BtnShowLog.TabIndex = 6;
            this.BtnShowLog.Text = "查  看  日  志";
            this.BtnShowLog.UseVisualStyleBackColor = true;
            this.BtnShowLog.Click += new System.EventHandler(this.BtnShowLog_Click);
            // 
            // RtxLog
            // 
            this.RtxLog.Location = new System.Drawing.Point(723, 21);
            this.RtxLog.Name = "RtxLog";
            this.RtxLog.Size = new System.Drawing.Size(550, 636);
            this.RtxLog.TabIndex = 7;
            this.RtxLog.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 674);
            this.Controls.Add(this.RtxLog);
            this.Controls.Add(this.BtnShowLog);
            this.Controls.Add(this.BtnSaveLocalPathToConfigFile);
            this.Controls.Add(this.LblCurrentConfigFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pnl);
            this.Controls.Add(this.BtnConfigFileEditor);
            this.Controls.Add(this.BtnLoadConfigFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "资源上传FTP工具 by 张齐";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Pnl.ResumeLayout(false);
            this.GrpConfig.ResumeLayout(false);
            this.GrpConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLoadConfigFile;
        private System.Windows.Forms.Button BtnConfigFileEditor;
        private System.Windows.Forms.Panel Pnl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblCurrentConfigFilePath;
        private System.Windows.Forms.Button BtnSaveLocalPathToConfigFile;
        private System.Windows.Forms.GroupBox GrpConfig;
        private System.Windows.Forms.Button BtnUpload;
        private System.Windows.Forms.Button BtnChooseLocalFolder;
        private System.Windows.Forms.TextBox TxtLocalFolderPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblServerPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnShowLog;
        private System.Windows.Forms.RichTextBox RtxLog;
    }
}

