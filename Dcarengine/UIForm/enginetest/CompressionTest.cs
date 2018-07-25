using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dcarengine.serialPort;
using Dcarengine.refactor;
using System.Threading;
using CCWin;

namespace Dcarengine.UIForm.enginetest
{
    public partial class CompressionTest : CCSkinMain
    {
        /// <summary>
        /// compressionTest
        /// </summary>
        public CompressionTest()
        {
            InitializeComponent();      
        } 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FE_Click(object sender, EventArgs e)
        {
            this.FE.Text = "测试中";
            if (WriteVale())
            {
                readValue();
            }
           // Thread.Sleep(10000);
            this.FE.Text = "开始";
        }



        public static int comCount = 0;
        /// <summary>
        /// 写数据
        /// </summary>
        public bool WriteVale() {
            try
            {
                comCount++;
                GobalSerialPort.WriteByMessage(CommonCmd._CompressionTest, 0, CommonCmd._CompressionTest.Length);
                String backString = GobalSerialPort.ResultBackString;
                if (comCount > 5)
                {
                    this.richTextBox1.Text = "测试失败 请重试";
                    comCount = 0;
                    //throw new Exception();
                    return false;
                }
                if (backString.Contains("71") && backString.Contains("18"))
                {
                    MessageBox.Show("开始测试");
                    return true;
                }
                else {
                    WriteVale();
                }

            }
            catch {}
            return false;
        }


        /// <summary>
        /// 3318数据返回
        /// </summary>
        public void readValue() {

            try
            {
                GobalSerialPort.WriteByMessage(CommonCmd._3318, 0, CommonCmd._3318.Length);
                String bakcString = GobalSerialPort.ResultBackString;
                if (bakcString.Contains("7F")) {

                    this.richTextBox1.Text = bakcString;
                    MessageBox.Show("测试终止");
                    return;
                }
                if (bakcString.Contains("73") && bakcString.Contains("18")
                     && bakcString.Contains("02"))
                {
                    String[] result = bakcString.Split('\r');
                    this.richTextBox1.Text = "测试完成";
                    comCount = 0;
                    MessageBox.Show("测试完成");
                    return;
                }
                readValue();
            }
            catch{
            }

        }

        private void CompressionTest_Load(object sender, EventArgs e)
        {

        }
    }
}
