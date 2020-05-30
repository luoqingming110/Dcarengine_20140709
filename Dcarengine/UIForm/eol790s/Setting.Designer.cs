using Dcarengine.Function_Class;
using Dcarengine.refactor;
using Dcarengine.serialPort;

namespace Dcarengine.UIForm.eol790s
{
    partial class Setting
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
            if (EcuConnectionF.ECULINKStatus == true)
            {               
                GobalSerialPort.WriteByMessage(CommonCmd._1086, 0, CommonCmd._1086.Length);
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
            this.ami_Button_22 = new EASkins.Ami_Button_2();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.emi_CheckBox1 = new EASkins.Emi_CheckBox();
            this.ami_Label1 = new EASkins.Ami_Label();
            this.emi_CheckBox2 = new EASkins.Emi_CheckBox();
            this.emi_RichTextBox2 = new EASkins.Emi_RichTextBox();
            this.ami_Label4 = new EASkins.Ami_Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ep_vin_textBox1 = new System.Windows.Forms.TextBox();
            this.emvin_CheckBox3 = new EASkins.Emi_CheckBox();
            this.ami_Label12 = new EASkins.Ami_Label();
            this.ami_Label2 = new EASkins.Ami_Label();
            this.ars_CheckBox1 = new EASkins.Emi_CheckBox();
            this.ars_status = new EASkins.Emi_Label();
            this.ami_Label3 = new EASkins.Ami_Label();
            this.retarder_status = new EASkins.Emi_Label();
            this.retarder_CheckBox2 = new EASkins.Emi_CheckBox();
            this.retarder_ComboBox2 = new EASkins.Ami_ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ars_ComboBox1 = new EASkins.Ami_ComboBox();
            this.ami_Label11 = new EASkins.Ami_Label();
            this.ami_Label5 = new EASkins.Ami_Label();
            this.ami_Label6 = new EASkins.Ami_Label();
            this.ami_Label8 = new EASkins.Ami_Label();
            this.ami_Label9 = new EASkins.Ami_Label();
            this.ami_Label10 = new EASkins.Ami_Label();
            this.ami_Label13 = new EASkins.Ami_Label();
            this.speed_CheckBox3 = new EASkins.Emi_CheckBox();
            this.calid_CheckBox4 = new EASkins.Emi_CheckBox();
            this.speed_textBox1 = new System.Windows.Forms.TextBox();
            this.calid_textBox1 = new System.Windows.Forms.TextBox();
            this.conect_Button_21 = new EASkins.Ami_Button_2();
            this.ucSignalLamp1 = new HZH_Controls.Controls.UCSignalLamp();
            this.ami_Label14 = new EASkins.Ami_Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ami_Button_22
            // 
            this.ami_Button_22.BackColor = System.Drawing.Color.Transparent;
            this.ami_Button_22.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ami_Button_22.Image = null;
            this.ami_Button_22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ami_Button_22.Location = new System.Drawing.Point(949, 579);
            this.ami_Button_22.Name = "ami_Button_22";
            this.ami_Button_22.Size = new System.Drawing.Size(154, 58);
            this.ami_Button_22.TabIndex = 44;
            this.ami_Button_22.Text = "刷写";
            this.ami_Button_22.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ami_Button_22.Click += new System.EventHandler(this.ami_Button_22_Click_1);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // emi_CheckBox1
            // 
            this.emi_CheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.emi_CheckBox1.Checked = false;
            this.emi_CheckBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.emi_CheckBox1.Location = new System.Drawing.Point(1008, 1161);
            this.emi_CheckBox1.Name = "emi_CheckBox1";
            this.emi_CheckBox1.Size = new System.Drawing.Size(127, 15);
            this.emi_CheckBox1.TabIndex = 47;
            this.emi_CheckBox1.Text = "确认";
            // 
            // ami_Label1
            // 
            this.ami_Label1.AutoSize = true;
            this.ami_Label1.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ami_Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label1.Location = new System.Drawing.Point(107, 1151);
            this.ami_Label1.Name = "ami_Label1";
            this.ami_Label1.Size = new System.Drawing.Size(133, 25);
            this.ami_Label1.TabIndex = 45;
            this.ami_Label1.Text = "EEPROM_VIN";
            // 
            // emi_CheckBox2
            // 
            this.emi_CheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.emi_CheckBox2.Checked = false;
            this.emi_CheckBox2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.emi_CheckBox2.Location = new System.Drawing.Point(1006, 1258);
            this.emi_CheckBox2.Name = "emi_CheckBox2";
            this.emi_CheckBox2.Size = new System.Drawing.Size(127, 15);
            this.emi_CheckBox2.TabIndex = 50;
            this.emi_CheckBox2.Text = "确认";
            // 
            // emi_RichTextBox2
            // 
            this.emi_RichTextBox2.AutoWordSelection = false;
            this.emi_RichTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.emi_RichTextBox2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.emi_RichTextBox2.ForeColor = System.Drawing.Color.DimGray;
            this.emi_RichTextBox2.Location = new System.Drawing.Point(562, 1246);
            this.emi_RichTextBox2.Name = "emi_RichTextBox2";
            this.emi_RichTextBox2.ReadOnly = false;
            this.emi_RichTextBox2.Size = new System.Drawing.Size(221, 44);
            this.emi_RichTextBox2.TabIndex = 49;
            this.emi_RichTextBox2.WordWrap = true;
            // 
            // ami_Label4
            // 
            this.ami_Label4.AutoSize = true;
            this.ami_Label4.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ami_Label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label4.Location = new System.Drawing.Point(107, 1246);
            this.ami_Label4.Name = "ami_Label4";
            this.ami_Label4.Size = new System.Drawing.Size(155, 25);
            this.ami_Label4.TabIndex = 48;
            this.ami_Label4.Text = "EEPROM_CALID";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Controls.Add(this.ep_vin_textBox1);
            this.panel1.Controls.Add(this.emvin_CheckBox3);
            this.panel1.Controls.Add(this.ami_Label12);
            this.panel1.Location = new System.Drawing.Point(0, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1192, 60);
            this.panel1.TabIndex = 55;
            // 
            // ep_vin_textBox1
            // 
            this.ep_vin_textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ep_vin_textBox1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ep_vin_textBox1.Location = new System.Drawing.Point(514, 3);
            this.ep_vin_textBox1.Multiline = true;
            this.ep_vin_textBox1.Name = "ep_vin_textBox1";
            this.ep_vin_textBox1.Size = new System.Drawing.Size(223, 44);
            this.ep_vin_textBox1.TabIndex = 82;
            this.ep_vin_textBox1.TextChanged += new System.EventHandler(this.ep_vin_text_changed);
            // 
            // emvin_CheckBox3
            // 
            this.emvin_CheckBox3.BackColor = System.Drawing.Color.Transparent;
            this.emvin_CheckBox3.Checked = false;
            this.emvin_CheckBox3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emvin_CheckBox3.Location = new System.Drawing.Point(962, 25);
            this.emvin_CheckBox3.Name = "emvin_CheckBox3";
            this.emvin_CheckBox3.Size = new System.Drawing.Size(127, 15);
            this.emvin_CheckBox3.TabIndex = 79;
            this.emvin_CheckBox3.Text = "已配置";
            // 
            // ami_Label12
            // 
            this.ami_Label12.AutoSize = true;
            this.ami_Label12.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label12.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ami_Label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label12.Location = new System.Drawing.Point(36, 15);
            this.ami_Label12.Name = "ami_Label12";
            this.ami_Label12.Size = new System.Drawing.Size(103, 25);
            this.ami_Label12.TabIndex = 69;
            this.ami_Label12.Text = "存储器VIN";
            // 
            // ami_Label2
            // 
            this.ami_Label2.AutoSize = true;
            this.ami_Label2.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ami_Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label2.Location = new System.Drawing.Point(39, 20);
            this.ami_Label2.Name = "ami_Label2";
            this.ami_Label2.Size = new System.Drawing.Size(48, 25);
            this.ami_Label2.TabIndex = 59;
            this.ami_Label2.Text = "ASR";
            // 
            // ars_CheckBox1
            // 
            this.ars_CheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.ars_CheckBox1.Checked = false;
            this.ars_CheckBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ars_CheckBox1.Location = new System.Drawing.Point(962, 31);
            this.ars_CheckBox1.Name = "ars_CheckBox1";
            this.ars_CheckBox1.Size = new System.Drawing.Size(127, 15);
            this.ars_CheckBox1.TabIndex = 61;
            this.ars_CheckBox1.Text = "已配置";
            // 
            // ars_status
            // 
            this.ars_status.AutoSize = true;
            this.ars_status.BackColor = System.Drawing.Color.Transparent;
            this.ars_status.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ars_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.ars_status.Location = new System.Drawing.Point(277, 21);
            this.ars_status.Name = "ars_status";
            this.ars_status.Size = new System.Drawing.Size(69, 25);
            this.ars_status.TabIndex = 62;
            this.ars_status.Text = "未激活";
            // 
            // ami_Label3
            // 
            this.ami_Label3.AutoSize = true;
            this.ami_Label3.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ami_Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label3.Location = new System.Drawing.Point(39, 332);
            this.ami_Label3.Name = "ami_Label3";
            this.ami_Label3.Size = new System.Drawing.Size(69, 25);
            this.ami_Label3.TabIndex = 63;
            this.ami_Label3.Text = "缓速器";
            // 
            // retarder_status
            // 
            this.retarder_status.AutoSize = true;
            this.retarder_status.BackColor = System.Drawing.Color.Transparent;
            this.retarder_status.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retarder_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.retarder_status.Location = new System.Drawing.Point(277, 335);
            this.retarder_status.Name = "retarder_status";
            this.retarder_status.Size = new System.Drawing.Size(69, 25);
            this.retarder_status.TabIndex = 66;
            this.retarder_status.Text = "未激活";
            // 
            // retarder_CheckBox2
            // 
            this.retarder_CheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.retarder_CheckBox2.Checked = false;
            this.retarder_CheckBox2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.retarder_CheckBox2.Location = new System.Drawing.Point(962, 342);
            this.retarder_CheckBox2.Name = "retarder_CheckBox2";
            this.retarder_CheckBox2.Size = new System.Drawing.Size(127, 15);
            this.retarder_CheckBox2.TabIndex = 65;
            this.retarder_CheckBox2.Text = "已配置";
            // 
            // retarder_ComboBox2
            // 
            this.retarder_ComboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.retarder_ComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.retarder_ComboBox2.DropDownHeight = 100;
            this.retarder_ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.retarder_ComboBox2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retarder_ComboBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.retarder_ComboBox2.FormattingEnabled = true;
            this.retarder_ComboBox2.HoverSelectionColor = System.Drawing.Color.Empty;
            this.retarder_ComboBox2.IntegralHeight = false;
            this.retarder_ComboBox2.ItemHeight = 20;
            this.retarder_ComboBox2.Items.AddRange(new object[] {
            "未选择",
            "激活",
            "未激活"});
            this.retarder_ComboBox2.Location = new System.Drawing.Point(517, 332);
            this.retarder_ComboBox2.Name = "retarder_ComboBox2";
            this.retarder_ComboBox2.Size = new System.Drawing.Size(220, 26);
            this.retarder_ComboBox2.StartIndex = 0;
            this.retarder_ComboBox2.TabIndex = 64;
            this.retarder_ComboBox2.Tag = "";
            this.retarder_ComboBox2.TextChanged += new System.EventHandler(this.retarder_text_changed);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Menu;
            this.panel2.Controls.Add(this.ami_Label2);
            this.panel2.Controls.Add(this.ars_status);
            this.panel2.Controls.Add(this.ars_ComboBox1);
            this.panel2.Controls.Add(this.ars_CheckBox1);
            this.panel2.Location = new System.Drawing.Point(0, 371);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1192, 60);
            this.panel2.TabIndex = 67;
            // 
            // ars_ComboBox1
            // 
            this.ars_ComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.ars_ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ars_ComboBox1.DropDownHeight = 100;
            this.ars_ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ars_ComboBox1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ars_ComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.ars_ComboBox1.FormattingEnabled = true;
            this.ars_ComboBox1.HoverSelectionColor = System.Drawing.Color.Empty;
            this.ars_ComboBox1.IntegralHeight = false;
            this.ars_ComboBox1.ItemHeight = 20;
            this.ars_ComboBox1.Items.AddRange(new object[] {
            "未选择",
            "激活",
            "未激活"});
            this.ars_ComboBox1.Location = new System.Drawing.Point(517, 20);
            this.ars_ComboBox1.Name = "ars_ComboBox1";
            this.ars_ComboBox1.Size = new System.Drawing.Size(220, 26);
            this.ars_ComboBox1.StartIndex = 0;
            this.ars_ComboBox1.TabIndex = 79;
            this.ars_ComboBox1.Tag = "";
            this.ars_ComboBox1.TextChanged += new System.EventHandler(this.ars_text_changed);
            // 
            // ami_Label11
            // 
            this.ami_Label11.AutoSize = true;
            this.ami_Label11.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label11.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ami_Label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label11.Location = new System.Drawing.Point(743, 19);
            this.ami_Label11.Name = "ami_Label11";
            this.ami_Label11.Size = new System.Drawing.Size(52, 25);
            this.ami_Label11.TabIndex = 71;
            this.ami_Label11.Text = "km/s";
            // 
            // ami_Label5
            // 
            this.ami_Label5.AutoSize = true;
            this.ami_Label5.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label5.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ami_Label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label5.Location = new System.Drawing.Point(25, 19);
            this.ami_Label5.Name = "ami_Label5";
            this.ami_Label5.Size = new System.Drawing.Size(126, 25);
            this.ami_Label5.TabIndex = 68;
            this.ami_Label5.Text = "最高车速限制";
            // 
            // ami_Label6
            // 
            this.ami_Label6.AutoSize = true;
            this.ami_Label6.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ami_Label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label6.Location = new System.Drawing.Point(36, 80);
            this.ami_Label6.Name = "ami_Label6";
            this.ami_Label6.Size = new System.Drawing.Size(92, 27);
            this.ami_Label6.TabIndex = 73;
            this.ami_Label6.Text = "功能名称";
            // 
            // ami_Label8
            // 
            this.ami_Label8.AutoSize = true;
            this.ami_Label8.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ami_Label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label8.Location = new System.Drawing.Point(277, 80);
            this.ami_Label8.Name = "ami_Label8";
            this.ami_Label8.Size = new System.Drawing.Size(92, 27);
            this.ami_Label8.TabIndex = 74;
            this.ami_Label8.Text = "当前状态";
            // 
            // ami_Label9
            // 
            this.ami_Label9.AutoSize = true;
            this.ami_Label9.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ami_Label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label9.Location = new System.Drawing.Point(558, 80);
            this.ami_Label9.Name = "ami_Label9";
            this.ami_Label9.Size = new System.Drawing.Size(92, 27);
            this.ami_Label9.TabIndex = 75;
            this.ami_Label9.Text = "修改数值";
            // 
            // ami_Label10
            // 
            this.ami_Label10.AutoSize = true;
            this.ami_Label10.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ami_Label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label10.Location = new System.Drawing.Point(958, 80);
            this.ami_Label10.Name = "ami_Label10";
            this.ami_Label10.Size = new System.Drawing.Size(92, 27);
            this.ami_Label10.TabIndex = 76;
            this.ami_Label10.Text = "状态选着";
            // 
            // ami_Label13
            // 
            this.ami_Label13.AutoSize = true;
            this.ami_Label13.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label13.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ami_Label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label13.Location = new System.Drawing.Point(36, 204);
            this.ami_Label13.Name = "ami_Label13";
            this.ami_Label13.Size = new System.Drawing.Size(68, 25);
            this.ami_Label13.TabIndex = 70;
            this.ami_Label13.Text = "CALID";
            // 
            // speed_CheckBox3
            // 
            this.speed_CheckBox3.BackColor = System.Drawing.Color.Transparent;
            this.speed_CheckBox3.Checked = false;
            this.speed_CheckBox3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.speed_CheckBox3.Location = new System.Drawing.Point(962, 19);
            this.speed_CheckBox3.Name = "speed_CheckBox3";
            this.speed_CheckBox3.Size = new System.Drawing.Size(127, 15);
            this.speed_CheckBox3.TabIndex = 70;
            this.speed_CheckBox3.Text = "已配置";
            // 
            // calid_CheckBox4
            // 
            this.calid_CheckBox4.BackColor = System.Drawing.Color.Transparent;
            this.calid_CheckBox4.Checked = false;
            this.calid_CheckBox4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calid_CheckBox4.Location = new System.Drawing.Point(962, 214);
            this.calid_CheckBox4.Name = "calid_CheckBox4";
            this.calid_CheckBox4.Size = new System.Drawing.Size(127, 15);
            this.calid_CheckBox4.TabIndex = 78;
            this.calid_CheckBox4.Text = "已配置";
            // 
            // speed_textBox1
            // 
            this.speed_textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.speed_textBox1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.speed_textBox1.Location = new System.Drawing.Point(514, 3);
            this.speed_textBox1.Multiline = true;
            this.speed_textBox1.Name = "speed_textBox1";
            this.speed_textBox1.Size = new System.Drawing.Size(223, 44);
            this.speed_textBox1.TabIndex = 80;
            this.speed_textBox1.TextChanged += new System.EventHandler(this.speed_text_changed);
            // 
            // calid_textBox1
            // 
            this.calid_textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.calid_textBox1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.calid_textBox1.Location = new System.Drawing.Point(514, 193);
            this.calid_textBox1.Multiline = true;
            this.calid_textBox1.Name = "calid_textBox1";
            this.calid_textBox1.Size = new System.Drawing.Size(223, 44);
            this.calid_textBox1.TabIndex = 81;
            this.calid_textBox1.TextChanged += new System.EventHandler(this.calid_text_changed);
            // 
            // conect_Button_21
            // 
            this.conect_Button_21.BackColor = System.Drawing.Color.Transparent;
            this.conect_Button_21.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.conect_Button_21.Image = null;
            this.conect_Button_21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.conect_Button_21.Location = new System.Drawing.Point(41, 588);
            this.conect_Button_21.Name = "conect_Button_21";
            this.conect_Button_21.Size = new System.Drawing.Size(154, 58);
            this.conect_Button_21.TabIndex = 82;
            this.conect_Button_21.Text = "重新连接";
            this.conect_Button_21.TextAlignment = System.Drawing.StringAlignment.Center;
            this.conect_Button_21.Click += new System.EventHandler(this.conect_Button_21_Click);
            // 
            // ucSignalLamp1
            // 
            this.ucSignalLamp1.IsHighlight = true;
            this.ucSignalLamp1.IsShowBorder = false;
            this.ucSignalLamp1.LampColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))))};
            this.ucSignalLamp1.Location = new System.Drawing.Point(399, 588);
            this.ucSignalLamp1.Name = "ucSignalLamp1";
            this.ucSignalLamp1.Size = new System.Drawing.Size(49, 49);
            this.ucSignalLamp1.TabIndex = 83;
            this.ucSignalLamp1.TwinkleSpeed = 0;
            // 
            // ami_Label14
            // 
            this.ami_Label14.AutoSize = true;
            this.ami_Label14.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label14.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ami_Label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label14.Location = new System.Drawing.Point(454, 602);
            this.ami_Label14.Name = "ami_Label14";
            this.ami_Label14.Size = new System.Drawing.Size(88, 25);
            this.ami_Label14.TabIndex = 84;
            this.ami_Label14.Text = "连接状态";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Menu;
            this.panel3.Controls.Add(this.ami_Label5);
            this.panel3.Controls.Add(this.speed_textBox1);
            this.panel3.Controls.Add(this.ami_Label11);
            this.panel3.Controls.Add(this.speed_CheckBox3);
            this.panel3.Location = new System.Drawing.Point(0, 252);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1192, 60);
            this.panel3.TabIndex = 57;
            // 
            // Setting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1194, 680);
            this.Controls.Add(this.retarder_CheckBox2);
            this.Controls.Add(this.retarder_ComboBox2);
            this.Controls.Add(this.ami_Label3);
            this.Controls.Add(this.ami_Label14);
            this.Controls.Add(this.retarder_status);
            this.Controls.Add(this.ucSignalLamp1);
            this.Controls.Add(this.conect_Button_21);
            this.Controls.Add(this.calid_textBox1);
            this.Controls.Add(this.calid_CheckBox4);
            this.Controls.Add(this.ami_Label13);
            this.Controls.Add(this.ami_Label10);
            this.Controls.Add(this.ami_Label9);
            this.Controls.Add(this.ami_Label8);
            this.Controls.Add(this.ami_Label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.emi_CheckBox2);
            this.Controls.Add(this.emi_RichTextBox2);
            this.Controls.Add(this.ami_Label4);
            this.Controls.Add(this.emi_CheckBox1);
            this.Controls.Add(this.ami_Label1);
            this.Controls.Add(this.ami_Button_22);
            this.MaximizeBox = false;
            this.Name = "Setting";
            this.Text = "上菲红发动机";
            this.Load += new System.EventHandler(this.ARS790_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private EASkins.Ami_Button_2 ami_Button_22;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private EASkins.Emi_CheckBox emi_CheckBox1;
        private EASkins.Ami_Label ami_Label1;
        private EASkins.Emi_CheckBox emi_CheckBox2;
        private EASkins.Emi_RichTextBox emi_RichTextBox2;
        private EASkins.Ami_Label ami_Label4;
        private System.Windows.Forms.Panel panel1;
        private EASkins.Ami_Label ami_Label2;
        private EASkins.Emi_CheckBox ars_CheckBox1;
        private EASkins.Emi_Label ars_status;
        private EASkins.Ami_Label ami_Label3;
        private EASkins.Emi_Label retarder_status;
        private EASkins.Emi_CheckBox retarder_CheckBox2;
        private EASkins.Ami_ComboBox retarder_ComboBox2;
        private System.Windows.Forms.Panel panel2;
        private EASkins.Ami_Label ami_Label11;
        private EASkins.Ami_Label ami_Label5;
        private EASkins.Ami_Label ami_Label6;
        private EASkins.Ami_Label ami_Label8;
        private EASkins.Ami_Label ami_Label9;
        private EASkins.Ami_Label ami_Label10;
        private EASkins.Ami_Label ami_Label12;
        private EASkins.Ami_Label ami_Label13;
        private EASkins.Ami_ComboBox ars_ComboBox1;
        private EASkins.Emi_CheckBox emvin_CheckBox3;
        private EASkins.Emi_CheckBox speed_CheckBox3;
        private EASkins.Emi_CheckBox calid_CheckBox4;
        private System.Windows.Forms.TextBox ep_vin_textBox1;
        private System.Windows.Forms.TextBox speed_textBox1;
        private System.Windows.Forms.TextBox calid_textBox1;
        private EASkins.Ami_Button_2 conect_Button_21;
        private HZH_Controls.Controls.UCSignalLamp ucSignalLamp1;
        private EASkins.Ami_Label ami_Label14;
        private System.Windows.Forms.Panel panel3;
    }
}