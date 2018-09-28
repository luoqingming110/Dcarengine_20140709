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

        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


      
       static  EcuConnectionF ecuConnection = new EcuConnectionF();


        /// <summary>
        /// 返回数据格式
        /// </summary>
         static   String backString = "";

        /// <summary>
        /// read 
        /// </summary>
        public static String readFunction(String  address , int lenght, byte[] eol) {

            try
            {
                String   _BackResult = "";
                _36count = 2;
                _35count = 2;
                _37count = 2;

                //CommonConstant.mode = "1090";
                //Tp_KeyMethodFuntion.Con();
                // GobalSerialPort.WriteByMessage(CommonCmd.ATSTFF, 0, CommonCmd.ATSTFF.Length);
                // GobalSerialPort.WriteByMessage(CommonCmd.ATSW19, 0, CommonCmd.ATSW19.Length);              
                // GobalSerialPort.WriteByMessage(DebugMode.startMode84, 0, DebugMode.startMode84.Length);
                // GobalSerialPort.WriteByMessage(CommonCmd._1090, 0, CommonCmd._1090.Length);           

                backString = GobalSerialPort.ResultBackString;                              //
                //   address = "024E9E";   
                address = address.Replace(" ","");               
                byte[] addressbyte = AddressReadConvert(address , lenght);     
                //35 
                readF_35(addressbyte);
                _BackResult = readF_36(CommonCmd._36);
             
                writeF_37(CommonCmd._37);
                
                return _BackResult;

            }
            catch (Exception ) {
            }
            return null;

        }

        /// <summary>
        /// write
        /// </summary>
        public static  String  writeFunction(String address, int lenght,String value,byte[] eol)
        {
            try
            {
                //CommonConstant.mode = "1090";
                //Tp_KeyMethodFuntion.Con();
                //byte[] ATSTFE = StringToSendBytes.bytesToSend( "ATSTFE\n");
                //GobalSerialPort.WriteByMessage(ATSTFE, 0, ATSTFE.Length);
                //backString = GobalSerialPort.ResultBackString;
                //GobalSerialPort.WriteByMessage(CommonCmd.ATSW30, 0, CommonCmd.ATSW30.Length);
                //backString = GobalSerialPort.ResultBackString;
                ////GobalSerialPort.WriteByMessage(DebugMode.startMode84, 0, DebugMode.startMode84.Length);
                //GobalSerialPort.WriteByMessage(CommonCmd._830300D600140A, 0, CommonCmd._830300D600140A.Length);
                //backString = GobalSerialPort.ResultBackString;


               _8081count = 2;
               _34count = 2;
               workCount = 4;
               _37count = 2;
               _3180count = 2;
               _3380count = 5;

        //日期模式
               writeF_8081count(eol);
                //34 模式
                // address = "024E9E";
                address = address.Replace(" ", "");
                byte[] addressbyte = AddressWriteConvert(address, lenght);
                writeF_34(addressbyte);
                //36 写入数据  value 为16进制
                String valueWrite = "36" + value;
                //valueWrite = "362222" + "\n";
                value = valueWrite.Replace(" ","");          
                byte[] byteValueWrite = StringToSendBytes.bytesToSend(value + "\n");
                //commoncmd
                writeF(byteValueWrite);
                writeF_37(CommonCmd._37);
                writeF_3180(CommonCmd._3180);
                writeF_3380(CommonCmd._3380);

                //EcuEnd();
                //Thread.Sleep(3000);
                //ecuConnection.ConnectEucByWait();
                //CommonConstant.mode = "1090";
                //Tp_KeyMethodFuntion.Con();


                return "OK";                
               // EcuEnd();
            }
            catch {}
            return "NO OK";
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

        /// <summary>
        /// 
        /// 读数据递归函数
        /// --------------------------------------------------
        /// </summary>
        private static int _35count = 2;
        private static int _36count = 2;

        /**
         * 35 function 
         */
        public static void readF_35(byte[] _write)
        {

            while (_35count > 0)
            {
                _35count--;
                GobalSerialPort.WriteByMessage(_write, 0, _write.Length);
                Thread.Sleep(200);
                backString = GobalSerialPort.ResultBackString;
                if (backString.Contains("FF")) {

                    break;
                }
                GobalSerialPort.WriteByMessage(CommonCmd.ATBD, 0, CommonCmd.ATBD.Length);
                Thread.Sleep(300);
                backString = GobalSerialPort.ResultBackString;
                if (backString.Contains("75")   
                    || (backString.Contains("7F") && backString.Contains("35") && backString.Contains("78")))
                {
                    Thread.Sleep(100);
                    break;
                }
                else
                {
                    readF_35(_write);
                }
            }

        }
        /**
        * 36 function 
        */
        public static String readF_36(byte[] _write)
        {
            String result = null;

            while (_36count > 0)
            {
                _36count--;
                GobalSerialPort.WriteByMessage(_write, 0, _write.Length);
                Thread.Sleep(200);
                backString = GobalSerialPort.ResultBackString;
                if (backString.Contains("36"))
                {
                    result = backString;
                    break;
                }           
                else
                {
                    readF_36(_write);
                }
            }
            return result;

        }







        /// <summary>
        /// 
        /// 写数据递归函数
        /// --------------------------------------------------
        /// </summary>
        private static int _8081count = 2;
        private static int _34count = 2;
        private static int workCount = 4;
        private static int _37count = 2;
        private static int _3180count= 2;
        private static int _3380count = 5;

        public static void writeF_8081count(byte[] _write)
        {

            while (_8081count > 0)
            {
                _8081count--;
                GobalSerialPort.WriteByMessage(_write, 0, _write.Length);
                Thread.Sleep(200);
                backString = GobalSerialPort.ResultBackString;
                GobalSerialPort.WriteByMessage(CommonCmd.ATBD, 0, CommonCmd.ATBD.Length);
                Thread.Sleep(300);
                backString = GobalSerialPort.ResultBackString;
                if (  backString.Contains("C0")
                    || (backString.Contains("7F") && backString.Contains("80") && backString.Contains("40"))
                    || (backString.Contains("7F") && backString.Contains("80") && backString.Contains("78")))
                {
                    Thread.Sleep(5000);
                    break;
                }
                else 
                {
                    writeF_8081count(_write);
                }
            }


        }

        /**
         * 34
         */
        public static void writeF_34(byte[] _write)
        {
            
            while (_34count > 0)
            {
                _34count--;
                GobalSerialPort.WriteByMessage(_write, 0, _write.Length);
                Thread.Sleep(200);
                backString = GobalSerialPort.ResultBackString;
                if (backString .Contains("FF")) {

                    break; 
                }
                GobalSerialPort.WriteByMessage(CommonCmd.ATBD, 0, CommonCmd.ATBD.Length);
                Thread.Sleep(300);
                backString = GobalSerialPort.ResultBackString;
                log.Info("eol atbd return :" + backString);
                if ( backString.Contains("74")
                    || (backString.Contains("7F") && backString.Contains("34") && backString.Contains("40"))
                    || (backString.Contains("7F") && backString.Contains("34") && backString.Contains("78")))
                {                   
                    Thread.Sleep(200);
                    break;        
                }else
                {
                    writeF_34(_write);
                }               
            }
            
        }

         /**
         * 36 数据
         * 
         **/
  
        public  static void  writeF(byte[]  _write) {

            while (workCount > 0) {

                workCount --;
                try
                {
                    GobalSerialPort.WriteByMessage(_write, 0, _write.Length);
                    Thread.Sleep(200);
                    backString = GobalSerialPort.ResultBackString;
                    GobalSerialPort.WriteByMessage(CommonCmd.ATBD, 0, CommonCmd.ATBD.Length);
                    Thread.Sleep(300);
                    backString = GobalSerialPort.ResultBackString;
                    log.Info("eol atbd return :" + backString);
                    if (backString.Contains("76") 
                        ||(backString.Contains("7F")&&backString.Contains("36")&&backString.Contains("40"))
                        || (backString.Contains("7F") && backString.Contains("36") && backString.Contains("78")))
                    {
                        Thread.Sleep(200);
                        break; 
                    }
                    else 
                    {
                        writeF(_write);                     
                    }
                }
                catch (Exception) {
                }                   
            }

        }

        /**
         * 37 
         **/
        public static void writeF_37(byte[] _write)
        {

            while (_37count > 0)
            {
                _37count--;
                GobalSerialPort.WriteByMessage(_write, 0, _write.Length);
                Thread.Sleep(200);
                backString = GobalSerialPort.ResultBackString;
                if (backString.Contains("77") ) {

                    Thread.Sleep(100);
                    break;
                }
                GobalSerialPort.WriteByMessage(CommonCmd.ATBD, 0, CommonCmd.ATBD.Length);
                Thread.Sleep(300);
                backString = GobalSerialPort.ResultBackString;
                log.Info("eol atbd return :" + backString);
                if ((backString.Contains("77"))
                    || (backString.Contains("7F") && backString.Contains("37") && backString.Contains("40"))
                    || (backString.Contains("7F") && backString.Contains("37") && backString.Contains("78")))
                {
                    Thread.Sleep(100);
                    break;
                }
                else
                {
                    writeF_37(_write);
                }
            }

        }

        /**
     * 3180
     **/
        public static void writeF_3180(byte[] _write)
        {

            while (_3180count > 0)
            {
                _3180count--;
                GobalSerialPort.WriteByMessage(_write, 0, _write.Length);
                Thread.Sleep(200);
                backString = GobalSerialPort.ResultBackString;
                if (backString.Contains("80")) {

                    Thread.Sleep(100);
                    break; 
                }
                GobalSerialPort.WriteByMessage(CommonCmd.ATBD, 0, CommonCmd.ATBD.Length);
                Thread.Sleep(300);
                backString = GobalSerialPort.ResultBackString;
                if ((backString.Contains("80"))
                    || (backString.Contains("7F") && backString.Contains("31") && backString.Contains("40"))
                    || (backString.Contains("7F") && backString.Contains("31") && backString.Contains("78")))
                {
                    Thread.Sleep(100);
                    break;
                }
                else
                {
                    writeF_3180(_write);
                }
            }

        }


        /**
        * 3380
       **/
        public static void writeF_3380(byte[] _write)
        {

            while (_3380count > 0)
            {
                _3380count--;
                GobalSerialPort.WriteByMessage(_write, 0, _write.Length);
                Thread.Sleep(200);
                backString = GobalSerialPort.ResultBackString;
                if (backString.Contains("80"))
                {

                    Thread.Sleep(100);
                    break;
                }
                GobalSerialPort.WriteByMessage(CommonCmd.ATBD, 0, CommonCmd.ATBD.Length);
                Thread.Sleep(300);
                backString = GobalSerialPort.ResultBackString;
                if ((backString.Contains("80") ||
                    backString.Contains("7F") && backString.Contains("33") && backString.Contains("23")) )                  
                {
                    writeF_3380(_write);                 
                }
                else
                {
                    Thread.Sleep(100);
                    break;
                }
            }

        }



    }
}
