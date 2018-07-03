using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dcarengine.Function_Class;
using Dcarengine.refactor;
using Dcarengine.serialPort;

namespace Dcarengine.UIForm.enginetest
{
    public partial class RunupTest : Form
    {
        public RunupTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked) {

                String cmd = CommonCmd._runUptestprefix + "00" + CommonCmd._runUptestsuffix;
                byte[] cmdbyte = StringToSendBytes.bytesToSend(cmd + "\n");
                //serialPort.GobalSerialPort.WriteByMessage(cmdbyte,0,cmdbyte.Length);

                WriteVale(cmdbyte);
                readValue();

            }

            if (this.checkBox2.Checked)
            {

                String cmd = CommonCmd._runUptestprefix + "01" + CommonCmd._runUptestsuffix;
                byte[] cmdbyte = StringToSendBytes.bytesToSend(cmd + "\n");
                //serialPort.GobalSerialPort.WriteByMessage(cmdbyte,0,cmdbyte.Length);

                WriteVale(cmdbyte);
                readValue();

            }

            if (this.checkBox3.Checked)
            {

                String cmd = CommonCmd._runUptestprefix + "02" + CommonCmd._runUptestsuffix;
                byte[] cmdbyte = StringToSendBytes.bytesToSend(cmd + "\n");
                //serialPort.GobalSerialPort.WriteByMessage(cmdbyte,0,cmdbyte.Length);

                WriteVale(cmdbyte);
                readValue();

            }

            if (this.checkBox5.Checked)
            {
                String cmd = CommonCmd._runUptestprefix + "03" + CommonCmd._runUptestsuffix;
                byte[] cmdbyte = StringToSendBytes.bytesToSend(cmd + "\n");
                //serialPort.GobalSerialPort.WriteByMessage(cmdbyte,0,cmdbyte.Length);

                WriteVale(cmdbyte);
                readValue();

            }

            if (this.checkBox7.Checked)
            {

                String cmd = CommonCmd._runUptestprefix + "04" + CommonCmd._runUptestsuffix;
                byte[] cmdbyte = StringToSendBytes.bytesToSend(cmd + "\n");
                //serialPort.GobalSerialPort.WriteByMessage(cmdbyte,0,cmdbyte.Length);

                WriteVale(cmdbyte);
                readValue();

            }

            if (this.checkBox8.Checked)
            {
                String cmd = CommonCmd._runUptestprefix + "05" + CommonCmd._runUptestsuffix;
                byte[] cmdbyte = StringToSendBytes.bytesToSend(cmd + "\n");
                //serialPort.GobalSerialPort.WriteByMessage(cmdbyte,0,cmdbyte.Length);

                WriteVale(cmdbyte);
                readValue();

            }
            else {

                String cmd = CommonCmd._runUptestprefix + "FF" + CommonCmd._runUptestsuffix;
                byte[] cmdbyte = StringToSendBytes.bytesToSend(cmd + "\n");
                //serialPort.GobalSerialPort.WriteByMessage(cmdbyte,0,cmdbyte.Length);

                WriteVale(cmdbyte);
                readValue();
            }
            

        }



        public static int comCount = 0;
        /// <summary>
        /// 写数据
        /// </summary>
        public void WriteVale(byte []   cmd)
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
                if (!backString.Contains("71") && !backString.Contains("16"))
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
                GobalSerialPort.WriteByMessage(CommonCmd._3316, 0, CommonCmd._3316.Length);
                String bakcString = GobalSerialPort.ResultBackString;
                if (bakcString.Contains("73") && bakcString.Contains("16")
                     && bakcString.Contains("02"))
                {
                    String[] result = bakcString.Split('\r');
                    this.richTextBox1.AppendText ( result[1] );
                    comCount = 0;
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
