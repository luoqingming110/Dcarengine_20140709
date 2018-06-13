using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Data.OleDb;
using System.Collections;
using Dcarengine.Function_Class;
using Dcarengine.UIForm;
using Dcarengine.SQLData;
using Aspose.Cells;
using Dcarengine.serialPort;
using Dcarengine.refactor;
using CCWin;

namespace Dcarengine
{
    public partial class 测量 : CCSkinMain
    {


        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region   字段
        private static bool measureflag = true;  ///判断测量是否结束,true 为停止
        private string select;
        string[] num;                ///这里是取出数据库里面num的数据放在num数组中
        string[] patent;             ///  patent 是代表数据库里面的数据，代表的是公式。
        string[] SWORDFALG;          ///  
        string[] SLongFALG;
        int[] RecordLength;          ///这里是记录每次读取取得的数据的长度；
        int[] RecordShujuChangDu;    ///这里是记录每次读完后的数据 ，用于写在DataRow中
        string[] RecordMeiCiDuDezhi;
        int JiLu_AllNum;                                      ///记录每次用的数据  初始化为1
        string[] FinalResult;
        string[] Value;
        byte[] saveTestData;                  ///这里是用来保存转化好的数据，仅用于实验而不是完整的程序用的，
        byte[][] measureWriteCmd;        ///这里是用来转化好的数据，用二维数组存放
        int Rowflags = 0;
        int DatagridrowNum;          ///这里是标记当前datagridview的行数，有很多的用处。       
        private string cont = MyMeans.strConn1;
        

        //sql connect
        DataSet ds;
        OleDbDataAdapter da;
        DataGridViewRow dr;
        OleDbConnection con;
        public DataTable ResultDatatable;
        //时间 和传递的行数；
        Int32 CountTime = 200, TotalTime = 0;    
        string GetBackSring;
      //  ArrayList AGetBackString = new ArrayList();
        //返回来的数据
        string BackString;
        //保存数据
        static  bool SaveMFlage;
        //获取参数表问题
        String EcuAddressTable;
        //excelFilePath
        static string excelFilePath;

        /// <summary>
        /// value 数据值
        /// </summary>
        /// <param name="value"></param>
        public delegate void  DataGridViewEdit();
        private  DataGridViewEdit dataGridViewEditF;
        private DataGridViewEdit  NoDatadataGridViewEditF;

        #endregion




        public 测量()
        {
            InitializeComponent();
            try
            {
                dataGridViewEditF = new DataGridViewEdit(DataGridView);
                NoDatadataGridViewEditF = new DataGridViewEdit(NoDtaDataGridView);

                con = new OleDbConnection(cont);
                num = new string[40];
                patent = new string[40];
                SWORDFALG = new string[40];
                SLongFALG = new string[40];
                saveTestData = new byte[12];
                //ecu version get table 
                if (EcuVersionF.EcuVsion != null)
                {
                    EcuAddressTable = (String)CommonConstant.EcuVersionMap[EcuVersionF.EcuVsion];
                }
                if (EcuAddressTable != null)
                {
                    con = new OleDbConnection(cont);
                    con.Open();
                    string sqlString = "select name from  " + EcuAddressTable;
                    DataSet mydataset = new DataSet();
                    OleDbDataAdapter myApdataer = new OleDbDataAdapter(sqlString, cont);
                    myApdataer.Fill(mydataset, "ECU13AdRess");
                    string[] arr = new string[mydataset.Tables[0].Rows.Count];
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = mydataset.Tables[0].Rows[i][0].ToString();
                    }
                    Array.Sort(arr);
                    测量参数.Items.AddRange(arr);
                    测量参数.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    测量参数.AutoCompleteSource = AutoCompleteSource.ListItems;
                    this.选择时间.Text = "200";
                }
            }
            catch (Exception e)
            {
                log.Info("measure is error :" + e.Message);
            }
        }


        private void 测量_Load(object sender, EventArgs e)
        {
           
        }



        /// <summary>
        /// DataGrideView  delegate  functions
        /// </summary>
        public void DataGridView()
        {
            for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
            {
                dataGridView1.Rows[j].Cells[3].Value = Value[j];
            }
        }

        /// <summary>
        /// DataGrideView  delegate  functions
        /// </summary>
        public void NoDtaDataGridView()
        {
            for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
            {
                dataGridView1.Rows[j].Cells[3].Value = "NO DATA ";
            }
        }

