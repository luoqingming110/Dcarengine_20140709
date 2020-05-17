using Dcarengine.Function_Class;
using Dcarengine.refactor;
using Dcarengine.serialPort;

namespace Dcarengine.UIForm
{
    partial class EOLFORMWRITE790S
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
            if (EcuConnectionF.ECULINKStatus == false)
            {
                return;
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.ami_Button_21 = new EASkins.Ami_Button_2();
            this.emi_Button_21 = new EASkins.Emi_Button_2();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(399, 575);
            this.splitter1.TabIndex = 31;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(399, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 575);
            this.splitter2.TabIndex = 32;
            this.splitter2.TabStop = false;
            // 
            // ami_Button_21
            // 
            this.ami_Button_21.BackColor = System.Drawing.Color.Transparent;
            this.ami_Button_21.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ami_Button_21.Image = null;
            this.ami_Button_21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ami_Button_21.Location = new System.Drawing.Point(50, 253);
            this.ami_Button_21.Name = "ami_Button_21";
            this.ami_Button_21.Size = new System.Drawing.Size(189, 60);
            this.ami_Button_21.TabIndex = 33;
            this.ami_Button_21.Text = "配置";
            this.ami_Button_21.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ami_Button_21.Click += new System.EventHandler(this.ami_Button_21_Click_2);
            // 
            // emi_Button_21
            // 
            this.emi_Button_21.BackColor = System.Drawing.Color.Transparent;
            this.emi_Button_21.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.emi_Button_21.ForeColor = System.Drawing.Color.White;
            this.emi_Button_21.Image = null;
            this.emi_Button_21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.emi_Button_21.Location = new System.Drawing.Point(50, 91);
            this.emi_Button_21.Name = "emi_Button_21";
            this.emi_Button_21.Size = new System.Drawing.Size(189, 69);
            this.emi_Button_21.TabIndex = 36;
            this.emi_Button_21.Text = "进入模式";
            this.emi_Button_21.TextAlignment = System.Drawing.StringAlignment.Center;
            this.emi_Button_21.Click += new System.EventHandler(this.emi_Button_21_Click_1);
            // 
            // EOLFORMWRITE790S
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(769, 575);
            this.Controls.Add(this.emi_Button_21);
            this.Controls.Add(this.ami_Button_21);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.IsMdiContainer = true;
            this.Name = "EOLFORMWRITE790S";
            this.Text = "EolWriteForm";
            this.Load += new System.EventHandler(this.EOLFORMWRITE_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private EASkins.Ami_Button_2 ami_Button_21;
        private EASkins.Emi_Button_2 emi_Button_21;
    }
}