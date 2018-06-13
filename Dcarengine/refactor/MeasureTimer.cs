using Dcarengine.serialPort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Dcarengine.refactor
{
    /// <summary>
    /// 测量定时器，读取线程模式
    /// </summary>
    class MeasureTimer
    {

       public static Timer  stateTimer  ;

       private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// 测量时间构造函数
        /// </summary>
        /// <param name="interval"></param>
        public MeasureTimer(int  interval) {

            log.Info("timer start ...");
            stateTimer = new Timer(new TimerCallback(TimerCmd) ,null, 0, interval);
        }


        /// <summary>
        /// 发送时间间隔
        /// </summary>
        /// <param name="state"></param>
        public static void TimerCmd(object state)
        {
            GobalSerialPort.Write(CommonCmd._21f0, 0, CommonCmd._21f0.Length);          
        }

        /// <summary>
        /// 定时器释放
        /// </summary>
        public static void TimeDispose() {

            if (stateTimer!=null) {

                log.Info("timer dispose ... ");
                stateTimer.Dispose();
            }
        }


    }
}
