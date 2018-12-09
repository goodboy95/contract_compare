using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageMagick;

namespace contractCompare
{
    public partial class Form1 : Form
    {
        private string wordFileName = "", pdfFileName = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void disposeObjects(params IDisposable[] objs)
        {
            foreach (var obj in objs) obj.Dispose();
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
            //string strOutput = p.StandardOutput.ReadToEnd();
            //等待程序执行完退出进程
            p.WaitForExit();
            p.Close();
            return "";
        }

        private void textBoxProcess(RichTextBox textBox, string diffStr)
        {
            const int MARKED_WORD_LEN = 10;
            var idx = 0;
            var variedList = new List<int>();
            var sb = new StringBuilder();
            while (idx < diffStr.Length)
            {
                if (diffStr[idx] != 27)
                {
                    sb.Append(diffStr[idx]);
                    idx++;
                }
                else
                {
                    variedList.Add(sb.Length);
                    var markedWord = diffStr.Substring(idx, MARKED_WORD_LEN);
                    var replaceWord = markedWord[5];
                    sb.Append(replaceWord);
                    idx += 10;
                }
            }
            textBox.Text = sb.ToString();
            foreach (var varyPtr in variedList)
            {
                textBox.Select(varyPtr, 1);
                textBox.SelectionColor = Color.Red;
            }
        }

        private void WordBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var wordPath = openFileDialog1.FileName;
                wordFileName = openFileDialog1.SafeFileName;
                wordPathBox.Text = wordPath;
            }
        }

        private void pdfBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var pdfPath = openFileDialog1.FileName;
                pdfFileName = openFileDialog1.SafeFileName;
                pdfPathBox.Text = pdfPath;
            }
        }

        private void wordTextBox_VScroll(object sender, EventArgs e)
        {
            var pct1 = wordTextBox.sc
            MessageBox.Show("hw");
        }

        private void pdfTextBox_VScroll(object sender, EventArgs e)
        {
            MessageBox.Show("hw2");
        }

        private void runCompare_Click(object sender, EventArgs e)
        {        
            loadProgress.Value = 0;
            Services.InitProgressBar(loadProgress);
            if (File.Exists("doc_diff.txt")) File.Delete("doc_diff.txt");
            if (File.Exists("pdf_diff.txt")) File.Delete("pdf_diff.txt");
            var wordPath = wordPathBox.Text;
            var pdfPath = pdfPathBox.Text;
            if (!Services.IsDocPdfVaild(wordPath, pdfPath, out string err))
            {
                MessageBox.Show(err);
                return;
            }
            var docText = Services.GetTextFromDoc(wordPath);
            var pdfText = Services.GetTextFromPDF(pdfPath);
            if (pdfText == null)
            {
                loadProgress.Value = 0;
                return;
            }
            var fw1 = File.OpenWrite("doc_txt.txt");
            var fw2 = File.OpenWrite("pdf_txt.txt");
            var sw1 = new StreamWriter(fw1);
            var sw2 = new StreamWriter(fw2);
            sw1.Write(docText);
            sw2.Write(pdfText);
            disposeObjects(sw1, sw2, fw1, fw2);
            Services.AnalyseDiffByPython();

            var f1 = File.OpenRead("doc_diff.txt");
            var f2 = File.OpenRead("pdf_diff.txt");
            var sr1 = new StreamReader(f1);
            var sr2 = new StreamReader(f2);
            var docDiff = sr1.ReadToEnd();
            var pdfDiff = sr2.ReadToEnd();
            disposeObjects(sr1, sr2, f1, f2);
            textBoxProcess(wordTextBox, docDiff);
            textBoxProcess(pdfTextBox, pdfDiff);
            loadProgress.Value = loadProgress.Maximum;
        }
    }
}
