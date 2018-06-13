using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Aspose.Cells;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Dcarengine.SQLData;
using System.Diagnostics;

namespace Dcarengine
{

    public class AsposeExcelTools
    {
        AccessDbClass accessdb;

        public static bool DataTableToExcel(DataTable datatable, string filepath, out string error)
        {
            error = "";
            try
            {
                if (datatable == null)
                {
                    error = "DataTableToExcel:datatable 为空";
                    return false;
                }

                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
                Aspose.Cells.Worksheet sheet = workbook.Worksheets[0];
                Aspose.Cells.Cells cells = sheet.Cells;

                int nRow = 0;
                foreach (DataRow row in datatable.Rows)
                {
                    nRow++;
                    try
                    {
                        for (int i = 0; i < datatable.Columns.Count; i++)
                        {
                            if (row[i].GetType().ToString() == "System.Drawing.Bitmap")
                            {
                                //------插入图片数据-------
                                System.Drawing.Image image = (System.Drawing.Image)row[i];
                                MemoryStream mstream = new MemoryStream();
                                image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                                sheet.Pictures.Add(nRow, i, mstream);
                            }
                            else
                            {
                                cells[nRow, i].PutValue(row[i]);
                            }
                        }
                    }
                    catch (System.Exception e)
                    {
                        error = error + " DataTableToExcel: " + e.Message;
                    }
                }

                workbook.Save(filepath);
                return true;
            }
            catch (System.Exception e)
            {
                error = error + " DataTableToExcel: " + e.Message;
                return false;
            }
        }

        public static bool DataTableToExcel2(DataTable datatable, string filepath, out string error)
        {

            error = "";
            Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();

            try
            {
                if (datatable == null)
                {
                    error = "DataTableToExcel:datatable 为空";
                    return false;
                }

                //为单元格添加样式    
                Aspose.Cells.Style style = wb.Styles[wb.Styles.Add()];
                //设置居中
                style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center;
                //设置背景颜色
                style.ForegroundColor = System.Drawing.Color.FromArgb(153, 204, 0);
                style.Pattern = BackgroundType.Solid;
                style.Font.IsBold = true;


                int rowIndex = 0;
                for (int i = 0; i < datatable.Columns.Count; i++)
                {
                    DataColumn col = datatable.Columns[i];
                    string columnName = col.Caption ?? col.ColumnName;
                    wb.Worksheets[0].Cells[rowIndex, i].PutValue(columnName);
                    wb.Worksheets[0].Cells[rowIndex, i].SetStyle(style);
                }
                rowIndex++;

                foreach (DataRow row in datatable.Rows)
                {
                    for (int i = 0; i < datatable.Columns.Count; i++)
                    {
                        wb.Worksheets[0].Cells[rowIndex, i].PutValue(row[i].ToString());
                    }
                    rowIndex++;
                }

                for (int k = 0; k < datatable.Columns.Count; k++)
                {
                    wb.Worksheets[0].AutoFitColumn(k, 0, 150);
                }
                wb.Worksheets[0].FreezePanes(1, 0, 1, datatable.Columns.Count);
                wb.Save(filepath);
                return true;
            }
            catch (Exception e)
            {
                error = error + " DataTableToExcel: " + e.Message;
                return false;
            }
        }

        /// <summary>
        /// 自己定义的
        /// </summary>
        public static bool Ecu_Id_DataTableToExcel(DataTable datatable, string filepath, out string error)
        {
            //string file = Application.StartupPath + "\\13id\\" +"id.xls";
            //filepath = file;
            error = "";
            try
            {
                if (datatable == null)
                {
                    error = "DataTableToExcel:datatable 为空";
                    return false;
                }
                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
                Aspose.Cells.Worksheet sheet = workbook.Worksheets[0];
                Aspose.Cells.Cells cells = sheet.Cells;
                cells.SetColumnWidth(4, 40);
                cells.SetColumnWidth(3, 40);
                Aspose.Cells.Style style = new Style();
                style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center;
                style.Pattern = BackgroundType.Solid;
                style.Font.IsBold = true;
                StyleFlag a = new StyleFlag();
                a.WrapText = true;
                style.IsTextWrapped = true;           //文本换行 这里很重要的；有助于格式的的显示内容
                cells.ApplyStyle(style, a);
                cells.ImportDataTable(datatable, true, "A5");
                workbook.Save(filepath);
            }
            catch (System.Exception e)
            {
                error = error + " DataTableToExcel: " + e.Message;
                return false;
            }
            return true;

        }

