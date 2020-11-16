using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dcarengine.UIForm;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using Dcarengine.SQLData;
using System.Collections;
using System.Data;
using Dcarengine.serialPort;
using System.Diagnostics;
using Dcarengine.refactor;

namespace Dcarengine.Function_Class
{
    class EcuConnectionF
    {

        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 声明委托，多线程更新UI控件
        /// </summary>
        /// <param name="l"></param>
        /// <param name="s"></param>
        private delegate void Edit(TextBox l, string s);


        // private  static  MainF MainF = new MainF();


        /// <summary>
        /// 定义连接的前面的字符 按照文档步骤来解释
        /// </summary>
        byte[] ATSP5;
        byte[] ATZ;
        byte[] ATST03;
        byte[] ATSW19;
        byte[] ATSH81_10_F1;
        byte[] _1081;
        byte[] ATL1;
        byte[] _ATE0;  //   初始化命令  
        public static bool ECULINKStatus;       //连接状态
        public static byte[] _AT2S;
        static ArrayList TL718NUM;  //动态数组 用来保存TL718的芯片的号  此处为静态字段
        static AccessDbClass accessdb;

        //连接标志 是否是主界面LOAD
        public static bool is_main_load = true;



        public static bool ECULINKStatus1
        {
            get { return ECULINKStatus; }
            set { ECULINKStatus = value; }
        }

        public void IniConnectTl718()
        {
            _ATE0 = StringToSendBytes.bytesToSend("ATE0\n");
            ATSP5 = StringToSendBytes.bytesToSend("ATSP5\n");
            ATST03 = StringToSendBytes.bytesToSend("ATST05\n");
            ATSW19 = StringToSendBytes.bytesToSend("ATSW19\n");
            ATSH81_10_F1 = StringToSendBytes.bytesToSend("ATSH8110F1\n");
            _1081 = StringToSendBytes.bytesToSend("1081\n");
            _AT2S = StringToSendBytes.bytesToSend("AT@S\n");
            ATZ = StringToSendBytes.bytesToSend("ATZ\n");
            ATL1 = StringToSendBytes.bytesToSend("ATL1");
            TL718NUM = new ArrayList();
        }


        public EcuConnectionF()
        {

            IniConnectTl718();
        }

        static EcuConnectionF()
        {

            // IniConnectTl718();
        }

        /// <summary>
        /// 查询芯片
        /// </summary>
        public static void QueryTL()
        {

            string sql = "select * from TL718";
            accessdb = new AccessDbClass(MyMeans.strConn1);
            DataTable tl718 = accessdb.SelectToDataTable(sql);
            tl718.Columns.Remove("ID");
            for (int i = 0; i < tl718.Rows.Count; i++)
            {
                string value = tl718.Rows[i][0].ToString();
                TL718NUM.Add(value);
            }
        }

        /// <summary>
        /// 连接ECU 通过获取锁模式
        /// </summary>
        public void ConnectEuc()
        {
            ClearSendAndRecive();

            String backEndString = null;

            //
            // GobalSerialPort.WriteByMessage(CommonCmd.ATR, 0, CommonCmd.ATR.Length);
            // backEndString = GetSerialPortBackData();

            GobalSerialPort.WriteByThreadWait(ATL1, 0, ATL1.Length);


            GobalSerialPort.WriteByThreadWait(CommonCmd.ATE1, 0, CommonCmd.ATE1.Length);

            //   GobalSerialPort.WriteByThreadWait(_AT2S, 0, _AT2S.Length);
            //  backEndString = GetSerialPortBackData();

            // GobalSerialPort.WriteByThreadWait(ATSP5, 0, ATSP5.Length);             ////////读取718芯片

            //  backEndString = GetSerialPortBackData();
            //if (backEndString.Contains("OK"))
            //{
            //    GobalSerialPort.WriteByThreadWait(CommonCmd.ATST00, 0, CommonCmd.ATST00.Length);      //22222/
            //}
            //backEndString = GetSerialPortBackData();
            //if (backEndString.Contains("OK"))
            //{
            //    GobalSerialPort.WriteByThreadWait(ATSW19, 0, ATSW19.Length);      //22222/           ////333333
            //}
            //backEndString = GetSerialPortBackData();
            //if (backEndString.Contains("OK"))
            //{
            GobalSerialPort.WriteByThreadWait(ATSH81_10_F1, 0, ATSH81_10_F1.Length);
            //  }
            backEndString = GetSerialPortBackData();
            if (backEndString.Contains("OK"))
            {
                GobalSerialPort.WriteByThreadWait(_1081, 0, _1081.Length);                              ////////////5
                //连接处可能需要特殊处理
            }
            backEndString = GetSerialPortBackData();

        }


