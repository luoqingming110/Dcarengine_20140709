using Dcarengine.Function_Class;
using Dcarengine.refactor;
using Dcarengine.serialPort;

namespace Dcarengine.UIForm
{
    partial class EOLFORMWRITE
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
            try
            {

                GobalSerialPort.WriteByMessage(CommonCmd._1081, 0, CommonCmd._1081.Length);

                GobalSerialPort.WriteByMessage(CommonCmd.ATST0F, 0, CommonCmd.ATST0F.Length);

                //GobalSerialPort.WriteByMessage(CommonCmd._1101, 0, CommonCmd._1101.Length);

                //Thread.Sleep(1000);

                //MainF.ShowBoxTex("串口已断开");

                //EcuConnectionF.ECULINKStatus1 = false;

                //EcuConnectionF connectecu = new EcuConnectionF();

                //Thread tWorkingThread = new Thread((connectecu.ConnectEucByWait));

                //tWorkingThread.Start();

            }
            catch
            {

            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.emi_Button_21 = new EASkins.Emi_Button_2();
            this.ami_Button_28 = new EASkins.Ami_Button_2();
            this.ami_Button_27 = new EASkins.Ami_Button_2();
            this.ami_Button_26 = new EASkins.Ami_Button_2();
            this.label1 = new System.Windows.Forms.Label();
            this.ami_Button_25 = new EASkins.Ami_Button_2();
            this.ami_Button_24 = new EASkins.Ami_Button_2();
            this.ami_Button_23 = new EASkins.Ami_Button_2();
            this.ami_Button_22 = new EASkins.Ami_Button_2();
            this.ami_Button_21 = new EASkins.Ami_Button_2();
            this.ami_Button_29 = new EASkins.Ami_Button_2();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.splitContainer1.Panel1.Controls.Add(this.ami_Button_29);
            this.splitContainer1.Panel1.Controls.Add(this.emi_Button_21);
            this.splitContainer1.Panel1.Controls.Add(this.ami_Button_28);
            this.splitContainer1.Panel1.Controls.Add(this.ami_Button_27);
            this.splitContainer1.Panel1.Controls.Add(this.ami_Button_26);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.ami_Button_25);
            this.splitContainer1.Panel1.Controls.Add(this.ami_Button_24);
            this.splitContainer1.Panel1.Controls.Add(this.ami_Button_23);
            this.splitContainer1.Panel1.Controls.Add(this.ami_Button_22);
            this.splitContainer1.Panel1.Controls.Add(this.ami_Button_21);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.splitContainer1.Size = new System.Drawing.Size(1373, 773);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.TabIndex = 0;
            // 
            // emi_Button_21
            // 
            this.emi_Button_21.BackColor = System.Drawing.Color.Transparent;
            this.emi_Button_21.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.emi_Button_21.ForeColor = System.Drawing.Color.White;
            this.emi_Button_21.Image = null;
            this.emi_Button_21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.emi_Button_21.Location = new System.Drawing.Point(38, 40);
            this.emi_Button_21.Name = "emi_Button_21";
            this.emi_Button_21.Size = new System.Drawing.Size(143, 49);
            this.emi_Button_21.TabIndex = 0;
            this.emi_Button_21.Text = "进入模式";
            this.emi_Button_21.TextAlignment = System.Drawing.StringAlignment.Center;
            this.emi_Button_21.Click += new System.EventHandler(this.emi_Button_21_Click);
            // 
            // ami_Button_28
            // 
            this.ami_Button_28.BackColor = System.Drawing.Color.Transparent;
            this.ami_Button_28.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ami_Button_28.Image = null;
            this.ami_Button_28.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ami_Button_28.Location = new System.Drawing.Point(38, 246);
            this.ami_Button_28.Name = "ami_Button_28";
            this.ami_Button_28.Size = new System.Drawing.Size(143, 50);
            this.ami_Button_28.TabIndex = 10;
            this.ami_Button_28.Text = "GPS";
            this.ami_Button_28.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ami_Button_28.Click += new System.EventHandler(this.ami_Button_28_Click);
            // 
            // ami_Button_27
            // 
            this.ami_Button_27.BackColor = System.Drawing.Color.Transparent;
            this.ami_Button_27.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ami_Button_27.Image = null;
            this.ami_Button_27.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ami_Button_27.Location = new System.Drawing.Point(38, 608);
            this.ami_Button_27.Name = "ami_Button_27";
            this.ami_Button_27.Size = new System.Drawing.Size(143, 50);
            this.ami_Button_27.TabIndex = 9;
            this.ami_Button_27.Text = "测试日期";
            this.ami_Button_27.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ami_Button_27.Click += new System.EventHandler(this.ami_Button_27_Click);
            // 
            // ami_Button_26
            // 
            this.ami_Button_26.BackColor = System.Drawing.Color.Transparent;
            this.ami_Button_26.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ami_Button_26.Image = null;
            this.ami_Button_26.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ami_Button_26.Location = new System.Drawing.Point(38, 533);
            this.ami_Button_26.Name = "ami_Button_26";
            this.ami_Button_26.Size = new System.Drawing.Size(143, 50);
            this.ami_Button_26.TabIndex = 8;
            this.ami_Button_26.Text = "配置日期";
            this.ami_Button_26.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ami_Button_26.Click += new System.EventHandler(this.ami_Button_26_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "EOL 数据写入项";
            // 
            // ami_Button_25
            // 
            this.ami_Button_25.BackColor = System.Drawing.Color.Transparent;
            this.ami_Button_25.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ami_Button_25.Image = null;
            this.ami_Button_25.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ami_Button_25.Location = new System.Drawing.Point(38, 463);
            this.ami_Button_25.Name = "ami_Button_25";
            this.ami_Button_25.Size = new System.Drawing.Size(143, 50);
            this.ami_Button_25.TabIndex = 7;
            this.ami_Button_25.Text = "测试工具序列号";
            this.ami_Button_25.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ami_Button_25.Click += new System.EventHandler(this.ami_Button_25_Click);
            // 
            // ami_Button_24
            // 
            this.ami_Button_24.BackColor = System.Drawing.Color.Transparent;
            this.ami_Button_24.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ami_Button_24.Image = null;
            this.ami_Button_24.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ami_Button_24.Location = new System.Drawing.Point(38, 387);
            this.ami_Button_24.Name = "ami_Button_24";
            this.ami_Button_24.Size = new System.Drawing.Size(143, 50);
            this.ami_Button_24.TabIndex = 6;
            this.ami_Button_24.Text = "speed limit";
            this.ami_Button_24.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ami_Button_24.Click += new System.EventHandler(this.ami_Button_24_Click);
            // 
            // ami_Button_23
            // 
            this.ami_Button_23.BackColor = System.Drawing.Color.Transparent;
            this.ami_Button_23.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ami_Button_23.Image = null;
            this.ami_Button_23.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ami_Button_23.Location = new System.Drawing.Point(38, 317);
            this.ami_Button_23.Name = "ami_Button_23";
            this.ami_Button_23.Size = new System.Drawing.Size(143, 50);
            this.ami_Button_23.TabIndex = 5;
            this.ami_Button_23.Text = "Retarder";
            this.ami_Button_23.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ami_Button_23.Click += new System.EventHandler(this.ami_Button_23_Click);
            // 
            // ami_Button_22
            // 
            this.ami_Button_22.BackColor = System.Drawing.Color.Transparent;
            this.ami_Button_22.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ami_Button_22.Image = null;
            this.ami_Button_22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ami_Button_22.Location = new System.Drawing.Point(38, 180);
            this.ami_Button_22.Name = "ami_Button_22";
            this.ami_Button_22.Size = new System.Drawing.Size(143, 50);
            this.ami_Button_22.TabIndex = 4;
            this.ami_Button_22.Text = "ABS";
            this.ami_Button_22.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ami_Button_22.Click += new System.EventHandler(this.ami_Button_22_Click);
            // 
            // ami_Button_21
            // 
            this.ami_Button_21.BackColor = System.Drawing.Color.Transparent;
            this.ami_Button_21.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ami_Button_21.Image = null;
            this.ami_Button_21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ami_Button_21.Location = new System.Drawing.Point(38, 114);
            this.ami_Button_21.Name = "ami_Button_21";
            this.ami_Button_21.Size = new System.Drawing.Size(143, 50);
            this.ami_Button_21.TabIndex = 3;
            this.ami_Button_21.Text = "ARS";
            this.ami_Button_21.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ami_Button_21.Click += new System.EventHandler(this.ami_Button_21_Click);
            // 
            // ami_Button_29
            // 
            this.ami_Button_29.BackColor = System.Drawing.Color.Transparent;
            this.ami_Button_29.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ami_Button_29.Image = null;
            this.ami_Button_29.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ami_Button_29.Location = new System.Drawing.Point(38, 687);
            this.ami_Button_29.Name = "ami_Button_29";
            this.ami_Button_29.Size = new System.Drawing.Size(143, 50);
            this.ami_Button_29.TabIndex = 11;
            this.ami_Button_29.Text = "VIN";
            this.ami_Button_29.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ami_Button_29.Click += new System.EventHandler(this.ami_Button_29_Click);
            // 
            // EOLFORMWRITE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1373, 773);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EOLFORMWRITE";
            this.Text = "EolWriteForm";
            this.Load += new System.EventHandler(this.EOLFORMWRITE_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private EASkins.Ami_Button_2 ami_Button_21;
        private EASkins.Ami_Button_2 ami_Button_25;
        private EASkins.Ami_Button_2 ami_Button_24;
        private EASkins.Ami_Button_2 ami_Button_23;
        private EASkins.Ami_Button_2 ami_Button_22;
        private EASkins.Ami_Button_2 ami_Button_27;
        private EASkins.Ami_Button_2 ami_Button_26;
        private EASkins.Ami_Button_2 ami_Button_28;
        private EASkins.Emi_Button_2 emi_Button_21;
        private EASkins.Ami_Button_2 ami_Button_29;
    }
}