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

namespace Dcarengine.UIForm.eol790s
{
    public partial class VIN790 : EASkins.Controls.MaterialForm
    {
        private static String address = "029162";
        private static Int32 length = 17;

        private static String NOTACTIVE = "未激活";
        private static String ACTIVE = "激活";
        private static String resultValue;
        private static String resultText;


        public VIN790()
        {
            InitializeComponent();
        }

        private void VIN790_Load(object sender, EventArgs e)
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


        /**
         * read
         */
        public void read()
        {
            String value = EolFunction.readFunction(address, length, CommonCmd._808003);
            //初始化数据
            try
            {
                String[] valueList = value.Split('\r');
                //finalValue              
                String finalValue = valueList[1].Replace(" ", "");
                String status = StringUtil.StringToASCII(finalValue);
                this.emi_RichTextBox1.Text = status;
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
                if (StringUtil.IsStringEmpty(text) && text.Length != 17)
                {
                    return;
                }
                String asciiToWrite = StringUtil.AsciiToHexString(text.Trim());
                EolFunction.writeFunction(address, length, asciiToWrite, CommonCmd._808103);
               // read();
                this.materialLabel2.Text = CommonConstant.EolWrireEndText;
            }
            catch (Exception)
            {
            }
        }


        private void emi_Button_11_Click(object sender, EventArgs e)
        {
            String text = this.emi_RichTextBox2.Text;
            if (StringUtil.IsStringEmpty(text) && text.Length != 17)
            {
                return;
            }

        }



    }
}