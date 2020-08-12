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

namespace Dcarengine.UIForm.EEPROM
{
    public partial class HighCount : Form
    {
        public HighCount()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 02f5值修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            EEPROMWrite.is_write = true;
            String writeValue = this.textBox4.Text.Trim();
            int count = Convert.ToInt32(writeValue);
            String all = Convert.ToString(count, 16).PadLeft(4, '0');
            String cmd = "3b02f5" + StringUtil.Reverse(all);
            byte[] cmdSend = StringToSendBytes.bytesToSend(cmd + "\n");
            GobalSerialPort.WriteByMessage(cmdSend, 0, cmdSend.Length);
            String result = GobalSerialPort.ResultBackString;
            if (result.Contains("7B"))
            {
                this.textBox4.Text = "ok";
                readValue();
            }

        }



        /// <summary>
        /// highCount
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HighCount_Load(object sender, EventArgs e)
        {
            try
            {
                readValue();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 读取所有数据
        /// </summary>
        public void readValue() {

            GobalSerialPort.WriteByMessage(CommonCmd.hiByte, 0, CommonCmd.hiByte.Length);
            String allResult = GobalSerialPort.ResultBackString;
            String[] result = allResult.Split('\r');
            this.textBox2.Text = workOut(result[1]).ToString();

            GobalSerialPort.WriteByMessage(CommonCmd.hiOneByte, 0, CommonCmd.hiOneByte.Length);
            String allResult1 = GobalSerialPort.ResultBackString;
            String[] result1 = allResult1.Split('\r');
            this.textBox3.Text = workOut(result1[1]).ToString();
        }

        /// <summary>
        /// workout
        /// </summary>
        /// <returns></returns>
        public object workOut(String text)
        {
            long finalresult = 0;
            try
            {
                String result = text.Replace(" ", "");
                String subResult = result.Substring(6, result.Length - 6);
                finalresult = Convert.ToInt64(StringUtil.Reverse(subResult), 16);
            }
            catch (Exception)
            { }
            return finalresult;
        }



        /// <summary>
        /// 02f4值修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            EEPROMWrite.is_write = true;
            String writeValue = this.textBox1.Text.Trim();
            int count = Convert.ToInt32(writeValue);
            String all = Convert.ToString(count, 16).PadLeft(4, '0');
            String cmd = "3b02f4" + StringUtil.Reverse(all);
            byte[] cmdSend = StringToSendBytes.bytesToSend(cmd + "\n");
            GobalSerialPort.WriteByMessage(cmdSend, 0, cmdSend.Length);
            String result = GobalSerialPort.ResultBackString;
            if (result.Contains("7B"))
            {
                this.textBox1.Text = "ok";

                readValue();
            }

        }


    }
}
