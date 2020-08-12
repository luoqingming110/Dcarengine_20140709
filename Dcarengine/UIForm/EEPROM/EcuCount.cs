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
    public partial class EcuCount : Form
    {
        public EcuCount()
        {
            InitializeComponent();
        }


        private void EcuCount_Load(object sender, EventArgs e)
        {
            try
            {
                //GobalSerialPort.WriteByMessage(CommonCmd._ecuRevolutions, 0, CommonCmd._ecuRevolutions.Length);
                //String allResult = GobalSerialPort.ResultBackString;
                //String[] result = allResult.Split('\r');
                //this.textBox2.Text = workOut(result[1]).ToString();
                readValue();
            }
            catch {

            }
        }
        /// <summary>
        /// readValue
        /// </summary>
        public void readValue() {

            GobalSerialPort.WriteByMessage(CommonCmd._ecuRevolutions, 0, CommonCmd._ecuRevolutions.Length);
            String allResult = GobalSerialPort.ResultBackString;
            String[] result = allResult.Split('\r');
            this.textBox2.Text = workOut(result[1]).ToString();

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
                if (result.Length == 14)
                {
                    String subResult = result.Substring(6, result.Length-6);
                    finalresult = Convert.ToInt64(StringUtil.Reverse(subResult), 16);
                }
            }
            catch (Exception e)
            { }
            return finalresult;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            EEPROMWrite.is_write = true;
            String writeValue = this.textBox1.Text.Trim();
            int count = Convert.ToInt32(writeValue);
            String all = Convert.ToString(count, 16).PadLeft(8, '0');
            String cmd = "3b0170" + StringUtil.Reverse(all);
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