        /// <summary>
        /// EN
        /// </summary>
        public void connectEcuByWaiteLM327()
        {

            if (GobalSerialPort.SerialPort.IsOpen == false)
            {
                return;
            }
            ClearSendAndRecive();
            String backEndString = null;
            GobalSerialPort.WriteByMessage(CommonCmd.ATL1, 0, CommonCmd.ATL1.Length);

            GobalSerialPort.WriteByMessage(CommonCmd.ATE1, 0, CommonCmd.ATE1.Length);
            try
            {
                GobalSerialPort.WriteByMessage(CommonCmd.ATAL, 0, CommonCmd.ATAL.Length);
                backEndString = GetSerialPortBackData();
            }
            catch { }
            GobalSerialPort.WriteByMessage(ATSP5, 0, ATSP5.Length);             ////////读取718芯片
            backEndString = GetSerialPortBackData();
            if (backEndString.Contains("OK"))
            {
                GobalSerialPort.WriteByMessage(CommonCmd.ATST0F, 0, CommonCmd.ATST0F.Length); //2
            }
            backEndString = GetSerialPortBackData();
            backEndString = GetSerialPortBackData();
            if (backEndString.Contains("OK"))
            {
                GobalSerialPort.WriteByMessage(ATSH81_10_F1, 0, ATSH81_10_F1.Length);
            }
            backEndString = GetSerialPortBackData();
            if (backEndString.Contains("OK"))
            {
                GobalSerialPort.WriteByMessage(_1081, 0, _1081.Length);  ////////////5
            }
            backEndString = GetSerialPortBackData();
            EcuVersionF.GetEcuVersion();
            if (backEndString.Contains("50") && backEndString.Contains("81"))
            {
                ECULINKStatus = true;
                MainF.ShowBoxTex("ECU连接成功！");
            }
            else
            {
                ECULINKStatus = false;
                MainF.ShowBoxTex("ECU连接失败！");
            }
            MainF.EcuIsLinked = ECULINKStatus1;
        }
        /// <summary>
        /// 连接ECU 通过获取锁模式
        /// </summary>
        public void ConnectEucByWait()
        {
            if (GobalSerialPort.SerialPort.IsOpen == false)
            {
                return;
            }

            //lock (CommonConstant.sign) {

            ClearSendAndRecive();

            String backEndString = null;

            GobalSerialPort.WriteByMessage(CommonCmd.ATE1, 0, CommonCmd.ATE1.Length);

            GobalSerialPort.WriteByMessage(CommonCmd.ATAL, 0, CommonCmd.ATAL.Length);

            try
            {
                //718 code
                //GobalSerialPort.WriteByMessage(_AT2S, 0, _AT2S.Length);
                //backEndString = GetSerialPortBackData();
                //CommonConstant.TL718 = backEndString.Split('\r')[1];
                //bool flag = false;
                //foreach (string num in CommonConstant.TL718List)
                //{
                //    if (backEndString.Contains(num))
                //    {
                //        flag = true;
                //        break;
                //    }
                //}
                //if (!flag)
                //{
                //    MainF.ShowBoxTex("设备不匹配!");
                //    return;
                //    // return;
                //}
            }
            catch { }

            // GobalSerialPort.WriteByMessage(ATZ, 0, ATZ.Length);             ////////读取718芯片

            GobalSerialPort.WriteByMessage(CommonCmd.AT_2, 0, CommonCmd.AT_2.Length);             ////////读取718芯片
            backEndString = GetSerialPortBackData();
            if (backEndString.Length == 12)
            {

                GobalSerialPort.WriteByMessage(CommonCmd.ATRD, 0, CommonCmd.ATRD.Length); //2
                backEndString = GetSerialPortBackData();
            }

            GobalSerialPort.WriteByMessage(ATSP5, 0, ATSP5.Length);             ////////读取718芯片
            backEndString = GetSerialPortBackData();
            if (backEndString.Contains("OK"))
            {
                GobalSerialPort.WriteByMessage(CommonCmd.ATST0F, 0, CommonCmd.ATST0F.Length); //2
            }

            backEndString = GetSerialPortBackData();
            //if (backEndString.Contains("OK"))
            //{
            //    GobalSerialPort.WriteByMessage(ATSW19, 0, ATSW19.Length);      //22222/           ////333333
            //}
            backEndString = GetSerialPortBackData();
            if (backEndString.Contains("OK"))
            {
                GobalSerialPort.WriteByMessage(ATSH81_10_F1, 0, ATSH81_10_F1.Length);
            }
            backEndString = GetSerialPortBackData();
            if (backEndString.Contains("OK"))
            {
                GobalSerialPort.WriteByMessage(_1081, 0, _1081.Length);                              ////////////5
                                                                                                     //连接处可能需要特殊处理
            }

            backEndString = GetSerialPortBackData();

            EcuVersionF.GetEcuVersion();

            if (backEndString.Contains("50") && backEndString.Contains("81"))
            {

                ECULINKStatus = true;
                MainF.ShowBoxTex("ECU连接成功！");
            }
            else
            {
                ECULINKStatus = false;
                MainF.ShowBoxTex("ECU连接失败！");
            }
            MainF.EcuIsLinked = ECULINKStatus1;
        }



