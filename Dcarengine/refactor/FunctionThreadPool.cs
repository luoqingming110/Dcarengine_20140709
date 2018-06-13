using Dcarengine.refactor;
using Dcarengine.UIForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Dcarengine.Function_Class
{
    /// <summary>
    ///功能线程模块/线程池 所有数据通过线程处理
    /// </summary>
    class FunctionThreadPool
    {


        //public  ThreadPool thread;
        static FunctionThreadPool(){

            ThreadPool.SetMinThreads(5, 5);
            ThreadPool.SetMaxThreads(5, 5);

        }


        /// <summary>
        /// 添加服务
        /// </summary>
        public static void AddWork(WaitCallback fun,object ob) {

            ThreadPool.QueueUserWorkItem(fun,100);

        }

        /// <summary>
        ///测试 function
        /// </summary>
        public static void WorkOut(object ob) {

            //if (GolbalLock.GobalLockOnce.IsWriteLockHeld) {

            //         MessageBox.Show("ss");
            //     }
            //     MainF.textBox1.Text = Thread.CurrentThread.Name;
            //     GolbalLock.GobalLockOnce.EnterWriteLock();
            //     MainF.textBox1.Text = "1111";
            //     GolbalLock.GobalLockOnce.ExitWriteLock();
            //     Thread.Sleep(2000);
            //     GolbalLock.GobalLockOnce.EnterWriteLock();
            //     ThreadSleep();
            //     MainF.textBox1.Text = "222";
            //     GolbalLock.GobalLockOnce.ExitWriteLock();
            WorkoutByMessage();
        }

        public static void ThreadSleep() {

            //MainF.textBox1.Text = Thread.CurrentThread.Name;
            //Thread.Sleep(2000);
        }


        /// <summary>
        ///测试 function
        /// </summary>
        public static void WorkLock(object ob)
        {

            //GolbalLock.GobalLockOnce.EnterWriteLock();
            //MainF.textBox1.Text = "lock";
            //Thread.Sleep(5000);
            //GolbalLock.GobalLockOnce.ExitWriteLock();
            WorkLockByMessage();

        }

        /// <summary>
        /// workLockMessage
        /// </summary>
        public static void WorkLockByMessage() {

            // MainF.textBox1.Text = "lock";
            CommonAutoRest.MEvent.WaitOne();
            //commonAutoRest

        }

        /// <summary>
        /// workOut
        /// </summary>
        public static void WorkoutByMessage()
        {
            CommonAutoRest.MEvent.Set();
           // MainF.textBox1.Text = "unlock";

        }


    }

}
