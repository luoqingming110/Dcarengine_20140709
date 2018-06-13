using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Data;

namespace Dcarengine.SQLData
{
    class MyMeans
    {

        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string Logion_Name;
        #region 数据库处理模块
        //此外，在DTccs中有两处，测量中有一处，
        #region  DTC数据库//User Id = admin;DataBase Password = cqupt2013;
        //public static string strConn = string.Format(@" Provider = Microsoft.Jet.OLEDB.4.0 ;Data Source =" + "d:/CarDBAccess.mdb  ");
        //public static string strConn1 = string.Format(@" Provider = Microsoft.Jet.OLEDB.4.0 ;Data Source ={0}\\CarDBAccess.mdb ",
        //      System.Windows.Forms.Application.StartupPath       );

        public static string strConn1 = string.Format(@" Provider = Microsoft.Jet.OLEDB.4.0 ;Data Source ={0}\CarDBAccess.mdb ;User Id = admin;Jet OLEDB:DataBase Password=RONGBOBESTRONG!@#",
          Directory.GetCurrentDirectory());                                        //带有文件目录的连接

        //public static string strConn1 = string.Format(@" Provider = Microsoft.Jet.OLEDB.4.0 ;Data Source ={0}\AcessData\CarDBAccess.mdb ;User Id = admin;Jet OLEDB:DataBase Password=201399",
        // Directory.GetCurrentDirectory());                                        //带有文件目录的连接

        public static OleDbConnection Conn = new OleDbConnection(strConn1);

        public static void AccessLink()
        {
            Conn.Open();
        }
        public static void AccessBreak()
        {
            Conn.Close();
        }


        #region ID数据库
        public static void InsertAccess(string ID, string Description, string TBytes, string Data, string Value)
        {
            try
            {
                MyMeans.AccessLink();
                string strInsert = " INSERT INTO [ECD_ID] ([ID],[描述],[类型长度],[数据],[ASCII值]) VALUES ( '" + ID + "','" + Description + "','" + TBytes + "','" + Data + "','" + Value + "')";
                OleDbCommand inst = new OleDbCommand(strInsert, Conn);
                inst.ExecuteNonQuery();
                MyMeans.AccessBreak();
            }
            catch
            {
                log.Info("ID数据储存出错！");
                MyMeans.AccessBreak();
            }
        }
        public static void DropAccess()
        {
            try
            {
                MyMeans.AccessLink();
                string strInsert = " delete * from ECD_ID ";
                OleDbCommand inst = new OleDbCommand(strInsert, Conn);
                inst.ExecuteNonQuery();
                MyMeans.AccessBreak();
            }
            catch
            {
                log.Info("ID数据清除出错！");
                MyMeans.AccessBreak();
            }
        }
        #endregion

        public static void InsertDTC(string Name1, string Name2, string Name3, string Name4, string Name5, string Name6)
        {
            try
            {
                string strInsert = " INSERT INTO [DTC] ([Name1],[Name2],[Name3],[Name4],[Name5],[Name6]) VALUES ('"
                    + Name1 + "','" + Name2 + "','" + Name3 + "','" + Name4 + "','" + Name5 + "','" + Name6 + "')";
                OleDbCommand inst = new OleDbCommand(strInsert, Conn);
                inst.ExecuteNonQuery();
            }
            catch
            {
                log.Info("DTC数据库储存出错！");
                MyMeans.AccessBreak();
            }
        }
        public static void DropDTC()
        {
            try
            {
                MyMeans.AccessLink();
                string strInsert = " delete * from DTC ";
                OleDbCommand inst = new OleDbCommand(strInsert, Conn);
                inst.ExecuteNonQuery();
                strInsert = " ALTER TABLE  DTC ALTER COLUMN ID COUNTER (1,1)";
                inst = new OleDbCommand(strInsert, Conn);
                inst.ExecuteNonQuery();
                MyMeans.AccessBreak();
            }
            catch
            {
                log.Info("DTC数据库清除出错！");
                MyMeans.AccessBreak();
            }
        }

        #endregion

        #region 行程参数数据库
        public static void InsertTrip(string Name1, string Name2, string Name3, string Name4, string Name5,
            string Name6, string Name7, string Name8, string Name9, string Name10)
        {
            try
            {
                MyMeans.AccessLink();
                string strInsert = " INSERT INTO [Trip] ([Name1],[Name2],[Name3],[Name4],[Name5],[Name6],[Name7],[Name8],[Name9],[Name10]) VALUES ( '"
                    + Name1 + "','" + Name2 + "','" + Name3 + "','" + Name4 + "','" + Name5 + "','" + Name6 + "','" + Name7 + "','" + Name8
                    + "','" + Name9 + "','" + Name10 + "')";
                OleDbCommand inst = new OleDbCommand(strInsert, Conn);
                inst.ExecuteNonQuery();
                MyMeans.AccessBreak();
            }
            catch
            {
                log.Info("行程记录数据库储存出错！");
                MyMeans.AccessBreak();
            }
        }
        public static void DropTrip()
        {
            try
            {
                MyMeans.AccessLink();
                string strInsert = " delete * from Trip ";
                OleDbCommand inst = new OleDbCommand(strInsert, Conn);
                inst.ExecuteNonQuery();
                MyMeans.AccessBreak();
            }
            catch
            {
                log.Info("行程记录清除出错！");
                MyMeans.AccessBreak();
            }
        }


        /// <summary>
        /// 返回DataSet 数据
        /// </summary>
        /// <returns></returns>
        public  static DataSet   GetEcuTrip(String  EcuVersion) {

            DataSet ds = new DataSet();
            try
            {
                MyMeans.AccessLink();
                String select = "SELECT * FROM  ECU13Tp  where EcuVersion='" + EcuVersion + "'";
                OleDbDataAdapter da = new OleDbDataAdapter(select, Conn);
                da.Fill(ds, "Table1_1");
                MyMeans.AccessBreak();
            }
            catch (Exception e) {

                log.Info("read ecu tp  by version is error" + e.Message);
                MyMeans.AccessBreak();
            }
            return ds;
        }
       


        #endregion

        #endregion





    }
}
