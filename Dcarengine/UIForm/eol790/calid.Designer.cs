namespace Dcarengine.UIForm.eol790
{
    partial class calid
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ami_Label1 = new EASkins.Ami_Label();
            this.materialLabel1 = new EASkins.Controls.MaterialLabel();
            this.ami_Button_21 = new EASkins.Ami_Button_2();
            this.emi_RichTextBox1 = new EASkins.Emi_RichTextBox();
            this.SuspendLayout();
            // 
            // ami_Label1
            // 
            this.ami_Label1.AutoSize = true;
            this.ami_Label1.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ami_Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label1.Location = new System.Drawing.Point(140, 309);
            this.ami_Label1.Name = "ami_Label1";
            this.ami_Label1.Size = new System.Drawing.Size(103, 25);
            this.ami_Label1.TabIndex = 26;
            this.ami_Label1.Text = "当前CALID";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(225, 196);
            this.materialLabel1.MouseState = EASkins.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(61, 23);
            this.materialLabel1.TabIndex = 25;
            this.materialLabel1.Text = "CALID";
            // 
            // ami_Button_21
            // 
            this.ami_Button_21.BackColor = System.Drawing.Color.Transparent;
            this.ami_Button_21.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ami_Button_21.Image = null;
            this.ami_Button_21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ami_Button_21.Location = new System.Drawing.Point(659, 292);
            this.ami_Button_21.Name = "ami_Button_21";
            this.ami_Button_21.Size = new System.Drawing.Size(149, 51);
            this.ami_Button_21.TabIndex = 24;
            this.ami_Button_21.Text = "读";
            this.ami_Button_21.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ami_Button_21.Click += new System.EventHandler(this.ami_Button_21_Click);
            // 
            // emi_RichTextBox1
            // 
            this.emi_RichTextBox1.AutoWordSelection = false;
            this.emi_RichTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.emi_RichTextBox1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.emi_RichTextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.emi_RichTextBox1.Location = new System.Drawing.Point(292, 292);
            this.emi_RichTextBox1.Name = "emi_RichTextBox1";
            this.emi_RichTextBox1.ReadOnly = false;
            this.emi_RichTextBox1.Size = new System.Drawing.Size(306, 76);
            this.emi_RichTextBox1.TabIndex = 23;
            this.emi_RichTextBox1.WordWrap = true;
            // 
            // calid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 567);
            this.Controls.Add(this.ami_Label1);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.ami_Button_21);
            this.Controls.Add(this.emi_RichTextBox1);
            this.Name = "calid";
            this.Text = "calid";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EASkins.Ami_Label ami_Label1;
        private EASkins.Controls.MaterialLabel materialLabel1;
        private EASkins.Ami_Button_2 ami_Button_21;
        private EASkins.Emi_RichTextBox emi_RichTextBox1;
    }
}