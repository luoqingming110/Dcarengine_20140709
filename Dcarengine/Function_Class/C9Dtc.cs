using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Dcarengine.SQLData;
using Dcarengine.UIForm;


namespace Dcarengine.Function_Class
{
    class C9Dtc
    {
        #region    parammer
        OleDbConnection con;
        OleDbCommand cmd;
        string C9BackTDCnumcode;    //故障代号
        string C9dtcname;                  //故障名称  这个值需要查询数据库
        string C9S_Descrition_English, C9S_Descrition_Chinese;
        string _C9Sactive, _C9Tested;
        int _9DTCID;
        int _C9s_Frequency_counter;
        string Debounce_completed;      //完成响应
        string Visible_to_OBD_tool;       //OBD 是否可现
        string MIL_lamp_on;
        string MIL_lamp_is_blinking;
        string System_lamp;
        string C9_Value;
        string FirstStatuValue;
        string CurrentStatuValue;
        string AllsStatuValue;
        int Time_since_first_appearance;
        int Active_Time;

        #endregion
        public void ConnectAccessF(int DtcNum, string c9DctnumCode)       //传入参数  
        {
            C9BackTDCnumcode = c9DctnumCode;
            int C9dtc = Convert.ToInt32(C9BackTDCnumcode, 16);
            _9DTCID = DtcNum + 1;
            try
            {
                SQLData.AccessDbClass mybd = new AccessDbClass(MyMeans.strConn1);
                con = new OleDbConnection(MyMeans.strConn1);
                con.Open();
                string select = "SELECT * FROM   ECU9DTC   where  DTCMNUM=  " + C9dtc;
                cmd = new OleDbCommand(select, con);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    C9dtcname = (string)reader[18];
                    C9S_Descrition_English = (string)reader[2];
                    C9S_Descrition_Chinese = (string)reader[3];
                }
                con.Close();
            }
            catch
            {
            }
            C9WorkFuc();
           
        }
        private void C9WorkFuc()
        {
            //string C9CodeDtc = MainF.SaveC9BackDtcData.Replace(" ", ""); ;
            //string[] SubStringCodeDtc = C9CodeDtc.Split('\r');
            //C9_Value = SubStringCodeDtc[1];
            ////状态位。。。。。。。。。。。。。。。。。。。。。
            //string statu = SubStringCodeDtc[1].Substring(4, 2);
            //string tpye1 = SubStringCodeDtc[1].Substring(6, 2);
            //string tpye2 = SubStringCodeDtc[1].Substring(8, 2);
            //string Frequency_counter = SubStringCodeDtc[1].Substring(10, 2);
            //_C9s_Frequency_counter = Convert.ToInt32(Frequency_counter, 16);     //发生的次数
            //string since_first_appearanceL = SubStringCodeDtc[1].Substring(14, 2);     //
            //string since_first_appearanceH = SubStringCodeDtc[1].Substring(16, 2);
            //Time_since_first_appearance = Convert.ToInt32(since_first_appearanceH + since_first_appearanceL, 16);
            //Time_since_first_appearance = Time_since_first_appearance / 60 + Time_since_first_appearance % 60;
            //string ActiveTimeL = SubStringCodeDtc[1].Substring(36, 2);
            //string ActiveTimeH = SubStringCodeDtc[1].Substring(38, 2);
            //Active_Time = Convert.ToInt32(ActiveTimeH + ActiveTimeL, 16);
            //Active_Time = Active_Time / 60 + Active_Time % 60;
            //int statuTO10jinz = Convert.ToInt32(statu, 16);
            //string statuTo2jinz = Convert.ToString(statuTO10jinz, 2).PadLeft(8, '0');
            //int tpye1To10jinz = Convert.ToInt32(tpye1, 16);
            //string type1To2jinz = Convert.ToString(tpye1To10jinz, 2).PadLeft(8, '0');
            //string All_string = type1To2jinz.Substring(4, 4);                          //4位数值  需要翻转字符串
            //string Currency = type1To2jinz.Substring(0, 4);                          //4位数值   需要翻转字符串
            //int all_string = 0, currency = 0, first = 0;
            //int tpye2To10jinz = Convert.ToInt32(tpye2, 16);
            //string type2To2jinz = Convert.ToString(tpye2To10jinz, 2).PadLeft(8, '0');
            //string First_String = type1To2jinz.Substring(2, 4);                        //4位数据 需要翻转字符
            //#region
            //string bits0 = statuTo2jinz.Substring(7, 1);
            //string bits1 = statuTo2jinz.Substring(6, 1);
            //string bits2 = statuTo2jinz.Substring(5, 1);
            //string bits3 = statuTo2jinz.Substring(4, 1);
            //string bits4 = statuTo2jinz.Substring(3, 1);
            //string bits6 = statuTo2jinz.Substring(1, 1);
            //if (bits0.Contains("1"))
            //{
            //    _C9Sactive = "Active";
            //    _C9Tested = "Tested";
            //}
            //else
            //{
            //    _C9Sactive = "Not_Active";
            //    _C9Tested = "Not_Tested";
            //}
            //if (bits1.Contains("1"))
            //{
            //    Debounce_completed = "YES";
            //}
            //else
            //{
            //    Debounce_completed = "NO";
            //}
            //if (bits2.Contains("1"))
            //{
            //    Visible_to_OBD_tool = "YES";
            //}
            //else
            //{
            //    Visible_to_OBD_tool = "NO";
            //}
            //if (bits3.Contains("1"))
            //{
            //    MIL_lamp_on = "YES";
            //}
            //else
            //{
            //    MIL_lamp_on = "NO";
            //}
            //if (bits4.Contains("1"))
            //{
            //    MIL_lamp_is_blinking = "YES";
            //}
            //else
            //{
            //    MIL_lamp_is_blinking = "NO";
            //}
            //if (bits6.Contains("1"))
            //{
            //    System_lamp = "YES";
            //}
            //else
            //{
            //    System_lamp = "NO";
            //}
            ////TYPE1  。TYPE2解析。。。

            //char[] allchar = ReverseString(All_string).ToCharArray();
            //char[] currencyChar = ReverseString(Currency).ToCharArray();
            //char[] FirstChar = ReverseString(First_String).ToCharArray();
            //for (int i = 0; i < allchar.Length; i++)
            //{
            //    if (allchar[i] == '1')
            //    {
            //        all_string = i;
            //        break;
            //    }
            //}
            //for (int i = 0; i < currencyChar.Length; i++)
            //{
            //    if (currencyChar[i] == '1')
            //    {
            //        currency = i;
            //        break;
            //    }
            //}
            //for (int i = 0; i < FirstChar.Length; i++)
            //{
            //    if (FirstChar[i] == '1')
            //    {
            //        first = i;
            //        break;
            //    }
            //}
            //if (all_string == 0)
            //{
            //    AllsStatuValue = "Bit0(max);Sign too high";
            //}
            //else if (all_string == 1)
            //{
            //    AllsStatuValue = "Bit1(min);Sign too low";
            //}
            //else if (all_string == 2)
            //{
            //    AllsStatuValue = "Bit2(Sig);Open Load";
            //}
            //else if (all_string == 3)
            //{
            //    AllsStatuValue = "Bit3(imp);Impossible";
            //}
            ///////////////////////////////////////////////////////
            //if (currency == 0)
            //{
            //    CurrentStatuValue = "Bit0(max);Sign too high";
            //}
            //else if (currency == 1)
            //{
            //    CurrentStatuValue = "Bit1(min);Sign too low";
            //}
            //else if (currency == 2)
            //{
            //    CurrentStatuValue = "Bit2(Sig);Open Load";
            //}
            //else if (currency == 3)
            //{
            //    CurrentStatuValue = "Bit3(imp);Impossible";
            //}
            /////////////////////////////////////////////////////////////
            //if (first == 0)
            //{
            //    FirstStatuValue = "Bit0(max);Sign too high";
            //}
            //else if (first == 1)
            //{
            //    FirstStatuValue = "Bit1(min);Sign too low";
            //}
            //else if (first == 2)
            //{
            //    FirstStatuValue = "Bit2(Sig);Open Load";
            //}
            //else if (first == 3)
            //{
            //    FirstStatuValue = "Bit3(imp);Impossible";
            //}

            //#endregion

            //InsertDtccode9();

        }

