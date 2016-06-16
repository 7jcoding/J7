using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace J7.Utility
{
    // <summary>
    /// C#的36进制实现
    /// </summary>
    public class ThirtySixScale
    {
        /// <summary>
        /// 进位数
        /// </summary>
        private const int RADIX = 36;
        /// <summary>
        /// 36进制数
        /// </summary>
        private string value;
        /// <summary>
        /// 对应10进制长整数
        /// </summary>
        private Int64 value_long;
        /// <summary>
        /// 36进制数向10进制转换
        /// </summary>
        /// <param name="value"></param>
        public ThirtySixScale(string value)
        {
            this.value = value;

            int length = value.Length;
            Int64 result = 0;
            for (int i = 0; i < length; i++)
            {
                Int64 val = (Int64)Math.Pow(RADIX, (length - i - 1));
                char c = value[i];
                Int64 tmp = Convert(c);
                result += tmp * val;
            }
            value_long = result;
        }
        /// <summary>
        /// 10进制向36进制转换
        /// </summary>
        /// <param name="value_long"></param>
        public ThirtySixScale(Int64 value_long)
        {
            this.value_long = value_long;
            if (value_long == 0)    //补充
            {
                this.value = "0";
                return;
            }
            Int64 result = value_long;
            while (result > 0)
            {
                Int64 val = result % RADIX;
                this.value = Convert((int)val).ToString() + this.value;
                result = (Int64)(result / RADIX);
            }
        }
        /// <summary>
        /// 输出36进制
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.value;
        }
        /// <summary>
        /// 输出10进制
        /// </summary>
        /// <returns></returns>
        public Int64 ToInt()
        {
            return value_long;
        }

        #region 字符数字相互转换
        private char Convert(int val)
        {
            switch (val)
            {
                case 0:
                    return '0';
                case 1:
                    return '1';
                case 2:
                    return '2';
                case 3:
                    return '3';
                case 4:
                    return '4';
                case 5:
                    return '5';
                case 6:
                    return '6';
                case 7:
                    return '7';
                case 8:
                    return '8';
                case 9:
                    return '9';

                case 10:
                    return 'A';
                case 11:
                    return 'B';
                case 12:
                    return 'C';
                case 13:
                    return 'D';
                case 14:
                    return 'E';
                case 15:
                    return 'F';
                case 16:
                    return 'G';
                case 17:
                    return 'H';
                case 18:
                    return 'I';
                case 19:
                    return 'J';
                case 20:
                    return 'K';
                case 21:
                    return 'L';
                case 22:
                    return 'M';
                case 23:
                    return 'N';
                case 24:
                    return 'O';
                case 25:
                    return 'P';
                case 26:
                    return 'Q';
                case 27:
                    return 'R';
                case 28:
                    return 'S';
                case 29:
                    return 'T';
                case 30:
                    return 'U';
                case 31:
                    return 'V';
                case 32:
                    return 'W';
                case 33:
                    return 'X';
                case 34:
                    return 'Y';
                case 35:
                    return 'Z';
            }
            return '0';
        }

        private int Convert(char c)
        {
            switch (c)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;

                case 'A':
                    return 10;
                case 'B':
                    return 11;
                case 'C':
                    return 12;
                case 'D':
                    return 13;
                case 'E':
                    return 14;
                case 'F':
                    return 15;
                case 'G':
                    return 16;
                case 'H':
                    return 17;
                case 'I':
                    return 18;
                case 'J':
                    return 19;
                case 'K':
                    return 20;
                case 'L':
                    return 21;
                case 'M':
                    return 22;
                case 'N':
                    return 23;
                case 'O':
                    return 24;
                case 'P':
                    return 25;
                case 'Q':
                    return 26;
                case 'R':
                    return 27;
                case 'S':
                    return 28;
                case 'T':
                    return 29;
                case 'U':
                    return 30;
                case 'V':
                    return 31;
                case 'W':
                    return 32;
                case 'X':
                    return 33;
                case 'Y':
                    return 34;
                case 'Z':
                    return 35;
            }
            return 0;
        }
        #endregion

        #region 重写运算符
        public static implicit operator ThirtySixScale(string value)
        {
            return new ThirtySixScale(value);
        }

        public static implicit operator ThirtySixScale(int value)
        {
            return new ThirtySixScale(value);
        }

        /// <summary>
        /// 随机种子定义
        /// </summary>
        private static char[] constant = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        //{   
        //  '0','1','2','3','4','5','6','7','8','9',  
        //  'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',   
        //  'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'   
        //};
        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <param name="length">要生成的随机数的位数</param>
        /// <returns></returns>
        public static string GenerateRandomNumber(int length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(9);
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                newRandom.Append(constant[rd.Next(9)]);
            }
            return newRandom.ToString();
        }
        #endregion
    }
}
