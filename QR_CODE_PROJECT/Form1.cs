using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WIA;
using WebEye.Controls.WinForms;
using WebEye.Controls.WinForms.WebCameraControl;
using QR_Project_BL;
using System.IO;
using System.Diagnostics;
using System.Windows.Controls;

namespace QR_CODE_PROJECT
{
    public partial class Form1 : Form
    {
        string videoPath = "";
        string resultPath = "";
        DateTime Santa = new DateTime(2017, 12, 25);
        WebCameraControl myWebControl = new WebCameraControl();
        public Form1()
        {
            InitializeComponent();
            int result = DateTime.Compare(DateTime.Now, Santa);
            if (result > 0)
            {
                Environment.Exit(0);
            }
        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void btnLoadVideo_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                videoPath = openFileDialog1.FileName;
                txtVideoPath.Text = videoPath;
            }
        }

        private void btnPathToReport_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                resultPath = folderBrowserDialog1.SelectedPath;
                txtPathToReport.Text = resultPath + @"\report.txt";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((videoPath != "") && (resultPath != ""))
            {
                ImageQueueHandler myAlgo = new ImageQueueHandler(videoPath, resultPath);
                button1.Enabled = false;
                Task t1 = Task.Run(() => myAlgo.startAnalysisOnThreads());
                Task.WaitAll(t1);
                btnOpenResult.Enabled = true;
                button1.Enabled = true;

            }
        }

        private void btnOpenResult_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtPathToReport.Text))
            {
                Process.Start("notepad.exe", txtPathToReport.Text);
            }           
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            List<WebCameraId> listWebCams = new List<WebCameraId>();
            foreach (WebCameraId camera in myWebControl.GetVideoCaptureDevices())
            {
                listWebCams.Add(camera);
            }

            lstCameras.DataSource = listWebCams;
        }

    }

}
