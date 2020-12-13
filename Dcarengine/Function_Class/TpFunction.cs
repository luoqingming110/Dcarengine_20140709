
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dcarengine.SQLData;
using System.Windows.Forms;
using Dcarengine.Function_Class;
using System.Threading;
using Dcarengine.UIForm;
using Dcarengine.serialPort;
using Dcarengine.refactor;
using System.Data;

namespace Dcarengine.Function_Class
{
    class TpRecord
    {

        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region
        private string[] Genera1 = new string[5];
        /// <summary>
        /// 用于计算的保存常规数据
        /// </summary>
        private string[] Genera2 = new string[5];
        private string   MaxValue_minValue;
        private string[] Single_Timer = new string[15];
        private string[] Dimensional_Maps = new string[6];
        private string[] _0175_0183S = new string[15];
        private string[] _0165_016BS = new string[7];
        /// <summary>
        /// 这里是MAX的最大值和最小值的五个变量的声明。。。。。
        /// </summary>
        Double Emp_nEngMax, Emp_nEngMin;
        Double CEngDst_tMax, CEngDst_tMin;
        Double CEnhgDst_tMax, CEnhgDst_tMin;
        Double Rall_PFltMax, Rall_pFltMin;
        Double Oil_PswmpMax, Oil_PswmpMin;
        /// <summary>
        /// 这里是计数器和计时器的变量声明 两个数组 初始化都为null
        /// </summary>
        UInt64[] TimerArray = new UInt64[15];
        UInt64[] CounterArry = new UInt64[15];
        string[] TimerToGenral = new string[15];
        /// <summary>
        /// 这里是处理一维数组的数据，变量为4*6的矩阵,后面是处理二维数据，也是矩阵处理方式
        /// </summary>
        UInt64[][] _1Dimensional_MapsInt = new UInt64[6][];
        String[][] _1Dimensional_Maps_toStr = new string[6][];
        UInt64[][] _68_2Dimensional_MapsInt = new UInt64[9][];
        string[][] _68_Dimensional_Maps_toStr = new string[9][];
        UInt64[][] _69_2Dimensional_MapsInt = new UInt64[9][];
        string[][] _69_Dimensional_Maps_toStr = new string[9][];

        /// <summary>
        /// cmd from db cmd
        /// </summary>
        String General1cmd;
        String General2cmd;
        String General3cmd;
        String General4cmd;
        String General5cmd;
        String MaxAndMincmd;
        String Timercmd;
        String Countercmd;
        String _1Ddata1;
        String _1Ddata2;
        String _2Ddata1;
        String _2Ddata2;
        String _2Ddata3;

        #endregion



        /// <summary>
        /// 获取行程记录
        /// </summary>
        static TpRecord() {

            GobalSerialPort.WriteByMessage(CommonCmd.ATE1, 0, CommonCmd.ATE1.Length);
        }

        /// <summary>
        /// 获取初始命令
        /// </summary>
        private void GetCmdFormDb(String EcuVersion) {

           DataSet dataSet =  MyMeans.GetEcuTrip(EcuVersion);
            foreach (DataRow row in dataSet.Tables["Table1_1"].Rows)
            {
                General1cmd = (String)row[1];
                General2cmd = (String)row[2];
                General3cmd = (String)row[3];
                General4cmd = (String)row[4];
                General5cmd = (String)row[5];
                MaxAndMincmd = (String)row[6];
                Timercmd   =  (String)row[7];         
                Countercmd = (String)row[8];
                _1Ddata1 = (String)row[9];
                _1Ddata2 = (String)row[10];
                _2Ddata1 = (String)row[11];
                _2Ddata2 = (String)row[12];
                _2Ddata3 = (String)row[13];
            }
        }


        /// <summary>
        /// 读取行程记录仪
        /// </summary>
        public void ReadFtrip()
        {
                try
                {

                CommonCmd.SendATE1();
                // EcuVersionF.EcuVsion = "P1287770";
                if (EcuVersionF.EcuVsion == null)
                {
                    MainF.ShowBoxTex("未能读取ECU版本号");
                    return;
                }
                if(EcuVersionF.EcuVsion == "P1287800") {
                    EcuVersionF.EcuVsion = "P1287790";
                }
                GetCmdFormDb(EcuVersionF.EcuVsion);
                SendData();
                Work_OutoneStep();
                WorkOut_TimerAndCounter();
                _1Dimensional_Maps();
                _2Dimensional_Maps();
                ShowTripRecord();//先清除数据，然后重新填充
                SaveFileFunction.Tp_SaveExcel();
                MainF.ShowBoxTex("读完数据");
                }
                catch(Exception e)
                {
                     log.Info("tp read this is exception" + e.Message);
                }            
        }

        private void SendData()
        {
            Max_MinValue();
            SendGeneral();
            SendExtendMes();
        }

