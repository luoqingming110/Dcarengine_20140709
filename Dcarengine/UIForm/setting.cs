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

    public delegate void settingBack(int ars, int retarde, int vin, int speed);

    public partial class setting : Form
    {
        public setting()
        {
            InitializeComponent();
        }

      
        public settingBack SettingBack;


        private void setting_Load(object sender, EventArgs e)
        {

        }

        //退出按键
        private void Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定选择?", "提示:", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            int arsValue = 0;
            int retarder = 0;
            int vin = 0;
            int speed = 0;
        

            if (dr == DialogResult.OK)   //如果单击“是”按钮
            {
                e.Cancel = false;                 //关闭窗体

                if (this.arsBox.Checked) {
                   arsValue = 1;
                }

                if (this.retarderBox.Checked)
                {
                    retarder = 1;

                }

                if (this.speedBox.Checked)
                {
                    speed = 1;
                }

                if (this.vinBox.Checked)
                {
                    vin = 1;

                }
              //  if (SettingBack != null) {

                    SettingBack(arsValue,retarder,vin,speed);
               // }

            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;                  //不执行操作
            }
        }



    }
}
