using Dcarengine.Function_Class;
using Dcarengine.refactor;
using EASkins.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dcarengine.UIForm.eol790
{
    public partial class Speed : EASkins.Controls.MaterialForm
    {
        private static String address = "028D6E";
        private static Int32 length = 2;

        private static String NOTACTIVE = "未激活";
        private static String ACTIVE = "激活";
        private static String resultValue;
        private static String resultText;

        public Speed()
        {
            InitializeComponent();
        }

        private void Speed_Load(object sender, EventArgs e)
        {

        }

        private void ami_Button_21_Click(object sender, EventArgs e)
        {
            if (EcuConnectionF.ECULINKStatus == false)
            {
                return;
            }

            read();
        }

        public void read() {

            String value = EolFunction.readFunction(address, length, CommonCmd._808002);
            //初始化数据
            try
            {
                String[] valueList = value.Split('\r');
                //finalValue              
                String finalValue = valueList[1].Replace(" ", "");
                String finalValueOne = finalValue.Substring(0, 2);
                String finalValueTwo = finalValue.Substring(2, 2);
                finalValue = finalValueTwo + finalValueOne;
                int status = StringUtil.hexTo10(finalValue) / 100;
                this.emi_RichTextBox1.Text = status.ToString();
                resultValue = finalValue;
            }
            catch (Exception)
            {
            }

        }



        private void ami_Button_22_Click(object sender, EventArgs e)
        {
            if (EcuConnectionF.ECULINKStatus == false)
            {
                return;
            }

            try
            {
                String text = this.emi_RichTextBox2.Text;
                if (StringUtil.IsStringEmpty(text))
                {
                    return;
                }
                int value = Int32.Parse(text) * 100;
                String speed = StringUtil._10ToHex(value).PadLeft(4,'0');
                if (speed.Length > 4) {

                    return;
                }
                String finalValueOne = speed.Substring(0, 2);
                String finalValueTwo = speed.Substring(2, 2);
                speed = finalValueTwo + finalValueOne;

                EolFunction.writeF_8081count(CommonCmd._808102);

                EolFunction.writeFunction(address, length, speed, CommonCmd._808102);


                String testValue = "LZFF0000000000002";
                if (StringUtil.IsStringEmpty(testValue) && testValue.Length != 17)
                {
                    return;
                }
                String asciiToWrite = StringUtil.AsciiToHexString(testValue.Trim());
                EolFunction.writeFunction("029162", 17, asciiToWrite, CommonCmd._808103);


                EolFunction.writeF_3180(CommonCmd._3180);

                EolFunction.writeF_3380_ByTime(CommonCmd._3380);

                // read();
                this.materialLabel2.Text = CommonConstant.EolWrireEndText;


            }
            catch (Exception)
            {
            }
        }


    }
}