        private void SendGeneral()
        {
            byte[] _21016DStr = StringToSendBytes.bytesToSend(General1cmd + "\n");
            GobalSerialPort.WriteByMessage(_21016DStr, 0, _21016DStr.Length);
            Genera1[0] = GobalSerialPort.ResultBackString;

            byte[] _21016EStr = StringToSendBytes.bytesToSend(General2cmd +"\n");
            GobalSerialPort.WriteByMessage(_21016EStr, 0, _21016EStr.Length);
            Genera1[1] = GobalSerialPort.ResultBackString;

            byte[] _21016FStr = StringToSendBytes.bytesToSend(General3cmd+"\n");
            GobalSerialPort.WriteByMessage(_21016FStr, 0, _21016FStr.Length);
            Genera1[2] = GobalSerialPort.ResultBackString;

            byte[] _210170Str = StringToSendBytes.bytesToSend(General4cmd+"\n");
            GobalSerialPort.WriteByMessage(_210170Str, 0, _210170Str.Length);
            Genera1[3] = GobalSerialPort.ResultBackString;

            byte[] _210171Str = StringToSendBytes.bytesToSend(General5cmd+"\n");
            GobalSerialPort.WriteByMessage(_210171Str, 0, _210171Str.Length);
            Genera1[4] = GobalSerialPort.ResultBackString;
        }


        private void Max_MinValue()
        {
            byte[] _21016CStr = StringToSendBytes.bytesToSend("234C09C828\n");
            GobalSerialPort.WriteByMessage(_21016CStr, 0, _21016CStr.Length);
            MaxValue_minValue = GobalSerialPort.ResultBackString;
            //计算最大值最小值
            WorkOut_Max_Min();
        }

        private void SendExtendMes()
        {
            byte[] counter = StringToSendBytes.bytesToSend("234C09743c\n");
            GobalSerialPort.WriteByMessage(counter, 0, counter.Length);           
            _0165_016BS[0] = GobalSerialPort.ResultBackString;

            byte[] _1_mapSendCmd = StringToSendBytes.bytesToSend("234C07F490\n");
            GobalSerialPort.WriteByMessage(_1_mapSendCmd, 0, _1_mapSendCmd.Length);          
            _0165_016BS[2] = GobalSerialPort.ResultBackString;

            byte[] _2_mapSendCmd_1 = StringToSendBytes.bytesToSend("234C085490\n");
            GobalSerialPort.WriteByMessage(_2_mapSendCmd_1, 0, _2_mapSendCmd_1.Length);
            _0165_016BS[3] = GobalSerialPort.ResultBackString;

            byte[] _2_mapSendCmd_2 = StringToSendBytes.bytesToSend("234C08E490\n");
            GobalSerialPort.WriteByMessage(_2_mapSendCmd_2, 0, _2_mapSendCmd_2.Length);
            _0165_016BS[4] = GobalSerialPort.ResultBackString;
        }


        /// <summary>
        ///   165代码读取量
        /// </summary>
        private void _0165_016B()
        {
            for (int i = 0; i < 5; i++)
            {
                string Sendstring1 = "210165";
                long intA1 = Convert.ToInt64(Sendstring1, 16);
                intA1 = intA1 + i;
                string Sendstring2 = Convert.ToString(intA1, 16) + "\n";
                byte[] ByteSend = StringToSendBytes.bytesToSend(Sendstring2);
                GobalSerialPort.WriteByMessage(ByteSend, 0, ByteSend.Length);                
                _0165_016BS[i] = GobalSerialPort.ResultBackString;
            }
        }

