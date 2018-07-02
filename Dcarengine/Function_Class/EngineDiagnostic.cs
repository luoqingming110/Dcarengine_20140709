using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dcarengine.serialPort;

namespace Dcarengine.Function_Class
{

    /// <summary>
    ///  发动机诊断测试
    /// </summary>
    class EngineDiagnostic
    {

        public static byte[] _31FE;
        public static byte[] _31FD;
        public static byte[] _31CE;
        public static byte[] _31CF;
        public static byte[] _331B;

        public static String  DbackString ;
        public static int  funcFlag = 0;


        static EngineDiagnostic() {

            _31FE = StringToSendBytes.bytesToSend("311B00000000000000FE00" + "\n");
            _31FD = StringToSendBytes.bytesToSend("311B00000000000000FD00" + "\n");
            _31CE = StringToSendBytes.bytesToSend("311B00000000000000CE00" + "\n");
            _31CF = StringToSendBytes.bytesToSend("311B00000000000000CF00" + "\n");
            _331B = StringToSendBytes.bytesToSend("331B" + "\n");
        }

        /// <summary>
        /// 发动机诊断测试
        /// </summary>
        /// <returns></returns>
        public static bool EngineBrake() {

            serialPort.GobalSerialPort.WriteByMessage(_31FE,0,_31FE.Length);
            DbackString = GobalSerialPort.ResultBackString;
           

           
            return true;
        }

        /// <summary>
        /// 递归函数
        /// </summary>
        /// <returns></returns>
        public static bool readBackFunction() {

            GobalSerialPort.WriteByMessage(_31FE, 0, _31FE.Length);
            DbackString = GobalSerialPort.ResultBackString;
            if (!DbackString.Contains("71") && !DbackString.Contains("1B"))
            {
                readBackFunction();
                funcFlag++;
            }
            if (funcFlag >10) {

                return  false ;
            }
            return true;
        }



        /// <summary>
        /// 轨道测试
        /// </summary>
        /// <returns></returns>
        public static bool RunUpTest()
        {




            return true;
        }

        
        /// <summary>
        /// 轨呀测试
        /// </summary>
        /// <returns></returns>
        public static bool CompressionTest()
        {




            return true;
        }



        /// <summary>
        /// 高压测试
        /// </summary>
        /// <returns></returns>
        public static bool HighPressureTest()
        {




            return true;
        }

    }


}
