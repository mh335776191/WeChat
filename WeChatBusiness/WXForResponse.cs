using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WXModel.WXTransmitData;
using WXModel.WXTransmitData.RequestData;
using WXModel.WXTransmitData.ResponseData;

namespace WeChatBusiness
{
    /// <summary>
    /// 生成回复信息
    /// </summary>
    public class WXForResponse
    {
        private BaseRequestData _request;
        private MsgType _msgtype;
        public WXForResponse(BaseRequestData request, MsgType msgtype)
        {
            _request = request;
            _msgtype = msgtype;
        }
        /// <summary>
        /// 获取返回给客户端的xml消息
        /// </summary>
        /// <param name="data">客户请求消息实体</param>
        /// <param name="msgtype">请求消息类型</param>
        /// <returns></returns>
        public string GetResponseXML(BaseResponseData responseModel)
        {
            switch (_msgtype)
            {
                case MsgType.text:
                    TextResponseMsg response = responseModel as TextResponseMsg;
                    return response.ToResponseXml<TextResponseMsg>();
            }
            return "";
        }
        public BaseResponseData GetResponseModel()
        {
            switch (_msgtype)
            {
                case MsgType.text:
                    TextRequestMsg re1uest = _request as TextRequestMsg;
                    TextResponseMsg response = new TextResponseMsg();
                    if (re1uest != null)
                    {
                        response.ToUserName = re1uest.FromUserName;
                        response.FromUserName = re1uest.ToUserName;
                        response.MsgType = re1uest.MsgType;
                        response.Content = "你好,宝贝";
                        response.CreateTime = "";
                    }
                    return response;
            }
            return null;
        }
    }
}
