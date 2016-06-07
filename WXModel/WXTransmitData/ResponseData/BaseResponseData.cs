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
                    return ((long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds).ToString();
                }
            }
            set { _createtime = value; }
        }
        public string MsgType { get; set; }
    }
}
