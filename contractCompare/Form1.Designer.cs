namespace contractCompare
{
    partial class Form1
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
            this.wordTextBox = new System.Windows.Forms.RichTextBox();
            this.pdfTextBox = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.wordPathBox = new System.Windows.Forms.TextBox();
            this.pdfPathBox = new System.Windows.Forms.TextBox();
            this.wordBtn = new System.Windows.Forms.Button();
            this.pdfBtn = new System.Windows.Forms.Button();
            this.runCompare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wordTextBox
            // 
            this.wordTextBox.Location = new System.Drawing.Point(75, 80);
            this.wordTextBox.Name = "wordTextBox";
            this.wordTextBox.Size = new System.Drawing.Size(331, 429);
            this.wordTextBox.TabIndex = 0;
            this.wordTextBox.Text = "";
            // 
            // pdfTextBox
            // 
            this.pdfTextBox.Location = new System.Drawing.Point(540, 80);
            this.pdfTextBox.Name = "pdfTextBox";
            this.pdfTextBox.Size = new System.Drawing.Size(331, 429);
            this.pdfTextBox.TabIndex = 1;
            this.pdfTextBox.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // wordPathBox
            // 
            this.wordPathBox.Location = new System.Drawing.Point(75, 25);
            this.wordPathBox.Name = "wordPathBox";
            this.wordPathBox.Size = new System.Drawing.Size(329, 25);
            this.wordPathBox.TabIndex = 2;
            // 
            // pdfPathBox
            // 
            this.pdfPathBox.Location = new System.Drawing.Point(540, 25);
            this.pdfPathBox.Name = "pdfPathBox";
            this.pdfPathBox.Size = new System.Drawing.Size(329, 25);
            this.pdfPathBox.TabIndex = 3;
            // 
            // wordBtn
            // 
            this.wordBtn.Location = new System.Drawing.Point(424, 26);
            this.wordBtn.Name = "wordBtn";
            this.wordBtn.Size = new System.Drawing.Size(59, 23);
            this.wordBtn.TabIndex = 4;
            this.wordBtn.Text = "button1";
            this.wordBtn.UseVisualStyleBackColor = true;
            this.wordBtn.Click += new System.EventHandler(this.WordBtn_Click);
            // 
            // pdfBtn
            // 
            this.pdfBtn.Location = new System.Drawing.Point(896, 26);
            this.pdfBtn.Name = "pdfBtn";
            this.pdfBtn.Size = new System.Drawing.Size(84, 23);
            this.pdfBtn.TabIndex = 5;
            this.pdfBtn.Text = "button2";
            this.pdfBtn.UseVisualStyleBackColor = true;
            this.pdfBtn.Click += new System.EventHandler(this.pdfBtn_Click);
            // 
            // runCompare
            // 
            this.runCompare.Location = new System.Drawing.Point(918, 217);
            this.runCompare.Name = "runCompare";
            this.runCompare.Size = new System.Drawing.Size(83, 38);
            this.runCompare.TabIndex = 6;
            this.runCompare.Text = "button3";
            this.runCompare.UseVisualStyleBackColor = true;
            this.runCompare.Click += new System.EventHandler(this.runCompare_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 652);
            this.Controls.Add(this.runCompare);
            this.Controls.Add(this.pdfBtn);
            this.Controls.Add(this.wordBtn);
            this.Controls.Add(this.pdfPathBox);
            this.Controls.Add(this.wordPathBox);
            this.Controls.Add(this.pdfTextBox);
            this.Controls.Add(this.wordTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox wordTextBox;
        private System.Windows.Forms.RichTextBox pdfTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox wordPathBox;
        private System.Windows.Forms.TextBox pdfPathBox;
        private System.Windows.Forms.Button wordBtn;
        private System.Windows.Forms.Button pdfBtn;
        private System.Windows.Forms.Button runCompare;
    }
}

