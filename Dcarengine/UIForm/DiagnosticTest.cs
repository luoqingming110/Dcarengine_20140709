using Dcarengine.Function_Class;
using Dcarengine.refactor;
using Dcarengine.serialPort;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dcarengine.UIForm.enginetest;
using CCWin;

namespace Dcarengine.UIForm
{
    public partial class DiagnosticTest : CCSkinMain
    {

        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public DiagnosticTest()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            EngineBreake engineBreake = new EngineBreake();
            engineBreake.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RunupTest runupTest = new RunupTest();
            runupTest.Show();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            HighPressureTest highPressureTest = new HighPressureTest();
            highPressureTest.Show();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            CompressionTest compressionTest = new CompressionTest();
            compressionTest.Show();
        }


        /// <summary>
        /// 
        /// load 初始化86模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiagnosticTest_Load(object sender, EventArgs e)
        {
            if (EcuConnectionF.ECULINKStatus == true)
            {
                try
                {
                    //mode
                    log.Info("engine test  1086  mode" + " ");
                    CommonConstant.mode = "1086";
                    Tp_KeyMethodFuntion.Con();
                    GobalSerialPort.WriteByMessage(CommonCmd._1086, 0, CommonCmd._1086.Length);
                    String backString = GobalSerialPort.ResultBackString;
                    if (!backString.Contains("86"))
                    {
                        GobalSerialPort.WriteByMessage(CommonCmd._1086, 0, CommonCmd._1086.Length);
                        backString = GobalSerialPort.ResultBackString;
                    }
                    else
                    {
                        GobalSerialPort.WriteByMessage(CommonCmd.ATST00, 0, CommonCmd.ATST00.Length);
                    }
                }
                catch
                {
                }
            }
            else
            {

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DiagnosticSpeed diagnosticSpeed = new DiagnosticSpeed();
            diagnosticSpeed.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {

            CylinderShut cylinderShut = new CylinderShut();
            cylinderShut.Show();
        
        }
    }
}
