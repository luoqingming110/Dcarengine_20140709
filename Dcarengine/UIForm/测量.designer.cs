using Dcarengine.UIForm;
using Dcarengine.Function_Class;
using Dcarengine.serialPort;
using Dcarengine.refactor;
using System.IO.Ports;
using System;
using System.Threading;

namespace Dcarengine
{
    partial class 测量
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

            /// 重构事件
            ///
            try {
                GobalSerialPort.SerialPort.DataReceived -= new SerialDataReceivedEventHandler(measure_DataReceivedByMeasure);
                GobalSerialPort.SerialPort.DataReceived += new SerialDataReceivedEventHandler(GobalSerialPort.SerialportMessage_DataReceived);

                if (MeasureTimer.stateTimer != null) {
                    MeasureTimer.stateTimer.Dispose();
                }

                ///reaply
                new Thread(RealyDelay).Start();               
                EcuConnectionFRe.ClearSendAndRecive();
                EcuConnectionFRe.ClearSendAndRecive();

            }
            catch (Exception e) {
                log.Info("from dispose exception :" + e.Message);
            }
            measureflag = true;
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(测量));
            this.单次测量 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.删除 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.选择时间 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.选择输出项 = new System.Windows.Forms.Label();
            this.插入 = new System.Windows.Forms.Button();
            this.测量参数 = new System.Windows.Forms.ComboBox();
            this.eCU13AdRessBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCU13AdRessBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // 单次测量
            // 
            this.单次测量.Location = new System.Drawing.Point(235, 36);
            this.单次测量.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.单次测量.Name = "单次测量";
            this.单次测量.Size = new System.Drawing.Size(161, 53);
            this.单次测量.TabIndex = 29;
            this.单次测量.Text = "测量不保存";
            this.单次测量.UseVisualStyleBackColor = true;
            this.单次测量.Click += new System.EventHandler(this.测量不保存_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(19, 36);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(161, 53);
            this.button7.TabIndex = 27;
            this.button7.Text = "测量保存";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.测量保存_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(15, 359);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 41);
            this.button5.TabIndex = 25;
            this.button5.Text = "导  出";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.导出_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(15, 271);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 41);
            this.button4.TabIndex = 24;
            this.button4.Text = "导  入";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.导入_Click);
            // 
            // 删除
            // 
            this.删除.Location = new System.Drawing.Point(15, 185);
            this.删除.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.删除.Name = "删除";
            this.删除.Size = new System.Drawing.Size(112, 41);
            this.删除.TabIndex = 23;
            this.删除.Text = "删  除";
            this.删除.UseVisualStyleBackColor = true;
            this.删除.Click += new System.EventHandler(this.删除选中的列表);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 623);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "时间频率";
            // 
            // 选择时间
            // 
            this.选择时间.FormattingEnabled = true;
            this.选择时间.Items.AddRange(new object[] {
            "200",
            "500",
            "1000"});
            this.选择时间.Location = new System.Drawing.Point(184, 623);
            this.选择时间.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.选择时间.Name = "选择时间";
            this.选择时间.Size = new System.Drawing.Size(180, 28);
            this.选择时间.TabIndex = 19;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dataGridView1.Location = new System.Drawing.Point(45, 118);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(607, 459);
            this.dataGridView1.TabIndex = 18;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "测量参数";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "描述";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "单位";
            this.Column3.Name = "Column3";
            this.Column3.Width = 70;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "测量值";
            this.Column4.Name = "Column4";
            this.Column4.Width = 140;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            this.Column7.Visible = false;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Column8";
            this.Column8.Name = "Column8";
            this.Column8.Visible = false;
            // 
            // 选择输出项
            // 
            this.选择输出项.AutoSize = true;
            this.选择输出项.Location = new System.Drawing.Point(42, 28);
            this.选择输出项.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.选择输出项.Name = "选择输出项";
            this.选择输出项.Size = new System.Drawing.Size(84, 20);
            this.选择输出项.TabIndex = 17;
            this.选择输出项.Text = "选择输出项";
            // 
            // 插入
            // 
            this.插入.Location = new System.Drawing.Point(526, 16);
            this.插入.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.插入.Name = "插入";
            this.插入.Size = new System.Drawing.Size(112, 45);
            this.插入.TabIndex = 16;
            this.插入.Text = "插入";
            this.插入.UseVisualStyleBackColor = true;
            this.插入.Click += new System.EventHandler(this.插入_Click);
            // 
            // 测量参数
            // 
            this.测量参数.FormattingEnabled = true;
            this.测量参数.Location = new System.Drawing.Point(168, 24);
            this.测量参数.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.测量参数.Name = "测量参数";
            this.测量参数.Size = new System.Drawing.Size(268, 28);
            this.测量参数.TabIndex = 15;
            // 
            // eCU13AdRessBindingSource
            // 
            this.eCU13AdRessBindingSource.DataMember = "ECU13AdRess";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 21);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 41);
            this.button1.TabIndex = 30;
            this.button1.Text = "上  移";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.上移);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 97);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 41);
            this.button2.TabIndex = 31;
            this.button2.Text = "下  移";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.下移);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.单次测量);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Location = new System.Drawing.Point(393, 590);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 117);
            this.panel1.TabIndex = 33;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.删除);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Location = new System.Drawing.Point(670, 118);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(144, 445);
            this.panel2.TabIndex = 34;
            // 
            // 测量
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(831, 715);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.选择时间);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.选择输出项);
            this.Controls.Add(this.插入);
            this.Controls.Add(this.测量参数);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "测量";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数测量";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Deasure_FormClosed);
            this.Load += new System.EventHandler(this.测量_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCU13AdRessBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button 单次测量;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button 删除;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox 选择时间;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label 选择输出项;
        private System.Windows.Forms.Button 插入;
        private System.Windows.Forms.ComboBox 测量参数;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.BindingSource eCU13AdRessBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}