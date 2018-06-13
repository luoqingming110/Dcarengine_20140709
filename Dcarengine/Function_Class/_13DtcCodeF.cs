using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading;
using System.Data.OleDb;
using Dcarengine.SQLData;
using Dcarengine.UIForm;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using Dcarengine.service;

namespace Dcarengine.Function_Class
{
    class _13DtcCodeF
    {

        #region 变量
        string[] _9DTCcode;
        public int DTCcodeLength = _13dtcRead.Save13BackDTC.Length;
       
        /// <summary>
        /// con 
        /// </summary>
        OleDbConnection con;   
        
        string[] Value;
        int[] Frequency_counter; string s_Frequency_counter;
        int[] ErrordeleteCounter; string s_ErrordeleteCounter;
        int[] Debounce_completed; string s_Debounce_completed;
        int[] Visible_to_OBD_tool; string s_Visible_to_OBD_tool;
        int[] MIL_lamp_on; string s_MIL_lamp_on;
        int[] MIL_lamp_is_blinking; string s_MIL_lamp_is_blinking;
        int[] System_lamp_on; string s_System_lamp_on;
        int[] First_Bit; int s_First_Bit;
        int[] Current_Bit; int s_Current_Bit;
        int[] All_Bit;
        public int[] TEST; public string Tested = "   ";
        string[] _13Descrition_English; string _13S_Descrition_English = "";
        string[] _13Descrition_Chinese; string _13S_Descrition_Chinese = "";
        string[] _13VALUES; string _13sValue = "";
        int[] _13Debounce_completed; string _13s_Debounce_completed;
        int[] _13Frequency_counter; string _13s_Frequency_counter;
        public int[] _13TEST; public string _13Tested = "     ";
        string[] _13BackTDCnumcode; string s_13BackTDCnumcode;
        string[] _13DTCCODE; string _13Dtccode;
        public int _13DTCcodenum = _13dtcRead.Save13BackDTC.Length;
        string[] DFCNAME; string _dfcname;
        string[] PCODE; string _pcode;
        string[] SPN; string _spn;
        string[] FM1; string _fmi;
        string[] DTCB; string _dtcb;
        string[] MIL; string _mil;
        string[] SVS; string _svs;
        string[] Envirments; string _envirments = "";
        string[] Envirment1; string _envirment1 = "";
        string[] Envirment2; string _envirment2 = "";
        string[] Envirment3; string _envirment3 = "";
        string[] Envirment4; string _envirment4 = "";
        string[] Envirment5; string _envirment5 = "";
        string[] Envirment6; string _envirment6 = "";
        string[] Envirment7; string _envirment7 = "";
        string[] Envirment8; string _envirment8 = "";
        string[] Envirment9; string _envirment9 = "";
        //故障序列号。。。
        public int _13DTCID;
        string[] _13Visible_to_OBD_tool; string _13S_Visible_to_OBD_tool = " ";
        string[] _13MIL_lamp_is_blinking; string _13S_MIL_lamp_is_blinking = " ";
        string[] _13Active; string _13Sactive = " ";

        //ECU环境变量的解析公式。。。。。
        string[] _13Fenviroment_Value1Arry; string[] _13Renviroment_Value1Arry; string[] _13Fenviroment_Value1Format; int[] _13Fenviroment_Value1Byte;
        string _13Fenviroment_Value1; string _13Renviroment_Value1;
        string[] _13Fenviroment_Value2Arry; string[] _13Renviroment_Value2Arry; string[] _13Fenviroment_Value2Format; int[] _13Fenviroment_Value2Byte;
        string _13Fenviroment_Value2; string _13Renviroment_Value2;
        string[] _13Fenviroment_Value3Arry; string[] _13Renviroment_Value3Arry; string[] _13Fenviroment_Value3Format; int[] _13Fenviroment_Value3Byte;
        string _13Fenviroment_Value3; string _13Renviroment_Value3;
        string[] _13Fenviroment_Value4Arry; string[] _13Renviroment_Value4Arry; string[] _13Fenviroment_Value4Format; int[] _13Fenviroment_Value4Byte;
        string _13Fenviroment_Value4; string _13Renviroment_Value4;
        string[] _13Fenviroment_Value5Arry; string[] _13Renviroment_Value5Arry; string[] _13Fenviroment_Value5Format; int[] _13Fenviroment_Value5Byte;
        string _13Fenviroment_Value5; string _13Renviroment_Value5;
        string[] _13Fenviroment_Value6Arry; string[] _13Renviroment_Value6Arry; string[] _13Fenviroment_Value6Format; int[] _13Fenviroment_Value6Byte;
        string _13Fenviroment_Value6; string _13Renviroment_Value6;
        string[] _13Fenviroment_Value7Arry; string[] _13Renviroment_Value7Arry; string[] _13Fenviroment_Value7Format; int[] _13Fenviroment_Value7Byte;
        string _13Fenviroment_Value7; string _13Renviroment_Value7;
        string[] _13Fenviroment_Value8Arry; string[] _13Renviroment_Value8Arry; string[] _13Fenviroment_Value8Format; int[] _13Fenviroment_Value8Byte;
        string _13Fenviroment_Value8; string _13Renviroment_Value8;
        string[] _13Fenviroment_Value9Arry; string[] _13Renviroment_Value9Arry; string[] _13Fenviroment_Value9Format; int[] _13Fenviroment_Value9Byte;
        string _13Fenviroment_Value9; string _13Renviroment_Value9;
        int[] _13EnvirmentID = new int[54];
        private string _13EnvirmentUnit1; private string[] _13EnvirmentUnit1A; private string _13EnvirmentCD1; private string[] _13EnvirmentCD1A;
        private string _13EnvirmentUnit2; private string[] _13EnvirmentUnit2A; private string _13EnvirmentCD2; private string[] _13EnvirmentCD2A;
        private string _13EnvirmentUnit3; private string[] _13EnvirmentUnit3A; private string _13EnvirmentCD3; private string[] _13EnvirmentCD3A;
        private string _13EnvirmentUnit4; private string[] _13EnvirmentUnit4A; private string _13EnvirmentCD4; private string[] _13EnvirmentCD4A;
        private string _13EnvirmentUnit5; private string[] _13EnvirmentUnit5A; private string _13EnvirmentCD5; private string[] _13EnvirmentCD5A;
        private string _13EnvirmentUnit6; private string[] _13EnvirmentUnit6A; private string _13EnvirmentCD6; private string[] _13EnvirmentCD6A;
        private string _13EnvirmentUnit7; private string[] _13EnvirmentUnit7A; private string _13EnvirmentCD7; private string[] _13EnvirmentCD7A;
        private string _13EnvirmentUnit8; private string[] _13EnvirmentUnit8A; private string _13EnvirmentCD8; private string[] _13EnvirmentCD8A;
        private string _13EnvirmentUnit9; private string[] _13EnvirmentUnit9A; private string _13EnvirmentCD9; private string[] _13EnvirmentCD9A;

        int DtcFalutCodeNumFlag = 11;   //这里是标示ECU的序列号，
        #endregion


        /// <summary>
        /// 构造函数
        /// </summary>
       public   _13DtcCodeF() {

            try
            {
                SQLData.AccessDbClass mybd = new AccessDbClass(MyMeans.strConn1);
                con = new OleDbConnection(MyMeans.strConn1);
                con.Open();
            }
            catch
            {
                MessageBox.Show("连接ACCESS数据库出错！");
            }

        }

