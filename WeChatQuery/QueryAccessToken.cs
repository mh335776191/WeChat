using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using WXModel.WXResultModel;

namespace WeChatQuery
{
    public class QueryAccessToken : IQuery<WXAccessTokenResult>
    {
        #region IQuery<WXAccessTokenResult> 成员

        public WXAccessTokenResult GetQueryResult(Dictionary<string, string> param)
        {
            param = new Dictionary<string, string>
                {
                    {"grant_type","client_credential"},
                    {"appid",WXCommon.WXAppId},
                    {"secret",WXCommon.WXAppSecret}
                };
            string queryresult = HttpHelper.Get(WXCommon.WXtoken_cgibinurl, param, "UTF-8");
            var resultmodel = queryresult.ToModel<WXAccessTokenResult>();
            return resultmodel;
        }

        #endregion
    }
}
