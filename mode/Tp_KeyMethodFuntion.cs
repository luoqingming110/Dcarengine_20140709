using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Dcarengine.Function_Class;
using Dcarengine.refactor;
using System.Collections;

namespace Dcarengine.Function_Class
{
    class Tp_KeyMethodFuntion
    {

        //private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// threadFlag  
        /// </summary>
        private int threadFlag = 0;


        private static readonly object obj = new object();



        public static byte[] bytesToSend(string SendSTring)
        {
            int SendstringLength = SendSTring.Length;
            byte[] _RSendstringbytes = new byte[SendstringLength + 1];
            byte[] Sendstringbytes = System.Text.ASCIIEncoding.Default.GetBytes(SendSTring + "");

            for (int i = 0; i < Sendstringbytes.Length - 1; i++)
            {
                //  Sendstringbytes[i] = Convert.ToByte(Sendstringbytes[i].ToString("X"));
                Sendstringbytes[i] = Byte.Parse(Sendstringbytes[i].ToString("X"), System.Globalization.NumberStyles.HexNumber);
                _RSendstringbytes[i] = Sendstringbytes[i];
            }
            _RSendstringbytes[SendstringLength - 1] = 0x0D;
            _RSendstringbytes[SendstringLength] = 0x0A;
            //  serialPort1.Write(ByteSend, 0, ByteSend.Length);
            return _RSendstringbytes;
        }


        /// <summary>
        /// KEYMEHOD
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private static UInt32 KEYMethod(UInt32 num, string version,string mode)
        {
            UInt32 key;
            UInt32 a = num;
            if (CommonConstant.mode != null || !"".Equals(mode))
            {
                Hashtable keyTable = ModeKeyMap.GetHashtable(version);
                String keyValue = Convert.ToString(keyTable[mode]);
                UInt32 maskVale = UInt32.Parse(keyValue);
                for (int j = 0; j < 35; j++)
                {
                    string z = Convert.ToString(a, 2).PadLeft(32, '0');   //Console.WriteLine("{0},{1}", z, z.Length);
                    string x = z.Substring(0, 1);
                    a = a << 1;
                    if (x == "1")
                    {
                        key = a ^ maskVale;
                        a = key;
                    }
                }
            }
            return a;
        }



        private static int i = 3;

        /// <summary>
        /// con
        /// </summary>
        public static string Con(string value, string version,string mode)
        {
            try
            {
                //byte[] _2709Str = bytesToSend(CommonConstant.EcuModeSendMap[CommonConstant.mode] + "\n");
                //GobalSerialPort.WriteByMessage(_2709Str, 0, _2709Str.Length);
                //string BackString = GobalSerialPort.ResultBackString;     //   "2709\r67 09 76 BB DD EE \r\n\r\n>"
                //string[] Backs = BackString.Split('\r');
                //string Back1 = Backs[1].Replace(" ", "");
                string Back1 = value.Replace(" ","");
                //如果有8位长度 00 00 00 00 表示已经正常进入
                if (Back1.Equals("00000000"))
                {
                    return "00000000";
                }
                UInt32 b = UInt32.Parse(Back1, System.Globalization.NumberStyles.HexNumber);     //最后得到的 b 的值是 171。
                string _270AStr = Convert.ToString(KEYMethod(b, version,mode), 16).PadLeft(8, '0');
               // _270AStr = CommonConstant.EcuModeSendSecondeMap[mode] + _270AStr + "\n";
               // byte[] _270AByte = bytesToSend(_270AStr);

                return _270AStr;
            }
            catch (Exception e)
            {
               Console.WriteLine( e.ToString() );
            }
            return "";
        }



   

        /// <summary>
        /// confunction
        /// </summary>
        public void confuntion()
        {

            //    byte[] _2709Str = bytesToSend(CommonConstant.EcuModeSendMap[CommonConstant.mode] + "\n");
            //    GobalSerialPort.WriteByMessage(_2709Str, 0, _2709Str.Length);
            //    string BackString = GobalSerialPort.ResultBackString;     //   "2709\r67 09 76 BB DD EE \r\n\r\n>"
            //    string[] Backs = BackString.Split('\r');
            //    string Back1 = Backs[1].Replace(" ", "");
            //    Back1 = Back1.Substring(4, 8);
            //    //如果有8位长度 00 00 00 00 表示已经正常进入
            //    if (Back1.Equals("00000000"))
            //    {
            //        return;
            //    }
            //    UInt32 b = UInt32.Parse(Back1, System.Globalization.NumberStyles.HexNumber);     //最后得到的 b 的值是 171。
            //    string _270AStr = Convert.ToString(KEYMethod(b), 16).PadLeft(8, '0');
            //    _270AStr = CommonConstant.EcuModeSendSecondeMap[CommonConstant.mode] + _270AStr + "\n";
            //    byte[] _270AByte = bytesToSend(_270AStr);
            //    GobalSerialPort.WriteByMessage(_270AByte, 0, _270AByte.Length);
            //    BackString = GobalSerialPort.ResultBackString;   //Byte to send
            //    int i = 10;
            //    //递归算法
            //    if (!BackString.Contains("67"))
            //    {

            //        while (i > 0)
            //        {
            //            i--;
            //            Con();

            //        }
            //    }
            //    else {threadFlag++;}
            //    //正常退出机制
            //    threadFlag++;
            //}
        }
    }

    
}
