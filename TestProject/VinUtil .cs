using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dcarengine.Function_Class
{
    class VinUtil
    {

        /**
         * 字符权重表
        */
        private static Hashtable CHAR_WEIGHTS = new Hashtable();

        /**
         * 位置权重表
         */
        private static int[] POS_WEIGHTS = new int[] { 8, 7, 6, 5, 4, 3, 2, 10, 0, 9, 8, 7, 6, 5, 4, 3, 2 };

        static VinUtil()
        {
            CHAR_WEIGHTS.Add('0', 0);
            CHAR_WEIGHTS.Add('1', 1);
            CHAR_WEIGHTS.Add('2', 2);
            CHAR_WEIGHTS.Add('3', 3);
            CHAR_WEIGHTS.Add('4', 4);
            CHAR_WEIGHTS.Add('5', 5);
            CHAR_WEIGHTS.Add('6', 6);
            CHAR_WEIGHTS.Add('7', 7);
            CHAR_WEIGHTS.Add('8', 8);
            CHAR_WEIGHTS.Add('9', 9);

            CHAR_WEIGHTS.Add('A', 1);
            CHAR_WEIGHTS.Add('B', 2);
            CHAR_WEIGHTS.Add('C', 3);
            CHAR_WEIGHTS.Add('D', 4);
            CHAR_WEIGHTS.Add('E', 5);
            CHAR_WEIGHTS.Add('F', 6);
            CHAR_WEIGHTS.Add('G', 7);
            CHAR_WEIGHTS.Add('H', 8);

            CHAR_WEIGHTS.Add('J', 1);
            CHAR_WEIGHTS.Add('K', 2);
            CHAR_WEIGHTS.Add('L', 3);
            CHAR_WEIGHTS.Add('M', 4);
            CHAR_WEIGHTS.Add('N', 5);
            CHAR_WEIGHTS.Add('P', 7);
            CHAR_WEIGHTS.Add('R', 9);

            CHAR_WEIGHTS.Add('S', 2);
            CHAR_WEIGHTS.Add('T', 3);
            CHAR_WEIGHTS.Add('U', 4);
            CHAR_WEIGHTS.Add('V', 5);
            CHAR_WEIGHTS.Add('W', 6);
            CHAR_WEIGHTS.Add('X', 7);
            CHAR_WEIGHTS.Add('Y', 8);
            CHAR_WEIGHTS.Add('Z', 9);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        public static bool isValidVin(String vin)
        {
            if (null == vin)
            {
                return false;
            }
            else if (vin.Trim().Length == 17)
            {
                vin = vin.ToUpper();
                int sum = 0;
                int checkSum = 0;
                char[] vinchar = vin.ToCharArray();

                for (int i = 0; i < vin.Length; i++)
                {
                    char code = vinchar[i];

                    Int32 cw = Convert.ToInt32(CHAR_WEIGHTS[code]);

                    if (cw == null)
                    {
                        return false;
                    }
                    int pw = POS_WEIGHTS[i];
                    sum += cw * pw;

                    Console.WriteLine(sum);
                    if (i == 8)
                    {
                        // 获取校验位的值
                        if (code == 'X')
                        {
                            checkSum = 10;
                        }
                        else if (code >= '0' && code <= '9')
                        {
                            checkSum = Convert.ToInt32(Convert.ToString(code));
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return checkSum == sum % 11;
            }
            return false;
        }

    }
}

