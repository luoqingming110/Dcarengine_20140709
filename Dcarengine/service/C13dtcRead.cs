using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Dcarengine.Function_Class;
using Dcarengine.interfaces;
using Dcarengine.refactor;
using Dcarengine.serialPort;
using Dcarengine.SQLData;
using Dcarengine.UIForm;

namespace Dcarengine.service
{
    class _13dtcRead :IDtcReadInterface
    {

        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 静态变量处理，线程中数据，数据必须保持在同一线程中
        /// </summary>
        public static string[]  ECU13DTC;
        /// <summary>
        /// 单个故障代码
        /// </summary>
        public static String ECU13DTCSingle;
        //获取数据
        public static string    StringOfGets;
        //这里是保存17发动机返回回来的代码用于显示在其他的窗口上所以是静态的 ；
        public static string[]  Save13BackDTC;
        /// <summary>
        ///单个返回数据
        /// </summary>
        public static string Save13BackDTCSingle;

        public static string[]  C13BackTDNumCode;

        /// <summary>
        /// 静态函数
        /// </summary>
        static _13dtcRead() {

            GobalSerialPort.WriteByMessage(CommonCmd.ATE1, 0, CommonCmd.ATE1.Length);

        }

        /// <summary>
        /// read dtc code
        /// </summary>
        public static void ReadECU13DTC()
        {

            CommonCmd.SendATE1();
            GobalSerialPort.ClearSendAndRecive();
            try
            {
                byte[] stringToalldtccodeA = StringToSendBytes.bytesToSend("1800FF00\n");       //发送命令的一个转化
                GobalSerialPort.WriteByMessage(stringToalldtccodeA, 0, stringToalldtccodeA.Length);
                StringOfGets = GobalSerialPort.ResultBackString;
                string[] splitstring = StringOfGets.Split('\r');
                if (splitstring[1] != null && (!splitstring[1].Contains("NO")))
                {
                    string result = splitstring[1];
                    string ss = result;
                    ss = result.Replace(" ", "");                                    //这里是将空格改为空的字符串，但是还有其他的方法
                    string sub = ss.Substring(2, 2);
                    string subtostr = sub.ToString();
                    int subtoint = Convert.ToInt32(subtostr, 16);       //subint 是表示有多少个故障代码
                    string[] strsubtring = new string[subtoint];          //strsubtring  表示要开辟多少个字符串数组
                    ECU13DTC = new string[subtoint];
                    int[] strsubtint = new int[subtoint];
                    Console.WriteLine(subtoint);
                    byte[][] C13DTwrite = new byte[subtoint][];
                    Save13BackDTC = new string[subtoint];
                    C13BackTDNumCode = new string[subtoint];
                    for (int i = 0; i < subtoint; i++)
                    {
                        C13DTwrite[i] = new byte[8];
                    }
                    //初始化数据
                    SingleDtcFunction singleDtcFunction = new SingleDtcFunction();
                    MyMeans.DropDTC();   //清除原先数据
                    MyMeans.AccessLink();
                    int x = 4;
                    for (int i = 0; i < subtoint; i++)
                    {
                        strsubtring[i] = ss.Substring(x, 6);
                        x = x + 6;
                        strsubtring[i] = strsubtring[i].Substring(0, 4);
                        C13BackTDNumCode[i] = strsubtring[i];
                        int TheoneString = Convert.ToInt32(strsubtring[i].Substring(0, 1), 16);
                        int _16TheoneString = int.Parse(TheoneString.ToString("X"), System.Globalization.NumberStyles.HexNumber);
                        string ThethreeString = strsubtring[i].Substring(1, 3);
                        //将前面的一个数据去掉前面的两位
                        string SUBba = Convert.ToString(_16TheoneString, 2).PadLeft(4, '0');
                        string C = SUBba.Substring(2, 2);
                        string D = "00" + C;
                        string Fianba = (Convert.ToInt32("00" + C)).ToString("X");
                        string Fianba1 = Convert.ToInt32(D, 2).ToString();
                        strsubtring[i] = Fianba1 + ThethreeString;
                        ECU13DTC[i] = strsubtring[i];
                        ECU13DTCSingle = strsubtring[i];
                        strsubtring[i] = "17" + strsubtring[i];
                        C13DTwrite[i] = StringToSendBytes.bytesToSend(strsubtring[i] + "\n");
                        try
                        {
                            GobalSerialPort.WriteByMessage(C13DTwrite[i], 0, C13DTwrite[0].Length);
                            StringOfGets = GobalSerialPort.ResultBackString;
                            Save13BackDTC[i] = StringOfGets;
                            Save13BackDTCSingle = StringOfGets;
                            //Date
                            int count = i + 1;
                            singleDtcFunction.ShowDtcCodeF(count);
                        }
                        catch (Exception e)
                        {
                            log.Info("the  error fo message is :" + e.Message);
                            continue;
                        }
                    }
                    MainF.ShowBoxTex("读取故障完毕");
                    MyMeans.AccessBreak();
                    SaveFileFunction.Dtc_SaveExcel();
                }
            }
            catch(Exception e){
                SaveFileFunction.Dtc_SaveExcel();
                log.Info("Dtc final  error :" +  e.Message);
            }
            
        }


        /// <summary>
        /// 清除故障
        /// </summary>
        public static  void Cleardtc()
        {         
            GobalSerialPort.WriteByMessage(CommonCmd.ClearDtcCmd, 0, CommonCmd.ClearDtcCmd.Length);
            string backresult= GobalSerialPort.ResultBackString;
            if (backresult.Contains("54") && backresult.Contains("FF") && backresult.Contains("00"))
            {
                MainF.ShowBoxTex("清除故障成功!");
            }
        }


        /// <summary>
        /// byte 数据类型
        /// </summary>
        public static  void CleardtcByByte()
        {
            Byte[] byte4 = new Byte[8];
            byte4[0] = 0x31;
            byte4[1] = 0x34;
            byte4[2] = 0x66;
            byte4[3] = 0x66;
            byte4[4] = 0x30;
            byte4[5] = 0x30;
            byte4[6] = 0x0D;
            byte4[7] = 0x0A;

            GobalSerialPort.WriteByMessage(CommonCmd.ATST00, 0, CommonCmd.ATST00.Length);
            Thread.Sleep(400);
            GobalSerialPort.WriteByMessage(byte4, 0, byte4.Length);
            Thread.Sleep(400);
            GobalSerialPort.WriteByMessage(CommonCmd.ATST0F, 0, CommonCmd.ATST0F.Length);
            string backresult = GobalSerialPort.ResultBackString;
            if (backresult.Contains("54") && backresult.Contains("FF") && backresult.Contains("00"))
            {
                MainF.ShowBoxTex("清除故障成功!");
            }
        }


    }
}
