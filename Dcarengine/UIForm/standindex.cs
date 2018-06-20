using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dcarengine.refactor;
using Dcarengine.serialPort;
using Dcarengine.Function_Class;
using Dcarengine.entity;
using System.Threading;
using Dcarengine.common;

namespace Dcarengine.UIForm
{
    public partial class standindex : Form
    {

        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public standindex()
        {
            InitializeComponent();
        }

        /// <summary>
        /// laod读取数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void standindex_Load(object sender, EventArgs e)
        {
            Thread tWorkingThread = null;
            try {

                tWorkingThread  = new Thread(isConnet);
                tWorkingThread.Start();

            } catch(Exception ){

                tWorkingThread.Abort();
            }

        }


        /// <summary>
        /// 
        /// </summary>
        public void isConnet() {

            while (true) {

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

                byte[] _210214 = StringToSendBytes.bytesToSend("210214\n");
                GobalSerialPort.WriteByMessage(_210214, 0, _210214.Length);
                String result214 = GobalSerialPort.ResultBackString;
                String[] result14A = result214.Split('\r');
                result214 = result14A[1].Replace(" ", "");

                byte[] _210215 = StringToSendBytes.bytesToSend("210215\n");
                GobalSerialPort.WriteByMessage(_210215, 0, _210215.Length);
                String result215 = GobalSerialPort.ResultBackString;
                String[] result15A = result215.Split('\r');
                result215 = result15A[1].Replace(" ", "");

                byte[] _210241 = StringToSendBytes.bytesToSend("210241\n");
                GobalSerialPort.WriteByMessage(_210241, 0, _210241.Length);
                String result210241 = GobalSerialPort.ResultBackString;
                String[] result210241A = result210241.Split('\r');
                result210241 = result210241A[1].Replace(" ", "");

                byte[] _210240 = StringToSendBytes.bytesToSend("210240\n");
                GobalSerialPort.WriteByMessage(_210240, 0, _210240.Length);
                String result210240 = GobalSerialPort.ResultBackString;
                String[] result210240A = result210240.Split('\r');
                result210240 = result210240A[1].Replace(" ", "");

                //展示数据格式
                show(result213, result214, result215, result210241, result210240);

                //mode 1086
                log.Info("ECUMODE  1086 " + " ");
                CommonConstant.mode = "1086";
                Tp_KeyMethodFuntion.Con();
                GobalSerialPort.WriteByMessage(CommonCmd._1086, 0, CommonCmd._1086.Length);
                String backString = GobalSerialPort.ResultBackString;
                if (!backString.Contains("86"))
                {
                    GobalSerialPort.WriteByMessage(CommonCmd._1086, 0, CommonCmd._1086.Length);
                    backString = GobalSerialPort.ResultBackString;
                }
                else
                {
                    GobalSerialPort.WriteByMessage(CommonCmd.ATST00, 0, CommonCmd.ATST00.Length);
                    //write 
                    String tl718code = result214.Substring(8 + 89 * 2, 12);
                    String time = result214.Substring(8 + 96 * 2, 8);
                    result214.Replace(tl718code, "0000" + CommonConstant.TL718CODE);
                    result214.Replace(time, DateUtil.getDate());
                    String address = "3b0214" + result214.Substring(8, 200);
                    byte[] cmdSend = StringToSendBytes.bytesToSend(address + "\n");
                    GobalSerialPort.WriteByMessage(cmdSend, 0, cmdSend.Length);
                    String result = GobalSerialPort.ResultBackString;
                    //if () {
                    //}
                    GobalSerialPort.WriteByMessage(CommonCmd.ATST0F, 0, CommonCmd.ATST0F.Length);
                    GobalSerialPort.WriteByMessage(CommonCmd._1081,0,CommonCmd._1081.Length);
                }


            }
            catch(IndexOutOfRangeException)
            {

                byte[] _210213 = StringToSendBytes.bytesToSend("210213\n");
                GobalSerialPort.WriteByMessage(_210213, 0, _210213.Length);
                String result213 = GobalSerialPort.ResultBackString;
                String[] resultA = result213.Split('\r');
                result213 = resultA[1].Replace(" ", "");

                byte[] _210214 = StringToSendBytes.bytesToSend("210214\n");
                GobalSerialPort.WriteByMessage(_210214, 0, _210214.Length);
                String result214 = GobalSerialPort.ResultBackString;
                String[] result14A = result214.Split('\r');
                result214 = result14A[1].Replace(" ", "");

                byte[] _210215 = StringToSendBytes.bytesToSend("210215\n");
                GobalSerialPort.WriteByMessage(_210215, 0, _210215.Length);
                String result215 = GobalSerialPort.ResultBackString;
                String[] result15A = result215.Split('\r');
                result215 = result15A[1].Replace(" ", "");

                byte[] _210241 = StringToSendBytes.bytesToSend("210241\n");
                GobalSerialPort.WriteByMessage(_210241, 0, _210241.Length);
                String result210241 = GobalSerialPort.ResultBackString;
                String[] result210241A = result210241.Split('\r');
                result210241 = result210241A[1].Replace(" ", "");

                byte[] _210240 = StringToSendBytes.bytesToSend("210240\n");
                GobalSerialPort.WriteByMessage(_210240, 0, _210240.Length);
                String result210240 = GobalSerialPort.ResultBackString;
                String[] result210240A = result210240.Split('\r');
                result210240 = result210240A[1].Replace(" ", "");

                show(result213, result214, result215, result210241, result210240);
            }
            catch (Exception ) {

            }
            finally
            {


                // return null;
            }
        }


