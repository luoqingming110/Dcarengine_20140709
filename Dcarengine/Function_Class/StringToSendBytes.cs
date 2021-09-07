using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dcarengine.Function_Class
{
    class StringToSendBytes
    {


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


        public static byte[] bytesToSendNoEnd(string SendSTring)
        {
            int SendstringLength = SendSTring.Length;
            byte[] _RSendstringbytes = new byte[SendstringLength];
            byte[] Sendstringbytes = System.Text.ASCIIEncoding.Default.GetBytes(SendSTring + "");

            for (int i = 0; i < Sendstringbytes.Length - 1; i++)
            {
                //  Sendstringbytes[i] = Convert.ToByte(Sendstringbytes[i].ToString("X"));
                Sendstringbytes[i] = Byte.Parse(Sendstringbytes[i].ToString("X"), System.Globalization.NumberStyles.HexNumber);
                _RSendstringbytes[i] = Sendstringbytes[i];
            }
            //_RSendstringbytes[SendstringLength - 1] = 0x0D;
            //_RSendstringbytes[SendstringLength] = 0x0A;
            //  serialPort1.Write(ByteSend, 0, ByteSend.Length);
            return _RSendstringbytes;
        }

        // byte[] 转16进制格式string：
        public static string ToHexString(byte[] bytes) // 0xae00cf => "AE00CF "
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                }
                hexString = strB.ToString();
            }
            return hexString;
        }

        public static string ByteToString(byte[] bytes) // 0xae00cf => "AE00CF "
        {
           // string hexString = string.Empty;
            string str = System.Text.Encoding.Default.GetString(bytes);
            return str;
        }


    }
}
