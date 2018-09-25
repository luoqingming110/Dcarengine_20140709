using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO.Ports;
using Dcarengine.Function_Class;
using Dcarengine.AcessData;
using Dcarengine.SQLData;
using System.Threading;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Design;
using DevExpress.Printing;
using DevExpress.XtraPrinting;
using Dcarengine.serialPort;
using Newtonsoft.Json;
using Dcarengine.refactor;
using Dcarengine.service;
using CCWin;
using Dcarengine.UIForm.EOL;

namespace Dcarengine.UIForm
{
    public partial class MainF : CCSkinMain
    {

        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 声明委托，多线程更新UI控件
        /// </summary>
        /// <param name="l"></param>
        /// <param name="s"></param>
        public  delegate void  MaifTextEdit(string  MainfShow);
        public  static   event MaifTextEdit maifTextEdit;

        public MainF()
        {
            InitializeComponent();
            connectecu = new EcuConnectionF();
            //init event
            MaifTextEdit maifText = new MaifTextEdit(MainFTextShow);
            maifTextEdit += maifText;

            //
            this.IsMdiContainer = true;

        }
        
        public static bool EcuIsLinked = false;//判断是否连接成功
        public static bool StateOfecu9 = true;//ecu的标记,表示选择EDC7UC31。可能可以优化掉
        public static bool StateOfecu13 = false;//ecu的标记,表示选择EDC17CV44。可能可以优化掉
        //这里是解析后的ECU数字码。。。。。。涉及地点;读取ID线程()
       // int ECUstringtochangeNum = 0;                                     ///用来标记所转化的Ecu代码的个数啊。。。。。
        public static string[] ECUstringtochangeASCII = new string[23];          ////用来存放转化的ECU13的字符串、、、、、、
      //  public static string[] _backECUIDString = new string[23];//涉及地点;GetEcuIDBackString
        public static string[] Save17backDTC;  //这里是保存17发动机返回回来的代码用于显示在其他的窗口上所以是静态的 ；

        public static string GetBackString;  //这是中断返回回来的数据
        // 这里开始只主程序所含有的对象。。
        EcuConnectionF connectecu;     //持有ECU连接静态对象
        public static string EcuIDCodeToStrFin;

        private void Connect_Click(object sender, EventArgs e)
        {
            EcuIsLinked = EcuConnectionF.ECULINKStatus1;
            if (EcuIsLinked)
            {
                MessageBox.Show("串口已连接！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    GobalSerialPort.initGobalSerialPort();
                    log.Info("串口是否被被打开：" + GobalSerialPort.SerialPort.IsOpen);
                    GobalSerialPort.SerialPort.Open();
                    ThreadEcuConnet();

                }
                catch
                {
                    showBox1.Text = "串口连接失败！";
                }
            }
        }

        /// <summary>
        /// Form Thread 更新UI 
        /// </summary>
        private void ThreadEcuConnet()
        {
            String Threadname = Thread.CurrentThread.Name;
            int id = Thread.CurrentThread.ManagedThreadId;
            log.Info("thread name is " + Threadname + id);
            Thread tWorkingThread = new Thread((connectecu.ConnectEucByWait));
            tWorkingThread.Start();
        }


