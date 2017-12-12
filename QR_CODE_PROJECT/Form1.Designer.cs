namespace QR_CODE_PROJECT
{
    partial class Form1
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnLoadVideo = new System.Windows.Forms.Button();
            this.btnPathToReport = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtVideoPath = new System.Windows.Forms.TextBox();
            this.txtPathToReport = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenResult = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gbLiveCam = new System.Windows.Forms.GroupBox();
            this.lblCameras = new System.Windows.Forms.Label();
            this.lstCameras = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.gbLiveCam.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // btnLoadVideo
            // 
            this.btnLoadVideo.Location = new System.Drawing.Point(6, 19);
            this.btnLoadVideo.Name = "btnLoadVideo";
            this.btnLoadVideo.Size = new System.Drawing.Size(94, 23);
            this.btnLoadVideo.TabIndex = 1;
            this.btnLoadVideo.Text = "Load Video";
            this.btnLoadVideo.UseVisualStyleBackColor = true;
            this.btnLoadVideo.Click += new System.EventHandler(this.btnLoadVideo_Click);
            // 
            // btnPathToReport
            // 
            this.btnPathToReport.Location = new System.Drawing.Point(6, 48);
            this.btnPathToReport.Name = "btnPathToReport";
            this.btnPathToReport.Size = new System.Drawing.Size(94, 23);
            this.btnPathToReport.TabIndex = 2;
            this.btnPathToReport.Text = "Set Report Path";
            this.btnPathToReport.UseVisualStyleBackColor = true;
            this.btnPathToReport.Click += new System.EventHandler(this.btnPathToReport_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtVideoPath
            // 
            this.txtVideoPath.Location = new System.Drawing.Point(106, 20);
            this.txtVideoPath.Name = "txtVideoPath";
            this.txtVideoPath.ReadOnly = true;
            this.txtVideoPath.Size = new System.Drawing.Size(217, 20);
            this.txtVideoPath.TabIndex = 3;
            // 
            // txtPathToReport
            // 
            this.txtPathToReport.Location = new System.Drawing.Point(104, 49);
            this.txtPathToReport.Name = "txtPathToReport";
            this.txtPathToReport.ReadOnly = true;
            this.txtPathToReport.Size = new System.Drawing.Size(217, 20);
            this.txtPathToReport.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenResult);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnLoadVideo);
            this.groupBox1.Controls.Add(this.txtPathToReport);
            this.groupBox1.Controls.Add(this.txtVideoPath);
            this.groupBox1.Controls.Add(this.btnPathToReport);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 108);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "QR Video Decoder";
            // 
            // btnOpenResult
            // 
            this.btnOpenResult.Enabled = false;
            this.btnOpenResult.Location = new System.Drawing.Point(106, 77);
            this.btnOpenResult.Name = "btnOpenResult";
            this.btnOpenResult.Size = new System.Drawing.Size(95, 23);
            this.btnOpenResult.TabIndex = 6;
            this.btnOpenResult.Text = "Open Result";
            this.btnOpenResult.UseVisualStyleBackColor = true;
            this.btnOpenResult.Click += new System.EventHandler(this.btnOpenResult_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Start Decode";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbLiveCam
            // 
            this.gbLiveCam.Controls.Add(this.lstCameras);
            this.gbLiveCam.Controls.Add(this.lblCameras);
            this.gbLiveCam.Location = new System.Drawing.Point(12, 126);
            this.gbLiveCam.Name = "gbLiveCam";
            this.gbLiveCam.Size = new System.Drawing.Size(327, 108);
            this.gbLiveCam.TabIndex = 6;
            this.gbLiveCam.TabStop = false;
            this.gbLiveCam.Text = "QR Decoder Live Cam";
            // 
            // lblCameras
            // 
            this.lblCameras.AutoSize = true;
            this.lblCameras.Location = new System.Drawing.Point(12, 22);
            this.lblCameras.Name = "lblCameras";
            this.lblCameras.Size = new System.Drawing.Size(76, 13);
            this.lblCameras.TabIndex = 1;
            this.lblCameras.Text = "Select Camera";
            // 
            // lstCameras
            // 
            this.lstCameras.FormattingEnabled = true;
            this.lstCameras.Location = new System.Drawing.Point(15, 38);
            this.lstCameras.Name = "lstCameras";
            this.lstCameras.Size = new System.Drawing.Size(186, 69);
            this.lstCameras.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 245);
            this.Controls.Add(this.gbLiveCam);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "QR Video Decoder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbLiveCam.ResumeLayout(false);
            this.gbLiveCam.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnLoadVideo;
        private System.Windows.Forms.Button btnPathToReport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtVideoPath;
        private System.Windows.Forms.TextBox txtPathToReport;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOpenResult;
        private System.Windows.Forms.GroupBox gbLiveCam;
        private System.Windows.Forms.Label lblCameras;
        private System.Windows.Forms.ListBox lstCameras;
    }
}

