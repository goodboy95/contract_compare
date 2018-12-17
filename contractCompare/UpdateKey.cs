using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace contractCompare
{
    public partial class UpdateKey : Form
    {
        public UpdateKey()
        {
            InitializeComponent();
        }

        public UpdateKey(string label)
        {
            InitializeComponent();
            label1.Text = label;
        }

        public UpdateKey(string label, string title)
        {
            InitializeComponent();
            label1.Text = label;
            this.Text = title;
        }

        public string ApiKey { get; set; }
        public string SecretKey { get; set; }

        private void UpdateKey_Load(object sender, EventArgs e)
        {
            this.AcceptButton = this.OKBtn;
            this.CancelButton = this.cancelBtn;
        }

        //取消
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        //确定
        private void OKBtn_Click(object sender, EventArgs e)
        {
            if (File.Exists("ocrkey.ini")) { File.Delete("ocrkey.ini"); }
            var f = File.OpenWrite("ocrkey.ini");
            var sw = new StreamWriter(f);
            ApiKey = apiKeyBox.Text;
            SecretKey = secretKeyBox.Text;
            sw.WriteLine(ApiKey);
            sw.WriteLine(SecretKey);
            sw.Close();
            f.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        
    }
}
