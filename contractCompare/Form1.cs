using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace contractCompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string CallCMD(string callStr)
        {
            Process p = new Process();
            //设置要启动的应用程序
            p.StartInfo.FileName = "cmd.exe";
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardInput = true;
            //输出信息
            p.StartInfo.RedirectStandardOutput = true;
            // 输出错误
            p.StartInfo.RedirectStandardError = true;
            //不显示程序窗口
            //p.StartInfo.CreateNoWindow = true;
            //启动程序
            p.Start();
            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(callStr);
            p.StandardInput.AutoFlush = true;
            //获取输出信息
            string strOutput = p.StandardOutput.ReadToEnd();
            //等待程序执行完退出进程
            p.WaitForExit();
            p.Close();
            return strOutput;
        }


        private void WordBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            var wordPath = openFileDialog1.FileName;
            wordPathBox.Text = wordPath;
        }

        private void pdfBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            var pdfPath = openFileDialog1.FileName;
            pdfPathBox.Text = pdfPath;
        }

        private void runCompare_Click(object sender, EventArgs e)
        {
            var wordPath = wordPathBox.Text;
            var pdfPath = pdfPathBox.Text;
            if (!File.Exists(wordPath) || !File.Exists(pdfPath))
            {

                //return;
            }
            var output = CallCMD($"python3 ../../comparer.py {wordPath} {pdfPath}");
        }
    }
}
