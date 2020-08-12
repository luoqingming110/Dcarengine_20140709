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
    public partial class TripRecord : Form
    {


        public TripRecord()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 清0 数据
        /// </summary>
        /// <returns></returns>
        public String preWriteValue(int  length) {

            String backValue = "";
            for (int i = 0; i < length; i++)
            {
                backValue += "00";
            }
            return backValue;
        }


        /// <summary>
        /// 0165
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            EEPROMWrite.is_write = true;
            String _0165  =  preWriteValue(60);
            String cmd165 = "3b0165" + _0165;
            byte[] cmdSend165 = StringToSendBytes.bytesToSend(cmd165 + "\n");
            GobalSerialPort.WriteByMessage(cmdSend165, 0, cmdSend165.Length);
            String result = GobalSerialPort.ResultBackString;


            String _0166 = preWriteValue(40);
            String cmd166 = "3b0166" + _0166;
            byte[] cmdSend166 = StringToSendBytes.bytesToSend(cmd166 + "\n");
            GobalSerialPort.WriteByMessage(cmdSend166, 0, cmdSend166.Length);
            String result166 = GobalSerialPort.ResultBackString;

            String _0167 = preWriteValue(96);
            String cmd167 = "3b0167" + _0167;
            byte[] cmdSend167 = StringToSendBytes.bytesToSend(cmd167 + "\n");
            GobalSerialPort.WriteByMessage(cmdSend167, 0, cmdSend167.Length);
            String result167 = GobalSerialPort.ResultBackString;

            String _0168 = preWriteValue(144);
            String cmd168 = "3b0168" + _0168;
            byte[] cmdSend168 = StringToSendBytes.bytesToSend(cmd168 + "\n");
            GobalSerialPort.WriteByMessage(cmdSend168, 0, cmdSend168.Length);
            String result168 = GobalSerialPort.ResultBackString;

            String _0169 = preWriteValue(144);
            String cmd169 = "3b0169" + _0169;
            byte[] cmdSend169 = StringToSendBytes.bytesToSend(cmd169 + "\n");
            GobalSerialPort.WriteByMessage(cmdSend169, 0, cmdSend169.Length);
            String result169 = GobalSerialPort.ResultBackString;

            String _016c = preWriteValue(40);
            String cmd16c = "3b016c" + _0169;
            byte[] cmdSend16c = StringToSendBytes.bytesToSend(cmd16c + "\n");
            GobalSerialPort.WriteByMessage(cmdSend16c, 0, cmdSend16c.Length);
            String result16c = GobalSerialPort.ResultBackString;

            if (result.Contains("7B"))
            {
                // this.textBox1.Text = "ok";
            }
        }

        /// <summary>
        /// 0166
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {}

        /// <summary>
        /// 0167
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {}

        /// <summary>
        /// 168
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {}

        /// <summary>
        /// 16c
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {}

        /// <summary>
        /// 169
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {}

        /// <summary>
        /// load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TripRecord_Load(object sender, EventArgs e)
        {
            try
            {
                ////165
                GobalSerialPort.WriteByMessage(CommonCmd.trip165, 0, CommonCmd.trip165.Length);
                String allResult = GobalSerialPort.ResultBackString;
                String[] result = allResult.Split('\r');
                textBox2.Text = result[1];

                ////166
                GobalSerialPort.WriteByMessage(CommonCmd.trip166, 0, CommonCmd.trip166.Length);
                String allResult1 = GobalSerialPort.ResultBackString;
                String[] result1 = allResult1.Split('\r');
                textBox3.Text = result1[1];

                ////167
                GobalSerialPort.WriteByMessage(CommonCmd.trip167, 0, CommonCmd.trip167.Length);
                String allResult167 = GobalSerialPort.ResultBackString;
                String[] result167 = allResult1.Split('\r');
                this.textBox5.Text = result1[1];

                ///168
                GobalSerialPort.WriteByMessage(CommonCmd.trip168, 0, CommonCmd.trip168.Length);
                String allResult168 = GobalSerialPort.ResultBackString;
                String[] result168 = allResult1.Split('\r');
                this.textBox7.Text = result1[1];

                //169
                GobalSerialPort.WriteByMessage(CommonCmd.trip169, 0, CommonCmd.trip169.Length);
                String allResult169 = GobalSerialPort.ResultBackString;
                String[] result169 = allResult1.Split('\r');
                this.textBox9.Text = result1[1];

                //16c
                GobalSerialPort.WriteByMessage(CommonCmd.trip16c, 0, CommonCmd.trip16c.Length);
                String allResult16c = GobalSerialPort.ResultBackString;
                String[] result16c = allResult1.Split('\r');
                this.textBox11.Text = result1[1];
            }
            catch (Exception ) {
            }

        }
    }
}