        public string ReverseString(string s)
        {
            char[] chars = s.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        public void InsertDtccode9()
        {
            MyMeans.AccessLink();
            #region 插入DTC数据库
            string title = "#" + _9DTCID + "  " + C9dtcname + "     " + C9BackTDCnumcode + "    " + _C9Sactive + "\\" + _C9Tested;
            MyMeans.InsertDTC(title, C9S_Descrition_English, "", "", "", C9S_Descrition_Chinese);
            MyMeans.InsertDTC("", "Symptom", "", "", "", "");
            MyMeans.InsertDTC("", "First", FirstStatuValue, "", "", "");
            MyMeans.InsertDTC("", "Current", CurrentStatuValue, "", "", "");
            MyMeans.InsertDTC("", "All", AllsStatuValue, "", "", "");
            MyMeans.InsertDTC("", "Frequency counter", "", _C9s_Frequency_counter.ToString(), "", "发生频率");
            MyMeans.InsertDTC("", "Error delete counter", "", "40", "", "完成测试数 (DLC)");
            MyMeans.InsertDTC("", "Status", "", "", "", "");
            MyMeans.InsertDTC("", "", "Debounce completed", Debounce_completed, "", "");
            MyMeans.InsertDTC("", "", "Visible to OBD tool", Visible_to_OBD_tool, "", "");
            MyMeans.InsertDTC("", "", "MIL lamp on", MIL_lamp_on, "", "");
            MyMeans.InsertDTC("", "", "MIL lamp is blinking", MIL_lamp_is_blinking, "", "");
            MyMeans.InsertDTC("", "", "System lamp on", System_lamp, "", "");
            MyMeans.InsertDTC("", "Time since first appearance ", "", Time_since_first_appearance.ToString(), "", "");
            MyMeans.InsertDTC("", "Active time", "", Active_Time.ToString(), "", "");
            MyMeans.InsertDTC("", "Raw values:", C9_Value, "", "", "");
            #endregion
            MyMeans.AccessBreak();
        }
    
    
    }
}
