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

            String backString = "311B00000000000000FD00 7F 31 22  >";

            if (! (backString.Contains("71") && backString.Contains("1B")) )
            {

                Console.WriteLine("not  contains");

            }

            if (false && false) {

                Console.WriteLine("");
            }



            //ff();

            Console.WriteLine(DateTime.Now.ToString("yyyyMMdd") );

            Console.WriteLine("10进制转" + Convert.ToInt64("0064",16) );

            //Console.WriteLine("16进制:" + Reverse("0000012c") );

            //Console.WriteLine("16进制:" + Reverse("2c010000"));

            String allList = Convert.ToString(300, 16).PadRight(8, '0');

            Console.WriteLine("16进制:"+ allList);

          

            String all = "67104C18A17C4CD1802BCF8ECC2A4E54202020203030303030303030303233393536332020202020353830313437393331343030303030303233393536332D46324330303030303538303234323733373820202020202020202020202020202020202020";

            String   code  = all.Substring(89 * 2, 12);

            Console.WriteLine(all.Replace(code,"100000000000"));


            Console.WriteLine(all.Substring(0, 8));

            String entity = all.Substring(8 + 35 * 2, 28);

            String xulie = all.Substring(8 + 0 * 2, 8);

            String ll = all.Substring(1, 2);

            Console.WriteLine("ll:" + ll);

            all = "610240915F020000000000000000000000000000";
            entity = all.Substring(6 + 0 * 2, 32);

     




            Console.WriteLine("this is ascii: " + StringToASCII(entity) );


            byte[] ba = System.Text.ASCIIEncoding.Default.GetBytes(entity);

            StringBuilder S = new StringBuilder();

            byte[] buff = new byte[all.Length / 2];

            int index = 0;
            for (int i = 0; i < xulie.Length; i += 2)

            {

                buff[index] = Convert.ToByte(xulie.Substring(i, 2), 16);

                ++index;

            }
            string result = Encoding.Default.GetString(buff);
            Console.WriteLine(all.Length + "    "+ entity );
            Console.WriteLine("xuelie:"+ xulie +"result:" + result);
            // string BackString = MainF.GetBackString;     //   "2709\r67 09 76 BB DD EE \r\n\r\n>"
           // String backString = "76BBDDEE";
            UInt32 b = UInt32.Parse(backString, System.Globalization.NumberStyles.HexNumber);     //最后得到的 b 的值是 171。

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
                    if (indexValue < 128) {
                        buff[index] = indexValue; 
                    }
                    ++index;
                }
                result = Encoding.Default.GetString(buff);
            }
            catch (Exception e)
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
