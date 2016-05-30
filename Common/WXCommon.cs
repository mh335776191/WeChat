using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class WXCommon
    {
        public static string WX_TOKEN = System.Configuration.ConfigurationManager.AppSettings["WXToken"];

        public static string WXEncodingAesKey = System.Configuration.ConfigurationManager.AppSettings["WXEncodingAesKey"];
        public static string WXAppId = System.Configuration.ConfigurationManager.AppSettings["WXAppId"];
        public static string WXAppSecret = System.Configuration.ConfigurationManager.AppSettings["WXAppSecret"];
    }
}