        /// <summary>
        /// 连接ECU 通过获取锁模式
        /// </summary>
        public void ConnectEucByWaitThread()
        {
            if (GobalSerialPort.SerialPort.IsOpen == false)
            {

                return;
            }

            ClearSendAndRecive();

            String backEndString = null;

            CommonCmd.SendATE1();
            // GobalSerialPort.GobalSerialPortEnventChange();
            // 718 code
            GobalSerialPort.WriteByMessage(_AT2S, 0, _AT2S.Length);
            backEndString = GetSerialPortBackData();
            CommonConstant.TL718CODE = backEndString;

            bool flag = false;
            foreach (string num in CommonConstant.TL718List)
            {
                if (backEndString.Contains(num))
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                MainF.ShowBoxTex("设备不匹配!");
                return;
                // return;
            }
            GobalSerialPort.WriteByMessage(ATSP5, 0, ATSP5.Length);             ////////读取718芯片
            backEndString = GetSerialPortBackData();
            if (backEndString.Contains("OK"))
            {
                GobalSerialPort.WriteByMessage(CommonCmd.ATST0F, 0, CommonCmd.ATST0F.Length); //2
            }

            backEndString = GetSerialPortBackData();
            if (backEndString.Contains("OK"))
            {
                GobalSerialPort.WriteByMessage(ATSW19, 0, ATSW19.Length);      //22222/           ////333333
            }
            backEndString = GetSerialPortBackData();
            if (backEndString.Contains("OK"))
            {
                GobalSerialPort.WriteByMessage(ATSH81_10_F1, 0, ATSH81_10_F1.Length);
            }
            backEndString = GetSerialPortBackData();
            if (backEndString.Contains("OK"))
            {
                GobalSerialPort.WriteByMessage(_1081, 0, _1081.Length);                              ////////////5
                //连接处可能需要特殊处理
            }

            backEndString = GetSerialPortBackData();

            if (backEndString.Contains("50") && backEndString.Contains("81"))
            {
                ECULINKStatus = true;
            }
            else
            {
                ECULINKStatus = false;
            }
            MainF.EcuIsLinked = ECULINKStatus1;
        }



        /// <summary>
        /// 连接ECU 通过获取锁模式
        /// </summary>
        public void ConnectEucTest()
        {

            //Process.Start("D://日志采集系统接入方案.docx");
            int id = Thread.CurrentThread.ManagedThreadId;
            log.Info("thread name is ss " + id);
            // MainF.showBox1.Text = "ok";
            // MainF.showBox1.Text = teststring;
            //  ShowTextBox(l, s);
            //  ShowTime();
        }

        public void ShowTime()
        {

            int id = Thread.CurrentThread.ManagedThreadId;
            log.Info("thread name is sssss " + id);
            // MainF.showBox1.Text = "No";
            MessageBox.Show("ss");
        }



        /// <summary>
        /// 清除数据
        /// </summary>
        public static void ClearSendAndRecive()
        {
            try
            {
                GobalSerialPort.SerialPort.ReadExisting();
                GobalSerialPort.SerialPort.DiscardInBuffer();
                GobalSerialPort.SerialPort.DiscardOutBuffer();
            }
            catch (InvalidOperationException)
            {
            }

        }


        /// <summary>
        /// 获取返回数据
        /// </summary>
        /// <returns></returns>
        public String GetSerialPortBackData()
        {

            return GobalSerialPort.ResultBackString;

        }


    }

}

