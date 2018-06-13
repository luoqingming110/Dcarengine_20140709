using CCWin;
using Dcarengine.Function_Class;
using Dcarengine.refactor;
using Dcarengine.serialPort;
using Dcarengine.UIForm.EEPROM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dcarengine.UIForm
{
    public partial class EEPROMWrite : Form
    {

        // private 

        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public EEPROMWrite()
        {

            InitializeComponent();
            this.IsMdiContainer = true;
            if (EcuConnectionF.ECULINKStatus == true)
            {
                try
                {
                    //mode
                    log.Info("ECUMODE  1086 " + " ");
                    CommonConstant.mode = "1086";
                    Tp_KeyMethodFuntion.Con();
                    GobalSerialPort.WriteByMessage(CommonCmd._1086, 0, CommonCmd._1086.Length);
                    String backString = GobalSerialPort.ResultBackString;
                    if (!backString.Contains("86"))
                    {
                        GobalSerialPort.WriteByMessage(CommonCmd._1086, 0, CommonCmd._1086.Length);
                        backString = GobalSerialPort.ResultBackString;
                    }
                    else {

                        GobalSerialPort.WriteByMessage(CommonCmd.ATST00,0,CommonCmd.ATST00.Length);

                    }
                }
                catch {
                }

            }
            else {

            }
        }


        /// <summary>
        /// EolWrite_Laod
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EolWrite_Load(object sender, EventArgs e)
        {


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 总油耗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {  
            
            splitContainer1.Panel2.Controls.Clear();
            AllOil allTrip = new AllOil();
            allTrip.TopLevel = false;
            //allTrip.FormBorderStyle = FormBorderStyle.None;
            allTrip.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(allTrip); //add the fs form to the panel2
            allTrip.Dock = DockStyle.Fill;
            allTrip.Show();

        }

        /// <summary>
        /// 总里程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            splitContainer1.Panel2.Controls.Clear();
            AllTrip allTrip = new AllTrip();

            allTrip.TopLevel = false;

           // allTrip.FormBorderStyle = FormBorderStyle.None;
           //  allTrip.Parent = this.splitContainer1.Panel2;

            this.splitContainer1.Panel2.Controls.Add(allTrip); //add the fs form to the panel2

            allTrip.Dock = DockStyle.Fill;

            allTrip.Show();


        }


        /// <summary>
        /// 发动机总时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {

            splitContainer1.Panel2.Controls.Clear();
            EngineAllTime allTrip = new EngineAllTime();

            allTrip.TopLevel = false;

            // allTrip.FormBorderStyle = FormBorderStyle.None;
            //  allTrip.Parent = this.splitContainer1.Panel2;

            this.splitContainer1.Panel2.Controls.Add(allTrip); //add the fs form to the panel2

            allTrip.Dock = DockStyle.Fill;

            allTrip.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {


            splitContainer1.Panel2.Controls.Clear();
            EcuTime allTrip = new EcuTime();
            allTrip.TopLevel = false;
            // allTrip.FormBorderStyle = FormBorderStyle.None;
            //  allTrip.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(allTrip); //add the fs form to the panel2

            allTrip.Dock = DockStyle.Fill;
            allTrip.Show();
        }

        /// <summary>
        /// 发动机总转数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            EcuCount allTrip = new EcuCount();
            allTrip.TopLevel = false;
            // allTrip.FormBorderStyle = FormBorderStyle.None;
            //  allTrip.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(allTrip); //add the fs form to the panel2
            allTrip.Dock = DockStyle.Fill;
            allTrip.Show();
        }

        /// <summary>
        /// 行驶记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            TripRecord allTrip = new TripRecord();
            allTrip.TopLevel = false;
            // allTrip.FormBorderStyle = FormBorderStyle.None;
            //  allTrip.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(allTrip); //add the fs form to the panel2
            allTrip.Dock = DockStyle.Fill;
            allTrip.Show();
        }



        /// <summary>
        /// 高压轨泄压阀 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {

            splitContainer1.Panel2.Controls.Clear();
            HighCount allTrip = new HighCount();
            allTrip.TopLevel = false;
            // allTrip.FormBorderStyle = FormBorderStyle.None;
            //  allTrip.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(allTrip); //add the fs form to the panel2
            allTrip.Dock = DockStyle.Fill;
            allTrip.Show();

        }



    }
}
