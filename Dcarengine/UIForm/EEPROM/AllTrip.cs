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

namespace Dcarengine.UIForm.EEPROM
{
    public partial class AllTrip : Form
    {
        public AllTrip()
        {
            InitializeComponent();
        }

        private void 总里程_Load(object sender, EventArgs e)
        {
            try
            {
                read();
            }
            catch (Exception ) {

            }
        }

        /// <summary>
        /// read
        /// </summary>
        public void read() {

            GobalSerialPort.WriteByMessage(CommonCmd._allTrip, 0, CommonCmd._allTrip.Length);
            String allResult = GobalSerialPort.ResultBackString;
            String[] result = allResult.Split('\r');
            this.textBox2.Text = workOut(result[1]).ToString();

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

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


        private void button1_Click(object sender, EventArgs e)
        {
            
            String writeValue = this.textBox1.Text.Trim();
            int count = Convert.ToInt32(writeValue);
            String all = Convert.ToString(count, 16).PadLeft(8, '0');
            String cmd = "3b016D" + StringUtil.Reverse(all);
            byte[] cmdSend = StringToSendBytes.bytesToSend(cmd + "\n");
            GobalSerialPort.WriteByMessage(cmdSend, 0, cmdSend.Length);
            String result = GobalSerialPort.ResultBackString;
            if (result.Contains("7B"))
            {
                this.textBox1.Text = "ok";
                read();
            }

        }
    }
}