        /// <summary>
        /// 析构函数
        /// </summary>
         ~_13DtcCodeF() {

            con.Close();
        }

        #region 后面解析的函数些个  整体一块
        public void ConnectAccessF()
        {
       

            #region
            _9DTCcode = new string[DTCcodeLength];
            for (int i = 0; i < DTCcodeLength; i++)
            {
                _9DTCcode[i] = _13dtcRead.Save13BackDTC[i];
            }

            Value = new string[DTCcodeLength];

            Frequency_counter = new int[DTCcodeLength];
            ErrordeleteCounter = new int[DTCcodeLength];
            Debounce_completed = new int[DTCcodeLength];

            Visible_to_OBD_tool = new int[DTCcodeLength];
            MIL_lamp_on = new int[DTCcodeLength];
            MIL_lamp_is_blinking = new int[DTCcodeLength];
            System_lamp_on = new int[DTCcodeLength];
            First_Bit = new int[DTCcodeLength];
            Current_Bit = new int[DTCcodeLength];
            All_Bit = new int[DTCcodeLength];
            TEST = new int[DTCcodeLength];

            //*************************************//
            //                                     //
            //                                     //
            //*************************************//
            _13Active = new string[_13DTCcodenum];
            _13VALUES = new string[_13DTCcodenum];
            _13Debounce_completed = new int[_13DTCcodenum];
            _13Frequency_counter = new int[_13DTCcodenum];
            _13TEST = new int[_13DTCcodenum];
            _13BackTDCnumcode = new string[_13DTCcodenum];
            _13DTCCODE = new string[_13DTCcodenum];
            _13Descrition_Chinese = new string[_13DTCcodenum];
            _13Descrition_English = new string[_13DTCcodenum];
            PCODE = new string[_13DTCcodenum];
            SPN = new string[_13DTCcodenum];
            FM1 = new string[_13DTCcodenum];
            DTCB = new string[_13DTCcodenum];
            MIL = new string[_13DTCcodenum];
            SVS = new string[_13DTCcodenum];
            Envirments = new string[_13DTCcodenum];
            Envirment1 = new string[_13DTCcodenum];
            Envirment2 = new string[_13DTCcodenum];
            Envirment3 = new string[_13DTCcodenum];
            Envirment4 = new string[_13DTCcodenum];
            Envirment5 = new string[_13DTCcodenum];
            Envirment6 = new string[_13DTCcodenum];
            Envirment7 = new string[_13DTCcodenum];
            Envirment8 = new string[_13DTCcodenum];
            Envirment9 = new string[_13DTCcodenum];
            DFCNAME = new string[_13DTCcodenum];
            _13Visible_to_OBD_tool  = new string[_13DTCcodenum];
            _13MIL_lamp_is_blinking = new string[_13DTCcodenum];

            //环境解析的变量数据。。。。。,关键是有两主数据
            _13Fenviroment_Value1Arry = new string[_13DTCcodenum]; _13Renviroment_Value1Arry = new string[_13DTCcodenum];
            _13Fenviroment_Value2Arry = new string[_13DTCcodenum]; _13Renviroment_Value2Arry = new string[_13DTCcodenum];
            _13Fenviroment_Value3Arry = new string[_13DTCcodenum]; _13Renviroment_Value3Arry = new string[_13DTCcodenum];
            _13Fenviroment_Value4Arry = new string[_13DTCcodenum]; _13Renviroment_Value4Arry = new string[_13DTCcodenum];
            _13Fenviroment_Value5Arry = new string[_13DTCcodenum]; _13Renviroment_Value5Arry = new string[_13DTCcodenum];
            _13Fenviroment_Value6Arry = new string[_13DTCcodenum]; _13Renviroment_Value6Arry = new string[_13DTCcodenum];
            _13Fenviroment_Value7Arry = new string[_13DTCcodenum]; _13Renviroment_Value7Arry = new string[_13DTCcodenum];
            _13Fenviroment_Value8Arry = new string[_13DTCcodenum]; _13Renviroment_Value8Arry = new string[_13DTCcodenum];
            _13Fenviroment_Value9Arry = new string[_13DTCcodenum]; _13Renviroment_Value9Arry = new string[_13DTCcodenum];

            //这里是公式的解析。。。。

            _13Fenviroment_Value1Format = new string[_13DTCcodenum];
            _13Fenviroment_Value2Format = new string[_13DTCcodenum];
            _13Fenviroment_Value3Format = new string[_13DTCcodenum];
            _13Fenviroment_Value4Format = new string[_13DTCcodenum];
            _13Fenviroment_Value5Format = new string[_13DTCcodenum];
            _13Fenviroment_Value6Format = new string[_13DTCcodenum];
            _13Fenviroment_Value7Format = new string[_13DTCcodenum];
            _13Fenviroment_Value8Format = new string[_13DTCcodenum];
            _13Fenviroment_Value9Format = new string[_13DTCcodenum];
            for (int i = 0; i < 54; i++)
            {
                _13EnvirmentID[i] = i + 1;

            }
            /////////////////////////////////////////////////////////
            _13Fenviroment_Value1Byte = new int[_13DTCcodenum];
            _13Fenviroment_Value2Byte = new int[_13DTCcodenum];
            _13Fenviroment_Value3Byte = new int[_13DTCcodenum];
            _13Fenviroment_Value4Byte = new int[_13DTCcodenum];
            _13Fenviroment_Value5Byte = new int[_13DTCcodenum];
            _13Fenviroment_Value6Byte = new int[_13DTCcodenum];
            _13Fenviroment_Value7Byte = new int[_13DTCcodenum];
            _13Fenviroment_Value8Byte = new int[_13DTCcodenum];
            _13Fenviroment_Value9Byte = new int[_13DTCcodenum];
            ///////////////////////////////////////////////////////
            _13EnvirmentUnit1A = new string[_13DTCcodenum];
            _13EnvirmentUnit2A = new string[_13DTCcodenum];
            _13EnvirmentUnit3A = new string[_13DTCcodenum];
            _13EnvirmentUnit4A = new string[_13DTCcodenum];
            _13EnvirmentUnit5A = new string[_13DTCcodenum];
            _13EnvirmentUnit6A = new string[_13DTCcodenum];
            _13EnvirmentUnit7A = new string[_13DTCcodenum];
            _13EnvirmentUnit8A = new string[_13DTCcodenum];
            _13EnvirmentUnit9A = new string[_13DTCcodenum];
            //故障的中文翻译
            _13EnvirmentCD1A = new string[_13DTCcodenum];
            _13EnvirmentCD2A = new string[_13DTCcodenum];
            _13EnvirmentCD3A = new string[_13DTCcodenum];
            _13EnvirmentCD4A = new string[_13DTCcodenum];
            _13EnvirmentCD5A = new string[_13DTCcodenum];
            _13EnvirmentCD6A = new string[_13DTCcodenum];
            _13EnvirmentCD7A = new string[_13DTCcodenum];
            _13EnvirmentCD8A = new string[_13DTCcodenum];
            _13EnvirmentCD9A = new string[_13DTCcodenum];
            #endregion

            ShowDtcCodeF();

        }          //连接数据库


        public void ShowDtcCodeF()
        {     //这个是最后显示的函数
            this.DataInitByDb();
            this._13解析环境();
            SHOWECU13CODE();
            SaveFileFunction.Dtc_SaveExcel();
        }

