using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Dcarengine.refactor
{
    class CommonAutoRest
    {
        /// <summary>
        /// thread message，事件通知結構
        /// </summary>
        static AutoResetEvent mThreadMessage = new AutoResetEvent(false);
        /// <summary>
        /// Thread Auto 数据计数器
        /// </summary>
        public static int AutoResetCount=0;


        static AutoResetEvent MainFTextThreadMessage = new AutoResetEvent(false);

        public static AutoResetEvent MEvent { get => mThreadMessage;
            set => mThreadMessage = value; }

        public static AutoResetEvent MainFTextThreadMessage1
        { get => MainFTextThreadMessage; set => MainFTextThreadMessage = value; }
    }
}
