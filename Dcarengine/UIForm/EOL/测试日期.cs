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

namespace Dcarengine.UIForm.EOL
{
    public partial class 测试日期 : MaterialForm
    {

        private static String address = "04E35F";
        private static Int32 length = 3;
        private static String NOTACTIVE = "未激活";
        private static String ACTIVE = "激活";
        private static String resultValue;
        private static String resultText;


        public 测试日期()
        {
            InitializeComponent();
        }

        private void 测试日期_Load(object sender, EventArgs e)
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

            String value = EolFunction.readFunction(address, length, CommonCmd._808000);
            //初始化数据
            try
            {
                String[] valueList = value.Split('\r');
                //finalValue              
                String finalValue = valueList[1].Replace(" ", "");
                this.emi_RichTextBox1.Text = finalValue;
                //resultValue = finalValue;
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
                //int value = Int32.Parse(text) / 100;
                // String sta = resultValue.Substring(1, 1);
                // MessageBox.Show(text);
                //String staprefix = status.Substring(0, 3 - 0);
                //String stasuffix = status.Substring(3 + 1, length - 4);
                //String stafinal = "";
                //final
                EolFunction.writeFunction(address, length, text.PadLeft(6,'0'), CommonCmd._808100);
                read();
                this.materialLabel2.Text = CommonConstant.EolWrireEndText;


            }
            catch (Exception)
            {
            }
        }


    }
}
