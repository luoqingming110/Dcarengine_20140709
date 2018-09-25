using Dcarengine.entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dcarengine.refactor
{

    /// <summary>
    /// 静态变量存储
    /// </summary>
    class CommonConstant
    {
        /// <summary>
        /// 串口连接
        /// </summary>
        public static String ECUCONNECT = "串口已连接！";


        /// <summary>
        /// 串口断开
        /// </summary>
        public static String UNECUCONNECT = "串口已断开！";


        /// <summary>
        /// hashTable  数据
        /// </summary>
        public static Hashtable EcuVersionMap = new Hashtable();


        public static String EolReadPrefix = "35";

        public static String EolWritePrefix = "34";

        public static String EolSuffix = "00";


        /// <summary>
        /// 发送数据数据模式
        /// </summary>
        public static Hashtable EcuModeSendMap = new Hashtable();


        /// <summary>
        /// 发送数据数据模式
        /// </summary>
        public static Hashtable  EolMap =  new Hashtable();

        /// <summary>
        /// 数据解密后的发送命令
        /// </summary>
        public static Hashtable EcuModeSendSecondeMap = new Hashtable();


        /// <summary>
        /// mode 
        /// </summary>
        public static String mode;


        /// <summary>
        /// 芯片编号  数据
        /// </summary>
        public static String TL718CODE="00000000"; 



        public static byte[]  _1081Mode= { 11,22,33,44 } ;
        public static byte[]  _1084Mode = { 11, 22, 33, 44 };
        public static byte[]  _1086Mode = { 244, 239, 116, 147};
        public static byte[]  _1087Mode = { 244, 239, 116, 147 };



        // public static 

        static CommonConstant(){

            EcuVersionMap.Add("P1287740", "ECU13AdRess740");

            EcuVersionMap.Add("P1287750", "ECU13AdRess750");

            EcuVersionMap.Add("P1287760", "ECU13AdRess760");

            EcuVersionMap.Add("P1287770", "ECU13AdRess770");

            EcuVersionMap.Add("P1287780", "ECU13AdRess780");

            EcuVersionMap.Add("P1287790", "ECU13AdRess790");

            ///sendMapMode
            ///
            EcuModeSendMap.Add("1084", "2705");
            EcuModeSendMap.Add("1085", "2707");
            EcuModeSendMap.Add("1086", "2709");
            EcuModeSendMap.Add("1087", "270B");

            EcuModeSendMap.Add("1090", "2711");
            EcuModeSendMap.Add("1091", "2713");
            EcuModeSendMap.Add("1092", "2715");
            EcuModeSendMap.Add("1093", "2717");

            //second send map
            EcuModeSendSecondeMap.Add("1084", "2706");
            EcuModeSendSecondeMap.Add("1085", "2708");
            EcuModeSendSecondeMap.Add("1086", "270A");
            EcuModeSendSecondeMap.Add("1087", "270C");

            EcuModeSendSecondeMap.Add("1090", "2712");        
            EcuModeSendSecondeMap.Add("1091", "2714");
            EcuModeSendSecondeMap.Add("1092", "2716");

            ///数据初始化
            //EolAddress ABS_790 = new EolAddress();
            //ABS_790.Active1 = "0";
            //ABS_790.Label1 = "1";
            //ABS_790.Disable1 = "";
            //ABS_790.EOL_Area1 = "EOL3";
            //ABS_790.Starting_Address1 = "024F80";
            //ABS_790.Length1 = 4;
            //ABS_790.Formmat1 = "";
            //EolMap.Add("P1287790", ABS_790);

            //EolAddress ARS_790 = new EolAddress();
            //ARS_790.Active1 = "";
            //ARS_790.Label1 = "";
            //ARS_790.Disable1 = "";
            //ARS_790.EOL_Area1 = "EOL3";
            //ARS_790.Starting_Address1 = "024F80";
            //ARS_790.Length1 = 4;
            //ARS_790.Formmat1 = "";
            //EolMap.Add("P1287790", ARS_790);
            ////
            //EolAddress RETARDER_790 = new EolAddress();
            //ARS_790.Active1 = "";
            //ARS_790.Label1 = "";
            //ARS_790.Disable1 = "";
            //ARS_790.EOL_Area1 = "EOL3";
            //ARS_790.Starting_Address1 = "024F80";
            //ARS_790.Length1 = 4;
            //ARS_790.Formmat1 = "";
            //EolMap.Add("P1287790", ARS_790);



        }


    }
}
