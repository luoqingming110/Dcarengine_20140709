using Dcarengine.refactor;
using Dcarengine.serialPort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Dcarengine.Function_Class
{

    /// <summary>
    /// Eolfunction
    /// </summary>
    class EolFunction
    {

        public int init() {

            return 0;
        }

        /// <summary>
        /// 返回数据格式
        /// </summary>
         static   String backString = "";

        /// <summary>
        /// read 
        /// </summary>
        public static String readFunction(String  address , int lenght) {

            try
            {
                String   _BackResult = "";

                CommonConstant.mode = "1092";
                Tp_KeyMethodFuntion.Con();

                GobalSerialPort.WriteByMessage(CommonCmd.ATSTFF, 0, CommonCmd.ATSTFF.Length);
                GobalSerialPort.WriteByMessage(CommonCmd.ATSW19, 0, CommonCmd.ATSW19.Length);              
                // GobalSerialPort.WriteByMessage(DebugMode.startMode84, 0, DebugMode.startMode84.Length);

                GobalSerialPort.WriteByMessage(CommonCmd._109214, 0, CommonCmd._109214.Length);            
                backString = GobalSerialPort.ResultBackString;
                if (backString!=null) {

                }
                GobalSerialPort.WriteByMessage(CommonCmd._808002,0,CommonCmd._808002.Length);
                backString = GobalSerialPort.ResultBackString;
                //
                //   address = "024E9E";   
                address = address.Replace(" ","");
                byte[] addressbyte = StringToSendBytes.bytesToSend(address + "\n");
            
                //byte[] addressbyte = AddressReadConvert(address,2);
                GobalSerialPort.WriteByMessage(addressbyte,0, addressbyte.Length);
                Thread.Sleep(200);
                backString = GobalSerialPort.ResultBackString;
                //GobalSerialPort.WriteByMessage(CommonCmd.ATBD,0,CommonCmd.ATBD.Length);
                //backString = GobalSerialPort.ResultBackString;
                //36
                if ( backString.Contains("FF") ) {

                    GobalSerialPort.WriteByMessage(CommonCmd._36, 0, CommonCmd._36.Length);
                    Thread.Sleep(200);
                    backString = GobalSerialPort.ResultBackString;
                    _BackResult = backString;
                    GobalSerialPort.WriteByMessage(CommonCmd.ATBD, 0, CommonCmd.ATBD.Length);
                    backString = GobalSerialPort.ResultBackString;                  
                    //byte
                }
                //37
                GobalSerialPort.WriteByMessage(CommonCmd._37,0,CommonCmd._37.Length);
                backString = GobalSerialPort.ResultBackString;

               // GobalSerialPort.WriteByMessage(CommonCmd._3180, 0, CommonCmd._3180.Length);
               // GobalSerialPort.WriteByMessage(CommonCmd._3380, 0, CommonCmd._3380.Length);

                //GobalSerialPort.WriteByMessage(CommonCmd.ATSH81_10_F1, 0, CommonCmd.ATSH81_10_F1.Length);
                //GobalSerialPort.WriteByMessage(CommonCmd._1081, 0, CommonCmd._1081.Length);
                return _BackResult;
            }
            catch (Exception e) {
            }
            return null;

        }

        /// <summary>
        /// write
        /// </summary>
        public static  void writeFunction(String address, int lenght,String value)
        {

            try
            {

                CommonConstant.mode = "1092";
                Tp_KeyMethodFuntion.Con();

                byte[] ATSTFE = StringToSendBytes.bytesToSend( "ATSTFE\n");
                GobalSerialPort.WriteByMessage(ATSTFE, 0, ATSTFE.Length);
                backString = GobalSerialPort.ResultBackString;
                GobalSerialPort.WriteByMessage(CommonCmd.ATSW30, 0, CommonCmd.ATSW30.Length);
                backString = GobalSerialPort.ResultBackString;
                //GobalSerialPort.WriteByMessage(DebugMode.startMode84, 0, DebugMode.startMode84.Length);
                GobalSerialPort.WriteByMessage(CommonCmd._830300D600140A, 0, CommonCmd._830300D600140A.Length);
                backString = GobalSerialPort.ResultBackString;
                //1092模式
                GobalSerialPort.WriteByMessage(CommonCmd._109214, 0, CommonCmd._109214.Length);
                backString = GobalSerialPort.ResultBackString;
                //日期模式
                byte[] databyte = StringToSendBytes.bytesToSend("80 81 02 31 32 33 34 35 36 17 03 E2\n");
                GobalSerialPort.WriteByMessage(databyte, 0, databyte.Length);
                Thread.Sleep(200);
                backString = GobalSerialPort.ResultBackString;
                //34 模式
                // address = "024E9E";
                // byte[] addressbyte = AddressWriteConvert(address, 2);
                address = address.Replace(" ","");
                byte[] addressbyte = StringToSendBytes.bytesToSend(address + "\n");
                GobalSerialPort.WriteByMessage(addressbyte, 0, addressbyte.Length);
                Thread.Sleep(200);
                backString = GobalSerialPort.ResultBackString;
                //36 写入数据
                //String valueWrite = "36" + value;
                //valueWrite = "362222" + "\n";
                value = value.Replace(" ","");          
                byte[] byteValueWrite = StringToSendBytes.bytesToSend(value + "\n");
                GobalSerialPort.WriteByMessage(byteValueWrite, 0, byteValueWrite.Length);
                Thread.Sleep(200);
                backString = GobalSerialPort.ResultBackString;  
                GobalSerialPort.WriteByMessage(CommonCmd.ATBD, 0, CommonCmd.ATBD.Length);
                Thread.Sleep(200);
                backString = GobalSerialPort.ResultBackString;
                //commoncmd
                if (!backString.Contains("76"))
                {
                    GobalSerialPort.WriteByMessage(byteValueWrite, 0, byteValueWrite.Length);
                    GobalSerialPort.WriteByMessage(CommonCmd.ATBD, 0, CommonCmd.ATBD.Length);
                    backString = GobalSerialPort.ResultBackString;

                }
                if (!backString.Contains("76"))
                {
                    GobalSerialPort.WriteByMessage(byteValueWrite, 0, byteValueWrite.Length);
                    GobalSerialPort.WriteByMessage(CommonCmd.ATBD, 0, CommonCmd.ATBD.Length);
                    backString = GobalSerialPort.ResultBackString;

                }
                if (!backString.Contains("76"))
                {
                    GobalSerialPort.WriteByMessage(byteValueWrite, 0, byteValueWrite.Length);
                    GobalSerialPort.WriteByMessage(CommonCmd.ATBD, 0, CommonCmd.ATBD.Length);
                    backString = GobalSerialPort.ResultBackString;
                }
                //76
                if (backString.Contains("76"))
                {
                    GobalSerialPort.WriteByMessage(CommonCmd._37, 0, CommonCmd._37.Length);
                   // Thread.Sleep(1000);
                  //  GobalSerialPort.WriteByMessage(CommonCmd._3180, 0, CommonCmd._3180.Length);

                  //  GobalSerialPort.WriteByMessage(CommonCmd._3380, 0, CommonCmd._3380.Length);
                }
                
                EcuEnd();
            }
            catch {

            }
        }

        /// <summary>
        /// ecudend write
        /// </summary>
        public static void EcuEnd() {

            GobalSerialPort.WriteByMessage(CommonCmd._1101, 0, CommonCmd._1101.Length);
            
        }



        /**
         * address read
         */
        public static byte[] AddressReadConvert(String  cmd , int lenght) {

            String hexlenght = lenght.ToString("X").PadLeft(6,'0');

            String AddressCmd = CommonConstant.EolReadPrefix + cmd + CommonConstant.EolSuffix + hexlenght;

            byte[] AddressCmdbyte = StringToSendBytes.bytesToSend(AddressCmd+"\n");

            return AddressCmdbyte;
        }

        /**
         * address write
         */
        public static byte[] AddressWriteConvert(String cmd, int lenght)
        {

            String hexlenght = lenght.ToString("X").PadLeft(6, '0');

            String AddressCmd = CommonConstant.EolWritePrefix + cmd + CommonConstant.EolSuffix + hexlenght;

            byte[] AddressCmdbyte = StringToSendBytes.bytesToSend(AddressCmd+"\n");

            return AddressCmdbyte;
        }


        /**
         * workOut
         */
        public static String workOut(String mdc , int length) {


            return null;
        }




    }
}
