using Dcarengine.Function_Class;
using Dcarengine.refactor;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

/// <summary>
/// luoqingming
/// </summary>
namespace Dcarengine.serialPort
{
    /// <summary>
    /// 基础serialPort  持有串口serialPort对象
    /// </summary>
    class GobalSerialPort
    {

        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// 统一串口对象
        /// </summary>
        private static SerialPort gobalserialPort;

        private static String  resultBackString;

   
        /// <summary>
        /// 串口属性
        /// </summary>
        public static SerialPort SerialPort { get => gobalserialPort;
            set => gobalserialPort = value; }


        public static string ResultBackString { get => resultBackString;
            set => resultBackString = value; }


        /// <summary>
        /// 初始化静态串口数据
        /// </summary>
         public static void initGobalSerialPort(){

            gobalserialPort = new SerialPort();

            FindPorts();

            IniSerialport();

            gobalserialPort.DataReceived += new SerialDataReceivedEventHandler(SerialportMessage_DataReceived);//DataReceived事件委托

            
        }

        /// <summary>
        /// 事件绑定改变
        /// </summary>
        public static void GobalSerialPortEnventChange() {

            gobalserialPort.DataReceived += new SerialDataReceivedEventHandler(SerialportMessage_DataReceived);//DataReceived事件委托

            CommonCmd.SendATE1();
        }



        /// <summary>
        /// find Ports
        /// </summary>
        public static void FindPorts()             
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string portName in ports)
            {
                // System.IO.Ports.SerialPort port = new SerialPort(portName);///获得所有串口
                try
                {
                    gobalserialPort.PortName = portName;
                }
                catch
                {
                   // MessageBox.Show("查找串口号失败！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /// <summary>
        /// 初始化串口 基本参数
        /// </summary>
        public static void IniSerialport()
        {

            gobalserialPort.BaudRate = 38400;
            gobalserialPort.DataBits = 8;
            gobalserialPort.StopBits = StopBits.One;
            gobalserialPort.ReceivedBytesThreshold = 1;

        }

        /// <summary>
        /// 打开接口
        /// </summary>
        public static void OpenSerialPort() {

            try
            {
                gobalserialPort.Open();
            }
            catch
            {

            }

        }

        /// <summary>
        /// close prot
        /// </summary>
        public static void CloseSerialPort() {

            try
            {
                gobalserialPort.Close();
            }
            catch {
            }
        }


        public static void Serialport1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //事件有数据会 会锁住数据
                GolbalLock.GobalLockOnce.EnterWriteLock();

                string backString = "";
                while (!(backString.Contains("\r\n\r\n>")))
                {
                    byte[] ReDatas = new byte[gobalserialPort.BytesToRead];//返回命令包
                    gobalserialPort.Read(ReDatas, 0, ReDatas.Length);//读取数据
                    ResultBackString = (System.Text.Encoding.Default.GetString(ReDatas));
                    backString = backString + ResultBackString;
                }
                ResultBackString = backString;
                //赋值 
                GolbalLock.EndData = backString;
                //释放
                GolbalLock.GobalLockOnce.ExitWriteLock();
            }              
            catch (Exception ex)
            {
                GolbalLock.EndData = null;
            }
        }


        /// <summary>
        /// 事件消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SerialportMessage_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                long startTime = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;

                //long startTime = System.DateTime.Now.Millisecond;
                //事件有数据会 会锁住数据                      
                string backString = "";
                while (!(backString.Contains("\r\n\r\n>")))
                {
                    byte[] ReDatas = new byte[gobalserialPort.BytesToRead];//返回命令包
                    gobalserialPort.Read(ReDatas, 0, ReDatas.Length);//读取数据
                    ResultBackString = (System.Text.Encoding.Default.GetString(ReDatas));
                    backString = backString + ResultBackString;
                    long workTime = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
                    if (workTime - startTime > 5000) {
                        backString = "";
                        ClearSendAndRecive();
                        log.Info("revice data from byffer " + ResultBackString + " ;breakTime:" + (workTime - startTime));
                        break;
                    }
                }
                ResultBackString = backString;
                long endTime = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
                //long endTime = System.DateTime.Now.Millisecond;
                log.Info("revice data from byffer " + ResultBackString + " ;workTime:" +
                    (endTime-startTime) + " count:" + CommonAutoRest.AutoResetCount);

              
                CommonAutoRest.MEvent.Set();
                Interlocked.Decrement(ref CommonAutoRest.AutoResetCount);

                ClearSendAndRecive();             
            }
            catch (Exception ex)
            {
                GolbalLock.EndData = null;
                ClearSendAndRecive();
                log.Info("读取串口数据异常"+ ex.Message);
            }
        }



        /// <summary>
        /// 写入数据 Lock模式数据
        /// </summary>
        public static void Write(byte[] buffer, int offset, int count) {

            log.Info("write  message  to buffer : " + StringToSendBytes.ByteToString(buffer));
            gobalserialPort.Write(buffer,offset, count);
           
        }

        /// <summary>
        /// 写入数据 Lock模式数据
        /// </summary>
        public static void WriteByMessage(byte[] buffer, int offset, int count)
        {
            try
            {

                log.Info("write  message  to buffer : " + StringToSendBytes.ByteToString(buffer));
                gobalserialPort.Write(buffer, offset, count);
                //进入线程等待
                CommonAutoRest.MEvent.WaitOne();

                Interlocked.Increment(ref CommonAutoRest.AutoResetCount);
               //++;
            }
            catch (Exception e) {

                log.Info("write message is error : " + e.Message);
            }
        }


        /// <summary>
        /// 写入数据 Lock模式数据
        /// </summary>
        public static void WriteByThreadWait(byte[] buffer, int offset, int count)
        {
            try
            {

                log.Info("write  message  to buffer : " + StringToSendBytes.ByteToString(buffer));
                gobalserialPort.Write(buffer, offset, count);
                //进入线程等待
                Thread.Sleep(200);
            }
            catch (Exception e)
            {

                log.Info("write message is error : " + e.Message);
            }
        }

        /// <summary>
        /// 这个函数是以前是一种用来读取数据的方式 现在我用来清除数据串口的数据
        /// </summary>
        /// <returns></returns>
        public static void ClearSendAndRecive()
        {

            try
            {
                gobalserialPort.ReadExisting();
                gobalserialPort.DiscardInBuffer();
                gobalserialPort.DiscardOutBuffer();
            }
            catch (InvalidOperationException)
            {
            }

        }

        /// <summary>
        /// 测试专用 
        /// </summary>
        public static void InitTest() {

            

        }


    }
}
