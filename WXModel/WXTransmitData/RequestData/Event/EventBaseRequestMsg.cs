using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WXModel.WXTransmitData.RequestData.Event
{
    /// <summary>
    /// 用户订阅事件
    /// </summary>
    public class EventBaseRequestMsg : BaseRequestData
    {
        public string Event { get; set; }
    }
}
