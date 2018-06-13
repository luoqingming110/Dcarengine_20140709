using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dcarengine.refactor
{
    /// <summary>
    /// modelKeyMap
    /// </summary>
    class ModeKeyMap
    {
        /// <summary>
        /// hashTable  数据
        /// </summary>
        //public static Hashtable EcuModelMap = new Hashtable();

        public static Hashtable Ecu790ModeKeyMap = new Hashtable();
        public static Hashtable Ecu780ModeKeyMap = new Hashtable();
        public static Hashtable Ecu770ModeKeyMap = new Hashtable();
        public static Hashtable Ecu760ModeKeyMap = new Hashtable();
        public static Hashtable Ecu750ModeKeyMap = new Hashtable();
        public static Hashtable Ecu740ModeKeyMap = new Hashtable();


        static ModeKeyMap()
        {
            ///
            Ecu790ModeKeyMap.Add("1084", 185999660);
            Ecu790ModeKeyMap.Add("1085", 4109333651);
            Ecu790ModeKeyMap.Add("1086", 4109333651);
            Ecu790ModeKeyMap.Add("1087", 2832623225);
            Ecu790ModeKeyMap.Add("1090", 2292663446);
            Ecu790ModeKeyMap.Add("1091", 2323879783);
            Ecu790ModeKeyMap.Add("1092", 2832623225);
            Ecu790ModeKeyMap.Add("1093", 882402761);


            ///780 MapData
            Ecu780ModeKeyMap.Add("1084", 185999660);
            Ecu780ModeKeyMap.Add("1085", 4109333651);
            Ecu780ModeKeyMap.Add("1086", 4109333651);
            Ecu780ModeKeyMap.Add("1087", 4109333651);

            Ecu780ModeKeyMap.Add("1090", 2493232599);
            Ecu780ModeKeyMap.Add("1091", 2474633425);
            Ecu780ModeKeyMap.Add("1092", 3498280648);
            Ecu780ModeKeyMap.Add("1093", 1205888911);

        }


        /// <summary>
        /// 映射关系 数据
        /// </summary>
        /// <returns></returns>
        public static Hashtable GetHashtable(String  EcuVersion) {


            if (EcuVersion.Equals("P1287790") ) {

                return Ecu790ModeKeyMap;

            } else {

                return Ecu780ModeKeyMap;
            }


            //return null;
        }





    }
}
