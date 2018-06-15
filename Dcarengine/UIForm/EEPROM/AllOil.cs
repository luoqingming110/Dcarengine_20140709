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
using Dcarengine.Function_Class;

namespace Dcarengine.UIForm.EEPROM
{
    public partial class AllOil : Form
    {
        public AllOil()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 总油耗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllOil_Load(object sender, EventArgs e)
        {
            if (EcuConnectionF.ECULINKStatus==false) {

                return;
            }
            try
            {
                readValue();
            }
            catch (Exception ) {

               Console.WriteLine ("this is the message");
               
            }

        }


        public void readValue()
        {

            GobalSerialPort.WriteByMessage(CommonCmd._allOilCost, 0, CommonCmd._allOilCost.Length);

            String allResult = GobalSerialPort.ResultBackString;
            //
            String[] result = allResult.Split('\r');

            allResult = result[1];

            this.textBox2.Text = workOut(allResult).ToString();

        }


        /// <summary>
        /// workout
        /// </summary>
        /// <returns></returns>
        public object workOut(String  text) {

            long finalresult = 0;
            try
            {
                String result = text.Replace(" ","");
                if (result.Length ==14) {

                    String subResult = result.Substring(6,result.Length-6);
                    finalresult = Convert.ToInt64(StringUtil.Reverse(subResult),16);
                }
            }
            catch (Exception e)
            { }
            //数据值/2
            return finalresult / 2;
        }



        /// <summary>
        /// gebpublish
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public String Getpublish(String result) {


            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            String writeValue = this.textBox1.Text.Trim();
            int count = Convert.ToInt32(writeValue) * 2 ;
            String all = Convert.ToString(count, 16).PadLeft(8,'0');
            String cmd = "3b0171" + StringUtil.Reverse(all);
            byte[] cmdSend = StringToSendBytes.bytesToSend(cmd + "\n");
            GobalSerialPort.WriteByMessage(cmdSend,0,cmdSend.Length);
            String result = GobalSerialPort.ResultBackString;
            if (result.Contains("7B")) {
                
                this.textBox1.Text = "ok";
                readValue();
            }
        }

    }
}