        private void DataInitByDb()                          //初始化？？？？？？
        {
            int[] _ToSQl = new int[DTCcodeLength];
            //string[] _13DTCTOSQL = MainF.ECU13DTC;
            string[] _13DTCTOSQL = _13dtcRead.ECU13DTC;
            for (int i = 0; i < DTCcodeLength; i++)
            {
                _13BackTDCnumcode[i] = _13DTCTOSQL[i];
                _13DTCTOSQL[i] = _13DTCTOSQL[i].Substring(0, 3);
                _ToSQl[i] = Convert.ToInt32(_13DTCTOSQL[i], 16);
            }

            OleDbCommand cmd;
            for (int i = 0; i < DTCcodeLength; i++)
            {
                string[] cccc = _13dtcRead.Save13BackDTC[i].Split('\r');
                string s1 = cccc[1].Substring(6, 2);
                _13Frequency_counter[i] = Convert.ToInt32(s1, 16);
                //状态位，这里是代表的Active，表示状态位。。。。。。这里指需要一位而已啊。。。
                string status1 = cccc[1].Substring(15, 1);
                string status2 = cccc[1].Substring(16, 1);
                int status1to10jinz = int.Parse(Convert.ToInt32(status1, 16).ToString("X"), System.Globalization.NumberStyles.HexNumber);
                string status1to2jinz = Convert.ToString(status1to10jinz, 2).PadLeft(4, '0');
                _13Active[i] = status1to2jinz.Substring(1, 2);
                // DTC 高位和地位之间的转化。。。。
                string s2 = cccc[1].Substring(9, 5);
                string s3 = s2.Replace(" ", "");
                string s4 = s3.Substring(0, 1);
                int s4TO10jinz = Convert.ToInt32(s4, 16);
                int s4To16jianz = int.Parse(s4TO10jinz.ToString("X"), System.Globalization.NumberStyles.HexNumber);
                string s4To2jianz = Convert.ToString(s4To16jianz, 2).PadLeft(4, '0');
                //这里是表达有没有被检测的数据。
                string subs4 = s4To2jianz.Substring(0, 1);
                _13TEST[i] = Convert.ToInt32(subs4);
                // 这里是表达有没有被检查的。。。。
                string subs5 = s4To2jianz.Substring(0, 1);
                _13Debounce_completed[i] = Convert.ToInt32(subs5);
                //解析这里的环境变量
                string Enviroment = cccc[1].Replace(" ", "");
                //这里是数据库查询的程序代码。。。。。
                try
                {
                    string select = "SELECT * FROM   ECU13DTC   where  DTCMNUM=  " + _ToSQl[i];
                    cmd = new OleDbCommand(select, con);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DFCNAME[i] = (string)reader[2];
                        _13Descrition_English[i] = (string)reader[3];
                        _13Descrition_Chinese[i] = (string)reader[4];
                        PCODE[i] = (string)reader[5];
                        SPN[i] = (string)reader[6];
                        FM1[i] = (string)reader[7];
                        DTCB[i] = (string)reader[8];
                        MIL[i] = (string)reader[9];
                        SVS[i] = (string)reader[10];
                        Envirment1[i] = (string)reader[11];
                        Envirment2[i] = (string)reader[12];
                        Envirment3[i] = (string)reader[13];
                        Envirment4[i] = (string)reader[14];
                        Envirment5[i] = (string)reader[15];
                        Envirment6[i] = (string)reader[16];
                        Envirment7[i] = (string)reader[17];
                        Envirment8[i] = (string)reader[18];
                        Envirment9[i] = (string)reader[19];
                    }
                    con.Close();
                    con.Open();
                }
                catch
                {
                    DtcFalutCodeNumFlag = i;
                    break;                                                   //跳过此次数据读取。。。
                }
            }
        }

