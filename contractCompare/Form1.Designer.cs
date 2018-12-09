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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.loadProgress = new System.Windows.Forms.ProgressBar();
            this.isAccurateOCR = new System.Windows.Forms.CheckBox();
            this.useSecondDiffAlg = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.findRange = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cautiousLevel = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.disableReread = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // wordTextBox
            // 
            this.wordTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wordTextBox.Location = new System.Drawing.Point(9, 158);
            this.wordTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.wordTextBox.Name = "wordTextBox";
            this.wordTextBox.Size = new System.Drawing.Size(527, 533);
            this.wordTextBox.TabIndex = 0;
            this.wordTextBox.Text = "";
            this.wordTextBox.VScroll += new System.EventHandler(this.wordTextBox_VScroll);
            // 
            // pdfTextBox
            // 
            this.pdfTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pdfTextBox.Location = new System.Drawing.Point(558, 158);
            this.pdfTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pdfTextBox.Name = "pdfTextBox";
            this.pdfTextBox.Size = new System.Drawing.Size(527, 533);
            this.pdfTextBox.TabIndex = 1;
            this.pdfTextBox.Text = "";
            this.pdfTextBox.VScroll += new System.EventHandler(this.pdfTextBox_VScroll);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // wordPathBox
            // 
            this.wordPathBox.Location = new System.Drawing.Point(121, 14);
            this.wordPathBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.wordPathBox.Name = "wordPathBox";
            this.wordPathBox.ReadOnly = true;
            this.wordPathBox.Size = new System.Drawing.Size(310, 21);
            this.wordPathBox.TabIndex = 2;
            // 
            // pdfPathBox
            // 
            this.pdfPathBox.Location = new System.Drawing.Point(662, 13);
            this.pdfPathBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pdfPathBox.Name = "pdfPathBox";
            this.pdfPathBox.ReadOnly = true;
            this.pdfPathBox.Size = new System.Drawing.Size(322, 21);
            this.pdfPathBox.TabIndex = 3;
            // 
            // wordBtn
            // 
            this.wordBtn.Location = new System.Drawing.Point(453, 14);
            this.wordBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.wordBtn.Name = "wordBtn";
            this.wordBtn.Size = new System.Drawing.Size(63, 22);
            this.wordBtn.TabIndex = 4;
            this.wordBtn.Text = "选择Docx";
            this.wordBtn.UseVisualStyleBackColor = true;
            this.wordBtn.Click += new System.EventHandler(this.WordBtn_Click);
            // 
            // pdfBtn
            // 
            this.pdfBtn.Location = new System.Drawing.Point(1003, 14);
            this.pdfBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pdfBtn.Name = "pdfBtn";
            this.pdfBtn.Size = new System.Drawing.Size(63, 22);
            this.pdfBtn.TabIndex = 5;
            this.pdfBtn.Text = "选择PDF";
            this.pdfBtn.UseVisualStyleBackColor = true;
            this.pdfBtn.Click += new System.EventHandler(this.pdfBtn_Click);
            // 
            // runCompare
            // 
            this.runCompare.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.runCompare.Location = new System.Drawing.Point(508, 101);
            this.runCompare.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.runCompare.Name = "runCompare";
            this.runCompare.Size = new System.Drawing.Size(93, 43);
            this.runCompare.TabIndex = 6;
            this.runCompare.Text = "开始比对";
            this.runCompare.UseVisualStyleBackColor = true;
            this.runCompare.Click += new System.EventHandler(this.runCompare_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Docx文件路径：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(575, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "PDF文件路径：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 121);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "Docx文件内容：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(799, 121);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "PDF文件内容：";
            // 
            // loadProgress
            // 
            this.loadProgress.Location = new System.Drawing.Point(9, 702);
            this.loadProgress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loadProgress.Name = "loadProgress";
            this.loadProgress.Size = new System.Drawing.Size(1075, 22);
            this.loadProgress.TabIndex = 11;
            // 
            // isAccurateOCR
            // 
            this.isAccurateOCR.AutoSize = true;
            this.isAccurateOCR.Location = new System.Drawing.Point(227, 64);
            this.isAccurateOCR.Name = "isAccurateOCR";
            this.isAccurateOCR.Size = new System.Drawing.Size(102, 16);
            this.isAccurateOCR.TabIndex = 12;
            this.isAccurateOCR.Text = "使用高精度OCR";
            this.isAccurateOCR.UseVisualStyleBackColor = true;
            // 
            // useSecondDiffAlg
            // 
            this.useSecondDiffAlg.AutoSize = true;
            this.useSecondDiffAlg.Location = new System.Drawing.Point(373, 64);
            this.useSecondDiffAlg.Name = "useSecondDiffAlg";
            this.useSecondDiffAlg.Size = new System.Drawing.Size(144, 16);
            this.useSecondDiffAlg.TabIndex = 13;
            this.useSecondDiffAlg.Text = "使用第二差异判断算法";
            this.useSecondDiffAlg.UseVisualStyleBackColor = true;
            this.useSecondDiffAlg.CheckedChanged += new System.EventHandler(this.useSecondDiffAlg_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(538, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "单次查找范围：";
            // 
            // findRange
            // 
            this.findRange.Location = new System.Drawing.Point(633, 62);
            this.findRange.Name = "findRange";
            this.findRange.Size = new System.Drawing.Size(63, 21);
            this.findRange.TabIndex = 15;
            this.findRange.Text = "100";
            this.findRange.TextChanged += new System.EventHandler(this.findRange_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(733, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "谨慎度：";
            // 
            // cautiousLevel
            // 
            this.cautiousLevel.Location = new System.Drawing.Point(811, 62);
            this.cautiousLevel.Name = "cautiousLevel";
            this.cautiousLevel.Size = new System.Drawing.Size(63, 21);
            this.cautiousLevel.TabIndex = 17;
            this.cautiousLevel.Text = "5";
            this.cautiousLevel.TextChanged += new System.EventHandler(this.cautiousLevel_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(920, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "选项帮助";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // disableReread
            // 
            this.disableReread.AutoSize = true;
            this.disableReread.Location = new System.Drawing.Point(71, 64);
            this.disableReread.Name = "disableReread";
            this.disableReread.Size = new System.Drawing.Size(108, 16);
            this.disableReread.TabIndex = 19;
            this.disableReread.Text = "不重新加载文件";
            this.disableReread.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1102, 816);
            this.Controls.Add(this.disableReread);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cautiousLevel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.findRange);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.useSecondDiffAlg);
            this.Controls.Add(this.isAccurateOCR);
            this.Controls.Add(this.loadProgress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.runCompare);
            this.Controls.Add(this.pdfBtn);
            this.Controls.Add(this.wordBtn);
            this.Controls.Add(this.pdfPathBox);
            this.Controls.Add(this.wordPathBox);
            this.Controls.Add(this.pdfTextBox);
            this.Controls.Add(this.wordTextBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar loadProgress;
        private System.Windows.Forms.CheckBox isAccurateOCR;
        private System.Windows.Forms.CheckBox useSecondDiffAlg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox findRange;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox cautiousLevel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox disableReread;
    }
}

