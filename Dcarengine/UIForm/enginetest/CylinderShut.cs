using CCWin;
using Dcarengine.Function_Class;
using Dcarengine.refactor;
using Dcarengine.serialPort;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dcarengine.UIForm.enginetest
{
    public partial class CylinderShut : CCSkinMain
    {
        public CylinderShut()
        {
            InitializeComponent();
        }

        private void CylinderShut_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 测试开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Text = "测试中";

            if (this.checkBox1.Checked)
            {

                String cmd = CommonCmd.shutprefix + "00" + "FFFFFFFFFF";
                byte[] cmdbyte = StringToSendBytes.bytesToSend(cmd + "\n");
                //serialPort.GobalSerialPort.WriteByMessage(cmdbyte,0,cmdbyte.Length);
          
                WriteVale(cmdbyte);
                readValue();

            }

            if (this.checkBox2.Checked)
            {

                String cmd = CommonCmd.shutprefix + "FF" + "00" + "FFFFFFFF";
                byte[] cmdbyte = StringToSendBytes.bytesToSend(cmd + "\n");
                //serialPort.GobalSerialPort.WriteByMessage(cmdbyte,0,cmdbyte.Length);

                WriteVale(cmdbyte);
                readValue();

            }

            if (this.checkBox3.Checked)
            {

                String cmd = CommonCmd.shutprefix + "FFFF00FFFFFF" ;
                byte[] cmdbyte = StringToSendBytes.bytesToSend(cmd + "\n");
                //serialPort.GobalSerialPort.WriteByMessage(cmdbyte,0,cmdbyte.Length);

                WriteVale(cmdbyte);
                readValue();

            }

            if (this.checkBox5.Checked)
            {
                String cmd = CommonCmd.shutprefix + "FFFFFF00FFFF" ;
                byte[] cmdbyte = StringToSendBytes.bytesToSend(cmd + "\n");
                //serialPort.GobalSerialPort.WriteByMessage(cmdbyte,0,cmdbyte.Length);

                WriteVale(cmdbyte);
                readValue();

            }

            if (this.checkBox7.Checked)
            {

                String cmd = CommonCmd.shutprefix + "FFFFFFFF00FF" ;
                byte[] cmdbyte = StringToSendBytes.bytesToSend(cmd + "\n");
                //serialPort.GobalSerialPort.WriteByMessage(cmdbyte,0,cmdbyte.Length);

                WriteVale(cmdbyte);
                readValue();

            }

            if (this.checkBox8.Checked)
            {
                String cmd = CommonCmd.shutprefix + "FFFFFFFFFF00";
                byte[] cmdbyte = StringToSendBytes.bytesToSend(cmd + "\n");
                //serialPort.GobalSerialPort.WriteByMessage(cmdbyte,0,cmdbyte.Length);

                WriteVale(cmdbyte);
                readValue();

            }
            else {

                String cmd = CommonCmd.shutprefix + "FFFFFFFFFFFF";
                byte[] cmdbyte = StringToSendBytes.bytesToSend(cmd + "\n");
                //serialPort.GobalSerialPort.WriteByMessage(cmdbyte,0,cmdbyte.Length);

                WriteVale(cmdbyte);
                readValue();
            }
            this.button1.Text = "开始";

        }



        public static int comCount = 0;
        /// <summary>
        /// 写数据
        /// </summary>
        public void WriteVale(byte[] cmd)
        {

            try
            {
                comCount++;
                GobalSerialPort.WriteByMessage(cmd, 0, cmd.Length);
                String backString = GobalSerialPort.ResultBackString;
                if (comCount > 10)
                {
                    this.richTextBox1.Text = "测试失败 请重试";
                    comCount = 0;
                    return;

                }
                if (backString.Contains("71") && backString.Contains("16"))
                {
                    MessageBox.Show("开始测试");
                }
                else
                {

                    WriteVale(cmd);
                }

            }
            catch { }
        }

        /// <summary>
        /// 3318数据返回
        /// </summary>
        public void readValue()
        {
            try
            {
                GobalSerialPort.WriteByMessage(CommonCmd._3315, 0, CommonCmd._3315.Length);
                String bakcString = GobalSerialPort.ResultBackString;
                if (bakcString.Contains("7F"))
                {
                    this.richTextBox1.Text = bakcString;
                    MessageBox.Show("测试终止");
                    return;
                }
                if (bakcString.Contains("73") && bakcString.Contains("15")
                     && bakcString.Contains("02"))
                {
                    String[] result = bakcString.Split('\r');
                    this.richTextBox1.AppendText(result[1]);
                    comCount = 0;
                    MessageBox.Show("测试完成");
                    return;
                }
                readValue();
            }
            catch
            {
            }
        }






    }
}
