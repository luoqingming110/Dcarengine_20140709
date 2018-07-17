using CCWin;
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
    public partial class EngineBreake : CCSkinMain
    {
        public EngineBreake()
        {
            InitializeComponent();
        }


        private void EngineBreake_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// fe  commend
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.FE.Text = "测试中";
            WriteValefe();
            readValuefe();
            this.FE.Text = "发动机制动开 排气制动关";
        }





        /// <summary>
        /// fd  commend
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.Text = "测试中";
            WriteValefd();
            readValuefe();
            this.button2.Text = "发动机制动关 排气制动关";

        }

        /// <summary>
        /// 
        /// ce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.button3.Text = "测试中";
            WriteValece();
            readValuefe();
            this.button3.Text = "发动机制动开 排气制动开";
        }


        /// <summary>
        /// cf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            this.button4.Text = "测试中";
            WriteValecf();
            readValuefe();
            this.button4.Text = "发动机制动关 排气制动开";
        }


        public static int comCount = 0;
        /// <summary>
        /// 写数据
        /// </summary>
        public void WriteValefe()
        {
            
            try
            {
                comCount++;
                GobalSerialPort.WriteByMessage(CommonCmd._331bfe, 0, CommonCmd._331bfe.Length);
                String backString = GobalSerialPort.ResultBackString;
                if (comCount > 10)
                {
                    this.richTextBox1.Text = "测试失败 请重试";
                    comCount = 0;
                    return;
                }
                if ( (backString.Contains("71") && backString.Contains("1B")))
                {
                    MessageBox.Show("开始测试");
                }
                else {
                    WriteValefe();
                }
            }
            catch { }
        }


        /// <summary>
        /// 3318数据返回
        /// </summary>
        public void readValuefe()
        {
            try
            {
                GobalSerialPort.WriteByMessage(CommonCmd._331b, 0, CommonCmd._331b.Length);
                String bakcString = GobalSerialPort.ResultBackString;
                if (bakcString.Contains("7F"))
                {
                    this.richTextBox5.Text = bakcString;
                    MessageBox.Show("测试终止");
                    return;
                }
                if (bakcString.Contains("73") && bakcString.Contains("1B")
                     && bakcString.Contains("02"))
                {
                    String[] result = bakcString.Split('\r');
                    this.richTextBox5.Text = result[1];
                    comCount = 0;
                    MessageBox.Show("测试完成");
                    return;
                }
                readValuefe();
            }
            catch
            {
            }
        }




        /// <summary>
        /// 写数据
        /// </summary>
        public void WriteValefd()
        {

            try
            {
                comCount++;
                GobalSerialPort.WriteByMessage(CommonCmd._331bfd, 0, CommonCmd._331bfd.Length);
                String backString = GobalSerialPort.ResultBackString;
                if (comCount > 10)
                {
                    this.richTextBox2.Text = "测试失败 请重试";
                    comCount = 0;
                    return;
                }
                if ((backString.Contains("71") && backString.Contains("1B")))
                {
                    MessageBox.Show("开始测试");
                }
                else {

                    WriteValefd();
                }
            }
            catch { }
        }



        /// <summary>
        /// 写数据
        /// </summary>
        public void WriteValecf()
        {
            try
            {
                comCount++;
                GobalSerialPort.WriteByMessage(CommonCmd._331bcf, 0, CommonCmd._331bcf.Length);
                String backString = GobalSerialPort.ResultBackString;
                if (comCount > 10)
                {
                    this.richTextBox4.Text = "测试失败 请重试";
                    comCount = 0;
                    return;
                }
                if ( (backString.Contains("71") && backString.Contains("1B")))
                {
                    // WriteValecf();
                    MessageBox.Show("开始测试");
                }
                else {

                    WriteValecf();
                }
            }
            catch { }
        }


        /// <summary>
        /// 写数据
        /// </summary>
        public void WriteValece()
        {

            try
            {
                comCount++;
                GobalSerialPort.WriteByMessage(CommonCmd._331bce, 0, CommonCmd._331bce.Length);
                String backString = GobalSerialPort.ResultBackString;
                if (comCount > 10)
                {
                    this.richTextBox3.Text = "测试失败 请重试";
                    comCount = 0;
                    return;
                } 
                if ( (backString.Contains("71") && backString.Contains("1B")))
                {
                    MessageBox.Show("开始测试");
                }
                else
                {
                    WriteValece();
                }

            }
            catch { }
        }




  
    }
}
