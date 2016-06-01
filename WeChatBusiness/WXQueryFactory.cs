using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WXModel.WXTransmitData;

namespace WeChatBusiness
{
    public class WXQueryFactory
    {
        public static BaseData GetRequestModel(string json)
        {
            MsgType msgType = GetMsgType(json);
            switch (msgType)
            {
                case MsgType.text:
                    return json.ToModel<TextMsg>();
            }
            return null;
        }
        private static MsgType GetMsgType(string json)
        {
            var baserequest = json.ToModel<BaseData>();
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
