using Dcarengine.service;
using Dcarengine.SQLData;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace Dcarengine.Function_Class
{
    /// <summary>
    /// 单步处理故障代码,将原来的读出数据处理分为每步单独处理
    /// refacor
    /// </summary>
    class SingleDtcFunction
    {

        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// 数据返回变量
        /// </summary>
        public static string DtcBackData;

        int _13Frequency_counter; string _13s_Frequency_counter;

        string _13Active; string _13Sactive = " ";

        public int _13TEST; public string _13Tested = "";

        int _13Debounce_completed; string _13s_Debounce_completed;

        string DFCNAME; string _dfcname;

        string _13Descrition_English; string _13S_Descrition_English = "";

        string _13Descrition_Chinese; string _13S_Descrition_Chinese = "";

        //故障序列
        public int _13DTCID;

        string _13Visible_to_OBD_tool; string _13S_Visible_to_OBD_tool = " ";

        string _13MIL_lamp_is_blinking; string _13S_MIL_lamp_is_blinking = " ";

        string[] _13BackTDCnumcode; string s_13BackTDCnumcode;

        /// <summary>
        /// 插入保存单个环境变量
        /// </summary>
        string[] _13VALUES; string _13sValue = "";


        string PCODE; string _pcode;
        string SPN; string _spn;
        string FM1; string _fmi;
        string DTCB; string _dtcb;
        string MIL; string _mil;
        string SVS; string _svs;
        string Envirments; string _envirments = "";
        string Envirment1; string _envirment1 = "";
        string Envirment2; string _envirment2 = "";
        string Envirment3; string _envirment3 = "";
        string Envirment4; string _envirment4 = "";
        string Envirment5; string _envirment5 = "";
        string Envirment6; string _envirment6 = "";
        string Envirment7; string _envirment7 = "";
        string Envirment8; string _envirment8 = "";
        string Envirment9; string _envirment9 = "";

        //string _13Active; string _13Sactive = " ";
        //ECU环境变量的解析公式
        string _13Fenviroment_Value1Arry; string _13Renviroment_Value1Arry; string _13Fenviroment_Value1Format; int _13Fenviroment_Value1Byte;
        string _13Fenviroment_Value1; string _13Renviroment_Value1;
        string _13Fenviroment_Value2Arry; string _13Renviroment_Value2Arry; string _13Fenviroment_Value2Format; int _13Fenviroment_Value2Byte;
        string _13Fenviroment_Value2; string _13Renviroment_Value2;
        string _13Fenviroment_Value3Arry; string _13Renviroment_Value3Arry; string _13Fenviroment_Value3Format; int _13Fenviroment_Value3Byte;
        string _13Fenviroment_Value3; string _13Renviroment_Value3;
        string _13Fenviroment_Value4Arry; string _13Renviroment_Value4Arry; string _13Fenviroment_Value4Format; int _13Fenviroment_Value4Byte;
        string _13Fenviroment_Value4; string _13Renviroment_Value4;
        string _13Fenviroment_Value5Arry; string _13Renviroment_Value5Arry; string _13Fenviroment_Value5Format; int _13Fenviroment_Value5Byte;
        string _13Fenviroment_Value5; string _13Renviroment_Value5;
        string _13Fenviroment_Value6Arry; string _13Renviroment_Value6Arry; string _13Fenviroment_Value6Format; int _13Fenviroment_Value6Byte;
        string _13Fenviroment_Value6; string _13Renviroment_Value6;
        string _13Fenviroment_Value7Arry; string _13Renviroment_Value7Arry; string _13Fenviroment_Value7Format; int _13Fenviroment_Value7Byte;
        string _13Fenviroment_Value7; string _13Renviroment_Value7;
        string _13Fenviroment_Value8Arry; string _13Renviroment_Value8Arry; string _13Fenviroment_Value8Format; int _13Fenviroment_Value8Byte;
        string _13Fenviroment_Value8; string _13Renviroment_Value8;
        string _13Fenviroment_Value9Arry; string _13Renviroment_Value9Arry; string _13Fenviroment_Value9Format; int _13Fenviroment_Value9Byte;
        string _13Fenviroment_Value9; string _13Renviroment_Value9;
        int[] _13EnvirmentID = new int[54];
        private string _13EnvirmentUnit1; private string _13EnvirmentUnit1A; private string _13EnvirmentCD1; private string _13EnvirmentCD1A;
        private string _13EnvirmentUnit2; private string _13EnvirmentUnit2A; private string _13EnvirmentCD2; private string _13EnvirmentCD2A;
        private string _13EnvirmentUnit3; private string _13EnvirmentUnit3A; private string _13EnvirmentCD3; private string _13EnvirmentCD3A;
        private string _13EnvirmentUnit4; private string _13EnvirmentUnit4A; private string _13EnvirmentCD4; private string _13EnvirmentCD4A;
        private string _13EnvirmentUnit5; private string _13EnvirmentUnit5A; private string _13EnvirmentCD5; private string _13EnvirmentCD5A;
        private string _13EnvirmentUnit6; private string _13EnvirmentUnit6A; private string _13EnvirmentCD6; private string _13EnvirmentCD6A;
        private string _13EnvirmentUnit7; private string _13EnvirmentUnit7A; private string _13EnvirmentCD7; private string _13EnvirmentCD7A;
        private string _13EnvirmentUnit8; private string _13EnvirmentUnit8A; private string _13EnvirmentCD8; private string _13EnvirmentCD8A;
        private string _13EnvirmentUnit9; private string _13EnvirmentUnit9A; private string _13EnvirmentCD9; private string _13EnvirmentCD9A;


        OleDbCommand cmd;

        /// <summary>
        /// jdbc con
        /// </summary>
        OleDbConnection con;

        //  int DtcFalutCodeNumFlag = 11;   //这里是标示ECU的序列号，

        public void ShowDtcCodeF(int  DtcId)
        {     //这个是最后显示的函数
            _13DTCID = DtcId;
            WorkDtcNormalData();
            _13DtcWorkOut();
            SHOWECU13CODE();          
        }

        /// <summary>
        /// 单数据变量
        /// </summary>
        public SingleDtcFunction() {

            con = MyMeans.Conn;

            for (int i = 0; i < 54; i++)
            {
                _13EnvirmentID[i] = i + 1;
            }
            // con.Open();

        }


        /// <summary>
        /// 计算前面单独数据变量
        /// </summary>
        public void WorkDtcNormalData() {

            int _ToSQl;
            String _13DTCTOSQL = _13dtcRead.ECU13DTCSingle.Substring(0, 3);
            _ToSQl = Convert.ToInt32(_13DTCTOSQL, 16);
            string[] datList = _13dtcRead.Save13BackDTCSingle.Split('\r');
            string counter = datList[1].Substring(6, 2);
            _13Frequency_counter = Convert.ToInt32(counter, 16);
            //状态位，这里是代表的Active，表示状态位。。。。。。这里指需要一位而已啊。。。
            string status1 = datList[1].Substring(15, 1);
            string status2 = datList[1].Substring(16, 1);
            int status1to10jinz = int.Parse(Convert.ToInt32(status1, 16).ToString("X"), System.Globalization.NumberStyles.HexNumber);
            string status1to2jinz = Convert.ToString(status1to10jinz, 2).PadLeft(4, '0');
            _13Active = status1to2jinz.Substring(1, 2);
            // DTC 高位和地位之间的转化。。。。
            string s2 = datList[1].Substring(9, 5);
            string s3 = s2.Replace(" ", "");
            string s4 = s3.Substring(0, 1);
            int s4TO10jinz = Convert.ToInt32(s4, 16);
            int s4To16jianz = int.Parse(s4TO10jinz.ToString("X"), System.Globalization.NumberStyles.HexNumber);
            string s4To2jianz = Convert.ToString(s4To16jianz, 2).PadLeft(4, '0');
            //这里是表达有没有被检测的数据。
            string subs4 = s4To2jianz.Substring(0, 1);
            _13TEST = Convert.ToInt32(subs4);
            // 这里是表达有没有被检查的。。。。
            string subs5 = s4To2jianz.Substring(0, 1);
            _13Debounce_completed = Convert.ToInt32(subs5);
            //解析这里的环境变量
            string Enviroment = datList[1].Replace(" ", "");
            //这里是数据库查询的程序代码
            try
            {
                // con.Open();
                string select = "SELECT * FROM   ECU13DTC   where  DTCMNUM=  " + _ToSQl;
                cmd = new OleDbCommand(select, con);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DFCNAME = (string)reader[2];
                    _13Descrition_English = (string)reader[3];
                    _13Descrition_Chinese = (string)reader[4];
                    PCODE = (string)reader[5];
                    SPN = (string)reader[6];
                    FM1 = (string)reader[7];
                    DTCB = (string)reader[8];
                    MIL = (string)reader[9];
                    SVS = (string)reader[10];
                    Envirment1 = (string)reader[11];
                    Envirment2 = (string)reader[12];
                    Envirment3 = (string)reader[13];
                    Envirment4 = (string)reader[14];
                    Envirment5 = (string)reader[15];
                    Envirment6 = (string)reader[16];
                    Envirment7 = (string)reader[17];
                    Envirment8 = (string)reader[18];
                    Envirment9 = (string)reader[19];
                }
                 //con.Close();
            }
            catch (Exception e)
            {
                log.Info("dtc select envirment is error " + e.Message);
            }
        }


        private void _13DtcWorkOut()
        {
            #region
            string select1 = "SELECT * FROM   ECU13Envirment_format   where  Envirment_ID=" + Get_13Envirment_ID(Envirment1);
            cmd = new OleDbCommand(select1, con);
            OleDbDataReader reader1 = cmd.ExecuteReader();
            while (reader1.Read())
            {

                _13Fenviroment_Value1Format = (string)reader1[4];
                _13Fenviroment_Value1Byte = ((int)reader1[6]) * 2;
                _13EnvirmentUnit1A = (string)reader1[5];
                _13EnvirmentCD1A = (string)reader1[3];
            }
            string select2 = "SELECT * FROM   ECU13Envirment_format   where  Envirment_ID =" + Get_13Envirment_ID(Envirment2);
            cmd = new OleDbCommand(select2, con);
            OleDbDataReader reader2 = cmd.ExecuteReader();
            while (reader2.Read())
            {

                _13Fenviroment_Value2Format = (string)reader2[4];
                _13Fenviroment_Value2Byte = ((int)reader2[6]) * 2;
                _13EnvirmentUnit2A = (string)reader2[5];
                _13EnvirmentCD2A = (string)reader2[3];
            }
            string select3 = "SELECT * FROM   ECU13Envirment_format   where  Envirment_ID=" + Get_13Envirment_ID(Envirment3);
            cmd = new OleDbCommand(select3, con);
            OleDbDataReader reader3 = cmd.ExecuteReader();
            while (reader3.Read())
            {

                _13Fenviroment_Value3Format = (string)reader3[4];
                _13Fenviroment_Value3Byte = ((int)reader3[6]) * 2;
                _13EnvirmentUnit3A = (string)reader3[5];
                _13EnvirmentCD3A = (string)reader3[3];
            }
            string select4 = "SELECT * FROM   ECU13Envirment_format   where  Envirment_ID=" + Get_13Envirment_ID(Envirment4);
            cmd = new OleDbCommand(select4, con);
            OleDbDataReader reader4 = cmd.ExecuteReader();
            while (reader4.Read())
            {

                _13Fenviroment_Value4Format = (string)reader4[4];
                _13Fenviroment_Value4Byte = ((int)reader4[6]) * 2;
                _13EnvirmentUnit4A = (string)reader4[5];
                _13EnvirmentCD4A = (string)reader4[3];
            }
            string select5 = "SELECT * FROM   ECU13Envirment_format   where  Envirment_ID=" + Get_13Envirment_ID(Envirment5);
            cmd = new OleDbCommand(select5, con);
            OleDbDataReader reader5 = cmd.ExecuteReader();
            while (reader5.Read())
            {

                _13Fenviroment_Value5Format = (string)reader5[4];
                _13Fenviroment_Value5Byte = ((int)reader5[6]) * 2;
                _13EnvirmentUnit5A = (string)reader5[5];
                _13EnvirmentCD5A = (string)reader5[3];
            }
            string select6 = "SELECT * FROM   ECU13Envirment_format   where Envirment_ID=" + Get_13Envirment_ID(Envirment6);
            cmd = new OleDbCommand(select6, con);
            OleDbDataReader reader6 = cmd.ExecuteReader();
            while (reader6.Read())
            {

                _13Fenviroment_Value6Format = (string)reader6[4];
                _13Fenviroment_Value6Byte = ((int)reader6[6]) * 2;
                _13EnvirmentUnit6A = (string)reader6[5];
                _13EnvirmentCD6A = (string)reader6[3];
            }
            string select7 = "SELECT * FROM   ECU13Envirment_format   where Envirment_ID=" + Get_13Envirment_ID(Envirment7);
            cmd = new OleDbCommand(select7, con);
            OleDbDataReader reader7 = cmd.ExecuteReader();
            while (reader7.Read())
            {

                _13Fenviroment_Value7Format = (string)reader7[4];
                _13Fenviroment_Value7Byte = ((int)reader7[6]) * 2;
                _13EnvirmentUnit7A = (string)reader7[5];
                _13EnvirmentCD7A = (string)reader7[3];
            }
            string select8 = "SELECT * FROM   ECU13Envirment_format   where Envirment_ID=" + Get_13Envirment_ID(Envirment8);
            cmd = new OleDbCommand(select8, con);
            OleDbDataReader reader8 = cmd.ExecuteReader();
            while (reader8.Read())
            {

                _13Fenviroment_Value8Format = (string)reader8[4];
                _13Fenviroment_Value8Byte = ((int)reader8[6]) * 2;
                _13EnvirmentUnit8A = (string)reader8[5];
                _13EnvirmentCD8A = (string)reader8[3];
            }
            string select9 = "SELECT * FROM   ECU13Envirment_format   where Envirment_ID=" + Get_13Envirment_ID(Envirment9);
            cmd = new OleDbCommand(select9, con);
            OleDbDataReader reader9 = cmd.ExecuteReader();
            while (reader9.Read())
            {

                _13Fenviroment_Value9Format = (string)reader9[4];
                _13Fenviroment_Value9Byte = ((int)reader9[6]) * 2;
                _13EnvirmentUnit9A = (string)reader9[5];
                _13EnvirmentCD9A = (string)reader9[3];
            }
           

            #region 环境变量的处理               
            string[] cccc = _13dtcRead.Save13BackDTCSingle.Split('\r');
            string Enviroment = cccc[1].Replace(" ", "").PadRight(200, '0');
            //截取环境数据并把它解析出来放入数组里面，
            _13Fenviroment_Value1Arry = Enviroment.Substring(18, _13Fenviroment_Value1Byte);
            _13Fenviroment_Value2Arry = Enviroment.Substring(18 + _13Fenviroment_Value1Byte + 4 * 1, _13Fenviroment_Value2Byte);
            _13Fenviroment_Value3Arry = Enviroment.Substring(18 + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + 4 * 2, _13Fenviroment_Value3Byte);
            _13Fenviroment_Value4Arry = Enviroment.Substring(18 + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + _13Fenviroment_Value3Byte + 4 * 3, _13Fenviroment_Value4Byte);
            _13Fenviroment_Value5Arry = Enviroment.Substring(18 + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + _13Fenviroment_Value3Byte + _13Fenviroment_Value4Byte + 4 * 4, _13Fenviroment_Value5Byte);
            _13Fenviroment_Value6Arry = Enviroment.Substring(18 + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + _13Fenviroment_Value3Byte + _13Fenviroment_Value4Byte + _13Fenviroment_Value5Byte + 4 * 5, _13Fenviroment_Value6Byte);
            _13Fenviroment_Value7Arry = Enviroment.Substring(18 + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + _13Fenviroment_Value3Byte + _13Fenviroment_Value4Byte + _13Fenviroment_Value5Byte + _13Fenviroment_Value6Byte + 4 * 6, _13Fenviroment_Value7Byte);
            _13Fenviroment_Value8Arry = Enviroment.Substring(18 + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + _13Fenviroment_Value3Byte + _13Fenviroment_Value4Byte + _13Fenviroment_Value5Byte + _13Fenviroment_Value6Byte + 4 * 7 + _13Fenviroment_Value7Byte, _13Fenviroment_Value8Byte);
            if (_13Fenviroment_Value9Byte != 0)
            {
                _13Fenviroment_Value9Arry = Enviroment.Substring(18 + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + _13Fenviroment_Value3Byte + _13Fenviroment_Value4Byte + _13Fenviroment_Value5Byte + _13Fenviroment_Value6Byte + 4 * 8 + _13Fenviroment_Value7Byte + _13Fenviroment_Value8Byte, _13Fenviroment_Value9Byte);
                //
                int a = 18 + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + _13Fenviroment_Value3Byte + _13Fenviroment_Value4Byte + _13Fenviroment_Value5Byte + _13Fenviroment_Value6Byte + 4 * 9 + _13Fenviroment_Value7Byte + _13Fenviroment_Value8Byte + _13Fenviroment_Value9Byte;
                _13Renviroment_Value1Arry = Enviroment.Substring(a, _13Fenviroment_Value1Byte);
                _13Renviroment_Value2Arry = Enviroment.Substring(a + _13Fenviroment_Value1Byte + 4 * 1, _13Fenviroment_Value2Byte);
                _13Renviroment_Value3Arry = Enviroment.Substring(a + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + 4 * 2, _13Fenviroment_Value3Byte);
                _13Renviroment_Value4Arry = Enviroment.Substring(a + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + _13Fenviroment_Value3Byte + 4 * 3, _13Fenviroment_Value4Byte);
                _13Renviroment_Value5Arry = Enviroment.Substring(a + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + _13Fenviroment_Value3Byte + _13Fenviroment_Value4Byte + 4 * 4, _13Fenviroment_Value5Byte);
                _13Renviroment_Value6Arry = Enviroment.Substring(a + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + _13Fenviroment_Value3Byte + _13Fenviroment_Value4Byte + _13Fenviroment_Value5Byte + 4 * 5, _13Fenviroment_Value6Byte);
                _13Renviroment_Value7Arry = Enviroment.Substring(a + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + _13Fenviroment_Value3Byte + _13Fenviroment_Value4Byte + _13Fenviroment_Value5Byte + _13Fenviroment_Value6Byte + 4 * 6, _13Fenviroment_Value7Byte);
                _13Renviroment_Value8Arry = Enviroment.Substring(a + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + _13Fenviroment_Value3Byte + _13Fenviroment_Value4Byte + _13Fenviroment_Value5Byte + _13Fenviroment_Value6Byte + 4 * 7 + _13Fenviroment_Value7Byte, _13Fenviroment_Value8Byte);
                _13Renviroment_Value9Arry = Enviroment.Substring(a + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + _13Fenviroment_Value3Byte + _13Fenviroment_Value4Byte + _13Fenviroment_Value5Byte + _13Fenviroment_Value6Byte + 4 * 8 + _13Fenviroment_Value7Byte + _13Fenviroment_Value8Byte, _13Fenviroment_Value9Byte);

            }
            else
            {
                int a = 18 + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + _13Fenviroment_Value3Byte + _13Fenviroment_Value4Byte + _13Fenviroment_Value5Byte + _13Fenviroment_Value6Byte + 4 * 8 + _13Fenviroment_Value7Byte + _13Fenviroment_Value8Byte + _13Fenviroment_Value9Byte;
                _13Renviroment_Value1Arry = Enviroment.Substring(a, _13Fenviroment_Value1Byte);
                _13Renviroment_Value2Arry = Enviroment.Substring(a + _13Fenviroment_Value1Byte + 4 * 1, _13Fenviroment_Value2Byte);
                _13Renviroment_Value3Arry = Enviroment.Substring(a + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + 4 * 2, _13Fenviroment_Value3Byte);
                _13Renviroment_Value4Arry = Enviroment.Substring(a + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + _13Fenviroment_Value3Byte + 4 * 3, _13Fenviroment_Value4Byte);
                _13Renviroment_Value5Arry = Enviroment.Substring(a + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + _13Fenviroment_Value3Byte + _13Fenviroment_Value4Byte + 4 * 4, _13Fenviroment_Value5Byte);
                _13Renviroment_Value6Arry = Enviroment.Substring(a + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + _13Fenviroment_Value3Byte + _13Fenviroment_Value4Byte + _13Fenviroment_Value5Byte + 4 * 5, _13Fenviroment_Value6Byte);
                _13Renviroment_Value7Arry = Enviroment.Substring(a + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + _13Fenviroment_Value3Byte + _13Fenviroment_Value4Byte + _13Fenviroment_Value5Byte + _13Fenviroment_Value6Byte + 4 * 6, _13Fenviroment_Value7Byte);
                _13Renviroment_Value8Arry = Enviroment.Substring(a + _13Fenviroment_Value1Byte + _13Fenviroment_Value2Byte + _13Fenviroment_Value3Byte + _13Fenviroment_Value4Byte + _13Fenviroment_Value5Byte + _13Fenviroment_Value6Byte + 4 * 7 + _13Fenviroment_Value7Byte, _13Fenviroment_Value8Byte);
                //  _13Renviroment_Value9Arry[i] = Enviroment.Substring(a + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + _13Fenviroment_Value4Byte[i] + _13Fenviroment_Value5Byte[i] + _13Fenviroment_Value6Byte[i] + 4 * 8 + _13Fenviroment_Value7Byte[i] + _13Fenviroment_Value8Byte[i], _13Fenviroment_Value9Byte[i]);
            }
            #region    这里要处理正负数

            MSScriptControl.ScriptControl sc1 = new MSScriptControl.ScriptControl();
            sc1.Language = "JavaScript";
            //// Value[i] = sc1.Eval(FinalResult[i]).ToString();  

            string Substring_ValueArry1 = _13Fenviroment_Value1Arry.Substring(0, 1);
            string Substring_ValueArry1_1 = _13Renviroment_Value1Arry.Substring(0, 1);
            char[] Str1 = Substring_ValueArry1.ToCharArray();
            char[] Str1_1 = Substring_ValueArry1_1.ToCharArray();
            if (Str1[0] < 'G' && Str1[0] > '7')
            {
                Int32 ReturnValue = System.Math.Abs(符号位转换(_13Fenviroment_Value1Arry));
                _13Fenviroment_Value1Arry = _13Fenviroment_Value1Format.Replace("Phy", ReturnValue.ToString());
                _13Fenviroment_Value1Arry = sc1.Eval(_13Fenviroment_Value1Arry).ToString();
                _13Fenviroment_Value1Arry = "-" + _13Fenviroment_Value1Arry;
            }
            else
            {
                Int32 value1 = Convert.ToInt32(_13Fenviroment_Value1Arry, 16);
                _13Fenviroment_Value1Arry = _13Fenviroment_Value1Format.Replace("Phy", value1.ToString());
                _13Fenviroment_Value1Arry = sc1.Eval(_13Fenviroment_Value1Arry).ToString();
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (Str1_1[0] < 'G' && Str1_1[0] > '7')
            {
                Int32 ReturnValue = System.Math.Abs(符号位转换(_13Renviroment_Value1Arry));
                _13Renviroment_Value1Arry = _13Fenviroment_Value1Format.Replace("Phy", ReturnValue.ToString());
                _13Renviroment_Value1Arry = sc1.Eval(_13Renviroment_Value1Arry).ToString();
                _13Fenviroment_Value1Arry = "-" + _13Fenviroment_Value1Arry;
            }
            else
            {
                Int32 value1_1 = Convert.ToInt32(_13Renviroment_Value1Arry, 16);
                _13Renviroment_Value1Arry = _13Fenviroment_Value1Format.Replace("Phy", value1_1.ToString());
                _13Renviroment_Value1Arry = sc1.Eval(_13Renviroment_Value1Arry).ToString();
            }
            //////////////////////22222222222222222222222222222222222222222

            string Substring_ValueArry2 = _13Fenviroment_Value2Arry.Substring(0, 1);
            string Substring_ValueArry2_1 = _13Renviroment_Value2Arry.Substring(0, 1);
            char[] Str2 = Substring_ValueArry2.ToCharArray();
            char[] Str2_1 = Substring_ValueArry2_1.ToCharArray();
            if (Str2[0] < 'G' && Str2[0] > '7')
            {
                Int32 ReturnValue = System.Math.Abs(符号位转换(_13Fenviroment_Value2Arry));
                _13Fenviroment_Value2Arry = _13Fenviroment_Value2Format.Replace("Phy", ReturnValue.ToString());
                _13Fenviroment_Value2Arry = sc1.Eval(_13Fenviroment_Value2Arry).ToString();
                _13Fenviroment_Value2Arry = "-" + _13Fenviroment_Value2Arry;
            }
            else
            {
                Int32 value1 = Convert.ToInt32(_13Fenviroment_Value2Arry, 16);
                _13Fenviroment_Value2Arry = _13Fenviroment_Value2Format.Replace("Phy", value1.ToString());
                _13Fenviroment_Value2Arry = sc1.Eval(_13Fenviroment_Value2Arry).ToString();
            }

            if (Str2_1[0] < 'G' && Str2_1[0] > '7')
            {
                Int32 ReturnValue = System.Math.Abs(符号位转换(_13Renviroment_Value2Arry));
                _13Renviroment_Value2Arry = _13Fenviroment_Value2Format.Replace("Phy", ReturnValue.ToString());
                _13Renviroment_Value2Arry = sc1.Eval(_13Renviroment_Value2Arry).ToString();
                _13Renviroment_Value2Arry = "-" + _13Renviroment_Value2Arry;
            }
            else
            {
                Int32 value1_1 = Convert.ToInt32(_13Renviroment_Value2Arry, 16);
                _13Renviroment_Value2Arry = _13Fenviroment_Value2Format.Replace("Phy", value1_1.ToString());
                _13Renviroment_Value2Arry = sc1.Eval(_13Renviroment_Value2Arry).ToString();
            }
            /////////////////33333333333333333333333333333333
            string Substring_ValueArry3 = _13Fenviroment_Value3Arry.Substring(0, 1);
            string Substring_ValueArry3_1 = _13Renviroment_Value3Arry.Substring(0, 1);
            char[] Str3 = Substring_ValueArry3.ToCharArray();
            char[] Str3_1 = Substring_ValueArry3_1.ToCharArray();
            if (Str3[0] < 'G' && Str3[0] > '7')
            {
                Int32 ReturnValue = System.Math.Abs(符号位转换(_13Fenviroment_Value3Arry));
                _13Fenviroment_Value3Arry = _13Fenviroment_Value3Format.Replace("Phy", ReturnValue.ToString());
                _13Fenviroment_Value3Arry = sc1.Eval(_13Fenviroment_Value3Arry).ToString();
                _13Fenviroment_Value3Arry = "-" + _13Fenviroment_Value3Arry;

            }
            else
            {
                Int32 value1 = Convert.ToInt32(_13Fenviroment_Value3Arry, 16);
                _13Fenviroment_Value3Arry = _13Fenviroment_Value3Format.Replace("Phy", value1.ToString());
                _13Fenviroment_Value3Arry = sc1.Eval(_13Fenviroment_Value3Arry).ToString();
            }

            if (Str3_1[0] < 'G' && Str3_1[0] > '7')
            {
                Int32 ReturnValue = System.Math.Abs(符号位转换(_13Renviroment_Value3Arry));
                _13Renviroment_Value3Arry = _13Fenviroment_Value3Format.Replace("Phy", ReturnValue.ToString());
                _13Renviroment_Value3Arry = sc1.Eval(_13Renviroment_Value3Arry).ToString();
                _13Renviroment_Value3Arry = "-" + _13Renviroment_Value3Arry;
            }
            else
            {
                Int32 value1_1 = Convert.ToInt32(_13Renviroment_Value3Arry, 16);
                _13Renviroment_Value3Arry = _13Fenviroment_Value3Format.Replace("Phy", value1_1.ToString());
                _13Renviroment_Value3Arry = sc1.Eval(_13Renviroment_Value3Arry).ToString();
            }
            ///////44444444444444444444444
            string Substring_ValueArry4 = _13Fenviroment_Value4Arry.Substring(0, 1);
            string Substring_ValueArry4_1 = _13Renviroment_Value4Arry.Substring(0, 1);
            char[] Str4 = Substring_ValueArry4.ToCharArray();
            char[] Str4_1 = Substring_ValueArry4_1.ToCharArray();
            if (Str4[0] < 'G' && Str4[0] > '7')
            {
                Int32 ReturnValue = System.Math.Abs(符号位转换(_13Fenviroment_Value4Arry));
                _13Fenviroment_Value4Arry = _13Fenviroment_Value4Format.Replace("Phy", ReturnValue.ToString());
                _13Fenviroment_Value4Arry = sc1.Eval(_13Fenviroment_Value4Arry).ToString();
                _13Fenviroment_Value4Arry = "-" + _13Fenviroment_Value4Arry;
            }
            else
            {
                Int32 value1 = Convert.ToInt32(_13Fenviroment_Value4Arry, 16);
                _13Fenviroment_Value4Arry = _13Fenviroment_Value4Format.Replace("Phy", value1.ToString());
                _13Fenviroment_Value4Arry = sc1.Eval(_13Fenviroment_Value4Arry).ToString();
            }

            if (Str4_1[0] < 'G' && Str4_1[0] > '7')
            {
                Int32 ReturnValue = System.Math.Abs(符号位转换(_13Renviroment_Value4Arry));
                _13Renviroment_Value4Arry = _13Fenviroment_Value4Format.Replace("Phy", ReturnValue.ToString());
                _13Renviroment_Value4Arry = "-" + sc1.Eval(_13Renviroment_Value4Arry).ToString();
            }
            else
            {
                Int32 value1_1 = Convert.ToInt32(_13Renviroment_Value4Arry, 16);
                _13Renviroment_Value4Arry = _13Fenviroment_Value4Format.Replace("Phy", value1_1.ToString());
                _13Renviroment_Value4Arry = sc1.Eval(_13Renviroment_Value4Arry).ToString();
            }
            //////////////////////5555555555555555555555555555555
            string Substring_ValueArry5 = _13Fenviroment_Value5Arry.Substring(0, 1);
            string Substring_ValueArry5_1 = _13Renviroment_Value5Arry.Substring(0, 1);
            char[] Str5 = Substring_ValueArry5.ToCharArray();
            char[] Str5_1 = Substring_ValueArry5_1.ToCharArray();
            if (Str5[0] < 'G' && Str5[0] > '7')
            {
                Int32 ReturnValue = System.Math.Abs(符号位转换(_13Fenviroment_Value5Arry));
                _13Fenviroment_Value5Arry = _13Fenviroment_Value5Format.Replace("Phy", ReturnValue.ToString());
                _13Fenviroment_Value5Arry = "-" + sc1.Eval(_13Fenviroment_Value5Arry).ToString();
            }
            else
            {
                Int32 value1 = Convert.ToInt32(_13Fenviroment_Value5Arry, 16);
                _13Fenviroment_Value5Arry = _13Fenviroment_Value5Format.Replace("Phy", value1.ToString());
                _13Fenviroment_Value5Arry = sc1.Eval(_13Fenviroment_Value5Arry).ToString();
            }

            if (Str5_1[0] < 'G' && Str5_1[0] > '7')
            {
                Int32 ReturnValue = System.Math.Abs(符号位转换(_13Renviroment_Value5Arry));
                _13Renviroment_Value5Arry = _13Fenviroment_Value5Format.Replace("Phy", ReturnValue.ToString());
                _13Renviroment_Value5Arry = "-" + sc1.Eval(_13Renviroment_Value5Arry).ToString();
            }
            else
            {
                Int32 value1_1 = Convert.ToInt32(_13Renviroment_Value5Arry, 16);
                _13Renviroment_Value5Arry = _13Fenviroment_Value5Format.Replace("Phy", value1_1.ToString());
                _13Renviroment_Value5Arry = sc1.Eval(_13Renviroment_Value5Arry).ToString();
            }
            ///////////////////////////////////666666666666666
            string Substring_ValueArry6 = _13Fenviroment_Value6Arry.Substring(0, 1);
            string Substring_ValueArry6_1 = _13Renviroment_Value6Arry.Substring(0, 1);
            char[] Str6 = Substring_ValueArry6.ToCharArray();
            char[] Str6_1 = Substring_ValueArry6_1.ToCharArray();
            if (Str6[0] < 'G' && Str6[0] > '7')
            {
                Int32 ReturnValue = System.Math.Abs(符号位转换(_13Fenviroment_Value6Arry));
                _13Fenviroment_Value6Arry = _13Fenviroment_Value6Format.Replace("Phy", ReturnValue.ToString());
                _13Fenviroment_Value6Arry = "-" + sc1.Eval(_13Fenviroment_Value6Arry).ToString();
            }
            else
            {
                Int32 value1 = Convert.ToInt32(_13Fenviroment_Value6Arry, 16);
                _13Fenviroment_Value6Arry = _13Fenviroment_Value6Format.Replace("Phy", value1.ToString());
                _13Fenviroment_Value6Arry = sc1.Eval(_13Fenviroment_Value6Arry).ToString();
            }

            if (Str6_1[0] < 'G' && Str6_1[0] > '7')
            {
                Int32 ReturnValue = System.Math.Abs(符号位转换(_13Renviroment_Value6Arry));
                _13Renviroment_Value6Arry = _13Fenviroment_Value6Format.Replace("Phy", ReturnValue.ToString());
                _13Renviroment_Value6Arry = "-" + sc1.Eval(_13Renviroment_Value6Arry).ToString();
            }
            else
            {
                Int32 value1_1 = Convert.ToInt32(_13Renviroment_Value6Arry, 16);
                _13Renviroment_Value6Arry = _13Fenviroment_Value6Format.Replace("Phy", value1_1.ToString());
                _13Renviroment_Value6Arry = sc1.Eval(_13Renviroment_Value6Arry).ToString();
            }
            //////////////77777777777777777777777777777777777
            string Substring_ValueArry7 = _13Fenviroment_Value7Arry.Substring(0, 1);
            string Substring_ValueArry7_1 = _13Renviroment_Value7Arry.Substring(0, 1);
            char[] Str7 = Substring_ValueArry7.ToCharArray();
            char[] Str7_1 = Substring_ValueArry7_1.ToCharArray();
            if (Str7[0] < 'G' && Str7[0] > '7')
            {
                Int32 ReturnValue = System.Math.Abs(符号位转换(_13Fenviroment_Value7Arry));
                _13Fenviroment_Value7Arry = _13Fenviroment_Value7Format.Replace("Phy", ReturnValue.ToString());
                _13Fenviroment_Value7Arry = "-" + sc1.Eval(_13Fenviroment_Value7Arry).ToString();
            }
            else
            {
                Int32 value1 = Convert.ToInt32(_13Fenviroment_Value7Arry, 16);
                _13Fenviroment_Value7Arry = _13Fenviroment_Value7Format.Replace("Phy", value1.ToString());
                _13Fenviroment_Value7Arry = sc1.Eval(_13Fenviroment_Value7Arry).ToString();
            }

            if (Str7_1[0] < 'G' && Str7_1[0] > '7')
            {
                Int32 ReturnValue = System.Math.Abs(符号位转换(_13Renviroment_Value7Arry));
                _13Renviroment_Value7Arry = _13Fenviroment_Value7Format.Replace("Phy", ReturnValue.ToString());
                _13Renviroment_Value7Arry = "-" + sc1.Eval(_13Renviroment_Value7Arry).ToString();
            }
            else
            {
                Int32 value1_1 = Convert.ToInt32(_13Renviroment_Value7Arry, 16);
                _13Renviroment_Value7Arry = _13Fenviroment_Value7Format.Replace("Phy", value1_1.ToString());
                _13Renviroment_Value7Arry = sc1.Eval(_13Renviroment_Value7Arry).ToString();
            }
            /////////////////888888888888888
            string Substring_ValueArry8 = _13Fenviroment_Value8Arry.Substring(0, 1);
            string Substring_ValueArry8_1 = _13Renviroment_Value8Arry.Substring(0, 1);
            char[] Str8 = Substring_ValueArry8.ToCharArray();
            char[] Str8_1 = Substring_ValueArry8_1.ToCharArray();
            if (Str8[0] < 'G' && Str8[0] > '7')
            {
                Int32 ReturnValue = System.Math.Abs(符号位转换(_13Fenviroment_Value8Arry));
                _13Fenviroment_Value8Arry = _13Fenviroment_Value8Format.Replace("Phy", ReturnValue.ToString());
                _13Fenviroment_Value8Arry = "-" + sc1.Eval(_13Fenviroment_Value8Arry).ToString();
            }
            else
            {
                Int32 value1 = Convert.ToInt32(_13Fenviroment_Value8Arry, 16);
                _13Fenviroment_Value8Arry = _13Fenviroment_Value8Format.Replace("Phy", value1.ToString());
                _13Fenviroment_Value8Arry = sc1.Eval(_13Fenviroment_Value8Arry).ToString();
            }

            if (Str8_1[0] < 'G' && Str8_1[0] > '7')
            {
                Int32 ReturnValue = System.Math.Abs(符号位转换(_13Renviroment_Value8Arry));
                _13Renviroment_Value8Arry = _13Fenviroment_Value8Format.Replace("Phy", ReturnValue.ToString());
                _13Renviroment_Value8Arry = "-" + sc1.Eval(_13Renviroment_Value8Arry).ToString();
            }
            else
            {
                Int32 value1_1 = Convert.ToInt32(_13Renviroment_Value8Arry, 16);
                _13Renviroment_Value8Arry = _13Fenviroment_Value8Format.Replace("Phy", value1_1.ToString());
                _13Renviroment_Value8Arry = sc1.Eval(_13Renviroment_Value8Arry).ToString();
            }
            ////////////////99999999999999999999999999999999
            if (_13Fenviroment_Value9Byte != 0)
            {
                string Substring_ValueArry9 = _13Fenviroment_Value9Arry.Substring(0, 1);
                string Substring_ValueArry9_1 = _13Renviroment_Value9Arry.Substring(0, 1);
                char[] Str9 = Substring_ValueArry9.ToCharArray();
                char[] Str9_1 = Substring_ValueArry9_1.ToCharArray();
                if (Str9[0] < 'G' && Str9[0] > '7')
                {
                    Int32 ReturnValue = System.Math.Abs(符号位转换(_13Fenviroment_Value9Arry));
                    _13Fenviroment_Value9Arry = _13Fenviroment_Value9Format.Replace("Phy", ReturnValue.ToString());
                    _13Fenviroment_Value9Arry = "-" + sc1.Eval(_13Fenviroment_Value9Arry).ToString();
                }
                else
                {
                    Int32 value1 = Convert.ToInt32(_13Fenviroment_Value9Arry, 16);
                    _13Fenviroment_Value9Arry = _13Fenviroment_Value9Format.Replace("Phy", value1.ToString());
                    _13Fenviroment_Value9Arry = sc1.Eval(_13Fenviroment_Value9Arry).ToString();
                }

                if (Str9_1[0] < 'G' && Str9_1[0] > '7')
                {
                    Int32 ReturnValue = System.Math.Abs(符号位转换(_13Renviroment_Value9Arry));
                    _13Renviroment_Value9Arry = _13Fenviroment_Value9Format.Replace("Phy", ReturnValue.ToString());
                    _13Renviroment_Value9Arry = "-" + sc1.Eval(_13Renviroment_Value9Arry).ToString();
                }
                else
                {
                    Int32 value1_1 = Convert.ToInt32(_13Renviroment_Value9Arry, 16);
                    _13Renviroment_Value9Arry = _13Fenviroment_Value9Format.Replace("Phy", value1_1.ToString());
                    _13Renviroment_Value9Arry = sc1.Eval(_13Renviroment_Value9Arry).ToString();
                }
            }
            #endregion
            #endregion
        }


        /// <summary>
        /// 其他数据解析
        /// </summary>
        private  void SHOWECU13CODE()
        {

            _dfcname = DFCNAME;
            s_13BackTDCnumcode = _13dtcRead.ECU13DTCSingle.Substring(0, 3).PadLeft(4, '0') + "H";
            _13sValue = _13dtcRead.ECU13DTCSingle;
            _pcode = PCODE;
            _spn = SPN;
            _fmi = FM1;
            _dtcb = DTCB;
            _mil = MIL;
            _svs = SVS;
            _envirment1 = Envirment1;
            _envirment2 = Envirment2;
            _envirment3 = Envirment3;
            _envirment4 = Envirment4;
            _envirment5 = Envirment5;
            _envirment6 = Envirment6;
            _envirment7 = Envirment7;
            _envirment8 = Envirment8;
            _envirment9 = Envirment9;
            _13s_Frequency_counter = _13Frequency_counter.ToString();
            _13S_Descrition_Chinese = _13Descrition_Chinese;
            _13S_Descrition_English = _13Descrition_English;

            if (_13Active == "11")
            {
                _13Sactive = "Active";
            }
            else
            {
                _13Sactive = "NOT_acive";
            }
            if (_13TEST == 1)
            {
                _13Tested = "Tested";
            }
            else
            {
                _13Tested = "Not_tested";
            }

            if (_13Debounce_completed == 1)
            {
                _13s_Debounce_completed = "YES";
            }
            else
            {
                _13s_Debounce_completed = "NO";
            }
            //
            if (this.MIL.StartsWith("ON"))
            {
                _13S_MIL_lamp_is_blinking = "YES";
                _13S_Visible_to_OBD_tool = "YES";
            }
            else
            {
                this._13S_MIL_lamp_is_blinking = "NO";
                this._13S_Visible_to_OBD_tool = "NO";
            }
            ///
            /// ECU 的环境变量。。。。
            /// 1
            _13Fenviroment_Value1 = _13Fenviroment_Value1Arry;
            _13Renviroment_Value1 = _13Renviroment_Value1Arry;
            _13EnvirmentUnit1 = _13EnvirmentUnit1A;
            _13EnvirmentCD1 = _13EnvirmentCD1A;

            //2
            _13Fenviroment_Value2 = _13Fenviroment_Value2Arry;
            _13Renviroment_Value2 = _13Renviroment_Value2Arry;
            _13EnvirmentUnit2 = _13EnvirmentUnit2A;
            _13EnvirmentCD2 = _13EnvirmentCD2A;
            //3

            _13Fenviroment_Value3 = _13Fenviroment_Value3Arry;
            _13Renviroment_Value3 = _13Renviroment_Value3Arry;
            _13EnvirmentUnit3 = _13EnvirmentUnit3A;
            _13EnvirmentCD3 = _13EnvirmentCD3A;
            //4

            _13Fenviroment_Value4 = _13Fenviroment_Value4Arry;
            _13Renviroment_Value4 = _13Renviroment_Value4Arry;
            _13EnvirmentUnit4 = _13EnvirmentUnit4A;
            _13EnvirmentCD4 = _13EnvirmentCD4A;

            //5
            _13Fenviroment_Value5 = _13Fenviroment_Value5Arry;
            _13Renviroment_Value5 = _13Renviroment_Value5Arry;
            _13EnvirmentUnit5 = _13EnvirmentUnit5A;
            _13EnvirmentCD5 = _13EnvirmentCD5A;
            //6
            _13Fenviroment_Value6 = _13Fenviroment_Value6Arry;
            _13Renviroment_Value6 = _13Renviroment_Value6Arry;
            _13EnvirmentUnit6 = _13EnvirmentUnit6A;
            _13EnvirmentCD6 = _13EnvirmentCD6A;
            //7
            _13Fenviroment_Value7 = _13Fenviroment_Value7Arry;
            _13Renviroment_Value7 = _13Renviroment_Value7Arry;
            _13EnvirmentUnit7 = _13EnvirmentUnit7A;
            _13EnvirmentCD7 = _13EnvirmentCD7A;
            //8
            _13Fenviroment_Value8 = _13Fenviroment_Value8Arry;
            _13Renviroment_Value8 = _13Renviroment_Value8Arry;
            _13EnvirmentUnit8 = _13EnvirmentUnit8A;
            _13EnvirmentCD8 = _13EnvirmentCD8A;
            //9
            _13Fenviroment_Value9 = _13Fenviroment_Value9Arry;
            _13Renviroment_Value9 = _13Renviroment_Value9Arry;
            _13EnvirmentUnit9 = _13EnvirmentUnit9A;
            _13EnvirmentCD9 = _13EnvirmentCD9A;

            InsertDtccode13();
            // MyMeans.AccessBreak();
        }


        /// <summary>
        /// 符号位转换公用函数
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private Int32 符号位转换(string inputString)
        {
            string Astring = inputString;
            Int32 res = Int32.Parse(Astring, System.Globalization.NumberStyles.AllowHexSpecifier);
            return res;
        }

        /// <summary>
        /// 获取环境变量ID 模式
        /// </summary>
        /// <param name="Enviroment"></param>
        /// <returns></returns>
        private int Get_13Envirment_ID(string Enviroment)
        {
            //初始值
            int _13Envirment = 0;
            //
            if (Enviroment == "SIGNALS_RDLI_GlbDa_lTotDst")
            {
                _13Envirment = _13EnvirmentID[0];
            }

            else if (Enviroment == "SIGNALS_RDLI_CEngDsT_t")
            {
                _13Envirment = _13EnvirmentID[1];

            }
            else if (Enviroment == "SIGNALS_RDLI_Epm_nEng")
            {
                _13Envirment = _13EnvirmentID[2];

            }
            else if (Enviroment == "SIGNALS_RDLI_Air_pSensPIntkVUs")
            {
                _13Envirment = _13EnvirmentID[3];

            }
            else if (Enviroment == "SIGNALS_RDLI_InjCtl_qSetUnBal")
            {
                _13Envirment = _13EnvirmentID[4];

            }
            else if (Enviroment == "SIGNALS_RDLI_CoETS_rTrq")
            {
                _13Envirment = _13EnvirmentID[5];

            }
            else if (Enviroment == "SIGNALS_RDLI_APP_r")
            {
                _13Envirment = _13EnvirmentID[6];

            }
            else if (Enviroment == "SIGNALS_RDLI_RailP_pFlt")
            {
                _13Envirment = _13EnvirmentID[7];

            }
            else if (Enviroment == "SIGNALS_RDLI_VehV_v")
            {
                _13Envirment = _13EnvirmentID[8];

            }

            else if (Enviroment == "SIGNALS_RDLI_RailP_pLin")
            {
                _13Envirment = _13EnvirmentID[9];

            }
            else if (Enviroment == "SIGNALS_RDLI_Epm_stSync")
            {
                _13Envirment = _13EnvirmentID[10];

            }
            else if (Enviroment == "SIGNALS_CEngDsT_t")
            {
                _13Envirment = _13EnvirmentID[11];

            }

            else if (Enviroment == "SIGNALS_BattU_u")
            {
                _13Envirment = _13EnvirmentID[12];

            }
            else if (Enviroment == "SIGNALS_InjUn_stStrt")
            {
                _13Envirment = _13EnvirmentID[13];

            }
            else if (Enviroment == "SIGNALS_RDLI_RailP_uOfsStrt")
            {
                _13Envirment = _13EnvirmentID[14];
            }
            else if (Enviroment == "SIGNALS_RDLI_RailP_uRaw")
            {
                _13Envirment = _13EnvirmentID[15];
            }
            else if (Enviroment == "SIGNALS_RDLI_InjCtl_qCurr")
            {
                _13Envirment = _13EnvirmentID[16];
            }
            else if (Enviroment == "SIGNALS_RDLI_Brk_st")
            {
                _13Envirment = _13EnvirmentID[17];
            }
            else if (Enviroment == "SIGNALS_RDLI_Brk_stMn")
            {
                _13Envirment = _13EnvirmentID[18];
            }
            else if (Enviroment == "SIGNALS_RDLI_Brk_stRed")
            {
                _13Envirment = _13EnvirmentID[19];
            }
            else if (Enviroment == "SIGNALS_RDLI_APP_rFlt_mp")
            {
                _13Envirment = _13EnvirmentID[20];
            }
            else if (Enviroment == "SIGNALS_RDLI_APP_uRaw1")
            {
                _13Envirment = _13EnvirmentID[21];
            }
            else if (Enviroment == "SIGNALS_RDLI_APP_uRaw2")
            {
                _13Envirment = _13EnvirmentID[22];
            }
            else if (Enviroment == "SIGNALS_RDLI_Clth_stRaw")
            {
                _13Envirment = _13EnvirmentID[23];
            }
            else if (Enviroment == "SIGNALS_RDLI_APP_stPlaBrk_mp")
            {
                _13Envirment = _13EnvirmentID[24];
            }
            else if (Enviroment == "SIGNALS_RDLI_InjCtl_qCurr")
            {
                _13Envirment = _13EnvirmentID[25];
            }
            ///
            else if (Enviroment == "SIGNALS_RDLI_MeUn_dvolSet")
            {
                _13Envirment = _13EnvirmentID[26];
            }
            else if (Enviroment == "SIGNALS_Rail_pDvt")
            {
                _13Envirment = _13EnvirmentID[27];
            }
            else if (Enviroment == "SIGNALS_IVDia_stErrChp_0")
            {
                _13Envirment = _13EnvirmentID[28];
            }
            else if (Enviroment == "SIGNALS_IVDia_stErrClctCyl_0")
            {
                _13Envirment = _13EnvirmentID[29];
            }
            else if (Enviroment == "SIGNALS_IVDia_stErrClctCyl_1")
            {
                _13Envirment = _13EnvirmentID[30];
            }
            else if (Enviroment == "SIGNALS_IVDia_stErrClctCyl_2")
            {
                _13Envirment = _13EnvirmentID[31];
            }
            else if (Enviroment == "SIGNALS_IVDia_stErrClctCyl_3")
            {
                _13Envirment = _13EnvirmentID[32];
            }
            else if (Enviroment == "SIGNALS_IVDia_stErrClctCyl_4")
            {
                _13Envirment = _13EnvirmentID[33];
            }
            else if (Enviroment == "SIGNALS_IVDia_stErrClctCyl_5")
            {
                _13Envirment = _13EnvirmentID[34];
            }
            else if (Enviroment == "SIGNALS_RDLI_EBrk_stSwtDeb")
            {
                _13Envirment = _13EnvirmentID[35];
            }
            else if (Enviroment == "SIGNALS_RDLI_EngBrk_stECRCtl")
            {
                _13Envirment = _13EnvirmentID[36];
            }
            else if (Enviroment == "SIGNALS_RDLI_ExhFlpLP_rPs")
            {
                _13Envirment = _13EnvirmentID[37];
            }
            else if (Enviroment == "SIGNALS_RDLI_CEngDsT_tSens")
            {
                _13Envirment = _13EnvirmentID[38];
            }
            else if (Enviroment == "SIGNALS_RDLI_CEngDsT_uRaw")
            {
                _13Envirment = _13EnvirmentID[39];
            }
            else if (Enviroment == "SIGNALS_RDLI_IAirHt_st0")
            {
                _13Envirment = _13EnvirmentID[40];
            }
            else if (Enviroment == "SIGNALS_RDLI_IAirHt_stPs0")
            {
                _13Envirment = _13EnvirmentID[41];
            }

            else if (Enviroment == "SIGNALS_EnvT_t")
            {
                _13Envirment = _13EnvirmentID[42];
            }
            else if (Enviroment == "SIGNALS_RDLI_MeUn_iActFlt")
            {
                _13Envirment = _13EnvirmentID[43];
            }
            else if (Enviroment == "SIGNALS_RDLI_MeUn_rPs")
            {
                _13Envirment = _13EnvirmentID[44];
            }
            ///////
            else if (Enviroment == "SIGNALS_RDLI_MeUn_uRaw")
            {
                _13Envirment = _13EnvirmentID[45];
            }
            else if (Enviroment == "SIGNALS_RDLI_RailP_uOfsStrt")
            {
                _13Envirment = _13EnvirmentID[46];
            }
            else if (Enviroment == "SIGNALS_RDLI_EnvP_pSens")
            {
                _13Envirment = _13EnvirmentID[47];
            }
            else if (Enviroment == "SIGNALS_RDLI_Air_tCACDs")
            {
                _13Envirment = _13EnvirmentID[48];
            }
            else if (Enviroment == "SIGNALS_RDLI_Air_uRawTCACDs")
            {
                _13Envirment = _13EnvirmentID[49];
            }
            else if (Enviroment == "SIGNALS_RDLI_Air_pSensPIntkVUs")
            {
                _13Envirment = _13EnvirmentID[50];
            }
            else if (Enviroment == "SIGNALS_RDLI_Air_uRawPIntkVUs")
            {
                _13Envirment = _13EnvirmentID[51];
            }
            else if (Enviroment == "SIGNALS_RDLI_EnvP_uRaw")
            {
                _13Envirment = _13EnvirmentID[52];
            }
            else if (Enviroment == "SIGNALS_PID68h_Air_tSensTIntkVUs")
            {

                _13Envirment = _13EnvirmentID[53];

            }
            return _13Envirment;
        }


        public void InsertDtccode13()
        {
            #region 插入DTC数据库
            string title = "#" + _13DTCID + "  " + _dfcname + "     " + s_13BackTDCnumcode + "    " + _13Sactive + "\\" + _13Tested;
            MyMeans.InsertDTC(title, _13S_Descrition_English, "", "", "", _13S_Descrition_Chinese);
            MyMeans.InsertDTC("", "P-Code : " + this._pcode, "SPN : " + this._spn, "FMI : " + this._fmi, "DTCB : " + this._dtcb, "");
            MyMeans.InsertDTC("", "Frequency counter", "", this._13s_Frequency_counter, "", "发生频率");
            MyMeans.InsertDTC("", "Error delete counter", "", "40", "", "完成测试数 (DLC)");
            MyMeans.InsertDTC("", "Status", "", "", "", "");
            MyMeans.InsertDTC("", "", "Debounce completed", this._13s_Debounce_completed, "", "");
            MyMeans.InsertDTC("", "", "Visible to OBD tool", this._13S_Visible_to_OBD_tool, "", "");
            MyMeans.InsertDTC("", "", "MIL lamp on", this._mil, "", "");
            MyMeans.InsertDTC("", "", "MIL lamp is blinking", this._13S_MIL_lamp_is_blinking, "", "");
            MyMeans.InsertDTC("", "", "System lamp on", this._svs, "", "");
            MyMeans.InsertDTC("", "Environmental condition ", "", "First:", "Latest:", "");
            MyMeans.InsertDTC("", "", this._envirment1, _13Fenviroment_Value1 + _13EnvirmentUnit1, _13Renviroment_Value1 + _13EnvirmentUnit1, _13EnvirmentCD1);
            MyMeans.InsertDTC("", "", this._envirment2, _13Fenviroment_Value2 + _13EnvirmentUnit2, _13Renviroment_Value2 + _13EnvirmentUnit2, _13EnvirmentCD2);
            MyMeans.InsertDTC("", "", this._envirment3, _13Fenviroment_Value3 + _13EnvirmentUnit3, _13Renviroment_Value3 + _13EnvirmentUnit3, _13EnvirmentCD3);
            MyMeans.InsertDTC("", "", this._envirment4, _13Fenviroment_Value4 + _13EnvirmentUnit4, _13Renviroment_Value4 + _13EnvirmentUnit4, _13EnvirmentCD4);
            MyMeans.InsertDTC("", "", this._envirment5, _13Fenviroment_Value5 + _13EnvirmentUnit5, _13Renviroment_Value5 + _13EnvirmentUnit5, _13EnvirmentCD5);
            MyMeans.InsertDTC("", "", this._envirment6, _13Fenviroment_Value6 + _13EnvirmentUnit6, _13Renviroment_Value6 + _13EnvirmentUnit6, _13EnvirmentCD6);
            MyMeans.InsertDTC("", "", this._envirment7, _13Fenviroment_Value7 + _13EnvirmentUnit7, _13Renviroment_Value7 + _13EnvirmentUnit7, _13EnvirmentCD7);
            MyMeans.InsertDTC("", "", this._envirment8, _13Fenviroment_Value8 + _13EnvirmentUnit8, _13Renviroment_Value8 + _13EnvirmentUnit8, _13EnvirmentCD8);
            MyMeans.InsertDTC("", "", this._envirment9, _13Fenviroment_Value9 + _13EnvirmentUnit9, _13Renviroment_Value9 + _13EnvirmentUnit9, _13EnvirmentCD9);
            MyMeans.InsertDTC("", "Raw values:", _13sValue, "", "", "");
            #endregion
        }


    }
    #endregion

}