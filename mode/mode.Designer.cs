namespace mode
{
    partial class mode
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
            this.ami_Button_11 = new EASkins.Ami_Button_1();
            this.ami_Label1 = new EASkins.Ami_Label();
            this.modebox = new System.Windows.Forms.ComboBox();
            this.ami_Label2 = new EASkins.Ami_Label();
            this.input = new System.Windows.Forms.TextBox();
            this.ami_Label3 = new EASkins.Ami_Label();
            this.ecubox = new System.Windows.Forms.ComboBox();
            this.ami_Label4 = new EASkins.Ami_Label();
            this.emi_RichTextBox1 = new EASkins.Emi_RichTextBox();
            this.SuspendLayout();
            // 
            // ami_Button_11
            // 
            this.ami_Button_11.BackColor = System.Drawing.Color.Transparent;
            this.ami_Button_11.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ami_Button_11.Image = null;
            this.ami_Button_11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ami_Button_11.Location = new System.Drawing.Point(70, 369);
            this.ami_Button_11.Name = "ami_Button_11";
            this.ami_Button_11.Size = new System.Drawing.Size(390, 149);
            this.ami_Button_11.TabIndex = 2;
            this.ami_Button_11.Text = "计算";
            this.ami_Button_11.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ami_Button_11.Click += new System.EventHandler(this.ami_Button_11_Click);
            // 
            // ami_Label1
            // 
            this.ami_Label1.AutoSize = true;
            this.ami_Label1.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ami_Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label1.Location = new System.Drawing.Point(523, 106);
            this.ami_Label1.Name = "ami_Label1";
            this.ami_Label1.Size = new System.Drawing.Size(92, 25);
            this.ami_Label1.TabIndex = 4;
            this.ami_Label1.Text = "计算结果";
            // 
            // modebox
            // 
            this.modebox.FormattingEnabled = true;
            this.modebox.Items.AddRange(new object[] {
            "1086",
            "1087",
            "1088",
            "1089",
            "1090",
            "1091",
            "1092"});
            this.modebox.Location = new System.Drawing.Point(70, 160);
            this.modebox.Name = "modebox";
            this.modebox.Size = new System.Drawing.Size(242, 23);
            this.modebox.TabIndex = 7;
            // 
            // ami_Label2
            // 
            this.ami_Label2.AutoSize = true;
            this.ami_Label2.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ami_Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label2.Location = new System.Drawing.Point(65, 132);
            this.ami_Label2.Name = "ami_Label2";
            this.ami_Label2.Size = new System.Drawing.Size(92, 25);
            this.ami_Label2.TabIndex = 8;
            this.ami_Label2.Text = "模式选择";
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(70, 278);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(242, 25);
            this.input.TabIndex = 9;
            // 
            // ami_Label3
            // 
            this.ami_Label3.AutoSize = true;
            this.ami_Label3.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ami_Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label3.Location = new System.Drawing.Point(65, 250);
            this.ami_Label3.Name = "ami_Label3";
            this.ami_Label3.Size = new System.Drawing.Size(72, 25);
            this.ami_Label3.TabIndex = 10;
            this.ami_Label3.Text = "输入值";
            // 
            // ecubox
            // 
            this.ecubox.FormattingEnabled = true;
            this.ecubox.Items.AddRange(new object[] {
            "790",
            "800"});
            this.ecubox.Location = new System.Drawing.Point(70, 68);
            this.ecubox.Name = "ecubox";
            this.ecubox.Size = new System.Drawing.Size(242, 23);
            this.ecubox.TabIndex = 11;
            // 
            // ami_Label4
            // 
            this.ami_Label4.AutoSize = true;
            this.ami_Label4.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ami_Label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label4.Location = new System.Drawing.Point(65, 40);
            this.ami_Label4.Name = "ami_Label4";
            this.ami_Label4.Size = new System.Drawing.Size(87, 25);
            this.ami_Label4.TabIndex = 12;
            this.ami_Label4.Text = "ECU选择";
            // 
            // emi_RichTextBox1
            // 
            this.emi_RichTextBox1.AutoWordSelection = false;
            this.emi_RichTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.emi_RichTextBox1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.emi_RichTextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.emi_RichTextBox1.Location = new System.Drawing.Point(528, 160);
            this.emi_RichTextBox1.Name = "emi_RichTextBox1";
            this.emi_RichTextBox1.ReadOnly = false;
            this.emi_RichTextBox1.Size = new System.Drawing.Size(327, 358);
            this.emi_RichTextBox1.TabIndex = 13;
            this.emi_RichTextBox1.WordWrap = true;
            // 
            // mode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 589);
            this.Controls.Add(this.emi_RichTextBox1);
            this.Controls.Add(this.ami_Label4);
            this.Controls.Add(this.ecubox);
            this.Controls.Add(this.ami_Label3);
            this.Controls.Add(this.input);
            this.Controls.Add(this.ami_Label2);
            this.Controls.Add(this.modebox);
            this.Controls.Add(this.ami_Label1);
            this.Controls.Add(this.ami_Button_11);
            this.Name = "mode";
            this.Text = "mode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private EASkins.Ami_Button_1 ami_Button_11;
        private EASkins.Ami_Label ami_Label1;
        private System.Windows.Forms.ComboBox modebox;
        private EASkins.Ami_Label ami_Label2;
        private System.Windows.Forms.TextBox input;
        private EASkins.Ami_Label ami_Label3;
        private System.Windows.Forms.ComboBox ecubox;
        private EASkins.Ami_Label ami_Label4;
        private EASkins.Emi_RichTextBox emi_RichTextBox1;
    }
}

