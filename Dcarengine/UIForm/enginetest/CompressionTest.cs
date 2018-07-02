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

namespace Dcarengine.UIForm.enginetest
{
    public partial class CompressionTest : Form
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

            WriteVale();
            readValue();

        }


        public static int comCount = 0;

        /// <summary>
        /// 写数据
        /// </summary>
        public void WriteVale() {

            try
            {
                comCount++;
                GobalSerialPort.WriteByMessage(CommonCmd._CompressionTest, 0, CommonCmd._CompressionTest.Length);
                String backString = GobalSerialPort.ResultBackString;
                if (comCount > 10)
                {
                    this.richTextBox1.Text = "测试失败 请重试";
                    return;
                }
                if (!backString.Contains("71") && !backString.Contains("18"))
                {
                    WriteVale();
                }
            }
            catch {}
        }


        /// <summary>
        /// 3318数据返回
        /// </summary>
        public void readValue() {

            try
            {
                GobalSerialPort.WriteByMessage(CommonCmd._3318, 0, CommonCmd._3318.Length);
                String bakcString = GobalSerialPort.ResultBackString;
                if (bakcString.Contains("73") && bakcString.Contains("18")
                     && bakcString.Contains("02"))
                {
                    String[] result = bakcString.Split('\r');
                    this.richTextBox1.Text = result[1];
                    return;
                }
                readValue();
            }
            catch{
            }

        }



    }
}
