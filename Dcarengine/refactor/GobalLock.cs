using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Dcarengine.Function_Class
{
    class GolbalLock
    {
       
        //全局读写锁，没有读取完数据时不释放数据锁
        private static ReaderWriterLockSlim  gobalLockOnce = new ReaderWriterLockSlim();

        private static ReaderWriterLock gobalLock = new ReaderWriterLock();

        private static String endData;

       // public static ReaderWriterLockSlim GobalLock { get => gobalLock; set => gobalLock = value; }

        public static string EndData { get => endData; set => endData = value; }

        public static ReaderWriterLock GobalLock { get => gobalLock; set => gobalLock = value; }

        public static ReaderWriterLockSlim GobalLockOnce { get => gobalLockOnce; set => gobalLockOnce = value; }


        /// <summary>
        /// 数据锁  不可冲入型
        /// </summary>
        public static void DataLockOnce() {

            gobalLockOnce.EnterWriteLock();
        }


        /// <summary>
        /// 数据锁  释放锁
        /// </summary>
        public static void UnDataLockOnce()
        {

            gobalLockOnce.ExitWriteLock();
        }

        /// <summary>
        /// 数据锁
        /// </summary>
        public static void   DataLock() {

            gobalLock.AcquireWriterLock(0);
        }

        /// <summary>
        /// 数据解锁
        /// </summary>
        public static void UnDataLock() {

            gobalLock.ReleaseWriterLock();
        }

    }
}
