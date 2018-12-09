using Baidu.Aip.Ocr;
using ImageMagick;
using IronPython.Hosting;
using Newtonsoft.Json.Linq;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace contractCompare
{
    public static class Services
    {
        static Ocr client = null;
        static ProgressBar _bar = null;
        static Services()
        {
            MagickNET.SetGhostscriptDirectory(@"E:\contract_compare\ghostscript");
        }

        public static void InitProgressBar(ProgressBar bar)
        {
            _bar = bar;
        }

        public static Ocr GetBaiduOCRClient()
        {
            if (client == null)
            {
                client = new Ocr("fD5N0AvQTTA7GED4RdY7tDg2", "CEcf9ASn9OMebosXTyQGFHh0NNtrRBm0");
                client.Timeout = 60000;
            }
            return client;
        }

        public static bool IsDocPdfVaild(string wordPath, string pdfPath, out string errMsg)
        {
            errMsg = "";
            const string DOCX_ID = "8075", PDF_ID = "3780";
            var errorPathList = new List<string>();
            var errorFileList = new List<string>();
            if (!File.Exists(wordPath)) errorPathList.Add("Docx");
            if (!File.Exists(pdfPath)) errorPathList.Add("PDF");
            if (errorPathList.Count > 0)
            {
                errMsg = $"选择的{string.Join("和", errorPathList)}文件不存在！";
                return false;
            }
            var fw = File.OpenRead(wordPath);
            var fp = File.OpenRead(pdfPath);
            var bw = new BinaryReader(fw);
            var bp = new BinaryReader(fp);
            var bwId = string.Join("", bw.ReadBytes(2));
            var bpId = string.Join("", bp.ReadBytes(2));
            if (bwId != DOCX_ID) errorFileList.Add("Docx");
            if (bpId != PDF_ID) errorFileList.Add("PDF");
            if (errorFileList.Count > 0)
            {
                errMsg = $"选择的{string.Join("和", errorFileList)}文件打开错误，文件类型不正确！";
                return false;
            }
            return true;
        }

        public static string GetTextFromDoc(string docPath)
        {
            var doc = DocX.Load(docPath);
            var txt = string.Join("\n", doc.Paragraphs.Select(p => p.Text));
            doc.Dispose();
            return txt;
        }

        public static string GetTextFromPDF(string pdfPath)
        {
            var textBuilder = new StringBuilder();
            var pdf = PdfReader.Open(pdfPath, PdfDocumentOpenMode.Import);
            int startPage = 0, endPage = pdf.PageCount;
            //处理pdf前，处理pdf后各占一位，5页pdf转图片占一位，pdf每页做OCR占一位
            _bar.Maximum = endPage + ((endPage - 1) / 5 + 1) + 2; 
            _bar.Value = 1;
            while (startPage < endPage)
            {
                var partialPdf = new PdfDocument();
                partialPdf.Version = pdf.Version;
                for (int i = startPage; i < Math.Min(startPage + 5, endPage); i++)
                {
                    partialPdf.AddPage(pdf.Pages[i]);
                }
                partialPdf.Save("temp.pdf");
                var partialText = GetPartialTextFromPDF("temp.pdf");
                if (partialText == null) { return null; }
                textBuilder.Append(partialText);
                startPage += 5;
                File.Delete("temp.pdf");
            }
            return textBuilder.ToString();
        }

        public static void AnalyseDiffByPython()
        {
            var ssa = Python.CreateEngine();
            var ssb = ssa.CreateScope();
            var ssc = ssa.CreateScriptSourceFromFile("comparer.py", Encoding.UTF8);
            ssc.Execute(ssb);
        }

        private static string GetPartialTextFromPDF(string pdfPath)
        {
            var client = GetBaiduOCRClient();
            var textList = new List<string>();
            var settings = new MagickReadSettings()
            {
                Density = new Density(450)
            };
            using (var imgs = new MagickImageCollection())
            {
                imgs.Read(pdfPath, settings);
                _bar.Value++;
                foreach (var g in imgs)
                {
                    var gb = g.ToByteArray(MagickFormat.Jpeg);
                    var f = File.OpenWrite(@"E:\xx.jpg");
                    f.Write(gb, 0, gb.Length);
                    f.Close();
            picOCR:
                    try
                    {
                        var result = client.GeneralBasic(gb);
                        textList.AddRange(((JArray)result["words_result"]).Select(o => o["words"].Value<string>()));
                        _bar.Value++;
                    }
                    //duwei TODO: 
                    catch (Exception e)
                    {
                        var errAction = MessageBox.Show($"进行PDF解析时出现错误：{e.Message}", "PDF解析错误", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        if (errAction == DialogResult.Retry)
                        {
                            goto picOCR;
                        }
                        else { return null; }

                    }
                }
            }
            return string.Join("\n", textList);
        }
    }
}
