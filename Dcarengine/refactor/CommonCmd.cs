using Dcarengine.Function_Class;
using Dcarengine.serialPort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dcarengine.refactor
{
    class CommonCmd
    {
        public static byte[] ATE0;

        /// <summary>
        /// ATE1
        /// </summary>
        public static byte[] ATE1;

        public static byte[] ClearCmd;

        public static  byte[] _21f0;

        public static  byte[]  ecuVersionCmd;

        public static byte[] _1081;

        public static byte[] ClearDtcCmd;

        public static byte[]  ATR;

        /// <summary>
        /// 芯片溢出时间为200MS
        /// </summary>
        public static byte[] ATST00;

        /// <summary>
        /// ATSTFF
        /// </summary>
        public static byte[] ATSTFF;

        public static byte[] ATST0F;

        /// <summary>
        /// 返回78  数据
        /// </summary>
        public static byte[] ATSTD6; 

        public static byte[] _830300D610140A;

        public static byte[] ATSW00;

        public static byte[] ATSW19;

        public static byte[] ATSW30;

        public static byte[] _830300D600140A;

        public static byte[] _109214;

        //
        public static byte[] _808002;
        public static byte[] _808001;
        public static byte[] _808000;
        public static byte[] _808003;

        //
        public static byte[] _808100;
        public static byte[] _808101;
        public static byte[] _808102;
        public static byte[] _808103;


        public static byte[] ATSH81_10_F1;
        /**
         * ATBD
         * 
         */
        public static byte[] ATBD;

        public static byte[] _36;

        public static byte[] _37;

        public static byte[] _1101;

        public static byte[] _3180;

        public static byte[] _3380;

       
        //
        public static byte[] _1086;

        //public static byte[] _3380;

        /**
         * eol区域
         */
        public static String  EolDateperfix = "80 81 02 31 32 33 34 35 36 17 03 E2";



        /// <summary>
        /// 总油耗
        /// </summary>
        public static byte[]  _allOilCost; 
        /// <summary>
        /// 总里程
        /// </summary>
        public static byte[]  _allTrip;
        /// <summary>
        /// 总时间
        /// </summary>
        public static byte[]  _allEngineTime;
        /// <summary>
        /// Ecu 总时间
        /// </summary>
        public static byte[]  _ecuAllTime;

        /// <summary>
        /// 发动机总 转数
        /// </summary>
        public static byte[] _ecuRevolutions;

        /// <summary>
        ///高压轨泄压阀
        /// </summary>
        public static byte[]  hiByte;
        public static byte[]  hiOneByte;


        /// <summary>
        /// 行驶记录
        /// </summary>
        public static byte[] trip165;
        public static byte[] trip166;
        public static byte[] trip167;
        public static byte[] trip168;
        public static byte[] trip169;
        public static byte[] trip16c;


        public static byte[] _331bfe;
        public static byte[] _331bfd;
        public static byte[] _331bce;
        public static byte[] _331bcf;
        public static byte[] _331b;

        /// <summary>
        /// compressionTest
        /// </summary>
        public static byte[] _CompressionTest;
        public static byte[] _3318;

        public static byte[] _HighPressureTest;
        public static byte[] _3314;

        public static string _runUptestsuffix = "000005DC0640001817700BB8000002EE038E000002EE055501C7080000000000000000";
        public static string _runUptestprefix= "3116";
        public static byte[] _3316;

        //speed
        public static String speedprefix = "311A0100";
        public static String speedsuffix = "012C00020010";
        public static byte[] _speed;
        public static byte[] _331A;

        //shut 
        public static String shutprefix = "311500";
        public static byte[] _3315;
        //public static String speedsuffix = "012C00020010";
        //public static byte[] _speed;
        //public static byte[] _331A;


        /// <summary>
        /// 静态变量
        /// </summary>
        static CommonCmd(){


            //1086
            _1086 = StringToSendBytes.bytesToSend("1086\n");
            ///
            _allOilCost = StringToSendBytes.bytesToSend("210171\n");
            _allTrip = StringToSendBytes.bytesToSend("21016D\n");
            _allEngineTime = StringToSendBytes.bytesToSend("21016E\n");
            _ecuAllTime = StringToSendBytes.bytesToSend("21016F\n");
            _ecuRevolutions = StringToSendBytes.bytesToSend("210170\n");
            ///
            hiByte = StringToSendBytes.bytesToSend("2102F4\n");
            hiOneByte = StringToSendBytes.bytesToSend("2102F5\n");
            ///
            trip165 = StringToSendBytes.bytesToSend("210165\n");
            trip166 = StringToSendBytes.bytesToSend("210166\n");
            trip167 = StringToSendBytes.bytesToSend("210167\n");
            trip168 = StringToSendBytes.bytesToSend("210168\n");
            trip169 = StringToSendBytes.bytesToSend("210169\n");
            trip16c = StringToSendBytes.bytesToSend("21016c\n");
            ///

            ATE0 = StringToSendBytes.bytesToSend("ATE0\n");

            ATE1 = StringToSendBytes.bytesToSend("ATE1\n");

            ClearCmd = StringToSendBytes.bytesToSend("2CF004\n");

            //_21f0 = StringToSendBytes.bytesToSend("2cf004\n");
            /// 
            _21f0 = StringToSendBytes.bytesToSend("21F0\n");

            ecuVersionCmd = StringToSendBytes.bytesToSend("1A94\n");

            _1081 = StringToSendBytes.bytesToSend("1081\n");

            ClearDtcCmd = StringToSendBytes.bytesToSend("14FF00\n");

            ATR = StringToSendBytes.bytesToSend("AT@R\n");

            ATST0F = StringToSendBytes.bytesToSend("ATST0F\n");

            ATST00 = StringToSendBytes.bytesToSend("ATST00\n");

            ATSTD6 = StringToSendBytes.bytesToSend("ATSTFF\n");

            _830300D610140A = StringToSendBytes.bytesToSend("830300D610140A\n");

            ATSW00 = StringToSendBytes.bytesToSend("ATSW00\n");

            ATSW19 = StringToSendBytes.bytesToSend("ATSW19\n");

            ATSTFF = StringToSendBytes.bytesToSend("ATSTFF\n");

            ATSW30 = StringToSendBytes.bytesToSend("ATSW30\n");
            //8303
            _830300D600140A = StringToSendBytes.bytesToSend("830300D600140A\n");
            _109214 = StringToSendBytes.bytesToSend("109214\n");


            ///
            _808002 = StringToSendBytes.bytesToSend("808002\n");
            _808001 = StringToSendBytes.bytesToSend("808001\n");
            _808003 = StringToSendBytes.bytesToSend("808003\n");
            _808000 = StringToSendBytes.bytesToSend("808000\n");

            ///数据列表
            _808100 = StringToSendBytes.bytesToSend("80 81 00 31 32 33 34 35 36 17 03 E2\n");
            _808101 = StringToSendBytes.bytesToSend("80 81 01 31 32 33 34 35 36 17 03 E2\n");
            _808102 = StringToSendBytes.bytesToSend("80 81 02 31 32 33 34 35 36 17 03 E2\n");
            _808103 = StringToSendBytes.bytesToSend("80 81 03 31 32 33 34 35 36 17 03 E2\n");



            ATBD = StringToSendBytes.bytesToSend("ATBD\n");

            _36 = StringToSendBytes.bytesToSend("36\n");

            _37 = StringToSendBytes.bytesToSend("37\n");

            _1101 = StringToSendBytes.bytesToSend("1101\n");

            _3180= StringToSendBytes.bytesToSend("3180\n");

            _3380 = StringToSendBytes.bytesToSend("3380\n");

            ATSH81_10_F1 = StringToSendBytes.bytesToSend("ATSH8110F1\n");

            _331bfe = StringToSendBytes.bytesToSend("311B00000000000000FE00" + "\n");
            _331bfd = StringToSendBytes.bytesToSend("311B00000000000000FD00" + "\n");
            _331bce = StringToSendBytes.bytesToSend("311B00000000000000FE00" + "\n");
            _331bcf = StringToSendBytes.bytesToSend("311B00000000000000FE00" + "\n");
            _331b = StringToSendBytes.bytesToSend("331b\n");

            _CompressionTest = StringToSendBytes.bytesToSend("31180000C8001401110222F667F334"+ "\n");
            _3318 = StringToSendBytes.bytesToSend("3318\n");
            //
            _HighPressureTest = StringToSendBytes.bytesToSend("311400010030D40DAC11940DAC03E82CEC1F4006A407D00D480ED80AF0012C"+"\n");
            _3314 = StringToSendBytes.bytesToSend("3314\n");

            _3316 = StringToSendBytes.bytesToSend("3316\n");

            _331A = StringToSendBytes.bytesToSend("331A\n");

            _3315 = StringToSendBytes.bytesToSend("3315\n");

        }


        /// <summary>
        /// send ATE1  init 
        /// </summary>
        public static void SendATE1() {

            GobalSerialPort.WriteByMessage(CommonCmd.ATE1, 0, CommonCmd.ATE1.Length);

        }


        /// <summary>
        /// send ATE1  init 
        /// </summary>
        public static void SendATE1ByThread()
        {

            GobalSerialPort.WriteByMessage(CommonCmd.ATE1, 0, CommonCmd.ATE1.Length);

        }


    }
}
