using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BaiDuResourceUpLoad
{
    public class ResourceManager
    {
        static string AppID = "23991356";
        static string Appkey = "L1GtqPhH40sGGqQruNcqQ08UQ5pSrOYD";
        static string Secretkey = "dAlGyy0NWXwt9F9ZrzxgvoOlEwLinj0K";
        static string Signkey = "7nB=A#$Y0AsEd!CGvLNC5$gZhI9=zit8";
        static string DefaultAccessToken = "123.ee889458d4d7a4f7e5586dc6fbeb2636.Y7BrvtNbBps_lpPQRu6j54KMVOjVepDUAtlSSD-.bGfZig";
        public static string GetAccessToken()
        {
            ////https://openapi.baidu.com/wiki/index.php?title=%E4%BD%BF%E7%94%A8%E5%BA%94%E7%94%A8%E5%85%AC%E9%92%A5%E3%80%81%E5%AF%86%E9%92%A5%E8%8E%B7%E5%8F%96Access_Token
            ////https://openapi.baidu.com/oauth/2.0/login_success#expires_in=2592000&access_token=123.8b765e02ca93ef7fdc2d55a46b545837.Y7JTiv5b0Mjfe23V4Cl4BfpBxPn2aN9bmB0KdNL.XiDOlg&session_secret=&session_key=&scope=basic+netdisk&state=xxx
            //string tokenUrl = $"http://openapi.baidu.com/oauth/2.0/authorize?response_type=token&client_id={Appkey}&redirect_uri=oob&scope=basic,netdisk&display=popup";
            //string result = HttpHelper.Get(tokenUrl, null, "utf-8");
            //return result;
            return DefaultAccessToken;
        }
        private static string RefAccessToken(string oldToken)
        {
            //https://openauth.baidu.com/doc/doc.html#_4-%E6%8C%89%E9%9C%80%E5%88%B7%E6%96%B0access-token
            string refreshTokenUrl = $"https://openapi.baidu.com/oauth/2.0/token?grant_type=refresh_token&refresh_token={oldToken}&client_id={Appkey}&client_secret={Secretkey}";
            string result = HttpHelper.Get(refreshTokenUrl, null, "utf-8");
            return result;
        }

        public static void CreateFolder(string folderName)
        {
            string uploadUrl = $"https://pan.baidu.com/rest/2.0/xpan/file?method=precreate&access_token={DefaultAccessToken}";
            string postData = JsonConvert.SerializeObject(new Dictionary<string, string> {
                { "path", folderName },
                { "size", "0" } ,
                { "isdir", "1" } ,
                { "autoinit", "1" } ,
                { "rtype", "1" } ,
                { "block_list",null}
            });
            string result = HttpHelper.HttpPost(uploadUrl, postData);
        }
        /// <summary>
        /// 查询容量信息
        /// </summary>
        public static void QueryQuota()
        {
            string queryUrl = $"https://pan.baidu.com/api/quota?access_token={DefaultAccessToken}";
            string result = HttpHelper.Get(queryUrl, null, "utf-8");
        }
    }
}
