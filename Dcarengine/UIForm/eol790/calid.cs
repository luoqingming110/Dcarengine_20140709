using Dcarengine.Function_Class;
using Dcarengine.refactor;
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
    public partial class calid : EASkins.Controls.MaterialForm
    {

        private static String address = "028D2A";
        private static Int32 length = 30;
        private static String resultValue;

        public calid()
        {
            InitializeComponent();
        }

        private void ami_Button_21_Click(object sender, EventArgs e)
        {

            read();
        }



        public void read()
        {

            String value = EolFunction.readFunction(address, length, CommonCmd._808002);
            //初始化数据
            try
            {
                String[] valueList = value.Split('\r');
                //finalValue              
                String finalValue = valueList[1].Replace(" ", "");
                String status = StringUtil.StringToASCII(finalValue);
                this.emi_RichTextBox1.Text = status;
               
            }
            catch (Exception)
            {
            }
        }



    }
}
