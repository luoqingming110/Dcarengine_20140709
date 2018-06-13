using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dcarengine.UIForm;
using Dcarengine.SQLData;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;


namespace Dcarengine.Function_Class
{
    class _13IdFDataWork
    {

        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// 返回数据字段
        /// </summary>
        private static String workOutData;

        public static string WorkOutData { get => workOutData; set => workOutData = value; }



        /// <summary>
        /// 解析ECUID 数据高低位
        /// </summary>
        /// <param name="ID"></param>
        public static void InsertAcessF_7(string ID)
        {

            try
            {
                string changeStr = ID;
                StringBuilder charTOstring = new StringBuilder();
                string[] A = changeStr.Split('\r');
                if (A[1] != null && !(A[1].Contains("NO")) && !(A[1].Contains("\r")))
                {
                    if (A[1] != "" || A[1].Length >= 13)
                    {
                        changeStr = A[1].Substring(6, A[1].Length - 7);

                        if (changeStr.Length == 2)
                        {
                            int code = Convert.ToInt32(changeStr, 16);
                            char c = (char)code;
                            MainF.EcuIDCodeToStrFin = charTOstring.Append(c.ToString()).ToString();
                        }
                        else
                        {
                            string[] substring = changeStr.Split(' ');                 //这个是用来存放分割后的字符串的数组
                            foreach (string key in substring)
                            {
                                int code = Convert.ToInt32(key, 16);      //将16进制字符串转换成其ASCII码（实际是Unicode码）
                                char c = (char)code;                      //取得这个Unicode码表示的char（强制转换就行）
                                WorkOutData = charTOstring.Append(c.ToString()).ToString();   //输出。                               
                            }
                        }
                    }
                    else
                    {
                        WorkOutData = A[1];
                    }
                }
                else
                {
                    WorkOutData = A[1];
                }
                String workYu = workOutData.Replace("\0", "0");
                WorkOutData = workYu.Trim();
            }
            catch (Exception e)
            {

                log.Info("this Id work is error,id is :" + ID + "\n" + e.Message);
                return;
            }
        }


        /// <summary>
        /// 数据解析
        /// </summary>
        /// <param name="ID"></param>
        public static void InsertAcessF_10(string ID)
        {

            try
            {
                string changeStr = ID;
                StringBuilder charTOstring = new StringBuilder();
                string[] A = changeStr.Split('\r');
                if (A[1] != null && !(A[1].Contains("NO")) && !(A[1].Contains("\r")))
                {
                    if (A[1] != "" || A[1].Length >= 13)
                    {
                        changeStr = A[1].Substring(9, A[1].Length - 10);

                        if (changeStr.Length == 2)
                        {
                            int code = Convert.ToInt32(changeStr, 16);
                            char c = (char)code;
                            MainF.EcuIDCodeToStrFin = charTOstring.Append(c.ToString()).ToString();
                        }
                        else
                        {

                            string[] substring = changeStr.Split(' ');                 //这个是用来存放分割后的字符串的数组
                            foreach (string key in substring)
                            {
                                try
                                {
                                    int code = Convert.ToInt32(key, 16);      //将16进制字符串转换成其ASCII码（实际是Unicode码）
                                    char c = (char)code;                      //取得这个Unicode码表示的char（强制转换就行）
                                    MainF.EcuIDCodeToStrFin = charTOstring.Append(c.ToString()).ToString();   //输出。
                                }
                                catch (FormatException)
                                {
                                    MessageBox.Show("处理异常！！！");
                                }
                            }
                        }
                    }
                    else
                    {
                        MainF.EcuIDCodeToStrFin = A[1];
                    }
                }
                else
                {
                    MainF.EcuIDCodeToStrFin = A[1];
                }
            }
            catch (Exception e)
            {
                log.Info("this Id work is error,id is :" + ID + "\n" + e.Message);
                return;
            }
        }
    }

    }