        /// <summary>
        /// show 
        /// </summary>
        /// <param name="result213"></param>
        /// <param name="result214"></param>
        /// <param name="result215"></param>
        public  void show(String result213,String result214 ,String result215,String result02141,String result210240)
        {

            try
            {
                String xinhao = result213.Substring(8 + 35 * 2, 28);
                String xinhaoTex = StringUtil.StringToASCII(xinhao);
                log.Info(xinhaoTex);
                this.Invoke((EventHandler)delegate { this.textBox1.Text = xinhaoTex; });

                ///序列号
                String xuliehao = result214.Substring(8 + 20 * 2, 30);
                String xuliehaoTex = StringUtil.StringToASCII(xuliehao);
                log.Info(xuliehaoTex);
                this.Invoke((EventHandler)delegate { this.textBox2.Text = xuliehaoTex; });

                ///零件号
                String lingjianhao = result214.Substring(8 + 66 * 2, 30);
                String lingjianhaoTex = StringUtil.StringToASCII(lingjianhao);
                this.Invoke((EventHandler)delegate { this.textBox3.Text = lingjianhaoTex; });
                log.Info(lingjianhaoTex);

                ///dis
                String Dis号 = result213.Substring(8 + 85 * 2, 20);
                String Dis号Tex = StringUtil.StringToASCII(Dis号);
                this.Invoke((EventHandler)delegate { this.textBox4.Text = Dis号Tex; });
                log.Info(lingjianhaoTex);


                ///CALID 标识
                String calid号 = result02141.Substring(6 + 0 * 2, 32);
                String calid号Tex = StringUtil.StringToASCII(calid号);
                this.Invoke((EventHandler)delegate { this.textBox5.Text = calid号Tex; });
                log.Info(calid号);


                ///sfheol
                String SFHEOL号 = result213.Substring(8 + 0 * 2, 8);
                //String SFHEOL号Tex = StringUtil.StringToASCII(SFHEOL号);
                this.Invoke((EventHandler)delegate { this.textBox6.Text = SFHEOL号; });
                log.Info(SFHEOL号);


                ///
                String SFH售后诊断工具号 = result214.Substring(8 + 89 * 2, 12);
                String SFH售后诊断工具号Tex = StringUtil.StringToASCII(SFH售后诊断工具号);
                this.Invoke((EventHandler)delegate { this.textBox7.Text = SFH售后诊断工具号Tex; });

                ///
                String SFH售后诊断工具测试时间 = result214.Substring(8 + 96 * 2, 8);
                //String SFH售后诊断工具测试时间Tex = StringUtil.StringToASCII(SFH售后诊断工具测试时间);
                this.Invoke((EventHandler)delegate { this.textBox8.Text = SFH售后诊断工具测试时间; });

                ///
                String SIHEOL刷写时间 = result213.Substring(8 + 0 * 2, 8);
                //String SIHEOL刷写时间Tex = StringUtil.StringToASCII(SIHEOL刷写时间);
                this.Invoke((EventHandler)delegate { this.textBox17.Text = SIHEOL刷写时间; });


                ///
                String SIH售后诊断工具号 = result214.Substring(8 + 89 * 2, 12);
                String SIH售后诊断工具号Tex = StringUtil.StringToASCII(SIH售后诊断工具号);
                this.Invoke((EventHandler)delegate { this.textBox9.Text = SIH售后诊断工具号Tex; });


                ///
                String SIH售后诊断工具测试时间 = result213.Substring(8 + 95 * 2, 10);
                //String SIH售后诊断工具号Tex = StringUtil.StringToASCII(SIH售后诊断工具测试时间);
                this.Invoke((EventHandler)delegate { this.textBox10.Text = SIH售后诊断工具测试时间; });

                ///
                String 其他客户EOL工具号 = result213.Substring(8 + 80 * 2, 10);
                String 其他客户EOL工具号Tex = StringUtil.StringToASCII(其他客户EOL工具号);
                this.Invoke((EventHandler)delegate { this.textBox11.Text = 其他客户EOL工具号Tex; });

                ///
                String 其他客户EOL刷写时间 = result215.Substring(8 + 86 * 2, 8);
                //String 其他客户EOL刷写时间Tex = StringUtil.StringToASCII(其他客户EOL刷写时间);
                this.Invoke((EventHandler)delegate { this.textBox12.Text = 其他客户EOL刷写时间; });

                ///
                String 其他客户售后诊断工具号 = result215.Substring(8 + 90 * 2, 10);
                String 其他客户售后诊断工具号Tex = StringUtil.StringToASCII(其他客户售后诊断工具号);
                this.Invoke((EventHandler)delegate { this.textBox13.Text = 其他客户售后诊断工具号Tex; });

                ///
                String 其他客户售后诊断工具测试时间 = result215.Substring(8 + 96 * 2, 8);
                // String 其他客户售后诊断工具测试时间Tex = StringUtil.StringToASCII(其他客户售后诊断工具测试时间);
                this.Invoke((EventHandler)delegate { this.textBox14.Text = 其他客户售后诊断工具测试时间; });

                String 车辆VAN = result213.Substring(8 + 51 * 2, 18);
                String 车辆VANTex = StringUtil.StringToASCII(车辆VAN);
                this.Invoke((EventHandler)delegate { this.textBox15.Text = 车辆VANTex; });

                ///VIN 标识
                String VIN = result210240.Substring(6 + 0 * 2, 32);
                String VINTEXT = StringUtil.StringToASCII(VIN);
                this.Invoke((EventHandler)delegate { this.textBox16.Text = VINTEXT; });
                log.Info(calid号);
            }
            catch {

            }
        }




    }
}