        public static bool Dtc_DataTableToExcel(DataTable datatable, string filepath, out string error)
        {
            string file = Application.StartupPath + "\\13dtc" + DateTime.Now.ToString()+"id.xls";
           
            datatable.Columns.Remove("ID");
            error = "";
            try
            {
                if (datatable == null)
                {
                    error = "DataTableToExcel:datatable 为空";
                    return false;
                }
                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
                Aspose.Cells.Worksheet sheet = workbook.Worksheets[0];
                Aspose.Cells.Cells cells = sheet.Cells;
                cells.SetColumnWidth(0, 25);
                cells.SetColumnWidth(1, 17);
                cells.SetColumnWidth(2, 28.5);
                cells.SetColumnWidth(3, 10);
                cells.SetColumnWidth(4, 10);
                cells.SetColumnWidth(5, 25);
                Aspose.Cells.Style style = new Style();
                style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center;
                style.Pattern = BackgroundType.Solid;
                style.Font.IsBold = true;
                StyleFlag a = new StyleFlag();
                a.WrapText = true;
                style.IsTextWrapped = true;           //文本换行 这里很重要的；有助于格式的的显示内容
                cells.ApplyStyle(style, a);
                cells.ImportDataTable(datatable, true, "A5");
                workbook.Save(filepath);
            }
            catch (System.Exception e)
            {
                error = error + " DataTableToExcel: " + e.Message;
                return false;
            }
            return true;

        }

        public static bool Tp_DataTableToExcel(DataTable datatable, string filepath, out string error)
        {
            string file = Application.StartupPath + "\\13tp" + DateTime.Now.ToString();
           
            error = "";
            try
            {
                if (datatable == null)
                {
                    error = "DataTableToExcel:datatable 为空";
                    return false;
                }
                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
                Aspose.Cells.Worksheet sheet = workbook.Worksheets[0];
                Aspose.Cells.Cells cells = sheet.Cells;
                cells.SetColumnWidth(0, 25);
                cells.SetColumnWidth(1, 17);
                cells.SetColumnWidth(2, 28.5);
                cells.SetColumnWidth(3, 10);
                cells.SetColumnWidth(4, 10);
                cells.SetColumnWidth(5, 25);
                Aspose.Cells.Style style = new Style();
                style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center;
                style.Pattern = BackgroundType.Solid;
                style.Font.IsBold = true;
                StyleFlag a = new StyleFlag();
                a.WrapText = true;
                style.IsTextWrapped = true;           //文本换行 这里很重要的；有助于格式的的显示内容
                cells.ApplyStyle(style, a);
                cells.ImportDataTable(datatable, true, "A5");
                workbook.Save(filepath);
            }
            catch (System.Exception e)
            {
                error = error + " DataTableToExcel: " + e.Message;
                return false;
            }
            return true;

        }

        public static void DataTableToExcelDesigner(DataTable dt, string filepath)
        {

            WorkbookDesigner wd = new WorkbookDesigner();
            //Open the template file (which contains smart markers).

            
            //Set the datatable as the data source.
            wd.SetDataSource(dt);
            //Process the smart markers to fill the data into the worksheets.
            wd.Process(true);
            //Save the excel file.
            wd.Workbook.Save("D:\\test\\outSmartMarker_Designer.xls");

        }

        public static bool ListsToExcelFile(string filepath, IList[] lists, out string error)
        {
            error = "";
            //----------Aspose变量初始化----------------
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
            Aspose.Cells.Worksheet sheet = workbook.Worksheets[0];
            Aspose.Cells.Cells cells = sheet.Cells;
            //-------------输入数据-------------
            int nRow = 0;
            sheet.Pictures.Clear();
            cells.Clear();
            foreach (IList list in lists)
            {

                for (int i = 0; i <= list.Count - 1; i++)
                {
                    try
                    {
                        System.Console.WriteLine(i.ToString() + "  " + list[i].GetType());
                        if (list[i].GetType().ToString() == "System.Drawing.Bitmap")
                        {
                            //插入图片数据
                            System.Drawing.Image image = (System.Drawing.Image)list[i];

                            MemoryStream mstream = new MemoryStream();

                            image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);

                            sheet.Pictures.Add(nRow, i, mstream);
                        }
                        else
                        {
                            cells[nRow, i].PutValue(list[i]);
                        }
                    }
                    catch (System.Exception e)
                    {
                        error = error + e.Message;
                    }

                }

                nRow++;
            }
            //-------------保存-------------
            workbook.Save(filepath);

            return true;
        }

        public void Tp_SaveExcel()
        {

            string sql = "select * from Trip";
            accessdb = new AccessDbClass(MyMeans.strConn1);
            DataTable a = accessdb.SelectToDataTable(sql);
            DataTable dt = a;
            string outError = "";
            string fileName = " dtc.xls";
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
    }
}
