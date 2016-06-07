using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeChatORM;

namespace WeChatDataRepository
{
    public class WX_Access_tokenRepository
    {
        /// <summary>
        /// 获取微信的Access_token
        /// </summary>
        /// <returns></returns>
        public string GetAccess_token()
        {
            using (var wxdb = new WXDBEntity())
            {
                var model = wxdb.WX_Access_token.SingleOrDefault();
                if (model != null && model.updatedate.AddHours(1.9) > DateTime.Now)
                {
                    return model.access_token;
                }
                return string.Empty;
            }
        }
        /// <summary>
        /// 更新accesstoken 并返回最新的保存成功的
        /// </summary>
        /// <param name="accesstoken"></param>
        /// <returns>accesstoken</returns>
        public string UpdataAccess_token(string accesstoken)
        {
            using (var wxdb = new WXDBEntity())
            {
                var model = wxdb.WX_Access_token.SingleOrDefault();
                if (model == null)
                {
                    model = new WX_Access_token();
                    wxdb.WX_Access_token.Add(model);
                }
                model.access_token = accesstoken;
                model.updatedate = DateTime.Now;
                var result = wxdb.SaveChanges();
                if (result > 0)
                    return accesstoken;
                return string.Empty;
            }
        }
    }
}
