using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WXModel.WXTransmitData;
using WXModel.WXTransmitData.RequestData;

namespace WeChatBusiness
{
    public class WXQueryFactory
    {
        /// <summary>
        /// 把请求转化为实体
        /// </summary>
        /// <param name="json">请求的json串</param>
        /// <param name="msgtype">请求的消息类型</param>
        /// <returns></returns>
        public static BaseRequestData GetRequestModel(string json, MsgType msgtype)
        {
            MsgType msgType = GetMsgType(json);
            switch (msgType)
            {
                case MsgType.text:
                    return json.ToModel<TextRequestMsg>();
            }
            return null;
        }
     
        public static MsgType GetMsgType(string json)
        {
            var baserequest = json.ToModel<BaseRequestData>();
            if (baserequest != null)
            {
                switch (baserequest.MsgType)
                {
                    case "text":
                        return MsgType.text;
                    case "image":
                        return MsgType.image;
                    case "voice":
                        return MsgType.voice;
                    case "video":
                        return MsgType.video;
                    case "shortvideo":
                        return MsgType.shortvideo;
                    case "link":
                        return MsgType.link;
                }
            }
            return MsgType.text;
        }
    }
}
