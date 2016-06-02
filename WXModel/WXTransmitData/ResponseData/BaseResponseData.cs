using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WXModel.WXTransmitData.ResponseData
{
    /// <summary>
    /// 回复消息 实体基类
    /// </summary>
    public class BaseResponseData
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public string CreateTime { get; set; }
        public string MsgType { get; set; }
    }
}
