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
        string _createtime = "";
        public string CreateTime
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_createtime))
                {
                    return _createtime;
                }
                else
                {
                    return (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds.ToString();
                }
            }
            set { _createtime = value; }
        }
        public string MsgType { get; set; }
        public string MsgId { get; set; }

    }

}
