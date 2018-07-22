using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dcarengine.Function_Class;
using Dcarengine.interfaces;
using Dcarengine.refactor;
using Dcarengine.serialPort;
using Dcarengine.SQLData;
using Dcarengine.UIForm;

namespace Dcarengine.service
{
    /// <summary>
    /// 读取ECU ID 问题
    /// </summary>
    class C13IdRead : IDReadInterface
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //这里是ecu13的数据，具体含义不懂     
        //这个是ID命令的字符串    ...
        static string[] C13ecuIdstrCmd1 = new string[2];
        static string[] C13ecuIdstrCmd2 = new string[2];
        static string[] C13ecuIdstrCmd3 = new string[2];
        static string[] C13ecuIdstrCmd4 = new string[1];
        static string[] C13ecuIdstrCmd5 = new string[1];
        static string[] C13ecuIdstrCmd6 = new string[6];
        static string[] C13ecuIdstrCmd7 = new string[9];
        // Id信息初始化数据 
        static byte[][] C13ecuIdstring1Tobyte = new byte[2][];
        static byte[][] C13ecuIdstring2Tobyte = new byte[2][];
        static byte[][] C13ecuIdstring3Tobyte = new byte[2][];
        static byte[][] C13ecuIdstring4Tobyte = new byte[1][];
        static byte[][] C13ecuIdstring5Tobyte = new byte[1][];
        static byte[][] C13ecuIdstring6Tobyte = new byte[6][];
        static byte[][] C13ecuIdstring7Tobyte = new byte[9][];

        ////用来存放转化的ECU13的字符串、、、、、、
        public static string[] ECUstringtochangeASCII = new string[23];
        //这里是解析后的ECU数字码。。。。。。涉及地点;读取ID线程()
        ///用来标记所转化的Ecu代码的个数啊。。。。。
        static int ECUstringtochangeNum = 0;                                 


        /// <summary>
        /// readId
        /// </summary>
        public void ReadEcuId()
        {

            throw new NotImplementedException();

        }


        /// <summary>
        /// 构造函数
        /// </summary>
        public  C13IdRead()
        {

            //初始化数据
            ToSendEcu13IdF();

        }

        /// <summary>
        /// 静态
        /// </summary>
         static C13IdRead() {

            GobalSerialPort.WriteByMessage(CommonCmd.ATE1, 0, CommonCmd.ATE1.Length);

        }


        /// <summary>
        /// 字符串 写入初始化
        /// </summary>
        private static void ToSendEcu13IdF()
        {
            int C13ecunum1 = 128;
            int C13ecunum2 = 134;
            int C13ecunum3 = 137;
            int C13ecunum4 = 140;
            int C13ecunum5 = 142;
            int C13ecunum6 = 144;
            int C13ecunum7 = 151;

            for (int i = 0; i < 2; i++)
            {
                C13ecuIdstring1Tobyte[i] = new byte[6];                       //这里是ecu数据的第一段
            }
            for (int i = 0; i < 2; i++)
            {
                C13ecuIdstrCmd1[i] = "1A" + C13ecunum1.ToString("X");
                C13ecunum1++;
                C13ecuIdstring1Tobyte[i] = StringToSendBytes.bytesToSend(C13ecuIdstrCmd1[i] + "\n");
            }
            //这里是ecu数据的第二段，两个循环的数据

            for (int i = 0; i < 2; i++)
            {
                C13ecuIdstring2Tobyte[i] = new byte[6];                     //这里是ecu数据的第二段
            }
            for (int i = 0; i < 2; i++)
            {
                C13ecuIdstrCmd2[i] = "1A" + C13ecunum2.ToString("X");
                C13ecunum2++;
                C13ecuIdstring2Tobyte[i] = StringToSendBytes.bytesToSend(C13ecuIdstrCmd2[i] + "\n");

            }
            //three
            for (int i = 0; i < 2; i++)
            {
                C13ecuIdstring3Tobyte[i] = new byte[6];                     //这里是ecu数据的第san段
            }
            for (int i = 0; i < 2; i++)
            {
                C13ecuIdstrCmd3[i] = "1A" + C13ecunum3.ToString("X");
                C13ecunum3++;
                C13ecuIdstring3Tobyte[i] = StringToSendBytes.bytesToSend(C13ecuIdstrCmd3[i] + "\n");

            }
            //这里是第四段程序
            for (int i = 0; i < 1; i++)
            {
                C13ecuIdstring4Tobyte[i] = new byte[6];
            }
            for (int i = 0; i < 1; i++)
            {  // Ecustring1Tobyte[i]=new byte[6];
                C13ecuIdstrCmd4[i] = "1A" + C13ecunum4.ToString("X");
                C13ecunum4++;
                C13ecuIdstring4Tobyte[i] = StringToSendBytes.bytesToSend(C13ecuIdstrCmd4[i] + "\n");

            }

            //这里是第五段程序

            for (int i = 0; i < 1; i++)
            {
                C13ecuIdstring5Tobyte[i] = new byte[6];
            }
            for (int i = 0; i < 1; i++)
            {
                C13ecuIdstrCmd5[i] = "1A" + C13ecunum5.ToString("X");
                C13ecunum5++;
                C13ecuIdstring5Tobyte[i] = StringToSendBytes.bytesToSend(C13ecuIdstrCmd5[i] + "\n");
            }

            for (int i = 0; i < 6; i++)
            {
                C13ecuIdstring6Tobyte[i] = new byte[6];
            }
            for (int i = 0; i < 6; i++)
            {
                C13ecuIdstrCmd6[i] = "1A" + C13ecunum6.ToString("X");
                C13ecunum6++;
                C13ecuIdstring6Tobyte[i] = StringToSendBytes.bytesToSend(C13ecuIdstrCmd6[i] + "\n");

            }
            for (int i = 0; i < 9; i++)
            {
                C13ecuIdstring7Tobyte[i] = new byte[6];
            }
            for (int i = 0; i < 9; i++)
            {
                C13ecuIdstrCmd7[i] = "1A" + C13ecunum7.ToString("X");
                C13ecunum7++;
                C13ecuIdstring7Tobyte[i] = StringToSendBytes.bytesToSend(C13ecuIdstrCmd7[i] + "\n");
            }
        }