        private void _13解析环境()
        {
            #region
            //    DataTable dt = new System.Data.DataTable("aa");
            //    SqlCommand cmd;
            OleDbCommand cmd;
            //这里是数据库查询的程序代码。。。。。
            for (int m = 0; m < _13DTCcodenum; m++)
            {
                if (m == DtcFalutCodeNumFlag) break;
                string select1 = "SELECT * FROM   ECU13Envirment_format   where  Envirment_ID=" + Get_13Envirment_ID(Envirment1[m]);
                cmd = new OleDbCommand(select1, con);
                OleDbDataReader reader1 = cmd.ExecuteReader();
                while (reader1.Read())
                {

                    _13Fenviroment_Value1Format[m] = (string)reader1[4];
                    _13Fenviroment_Value1Byte[m] = ((int)reader1[6]) * 2;
                    _13EnvirmentUnit1A[m] = (string)reader1[5];
                    _13EnvirmentCD1A[m] = (string)reader1[3];
                }
                con.Close();
                con.Open();
                string select2 = "SELECT * FROM   ECU13Envirment_format   where  Envirment_ID =" + Get_13Envirment_ID(Envirment2[m]);
                cmd = new OleDbCommand(select2, con);
                OleDbDataReader reader2 = cmd.ExecuteReader();

                while (reader2.Read())
                {

                    _13Fenviroment_Value2Format[m] = (string)reader2[4];
                    _13Fenviroment_Value2Byte[m] = ((int)reader2[6]) * 2;
                    _13EnvirmentUnit2A[m] = (string)reader2[5];
                    _13EnvirmentCD2A[m] = (string)reader2[3];
                }
                con.Close();
                con.Open();
                /////////////////////////
                string select3 = "SELECT * FROM   ECU13Envirment_format   where  Envirment_ID=" + Get_13Envirment_ID(Envirment3[m]);
                //         cmd = new SqlCommand(select3, con);
                //         SqlDataReader reader3 = cmd.ExecuteReader();
                cmd = new OleDbCommand(select3, con);
                OleDbDataReader reader3 = cmd.ExecuteReader();
                while (reader3.Read())
                {

                    _13Fenviroment_Value3Format[m] = (string)reader3[4];
                    _13Fenviroment_Value3Byte[m] = ((int)reader3[6]) * 2;
                    _13EnvirmentUnit3A[m] = (string)reader3[5];
                    _13EnvirmentCD3A[m] = (string)reader3[3];
                }
                con.Close();
                con.Open();
                ////////////////////////
                string select4 = "SELECT * FROM   ECU13Envirment_format   where  Envirment_ID=" + Get_13Envirment_ID(Envirment4[m]);

                //    cmd = new SqlCommand(select4, con);
                //    SqlDataReader reader4 = cmd.ExecuteReader();
                cmd = new OleDbCommand(select4, con);
                OleDbDataReader reader4 = cmd.ExecuteReader();

                while (reader4.Read())
                {

                    _13Fenviroment_Value4Format[m] = (string)reader4[4];
                    _13Fenviroment_Value4Byte[m] = ((int)reader4[6]) * 2;
                    _13EnvirmentUnit4A[m] = (string)reader4[5];
                    _13EnvirmentCD4A[m] = (string)reader4[3];
                }
                con.Close();
                con.Open();

                /////////////
                string select5 = "SELECT * FROM   ECU13Envirment_format   where  Envirment_ID=" + Get_13Envirment_ID(Envirment5[m]);
                //      cmd = new SqlCommand(select5, con);
                //      SqlDataReader reader5 = cmd.ExecuteReader();
                cmd = new OleDbCommand(select5, con);
                OleDbDataReader reader5 = cmd.ExecuteReader();

                while (reader5.Read())
                {

                    _13Fenviroment_Value5Format[m] = (string)reader5[4];
                    _13Fenviroment_Value5Byte[m] = ((int)reader5[6]) * 2;
                    _13EnvirmentUnit5A[m] = (string)reader5[5];
                    _13EnvirmentCD5A[m] = (string)reader5[3];
                }
                con.Close();
                con.Open();
                //////////
                string select6 = "SELECT * FROM   ECU13Envirment_format   where Envirment_ID=" + Get_13Envirment_ID(Envirment6[m]);

                //     cmd = new SqlCommand(select6, con);
                //    SqlDataReader reader6 = cmd.ExecuteReader();

                cmd = new OleDbCommand(select6, con);
                OleDbDataReader reader6 = cmd.ExecuteReader();

                while (reader6.Read())
                {

                    _13Fenviroment_Value6Format[m] = (string)reader6[4];
                    _13Fenviroment_Value6Byte[m] = ((int)reader6[6]) * 2;
                    _13EnvirmentUnit6A[m] = (string)reader6[5];
                    _13EnvirmentCD6A[m] = (string)reader6[3];
                }
                con.Close();
                con.Open();
                /////////////
                string select7 = "SELECT * FROM   ECU13Envirment_format   where Envirment_ID=" + Get_13Envirment_ID(Envirment7[m]);
                //    cmd = new SqlCommand(select7, con);
                //    SqlDataReader reader7 = cmd.ExecuteReader();
                cmd = new OleDbCommand(select7, con);
                OleDbDataReader reader7 = cmd.ExecuteReader();


                while (reader7.Read())
                {

                    _13Fenviroment_Value7Format[m] = (string)reader7[4];
                    _13Fenviroment_Value7Byte[m] = ((int)reader7[6]) * 2;
                    _13EnvirmentUnit7A[m] = (string)reader7[5];
                    _13EnvirmentCD7A[m] = (string)reader7[3];
                }
                con.Close();
                con.Open();
                ///////////
                string select8 = "SELECT * FROM   ECU13Envirment_format   where Envirment_ID=" + Get_13Envirment_ID(Envirment8[m]);
                //       cmd = new SqlCommand(select8, con);
                //      SqlDataReader reader8 = cmd.ExecuteReader();
                cmd = new OleDbCommand(select8, con);
                OleDbDataReader reader8 = cmd.ExecuteReader();

                while (reader8.Read())
                {

                    _13Fenviroment_Value8Format[m] = (string)reader8[4];
                    _13Fenviroment_Value8Byte[m] = ((int)reader8[6]) * 2;
                    _13EnvirmentUnit8A[m] = (string)reader8[5];
                    _13EnvirmentCD8A[m] = (string)reader8[3];
                }
                con.Close();
                con.Open();
                ////////////////
                string select9 = "SELECT * FROM   ECU13Envirment_format   where Envirment_ID=" + Get_13Envirment_ID(Envirment9[m]);
                //     cmd = new SqlCommand(select9, con);
                //     SqlDataReader reader9 = cmd.ExecuteReader();
                cmd = new OleDbCommand(select9, con);
                OleDbDataReader reader9 = cmd.ExecuteReader();
                while (reader9.Read())
                {

                    _13Fenviroment_Value9Format[m] = (string)reader9[4];
                    _13Fenviroment_Value9Byte[m] = ((int)reader9[6]) * 2;
                    _13EnvirmentUnit9A[m] = (string)reader9[5];
                    _13EnvirmentCD9A[m] = (string)reader9[3];
                }
                con.Close();
                con.Open();
            }

            #region 环境变量的处理
            for (int i = 0; i < DTCcodeLength; i++)
            {
                if (i == DtcFalutCodeNumFlag) break;
                string[] cccc = _13dtcRead.Save13BackDTC[i].Split('\r');
                string Enviroment = cccc[1].Replace(" ", "").PadRight(200, '0');
                //截取环境数据并把它解析出来放入数组里面，
                _13Fenviroment_Value1Arry[i] = Enviroment.Substring(18, _13Fenviroment_Value1Byte[i]);
                _13Fenviroment_Value2Arry[i] = Enviroment.Substring(18 + _13Fenviroment_Value1Byte[i] + 4 * 1, _13Fenviroment_Value2Byte[i]);
                _13Fenviroment_Value3Arry[i] = Enviroment.Substring(18 + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + 4 * 2, _13Fenviroment_Value3Byte[i]);
                _13Fenviroment_Value4Arry[i] = Enviroment.Substring(18 + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + 4 * 3, _13Fenviroment_Value4Byte[i]);
                _13Fenviroment_Value5Arry[i] = Enviroment.Substring(18 + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + _13Fenviroment_Value4Byte[i] + 4 * 4, _13Fenviroment_Value5Byte[i]);
                _13Fenviroment_Value6Arry[i] = Enviroment.Substring(18 + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + _13Fenviroment_Value4Byte[i] + _13Fenviroment_Value5Byte[i] + 4 * 5, _13Fenviroment_Value6Byte[i]);
                _13Fenviroment_Value7Arry[i] = Enviroment.Substring(18 + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + _13Fenviroment_Value4Byte[i] + _13Fenviroment_Value5Byte[i] + _13Fenviroment_Value6Byte[i] + 4 * 6, _13Fenviroment_Value7Byte[i]);
                _13Fenviroment_Value8Arry[i] = Enviroment.Substring(18 + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + _13Fenviroment_Value4Byte[i] + _13Fenviroment_Value5Byte[i] + _13Fenviroment_Value6Byte[i] + 4 * 7 + _13Fenviroment_Value7Byte[i], _13Fenviroment_Value8Byte[i]);
                if (_13Fenviroment_Value9Byte[i] != 0)
                {
                    _13Fenviroment_Value9Arry[i] = Enviroment.Substring(18 + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + _13Fenviroment_Value4Byte[i] + _13Fenviroment_Value5Byte[i] + _13Fenviroment_Value6Byte[i] + 4 * 8 + _13Fenviroment_Value7Byte[i] + _13Fenviroment_Value8Byte[i], _13Fenviroment_Value9Byte[i]);

                    /////
                    int a = 18 + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + _13Fenviroment_Value4Byte[i] + _13Fenviroment_Value5Byte[i] + _13Fenviroment_Value6Byte[i] + 4 * 9 + _13Fenviroment_Value7Byte[i] + _13Fenviroment_Value8Byte[i] + _13Fenviroment_Value9Byte[i];
                    _13Renviroment_Value1Arry[i] = Enviroment.Substring(a, _13Fenviroment_Value1Byte[i]);
                    _13Renviroment_Value2Arry[i] = Enviroment.Substring(a + _13Fenviroment_Value1Byte[i] + 4 * 1, _13Fenviroment_Value2Byte[i]);
                    _13Renviroment_Value3Arry[i] = Enviroment.Substring(a + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + 4 * 2, _13Fenviroment_Value3Byte[i]);
                    _13Renviroment_Value4Arry[i] = Enviroment.Substring(a + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + 4 * 3, _13Fenviroment_Value4Byte[i]);
                    _13Renviroment_Value5Arry[i] = Enviroment.Substring(a + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + _13Fenviroment_Value4Byte[i] + 4 * 4, _13Fenviroment_Value5Byte[i]);
                    _13Renviroment_Value6Arry[i] = Enviroment.Substring(a + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + _13Fenviroment_Value4Byte[i] + _13Fenviroment_Value5Byte[i] + 4 * 5, _13Fenviroment_Value6Byte[i]);
                    _13Renviroment_Value7Arry[i] = Enviroment.Substring(a + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + _13Fenviroment_Value4Byte[i] + _13Fenviroment_Value5Byte[i] + _13Fenviroment_Value6Byte[i] + 4 * 6, _13Fenviroment_Value7Byte[i]);
                    _13Renviroment_Value8Arry[i] = Enviroment.Substring(a + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + _13Fenviroment_Value4Byte[i] + _13Fenviroment_Value5Byte[i] + _13Fenviroment_Value6Byte[i] + 4 * 7 + _13Fenviroment_Value7Byte[i], _13Fenviroment_Value8Byte[i]);
                    _13Renviroment_Value9Arry[i] = Enviroment.Substring(a + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + _13Fenviroment_Value4Byte[i] + _13Fenviroment_Value5Byte[i] + _13Fenviroment_Value6Byte[i] + 4 * 8 + _13Fenviroment_Value7Byte[i] + _13Fenviroment_Value8Byte[i], _13Fenviroment_Value9Byte[i]);

                }
                else
                {
                    int a = 18 + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + _13Fenviroment_Value4Byte[i] + _13Fenviroment_Value5Byte[i] + _13Fenviroment_Value6Byte[i] + 4 * 8 + _13Fenviroment_Value7Byte[i] + _13Fenviroment_Value8Byte[i] + _13Fenviroment_Value9Byte[i];
                    _13Renviroment_Value1Arry[i] = Enviroment.Substring(a, _13Fenviroment_Value1Byte[i]);
                    _13Renviroment_Value2Arry[i] = Enviroment.Substring(a + _13Fenviroment_Value1Byte[i] + 4 * 1, _13Fenviroment_Value2Byte[i]);
                    _13Renviroment_Value3Arry[i] = Enviroment.Substring(a + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + 4 * 2, _13Fenviroment_Value3Byte[i]);
                    _13Renviroment_Value4Arry[i] = Enviroment.Substring(a + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + 4 * 3, _13Fenviroment_Value4Byte[i]);
                    _13Renviroment_Value5Arry[i] = Enviroment.Substring(a + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + _13Fenviroment_Value4Byte[i] + 4 * 4, _13Fenviroment_Value5Byte[i]);
                    _13Renviroment_Value6Arry[i] = Enviroment.Substring(a + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + _13Fenviroment_Value4Byte[i] + _13Fenviroment_Value5Byte[i] + 4 * 5, _13Fenviroment_Value6Byte[i]);
                    _13Renviroment_Value7Arry[i] = Enviroment.Substring(a + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + _13Fenviroment_Value4Byte[i] + _13Fenviroment_Value5Byte[i] + _13Fenviroment_Value6Byte[i] + 4 * 6, _13Fenviroment_Value7Byte[i]);
                    _13Renviroment_Value8Arry[i] = Enviroment.Substring(a + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + _13Fenviroment_Value4Byte[i] + _13Fenviroment_Value5Byte[i] + _13Fenviroment_Value6Byte[i] + 4 * 7 + _13Fenviroment_Value7Byte[i], _13Fenviroment_Value8Byte[i]);
                    //  _13Renviroment_Value9Arry[i] = Enviroment.Substring(a + _13Fenviroment_Value1Byte[i] + _13Fenviroment_Value2Byte[i] + _13Fenviroment_Value3Byte[i] + _13Fenviroment_Value4Byte[i] + _13Fenviroment_Value5Byte[i] + _13Fenviroment_Value6Byte[i] + 4 * 8 + _13Fenviroment_Value7Byte[i] + _13Fenviroment_Value8Byte[i], _13Fenviroment_Value9Byte[i]);
                }
            }
            #region    这里要处理正负数
            for (int n = 0; n < _13DTCcodenum; n++)
            {
                if (n == DtcFalutCodeNumFlag) break;
                MSScriptControl.ScriptControl sc1 = new MSScriptControl.ScriptControl();
                sc1.Language = "JavaScript";
                //// /////////////////////////////////////////////////////////////////////////////// Value[i] = sc1.Eval(FinalResult[i]).ToString();  
                string Substring_ValueArry1 = _13Fenviroment_Value1Arry[n].Substring(0, 1);
                string Substring_ValueArry1_1 = _13Renviroment_Value1Arry[n].Substring(0, 1);
                char[] Str1 = Substring_ValueArry1.ToCharArray();
                char[] Str1_1 = Substring_ValueArry1_1.ToCharArray();
                if (Str1[0] < 'G' && Str1[0] > '7')
                {
                    Int32 ReturnValue = System.Math.Abs(符号位转换(_13Fenviroment_Value1Arry[n]));
                    _13Fenviroment_Value1Arry[n] = _13Fenviroment_Value1Format[n].Replace("Phy", ReturnValue.ToString());
                    _13Fenviroment_Value1Arry[n] = sc1.Eval(_13Fenviroment_Value1Arry[n]).ToString();
                    _13Fenviroment_Value1Arry[n] = "-" + _13Fenviroment_Value1Arry[n];
                }
                else
                {
                    Int32 value1 = Convert.ToInt32(_13Fenviroment_Value1Arry[n], 16);
                    _13Fenviroment_Value1Arry[n] = _13Fenviroment_Value1Format[n].Replace("Phy", value1.ToString());
                    _13Fenviroment_Value1Arry[n] = sc1.Eval(_13Fenviroment_Value1Arry[n]).ToString();
                }
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (Str1_1[0] < 'G' && Str1_1[0] > '7')
                {
                    Int32 ReturnValue = System.Math.Abs(符号位转换(_13Renviroment_Value1Arry[n]));
                    _13Renviroment_Value1Arry[n] = _13Fenviroment_Value1Format[n].Replace("Phy", ReturnValue.ToString());
                    _13Renviroment_Value1Arry[n] = sc1.Eval(_13Renviroment_Value1Arry[n]).ToString();
                    _13Fenviroment_Value1Arry[n] = "-" + _13Fenviroment_Value1Arry[n];
                }
                else
                {
                    Int32 value1_1 = Convert.ToInt32(_13Renviroment_Value1Arry[n], 16);
                    _13Renviroment_Value1Arry[n] = _13Fenviroment_Value1Format[n].Replace("Phy", value1_1.ToString());
                    _13Renviroment_Value1Arry[n] = sc1.Eval(_13Renviroment_Value1Arry[n]).ToString();
                }
                //////////////////////22222222222222222222222222222222222222222

                string Substring_ValueArry2 = _13Fenviroment_Value2Arry[n].Substring(0, 1);
                string Substring_ValueArry2_1 = _13Renviroment_Value2Arry[n].Substring(0, 1);
                char[] Str2 = Substring_ValueArry2.ToCharArray();
                char[] Str2_1 = Substring_ValueArry2_1.ToCharArray();
                if (Str2[0] < 'G' && Str2[0] > '7')
                {
                    Int32 ReturnValue = System.Math.Abs(符号位转换(_13Fenviroment_Value2Arry[n]));
                    _13Fenviroment_Value2Arry[n] = _13Fenviroment_Value2Format[n].Replace("Phy", ReturnValue.ToString());
                    _13Fenviroment_Value2Arry[n] = sc1.Eval(_13Fenviroment_Value2Arry[n]).ToString();
                    _13Fenviroment_Value2Arry[n] = "-" + _13Fenviroment_Value2Arry[n];
                }
                else
                {
                    Int32 value1 = Convert.ToInt32(_13Fenviroment_Value2Arry[n], 16);
                    _13Fenviroment_Value2Arry[n] = _13Fenviroment_Value2Format[n].Replace("Phy", value1.ToString());
                    _13Fenviroment_Value2Arry[n] = sc1.Eval(_13Fenviroment_Value2Arry[n]).ToString();
                }

                if (Str2_1[0] < 'G' && Str2_1[0] > '7')
                {
                    Int32 ReturnValue = System.Math.Abs(符号位转换(_13Renviroment_Value2Arry[n]));
                    _13Renviroment_Value2Arry[n] = _13Fenviroment_Value2Format[n].Replace("Phy", ReturnValue.ToString());
                    _13Renviroment_Value2Arry[n] = sc1.Eval(_13Renviroment_Value2Arry[n]).ToString();
                    _13Renviroment_Value2Arry[n] = "-" + _13Renviroment_Value2Arry[n];
                }
                else
                {
                    Int32 value1_1 = Convert.ToInt32(_13Renviroment_Value2Arry[n], 16);
                    _13Renviroment_Value2Arry[n] = _13Fenviroment_Value2Format[n].Replace("Phy", value1_1.ToString());
                    _13Renviroment_Value2Arry[n] = sc1.Eval(_13Renviroment_Value2Arry[n]).ToString();
                }
                /////////////////33333333333333333333333333333333
                string Substring_ValueArry3 = _13Fenviroment_Value3Arry[n].Substring(0, 1);
                string Substring_ValueArry3_1 = _13Renviroment_Value3Arry[n].Substring(0, 1);
                char[] Str3 = Substring_ValueArry3.ToCharArray();
                char[] Str3_1 = Substring_ValueArry3_1.ToCharArray();
                if (Str3[0] < 'G' && Str3[0] > '7')
                {
                    Int32 ReturnValue = System.Math.Abs(符号位转换(_13Fenviroment_Value3Arry[n]));
                    _13Fenviroment_Value3Arry[n] = _13Fenviroment_Value3Format[n].Replace("Phy", ReturnValue.ToString());
                    _13Fenviroment_Value3Arry[n] = sc1.Eval(_13Fenviroment_Value3Arry[n]).ToString();
                    _13Fenviroment_Value3Arry[n] = "-" + _13Fenviroment_Value3Arry[n];

                }
                else
                {
                    Int32 value1 = Convert.ToInt32(_13Fenviroment_Value3Arry[n], 16);
                    _13Fenviroment_Value3Arry[n] = _13Fenviroment_Value3Format[n].Replace("Phy", value1.ToString());
                    _13Fenviroment_Value3Arry[n] = sc1.Eval(_13Fenviroment_Value3Arry[n]).ToString();
                }

                if (Str3_1[0] < 'G' && Str3_1[0] > '7')
                {
                    Int32 ReturnValue = System.Math.Abs(符号位转换(_13Renviroment_Value3Arry[n]));
                    _13Renviroment_Value3Arry[n] = _13Fenviroment_Value3Format[n].Replace("Phy", ReturnValue.ToString());
                    _13Renviroment_Value3Arry[n] = sc1.Eval(_13Renviroment_Value3Arry[n]).ToString();
                    _13Renviroment_Value3Arry[n] = "-" + _13Renviroment_Value3Arry[n];
                }
                else
                {
                    Int32 value1_1 = Convert.ToInt32(_13Renviroment_Value3Arry[n], 16);
                    _13Renviroment_Value3Arry[n] = _13Fenviroment_Value3Format[n].Replace("Phy", value1_1.ToString());
                    _13Renviroment_Value3Arry[n] = sc1.Eval(_13Renviroment_Value3Arry[n]).ToString();
                }
                ///////44444444444444444444444
                string Substring_ValueArry4 = _13Fenviroment_Value4Arry[n].Substring(0, 1);
                string Substring_ValueArry4_1 = _13Renviroment_Value4Arry[n].Substring(0, 1);
                char[] Str4 = Substring_ValueArry4.ToCharArray();
                char[] Str4_1 = Substring_ValueArry4_1.ToCharArray();
                if (Str4[0] < 'G' && Str4[0] > '7')
                {
                    Int32 ReturnValue = System.Math.Abs(符号位转换(_13Fenviroment_Value4Arry[n]));
                    _13Fenviroment_Value4Arry[n] = _13Fenviroment_Value4Format[n].Replace("Phy", ReturnValue.ToString());
                    _13Fenviroment_Value4Arry[n] = sc1.Eval(_13Fenviroment_Value4Arry[n]).ToString();
                    _13Fenviroment_Value4Arry[n] = "-" + _13Fenviroment_Value4Arry[n];
                }
                else
                {
                    Int32 value1 = Convert.ToInt32(_13Fenviroment_Value4Arry[n], 16);
                    _13Fenviroment_Value4Arry[n] = _13Fenviroment_Value4Format[n].Replace("Phy", value1.ToString());
                    _13Fenviroment_Value4Arry[n] = sc1.Eval(_13Fenviroment_Value4Arry[n]).ToString();
                }

                if (Str4_1[0] < 'G' && Str4_1[0] > '7')
                {
                    Int32 ReturnValue = System.Math.Abs(符号位转换(_13Renviroment_Value4Arry[n]));
                    _13Renviroment_Value4Arry[n] = _13Fenviroment_Value4Format[n].Replace("Phy", ReturnValue.ToString());
                    _13Renviroment_Value4Arry[n] = "-" + sc1.Eval(_13Renviroment_Value4Arry[n]).ToString();
                }
                else
                {
                    Int32 value1_1 = Convert.ToInt32(_13Renviroment_Value4Arry[n], 16);
                    _13Renviroment_Value4Arry[n] = _13Fenviroment_Value4Format[n].Replace("Phy", value1_1.ToString());
                    _13Renviroment_Value4Arry[n] = sc1.Eval(_13Renviroment_Value4Arry[n]).ToString();
                }
                //////////////////////5555555555555555555555555555555
                string Substring_ValueArry5 = _13Fenviroment_Value5Arry[n].Substring(0, 1);
                string Substring_ValueArry5_1 = _13Renviroment_Value5Arry[n].Substring(0, 1);
                char[] Str5 = Substring_ValueArry5.ToCharArray();
                char[] Str5_1 = Substring_ValueArry5_1.ToCharArray();
                if (Str5[0] < 'G' && Str5[0] > '7')
                {
                    Int32 ReturnValue = System.Math.Abs(符号位转换(_13Fenviroment_Value5Arry[n]));
                    _13Fenviroment_Value5Arry[n] = _13Fenviroment_Value5Format[n].Replace("Phy", ReturnValue.ToString());
                    _13Fenviroment_Value5Arry[n] = "-" + sc1.Eval(_13Fenviroment_Value5Arry[n]).ToString();
                }
                else
                {
                    Int32 value1 = Convert.ToInt32(_13Fenviroment_Value5Arry[n], 16);
                    _13Fenviroment_Value5Arry[n] = _13Fenviroment_Value5Format[n].Replace("Phy", value1.ToString());
                    _13Fenviroment_Value5Arry[n] = sc1.Eval(_13Fenviroment_Value5Arry[n]).ToString();
                }

                if (Str5_1[0] < 'G' && Str5_1[0] > '7')
                {
                    Int32 ReturnValue = System.Math.Abs(符号位转换(_13Renviroment_Value5Arry[n]));
                    _13Renviroment_Value5Arry[n] = _13Fenviroment_Value5Format[n].Replace("Phy", ReturnValue.ToString());
                    _13Renviroment_Value5Arry[n] = "-" + sc1.Eval(_13Renviroment_Value5Arry[n]).ToString();
                }
                else
                {
                    Int32 value1_1 = Convert.ToInt32(_13Renviroment_Value5Arry[n], 16);
                    _13Renviroment_Value5Arry[n] = _13Fenviroment_Value5Format[n].Replace("Phy", value1_1.ToString());
                    _13Renviroment_Value5Arry[n] = sc1.Eval(_13Renviroment_Value5Arry[n]).ToString();
                }
                ///////////////////////////////////666666666666666
                string Substring_ValueArry6 = _13Fenviroment_Value6Arry[n].Substring(0, 1);
                string Substring_ValueArry6_1 = _13Renviroment_Value6Arry[n].Substring(0, 1);
                char[] Str6 = Substring_ValueArry6.ToCharArray();
                char[] Str6_1 = Substring_ValueArry6_1.ToCharArray();
                if (Str6[0] < 'G' && Str6[0] > '7')
                {
                    Int32 ReturnValue = System.Math.Abs(符号位转换(_13Fenviroment_Value6Arry[n]));
                    _13Fenviroment_Value6Arry[n] = _13Fenviroment_Value6Format[n].Replace("Phy", ReturnValue.ToString());
                    _13Fenviroment_Value6Arry[n] = "-" + sc1.Eval(_13Fenviroment_Value6Arry[n]).ToString();
                }
                else
                {
                    Int32 value1 = Convert.ToInt32(_13Fenviroment_Value6Arry[n], 16);
                    _13Fenviroment_Value6Arry[n] = _13Fenviroment_Value6Format[n].Replace("Phy", value1.ToString());
                    _13Fenviroment_Value6Arry[n] = sc1.Eval(_13Fenviroment_Value6Arry[n]).ToString();
                }

                if (Str6_1[0] < 'G' && Str6_1[0] > '7')
                {
                    Int32 ReturnValue = System.Math.Abs(符号位转换(_13Renviroment_Value6Arry[n]));
                    _13Renviroment_Value6Arry[n] = _13Fenviroment_Value6Format[n].Replace("Phy", ReturnValue.ToString());
                    _13Renviroment_Value6Arry[n] = "-" + sc1.Eval(_13Renviroment_Value6Arry[n]).ToString();
                }
                else
                {
                    Int32 value1_1 = Convert.ToInt32(_13Renviroment_Value6Arry[n], 16);
                    _13Renviroment_Value6Arry[n] = _13Fenviroment_Value6Format[n].Replace("Phy", value1_1.ToString());
                    _13Renviroment_Value6Arry[n] = sc1.Eval(_13Renviroment_Value6Arry[n]).ToString();
                }
                //////////////77777777777777777777777777777777777
                string Substring_ValueArry7 = _13Fenviroment_Value7Arry[n].Substring(0, 1);
                string Substring_ValueArry7_1 = _13Renviroment_Value7Arry[n].Substring(0, 1);
                char[] Str7 = Substring_ValueArry7.ToCharArray();
                char[] Str7_1 = Substring_ValueArry7_1.ToCharArray();
                if (Str7[0] < 'G' && Str7[0] > '7')
                {
                    Int32 ReturnValue = System.Math.Abs(符号位转换(_13Fenviroment_Value7Arry[n]));
                    _13Fenviroment_Value7Arry[n] = _13Fenviroment_Value7Format[n].Replace("Phy", ReturnValue.ToString());
                    _13Fenviroment_Value7Arry[n] = "-" + sc1.Eval(_13Fenviroment_Value7Arry[n]).ToString();
                }
                else
                {
                    Int32 value1 = Convert.ToInt32(_13Fenviroment_Value7Arry[n], 16);
                    _13Fenviroment_Value7Arry[n] = _13Fenviroment_Value7Format[n].Replace("Phy", value1.ToString());
                    _13Fenviroment_Value7Arry[n] = sc1.Eval(_13Fenviroment_Value7Arry[n]).ToString();
                }

                if (Str7_1[0] < 'G' && Str7_1[0] > '7')
                {
                    Int32 ReturnValue = System.Math.Abs(符号位转换(_13Renviroment_Value7Arry[n]));
                    _13Renviroment_Value7Arry[n] = _13Fenviroment_Value7Format[n].Replace("Phy", ReturnValue.ToString());
                    _13Renviroment_Value7Arry[n] = "-" + sc1.Eval(_13Renviroment_Value7Arry[n]).ToString();
                }
                else
                {
                    Int32 value1_1 = Convert.ToInt32(_13Renviroment_Value7Arry[n], 16);
                    _13Renviroment_Value7Arry[n] = _13Fenviroment_Value7Format[n].Replace("Phy", value1_1.ToString());
                    _13Renviroment_Value7Arry[n] = sc1.Eval(_13Renviroment_Value7Arry[n]).ToString();
                }
                /////////////////888888888888888
                string Substring_ValueArry8 = _13Fenviroment_Value8Arry[n].Substring(0, 1);
                string Substring_ValueArry8_1 = _13Renviroment_Value8Arry[n].Substring(0, 1);
                char[] Str8 = Substring_ValueArry8.ToCharArray();
                char[] Str8_1 = Substring_ValueArry8_1.ToCharArray();
                if (Str8[0] < 'G' && Str8[0] > '7')
                {
                    Int32 ReturnValue = System.Math.Abs(符号位转换(_13Fenviroment_Value8Arry[n]));
                    _13Fenviroment_Value8Arry[n] = _13Fenviroment_Value8Format[n].Replace("Phy", ReturnValue.ToString());
                    _13Fenviroment_Value8Arry[n] = "-" + sc1.Eval(_13Fenviroment_Value8Arry[n]).ToString();
                }
                else
                {
                    Int32 value1 = Convert.ToInt32(_13Fenviroment_Value8Arry[n], 16);
                    _13Fenviroment_Value8Arry[n] = _13Fenviroment_Value8Format[n].Replace("Phy", value1.ToString());
                    _13Fenviroment_Value8Arry[n] = sc1.Eval(_13Fenviroment_Value8Arry[n]).ToString();
                }

                if (Str8_1[0] < 'G' && Str8_1[0] > '7')
                {
                    Int32 ReturnValue = System.Math.Abs(符号位转换(_13Renviroment_Value8Arry[n]));
                    _13Renviroment_Value8Arry[n] = _13Fenviroment_Value8Format[n].Replace("Phy", ReturnValue.ToString());
                    _13Renviroment_Value8Arry[n] = "-" + sc1.Eval(_13Renviroment_Value8Arry[n]).ToString();
                }
                else
                {
                    Int32 value1_1 = Convert.ToInt32(_13Renviroment_Value8Arry[n], 16);
                    _13Renviroment_Value8Arry[n] = _13Fenviroment_Value8Format[n].Replace("Phy", value1_1.ToString());
                    _13Renviroment_Value8Arry[n] = sc1.Eval(_13Renviroment_Value8Arry[n]).ToString();
                }
                ////////////////99999999999999999999999999999999
                if (_13Fenviroment_Value9Byte[n] != 0)
                {
                    string Substring_ValueArry9 = _13Fenviroment_Value9Arry[n].Substring(0, 1);
                    string Substring_ValueArry9_1 = _13Renviroment_Value9Arry[n].Substring(0, 1);
                    char[] Str9 = Substring_ValueArry9.ToCharArray();
                    char[] Str9_1 = Substring_ValueArry9_1.ToCharArray();
                    if (Str9[0] < 'G' && Str9[0] > '7')
                    {
                        Int32 ReturnValue = System.Math.Abs(符号位转换(_13Fenviroment_Value9Arry[n]));
                        _13Fenviroment_Value9Arry[n] = _13Fenviroment_Value9Format[n].Replace("Phy", ReturnValue.ToString());
                        _13Fenviroment_Value9Arry[n] = "-" + sc1.Eval(_13Fenviroment_Value9Arry[n]).ToString();
                    }
                    else
                    {
                        Int32 value1 = Convert.ToInt32(_13Fenviroment_Value9Arry[n], 16);
                        _13Fenviroment_Value9Arry[n] = _13Fenviroment_Value9Format[n].Replace("Phy", value1.ToString());
                        _13Fenviroment_Value9Arry[n] = sc1.Eval(_13Fenviroment_Value9Arry[n]).ToString();
                    }

                    if (Str9_1[0] < 'G' && Str9_1[0] > '7')
                    {
                        Int32 ReturnValue = System.Math.Abs(符号位转换(_13Renviroment_Value9Arry[n]));
                        _13Renviroment_Value9Arry[n] = _13Fenviroment_Value9Format[n].Replace("Phy", ReturnValue.ToString());
                        _13Renviroment_Value9Arry[n] = "-" + sc1.Eval(_13Renviroment_Value9Arry[n]).ToString();
                    }
                    else
                    {
                        Int32 value1_1 = Convert.ToInt32(_13Renviroment_Value9Arry[n], 16);
                        _13Renviroment_Value9Arry[n] = _13Fenviroment_Value9Format[n].Replace("Phy", value1_1.ToString());
                        _13Renviroment_Value9Arry[n] = sc1.Eval(_13Renviroment_Value9Arry[n]).ToString();
                    }
                }
                //FinalResult[i] = patent[i].Replace("x", res.ToString());
            #endregion
            }
            #endregion
            #endregion

        }

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

