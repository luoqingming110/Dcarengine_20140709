﻿namespace Dcarengine.UIForm.enginetest
{
    partial class CompressionTest
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
            this.FE = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FE
            // 
            this.FE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FE.Location = new System.Drawing.Point(327, 98);
            this.FE.Name = "FE";
            this.FE.Size = new System.Drawing.Size(261, 103);
            this.FE.TabIndex = 1;
            this.FE.Text = "开始";
            this.FE.UseVisualStyleBackColor = true;
            this.FE.Click += new System.EventHandler(this.FE_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(227, 218);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(481, 180);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(178, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(598, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "此项需要在发动机为启动时进行测试，测试开始后，请拧动发动机钥匙";
            // 
            // CompressionTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 572);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.FE);
            this.Name = "CompressionTest";
            this.Text = "CompressionTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FE;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
    }
}