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
using Newtonsoft.Json.Linq;

namespace contractCompare
{
    public partial class Form1 : Form
    {
        private string wordFileName = "", pdfFileName = "";
        private string findRangeVal = "100", cautiousVal = "5";
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
            //var wordLines = wordTextBox.Lines.Length;
            //var pdfLines = pdfTextBox.Lines.Length;
            //Point p = wordTextBox.Location;
            //int wordBoxIndex = wordTextBox.GetCharIndexFromPosition(p);
            //int wordBoxLine = wordTextBox.GetLineFromCharIndex(wordBoxIndex);
            //var pdfBoxLine = (int)(((double)wordBoxLine) * pdfLines / wordLines);
            //pdfTextBox.SelectionStart = pdfTextBox.GetFirstCharIndexFromLine(pdfBoxLine);
            //pdfTextBox.SelectionLength = 0;
            //pdfTextBox.ScrollToCaret();
        }

        private void pdfTextBox_VScroll(object sender, EventArgs e)
        {
            //MessageBox.Show("hw2");
        }

        private void useSecondDiffAlg_CheckedChanged(object sender, EventArgs e)
        {
            if (useSecondDiffAlg.Checked)
            {
                findRange.Enabled = true;
                cautiousLevel.Enabled = true;
            }
            else
            {
                findRange.Enabled = false;
                cautiousLevel.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"不重新加载文件：勾选此项时，不会重新读取docx和pdf内容，适用于误关窗口或修改差异算法的场景。

使用高精度OCR：当扫描版PDF分辨率较低时，勾选此项以获得更高的文字识别精确度。

（提示：普通精度OCR每日可处理5万页PDF，高精度OCR每日可处理500页PDF，剩余用量可登录cloud.baidu.com查询）

使用第二差异算法：一般无需勾选，但如果发现差异判断出现了大量连续的误判情况，可勾选此项再次尝试。

单次查找范围：使用第二差异算法时，如果出现PDF内容缺失的情况，可适当调大此值，但该值过大可能会导致错位匹配(电子件中某词语与扫描件中不同位置的同一词语进行匹配)的情况。

谨慎度：使用第二差异算法时，如果仍旧出现大量误判的情况，可适当调小此值，但该值过小可能会导致错位匹配的情况。", "选项帮助");
        }

        private void cautiousLevel_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(cautiousLevel.Text, out int val);
            if (val <= 0 || cautiousLevel.Text.Contains(" ")) { cautiousLevel.Text = cautiousVal; }
            else { cautiousVal = cautiousLevel.Text; }
        }

        private void findRange_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(findRange.Text, out int val);
            if (val <= 0 || findRange.Text.Contains(" ")) { findRange.Text = findRangeVal; }
            else { findRangeVal = findRange.Text; }
        }

        private void runCompare_Click(object sender, EventArgs e)
        {
            // save config for python submodule
            if (File.Exists("diff_config.ini")) { File.Delete("diff_config.ini"); }
            var cf = File.OpenWrite("diff_config.ini");
            var cw = new StreamWriter(cf);
            var configJObj = new JObject() { ["secondDiffAlg"] = useSecondDiffAlg.Checked, ["diffWindow"] = int.Parse(findRange.Text), ["minChainNum"] = int.Parse(cautiousLevel.Text) };
            cw.Write(configJObj.ToString());
            disposeObjects(cw, cf);
            // diff start
            loadProgress.Value = 0;
            Services.InitProgressBar(loadProgress);
            wordTextBox.Text = "";
            pdfTextBox.Text = "";
            if (!disableReread.Checked)
            {
                if (File.Exists("doc_diff.txt")) File.Delete("doc_diff.txt");
                if (File.Exists("pdf_diff.txt")) File.Delete("pdf_diff.txt");
                if (File.Exists("doc_txt.txt")) File.Delete("doc_txt.txt");
                if (File.Exists("pdf_txt.txt")) File.Delete("pdf_txt.txt");
                var wordPath = wordPathBox.Text;
                var pdfPath = pdfPathBox.Text;
                if (!Services.IsDocPdfVaild(wordPath, pdfPath, out string err))
                {
                    MessageBox.Show(err);
                    return;
                }
                var docText = Services.GetTextFromDoc(wordPath);
                var pdfText = Services.GetTextFromPDF(pdfPath, isAccurateOCR.Checked);
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
            }
            Services.AnalyseDiffByPython();
            loadProgress.Value++;
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
