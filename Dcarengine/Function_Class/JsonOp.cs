using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dcarengine.Function_Class
{
    class JsonOp
    {

        public static String readJson(String key)
        {

            String calid = "";
            string path=AppDomain.CurrentDomain.BaseDirectory; //另一种获取方式

            try
            {
                StreamReader file = File.OpenText("calid.json");

                //StreamReader file = File.OpenText("../calid.json");
                JsonTextReader reader = new JsonTextReader(file);
                JObject jsonObject = (JObject)JToken.ReadFrom(reader);
                calid = (String)jsonObject[key];
                //String  AccCode = (uint)jsonObject["AccCode"];
                //int   Id = (uint)jsonObject["Id"];

                // Configure Json
                //BPointMove = (bool)jsonObject["BPointMove"];
                //_classLeft.DelayBPointMove = (int)jsonObject["L_BPointMoveDelay"];
                //_classRight.DelayBPointMove = (int)jsonObject["R_BPointMoveDelay"];
                //file.Close();
            }
            catch
            {
                //MessageBox.Show("CAN卡配置有误！");
            }

            return calid;
        }

    }
}
