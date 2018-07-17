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
    public partial class DiagnosticSpeed : CCSkinMain
    {
        public DiagnosticSpeed()
        {
            InitializeComponent();
        }

        private void DiagnosticSpeed_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Text = "测试中";
            try
            {
                String startValue = this.richTextBox1.Text;
                String endtValue = this.richTextBox2.Text;
                if ( "".Equals(startValue)||startValue==null ||("".Equals(endtValue)||endtValue==null ) ) {

                    MessageBox.Show("请输入数据");
                    return;
                }
                long start = long.Parse(startValue);
                long end = long.Parse(endtValue);
                if (end < start) {

                    MessageBox.Show("结束速度需要大于开始速度");
                    return;
                }
                // 开始速度
               String  startValue16 = Convert.ToString(start * 2, 16).PadLeft(4,'0');
               // 结束速度
               String  endtValue16 = Convert.ToString(end * 2, 16).PadLeft(4,'0');
               String speedValue = CommonCmd.speedprefix + startValue16 + endtValue16 + CommonCmd.speedsuffix + "\n";

               byte[] speedValueByte = StringToSendBytes.bytesToSend(startValue);
               WriteVale(speedValueByte);
               readValue();
            }
            catch (Exception ) {
            }
            this.button1.Text = "开始";
        }






        private static int comCount = 0;
        /// <summary>
        /// 写数据
        /// </summary>
        public void WriteVale(byte []  speed)
        {

            try
            {
                comCount++;
                GobalSerialPort.WriteByMessage(speed, 0, speed.Length);
                String backString = GobalSerialPort.ResultBackString;
                if (comCount > 10)
                {
                    this.richTextBox1.Text = "测试失败 请重试";
                    comCount = 0;
                    return;
                }
                if (backString.Contains("71") && backString.Contains("1A"))
                {
                    MessageBox.Show("开始测试");
                    return;
                }
                else
                {
               
                    WriteVale(speed);
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
                GobalSerialPort.WriteByMessage(CommonCmd._331A, 0, CommonCmd._331A.Length);
                String bakcString = GobalSerialPort.ResultBackString;
                if (bakcString.Contains("7F"))
                {
                    this.richTextBox3.Text = bakcString;
                    MessageBox.Show("测试终止");
                    return;
                }
                if (bakcString.Contains("73") && bakcString.Contains("1A")
                     && bakcString.Contains("02"))
                {
                    String[] result = bakcString.Split('\r');
                    this.richTextBox3.Text = result[1];
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