        /// <summary>
        /// 测量数据保存
        /// </summary>
        public  void WorkoutBySave()
        {        
            try
            {

                string Svalue = BackString.Replace(" ", "");
                //contains no
                if (Svalue.Contains("NO")) {

                    if (dataGridView1.InvokeRequired)
                    {
                        
                        Invoke(NoDatadataGridViewEditF);
                    }
                    else
                    {
                        for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                        {
                            dataGridView1.Rows[j].Cells[3].Value = "NO DATA";
                        }
                    }
                }
                //contains no
                if (!Svalue.Contains("NO") && !StringUtil.IsStringEmpty(Svalue) )
                {
                    int x = 4;
                    for (int i = 0; i < DatagridrowNum; i++)
                    {
                        RecordMeiCiDuDezhi[i] = Svalue.Substring(x, RecordShujuChangDu[i] * 2);
                        x = x + RecordShujuChangDu[i] * 2;
                    }
                    TotalTime = CountTime + TotalTime;
                    DataRow AddDataRow = ResultDatatable.NewRow();
                    AddDataRow[0] = TotalTime;
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        if (RecordShujuChangDu[i] == 1)
                        {
                            Int32 res = Int32.Parse(RecordMeiCiDuDezhi[i], System.Globalization.NumberStyles.AllowHexSpecifier);
                            FinalResult[i] = patent[i].Replace("x", res.ToString());
                            MSScriptControl.ScriptControl sc1 = new MSScriptControl.ScriptControl();
                            sc1.Language = "JavaScript";
                            Value[i] = sc1.Eval(FinalResult[i]).ToString("#0.00");
                            AddDataRow[i + 1] = Value[i];
                        }
                        else if (RecordShujuChangDu[i] == 2)
                        {
                            string a = RecordMeiCiDuDezhi[i].Substring(0, 2);
                            string b = RecordMeiCiDuDezhi[i].Substring(2, 2);
                            string c = b + a;
                            char[] d = b.Substring(0, 1).ToCharArray();     // 判断数据是以1开头的。。。。。
                            Int32 res;
                            if (SWORDFALG[i].Contains("1") && (d[0] > '7' && d[0] < 'G'))
                            {
                                res = 65535 - Int32.Parse(c, System.Globalization.NumberStyles.AllowHexSpecifier);
                            }
                            else
                            {
                                res = Int32.Parse(c, System.Globalization.NumberStyles.AllowHexSpecifier);
                            }
                            FinalResult[i] = patent[i].Replace("x", res.ToString());
                            MSScriptControl.ScriptControl sc1 = new MSScriptControl.ScriptControl();
                            sc1.Language = "JavaScript";
                            Value[i] = sc1.Eval(FinalResult[i]).ToString("#0.00");
                            AddDataRow[i + 1] = Value[i];
                        }
                        else if (RecordShujuChangDu[i] == 4)
                        {
                            string a = RecordMeiCiDuDezhi[i].Substring(0, 2);
                            string b = RecordMeiCiDuDezhi[i].Substring(2, 2);
                            string c = RecordMeiCiDuDezhi[i].Substring(4, 2);
                            string d = RecordMeiCiDuDezhi[i].Substring(6, 2);
                            string e = d + c + b + a;
                            char[] f = e.Substring(0, 1).ToCharArray();
                            Int64 res;
                            if (SLongFALG[i].Contains("1") && (f[0] > '7' && f[0] < 'G'))
                            {
                                res = 4294967295 - Int64.Parse(e, System.Globalization.NumberStyles.AllowHexSpecifier);
                            }
                            else
                            {
                                res = Int64.Parse(e, System.Globalization.NumberStyles.AllowHexSpecifier);
                            }
                            FinalResult[i] = patent[i].Replace("x", res.ToString());
                            MSScriptControl.ScriptControl sc1 = new MSScriptControl.ScriptControl();
                            sc1.Language = "JavaScript";
                            double num1 = sc1.Eval(FinalResult[i]);
                            Value[i] = num1.ToString("#0.00");
                            AddDataRow[i + 1] = Value[i];
                        }
                    }
                    ResultDatatable.Rows.Add(AddDataRow);
                    // dataGridView1 is invokeRe
                    if (dataGridView1.InvokeRequired)
                    {
                        log.Info("DataTable length is  delegate:" + ResultDatatable.Rows.Count);
                        this.Invoke( dataGridViewEditF);
                    }
                    else
                    {
                        for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                        {
                            dataGridView1.Rows[j].Cells[3].Value = Value[j];
                        }
                        log.Info("dataGridView is not delegate, DataTable length is :" + ResultDatatable.Rows.Count);
                    }
                }
                
                //每 到一定量清空数据
                if (ResultDatatable.Rows.Count >= 300)  {
                    Thread t = new Thread(new ParameterizedThreadStart(SynOpenExeclWorkbook));
                    t.Start(excelFilePath);                 
                }
            }
            catch (Exception  e) {

                log.Info("measure  workout is error ..."  + e.Message);
                return;

            }
        }


        /// <summary>
        /// 测量不保存
        /// </summary>
        private void workOutByNoSave()
        {

            try
            {
                string Svalue = BackString.Replace(" ", "");
                //直接返回
                if (Svalue.Contains("NO")) {
                    //delegate dataGrideView
                    if (dataGridView1.InvokeRequired)
                    {
                        Invoke(NoDatadataGridViewEditF);
                    }
                    else
                    {
                        for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                        {
                            dataGridView1.Rows[j].Cells[3].Value = "NO DATA";
                        }
                        log.Info("dataGridView is not delegate, DataTable length is :" + ResultDatatable.Rows.Count);
                    }
                }
                //返回数据
                if (!Svalue.Contains("NO") && !StringUtil.IsStringEmpty(Svalue))
                {
                    int x = 4;
                    for (int i = 0; i < DatagridrowNum; i++)
                    {
                        RecordMeiCiDuDezhi[i] = Svalue.Substring(x, RecordShujuChangDu[i] * 2);
                        x = x + RecordShujuChangDu[i] * 2;
                    }
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        if (RecordShujuChangDu[i] == 1)
                        {
                            Int32 res = Int32.Parse(RecordMeiCiDuDezhi[i], System.Globalization.NumberStyles.AllowHexSpecifier);
                            FinalResult[i] = patent[i].Replace("x", res.ToString());
                            MSScriptControl.ScriptControl sc1 = new MSScriptControl.ScriptControl();
                            sc1.Language = "JavaScript";
                            Value[i] = sc1.Eval(FinalResult[i]).ToString("#0.00");
                        }
                        else if (RecordShujuChangDu[i] == 2)
                        {
                            string a = RecordMeiCiDuDezhi[i].Substring(0, 2);
                            string b = RecordMeiCiDuDezhi[i].Substring(2, 2);
                            string c = b + a;
                            char[] d = b.Substring(0, 1).ToCharArray();   //  
                            Int32 res;
                            if (SWORDFALG[i].Contains("1") && (d[0] > '7' && d[0] < 'G'))
                            {
                                res = 65535 - Int32.Parse(c, System.Globalization.NumberStyles.AllowHexSpecifier);
                            }
                            else
                            {
                                res = Int32.Parse(c, System.Globalization.NumberStyles.AllowHexSpecifier);
                            }
                            FinalResult[i] = patent[i].Replace("x", res.ToString());
                            MSScriptControl.ScriptControl sc1 = new MSScriptControl.ScriptControl();
                            sc1.Language = "JavaScript";
                            Value[i] = sc1.Eval(FinalResult[i]).ToString("#0.00");
                        }
                        else if (RecordShujuChangDu[i] == 4)
                        {
                            string a = RecordMeiCiDuDezhi[i].Substring(0, 2);
                            string b = RecordMeiCiDuDezhi[i].Substring(2, 2);
                            string c = RecordMeiCiDuDezhi[i].Substring(4, 2);
                            string d = RecordMeiCiDuDezhi[i].Substring(6, 2);
                            string e = d + c + b + a;
                            char[] f = e.Substring(0, 1).ToCharArray();
                            Int64 res;
                            if (SLongFALG[i].Contains("1") && (f[0] > '7' && f[0] < 'G'))
                            {
                                res = 4294967295 - Int64.Parse(e, System.Globalization.NumberStyles.AllowHexSpecifier);
                            }
                            else
                            {
                                res = Int64.Parse(e, System.Globalization.NumberStyles.AllowHexSpecifier);
                            }
                            FinalResult[i] = patent[i].Replace("x", res.ToString());
                            MSScriptControl.ScriptControl sc1 = new MSScriptControl.ScriptControl();
                            sc1.Language = "JavaScript";
                            double num1 = sc1.Eval(FinalResult[i]);
                            Value[i] = num1.ToString("#0.00");
                        }
                    }
                    //delegate dataGrideView
                    if (dataGridView1.InvokeRequired)
                    {
                        log.Info("DataTable length is  delegate:" + ResultDatatable.Rows.Count);
                        this.Invoke(dataGridViewEditF);
                    }
                    else
                    {
                        for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                        {
                            dataGridView1.Rows[j].Cells[3].Value = Value[j];
                        }
                        log.Info("dataGridView is not delegate, DataTable length is :" + ResultDatatable.Rows.Count);
                    }
                }

            }
            catch (Exception e) {
                log.Info("measure work out is error :" + e.Message);
            }
        }


        private void 插入_Click(object sender, EventArgs e)
        {
            if (measureflag)
            {         
                string Selected_String = this.测量参数.Text;
                bool Selected_Falg = this.CompareSelText();
                //ecutable select 
                if (Selected_Falg && EcuAddressTable!=null)
                {
                    select = "SELECT * FROM " + EcuAddressTable + " where name='" + Selected_String + "'";
                    da = new OleDbDataAdapter(select, con);
                    ds = new DataSet();
                    da.Fill(ds, "Table1_1");
                    foreach (DataRow row in ds.Tables["Table1_1"].Rows)
                    {
                        int index = this.dataGridView1.Rows.Add();
                        dr = dataGridView1.Rows[index];
                        dr.Cells[0].Value = row[0];
                        dr.Cells[1].Value = row[3];
                        dr.Cells[2].Value = row[1];
                        dr.Cells[3].Value = row[2];          //Decription..
                        dr.Cells[4].Value = row[4];
                        dr.Cells[5].Value = row[5];
                        dr.Cells[6].Value = row[6];
                        dr.Cells[7].Value = row[7];
                    }
                    Rowflags++;
                }
                else
                {
                    Selected_Falg = false;
                }             
            }
            else
            {
                MessageBox.Show("参数正在测量中，请稍后！", "信息提示",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CompareSelText()
        {
            bool SelectedFalg = false;
            System.Data.DataTable a = this.DatagridviewTodatatble(this.dataGridView1);
            for (int i = 0; i < a.Rows.Count; i++)
            {
                string value = a.Rows[i][0].ToString();

                if (value == this.测量参数.Text)
                {
                    MessageBox.Show("已经选择了该参数");
                    SelectedFalg = false;
                    break;
                }
                else
                {
                    SelectedFalg = true;
                }
            }
            return SelectedFalg;
        }

        private bool CompareSelText(string CompareString)
        {
            bool SelectedFalg = false;
            System.Data.DataTable a = this.DatagridviewTodatatble(this.dataGridView1);
            for (int i = 0; i < a.Rows.Count; i++)
            {
                string value = a.Rows[i][0].ToString();
                if (value == CompareString)
                {
                    SelectedFalg = false;
                    break;
                }
                else
                {
                    SelectedFalg = true;
                }
            }
            return SelectedFalg;
        }


        



        /// <summary>
        /// 处理数据问题模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private  void measure_DataReceivedByMeasure(object sender, SerialDataReceivedEventArgs e)
        {

            BackString = "";
            long startTime = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
            try
            {
                while (!(BackString.Contains("\r\n\r\n>")))
                {
                    byte[] ReDatas = new byte[GobalSerialPort.SerialPort.BytesToRead];//返回命令包
                    GobalSerialPort.SerialPort.Read(ReDatas, 0, ReDatas.Length);//读取数据
                    GetBackSring = Encoding.Default.GetString(ReDatas);
                    BackString = BackString + GetBackSring;
                    long workTime = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
                    if (workTime - startTime > 5000)
                    {
                        BackString = "";
                        GobalSerialPort.ClearSendAndRecive();
                        log.Info("revice data from byffer " + BackString + " ;breakTime:" + (workTime - startTime));
                        break;
                    }
                }
                GobalSerialPort.ResultBackString = BackString;
                long endTime = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
                log.Info("revice data from byffer " + BackString + " ;workTime:" + (endTime - startTime));
                CommonAutoRest.MEvent.Set();
                Interlocked.Decrement(ref CommonAutoRest.AutoResetCount);

                if ((BackString.Contains("6C") && BackString.Contains("F0"))
                     || BackString.Contains("OK"))
                {
                    CommonAutoRest.MEvent.Set();
                    Interlocked.Decrement(ref CommonAutoRest.AutoResetCount);
                    return;
                }
            }
            catch { }

            if (SaveMFlage == true )
            {
                 WorkoutBySave();
            }
            if (SaveMFlage == false)
            {
                 workOutByNoSave();
            }

        }

       

        public void SaveExcleAsopse()
        {
            try
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.RestoreDirectory = true;
                fileDialog.Title = "导出Excel";
                fileDialog.Filter = "Excel文件(*.xls)|*.xls|*.xlsx";
                //    DialogResult dialogResult = fileDialog.ShowDialog();
                //   string excelFilePath = fileDialog.FileName;
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string excelFilePath = fileDialog.FileName;
                    AposeCellToWorkbook(excelFilePath);
                }
            }
            catch
            {
                MainF.EcuIsLinked = false;//保存失败时，串口会自动断开        
            }
        }


        /// <summary>
        /// 数据保存到excelPath
        /// </summary>
        public void AposeCellToWorkbook(String  excelPath) {

            try
            {
                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
                Aspose.Cells.Worksheet sheet = workbook.Worksheets[0];
                Aspose.Cells.Cells cells = sheet.Cells;
                Aspose.Cells.Style style = new Aspose.Cells.Style();
                style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center;
                style.Pattern = BackgroundType.Solid;
                style.Font.IsBold = true;
                StyleFlag a = new StyleFlag();
                a.WrapText = true;
                style.IsTextWrapped = true;           //文本换行 这里很重要的；有助于格式的的显示内容
                cells.ApplyStyle(style, a);
                cells.ImportDataTable(ResultDatatable, true, "A3");
                workbook.Save(excelFilePath);
            }
            catch (Exception e) {

                log.Info("workbook sheet is error :" + e.Message);
            }
        }


        /// <summary>
        /// 数据保存到excelPath
        /// </summary>
        public void  SynOpenExeclWorkbook(Object excelPath)
        {

            try
            {
                //ResultDatatable 
                Workbook CurrentWorkbook = File.Exists(excelFilePath) ? new Workbook(excelFilePath) : new Workbook();
                Aspose.Cells.Worksheet sheet = CurrentWorkbook.Worksheets[0];
                Aspose.Cells.Cells cells = sheet.Cells;
                int rowCount = cells.MaxDataRow;
                int columnCount = cells.MaxDataColumn; 
                Aspose.Cells.Style style = new Aspose.Cells.Style();
                style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center;
                style.Pattern = BackgroundType.Solid;
                style.Font.IsBold = true;
                StyleFlag a = new StyleFlag();
                a.WrapText = true;
                style.IsTextWrapped = true;           //文本换行 这里很重要的；有助于格式的的显示内容
                cells.ApplyStyle(style, a);
                if (rowCount == -1 && columnCount == -1)
                {

                    cells.ImportDataTable(ResultDatatable, true, "A3");
                }
                else {

                    cells.ImportDataTable(ResultDatatable, false, rowCount+1,0);
                }
                log.Info("workbook sheet from result , count:" + ResultDatatable.Rows.Count);
                ResultDatatable.Rows.Clear();
                CurrentWorkbook.Save(excelFilePath);
                //CommonAutoRest.MainFTextThreadMessage1.Set();
            }
            catch (Exception e)
            {
                log.Info("workbook sheet is error :" + e.Message);
            }

        }


        public System.Data.DataTable DatagridviewTodatatble(DataGridView dataGridView1)
        {

            System.Data.DataTable dt = new System.Data.DataTable();
            dt.TableName = "test";
            //添加列
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dt.Columns.Add(dataGridView1.Columns[i].Name);
            }
            //添加行
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                DataRow dr = dt.NewRow();
                for (int k = 0; k < dataGridView1.Columns.Count; k++)
                {
                    dr[k] = dataGridView1.Rows[j].Cells[k].Value;
                }

                dt.Rows.Add(dr);        //将数据写入DATATABLE中。
            }
            return dt;
        }

        /// <summary>
        ///一定要注意额，这里是我们在已经知道两个是在一样的大小下才能调用此函数
        /// </summary>
        /// <param name="datatbale"></param>
        /// <returns></returns>
        public void DatatabletoDataGridview(System.Data.DataTable datatbale)
        {
            DataGridView dg = new DataGridView();
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                for (int k = 0; k < dataGridView1.Columns.Count; k++)
                {
                    dataGridView1.Rows[j].Cells[k].Value = datatbale.Rows[j][k];
                }
            }
        }

        private System.Data.DataTable SwapDTCR(System.Data.DataTable inputDT)
        {
            System.Data.DataTable outputDT = new System.Data.DataTable();
            // 标题的位置不变
            // outputDT.Columns.Add(inputDT.Columns[0].ColumnName.ToString());
            int ColumnCount = inputDT.Rows.Count;
            /*
              foreach (DataRow inRow in inputDT.Rows)
              {
                  string newColName = inRow[0].ToString();
                  outputDT.Columns.Add(newColName);
              }*/
            for (int i = 0; i < ColumnCount; i++)
            {
                outputDT.Columns.Add();
            }

            for (int rCount = 0; rCount < inputDT.Columns.Count - 2; rCount++)
            {
                DataRow newRow = outputDT.NewRow();
                newRow[0] = inputDT.Columns[rCount].ColumnName.ToString();
                for (int cCount = 0; cCount < inputDT.Rows.Count; cCount++)
                {
                    string colValue = inputDT.Rows[cCount][rCount].ToString();
                    newRow[cCount] = colValue;
                }
                outputDT.Rows.Add(newRow);
            }
            return outputDT;
        }

        public System.Data.DataTable FinalDatatable(System.Data.DataTable datatable1)
        {

            System.Data.DataTable Adddt = new System.Data.DataTable();
            System.Data.DataTable dt = datatable1;
            System.Data.DataTable newDataTable = new System.Data.DataTable();
            for (int i = 0; i < dt.Columns.Count + 1; i++)
            {
                newDataTable.Columns.Add();
            }
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                newDataTable.Rows.Add();
            }
            for (int col = 0; col < dt.Columns.Count; col++)
            {
                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    newDataTable.Rows[row][col + 1] = dt.Rows[row][col];
                }
            }
            newDataTable.Rows[0][0] = "time";
            newDataTable.Rows[1][0] = "时间间隔";
            newDataTable.Rows[2][0] = "s";
            return newDataTable;
        }

        private void 保存_Click(object sender, EventArgs e)
        {
            if (measureflag)
            {
                //SaveExcel();
                SaveExcleAsopse();
            }
            else
            {
                MessageBox.Show("请先停止测量！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 停止测量_Click(object sender, EventArgs e)
        {
            if (measureflag)
            {
                MessageBox.Show("尚未开始测量！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (MeasureTimer.stateTimer != null)
                {
                    MeasureTimer.stateTimer.Dispose();
                }
                measureflag = true;            
            }
        }

        private void 测量不保存_Click(object sender, EventArgs e)
        {
            SaveMFlage = false;
            if (!EcuConnectionF.ECULINKStatus1)
            {
                MessageBox.Show("串口未连接！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (measureflag)
            {
                this.单次测量.Text = "停止测量";
                measureflag = false;
                if (this.dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("请插入测量参数！", "信息提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.dataGridView1.CurrentRow != null && this.dataGridView1.Rows.Count >= 21)
                {
                    MessageBox.Show("连续测量一次最多20个，请请删除部分参数！", "信息提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (this.dataGridView1.CurrentRow != null && this.dataGridView1.Rows.Count < 21)
                {
                    new Thread(DoubleMeasure).Start();
                }
            }                  
            else
            {
                //时间 和传递的行数；
                CountTime = 200;
                TotalTime = 0;
                MeasureTimer.TimeDispose();

                GobalSerialPort.SerialPort.DataReceived -= new SerialDataReceivedEventHandler(measure_DataReceivedByMeasure);

                GobalSerialPort.SerialPort.DataReceived += new SerialDataReceivedEventHandler(GobalSerialPort.SerialportMessage_DataReceived);


                EcuConnectionF ecuConnectionF = new EcuConnectionF();

                ecuConnectionF.ConnectEuc();
                GobalSerialPort.Write(CommonCmd.ClearCmd, 0, CommonCmd.ClearCmd.Length);
                Thread.Sleep(1500);
                CommonAutoRest.MEvent.Set();
                this.单次测量.Text = "测试不保存";
                measureflag = true;


            }      
        }


        /// <summary>
        /// 清除命令延时处理函数
        /// </summary>
        public void ClearDelay() {

            GobalSerialPort.WriteByMessage(CommonCmd.ATE0, 0, CommonCmd.ATE0.Length);                                
            GobalSerialPort.WriteByMessage(CommonCmd.ClearCmd, 0, CommonCmd.ClearCmd.Length);
        }

        /// <summary>
        /// 清除命令延时处理函数
        /// </summary>
        public void RealyDelay()
        {

            GobalSerialPort.WriteByMessage(CommonCmd.ATE1, 0, CommonCmd.ATE1.Length);
            GobalSerialPort.WriteByMessage(CommonCmd.ClearCmd, 0, CommonCmd.ClearCmd.Length);
        }

        /// <summary>
        /// 测量数据
        /// </summary>
        private void DoubleMeasure()
        {

            try
            {
                JiLu_AllNum = 01;
                this.DatagridrowNum = this.dataGridView1.RowCount - 1;            //因为这里本来由一行是空格的，所以要减一
                this.measureWriteCmd = new byte[this.DatagridrowNum][];           //这里是初始化数组。。
                RecordShujuChangDu = new int[DatagridrowNum];
                RecordMeiCiDuDezhi = new string[DatagridrowNum];
                FinalResult = new string[this.DatagridrowNum];
                Value = new string[this.DatagridrowNum];
                DataTable dt = this.DatagridviewTodatatble(this.dataGridView1);  //这是调用函数的用法。。

                for (int i = 0; i < DatagridrowNum; i++)
                {
                    num[i] = dt.Rows[i][4].ToString();
                    patent[i] = dt.Rows[i][7].ToString();
                    SWORDFALG[i] = dt.Rows[i][5].ToString();
                    SLongFALG[i] = dt.Rows[i][6].ToString();
                }
                if (DatagridrowNum > 10)
                {
                    int DataNumbeishu = DatagridrowNum / 10;                       //将毎5行的数据当做一个命令来经行测量，这样的话就要求知道行数的倍数，这是代表着行数的倍数
                    int DataNumyushu = DatagridrowNum % 10;                        //这里代表着行数的余数
                    string[] Before_WriteString = new string[DataNumbeishu + 1];  //这里是代表的有几个5个为一组的命令，这里必须加1；
                    for (int BS = 0; BS < DataNumbeishu; BS++)
                    {
                        Before_WriteString[BS] = "";
                        string addstring = "2CF0";
                        for (int i = 0; i < 10; i++)
                        {
                            RecordLength = new int[i + BS * 10];//记录所有的用到的长度。。。
                            string suffixCmd = "02";
                            string a = num[i + BS * 10].Substring(9, 1);
                            string b = num[i + BS * 10].Substring(2, 6);
                            if (a == "1")
                            {
                                suffixCmd = "01";
                            }
                            else if (a == "2")
                            {
                                suffixCmd = "02";
                            }
                            else if (a == "4")
                            {
                                suffixCmd = "04";
                            }
                            Before_WriteString[BS] = Before_WriteString[BS] + addstring + "03" + JiLu_AllNum.ToString("X").PadLeft(2, '0') + suffixCmd + b;
                            JiLu_AllNum = JiLu_AllNum + Convert.ToInt32(suffixCmd);
                            RecordShujuChangDu[i + BS * 10] = Convert.ToInt32(suffixCmd);
                            addstring = "";
                        }
                    }
                    string _2CF0_Add = "2CF0";                     /////////////////这里是设置2CF0、、、、、、、、、、、、、、、；
                    Before_WriteString[DataNumbeishu] = "";
                    for (int i = 0; i < DataNumyushu; i++)
                    {
                        RecordLength = new int[i + DataNumbeishu * 10];//记录所有的用到的长度。。。
                        string shujuchangdu = "02";
                        string a = num[i + DataNumbeishu * 10].Substring(9, 1);
                        string b = num[i + DataNumbeishu * 10].Substring(2, 6);
                        if (a == "1")
                        {
                            shujuchangdu = "01";
                        }
                        else if (a == "2")
                        {
                            shujuchangdu = "02";
                        }
                        else if (a == "4")
                        {
                            shujuchangdu = "04";
                        }
                        Before_WriteString[DataNumbeishu] = Before_WriteString[DataNumbeishu] + _2CF0_Add + "03" + JiLu_AllNum.ToString("X").PadLeft(2, '0') + shujuchangdu + b;
                        JiLu_AllNum = JiLu_AllNum + Convert.ToInt32(shujuchangdu);
                        RecordShujuChangDu[i + DataNumbeishu * 10] = Convert.ToInt32(shujuchangdu);
                        _2CF0_Add = "";
                    }
                    JiLu_AllNum = 01;                                                       //将数据还原为 初始状态；；；；
                    GobalSerialPort.WriteByMessage(CommonCmd.ATE0, 0, CommonCmd.ATE0.Length);
                    Thread.Sleep(200);
                    GobalSerialPort.WriteByMessage(CommonCmd.ClearCmd, 0, CommonCmd.ClearCmd.Length);
                    Thread.Sleep(200);
                    for (int i = 0; i < DataNumbeishu + 1; i++)
                    {
                        byte[] writeString = StringToSendBytes.bytesToSend(Before_WriteString[i] + "\n");
                        GobalSerialPort.WriteByMessage(writeString, 0, writeString.Length);
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    string addstring = "2CF0";
                    string Before_WriteString = "";
                    for (int length = 0; length < DatagridrowNum; length++)
                    {
                        RecordLength = new int[length];   //记录所有的用到的长度。。。
                        string suffixCmd = "02";
                        string a = num[length].Substring(9, 1);
                        string b = num[length].Substring(2, 6);
                        if (a == "1")
                        {
                            suffixCmd = "01";
                        }
                        else if (a == "2")
                        {
                            suffixCmd = "02";
                        }
                        else if (a == "4")
                        {
                            suffixCmd = "04";
                        }
                        Before_WriteString = Before_WriteString + addstring + "03" + JiLu_AllNum.ToString("X").PadLeft(2, '0') + suffixCmd + b;
                        JiLu_AllNum = JiLu_AllNum + Convert.ToInt32(suffixCmd);
                        RecordShujuChangDu[length] = Convert.ToInt32(suffixCmd);
                        addstring = "";
                    }
                    JiLu_AllNum = 01;
                    //设置数据格式。。。              
                    GobalSerialPort.WriteByMessage(CommonCmd.ATE0, 0, CommonCmd.ATE0.Length);
                    Thread.Sleep(200);
                    GobalSerialPort.WriteByMessage(CommonCmd.ClearCmd, 0, CommonCmd.ClearCmd.Length);
                    Thread.Sleep(200);
                    byte[] writeString = StringToSendBytes.bytesToSend(Before_WriteString + "\n");
                    GobalSerialPort.WriteByMessage(writeString, 0, writeString.Length);
                    Thread.Sleep(400);
                }
                //ReadValue();
                DataTable SaveTable = DatagridviewTodatatble(dataGridView1);
                DataTable SaveTable2 = SwapDTCR(SaveTable);
                ResultDatatable = FinalDatatable(SaveTable2);
                //设置定时任务
                GobalSerialPort.SerialPort.DataReceived -= new SerialDataReceivedEventHandler(GobalSerialPort.SerialportMessage_DataReceived);
                GobalSerialPort.SerialPort.DataReceived += new SerialDataReceivedEventHandler(measure_DataReceivedByMeasure);
                MeasureTimer measureTimer = new MeasureTimer(200);
            }
            catch (Exception e) {
                log.Info("double measure is error : " + e.Message);
            }
        }

       
        private void 测量保存_Click(object sender, EventArgs e)
        {
            SaveMFlage = true;
            if (!EcuConnectionF.ECULINKStatus1)
            {
                MessageBox.Show("串口未连接！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //测量数据
            if (measureflag) 
            {
                this.button7.Text = "停止测量";
                if (this.dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("请插入测量参数！", "信息提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.dataGridView1.CurrentRow != null && this.dataGridView1.Rows.Count >= 21)
                {
                    MessageBox.Show("连续测量一次最多20个，请请删除部分参数！", "信息提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (this.dataGridView1.CurrentRow != null && this.dataGridView1.Rows.Count < 21)
                {
                    measureflag = false;
                    SaveFileDialog fileDialog = new SaveFileDialog();
                    fileDialog.RestoreDirectory = true;
                    fileDialog.Title = "导出Excel";
                    fileDialog.Filter = "Excel文件(*.xls)|*.xls|(*.xlsx)|*.xlsx";
                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                         excelFilePath = fileDialog.FileName;
                         Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();                       
                         workbook.Save(excelFilePath);
                    }

                    new Thread(DoubleMeasure).Start();
                }
            }
            else   //停止测量数据
            {

                //时间和传递的行数；
                CountTime = 200;
                TotalTime = 0;             
                measureflag = true;

                MeasureTimer.TimeDispose();

                GobalSerialPort.SerialPort.DataReceived -= new SerialDataReceivedEventHandler(measure_DataReceivedByMeasure);

                GobalSerialPort.SerialPort.DataReceived += new SerialDataReceivedEventHandler(GobalSerialPort.SerialportMessage_DataReceived);

                Thread t1 = new Thread(new ParameterizedThreadStart(SynOpenExeclWorkbook));
                t1.Start(excelFilePath);

               // new Thread(ClearDelay).Start();

               // GobalSerialPort.WriteByMessage(CommonCmd.ATR, 0, CommonCmd.ATR.Length);
                EcuConnectionF ecuConnectionF = new EcuConnectionF();
                ecuConnectionF.ConnectEucByWait();

                //  new Thread(ClearDelay).Start();               
                GobalSerialPort.ClearSendAndRecive();
                GobalSerialPort.Write(CommonCmd.ClearCmd, 0, CommonCmd.ClearCmd.Length);
                Thread.Sleep(1500);

               // Thread.Sleep(2000);

                this.button7.Text = "测量保存";

                return;
            }

        }

     



        private void 删除选中的列表(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 0)
            {
                int i = this.dataGridView1.CurrentRow.Index;
                if (i < dataGridView1.Rows.Count - 1)
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                }
                else
                {
                    MessageBox.Show("操作错误！！！");
                }
            }
        }


        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 导出_Click(object sender, EventArgs e)
        {
            string AppPath = System.Windows.Forms.Application.StartupPath;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = " ini files(*.ini)|*.ini|All files(*.*)|*.*";
            saveFileDialog.InitialDirectory = AppPath;
            saveFileDialog.Title = "保存为配置文件";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string Address = saveFileDialog.FileName;
                StreamWriter sw = new StreamWriter(Address, false);
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    string s = dataGridView1.Rows[i].Cells[0].Value.ToString() + "\n";
                    sw.WriteLine(s);
                }
                sw.Flush();
                sw.Close();
            }
        }
    
        private void 导入_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            string AppPath = System.Windows.Forms.Application.StartupPath;
            OpenFileDialog openfileDialog = new OpenFileDialog();
            openfileDialog.Filter = " ini files(*.ini)|*.ini|All files(*.*)|*.*";
            openfileDialog.InitialDirectory = AppPath;
            openfileDialog.Title = "导入配置文件";
            if (openfileDialog.ShowDialog() == DialogResult.OK)
            {
                string importString = "";
                string fname = openfileDialog.FileName;
                StreamReader sr = new StreamReader(fname);
                while (sr.Peek() >= 0)
                {
                    importString = sr.ReadLine();
                    if (importString != "")
                    {
                        if (CompareSelText(importString))
                        {
                            importOldText(importString);
                        }
                    }
                }
                sr.Close();
            }
        }

        private void importOldText(string importString)
        {

            if (EcuAddressTable!=null) {
                select = "SELECT * FROM " + EcuAddressTable + " where name='" + importString + "'";
                da = new OleDbDataAdapter(select, con);
                ds = new DataSet();
                da.Fill(ds, "Table1_1");
                foreach (DataRow row in ds.Tables["Table1_1"].Rows)
                {
                    int index = this.dataGridView1.Rows.Add();
                    dr = dataGridView1.Rows[index];
                    dr.Cells[0].Value = row[0];
                    dr.Cells[1].Value = row[3];
                    dr.Cells[2].Value = row[1];
                    dr.Cells[3].Value = row[2];          //Decription..
                    dr.Cells[4].Value = row[4];
                    dr.Cells[5].Value = row[5];
                    dr.Cells[6].Value = row[6];
                    dr.Cells[7].Value = row[7];
                }
            }
        }


        private void 上移(object sender, EventArgs e)
        {

            upOrdown("up");

        }

        private void 下移(object sender, EventArgs e)
        {

            upOrdown("down");

        }

        //方法 上移 下移 删除   
        //dGVshowProcess   是一个DataGridView
        private void upOrdown(string type)
        {
            if (this.dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请选择要需要操作的工序所在行");
            }
            else if (type == "up")       ////////////////向上移动
            {
                if (this.dataGridView1.CurrentRow.Index <= 0)
                {
                    MessageBox.Show("此工序已在顶端，不能再上移！");
                }
                else
                {
                    System.Data.DataTable nowDatatable = new System.Data.DataTable();

                    int nowIndex = this.dataGridView1.CurrentRow.Index;
                    nowDatatable = this.DatagridviewTodatatble(dataGridView1);
                    object[] _rowData = nowDatatable.Rows[nowIndex].ItemArray;
                    nowDatatable.Rows[nowIndex].ItemArray = (nowDatatable).Rows[nowIndex - 1].ItemArray;
                    (nowDatatable).Rows[nowIndex - 1].ItemArray = _rowData;
                    DatatabletoDataGridview(nowDatatable);
                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[nowIndex - 1].Cells[0];//设定当前行
                    // dataGridView1.Refresh();
                }
            }
            else if (type == "down")         //////////////////向下移动
            {
                if (this.dataGridView1.CurrentRow.Index > this.dataGridView1.Rows.Count - 3)
                {
                    MessageBox.Show("此工序已在底端，不能再下移！");
                }
                else
                {
                    int nowIndex = this.dataGridView1.CurrentRow.Index;
                    System.Data.DataTable nowDatatable = new System.Data.DataTable();
                    nowDatatable = this.DatagridviewTodatatble(dataGridView1);

                    object[] _rowData = (nowDatatable).Rows[nowIndex].ItemArray;
                    (nowDatatable).Rows[nowIndex].ItemArray = (nowDatatable).Rows[nowIndex + 1].ItemArray;
                    (nowDatatable).Rows[nowIndex + 1].ItemArray = _rowData;
                    DatatabletoDataGridview(nowDatatable);
                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[nowIndex + 1].Cells[0];//设定当前行
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
