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
    public partial class HighPressureTest : Form
    {
        public HighPressureTest()
        {
            InitializeComponent();
        }

        private void FE_Click(object sender, EventArgs e)
        {

            WriteVale();
            readValue();

        }


        public static int comCount = 0;
        /// <summary>
        /// 写数据
        /// </summary>
        public void WriteVale()
        {

            try
            {
                comCount++;
                GobalSerialPort.WriteByMessage(CommonCmd._HighPressureTest, 0, CommonCmd._HighPressureTest.Length);
                String backString = GobalSerialPort.ResultBackString;
                if (comCount > 10)
                {
                    this.richTextBox1.Text = "测试失败 请重试";
                    return;
                }
                if (!backString.Contains("71") && !backString.Contains("14"))
                {
                    WriteVale();
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
                GobalSerialPort.WriteByMessage(CommonCmd._3314, 0, CommonCmd._3314.Length);
                String bakcString = GobalSerialPort.ResultBackString;
                if (bakcString.Contains("73") && bakcString.Contains("14")
                     && bakcString.Contains("02"))
                {
                    String[] result = bakcString.Split('\r');
                    this.richTextBox1.Text = result[1];
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
