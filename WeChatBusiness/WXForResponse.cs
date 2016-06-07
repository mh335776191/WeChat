using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WXModel.WXTransmitData;
using WXModel.WXTransmitData.RequestData;
using WXModel.WXTransmitData.RequestData.Event;
using WXModel.WXTransmitData.ResponseData;

namespace WeChatBusiness
{
    /// <summary>
    /// 生成回复信息
    /// </summary>
    public class WXForResponse
    {
        private BaseRequestData request;
        BaseResponseData response = new BaseResponseData();
        private MsgType msgtype;
        public WXForResponse(BaseRequestData _request, MsgType _msgtype)
        {
            request = _request;
            msgtype = _msgtype;
        }
        /// <summary>
        /// 获取返回给客户端的xml消息
        /// </summary>
        /// <param name="data">客户请求消息实体</param>
        /// <param name="msgtype">请求消息类型</param>
        /// <returns></returns>
        public string GetResponseXML(BaseResponseData responseModel)
        {
            switch (msgtype)
            {
                case MsgType.text:
                    TextResponseMsg txtresponse = responseModel as TextResponseMsg;
                    return txtresponse.ToResponseXml<TextResponseMsg>();
                case MsgType.news:
                    Image_TextResponseMsg imgtxtresponse = responseModel as Image_TextResponseMsg;
                    return imgtxtresponse.ToResponseXml<Image_TextResponseMsg>();
                case MsgType.Event:
                    var rq = request as EventBaseRequestMsg;
                    if (rq.Event.Contains("subscribe"))
                    {
                        TextResponseMsg eventresponse = responseModel as TextResponseMsg;
                        return eventresponse.ToResponseXml<TextResponseMsg>();
                    }
                    return null;
            }
            return "";
        }
        /// <summary>
        /// 获取返回给客户端的实体类型
        /// </summary>
        /// <returns></returns>
        public BaseResponseData GetResponseModel()
        {
            switch (msgtype)
            {
                case MsgType.text:
                    TextRequestMsg _request = request as TextRequestMsg;
                    if (_request != null)
                    {
                        response = GetLaughResponse(_request);
                    }
                    msgtype = (MsgType)Enum.Parse(typeof(MsgType), response.MsgType);
                    return response;
                case MsgType.Event:
                    EventBaseRequestMsg _eventrequest = request as EventBaseRequestMsg;
                    if (_eventrequest != null)
                    {
                        response = GetEventResponst(_eventrequest);
                    }
                    return response;
            }
            return null;
        }
        private BaseResponseData GetLaughResponse(TextRequestMsg request)
        {

            if (request.Content.Contains("笑话"))
            {
                var laugh = new ResponseDataBusiness().GetJoke(false);
                TextResponseMsg _response = new TextResponseMsg();
                _response.ToUserName = request.FromUserName;
                _response.FromUserName = request.ToUserName;
                _response.MsgType = MsgType.text.ToString();
                _response.Content = laugh.Content.Trim();
                return _response;

            }
            if (request.Content.Contains("趣图"))
            {
                var laugh = new ResponseDataBusiness().GetJoke(true);
                if (!string.IsNullOrWhiteSpace(laugh.ImgUrl))
                {
                    Image_TextResponseMsg _response = new Image_TextResponseMsg();
                    _response.ToUserName = request.FromUserName;
                    _response.FromUserName = request.ToUserName;
                    _response.Title = "心情美好一整天";
                    _response.MsgType = MsgType.news.ToString();
                    _response.Articles = new Article[1];
                    _response.Articles[0] = new Article { Description = laugh.Content.Trim(), PicUrl = laugh.ImgUrl, Url = "www.baidu.com", Title = laugh.Tag };
                    return _response;
                }
            }
            else
            {
                TextResponseMsg _response = new TextResponseMsg();
                _response.ToUserName = request.FromUserName;
                _response.FromUserName = request.ToUserName;
                _response.MsgType = MsgType.text.ToString();
                _response.Content = DateTime.Now.ToString();
                return _response;
            }

            return null;
        }


        private BaseResponseData GetEventResponst(EventBaseRequestMsg request)
        {
            if (request.Event.Contains("subscribe"))
            {
                TextResponseMsg response = new TextResponseMsg();
                TextResponseMsg _response = new TextResponseMsg();
                _response.ToUserName = request.FromUserName;
                _response.FromUserName = request.ToUserName;
                _response.MsgType = MsgType.text.ToString();
                _response.Content = "订阅时间：" + DateTime.Now.ToString() + "欢迎订阅该订阅号。发送笑话，趣图关键字有惊喜。";
                return _response;
            }
            if (request.Event == "unsubscribe")
            {
                TextResponseMsg response = new TextResponseMsg();
                TextResponseMsg _response = new TextResponseMsg();
                _response.ToUserName = request.FromUserName;
                _response.FromUserName = request.ToUserName;
                _response.MsgType = MsgType.text.ToString();
                _response.Content = "取消订阅时间：" + DateTime.Now.ToString();
                return _response;
            }
            return null;
        }
    }
}
