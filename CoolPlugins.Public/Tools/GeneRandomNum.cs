using System;

namespace CoolPlugins.Public.Tools
{
    public static class GeneRandomNum
    {
        /// <summary>
        /// 自动生成随机数
        /// </summary>
        /// <param name="str">随机数开头字母</param>
        /// <returns></returns>
        public static string GetRanNum(string str)
        {
            Random ran = new Random((int)DateTime.Now.Ticks); //264673 随机种子
            int s = ran.Next(1000, 8888888); //1000-8888888 之间的任意数
            return str + DateTime.Now.ToString("yyyyMMddHHmmss") + s;
        }
    }
}