        private void ColsePort_Click(object sender, EventArgs e)
        {
            if (EcuIsLinked)
            {
                GobalSerialPort.SerialPort.Close();
                showBox1.Text = "串口已断开";
                //MainFTextShow("串口已断开");
                this.Text = "MainF";
                EcuVeriosn.Text = "";
                EcuIsLinked = false;
                EcuConnectionF.ECULINKStatus1 = EcuIsLinked;
            }
            else
            {
                MessageBox.Show("串口已断开！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #region  功能模块

        private void ReadEcuIDF()
        {
                log.Info("Ecu Id  readding  start...");
                MyMeans.DropAccess();
                Thread thread = new Thread(C13IdRead.workRun );
                thread.Start();
        }


        private void readDtc_Click(object sender, EventArgs e)
        {
            if (EcuIsLinked)
            {
                    showBox1.Text = "正在读取DTC...";
                    ReadDtcByCmd();                
            }
            else
            {
                MessageBox.Show("串口未连接！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReadDtcByCmd()
        {
                ReadECU13DTC();        
        }

        /// <summary>
        /// 对象处理DTC
        /// </summary>
        private void ReadECU13DTC()
        {
            //_13dtcRead dtcRead = new _13dtcRead();
            // dtcRead.ReadECU13DTC();
            //多线程处理
            new Thread(_13dtcRead.ReadECU13DTC).Start();
        }

      
        private void measure_Click(object sender, EventArgs e)
        {

            测量 Cmeaure = new 测量();
            Cmeaure.Show();

            //DebugForm debugForm = new DebugForm();
            //debugForm.Show();

        }

        private void 行程记录_Click(object sender, EventArgs e)
        {
            if (EcuIsLinked)
            {
                showBox1.Text = "正在读取记录...";
                TpRecord t = new TpRecord();
                new Thread(t.ReadFtrip).Start();
            }
            else
            {
                MessageBox.Show("串口未连接！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
       }


        private void ReadEcuId_Click(object sender, EventArgs e)
        {
            if (EcuIsLinked)
            {
                showBox1.Text = "正在读取ID...";
                ReadEcuIDF();                
            }
            else
            {
                MessageBox.Show("串口未连接！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iD信息读取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EcuIsLinked)
            {
                showBox1.Text = "正在读取ID...";
                ReadEcuIDF();
            }
            else
            {
                MessageBox.Show("串口未连接！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 故障读取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EcuIsLinked)
            {

                    ReadDtcByCmd();            
            }
            else
            {
                MessageBox.Show("串口未连接！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void 故障清除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
               new Thread(_13dtcRead.Cleardtc).Start();                      
        }

        private void 参数测量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                    
             测量 C = new 测量();
             C.Show();  
            
        }

        private void 行车记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EcuIsLinked)
            {
                showBox1.Text = "正在读取记录...";
                TpRecord t = new TpRecord();
                new Thread(t.ReadFtrip).Start();

            }
            else
            {
                MessageBox.Show("串口未连接！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearDtc_Click(object sender, EventArgs e)
        {
            if (EcuIsLinked)
            {
                //线程处理
                //new Thread(_13dtcRead.CleardtcByByte).Start();
                _13dtcRead.CleardtcByByte();
            }
            else
            {
                MessageBox.Show("串口未连接！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eDC7UC31ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // ECDName = "EDC7UC31";
            MessageBox.Show("已经选择EDC7UC31");
        }

        private void eDC17CV44ToolStripMenuItem_Click(object sender, EventArgs e)
        {

           // ECDName = "EDC17CV44";
            MessageBox.Show("已经选择EDC17CV44");
        }

        /// <summary>
        /// standindex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainF_Load(object sender, EventArgs e)
        {

            //EcuIsLinked = EcuConnectionF.ECULINKStatus1;
       

            standindex standindex = new standindex();
            standindex.TopLevel = false;
            this.panel1.Controls.Add(standindex); //add the fs form to the panel2
            standindex.Show();
        }

        /// <summary>
        /// 窗口显示
        /// </summary>
        public static void ShowBoxTex(String  success)
        {

            showBox1.Invoke((EventHandler)delegate { showBox1.Text = success;  }  ); 
            //showBox1.Invoke(ShowBoxTexDelege,"");
            
        }

        public static void ShowBoxTexDelege(String success)
        {
         //   showBox1.Invoke();
        }


        /// <summary>
        /// 发动机版本号显示函数
        /// </summary>
        /// <param name="success"></param>
        public static void EcuVersionLabelShow(String success)
        {
            EcuVeriosn.Invoke((EventHandler)delegate { EcuVeriosn.Text = success; });

            maifTextEdit(success);
            // MainF.T
            // MainFShow();
        }

        /// <summary>
        /// 显示窗体版本号
        /// </summary>
        /// <param name="success"></param>
        public void MainFTextShow(String success) {

            this.Invoke((EventHandler)delegate { this.Text = success; });

           // this.Invoke = success;
            //this.Text.F
        }

        private void dUBUGToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DebugForm debugForm = new DebugForm();
            debugForm.Show();

        }

        /// <summary>
        /// 监测
        /// </summary>
        private void LinsenAutoSetCount() {

            while (true) {

                if (CommonAutoRest.AutoResetCount >=3) {

                    GobalSerialPort.ClearSendAndRecive();

                    CommonAutoRest.MEvent.Set();                    
                }
            }

        }

        private void eEPROMToolStripMenuItem_Click(object sender, EventArgs e)
        {

            EEPROMWrite eolWrite = new EEPROMWrite();
            eolWrite.Show();

            //EOL测试数据
          

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        
        //主动测试工具主界面
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            DiagnosticTest diagnostic = new DiagnosticTest();
            diagnostic.Show();

        }


        /**
         * EOL 写数据
         */
        private void eOLWRITEToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //EOLFORMWRITE eOLFORMWRITE = new EOLFORMWRITE();
            EOLFORMWRITE eolF = new EOLFORMWRITE();
            eolF.Show();
        }

        private void dEBUGToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DebugForm debugForm = new DebugForm();
            debugForm.Show();

        }
    }

}
        #endregion




