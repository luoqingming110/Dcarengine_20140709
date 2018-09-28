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
    public partial class ABS : MaterialForm
    {

        private static String address = "0211C0";
        private static Int32  length = 4;

   
        private static String NOTACTIVE = "未激活";
        private static String ACTIVE = "激活";
        private static String resultValue; 
        private static String resultText; 

        public ABS()
        {

            InitializeComponent();
            Console.WriteLine(EcuVersionF.EcuVsion);
          
        }


        /// <summary>
        /// main Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ABS_Load(object sender, EventArgs e)
        {
            if (EcuConnectionF.ECULINKStatus == false)
            {
                return;
            }
            read();
        }

        private void ami_Button_21_Click(object sender, EventArgs e)
        {
            read();
        }

        /// <summary>
        /// read 函数封装
        /// </summary>
        public void read() {

            String value = EolFunction.readFunction(address, length, CommonCmd._808001);
            //初始化数据
            try
            {
                String[] valueList = value.Split('\r');
                //finalValue
                String finalValue = valueList[1];
                String status = StringUtil.hexTo2(finalValue);
                resultValue = finalValue;
                if (StringUtil.IsStringEmpty(status))
                {

                    this.emi_RichTextBox1.Text = "读取失败";
                    return;
                }
                String sta = status.Substring(1, 1);
                if (sta.Equals("0"))
                {
                    this.emi_RichTextBox1.Text = "激活";
                }
                else
                {
                    this.emi_RichTextBox1.Text = "未激活";
                }
            }
            catch (Exception)
            {
            }
        }


        /// <summary>
        /// 修改数据状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ami_Button_22_Click(object sender, EventArgs e)
        {
            if (EcuConnectionF.ECULINKStatus == false)
            {
                return;
            }

            try
            {
                String text = this.ami_ComboBox1.Text.Trim();
                String status = StringUtil.hexTo2(resultValue);
                // String sta = resultValue.Substring(1, 1);
                //MessageBox.Show(text);
                String staprefix = status.Substring(0, 1 - 0);
                String stasuffix = status.Substring(1 + 1, status.Length - 2);
                String stafinal = "";

                if (text.Equals(NOTACTIVE))
                {
                    // resultValue =  ;
                    stafinal = staprefix + "0" + stasuffix;

                }
                else if (text.Equals(ACTIVE))
                {

                    stafinal = staprefix + "1" + stasuffix;
                }
                stafinal = StringUtil._2ToHex(stafinal).PadLeft(8,'0');
                //final
                EolFunction.writeFunction(address, length, stafinal, CommonCmd._808101);

                read();

                this.materialLabel2.Text = CommonConstant.EolWrireEndText; 

            }
            catch (Exception) {
            }
        }


    }
}
