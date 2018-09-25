using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dcarengine.Function_Class
{

    /// <summary>
    /// 标准
    /// </summary>
    class standClass
    {



        /// <summary>
        /// writefunction
        /// </summary>
        public static void  String() {

            // Convert.ToString("2", 2);

            int num = Convert.ToInt32("01000100", 16);
            String s = Convert.ToString(num, 2).PadLeft(32, '0');
        }



    }
}
