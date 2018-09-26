namespace Dcarengine.UIForm.EOL
{
    partial class ARS
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
            this.ami_ComboBox1 = new EASkins.Ami_ComboBox();
            this.ami_Button_22 = new EASkins.Ami_Button_2();
            this.ami_Label2 = new EASkins.Ami_Label();
            this.ami_Label1 = new EASkins.Ami_Label();
            this.materialLabel1 = new EASkins.Controls.MaterialLabel();
            this.emi_RichTextBox1 = new EASkins.Emi_RichTextBox();
            this.SuspendLayout();
            // 
            // ami_ComboBox1
            // 
            this.ami_ComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.ami_ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ami_ComboBox1.DropDownHeight = 100;
            this.ami_ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ami_ComboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ami_ComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.ami_ComboBox1.FormattingEnabled = true;
            this.ami_ComboBox1.HoverSelectionColor = System.Drawing.Color.Empty;
            this.ami_ComboBox1.IntegralHeight = false;
            this.ami_ComboBox1.ItemHeight = 20;
            this.ami_ComboBox1.Items.AddRange(new object[] {
            "激活",
            "未激活"});
            this.ami_ComboBox1.Location = new System.Drawing.Point(416, 462);
            this.ami_ComboBox1.Name = "ami_ComboBox1";
            this.ami_ComboBox1.Size = new System.Drawing.Size(229, 26);
            this.ami_ComboBox1.StartIndex = 0;
            this.ami_ComboBox1.TabIndex = 25;
            this.ami_ComboBox1.SelectedIndexChanged += new System.EventHandler(this.ami_ComboBox1_SelectedIndexChanged);
            // 
            // ami_Button_22
            // 
            this.ami_Button_22.BackColor = System.Drawing.Color.Transparent;
            this.ami_Button_22.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ami_Button_22.Image = null;
            this.ami_Button_22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ami_Button_22.Location = new System.Drawing.Point(770, 462);
            this.ami_Button_22.Name = "ami_Button_22";
            this.ami_Button_22.Size = new System.Drawing.Size(149, 51);
            this.ami_Button_22.TabIndex = 24;
            this.ami_Button_22.Text = "确定";
            this.ami_Button_22.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ami_Button_22.Click += new System.EventHandler(this.ami_Button_22_Click);
            // 
            // ami_Label2
            // 
            this.ami_Label2.AutoSize = true;
            this.ami_Label2.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ami_Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label2.Location = new System.Drawing.Point(261, 462);
            this.ami_Label2.Name = "ami_Label2";
            this.ami_Label2.Size = new System.Drawing.Size(92, 25);
            this.ami_Label2.TabIndex = 23;
            this.ami_Label2.Text = "改变状态";
            this.ami_Label2.Click += new System.EventHandler(this.ami_Label2_Click);
            // 
            // ami_Label1
            // 
            this.ami_Label1.AutoSize = true;
            this.ami_Label1.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ami_Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label1.Location = new System.Drawing.Point(261, 284);
            this.ami_Label1.Name = "ami_Label1";
            this.ami_Label1.Size = new System.Drawing.Size(92, 25);
            this.ami_Label1.TabIndex = 22;
            this.ami_Label1.Text = "当前状态";
            this.ami_Label1.Click += new System.EventHandler(this.ami_Label1_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(374, 174);
            this.materialLabel1.MouseState = EASkins.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(85, 23);
            this.materialLabel1.TabIndex = 21;
            this.materialLabel1.Text = "ARS状态";
            this.materialLabel1.Click += new System.EventHandler(this.materialLabel1_Click);
            // 
            // emi_RichTextBox1
            // 
            this.emi_RichTextBox1.AutoWordSelection = false;
            this.emi_RichTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.emi_RichTextBox1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.emi_RichTextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.emi_RichTextBox1.Location = new System.Drawing.Point(413, 284);
            this.emi_RichTextBox1.Name = "emi_RichTextBox1";
            this.emi_RichTextBox1.ReadOnly = false;
            this.emi_RichTextBox1.Size = new System.Drawing.Size(232, 51);
            this.emi_RichTextBox1.TabIndex = 20;
            this.emi_RichTextBox1.WordWrap = true;
            this.emi_RichTextBox1.TextChanged += new System.EventHandler(this.emi_RichTextBox1_TextChanged);
            // 
            // ARS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 687);
            this.Controls.Add(this.ami_ComboBox1);
            this.Controls.Add(this.ami_Button_22);
            this.Controls.Add(this.ami_Label2);
            this.Controls.Add(this.ami_Label1);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.emi_RichTextBox1);
            this.Name = "ARS";
            this.Text = "ARS";
            this.Load += new System.EventHandler(this.ARS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EASkins.Ami_ComboBox ami_ComboBox1;
        private EASkins.Ami_Button_2 ami_Button_22;
        private EASkins.Ami_Label ami_Label2;
        private EASkins.Ami_Label ami_Label1;
        private EASkins.Controls.MaterialLabel materialLabel1;
        private EASkins.Emi_RichTextBox emi_RichTextBox1;
    }
}