        /// <summary>
        ///  计算量第一步
        /// </summary>
        private void Work_OutoneStep()
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    string[] fenge = Genera1[i].Split('\r');
                    if (fenge[1] != null)
                    {
                        Genera2[i] = fenge[1].Replace(" ", "");
                        if (!Genera2[i].Contains("NO") && !Genera2[i].Contains("7F"))
                        {
                            string substring1 = Genera2[i].Substring(2, 2);
                            string substring2 = Genera2[i].Substring(4, 2);
                            string substring3 = Genera2[i].Substring(6, 2);
                            string substring4 = Genera2[i].Substring(8, 2);
                            Genera2[i] = substring4 + substring3 + substring2 + substring1;
                        }
                        else
                        {
                            Genera2[i] = "0";
                        }
                        UInt64 intA2 = Convert.ToUInt64(Genera2[i], 16);
                        Genera2[i] = intA2.ToString();
                    }
                    else
                    {
                        Genera2[i] = "0";
                    }
                }
                for (int k = 0; k < 5; k++)
                {
                    if (_0165_016BS[k] != "")
                    {
                        if (_0165_016BS[k] != null)     //判断字符串的是否为空
                        {
                            string[] fengge2 = _0165_016BS[k].Split('\r');
                            if (fengge2[1] != null)
                            {
                                _0165_016BS[k] = fengge2[1];
                            }
                            else
                            {
                                _0165_016BS[k] = "";
                            }
                        }
                        else
                        {
                            _0165_016BS[k] = "";
                        }
                    }
                    else
                    {
                        _0165_016BS[k] = "";
                    }
                }
            }
            catch (Exception e) {

                log.Info("tp work once is error :" + e.Message);
            }
        }

        /// <summary>
        /// 最大值最小值
        /// </summary>
        private void WorkOut_Max_Min()
        {
            try
            {
                //max   and  min
                if (MaxValue_minValue != "" || (!MaxValue_minValue.Contains("NO") && !MaxValue_minValue.Contains("7F")))
                {
                    string[] Max_Min = MaxValue_minValue.Split('\r');
                    if (!Max_Min[1].Contains("NO") && Max_Min[1] != null)
                    {
                        if (Max_Min.Length == 1)
                        {
                            MaxValue_minValue = Max_Min[0];
                        }
                        else
                        {
                            MaxValue_minValue = Max_Min[1];
                        }
                    }
                    else
                    {
                        MaxValue_minValue = " ";
                    }
                }
                else
                {
                    MaxValue_minValue = " ";
                }

                string[] Max_minStrArray = new string[10];
                Double[] Max_minIntArray = new Double[10];
                string Max_min = MaxValue_minValue.Replace(" ", "").Substring(2, 80);
                int x = 0;
                for (int i = 0; i < 10; i++)
                {
                    Max_minStrArray[i] = Max_min.Substring(x, 8);
                    x = x + 8;
                }
                for (int i = 0; i < 10; i++)
                {
                    string[] SplitArry = new string[4];
                    int k = 0;
                    for (int j = 0; j < 4; j++)
                    {
                        SplitArry[j] = Max_minStrArray[i].Substring(k, 2);
                        k = k + 2;
                    }
                    Max_minStrArray[i] = SplitArry[3] + SplitArry[2] + SplitArry[1] + SplitArry[0];

                }
                for (int i = 0; i < 10; i++)
                {
                    //      Max_minIntArray[i] = Convert.ToUInt64(Max_minStrArray[i], 10);
                    Max_minIntArray[i] = Convert.ToUInt64(Max_minStrArray[i], 16);
                }
                Emp_nEngMin = Max_minIntArray[0] / 2;
                Emp_nEngMax = Max_minIntArray[1] / 2;
                CEngDst_tMin = Max_minIntArray[2] / 10 - 273.14;
                CEngDst_tMax = Max_minIntArray[3] / 10 - 273.14;
                CEnhgDst_tMin = Max_minIntArray[4] / 10 - 273.14;
                CEnhgDst_tMax = Max_minIntArray[5] / 10 - 273.14;
                Rall_pFltMin = Max_minIntArray[6] * 100;
                Rall_PFltMax = Max_minIntArray[7] * 100;
                Oil_PswmpMin = Max_minIntArray[8] / 10 - 273.14;
                Oil_PswmpMax = Max_minIntArray[9] / 10 - 273.14;

            }catch (Exception e) {

                log.Info("this is message " + e.Message);
                return;
            }

        }


        /// <summary>
        /// 计算计时器与计算器
        /// </summary>
        private void WorkOut_TimerAndCounter()
        {

            try
            {
                string[] TimerStrArray = new string[15]; string[] CounterStrArray = new string[15];
                UInt64[] TimerIntArry = new UInt64[15]; UInt64[] CounterIntArry = new UInt64[15];

                /// 这里是增加补齐的数据  长读不足可以补位
                for (int i = 0; i < 2; i++)
                {
                    _0165_016BS[i] = _0165_016BS[i].Replace(" ", "").PadRight(127, '0');
                    int j = _0165_016BS[i].Length;
                }
                ///
                string Counter = _0165_016BS[0].Replace(" ", "").Substring(2, 120);
                string Timer = _0165_016BS[1].Replace(" ", "").Substring(2, 120);
                int x = 0;
                for (int i = 0; i < 15; i++)
                {
                    TimerStrArray[i] = Counter.Substring(x, 8);
                    CounterStrArray[i] = Timer.Substring(x, 8);
                    x = x + 8;
                }
                for (int i = 0; i < 15; i++)
                {
                    string[] SplitTimerArry = new string[4];
                    string[] SplitCounterArry = new string[4];
                    int k = 0;
                    for (int j = 0; j < 4; j++)
                    {
                        SplitTimerArry[j] = TimerStrArray[i].Substring(k, 2);
                        SplitCounterArry[j] = CounterStrArray[i].Substring(k, 2);
                        k = k + 2;
                    }
                    TimerStrArray[i] = SplitTimerArry[3] + SplitTimerArry[2] + SplitTimerArry[1] + SplitTimerArry[0];
                    CounterStrArray[i] = SplitCounterArry[3] + SplitCounterArry[2] + SplitCounterArry[1] + SplitCounterArry[0];
                }
                //转化数据 将他转化成计数器和时间
                for (int j = 0; j < 15; j++)
                {
                    TimerIntArry[j] = Convert.ToUInt64(TimerStrArray[j], 16);
                    CounterIntArry[j] = Convert.ToUInt64(CounterStrArray[j], 16);
                    TimerArray[j] = TimerIntArry[j];
                    CounterArry[j] = CounterIntArry[j];
                }
                // 这里要将的是时间转成成便于识别的数字。。。
                for (int k = 0; k < 15; k++)
                {
                    UInt64 Colck, Min, Second;
                    Colck = TimerIntArry[k] / 3600;
                    Min = TimerIntArry[k] % 3600 / 60;
                    Second = TimerIntArry[k] % 3600 % 60;
                    TimerToGenral[k] = Colck.ToString() + "h" + Min.ToString() + "min" + Second + "s";
                }
            }
            catch (Exception e) {

                log.Info("counter and timer error :" + e.Message);
            }

        }


        private void _1Dimensional_Maps()
        {

            try
            {
                //////这里是将192个字符转化为8个为一组的字符放在数数组中 ，也初始话6*4的矩阵
                string[][] _1MapsStr = new string[6][];
                //初始化数组 指的是全局变量。。。。
                for (int i = 0; i < 6; i++)
                {
                    _1Dimensional_MapsInt[i] = new UInt64[4];
                    _1Dimensional_Maps_toStr[i] = new string[4];
                    _1MapsStr[i] = new string[4];
                }
                string _1Maps = _0165_016BS[2].Replace(" ", "").PadRight(200, '0').Substring(4, 192);
                int x = 0;
                for (int No1 = 0; No1 < 6; No1++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        _1MapsStr[No1][j] = _1Maps.Substring(x, 8);
                        x = x + 8;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        string[] SplitArry = new string[4];
                        int k = 0;
                        for (int r = 0; r < 4; r++)
                        {
                            SplitArry[r] = _1MapsStr[i][j].Substring(k, 2);
                            k = k + 2;
                        }
                        _1MapsStr[i][j] = SplitArry[3] + SplitArry[2] + SplitArry[1] + SplitArry[0];
                    }
                }
                for (int k = 0; k < 6; k++)
                {
                    for (int h = 0; h < 4; h++)
                    {
                        _1Dimensional_MapsInt[k][h] = Convert.ToUInt64(_1MapsStr[k][h], 16);
                        UInt64 Colck, Min, Second;
                        Colck = _1Dimensional_MapsInt[k][h] / 3600;
                        Min = _1Dimensional_MapsInt[k][h] % 3600 / 60;
                        Second = _1Dimensional_MapsInt[k][h] % 3600 % 60;
                        _1Dimensional_Maps_toStr[k][h] = Colck.ToString() + "h" + Min.ToString() + "min" + Second + "s";
                    }
                }
            }
            catch (Exception e) {

                log.Info("1Dimensional_Map  error " + e.Message);
            }
        }


        //显示结果
        private void _2Dimensional_Maps()
        {
            try
            {
                UInt64[][] _68_2Dimensional_MapsInt = new UInt64[9][];
                _68_Dimensional_Maps_toStr = new string[9][];
                UInt64[][] _69_2Dimensional_MapsInt = new UInt64[9][];
                _69_Dimensional_Maps_toStr = new string[9][];
                //////将二维数据截取出来存放在
                string[][] _68_2MapsStr = new string[9][];
                string[][] _69_2MapsStr = new string[9][];
                //初始化数组 指的是全局变量。。。。
                for (int i = 0; i < 9; i++)
                {
                    _68_2Dimensional_MapsInt[i] = new UInt64[4];
                    _68_Dimensional_Maps_toStr[i] = new string[4];
                    _69_2Dimensional_MapsInt[i] = new UInt64[4]; ;
                    _69_Dimensional_Maps_toStr[i] = new string[4];
                    _68_2MapsStr[i] = new string[4];
                    _69_2MapsStr[i] = new string[4];
                }
                string _68_2Maps = _0165_016BS[3].Replace(" ", "").PadRight(296, '0').Substring(4, 288);
                string _69_2Maps = _0165_016BS[4].Replace(" ", "").PadRight(296, '0').Substring(4, 288);
                int x = 0;
                for (int No1 = 0; No1 < 9; No1++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        _68_2MapsStr[No1][j] = _68_2Maps.Substring(x, 8);
                        _69_2MapsStr[No1][j] = _69_2Maps.Substring(x, 8);
                        x = x + 8;
                    }
                }
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        string[] SplitArry1 = new string[4];
                        string[] SplitArry2 = new string[4];
                        int k = 0;
                        for (int r = 0; r < 4; r++)
                        {
                            SplitArry1[r] = _68_2MapsStr[i][j].Substring(k, 2);
                            SplitArry2[r] = _69_2MapsStr[i][j].Substring(k, 2);
                            k = k + 2;
                        }
                        _68_2MapsStr[i][j] = SplitArry1[3] + SplitArry1[2] + SplitArry1[1] + SplitArry1[0];
                        _69_2MapsStr[i][j] = SplitArry2[3] + SplitArry2[2] + SplitArry2[1] + SplitArry2[0];
                    }
                }

                for (int k = 0; k < 9; k++)
                {
                    for (int h = 0; h < 4; h++)
                    {
                        _68_2Dimensional_MapsInt[k][h] = Convert.ToUInt64(_68_2MapsStr[k][h], 16);
                        _69_2Dimensional_MapsInt[k][h] = Convert.ToUInt64(_69_2MapsStr[k][h], 16);
                        UInt64 Colck1, Min1, Second1;
                        UInt64 Colck2, Min2, Second2;
                        Colck1 = _68_2Dimensional_MapsInt[k][h] / 3600;
                        Min1 = _68_2Dimensional_MapsInt[k][h] % 3600 / 60;
                        Second1 = _68_2Dimensional_MapsInt[k][h] % 3600 % 60;
                        _68_Dimensional_Maps_toStr[k][h] = Colck1.ToString() + "h" + Min1.ToString() + "min" + Second1 + "s";
                        ////
                        Colck2 = _69_2Dimensional_MapsInt[k][h] / 3600;
                        Min2 = _69_2Dimensional_MapsInt[k][h] % 3600 / 60;
                        Second2 = _69_2Dimensional_MapsInt[k][h] % 3600 % 60;
                        _69_Dimensional_Maps_toStr[k][h] = Colck2.ToString() + "h" + Min2.ToString() + "min" + Second2 + "s";
                    }
                }
            }
            catch (Exception e) {

                log.Info("2Dimensional error is  :" + e.Message);
            }

        }


        /// <summary>
        /// 显示行程记录
        /// </summary>
        private void ShowTripRecord()
        {
            try
            {
                UInt64 VehDa_tiEngOn_COLCK, VehDa_tiEngOn_MIN, VehDa_tiEngOn_SECOND;
                UInt64 VehDa_tiECUOn_COLCK, VehDa_tiECUOn_MIN, VehDa_tiECUOn_SECOND;
                VehDa_tiEngOn_COLCK = Convert.ToUInt64(Genera2[1]) / 3600;
                VehDa_tiEngOn_MIN = Convert.ToUInt64(Genera2[1]) % 3600 / 60;
                VehDa_tiEngOn_SECOND = Convert.ToUInt64(Genera2[1]) % 3600 % 60;

                VehDa_tiECUOn_COLCK = Convert.ToUInt64(Genera2[2]) / 3600;
                VehDa_tiECUOn_MIN = Convert.ToUInt64(Genera2[2]) % 3600 / 60;
                VehDa_tiECUOn_SECOND = Convert.ToUInt64(Genera2[2]) % 3600 % 60;

                StringBuilder _General = new StringBuilder();

                #region  Trip数据表填充

                MyMeans.DropTrip();//清除原先数据
                MyMeans.InsertTrip("Trip Recorder Variable", "", "", "", "", "", "", "", "", "");


                MyMeans.InsertTrip("General", "", "", "", "描述", "", "", "", "", "");
                MyMeans.InsertTrip("", "VehDa_lSum  [m]", Genera2[0], Genera2[0], "发动机行驶总里程", "", "", "", "", "");
                MyMeans.InsertTrip("", "VehDa_tiEngOn", VehDa_tiEngOn_COLCK + "h " + VehDa_tiEngOn_MIN + "min " + VehDa_tiEngOn_SECOND + "s", Genera2[1], "发动机累积运转时间", "", "", "", "", "");
                MyMeans.InsertTrip("", "VehDa_tiECUOn", VehDa_tiECUOn_COLCK + "h " + VehDa_tiECUOn_MIN + "min " + VehDa_tiECUOn_SECOND + "s", Genera2[2], "发动机ECU运行时间", "", "", "", "", "");
                MyMeans.InsertTrip("", "VehDa_nEngRevTot [r]", Convert.ToString(Convert.ToInt64(Genera2[3]) * 1000), Convert.ToString(Convert.ToInt64(Genera2[3]) * 1000), "发动机总运转数", "", "", "", "", "");
                MyMeans.InsertTrip("", "VehDa_volFlConsumTot [l]", Convert.ToString(Convert.ToInt64(Genera2[4]) / 2), Convert.ToString(Convert.ToInt64(Genera2[4]) / 2), "发动机总油耗", "", "", "", "", "");

                //for (int i = 0; i < 5; i++)
                //{
                //    string[] SubGeneral = Genera1[i].Split('\r');
                //    string InsertDtcGeneral = SubGeneral[1].Replace(" ", "");
                //    string Sendstring1 = "21016D";
                //    int intA1 = Convert.ToInt64(Sendstring1, 16);
                //    intA1 = intA1 + i;
                //    string Sendstring2 = Convert.ToString(intA1, 16) + "\n";
                //    MyMeans.InsertTrip(Sendstring2, InsertDtcGeneral, "", "", "", "", "", "", "", "");
                //}

                MyMeans.InsertTrip("Min/Max Value", "", "单位", "最小值", "最大值", "描述", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 1: Eng_nAvrg", "[rpm]", Convert.ToString(Emp_nEngMin), Convert.ToString(Emp_nEngMax), "发动机转速", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 2: CTSCD_tClnt", "[deg C] ", Convert.ToString(CEngDst_tMin), Convert.ToString(CEngDst_tMax), "发动机水温", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 3: FTSCD_tFuel", "[deg C]", Convert.ToString(CEnhgDst_tMin), Convert.ToString(CEnhgDst_tMax), "发动机转速燃油温度", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 4: RailCD_pPeak", "[hPa]", Convert.ToString(Rall_pFltMin), Convert.ToString(Rall_PFltMax), "发动机轨压", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 5: OTSCD_tEngOil", "[deg C]", Convert.ToString(Oil_PswmpMin), Convert.ToString(Oil_PswmpMax), "发动机机油温度", "", "", "", "");
                MyMeans.InsertTrip(MaxValue_minValue, "", "", "", "", "", "", "", "", "");

                MyMeans.InsertTrip("Single  计数器", "", "单位", "范围", "数值", "描述", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 1: SIGNALS_RDLI_CoEng_st", "[-]", ">= 1.00", Convert.ToString(CounterArry[0]), "上电次数", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 2: SIGNALS_RailP_pFlt", "[hpa]", "1750000 ~ 2000000", Convert.ToString(CounterArry[1]), "轨压超压的次数", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 3: SIGNALS_Epm_nEng", "[rpm]", ">= 550.00", Convert.ToString(CounterArry[2]), "发动机转速", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 4: SIGNALS_Epm_nEng", "[rpm]", ">= 2600.00", Convert.ToString(CounterArry[3]), "发动机超速", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 5: SIGNALS_CEngDsT_t", "[deg C]", "-100.0 ~ 5.0", Convert.ToString(CounterArry[4]), "水温正常", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 6: SIGNALS_CEngDsT_t", "[deg C]", ">= 122.0 ", Convert.ToString(CounterArry[5]), "水温过热", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 7: SIGNALS_VehV_v", "[Km/h]", ">= 130", Convert.ToString(CounterArry[6]), "车速", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 8: SIGNALS_Air_tCACDs", "[deg C]", "-100.0 ~ 30.0", Convert.ToString(CounterArry[7]), "进气温度", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 9: SIGNALS_Air_tCACDs", "[deg C]", ">= 95.0", Convert.ToString(CounterArry[8]), "进气温度", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 10: SIGNALS_BattU_u", "[mV]", "0 .. 36000", Convert.ToString(CounterArry[9]), "蓄电池电压", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 11: SIGNALS_BattU_u", "[deg C]", "-100.0 .. 40.0", Convert.ToString(CounterArry[10]), "机油温度", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 12: SIGNALS_Oil_tSwmp", "[hpa]", "850 .. 1050", Convert.ToString(CounterArry[11]), "高怠速设置值低值 ", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 13: SIGNALS_RDLI_Rail_pDvt", "[hpa]", "2000 .. 5000", Convert.ToString(CounterArry[12]), "轨压偏差", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 14: SIGNALS_RDLI_EnvP_p", "[hpa]", "0 ~ 635", Convert.ToString(CounterArry[13]), "环境大气压力", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 15: SIGNALS_EnvP_p", "[hpa]", "635 ~ 1010", Convert.ToString(CounterArry[14]), "环境大气压力", "", "", "", "");
                
                //for (int x = 0; x < 1; x++)
                //{
                //    string Sendstring1 = "210165";
                //    int intA1 = Convert.ToInt64(Sendstring1, 16);
                //    intA1 = intA1 + x;
                //    string Sendstring2 = Convert.ToString(intA1, 16) + "\n";
                //    _General.Append(Sendstring2 + "      " + _0165_016BS[x] + "\n");
                //    MyMeans.InsertTrip(Sendstring2, _0165_016BS[x], "", "", "", "", "", "", "", "");
                //}

                MyMeans.InsertTrip("1 - Dimensional Maps", "", "", "", "", "", "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 1:  Eng_nAvrg   [rpm]	 发动机平均转速", "", "", "", "", "", "", "", "");
                MyMeans.InsertTrip("", " ", "2300 ~ 2500", "2500 ~ 2700", "2700 ~ 2900", "2900 ~ 3100", "", "", "", "");
                MyMeans.InsertTrip("", "", _1Dimensional_Maps_toStr[0][0], _1Dimensional_Maps_toStr[0][1], _1Dimensional_Maps_toStr[0][2], _1Dimensional_Maps_toStr[0][3], "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 2:  CTSCD_tClnt [deg C]	 冷却液温度", "", "", "", "", "", "", "", "");
                MyMeans.InsertTrip("", "", "102 ~ 107", "107 ~ 112", "112 ~ 117", "117 ~ 122", "", "", "", "");
                MyMeans.InsertTrip("", "", _1Dimensional_Maps_toStr[1][0], _1Dimensional_Maps_toStr[1][1], _1Dimensional_Maps_toStr[1][2], _1Dimensional_Maps_toStr[1][3], "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 3:  IATSCD_tAir [deg C]      进气温度", "", "", "", "", "", "", "", "");
                MyMeans.InsertTrip("", "", "80 ~ 85", "85 ~ 90", "90 ~ 95", "95 ~ 100", "", "", "", "");
                MyMeans.InsertTrip("", "", _1Dimensional_Maps_toStr[2][0], _1Dimensional_Maps_toStr[2][1], _1Dimensional_Maps_toStr[2][2], _1Dimensional_Maps_toStr[2][3], "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 4:  OTSCD_tEngOil [deg C]	 发动机机油温度", "", "", "", "", "", "", "", "");
                MyMeans.InsertTrip("", "", "115 ~ 120", "120 ~ 125", "125 ~ 130", "130 ~ 135", "", "", "", "");
                MyMeans.InsertTrip("", "", _1Dimensional_Maps_toStr[3][0], _1Dimensional_Maps_toStr[3][1], _1Dimensional_Maps_toStr[3][2], _1Dimensional_Maps_toStr[3][3], "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 5:  FTSCD_tFuel   [deg C]	 燃油温度", "", "", "", "", "", "", "", "");
                MyMeans.InsertTrip("", "", "80 ~ 85", "85 ~ 90", "90 ~ 95", "95 ~ 100", "", "", "", "");
                MyMeans.InsertTrip("", "", _1Dimensional_Maps_toStr[4][0], _1Dimensional_Maps_toStr[4][1], _1Dimensional_Maps_toStr[4][2], _1Dimensional_Maps_toStr[4][3], "", "", "", "");
                MyMeans.InsertTrip("", "Nr. 6:  RailCD_pPeak  [hPa]	 持续10毫秒最大轨道压", "", "", "", "", "", "", "", "");
                MyMeans.InsertTrip("", "", "250bar ~ 594bar", "594bar ~ 938bar", "938bar ~ 1282bar", "1282bar ~ 1625bar", "", "", "", "");
                MyMeans.InsertTrip("", "", _1Dimensional_Maps_toStr[5][0], _1Dimensional_Maps_toStr[5][1], _1Dimensional_Maps_toStr[5][2], _1Dimensional_Maps_toStr[5][3], "", "", "", "");
                //// 2wei  shuju///////////////////////////////////////////////////////////////////////////////////
                MyMeans.InsertTrip("2 - Dimensional Maps", "", "", "", "", "", "", "", "", "");
                MyMeans.InsertTrip("", " x: Eng_nAvrg[rpm] /  y: CoEng_rTrq[%]    发动机平均转速 ", "", "", "", "", "", "", "", "");
                MyMeans.InsertTrip("", "当前扭矩与最大扭矩的比率", "500 ~ 1000 ", "1000 ~ 1500", "1500 ~ 2000", "2000 ~ 2500", "", "", "", "");
                MyMeans.InsertTrip("", "94.9707 ~ 114.9658 %", _68_Dimensional_Maps_toStr[2][0], _68_Dimensional_Maps_toStr[2][1], _68_Dimensional_Maps_toStr[2][2], _68_Dimensional_Maps_toStr[2][3], "", "", "", "");
                MyMeans.InsertTrip("", "74.9756 ~ 94.9707 %", _68_Dimensional_Maps_toStr[1][0], _68_Dimensional_Maps_toStr[1][1], _68_Dimensional_Maps_toStr[1][2], _68_Dimensional_Maps_toStr[1][3], "", "", "", "");
                MyMeans.InsertTrip("", "54.9805 ~ 74.9756  %", _68_Dimensional_Maps_toStr[0][0], _68_Dimensional_Maps_toStr[0][1], _68_Dimensional_Maps_toStr[0][2], _68_Dimensional_Maps_toStr[0][3], "", "", "", "");
                MyMeans.InsertTrip("", "34.9894 ~ 54.9805  %", _68_Dimensional_Maps_toStr[5][0], _68_Dimensional_Maps_toStr[5][1], _68_Dimensional_Maps_toStr[5][2], _68_Dimensional_Maps_toStr[5][3], "", "", "", "");
                MyMeans.InsertTrip("", "14.9984 ~ 34.9894   %", _68_Dimensional_Maps_toStr[4][0], _68_Dimensional_Maps_toStr[4][1], _68_Dimensional_Maps_toStr[4][2], _68_Dimensional_Maps_toStr[4][3], "", "", "", "");
                MyMeans.InsertTrip("", "-4.9927 ~ 14.9984   %", _68_Dimensional_Maps_toStr[3][0], _68_Dimensional_Maps_toStr[3][1], _68_Dimensional_Maps_toStr[3][2], _68_Dimensional_Maps_toStr[3][3], "", "", "", "");

                MyMeans.InsertTrip("", " x: VSSCD_v[km/h] / y: CoEng_rTrq[%]   车速	 ", "", "", "", "", "", "", "", "");
                MyMeans.InsertTrip("", " 当前扭矩与最大扭矩的比率", "-5 ~ 30 ", "30 ~ 65", "65 ~ 100", "100 ~ 135", "", "", "", "");
                MyMeans.InsertTrip("", "94.9707 ~ 114.9658 %", _68_Dimensional_Maps_toStr[8][0], _68_Dimensional_Maps_toStr[8][1], _68_Dimensional_Maps_toStr[8][2], _68_Dimensional_Maps_toStr[8][3], "", "", "", "");
                MyMeans.InsertTrip("", "74.9756 ~ 94.9707 %", _68_Dimensional_Maps_toStr[7][0], _68_Dimensional_Maps_toStr[7][1], _68_Dimensional_Maps_toStr[7][2], _68_Dimensional_Maps_toStr[7][3], "", "", "", "");
                MyMeans.InsertTrip("", "54.9805 ~ 74.9756 %", _68_Dimensional_Maps_toStr[6][0], _68_Dimensional_Maps_toStr[6][1], _68_Dimensional_Maps_toStr[6][2], _68_Dimensional_Maps_toStr[6][3], "", "", "", "");
                MyMeans.InsertTrip("", "34.9894 ~ 54.9805 %", _69_Dimensional_Maps_toStr[2][0], _68_Dimensional_Maps_toStr[2][1], _68_Dimensional_Maps_toStr[2][2], _68_Dimensional_Maps_toStr[2][3], "", "", "", "");
                MyMeans.InsertTrip("", "14.9984 ~ 34.9894 %", _69_Dimensional_Maps_toStr[1][0], _68_Dimensional_Maps_toStr[1][1], _68_Dimensional_Maps_toStr[1][2], _68_Dimensional_Maps_toStr[1][3], "", "", "", "");
                MyMeans.InsertTrip("", "-4.9927 ~ 14.9984 %	", _69_Dimensional_Maps_toStr[0][0], _68_Dimensional_Maps_toStr[0][1], _68_Dimensional_Maps_toStr[0][2], _68_Dimensional_Maps_toStr[0][3], "", "", "", "");

                MyMeans.InsertTrip("", "x: Eng_nAvrg[rpm] / y: BPSCD_pOutVal[mbar]    发动机平均转速", "", "", "", "", "", "", "", "");
                MyMeans.InsertTrip("", " 增压压力传感器的输出值 ", "500 ~ 1000", "1000 ~ 1500", "1500 ~ 2000 ", " 2000 ~ 2500 ", "", "", "", "");
                MyMeans.InsertTrip("", "2500 ~ 3100	", _69_Dimensional_Maps_toStr[5][0], _68_Dimensional_Maps_toStr[5][1], _68_Dimensional_Maps_toStr[5][2], _68_Dimensional_Maps_toStr[5][3], "", "", "", "");
                MyMeans.InsertTrip("", "2100 ~ 2500	", _69_Dimensional_Maps_toStr[4][0], _68_Dimensional_Maps_toStr[4][1], _68_Dimensional_Maps_toStr[4][2], _68_Dimensional_Maps_toStr[4][3], "", "", "", "");
                MyMeans.InsertTrip("", "1600 ~ 2100	", _69_Dimensional_Maps_toStr[3][0], _68_Dimensional_Maps_toStr[3][1], _68_Dimensional_Maps_toStr[3][2], _68_Dimensional_Maps_toStr[3][3], "", "", "", "");

                MyMeans.InsertTrip("", "x: Eng_nAvrg[rpm] / y: RailCD_pPeak[bar]      发动机平均转速", "", "", "", "", "", "", "", "");
                MyMeans.InsertTrip("", " 持续10毫秒最大轨道压力 ", "500 ~ 1000", "1000 ~ 1500", "1500 ~ 2000 ", " 2000 ~ 2500 ", "", "", "", "");
                MyMeans.InsertTrip("", "1200~ 1650	", _69_Dimensional_Maps_toStr[8][0], _68_Dimensional_Maps_toStr[8][1], _68_Dimensional_Maps_toStr[8][2], _68_Dimensional_Maps_toStr[8][3], "", "", "", "");
                MyMeans.InsertTrip("", "650 ~ 1200	", _69_Dimensional_Maps_toStr[7][0], _68_Dimensional_Maps_toStr[7][1], _68_Dimensional_Maps_toStr[7][2], _68_Dimensional_Maps_toStr[7][3], "", "", "", "");
                MyMeans.InsertTrip("", "100 ~ 650	", _69_Dimensional_Maps_toStr[6][0], _68_Dimensional_Maps_toStr[6][1], _68_Dimensional_Maps_toStr[6][2], _68_Dimensional_Maps_toStr[6][3], "", "", "", "");

                #endregion
                //for (int x = 2; x < 5; x++)
                //{
                //    string Sendstring1 = "210165";
                //    int intA1 = Convert.ToInt64(Sendstring1, 16);
                //    intA1 = intA1 + x;
                //    string Sendstring2 = Convert.ToString(intA1, 16) + "\n";
                //    _General.Append(Sendstring2 + "      " + _0165_016BS[x] + "\n");
                //    MyMeans.InsertTrip(Sendstring2, _0165_016BS[x], "", "", "", "", "", "", "", "");
                //}
            }
            catch (Exception e) {

                log.Info("tp insert data to db is error: " +  e.Message);
            }

        }




    }
}
