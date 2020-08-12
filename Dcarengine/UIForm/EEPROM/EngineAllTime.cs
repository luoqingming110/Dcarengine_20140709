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
    public partial class EngineAllTime : Form
    {
        public EngineAllTime()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 发动机总运行时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EngineAllTime_Load(object sender, EventArgs e)
        {
            try
            {
                Read();
            }
            catch {

                
            }
        }

        /// <summary>
        /// 读取数据类型
        /// </summary>
        public  void Read() {

            GobalSerialPort.WriteByMessage(CommonCmd._allEngineTime, 0, CommonCmd._allEngineTime.Length);
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
                String subResult = result.Substring(6, result.Length-6);
                finalresult = Convert.ToInt64(StringUtil.Reverse(subResult), 16);
            }
            catch (Exception e)
            { }
            return finalresult;
        }


        /// <summary>
        /// 16个字节长度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            EEPROMWrite.is_write = true;
            String writeValue = this.textBox1.Text.Trim();
            int count = Convert.ToInt32(writeValue);
            String all = Convert.ToString(count, 16).PadLeft(32, '0');
            String cmd = "3b016E" + StringUtil.Reverse(all);
            byte[] cmdSend = StringToSendBytes.bytesToSend(cmd + "\n");
            GobalSerialPort.WriteByMessage(cmdSend, 0, cmdSend.Length);
            String result = GobalSerialPort.ResultBackString;
            if (result.Contains("7B"))
            {
                this.textBox1.Text = "ok";
                Read();
            }

        }

    }
}
