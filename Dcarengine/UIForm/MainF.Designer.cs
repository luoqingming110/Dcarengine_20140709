using System;
using System.Windows;

namespace Dcarengine.UIForm
{
    partial class MainF
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
            //Application.
        }


        /// <summary>
        /// application exit from
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, EventArgs e)
        {
            log.Info("application is  exit  ");
            System.Environment.Exit(0);            
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainF));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设备选定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.串口连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.串口断开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.信息检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iD信息读取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.故障处理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.故障读取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.故障清除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.行车记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.参数测量ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eEPROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eOLWRITEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            showBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            EcuVeriosn = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dEBUGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设备选定ToolStripMenuItem,
            this.信息检测ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.eEPROMToolStripMenuItem,
            this.eOLWRITEToolStripMenuItem,
            this.dEBUGToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(4, 28);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1169, 39);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设备选定ToolStripMenuItem
            // 
            this.设备选定ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.串口连接ToolStripMenuItem,
            this.串口断开ToolStripMenuItem});
            this.设备选定ToolStripMenuItem.Name = "设备选定ToolStripMenuItem";
            this.设备选定ToolStripMenuItem.Size = new System.Drawing.Size(122, 35);
            this.设备选定ToolStripMenuItem.Text = "设备选定";
            // 
            // 串口连接ToolStripMenuItem
            // 
            this.串口连接ToolStripMenuItem.Name = "串口连接ToolStripMenuItem";
            this.串口连接ToolStripMenuItem.Size = new System.Drawing.Size(190, 36);
            this.串口连接ToolStripMenuItem.Text = "通信连接";
            // 
            // 串口断开ToolStripMenuItem
            // 
            this.串口断开ToolStripMenuItem.Name = "串口断开ToolStripMenuItem";
            this.串口断开ToolStripMenuItem.Size = new System.Drawing.Size(190, 36);
            this.串口断开ToolStripMenuItem.Text = "断开连接";
            // 
            // 信息检测ToolStripMenuItem
            // 
            this.信息检测ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iD信息读取ToolStripMenuItem,
            this.故障处理ToolStripMenuItem,
            this.行车记录ToolStripMenuItem,
            this.参数测量ToolStripMenuItem});
            this.信息检测ToolStripMenuItem.Name = "信息检测ToolStripMenuItem";
            this.信息检测ToolStripMenuItem.Size = new System.Drawing.Size(122, 35);
            this.信息检测ToolStripMenuItem.Text = "信息检测";
            // 
            // iD信息读取ToolStripMenuItem
            // 
            this.iD信息读取ToolStripMenuItem.Name = "iD信息读取ToolStripMenuItem";
            this.iD信息读取ToolStripMenuItem.Size = new System.Drawing.Size(215, 36);
            this.iD信息读取ToolStripMenuItem.Text = "ID信息读取";
            this.iD信息读取ToolStripMenuItem.Click += new System.EventHandler(this.iD信息读取ToolStripMenuItem_Click);
            // 
            // 故障处理ToolStripMenuItem
            // 
            this.故障处理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.故障读取ToolStripMenuItem,
            this.故障清除ToolStripMenuItem});
            this.故障处理ToolStripMenuItem.Name = "故障处理ToolStripMenuItem";
            this.故障处理ToolStripMenuItem.Size = new System.Drawing.Size(215, 36);
            this.故障处理ToolStripMenuItem.Text = "故障处理";
            // 
            // 故障读取ToolStripMenuItem
            // 
            this.故障读取ToolStripMenuItem.Name = "故障读取ToolStripMenuItem";
            this.故障读取ToolStripMenuItem.Size = new System.Drawing.Size(190, 36);
            this.故障读取ToolStripMenuItem.Text = "故障读取";
            this.故障读取ToolStripMenuItem.Click += new System.EventHandler(this.故障读取ToolStripMenuItem_Click);
            // 
            // 故障清除ToolStripMenuItem
            // 
            this.故障清除ToolStripMenuItem.Name = "故障清除ToolStripMenuItem";
            this.故障清除ToolStripMenuItem.Size = new System.Drawing.Size(190, 36);
            this.故障清除ToolStripMenuItem.Text = "故障清除";
            this.故障清除ToolStripMenuItem.Click += new System.EventHandler(this.故障清除ToolStripMenuItem_Click);
            // 
            // 行车记录ToolStripMenuItem
            // 
            this.行车记录ToolStripMenuItem.Name = "行车记录ToolStripMenuItem";
            this.行车记录ToolStripMenuItem.Size = new System.Drawing.Size(215, 36);
            this.行车记录ToolStripMenuItem.Text = "行程记录";
            this.行车记录ToolStripMenuItem.Click += new System.EventHandler(this.行车记录ToolStripMenuItem_Click);
            // 
            // 参数测量ToolStripMenuItem
            // 
            this.参数测量ToolStripMenuItem.Name = "参数测量ToolStripMenuItem";
            this.参数测量ToolStripMenuItem.Size = new System.Drawing.Size(215, 36);
            this.参数测量ToolStripMenuItem.Text = "参数测量";
            this.参数测量ToolStripMenuItem.Click += new System.EventHandler(this.参数测量ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(170, 35);
            this.toolStripMenuItem1.Text = "主动诊断测试";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // eEPROMToolStripMenuItem
            // 
            this.eEPROMToolStripMenuItem.Name = "eEPROMToolStripMenuItem";
            this.eEPROMToolStripMenuItem.Size = new System.Drawing.Size(126, 35);
            this.eEPROMToolStripMenuItem.Text = "EEPROM";
            this.eEPROMToolStripMenuItem.Click += new System.EventHandler(this.eEPROMToolStripMenuItem_Click);
            // 
            // eOLWRITEToolStripMenuItem
            // 
            this.eOLWRITEToolStripMenuItem.Name = "eOLWRITEToolStripMenuItem";
            this.eOLWRITEToolStripMenuItem.Size = new System.Drawing.Size(145, 35);
            this.eOLWRITEToolStripMenuItem.Text = "EOLWRITE";
            this.eOLWRITEToolStripMenuItem.Click += new System.EventHandler(this.eOLWRITEToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton8,
            this.toolStripButton5,
            this.toolStripButton7});
            this.toolStrip1.Location = new System.Drawing.Point(4, 67);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1169, 45);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::Dcarengine.Properties.Resources._11;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(116, 42);
            this.toolStripButton1.Text = "通信连接";
            this.toolStripButton1.Click += new System.EventHandler(this.Connect_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::Dcarengine.Properties.Resources._6121;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(116, 42);
            this.toolStripButton2.Text = "断开连接";
            this.toolStripButton2.Click += new System.EventHandler(this.ColsePort_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(123, 42);
            this.toolStripButton3.Text = " ID信息读取";
            this.toolStripButton3.Click += new System.EventHandler(this.ReadEcuId_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(96, 42);
            this.toolStripButton4.Text = "故障读取";
            this.toolStripButton4.Click += new System.EventHandler(this.readDtc_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(96, 42);
            this.toolStripButton8.Text = "故障清除";
            this.toolStripButton8.Click += new System.EventHandler(this.ClearDtc_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(96, 42);
            this.toolStripButton5.Text = "行程记录";
            this.toolStripButton5.Click += new System.EventHandler(this.行程记录_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(96, 42);
            this.toolStripButton7.Text = "参数测量";
            this.toolStripButton7.Click += new System.EventHandler(this.measure_Click);
            // 
            // showBox1
            // 
            showBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            showBox1.Location = new System.Drawing.Point(0, 416);
            showBox1.Multiline = true;
            showBox1.Name = "showBox1";
            showBox1.Size = new System.Drawing.Size(1177, 86);
            showBox1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(EcuVeriosn);
            this.groupBox1.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 496);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1177, 62);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // EcuVeriosn
            // 
            EcuVeriosn.AutoSize = true;
            EcuVeriosn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            EcuVeriosn.Location = new System.Drawing.Point(107, 22);
            EcuVeriosn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            EcuVeriosn.Name = "EcuVeriosn";
            EcuVeriosn.Size = new System.Drawing.Size(79, 20);
            EcuVeriosn.TabIndex = 0;
            EcuVeriosn.Text = "version";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 106);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1177, 309);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dEBUGToolStripMenuItem
            // 
            this.dEBUGToolStripMenuItem.Name = "dEBUGToolStripMenuItem";
            this.dEBUGToolStripMenuItem.Size = new System.Drawing.Size(108, 35);
            this.dEBUGToolStripMenuItem.Text = "DEBUG";
            this.dEBUGToolStripMenuItem.Click += new System.EventHandler(this.dEBUGToolStripMenuItem_Click);
            // 
            // MainF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Back = ((System.Drawing.Image)(resources.GetObject("$this.Back")));
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(193)))), ((int)(((byte)(165)))));
            this.ClientSize = new System.Drawing.Size(1177, 555);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(showBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.Name = "MainF";
            this.Text = "RB Tech";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainF_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设备选定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 串口连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 串口断开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 信息检测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iD信息读取ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 故障处理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 故障读取ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 故障清除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 行车记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 参数测量ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        public System.Windows.Forms.TextBox tB_ReceiveDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem eEPROMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eOLWRITEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dEBUGToolStripMenuItem;
        public static System.Windows.Forms.Label EcuVeriosn;
        public static System.Windows.Forms.TextBox showBox1;
    } 
}