        /// <summary>
        /// 数据写入
        /// </summary>
        public static void CmdWrite() {

           
            try
            {
                for (int i = 0; i < 2; i++)
                {

                    GobalSerialPort.WriteByMessage(C13ecuIdstring2Tobyte[i], 0, C13ecuIdstring2Tobyte[i].Length);

                    ECUstringtochangeASCII[ECUstringtochangeNum] = GobalSerialPort.ResultBackString;
                    ECUstringtochangeNum++;

                }
                for (int i = 0; i < 2; i++)
                {
                    GobalSerialPort.WriteByMessage(C13ecuIdstring3Tobyte[i], 0, C13ecuIdstring3Tobyte[i].Length);
                    ECUstringtochangeASCII[ECUstringtochangeNum] = GobalSerialPort.ResultBackString;
                    ECUstringtochangeNum++;
                }
                for (int i = 0; i < 1; i++)
                {
                    GobalSerialPort.WriteByMessage(C13ecuIdstring4Tobyte[i], 0, C13ecuIdstring4Tobyte[i].Length);

                    ECUstringtochangeASCII[ECUstringtochangeNum] = GobalSerialPort.ResultBackString;
                    ECUstringtochangeNum++;
                }
                for (int i = 0; i < 1; i++)
                {
                    GobalSerialPort.WriteByMessage(C13ecuIdstring5Tobyte[i], 0, C13ecuIdstring5Tobyte[i].Length);

                    ECUstringtochangeASCII[ECUstringtochangeNum] = GobalSerialPort.ResultBackString;
                    ECUstringtochangeNum++;
                }
                for (int i = 0; i < 6; i++)
                {
                    GobalSerialPort.WriteByMessage(C13ecuIdstring6Tobyte[i], 0, C13ecuIdstring6Tobyte[i].Length);

                    ECUstringtochangeASCII[ECUstringtochangeNum] = GobalSerialPort.ResultBackString;
                    ECUstringtochangeNum++;
                }
                for (int i = 0; i < 9; i++)
                {
                    GobalSerialPort.WriteByMessage(C13ecuIdstring7Tobyte[i], 0, C13ecuIdstring7Tobyte[i].Length);

                    ECUstringtochangeASCII[ECUstringtochangeNum] = GobalSerialPort.ResultBackString;
                    ECUstringtochangeNum++;
                }
            }
            catch
            {

            }
            ECUstringtochangeNum = 0;


        }



