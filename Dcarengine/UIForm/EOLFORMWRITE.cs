using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Dcarengine.Function_Class;
using Dcarengine.UIForm.EOL;
using Dcarengine.refactor;
using Dcarengine.serialPort;

namespace Dcarengine.UIForm
{
    public partial class EOLFORMWRITE : Form
    {


        public EOLFORMWRITE()
        {
            InitializeComponent();
            if (!CommonConstant.is90Mode)
            {


                this.emi_Button_21.Text = "进入模式";
            }
            else {

                this.emi_Button_21.Text = "退出模式";

            }

        }



        private void EOLFORMWRITE_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {

           // EolFunction.writeFunction(null,10,"10");
            
         

        }

        private void button2_Click(object sender, EventArgs e)
        {

          //  EolFunction.readFunction(null, 10);


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();      
            Form1 allTrip = new Form1();
            allTrip.TopLevel = false;
            //allTrip.FormBorderStyle = FormBorderStyle.None;
            allTrip.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(allTrip); //add the fs form to the panel2
            allTrip.Dock = DockStyle.Fill;
            allTrip.Show();    
        }

        private void ami_Button_21_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            ARS allTrip = new ARS();
            allTrip.TopLevel = false;
            allTrip.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(allTrip); //add the fs form to the panel2
            allTrip.Dock = DockStyle.Fill;
            allTrip.Show();

        }



        /// <summary>
        /// retarder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ami_Button_23_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            Retarder allTrip = new Retarder();
            allTrip.TopLevel = false;
            allTrip.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(allTrip); //add the fs form to the panel2
            allTrip.Dock = DockStyle.Fill;
            allTrip.Show();

        }

        private void ami_Button_22_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            ABS allTrip = new ABS();
            allTrip.TopLevel = false;
            allTrip.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(allTrip); //add the fs form to the panel2
            allTrip.Dock = DockStyle.Fill;
            allTrip.Show();
        }


        /// <summary>
        /// GPS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ami_Button_28_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            GPS allTrip = new GPS();
            allTrip.TopLevel = false;
            allTrip.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(allTrip); //add the fs form to the panel2
            allTrip.Dock = DockStyle.Fill;
            allTrip.Show();
        }

        private void ami_Button_24_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            Speed allTrip = new Speed();
            allTrip.TopLevel = false;
            allTrip.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(allTrip); //add the fs form to the panel2
            allTrip.Dock = DockStyle.Fill;
            allTrip.Show();
        }

        /// <summary>
        /// 测试工具序列号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ami_Button_25_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            序列号 allTrip = new 序列号();
            allTrip.TopLevel = false;
            allTrip.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(allTrip); //add the fs form to the panel2
            allTrip.Dock = DockStyle.Fill;
            allTrip.Show();

        }

        /// <summary>
        /// 配置日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ami_Button_26_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            配置日期 allTrip = new 配置日期();
            allTrip.TopLevel = false;
            allTrip.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(allTrip); //add the fs form to the panel2
            allTrip.Dock = DockStyle.Fill;
            allTrip.Show();

        }

        /// <summary>
        /// 测试日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ami_Button_27_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            测试日期 allTrip = new 测试日期();
            allTrip.TopLevel = false;
            allTrip.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(allTrip); //add the fs form to the panel2
            allTrip.Dock = DockStyle.Fill;
            allTrip.Show();

        }

        private void emi_Button_21_Click(object sender, EventArgs e)
        {
            if (EcuConnectionF.ECULINKStatus == false)
            {
                return;
            }
            //
            if (!CommonConstant.is90Mode)
            {
                CommonConstant.mode = "1090";
                Tp_KeyMethodFuntion.Con();
                GobalSerialPort.WriteByMessage(CommonCmd._1090, 0, CommonCmd._1090.Length);
                String backString = GobalSerialPort.ResultBackString;
                this.emi_Button_21.Text = "退出";
                CommonConstant.is90Mode = true;
            }
            else {

                GobalSerialPort.WriteByMessage(CommonCmd._1101, 0, CommonCmd._1101.Length);
                EcuConnectionF.ECULINKStatus = false;
                this.emi_Button_21.Text = "进入模式";
                CommonConstant.is90Mode = false;
            }


        }

        private void ami_Button_29_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            VIN allTrip = new VIN();
            allTrip.TopLevel = false;
            allTrip.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(allTrip); //add the fs form to the panel2
            allTrip.Dock = DockStyle.Fill;
            allTrip.Show();
        }
    }
}
