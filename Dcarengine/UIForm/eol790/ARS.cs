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
    public partial class ARS : MaterialForm
    {
        private static String address = "024F80";
        private static Int32 length = 4;
        private static String NOTACTIVE = "未激活";
        private static String ACTIVE = "激活";
        private static String resultValue;
        private static String resultText;

        public ARS()
        {
            InitializeComponent();
        }

        private void ARS790_Load(object sender, EventArgs e)
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
                //高低位
                String finalValueOne = finalValue.Substring(0, 2);
                String finalValueTwo = finalValue.Substring(2, 2);
                String finalValueThree = finalValue.Substring(4, 2);
                String finalValueFour = finalValue.Substring(6, 2);
                finalValue = finalValueFour + finalValueThree + finalValueTwo + finalValueOne;

                String status = StringUtil.hexTo2(finalValue);
                resultValue = finalValue;
                if (StringUtil.IsStringEmpty(status))
                {

                    this.emi_RichTextBox1.Text = "读取失败";
                    return;
                }
                String sta = status.Substring(31, 1);
                if (sta.Equals("0"))
                {
                    this.emi_RichTextBox1.Text = "未激活";
                }
                else
                {
                    this.emi_RichTextBox1.Text = "激活";
                }
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
                String text = this.ami_ComboBox1.Text;
                String status = StringUtil.hexTo2(resultValue);
                // String sta = resultValue.Substring(1, 1);
                //MessageBox.Show(text);
                String staprefix = status.Substring(0, 31);
                String stasuffix = status.Substring(0, 31);
                String stafinal = "";

                if (text.Equals(NOTACTIVE))
                {
                    // resultValue =  ;
                    stafinal =  stasuffix + "0";
                }
                else if (text.Equals(ACTIVE))
                {
                    stafinal =  stasuffix + "1";
                }
                stafinal = StringUtil._2ToHex(stafinal).PadLeft(8, '0');
                //高低位
                String finalValueOne = stafinal.Substring(0, 2);
                String finalValueTwo = stafinal.Substring(2, 2);
                String finalValueThree = stafinal.Substring(4, 2);
                String finalValueFour = stafinal.Substring(6, 2);
                stafinal = finalValueFour + finalValueThree + finalValueTwo + finalValueOne;
                //final
                EolFunction.writeFunction(address, length, stafinal, CommonCmd._808102);
                read();
                this.materialLabel2.Text = CommonConstant.EolWrireEndText;


            }
            catch (Exception) { }



        }


    }
}
