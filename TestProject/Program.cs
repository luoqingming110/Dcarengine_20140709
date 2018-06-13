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

        static string Reverse1(string original)
        {
            char[] arr = original.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static string Reverse(String  origin) {

            string[] sub = new string[origin.Length / 2];

            string result = "" ;

            for (int i=0;i<origin.Length/2 ;i++) {

                sub[i] = origin.Substring(i*2,2);
            }
            for(int j=sub.Length-1; j>=0;j--){

                result += sub[j];
            }
            return result;
        }


        static void Main(string[] args)
        {

            Console.WriteLine("10进制转" + Convert.ToInt64("0064",16) );

            Console.WriteLine("16进制:" + Reverse("0000012c") );

            Console.WriteLine("16进制:" + Reverse("2c010000"));

            String allList = Convert.ToString(300, 16).PadRight(8, '0');

            Console.WriteLine("16进制:"+ allList);

            String all = "67610213201702094FA620202020343920202053303030303030303030303030302020202020204632434345363131422A4C303030202056303030303030303020353830323038323836352020202020303030323236202020353830323330353833392020202020";

            Console.WriteLine(all.Substring(0,8));

            String entity =  all.Substring(8+35*2,28);

            String xulie = all.Substring(8 + 0* 2, 8);

            String ll = all.Substring(1,2);

            Console.WriteLine("ll:" + ll);
            //Con
            //Console.WriteLine( all.Length +"    "+entity + HexStringToASCII(entity));

            

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
            String backString = "76BBDDEE";
            UInt32 b = UInt32.Parse(backString, System.Globalization.NumberStyles.HexNumber);     //最后得到的 b 的值是 171。

            //// 85 86
            //String sbyteone   = Convert.ToString(244, 16);
            //String sbytetwo   = Convert.ToString(239, 16);
            //String sbytethree = Convert.ToString(116, 16);
            //String sbytefour  = Convert.ToString(147, 16);
            ////84 
            //String sbyteone1 = Convert.ToString(11, 16).PadLeft(2,'0');
            //String sbytetwo1 = Convert.ToString(22, 16).PadLeft(2, '0');
            //String sbytethree1 = Convert.ToString(33, 16).PadLeft(2, '0');
            //String sbytefour1 = Convert.ToString(44, 16).PadLeft(2, '0');
            ////87 92
            //String sbyteone2 = Convert.ToString(168, 16).PadLeft(2, '0');
            //String sbytetwo2 = Convert.ToString(214, 16).PadLeft(2, '0');
            //String sbytethree2 = Convert.ToString(102, 16).PadLeft(2, '0');
            //String sbytefour2 = Convert.ToString(121, 16).PadLeft(2, '0');
            ////90
            //String sbyteone3 = Convert.ToString(136, 16).PadLeft(2, '0');
            //String sbytetwo3 = Convert.ToString(167, 16).PadLeft(2, '0');
            //String sbytethree3 = Convert.ToString(68, 16).PadLeft(2, '0');
            //String sbytefour3 = Convert.ToString(150, 16).PadLeft(2, '0');
            ////91
            //String sbyteone4 = Convert.ToString(138, 16).PadLeft(2, '0');
            //String sbytetwo4 = Convert.ToString(131, 16).PadLeft(2, '0');
            //String sbytethree4 = Convert.ToString(151, 16).PadLeft(2, '0');
            //String sbytefour4 = Convert.ToString(103, 16).PadLeft(2, '0');
            ////93
            //String sbyteone5 = Convert.ToString(52, 16).PadLeft(2, '0');
            //String sbytetwo5 = Convert.ToString(152, 16).PadLeft(2, '0');
            //String sbytethree5 = Convert.ToString(101, 16).PadLeft(2, '0');
            //String sbytefour5 = Convert.ToString(201, 16).PadLeft(2, '0');
            //String final = sbyteone + sbytetwo + sbytethree + sbytefour;
            //String final1 = sbyteone1 + sbytetwo1 + sbytethree1 + sbytefour1;
            //String final2 = sbyteone2 + sbytetwo2 + sbytethree2 + sbytefour2;
            //String final3 = sbyteone3 + sbytetwo3 + sbytethree3 + sbytefour3;
            //String final4 = sbyteone4 + sbytetwo4 + sbytethree4 + sbytefour4;
            //String final5 = sbyteone5 + sbytetwo5 + sbytethree5 + sbytefour5;
            //UInt32 x = UInt32.Parse(final, System.Globalization.NumberStyles.HexNumber);   //最后得到的 b 的值是 171。
            //UInt32 x1 = UInt32.Parse(final1, System.Globalization.NumberStyles.HexNumber);  //最后得到的 b 的值是 171。
            //UInt32 x2 = UInt32.Parse(final2, System.Globalization.NumberStyles.HexNumber);  //最后得到的 b 的值是 171。
            //UInt32 x3 = UInt32.Parse(final3, System.Globalization.NumberStyles.HexNumber);  //最后得到的 b 的值是 171。
            //UInt32 x4 = UInt32.Parse(final4, System.Globalization.NumberStyles.HexNumber);  //最后得到的 b 的值是 171。
            //UInt32 x5 = UInt32.Parse(final5, System.Globalization.NumberStyles.HexNumber);  //最后得到的 b 的值是 171。

            // 85 86 87
            //String sbyteone = Convert.ToString(244, 16);
            //String sbytetwo = Convert.ToString(239, 16);
            //String sbytethree = Convert.ToString(116, 16);
            //String sbytefour = Convert.ToString(147, 16);

            ////84 
            //String sbyteone1 = Convert.ToString(11, 16).PadLeft(2, '0');
            //String sbytetwo1 = Convert.ToString(22, 16).PadLeft(2, '0');
            //String sbytethree1 = Convert.ToString(33, 16).PadLeft(2, '0');
            //String sbytefour1 = Convert.ToString(44, 16).PadLeft(2, '0');

            ////90
            //String sbyteone3 = Convert.ToString(148, 16).PadLeft(2, '0');
            //String sbytetwo3 = Convert.ToString(155, 16).PadLeft(2, '0');
            //String sbytethree3 = Convert.ToString(181, 16).PadLeft(2, '0');
            //String sbytefour3 = Convert.ToString(215, 16).PadLeft(2, '0');
            ////91
            //String sbyteone4 = Convert.ToString(147, 16).PadLeft(2, '0');
            //String sbytetwo4 = Convert.ToString(127, 16).PadLeft(2, '0');
            //String sbytethree4 = Convert.ToString(232, 16).PadLeft(2, '0');
            //String sbytefour4 = Convert.ToString(209, 16).PadLeft(2, '0');
            ////92
            //String sbyteone5 = Convert.ToString(208, 16).PadLeft(2, '0');
            //String sbytetwo5 = Convert.ToString(131, 16).PadLeft(2, '0');
            //String sbytethree5 = Convert.ToString(134, 16).PadLeft(2, '0');
            //String sbytefour5 = Convert.ToString(200, 16).PadLeft(2, '0');

            ////93
            //String sbyteone2 = Convert.ToString(71, 16).PadLeft(2, '0');
            //String sbytetwo2 = Convert.ToString(224, 16).PadLeft(2, '0');
            //String sbytethree2 = Convert.ToString(103, 16).PadLeft(2, '0');
            //String sbytefour2 = Convert.ToString(143, 16).PadLeft(2, '0');


            //String final = sbyteone + sbytetwo + sbytethree + sbytefour;
            //String final1 = sbyteone1 + sbytetwo1 + sbytethree1 + sbytefour1;
            //String final2 = sbyteone2 + sbytetwo2 + sbytethree2 + sbytefour2;
            //String final3 = sbyteone3 + sbytetwo3 + sbytethree3 + sbytefour3;
            //String final4 = sbyteone4 + sbytetwo4 + sbytethree4 + sbytefour4;
            //String final5 = sbyteone5 + sbytetwo5 + sbytethree5 + sbytefour5;


            //UInt32 x = UInt32.Parse(final, System.Globalization.NumberStyles.HexNumber);   //最后得到的 b 的值是 171。

            //UInt32 x1 = UInt32.Parse(final1, System.Globalization.NumberStyles.HexNumber);  //最后得到的 b 的值是 171。

            //UInt32 x2 = UInt32.Parse(final2, System.Globalization.NumberStyles.HexNumber);  //最后得到的 b 的值是 171。

            //UInt32 x3 = UInt32.Parse(final3, System.Globalization.NumberStyles.HexNumber);  //最后得到的 b 的值是 171。

            //UInt32 x4 = UInt32.Parse(final4, System.Globalization.NumberStyles.HexNumber);  //最后得到的 b 的值是 171。

            //UInt32 x5 = UInt32.Parse(final5, System.Globalization.NumberStyles.HexNumber);  //最后得到的 b 的值是 171。

            //Console.WriteLine("86 85 87: "  + final  + "10进制:" + x);
            //Console.WriteLine("84: "  + final1 + "10进制:"  + x1);
            //Console.WriteLine("93: "  + final2 + "10进制:"  + x2);
            //Console.WriteLine("90: "  + final3 + "10进制:"  + x3);
            //Console.WriteLine("91: "  + final4 + "10进制:"  + x4);
            //Console.WriteLine("92: "  + final5 + "10进制:"  + x5);

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
                Console.WriteLine("{0} Checking status {1,2}.",DateTime.Now.ToString("h:mm:ss.fff"),
                (++invokeCount).ToString());

                
               // autoEvent.WaitOne();
                //if (invokeCount == maxCount)
                //{
                //    // Reset the counter and signal the waiting thread.
                //    invokeCount = 0;
                //    autoEvent.Set();
                //}
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
