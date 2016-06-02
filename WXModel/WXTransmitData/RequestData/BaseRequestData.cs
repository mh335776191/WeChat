using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WXModel.WXTransmitData.RequestData
{
    /// <summary>
    /// 请求消息实体基类
    /// </summary>
    public class BaseRequestData
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public string CreateTime { get; set; }
        public string MsgType { get; set; }
        public string MsgId { get; set; }

    }

}
