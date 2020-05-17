using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestProject
{
    class Program
    {

        private static ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();

        private static ReaderWriterLock cacheLock1 = new ReaderWriterLock();
        
        delegate void MyDele(string str);　　//定义委托

        event MyDele MyEvent;　　//定义事件

        delegate String GetString();

        static AutoResetEvent mThreadMessage = new AutoResetEvent(false);

     //  private static String  backString="";

        static void Main(string[] args)
        {

             long  stat_time =  (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;

            Thread.Sleep(1000);

            long  end_time = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;

            long ctime = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;

            Console.Out.WriteLine("stime :"+ stat_time +"endTime:" + end_time + "ss:" + (end_time  -stat_time) );

            Console.Out.WriteLine("ctime :" + ctime);

            string str2 = "SessionN";
            byte[] array = System.Text.Encoding.ASCII.GetBytes(str2);  //数组array为对应的ASCII数组    
            string ASCIIstr2 = null;
            string hexList = "";
            for (int i = 0; i < array.Length; i++)
            {
                int  value = Convert.ToInt32(array[i]);
                String hexValue = string.Format("{0:x}", value);
                hexList += hexValue;
            }

            Console.WriteLine(ASCIIstr2 + "length:"+str2.Length + "length0:" + hexList +"..."+ hexList.Length);

            //   Convert.ToString("01000100", System.Globalization.NumberStyles.HexNumber);
            // int num = Convert.ToInt32("01000100", 16);
            int num = Convert.ToInt32("00000000", 16);
            String s = Convert.ToString(num,2).PadLeft(32,'0');
            String sta = s.Substring(31, 1);

            Console.WriteLine("this is sta :" + sta);

            String finalValue = "1027";

            String finalValueOne = finalValue.Substring(0, 2);
            String finalValueTwo = finalValue.Substring(2, 2);
            finalValue = finalValueTwo + finalValueOne;

            Console.WriteLine("fianlValue: " + finalValue);

            String staprefix = s.Substring(0, 1 - 0);
            String stasuffix = s.Substring(1 + 1, s.Length - 2);


            String ss=  string.Format("{0:x}", 100);


            Console.WriteLine("pre:"+staprefix + "suf:" + stasuffix);

            Console.WriteLine(ss);



            Console.WriteLine(s);
            Console.WriteLine(sta);

            // 2323879783
            ////90
            String sbyteone3 = Convert.ToString(148, 16).PadLeft(2, '0');
            String sbytetwo3 = Convert.ToString(155, 16).PadLeft(2, '0');
            String sbytethree3 = Convert.ToString(181, 16).PadLeft(2, '0');
            String sbytefour3 = Convert.ToString(215, 16).PadLeft(2, '0');

            //String sbyteone3 = Convert.ToString(136, 16).PadLeft(2, '0');
            //String sbytetwo3 = Convert.ToString(167, 16).PadLeft(2, '0');
            //String sbytethree3 = Convert.ToString(68, 16).PadLeft(2, '0');
            //String sbytefour3 = Convert.ToString(150, 16).PadLeft(2, '0');

            String final3 = sbyteone3 + sbytetwo3 + sbytethree3 + sbytefour3;
           
            UInt32 x = UInt32.Parse(final3, System.Globalization.NumberStyles.HexNumber);   //最后得到的 b 的值是 171。

            Console.WriteLine("84: " + "s" + "10进制:" + x);



        }



        static int a = 0;
        public static void ff() {

            Console.WriteLine("this is the ff: ff" );
            a++;
            if (a >10) {

                return;
            }

            ff();
          //  ff();
        }



        /// <summary>
        /// StringtoAscII
        /// </summary>
        /// <returns></returns>
        public static String StringToASCII(String orginString)
        {

            String result = "";
            try
            {
                byte[] buff = new byte[orginString.Length / 2];
                int index = 0;
                for (int i = 0; i < orginString.Length; i += 2)
                {
                    byte indexValue = Convert.ToByte(orginString.Substring(i, 2), 16);
                    if (indexValue < 128)
                    {
                        buff[index] = indexValue;
                    }
                    ++index;
                }
                result = Encoding.Default.GetString(buff);
                result = result.Replace("\0","");
            }
            catch (Exception )
            {

            }
            return result;
        }



        /// <summary>
        /// Workout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void WorkOut(object sender, SerialDataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void measure_DataReceivedByMeasure(object sender, SerialDataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }



        class StatusChecker
        {
            private int invokeCount;
            private int maxCount;

            public StatusChecker(int count)
            {
                invokeCount = 0;
                maxCount = count;
            }

            // This method is called by the timer delegate.
            public void CheckStatus(Object stateInfo)
            {
                //AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
                Console.WriteLine("{0} Checking status {1,2}.", DateTime.Now.ToString("h:mm:ss.fff"),
                (++invokeCount).ToString());

            }
        }

        /// <summary>
        /// 将一条十六进制字符串转换为ASCII
        /// </summary>
        /// <param name="hexstring">一条十六进制字符串</param>
        /// <returns>返回一条ASCII码</returns>
        public static string HexStringToASCII(string hexstring)
        {
            byte[] bt = HexStringToBinary(hexstring);
            string lin = "";
            for (int i = 0; i < bt.Length; i++)
            {
                lin = lin + bt[i] + " ";
            }


            string[] ss = lin.Trim().Split(new char[] { ' ' });
            char[] c = new char[ss.Length];
            int a;
            for (int i = 0; i < c.Length; i++)
            {
                a = Convert.ToInt32(ss[i]);
                c[i] = Convert.ToChar(a);
            }

            string b = new string(c);
            return b;
        }


        /**/
        /// <summary>
        /// 16进制字符串转换为二进制数组
        /// </summary>
        /// <param name="hexstring">用空格切割字符串</param>
        /// <returns>返回一个二进制字符串</returns>
        public static byte[] HexStringToBinary(string hexstring)
        {

            string[] tmpary = hexstring.Trim().Split(' ');
            byte[] buff = new byte[tmpary.Length];
            for (int i = 0; i < buff.Length; i++)
            {
                buff[i] = Convert.ToByte(tmpary[i], 16);
            }
            return buff;
        }





        public void Say(object a)
        {
            Console.WriteLine("你好");
        }


        public void TimeerSetting(object sender, System.Timers.ElapsedEventArgs e)
        {
            //  GobalSerialPort.WriteByMessage(CommonCmd._21f0, 0, CommonCmd._21f0.Length);
            //  mcount++;

            Console.WriteLine("this is reaaa");
           // mThreadMessage.WaitOne();
        }



        class Heater
        {

            private int temperature;
            public string type = "RealFire 001";       // 添加型号作为演示
            public string area = "China Xian";         // 添加产地作为演示
                                                       //声明委托
            public delegate void BoiledEventHandler(Object sender, BoiledEventArgs e);
            public event BoiledEventHandler Boiled; //声明事件

            // 定义BoiledEventArgs类，传递给Observer所感兴趣的信息
            public class BoiledEventArgs : EventArgs
            {
                public readonly int temperature;
                public BoiledEventArgs(int temperature)
                {
                    this.temperature = temperature;
                }
            }

            // 可以供继承自 Heater 的类重写，以便继承类拒绝其他对象对它的监视
            protected virtual void OnBoiled(BoiledEventArgs e)
            {
                if (Boiled != null)
                { // 如果有对象注册
                    Boiled(this, e);  // 调用所有注册对象的方法
                }
            }

            // 烧水。
            public void BoilWater()
            {
                for (int i = 0; i <= 100; i++)
                {
                    temperature = i;
                    if (temperature > 95)
                    {
                        //建立BoiledEventArgs 对象。
                        BoiledEventArgs e = new BoiledEventArgs(temperature);
                        OnBoiled(e);  // 调用 OnBolied方法
                    }
                }
            }

            // 警报器
            public class Alarm
            {
                public void MakeAlert(Object sender, Heater.BoiledEventArgs e)
                {
                    Heater heater = (Heater)sender;     //这里是不是很熟悉呢？
                                                        //访问 sender 中的公共字段
                    Console.WriteLine("Alarm：{0} - {1}: ", heater.area, heater.type);
                    Console.WriteLine("Alarm: 嘀嘀嘀，水已经 {0} 度了：", e.temperature);
                    Console.WriteLine();
                }
            }

            // 显示器
            public class Display
            {
                public static void ShowMsg(Object sender, Heater.BoiledEventArgs e)
                {   //静态方法
                    Heater heater = (Heater)sender;
                    Console.WriteLine("Display：{0} - {1}: ", heater.area, heater.type);
                    Console.WriteLine("Display：水快烧开了，当前温度：{0}度。", e.temperature);
                    Console.WriteLine();
                }
            }




        }





        //定义委托方法
        public void MyMethod(string str)
        {

            Console.WriteLine("方法参数为：" + str);

        }
        
        //
        public static void write() {

            lock (cacheLock) {

                System.Console.WriteLine("this is a ........");
            }
            //  cacheLock1.AcquireWriterLock(100);          
            //  cacheLock1.ReleaseLock();
            //  cacheLock1.ReleaseLock();
            //  cacheLock1.l
        }

        //
        public static void print()
        {
            if (cacheLock1.IsWriterLockHeld) {

                System.Console.WriteLine("write locked ");
            }

            cacheLock1.AcquireWriterLock(11);
            System.Console.WriteLine("this is a ........");
        }




    }
}
