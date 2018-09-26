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
using Dcarengine.UIForm.eol790;

namespace Dcarengine.UIForm
{
    public partial class EOLFORMWRITE790 : Form
    {
        public EOLFORMWRITE790()
        {
            InitializeComponent();
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




    }
}
