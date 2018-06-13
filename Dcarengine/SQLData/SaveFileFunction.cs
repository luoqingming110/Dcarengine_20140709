using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace Dcarengine.SQLData
{
    class SaveFileFunction
    {
        static AccessDbClass accessdb;

        public static void Tp_SaveExcel()
        {

            string sql = "select * from Trip";
            accessdb = new AccessDbClass(MyMeans.strConn1);
            DataTable a = accessdb.SelectToDataTable(sql);
            DataTable dt = a;
            string outError = "";
            DateTime dtime = DateTime.Now;
            string fileName = Application.StartupPath + "\\EDC17 TripRecorder\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + " tp.xls";
            AsposeExcelTools.Tp_DataTableToExcel(dt, fileName, out outError);
            if (!string.IsNullOrEmpty(outError))
            {
                MessageBox.Show(outError);
            }
            else
            {
                Process.Start(fileName);
            }
        }

        public static void C9Tp_SaveExcel()
        {
            string sql = "select * from Trip";
            accessdb = new AccessDbClass(MyMeans.strConn1);
            DataTable a = accessdb.SelectToDataTable(sql);
            DataTable dt = a;
            string outError = "";
            DateTime dtime = DateTime.Now;
            string fileName = Application.StartupPath + "\\EDC7 TripRecorder\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + " tp.xls";
            AsposeExcelTools.Tp_DataTableToExcel(dt, fileName, out outError);
            if (!string.IsNullOrEmpty(outError))
            {
                MessageBox.Show(outError);
            }
            else
            {
                Process.Start(fileName);
            }
        }

        public static void C9id_SaveExcel()
        {

            string sql = "select * from ECD_ID";
            accessdb = new AccessDbClass(MyMeans.strConn1);
            DataTable a = accessdb.SelectToDataTable(sql);
            DataTable dt = a;
            string outError = "";
            DateTime dtime = DateTime.Now;
            //
            string fileName = Application.StartupPath + "\\EDC7 ECU ID\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + "id.xls";
            //  string fileName = Application.StartupPath + "\\EDC17 ECU ID\\" +dtime.GetDateTimeFormats('s')[0].ToString() +"id.xls";
            AsposeExcelTools.Ecu_Id_DataTableToExcel(dt, fileName, out outError);
            if (!string.IsNullOrEmpty(outError))
            {
                MessageBox.Show(outError);
            }
            else
            {
                Process.Start(fileName);
            }
        }


        public static void id_SaveExcel()
        {

            string sql = "select * from ECD_ID";
            accessdb = new AccessDbClass(MyMeans.strConn1);
            DataTable a = accessdb.SelectToDataTable(sql);
            DataTable dt = a;
            string outError = "";
            DateTime dtime = DateTime.Now;
            //
            string fileName = Application.StartupPath + "\\EDC17 ECU ID\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + "id.xls";
            //  string fileName = Application.StartupPath + "\\EDC17 ECU ID\\" +dtime.GetDateTimeFormats('s')[0].ToString() +"id.xls";
            AsposeExcelTools.Ecu_Id_DataTableToExcel(dt, fileName, out outError);
            if (!string.IsNullOrEmpty(outError))
            {
                MessageBox.Show(outError);
            }
            else
            {
                Process.Start(fileName);
            }
        }

        public static void Dtc_SaveExcel()
        {

            string sql = "select * from dtc";
            accessdb = new AccessDbClass(MyMeans.strConn1);
            DataTable a = accessdb.SelectToDataTable(sql);
            DataTable dt = a;
            string outError = "";
            DateTime dtime = DateTime.Now;
            string fileName = Application.StartupPath + "\\EDC17 DTC\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + "dtc.xls";
            AsposeExcelTools.Dtc_DataTableToExcel(dt, fileName, out outError);
            if (!string.IsNullOrEmpty(outError))
            {
                MessageBox.Show(outError);
            }
            else
            {
                Process.Start(fileName);
            }
        }

        public static void C9Dtc_SaveExcel()
        {

            string sql = "select * from dtc";
            accessdb = new AccessDbClass(MyMeans.strConn1);
            DataTable a = accessdb.SelectToDataTable(sql);
            DataTable dt = a;
            string outError = "";
            DateTime dtime = DateTime.Now;
            string fileName = Application.StartupPath + "\\EDC7 DTC\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + "dtc.xls";
            AsposeExcelTools.Dtc_DataTableToExcel(dt, fileName, out outError);
            if (!string.IsNullOrEmpty(outError))
            {
                MessageBox.Show(outError);
            }
            else
            {
                Process.Start(fileName);
            }

        }

    }
}
