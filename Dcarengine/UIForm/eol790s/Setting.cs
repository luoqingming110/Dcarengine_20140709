using Dcarengine.Function_Class;
using Dcarengine.refactor;
using Dcarengine.serialPort;
using EASkins;
using EASkins.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace Dcarengine.UIForm.eol790s
{
    public partial class Setting : EASkins.Controls.MaterialForm
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static String address = "024F80";
        private static Int32 length = 4;
        private static String NOTACTIVE = "未激活";
        private static String ACTIVE = "激活";

        //最终数据读取
        private static String resultValue;
        private static String resultText;
        private static int prorcess_value = 0;
        private static String ars_write_value = "";
        private static String speed_write_value = "";
        //private static String vin_write_value = "";
        private static String ep_vin_write_value = "";
        private static String calid_write_value = "";

        private readonly MaterialSkinManager materialSkinManager;

        delegate void update_textBox_Delegate(string obj);

        delegate void update_checkBox_Delegate(bool boll);
        /// <summary>
        /// 更新状态栏的文字，多线程时被委托调用
        /// </summary>
        /// <param name="text"></param>
        private void updateStatusWordInDelegate(string text)
        {
            this.calid_CheckBox4.Text = text;
        }
        /// <summary>
        /// 更新状态栏的文字，多线程时被委托调用
        /// </summary>
        /// <param name="text"></param>
        private void updateStatusWordInDelegate(bool boll)
        {
            this.calid_CheckBox4.Checked = boll;
        }

        private void updateStatusWordInThread(string text)
        {
            update_textBox_Delegate d = new update_textBox_Delegate(updateStatusWordInDelegate);
            this.calid_textBox1.Invoke(d, text);
        }

        private void updateStatusThread(bool text)
        {
            update_checkBox_Delegate d = new update_checkBox_Delegate(updateStatusWordInDelegate);
            this.calid_CheckBox4.Invoke(d, text);
        }

        public Setting()
        {
            InitializeComponent();
            this.backgroundWorker1.WorkerReportsProgress = true;  //设置能报告进度更新
            this.backgroundWorker1.WorkerSupportsCancellation = true;  //设置支持异步取消

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey200, Primary.BlueGrey200, Primary.BlueGrey200,
                Accent.LightBlue200, TextShade.WHITE);


        }


        private void ARS790_Load(object sender, EventArgs e)
        {
            if (!StringUtil.IsStringEmpty(CommonConstant.dic_code))
            {

                String caild = JsonOp.readJson(CommonConstant.dic_code);
                this.calid_textBox1.Invoke(new EventHandler(delegate { this.calid_textBox1.Text = caild; }));
                this.calid_CheckBox4.Invoke(new EventHandler(delegate { this.calid_CheckBox4.Checked = true; }));
            }

            if (EcuConnectionF.ECULINKStatus == true)
            {
                this.ucSignalLamp1.LampColor = new Color[] { Color.FromArgb(0, 255, 0) };
                // read();

            }
        }

        public void read()
        {

            String value = EolFunction.readFunction(address, length, CommonCmd._808002);
            //初始化数据
            try
            {
                String[] valueList = value.Split('\r');
                //finalValue
                String finalValue = valueList[1].Replace(" ", "");
                //高低位
                String finalValueOne = finalValue.Substring(0, 2);
                String finalValueTwo = finalValue.Substring(2, 2);
                String finalValueThree = finalValue.Substring(4, 2);
                String finalValueFour = finalValue.Substring(6, 2);
                finalValue = finalValueFour + finalValueThree + finalValueTwo + finalValueOne;
                resultValue = finalValue;
                // status
                String status = StringUtil.hexTo2(finalValue);
                if (StringUtil.IsStringEmpty(status))
                {
                    ars_status.Text = "读取失败";
                    retarder_status.Text = "读取失败";
                    return;
                }
                String ars = status.Substring(31, 1);
                if (ars.Equals("0"))
                {
                    this.ars_status.Text = "未激活";
                }
                else
                {
                    this.ars_status.Text = "激活";
                }
                String retarder = status.Substring(28, 1);
                if (retarder.Equals("0"))
                {
                    this.retarder_status.Text = "未激活";
                }
                else
                {
                    this.retarder_status.Text = "激活";
                }
            }
            catch (Exception)
            {
            }
        }


        private void ami_Button_22_Click_1(object sender, EventArgs e)
        {

            if (EcuConnectionF.ECULINKStatus == false)
            {
                return;
            }
            if (!ars_CheckBox1.Checked
                && !retarder_CheckBox2.Checked
                && !speed_CheckBox3.Checked
                && !emvin_CheckBox3.Checked
                && !calid_CheckBox4.Checked
                )
            {

                return;
            }


            if (ars_CheckBox1.Checked || retarder_CheckBox2.Checked)
            {

            }
            //epvin
            if (emvin_CheckBox3.Checked)
            {
                String text = this.ep_vin_textBox1.Text;
                if (StringUtil.IsStringEmpty(text) && text.Length != 17)
                {
                    MessageBox.Show("Vin 数值长度不为17");
                    return;
                }
                String asciiToWrite = StringUtil.AsciiToHexString(text.Trim());
                ep_vin_write_value = asciiToWrite;
            }
            //calid
            if (calid_CheckBox4.Checked)
            {
                String text = this.calid_textBox1.Text;
                if (StringUtil.IsStringEmpty(text) && text.Length != 12)
                {
                    return;
                }
            }
            //speed
            if (this.speed_CheckBox3.Checked)
            {

                String text = this.speed_textBox1.Text;
                if (StringUtil.IsStringEmpty(text))
                {
                    MessageBox.Show("速度值不能为空");
                    return;
                }
                int value = Int32.Parse(text) * 100;
                String speed = StringUtil._10ToHex(value).PadLeft(4, '0');
                if (speed.Length > 4)
                {
                    MessageBox.Show("速度值超过临界值");
                    return;
                }
                String finalValueOne = speed.Substring(0, 2);
                String finalValueTwo = speed.Substring(2, 2);
                speed = finalValueTwo + finalValueOne;

                speed_write_value = speed;
            }
            //vin
            //if (vin_CheckBox4.Checked)
            //{
            //    try
            //    {
            //        String text = this.vin_textBox1.Text;
            //        if (StringUtil.IsStringEmpty(text) && text.Length != 17)
            //        {
            //            MessageBox.Show("Vin 数值长度不为17,请输入!");
            //            this.vin_textBox1.Focus();
            //            return;
            //        }
            //        String asciiToWrite = StringUtil.AsciiToHexString(text.Trim());
            //        vin_write_value = asciiToWrite;
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}

            backgroundWorker1.RunWorkerAsync();  //运行backgroundWorker组件
            写入进度 form = new 写入进度(this.backgroundWorker1);  //显示进度条窗体
            form.ShowDialog(this);
        }

        //在另一个线程上开始运行(处理进度条)
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (worker.CancellationPending) //获取程序是否已请求取消后台操作
            {
                e.Cancel = true;
                return;
            }

            if (this.calid_CheckBox4.Checked || this.emvin_CheckBox3.Checked)
            {
                CommonConstant.mode = "1086";
                Tp_KeyMethodFuntion.Con();
                GobalSerialPort.WriteByMessage(CommonCmd._1086, 0, CommonCmd._1086.Length);
            }
            String result = GobalSerialPort.ResultBackString;

            //emvin
            if (this.emvin_CheckBox3.Checked)
            {
                String cmd = "3b0240";
                String asciiToWrite = ep_vin_write_value;
                byte[] cmdSend = StringToSendBytes.bytesToSend(cmd + ep_vin_write_value + "\n");
                GobalSerialPort.WriteByMessage(cmdSend, 0, cmdSend.Length);
                if (result.Contains("7B"))
                {
                }
                worker.ReportProgress(10);
            }
            //calid
            if (this.calid_CheckBox4.Checked)
            {
                String calid_cmd = "3b0241";
                String calid = this.calid_textBox1.Text.Trim().PadRight(16, ' ');
                String asciiToWrite_calid = StringUtil.AsciiToHexString(calid);
                byte[] cmdSend_calid = StringToSendBytes.bytesToSend(calid_cmd + asciiToWrite_calid + "\n");
                GobalSerialPort.WriteByMessage(cmdSend_calid, 0, cmdSend_calid.Length);
                result = GobalSerialPort.ResultBackString;
                if (result.Contains("7B"))
                {
                }
                worker.ReportProgress(20);
            }

            if ( this.speed_CheckBox3.Checked
                || this.retarder_CheckBox2.Checked || this.ars_CheckBox1.Checked)
            {

                CommonConstant.mode = "1090";
                Tp_KeyMethodFuntion.Con();
                GobalSerialPort.WriteByMessage(CommonCmd._1090, 0, CommonCmd._1090.Length);
                String backString = GobalSerialPort.ResultBackString;
                if (backString.Contains("10") || backString.Contains("78"))
                {

                    Thread.Sleep(2000);
                }
                EolFunction.writeF_8081count(CommonCmd._808102);
            }
            worker.ReportProgress(30);

            if (this.ars_CheckBox1.Checked || this.retarder_CheckBox2.Checked)
            {
                read();
                if (ars_CheckBox1.Checked)
                {
                    try
                    {
                        String text = this.ars_ComboBox1.Text;
                        String status = StringUtil.hexTo2(resultValue);
                        String staprefix = status.Substring(0, 31);
                        String stasuffix = status.Substring(0, 31);
                        String stafinal = "";
                        if (text.Equals(NOTACTIVE))
                        {
                            stafinal = stasuffix + "0";
                        }
                        else if (text.Equals(ACTIVE))
                        {
                            stafinal = stasuffix + "1";
                        }
                        stafinal = StringUtil._2ToHex(stafinal).PadLeft(8, '0');
                        resultValue = stafinal;
                    }
                    catch (Exception) { }
                }
                if (retarder_CheckBox2.Checked)
                {
                    try
                    {
                        String status = StringUtil.hexTo2(resultValue);
                        String retarder_text = this.retarder_ComboBox2.Text;
                        String staprefix = status.Substring(0, 28);
                        String stasuffix = status.Substring(28 + 1, status.Length - 29);
                        String stafinal = "";
                        if (retarder_text.Equals(NOTACTIVE))
                        {
                            stafinal = staprefix + "0" + stasuffix;
                        }
                        else if (retarder_text.Equals(ACTIVE))
                        {
                            stafinal = staprefix + "1" + stasuffix;
                        }
                        stafinal = StringUtil._2ToHex(stafinal).PadLeft(8, '0');
                        resultValue = stafinal;
                    }
                    catch (Exception) { }
                }

                try
                {
                    //高低位
                    String finalValueOne = resultValue.Substring(0, 2);
                    String finalValueTwo = resultValue.Substring(2, 2);
                    String finalValueThree = resultValue.Substring(4, 2);
                    String finalValueFour = resultValue.Substring(6, 2);
                    String stafinal = finalValueFour + finalValueThree + finalValueTwo + finalValueOne;
                    ars_write_value = stafinal;
                }
                catch { }

                EolFunction.writeFunction(EolFunction.ars_address, EolFunction.ars_length, ars_write_value, CommonCmd._808102);
                worker.ReportProgress(40);
            }

            if (this.speed_CheckBox3.Checked)
            {
                EolFunction.writeFunction(EolFunction.speed_address, EolFunction.speed_length, speed_write_value, CommonCmd._808102);
                worker.ReportProgress(50);
            }
            worker.ReportProgress(50);

            if (this.emvin_CheckBox3.Checked)
            {
                EolFunction.writeFunction(EolFunction.vin_address, EolFunction.vin_length, ep_vin_write_value, CommonCmd._808102);
                worker.ReportProgress(60);
            }

            if (this.emvin_CheckBox3.Checked || this.speed_CheckBox3.Checked
               || this.retarder_CheckBox2.Checked || this.ars_CheckBox1.Checked)
            {
                EolFunction.writeF_3180(CommonCmd._3180);
                worker.ReportProgress(80);

                EolFunction.writeF_3380_ByTime(CommonCmd._3380);
                worker.ReportProgress(95);
            }
            worker.ReportProgress(95);
            GobalSerialPort.WriteByMessage(CommonCmd._1101, 0, CommonCmd._1101.Length); 
            worker.ReportProgress(100);
            //
            //
            //255, 77, 59
            this.ucSignalLamp1.LampColor = new Color[] { Color.FromArgb(255, 77, 59) };
            EcuConnectionF.ECULINKStatus1 = false;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("取消");
            }
            else
            {
                MessageBox.Show("完成");
            }
        }

        //vin_rich
        //private void vin_text_changed(object sender, EventArgs e)
        //{


        //    if (this.vin_textBox1.Text.Length > 0)
        //    {

        //        this.vin_CheckBox4.Checked = true;
        //    }
        //    else
        //    {

        //        this.vin_CheckBox4.Checked = false;
        //    }
        //}

        //emvin
        private void ep_vin_text_changed(object sender, EventArgs e)
        {


            if (this.ep_vin_textBox1.Text.Length > 0)
            {

                this.emvin_CheckBox3.Checked = true;
            }
            else
            {

                this.emvin_CheckBox3.Checked = false;
            }

        }

        //calid
        private void calid_text_changed(object sender, EventArgs e)
        {

            if (this.calid_textBox1.Text.Length > 0)
            {

                this.calid_CheckBox4.Checked = true;
            }
            else
            {

                this.calid_CheckBox4.Checked = false;
            }

        }

        //speed
        private void speed_text_changed(object sender, EventArgs e)
        {

            if (this.speed_textBox1.Text.Length > 0)
            {

                this.speed_CheckBox3.Checked = true;
            }
            else
            {

                this.speed_CheckBox3.Checked = false;
            }
        }

        //text
        private void retarder_text_changed(object sender, EventArgs e)
        {

            if (!this.retarder_ComboBox2.Text.Equals("未选择"))
            {

                this.retarder_CheckBox2.Checked = true;
            }
            if (this.retarder_ComboBox2.Text.Equals("未选择"))
            {

                this.retarder_CheckBox2.Checked = false;
            }
        }

        //ars
        private void ars_text_changed(object sender, EventArgs e)
        {

            if (!this.ars_ComboBox1.Text.Equals("未选择"))
            {

                this.ars_CheckBox1.Checked = true;
            }
            if (this.ars_ComboBox1.Text.Equals("未选择"))
            {

                this.ars_CheckBox1.Checked = false;
            }
        }


        /**
         * 重新连接 
         */
        private void conect_Button_21_Click(object sender, EventArgs e)
        {
            EcuConnectionF.is_main_load = false;

            if (EcuConnectionF.ECULINKStatus1)
            {
                return;
            }
            else
            {

                try
                {
                    GobalSerialPort.initGobalSerialPort();
                    if (!GobalSerialPort.SerialPort.IsOpen)
                    {
                        GobalSerialPort.SerialPort.Close();
                        GobalSerialPort.SerialPort.Open();
                    }
                    ThreadEcuConnet();
                }
                catch (Exception ex)
                {
                    log.Info("连接" + ex.Message);
                    ThreadEcuConnet();
                }
            }
        }

        private void ThreadEcuConnet()
        {
            //update_textBox_Delegate d = new update_textBox_Delegate(updateStatusWordInDelegate);
            //update_checkBox_Delegate ud = new update_checkBox_Delegate(updateStatusWordInDelegate);

            EcuConnectionF ecuConnectionF = new EcuConnectionF();
            String Threadname = Thread.CurrentThread.Name;
            int id = Thread.CurrentThread.ManagedThreadId;
            Thread tWorkingThread = new Thread(ConnectEucByWaitThread);
            tWorkingThread.Start();

            //Thread read = new Thread((readDis));
            //read.Start();
            //read.Join();
            // readDis();
        }




        /***
         * readDis
         * 
         * **/
        private void readDis()
        {

            while (true)
            {
                if (EcuConnectionF.ECULINKStatus == true)
                {
                    break;
                }
            }
            try
            {

                byte[] _210213 = StringToSendBytes.bytesToSend("210213\n");
                GobalSerialPort.WriteByMessage(_210213, 0, _210213.Length);
                String result213 = GobalSerialPort.ResultBackString;
                String[] resultA = result213.Split('\r');
                result213 = resultA[1].Replace(" ", "");
                ///dis
                String Dis号 = result213.Substring(8 + 85 * 2, 20);
                String Dis号Tex = StringUtil.StringToASCII(Dis号);
                String caild = JsonOp.readJson(Dis号Tex);

                // updateStatusWordInThread(caild);
                //updateStatusThread(true);
                this.calid_CheckBox4.Checked = true;
                this.calid_textBox1.Text = caild;
                //this.calid_textBox1.Invoke(new EventHandler(delegate { this.calid_textBox1.Text = caild; }));
                //this.calid_CheckBox4.Invoke(new EventHandler(delegate { this.calid_CheckBox4.Checked = true; }));
                log.Info("dis code is ");

            }
            catch (Exception) { }
        }


        /// <summary>
        /// 连接ECU 通过获取锁模式
        /// </summary>
        public void ConnectEucByWaitThread()
        {
            if (GobalSerialPort.SerialPort.IsOpen == false)
            {
                return;
            }

            EcuConnectionF.ClearSendAndRecive();

            String backEndString = null;

            CommonCmd.SendATE1();
            // GobalSerialPort.GobalSerialPortEnventChange();
            // 718 code
            GobalSerialPort.WriteByMessage(EcuConnectionF._AT2S, 0, EcuConnectionF._AT2S.Length);
            backEndString = GobalSerialPort.ResultBackString;
            CommonConstant.TL718CODE = backEndString;

            bool flag = false;
            foreach (string num in CommonConstant.TL718List)
            {
                if (backEndString.Contains(num))
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                MessageBox.Show("设备不匹配");
                return;
            }
            GobalSerialPort.WriteByMessage(CommonCmd.ATSP5, 0, CommonCmd.ATSP5.Length);             ////////读取718芯片
            backEndString = GobalSerialPort.ResultBackString;
            if (backEndString.Contains("OK"))
            {
                GobalSerialPort.WriteByMessage(CommonCmd.ATST0F, 0, CommonCmd.ATST0F.Length); //2
            }

            backEndString = GobalSerialPort.ResultBackString;
            if (backEndString.Contains("OK"))
            {
                GobalSerialPort.WriteByMessage(CommonCmd.ATSW19, 0, CommonCmd.ATSW19.Length);      //22222/           ////333333
            }
            backEndString = GobalSerialPort.ResultBackString;
            if (backEndString.Contains("OK"))
            {
                GobalSerialPort.WriteByMessage(CommonCmd.ATSH81_10_F1, 0, CommonCmd.ATSH81_10_F1.Length);
            }
            backEndString = GobalSerialPort.ResultBackString;
            if (backEndString.Contains("OK"))
            {
                GobalSerialPort.WriteByMessage(CommonCmd._1081, 0, CommonCmd._1081.Length);                              ////////////5
                //连接处可能需要特殊处理
            }

            backEndString = GobalSerialPort.ResultBackString;

            if (backEndString.Contains("50") && backEndString.Contains("81"))
            {
                EcuConnectionF.ECULINKStatus = true;
            }
            else
            {
                EcuConnectionF.ECULINKStatus = false;
            }
            MainF.EcuIsLinked = EcuConnectionF.ECULINKStatus1;

            if (EcuConnectionF.ECULINKStatus)
            {
                EcuVersionF.GetEcuVersion();

                byte[] _210213 = StringToSendBytes.bytesToSend("210213\n");
                GobalSerialPort.WriteByMessage(_210213, 0, _210213.Length);
                String result213 = GobalSerialPort.ResultBackString;
                String[] resultA = result213.Split('\r');
                result213 = resultA[1].Replace(" ", "");
                ///dis
                String Dis号 = result213.Substring(8 + 85 * 2, 20);
                String Dis号Tex = StringUtil.StringToASCII(Dis号);
                String caild = JsonOp.readJson(Dis号Tex);
                this.ucSignalLamp1.LampColor = new Color[] { Color.FromArgb(0, 255, 0) };
                this.calid_textBox1.Invoke(new EventHandler(delegate { this.calid_textBox1.Text = caild; }));
                this.calid_CheckBox4.Invoke(new EventHandler(delegate { this.calid_CheckBox4.Checked = true; }));
                log.Info("dis code is ");
            }
            // updateStatusWordInThread(caild);
            //updateStatusThread(true);
            //this.calid_CheckBox4.Checked = true;
            //this.calid_textBox1.Text = caild;
        }

        private void ucSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void verificationComponent1_Verificationed(HZH_Controls.Controls.VerificationEventArgs e)
        {

        }

    }
}
