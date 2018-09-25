using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Dcarengine.Function_Class;
using Dcarengine.refactor;
using Dcarengine.serialPort;

namespace Dcarengine.UIForm.EOL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (EcuConnectionF.ECULINKStatus == false)
            {
                return;
            }
          // CommonConstant.mode = "1092";
           //Tp_KeyMethodFuntion.Con();


        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (EcuConnectionF.ECULINKStatus == false)
            {
                return;
            }
            // address
            String address = this.textBox2.Text.TrimEnd() ;
            // 地址收场
            if (address == null) {
                address = "35 02 91 62 00 00 00 11";
            }
            String backValue = EolFunction.readFunction(address,10,CommonCmd._808002);
            this.textBox3.Text = backValue;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (EcuConnectionF.ECULINKStatus == false)
            {
                return;
            }
            // address
            String address = this.textBox5.Text.TrimEnd();
            String value  =  this.textBox1.Text.TrimEnd();

            // 地址收场
            if (address == null)
            {
                address = "34024E9E00000002";
                value = "361122";
            }
           String ok =   EolFunction.writeFunction(address, 10,value,CommonCmd._808102);
           this.textBox4.Text = ok;




        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (EcuConnectionF.ECULINKStatus == false)
            {
                return;
            }
            GobalSerialPort.WriteByMessage(CommonCmd._3180, 0, CommonCmd._3180.Length);
            GobalSerialPort.WriteByMessage(CommonCmd._3380, 0, CommonCmd._3380.Length);
            //数据复位
            GobalSerialPort.WriteByMessage(CommonCmd._1101, 0, CommonCmd._1101.Length);

            this.Close();

        }
    }
}
