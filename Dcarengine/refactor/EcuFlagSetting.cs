using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dcarengine.refactor
{

    /// <summary>
    ///标志属于哪个ECU  
    /// </summary>
    class EcuFlagSetting
    {

        /// <summary>
        /// 代表显示ECU信息
        /// </summary>
        private static string ecuSetting;

        public static string EcuSetting { get => ecuSetting; set => ecuSetting = value; }





    }
}
