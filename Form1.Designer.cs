namespace FontConverter
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.lblFontName = new System.Windows.Forms.Label();
            this.btnFont = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.pictZoomed = new System.Windows.Forms.PictureBox();
            this.chkBold = new System.Windows.Forms.CheckBox();
            this.chkItalic = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictActual = new System.Windows.Forms.PictureBox();
            this.chkHankaku = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.spinYOffset = new System.Windows.Forms.NumericUpDown();
            this.spinXOffset = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.spinMargine = new System.Windows.Forms.NumericUpDown();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblConvertCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.chkAlpha = new System.Windows.Forms.CheckBox();
            this.chkKana = new System.Windows.Forms.CheckBox();
            this.chkKanji = new System.Windows.Forms.CheckBox();
            this.btnRead = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictZoomed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinYOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinXOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMargine)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(167, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(181, 19);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "更新対象のFONTX2ファイル";
            // 
            // lblFontName
            // 
            this.lblFontName.Location = new System.Drawing.Point(165, 35);
            this.lblFontName.Name = "lblFontName";
            this.lblFontName.Size = new System.Drawing.Size(144, 18);
            this.lblFontName.TabIndex = 3;
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(436, 37);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(103, 23);
            this.btnFont.TabIndex = 4;
            this.btnFont.Text = "フォントの選択";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(464, 187);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "変換";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictZoomed
            // 
            this.pictZoomed.Location = new System.Drawing.Point(23, 72);
            this.pictZoomed.Name = "pictZoomed";
            this.pictZoomed.Size = new System.Drawing.Size(120, 120);
            this.pictZoomed.TabIndex = 0;
            this.pictZoomed.TabStop = false;
            // 
            // chkBold
            // 
            this.chkBold.AutoSize = true;
            this.chkBold.Location = new System.Drawing.Point(312, 40);
            this.chkBold.Name = "chkBold";
            this.chkBold.Size = new System.Drawing.Size(48, 16);
            this.chkBold.TabIndex = 6;
            this.chkBold.Text = "太字";
            this.chkBold.UseVisualStyleBackColor = true;
            // 
            // chkItalic
            // 
            this.chkItalic.AutoSize = true;
            this.chkItalic.Location = new System.Drawing.Point(354, 40);
            this.chkItalic.Name = "chkItalic";
            this.chkItalic.Size = new System.Drawing.Size(48, 16);
            this.chkItalic.TabIndex = 7;
            this.chkItalic.Text = "斜体";
            this.chkItalic.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "使用するフォント";
            // 
            // pictActual
            // 
            this.pictActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictActual.Location = new System.Drawing.Point(167, 72);
            this.pictActual.Name = "pictActual";
            this.pictActual.Size = new System.Drawing.Size(51, 44);
            this.pictActual.TabIndex = 9;
            this.pictActual.TabStop = false;
            this.pictActual.Click += new System.EventHandler(this.pictActual_Click);
            // 
            // chkHankaku
            // 
            this.chkHankaku.AutoSize = true;
            this.chkHankaku.Location = new System.Drawing.Point(382, 16);
            this.chkHankaku.Name = "chkHankaku";
            this.chkHankaku.Size = new System.Drawing.Size(48, 16);
            this.chkHankaku.TabIndex = 12;
            this.chkHankaku.Text = "半角";
            this.chkHankaku.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(354, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(22, 19);
            this.button3.TabIndex = 13;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // spinYOffset
            // 
            this.spinYOffset.Location = new System.Drawing.Point(293, 102);
            this.spinYOffset.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.spinYOffset.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            -2147483648});
            this.spinYOffset.Name = "spinYOffset";
            this.spinYOffset.Size = new System.Drawing.Size(38, 19);
            this.spinYOffset.TabIndex = 14;
            // 
            // spinXOffset
            // 
            this.spinXOffset.Location = new System.Drawing.Point(293, 67);
            this.spinXOffset.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.spinXOffset.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            -2147483648});
            this.spinXOffset.Name = "spinXOffset";
            this.spinXOffset.Size = new System.Drawing.Size(38, 19);
            this.spinXOffset.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "XOffset";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "YOffset";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "マージン";
            // 
            // spinMargine
            // 
            this.spinMargine.Location = new System.Drawing.Point(293, 135);
            this.spinMargine.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.spinMargine.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            -2147483648});
            this.spinMargine.Name = "spinMargine";
            this.spinMargine.Size = new System.Drawing.Size(38, 19);
            this.spinMargine.TabIndex = 18;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblConvertCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 213);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(556, 22);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(55, 17);
            this.lblStatus.Text = "変換状況";
            this.lblStatus.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // lblConvertCount
            // 
            this.lblConvertCount.Name = "lblConvertCount";
            this.lblConvertCount.Size = new System.Drawing.Size(0, 17);
            // 
            // chkAlpha
            // 
            this.chkAlpha.AutoSize = true;
            this.chkAlpha.Checked = true;
            this.chkAlpha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAlpha.Location = new System.Drawing.Point(149, 176);
            this.chkAlpha.Name = "chkAlpha";
            this.chkAlpha.Size = new System.Drawing.Size(84, 16);
            this.chkAlpha.TabIndex = 21;
            this.chkAlpha.Text = "英数字記号";
            this.chkAlpha.UseVisualStyleBackColor = true;
            // 
            // chkKana
            // 
            this.chkKana.AutoSize = true;
            this.chkKana.Checked = true;
            this.chkKana.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKana.Location = new System.Drawing.Point(240, 175);
            this.chkKana.Name = "chkKana";
            this.chkKana.Size = new System.Drawing.Size(69, 16);
            this.chkKana.TabIndex = 22;
            this.chkKana.Text = "カナ・かな";
            this.chkKana.UseVisualStyleBackColor = true;
            // 
            // chkKanji
            // 
            this.chkKanji.AutoSize = true;
            this.chkKanji.Checked = true;
            this.chkKanji.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKanji.Location = new System.Drawing.Point(325, 175);
            this.chkKanji.Name = "chkKanji";
            this.chkKanji.Size = new System.Drawing.Size(48, 16);
            this.chkKanji.TabIndex = 23;
            this.chkKanji.Text = "漢字";
            this.chkKanji.UseVisualStyleBackColor = true;
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(436, 13);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(103, 23);
            this.btnRead.TabIndex = 24;
            this.btnRead.Text = "読み込み";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 235);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.chkKanji);
            this.Controls.Add(this.chkKana);
            this.Controls.Add(this.chkAlpha);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.spinMargine);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.spinXOffset);
            this.Controls.Add(this.spinYOffset);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.chkHankaku);
            this.Controls.Add(this.pictActual);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkItalic);
            this.Controls.Add(this.chkBold);
            this.Controls.Add(this.pictZoomed);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.lblFontName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "FONTX2 Converter";
            ((System.ComponentModel.ISupportInitialize)(this.pictZoomed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinYOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinXOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMargine)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label lblFontName;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictZoomed;
        private System.Windows.Forms.CheckBox chkBold;
        private System.Windows.Forms.CheckBox chkItalic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictActual;
        private System.Windows.Forms.CheckBox chkHankaku;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown spinYOffset;
        private System.Windows.Forms.NumericUpDown spinXOffset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown spinMargine;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblConvertCount;
        private System.Windows.Forms.CheckBox chkAlpha;
        private System.Windows.Forms.CheckBox chkKana;
        private System.Windows.Forms.CheckBox chkKanji;
        private System.Windows.Forms.Button btnRead;
    }
}

