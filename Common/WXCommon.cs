using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class WXCommon
    {
        public static string WX_TOKEN = System.Configuration.ConfigurationManager.AppSettings["WXToken"];

        //public static string WXEncodingAesKey = System.Configuration.ConfigurationManager.AppSettings["WXEncodingAesKey"];
        public static string WXAppId = System.Configuration.ConfigurationManager.AppSettings["WXAppId"];
        public static string WXAppSecret = System.Configuration.ConfigurationManager.AppSettings["WXAppSecret"];
        /// <summary>
        /// 微信accesstoken获取路径
        /// </summary>
        public static string WXtoken_cgibinurl = "https://api.weixin.qq.com/cgi-bin/token";
        /// <summary>
        /// ticks转换为datetime
        /// </summary>
        /// <param name="ticks"></param>
        /// <returns></returns>
        public static string formtToDate(string ticks)
        {
            long time_JAVA_Long = long.Parse(ticks) * 1000L;//java长整型日期，毫秒为单位                
            DateTime dt_1970 = new DateTime(1970, 1, 1, 0, 0, 0);
            long tricks_1970 = dt_1970.Ticks;//1970年1月1日刻度                         
            long time_tricks = tricks_1970 + time_JAVA_Long * 10000;//日志日期刻度                         
            DateTime dt = new DateTime(time_tricks).AddHours(8);//转化为DateTime
            return dt.ToString();
        }
    }
}
