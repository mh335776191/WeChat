using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WXModel.WXResultModel
{
    public class WXAccessTokenResult
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
}
