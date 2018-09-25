﻿using Dcarengine.Function_Class;
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
    public partial class Speed : MaterialForm
    {

        private static String address = "0238B2";
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
            if (EcuConnectionF.ECULINKStatus == false)
            {

                return;
            }

        }

        private void ami_Button_21_Click(object sender, EventArgs e)
        {
            if (EcuConnectionF.ECULINKStatus == false)
            {
                return;
            }

            String value = EolFunction.readFunction(address, length, CommonCmd._808001);
            //初始化数据
            try
            {
                String[] valueList = value.Split('\r');
                //finalValue              
                String finalValue = valueList[1].Replace(" ","");
                int  status = StringUtil.hexTo10(finalValue) * 100;
                this.emi_RichTextBox1.Text = status.ToString();             
                resultValue = finalValue;              
            }
            catch (Exception)
            {
            }
        }

       


        /// <summary>
        /// 写数据
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
                String text = this.emi_RichTextBox2.Text;
                if (StringUtil.IsStringEmpty(text))
                {
                    return;
                }
                int value = Int32.Parse(text)/100;
                // String sta = resultValue.Substring(1, 1);
                // MessageBox.Show(text);
                //String staprefix = status.Substring(0, 3 - 0);
                //String stasuffix = status.Substring(3 + 1, length - 4);
                //String stafinal = "";
                //final
                EolFunction.writeFunction(address, length, StringUtil._10ToHex(value), CommonCmd._808101);
            }
            catch (Exception) {
            }
        }


    }
}
