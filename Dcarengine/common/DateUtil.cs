using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dcarengine.common
{
    class DateUtil
    {


        public static String getDate() {


            String  date   = DateTime.Now.ToString("yyyyMMdd");

            return date;


        }




    }
}