        /// <summary>
        /// 数据解析 进入数据库
        /// </summary>
        public static void  WorkOutToDb()
        {           
            _13IdFDataWork.InsertAcessF_7(ECUstringtochangeASCII[0]);      //86 
            MyMeans.InsertAccess("86", "客户字符串0", "ASCII/10", _13IdFDataWork.WorkOutData, ECUstringtochangeASCII[0]);
            
            _13IdFDataWork.InsertAcessF_10(ECUstringtochangeASCII[1]);  //87 
            MyMeans.InsertAccess("87", "ECU软件版本号", "ASCII/64", _13IdFDataWork.WorkOutData, ECUstringtochangeASCII[1]);

            _13IdFDataWork.InsertAcessF_7(ECUstringtochangeASCII[2]);       //89
            MyMeans.InsertAccess("89", "客户字符串1", "ASCII/10", _13IdFDataWork.WorkOutData, ECUstringtochangeASCII[2]);

            _13IdFDataWork.InsertAcessF_10(ECUstringtochangeASCII[3]);       //8a
            log.Info("13id 1a8a :" + _13IdFDataWork.WorkOutData);
            MyMeans.InsertAccess("8A", "ECU软件系统号", "ASCII/100", _13IdFDataWork.WorkOutData, ECUstringtochangeASCII[3]);

            _13IdFDataWork.InsertAcessF_1A8C(ECUstringtochangeASCII[4]);       //8c
            MyMeans.InsertAccess("8C", "SCD协议版本", "Unsigned/1", _13IdFDataWork.WorkOutData, ECUstringtochangeASCII[4]);

            _13IdFDataWork.InsertAcessF_7(ECUstringtochangeASCII[5]);       //8e
            MyMeans.InsertAccess("8E", "EEPROM数据集标识", "ASCII/40", _13IdFDataWork.WorkOutData, ECUstringtochangeASCII[5]);

            _13IdFDataWork.InsertAcessF_7(ECUstringtochangeASCII[6]);       //90
            MyMeans.InsertAccess("90", "车辆识别号码", "ASCII/17", _13IdFDataWork.WorkOutData, ECUstringtochangeASCII[6]);

            _13IdFDataWork.InsertAcessF_7(ECUstringtochangeASCII[7]);       //91
            MyMeans.InsertAccess("91", "ECU硬件编号", "ASCII/13", _13IdFDataWork.WorkOutData, ECUstringtochangeASCII[7]);

            _13IdFDataWork.InsertAcessF_7(ECUstringtochangeASCII[8]);       //92
            MyMeans.InsertAccess("92", "ECU硬件系统编号", "ASCII/8", _13IdFDataWork.WorkOutData, ECUstringtochangeASCII[8]);

            _13IdFDataWork.InsertAcessF_7(ECUstringtochangeASCII[9]);       //93
            MyMeans.InsertAccess("93", "ECU硬件版本号", "ASCII/8", _13IdFDataWork.WorkOutData, ECUstringtochangeASCII[9]);

            _13IdFDataWork.InsertAcessF_7(ECUstringtochangeASCII[10]);       //94
            MyMeans.InsertAccess("94", "ECU软件系统编号", "ASCII/26", _13IdFDataWork.WorkOutData, ECUstringtochangeASCII[10]);

            _13IdFDataWork.InsertAcessF_7(ECUstringtochangeASCII[12]);       //97
            MyMeans.InsertAccess("97", "发动机类型", "ASCII/15", _13IdFDataWork.WorkOutData, ECUstringtochangeASCII[12]);

            _13IdFDataWork.InsertAcessF_7(ECUstringtochangeASCII[13]);       //98
            MyMeans.InsertAccess("98", "维修站代码或诊断仪序列号", "ASCII/10", _13IdFDataWork.WorkOutData, ECUstringtochangeASCII[13]);

            _13IdFDataWork.InsertAcessF_7(ECUstringtochangeASCII[14]);       //99
            MyMeans.InsertAccess("99", "编程日期", "BCD/3", _13IdFDataWork.WorkOutData, ECUstringtochangeASCII[14]);

            _13IdFDataWork.InsertAcessF_7(ECUstringtochangeASCII[15]);       //9a
            MyMeans.InsertAccess("9A", "发动机测试日期", "BCD/3", _13IdFDataWork.WorkOutData, ECUstringtochangeASCII[15]);

            _13IdFDataWork.InsertAcessF_7(ECUstringtochangeASCII[16]);       //9b
            MyMeans.InsertAccess("9B", "数据集识别", "ASCII/30", _13IdFDataWork.WorkOutData, ECUstringtochangeASCII[16]);

            _13IdFDataWork.InsertAcessF_7(ECUstringtochangeASCII[17]);       //9c
            MyMeans.InsertAccess("9C", "客户字符串2", "ASCII/10", _13IdFDataWork.WorkOutData, ECUstringtochangeASCII[17]);

            _13IdFDataWork.InsertAcessF_7(ECUstringtochangeASCII[18]);       //9d
            MyMeans.InsertAccess("9D", "客户字符串3", "ASCII/10", _13IdFDataWork.WorkOutData, ECUstringtochangeASCII[18]);

            _13IdFDataWork.InsertAcessF_7(ECUstringtochangeASCII[19]);       //9e
            MyMeans.InsertAccess("9E", "客户字符串4", "ASCII/10", _13IdFDataWork.WorkOutData, ECUstringtochangeASCII[19]);

            _13IdFDataWork.InsertAcessF_7(ECUstringtochangeASCII[20]);       //9f
            MyMeans.InsertAccess("9F", "客户字符串5", "ASCII/10", _13IdFDataWork.WorkOutData, ECUstringtochangeASCII[20]);
        }

        /// <summary>
        /// DbDataToExcel
        /// </summary>
        public static void DbDataToExcel() {

            SaveFileFunction.id_SaveExcel();

        }


        /// <summary>
        //  运行开始方法
        /// </summary>
        public static void workRun() {


            CommonCmd.SendATE1();

            //GobalSerialPort.GobalSerialPortEnventChange();

            ToSendEcu13IdF();

            CmdWrite();

            WorkOutToDb();

            MainF.ShowBoxTex("读取ID完毕");

            DbDataToExcel();
        }




    }
}

