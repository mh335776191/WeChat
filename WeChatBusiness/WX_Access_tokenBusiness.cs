using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using WeChatDataRepository;
using WeChatQuery;
using WXModel.WXResultModel;

namespace WeChatBusiness
{
    public class WX_Access_tokenBusiness
    {
        WX_Access_tokenRepository _repository = new WX_Access_tokenRepository();
        public string GetAccess_token()
        {
            string accesstoken = _repository.GetAccess_token();
            if (string.IsNullOrWhiteSpace(accesstoken))
            {
                IQuery<WXAccessTokenResult> wxquery = new QueryAccessToken();
                var accesstokenresult = wxquery.GetQueryResult(new Dictionary<string, string>());
                if (accesstokenresult != null)
                {
                    accesstoken = accesstokenresult.access_token;
                    return _repository.UpdataAccess_token(accesstoken);
                }
            }
            return accesstoken;
        }
    }
}
