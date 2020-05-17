using Dcarengine.refactor;
using Dcarengine.serialPort;
using Dcarengine.UIForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dcarengine.Function_Class
{
    class EcuVersionF
    {

        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static String EcuVsion;

        /// <summary>
        /// 获取ECUVersion 数据问题
        /// </summary>
        public static void GetEcuVersion() {

            log.Info("ecu version read ..");

            GobalSerialPort.WriteByMessage(CommonCmd.ecuVersionCmd, 0, CommonCmd.ecuVersionCmd.Length);

            String VersionString = GobalSerialPort.ResultBackString;

            _13IdFDataWork.InsertAcessF_7(VersionString);

            EcuVsion = _13IdFDataWork.WorkOutData;

            MainF.EcuVersionLabelShow(EcuVsion);

            log.Info("ecu version is :" + EcuVsion);
            // CommonAutoRest.MainFTextThreadMessage1.Set();
        }





    }
}
