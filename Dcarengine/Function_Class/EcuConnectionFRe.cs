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
using Dcarengine.refactor;

namespace Dcarengine.Function_Class
{
    class EcuConnectionFRe
    {
        /// <summary>
        /// 定义连接的前面的字符 按照文档步骤来解释
        /// </summary>
        byte[] ATSP5;
        byte[] ATST03;
        byte[] ATSW19;
        byte[] ATSH81_10_F1;
        byte[] _1081;
        byte[] _ATE0;  //   初始化命令  
        static bool ECULINKStatus;       //连接状态
        public static byte[] _AT2S;
        static ArrayList TL718NUM;  //动态数组 用来保存TL718的芯片的号  此处为静态字段
        static AccessDbClass accessdb;

        public bool ECULINKStatus1
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
            TL718NUM = new ArrayList();
        }

        public EcuConnectionFRe()
        {

            IniConnectTl718();
        }

        static EcuConnectionFRe()
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

            GobalSerialPort.WriteByMessage(_AT2S, 0, _AT2S.Length);
            CommonAutoRest.MEvent.WaitOne();
            backEndString = GetSerialPortBackData();
            foreach (string num in TL718NUM)
            {
                if (backEndString.Contains(num))
                {
                    GobalSerialPort.WriteByMessage(ATSP5, 0, ATSP5.Length);             ////////读取718芯片
                }
            }
            CommonAutoRest.MEvent.WaitOne();
            backEndString = GetSerialPortBackData();
            if (backEndString.Contains("OK"))
            {
                GobalSerialPort.WriteByMessage(ATST03, 0, ATST03.Length);      //22222/
            }
            CommonAutoRest.MEvent.WaitOne();
            backEndString = GetSerialPortBackData();
            if (backEndString.Contains("OK"))
            {
                GobalSerialPort.WriteByMessage(ATSW19, 0, ATSW19.Length);      //22222/           ////333333
            }
            CommonAutoRest.MEvent.WaitOne();
            backEndString = GetSerialPortBackData();
            if (backEndString.Contains("OK"))
            {
                GobalSerialPort.WriteByMessage(ATSH81_10_F1, 0, ATSH81_10_F1.Length);
            }
            CommonAutoRest.MEvent.WaitOne();
            backEndString = GetSerialPortBackData();
            if (backEndString.Contains("OK"))
            {
                GobalSerialPort.WriteByMessage(_1081, 0, _1081.Length);                              ////////////5
                //连接处可能需要特殊处理
            }
            CommonAutoRest.MEvent.WaitOne();
            backEndString = GetSerialPortBackData();
            if (backEndString.Contains("50") && backEndString.Contains("81"))
            {
                ECULINKStatus = true;
            }
            else
            {
                ECULINKStatus = false;
            }
        }

        //这个函数是以前是一种用来读取数据的方式 现在我用来清除数据串口的数据
        public static string ClearSendAndRecive()
        {

            string s1 = "";
            
            return s1;
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