        private Int32 符号位转换(string inputString)
        {
            string Astring = inputString;
            Int32 res = Int32.Parse(Astring, System.Globalization.NumberStyles.AllowHexSpecifier);
            return res;
        }

        private void SHOWECU13CODE()
        {
            MyMeans.DropDTC();   //清除原先数据
            MyMeans.AccessLink();
            for (int i = 0; i < _13DTCcodenum; i++)
            {
                if (i == DtcFalutCodeNumFlag) break;
                _dfcname = DFCNAME[i];
                //    string s_13backcode = _13BackTDCnumcode[i].Substring(0,3).PadLeft(4,'0') ; 
                s_13BackTDCnumcode = _13BackTDCnumcode[i].Substring(0, 3).PadLeft(4, '0') + "H";

                _pcode = PCODE[i];
                _spn = SPN[i];
                _fmi = FM1[i];
                _dtcb = DTCB[i];
                _mil = MIL[i];
                _svs = SVS[i];
                _envirment1 = Envirment1[i];
                _envirment2 = Envirment2[i];
                _envirment3 = Envirment3[i];
                _envirment4 = Envirment4[i];
                _envirment5 = Envirment5[i];
                _envirment6 = Envirment6[i];
                _envirment7 = Envirment7[i];
                _envirment8 = Envirment8[i];
                _envirment9 = Envirment9[i];

                _13DTCID = i + 1;

                _13s_Frequency_counter = _13Frequency_counter[i].ToString();
                _13S_Descrition_Chinese = _13Descrition_Chinese[i];
                _13S_Descrition_English = _13Descrition_English[i];
                if (_13Active[i] == "11")
                {
                    _13Sactive = "Active";
                }
                else
                {
                    _13Sactive = "NOT_acive";

                }

                if (_13TEST[i] == 1)
                {
                    _13Tested = "Tested";
                }
                else
                {
                    _13Tested = "Not_tested";

                }

                if (_13Debounce_completed[i] == 1)
                {

                    _13s_Debounce_completed = "YES";

                }
                else
                {

                    _13s_Debounce_completed = "NO";


                }
                //
                if (this.MIL[i].StartsWith("ON"))
                {

                    this._13S_MIL_lamp_is_blinking = "YES";
                    this._13S_Visible_to_OBD_tool = "YES";

                }
                else
                {
                    this._13S_MIL_lamp_is_blinking = "NO";
                    this._13S_Visible_to_OBD_tool = "NO";
                }
                _13VALUES[i] = _13dtcRead.Save13BackDTC[i];
                _13sValue = _13VALUES[i];
                ///
                /// ECU 的环境变量。。。。
                /// 1
                _13Fenviroment_Value1 = _13Fenviroment_Value1Arry[i];
                _13Renviroment_Value1 = _13Renviroment_Value1Arry[i];
                _13EnvirmentUnit1 = _13EnvirmentUnit1A[i];
                _13EnvirmentCD1 = _13EnvirmentCD1A[i];

                //2
                _13Fenviroment_Value2 = _13Fenviroment_Value2Arry[i];
                _13Renviroment_Value2 = _13Renviroment_Value2Arry[i];
                _13EnvirmentUnit2 = _13EnvirmentUnit2A[i];
                _13EnvirmentCD2 = _13EnvirmentCD2A[i];
                //3

                _13Fenviroment_Value3 = _13Fenviroment_Value3Arry[i];
                _13Renviroment_Value3 = _13Renviroment_Value3Arry[i];
                _13EnvirmentUnit3 = _13EnvirmentUnit3A[i];
                _13EnvirmentCD3 = _13EnvirmentCD3A[i];
                //4

                _13Fenviroment_Value4 = _13Fenviroment_Value4Arry[i];
                _13Renviroment_Value4 = _13Renviroment_Value4Arry[i];
                _13EnvirmentUnit4 = _13EnvirmentUnit4A[i];
                _13EnvirmentCD4 = _13EnvirmentCD4A[i];

                //5
                _13Fenviroment_Value5 = _13Fenviroment_Value5Arry[i];
                _13Renviroment_Value5 = _13Renviroment_Value5Arry[i];
                _13EnvirmentUnit5 = _13EnvirmentUnit5A[i];
                _13EnvirmentCD5 = _13EnvirmentCD5A[i];
                //6
                _13Fenviroment_Value6 = _13Fenviroment_Value6Arry[i];
                _13Renviroment_Value6 = _13Renviroment_Value6Arry[i];
                _13EnvirmentUnit6 = _13EnvirmentUnit6A[i];
                _13EnvirmentCD6 = _13EnvirmentCD6A[i];
                //7
                _13Fenviroment_Value7 = _13Fenviroment_Value7Arry[i];
                _13Renviroment_Value7 = _13Renviroment_Value7Arry[i];
                _13EnvirmentUnit7 = _13EnvirmentUnit7A[i];
                _13EnvirmentCD7 = _13EnvirmentCD7A[i];
                //8
                _13Fenviroment_Value8 = _13Fenviroment_Value8Arry[i];
                _13Renviroment_Value8 = _13Renviroment_Value8Arry[i];
                _13EnvirmentUnit8 = _13EnvirmentUnit8A[i];
                _13EnvirmentCD8 = _13EnvirmentCD8A[i];
                //9
                _13Fenviroment_Value9 = _13Fenviroment_Value9Arry[i];
                _13Renviroment_Value9 = _13Renviroment_Value9Arry[i];
                _13EnvirmentUnit9 = _13EnvirmentUnit9A[i];
                _13EnvirmentCD9 = _13EnvirmentCD9A[i];
                InsertDtccode13();
            }
            MyMeans.AccessBreak();
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

        #endregion

    }

}
