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
            this.SuspendLayout();
            // 
            // wordTextBox
            // 
            this.wordTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wordTextBox.Location = new System.Drawing.Point(12, 163);
            this.wordTextBox.Name = "wordTextBox";
            this.wordTextBox.Size = new System.Drawing.Size(675, 700);
            this.wordTextBox.TabIndex = 0;
            this.wordTextBox.Text = "";
            // 
            // pdfTextBox
            // 
            this.pdfTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pdfTextBox.Location = new System.Drawing.Point(770, 163);
            this.pdfTextBox.Name = "pdfTextBox";
            this.pdfTextBox.Size = new System.Drawing.Size(675, 700);
            this.pdfTextBox.TabIndex = 1;
            this.pdfTextBox.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // wordPathBox
            // 
            this.wordPathBox.Location = new System.Drawing.Point(30, 60);
            this.wordPathBox.Name = "wordPathBox";
            this.wordPathBox.ReadOnly = true;
            this.wordPathBox.Size = new System.Drawing.Size(657, 25);
            this.wordPathBox.TabIndex = 2;
            // 
            // pdfPathBox
            // 
            this.pdfPathBox.Location = new System.Drawing.Point(770, 60);
            this.pdfPathBox.Name = "pdfPathBox";
            this.pdfPathBox.ReadOnly = true;
            this.pdfPathBox.Size = new System.Drawing.Size(675, 25);
            this.pdfPathBox.TabIndex = 3;
            // 
            // wordBtn
            // 
            this.wordBtn.Location = new System.Drawing.Point(192, 17);
            this.wordBtn.Name = "wordBtn";
            this.wordBtn.Size = new System.Drawing.Size(84, 27);
            this.wordBtn.TabIndex = 4;
            this.wordBtn.Text = "选择Docx";
            this.wordBtn.UseVisualStyleBackColor = true;
            this.wordBtn.Click += new System.EventHandler(this.WordBtn_Click);
            // 
            // pdfBtn
            // 
            this.pdfBtn.Location = new System.Drawing.Point(929, 17);
            this.pdfBtn.Name = "pdfBtn";
            this.pdfBtn.Size = new System.Drawing.Size(84, 27);
            this.pdfBtn.TabIndex = 5;
            this.pdfBtn.Text = "选择PDF";
            this.pdfBtn.UseVisualStyleBackColor = true;
            this.pdfBtn.Click += new System.EventHandler(this.pdfBtn_Click);
            // 
            // runCompare
            // 
            this.runCompare.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.runCompare.Location = new System.Drawing.Point(671, 92);
            this.runCompare.Name = "runCompare";
            this.runCompare.Size = new System.Drawing.Size(124, 65);
            this.runCompare.TabIndex = 6;
            this.runCompare.Text = "开始比对";
            this.runCompare.UseVisualStyleBackColor = true;
            this.runCompare.Click += new System.EventHandler(this.runCompare_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Docx文件路径：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(767, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "PDF文件路径：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Docx文件内容：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1059, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "PDF文件内容：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1469, 1055);
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
    }
}

