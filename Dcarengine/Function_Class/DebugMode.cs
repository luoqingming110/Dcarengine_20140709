using Dcarengine.serialPort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dcarengine.Function_Class
{
    class DebugMode
    {

        public static byte[] startMode84;

        /// <summary>
        /// debug mode
        /// </summary>
        static DebugMode(){

            startMode84 = StringToSendBytes.bytesToSend("1084\n");



        }


        private void Con()
        {
            try
            {
                #region
                //winuds.串口.serialPort1();
                string BackString;
                string ClearBuff = GobalSerialPort.ResultBackString;
                byte[] _2709Str = StringToSendBytes. bytesToSend("2709\n");
                GobalSerialPort.WriteByMessage(_2709Str, 0, _2709Str.Length);
                BackString = GobalSerialPort.ResultBackString;  //   "2709\r67 09 76 BB DD EE \r\n\r\n>"
                if (BackString.Contains("NO"))
                {
                    byte[] _2709Str1 = StringToSendBytes.bytesToSend("2709\n");
                    GobalSerialPort.WriteByMessage(_2709Str1, 0, _2709Str1.Length);
                    BackString = GobalSerialPort.ResultBackString;
                }
                string[] Backs = BackString.Split('\r');
                string Back1 = Backs[1].Replace(" ", "");
                Back1 = Back1.Substring(4, 8);
                UInt32 b = UInt32.Parse(Back1, System.Globalization.NumberStyles.HexNumber);     //最后得到的 b 的值是 171。
                string _270AStr = Convert.ToString(KEYMethod(b), 16).PadLeft(8, '0');
                _270AStr = "270A" + _270AStr + "\n";
                byte[] _270AByte = StringToSendBytes.bytesToSend(_270AStr);
                GobalSerialPort.WriteByMessage(_270AByte, 0, _270AByte.Length);
                string Backstring1 = GobalSerialPort.ResultBackString;

                byte[] _1086byte = StringToSendBytes.bytesToSend("1086\n");
                GobalSerialPort.WriteByMessage(_1086byte, 0, _1086byte.Length);
                string Backstring2 =  GobalSerialPort.ResultBackString;
                if (Backstring2.Contains("86"))
                {
                }
                else
                {
                }
                #endregion
            }
            catch
            {
            }
        }


        private UInt32 KEYMethod(UInt32 num)
        {

            UInt32 a;
            UInt32 key;
            //  a = 3891493180;
            // a = 462276195;
            // a = 2908138325;
            //   a = 2958568598;
            //  a = 1454069034;
            a = num;
            for (int j = 0; j < 35; j++)
            {
                string z = Convert.ToString(a, 2).PadLeft(32, '0');   //Console.WriteLine("{0},{1}", z, z.Length);
                string x = z.Substring(0, 1);
                a = a << 1;
                if (x == "1")
                {
                    key = a ^ 4109333651;
                    a = key;
                }
                //     Console.WriteLine(a);
                //    Console.WriteLine(x);
            }
            return a;
        }


    }
}
