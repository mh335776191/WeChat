using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Common;
using WeChatBusiness;
using WXModel;
using WXModel.WXTransmitData;
using WXModel.WXTransmitData.RequestData;

namespace WeChat.Controllers
{
    public class WeiXinController : Controller
    {
        public ActionResult Index()
        {
            return Content("ok");
        }
        public ActionResult Action()
        {


            try
            {
                #region 获取请求xml内容
                Stream requestStream = Request.InputStream;
                long requestlength = requestStream.Length;
                byte[] requestBytes = new byte[requestlength];
                requestStream.Read(requestBytes, 0, (int)requestlength);
                string requestStr = Encoding.UTF8.GetString(requestBytes);
                //                string requestStr = @"<xml><ToUserName><![CDATA[gh_4ce5c62397ff]]></ToUserName>
                //                                    <FromUserName><![CDATA[oiI62v8GLf52lVLsQyQvrRKGUrRk]]></FromUserName>
                //                                    <CreateTime>1464965475</CreateTime>
                //                                    <MsgType><![CDATA[text]]></MsgType>
                //                                    <Content><![CDATA[趣图]]></Content>
                //                                    <MsgId>6291978805302987227</MsgId>
                //                                </xml>";



                #endregion
                string requestJson = requestStr.ToXMLJson();
                MsgType requestmsgType = WXQueryFactory.GetMsgType(requestJson);
                BaseRequestData requestData = WXQueryFactory.GetRequestModel(requestJson, requestmsgType);
                WX_RequestBusiness _requestBusiness = new WX_RequestBusiness();
                if (requestData != null)
                {
                    int requestid = _requestBusiness.AddRequestMsgLog(requestData, requestJson, requestStr);
                    WXForResponse responsecmd = new WXForResponse(requestData, requestmsgType);
                    var responsemodel = responsecmd.GetResponseModel();
                    var resuponsexml = responsecmd.GetResponseXML(responsemodel);
                    //var model = new WXModel.WXTransmitData.ResponseData.Image_TextResponseMsg();
                    //model.Title = "图文消息title";
                    //model.ToUserName = "FromUserName";
                    //model.FromUserName = "ToUserName";
                    //model.MsgType = "news";
                    //model.Articles = new WXModel.WXTransmitData.ResponseData.Article[2];
                    //model.Articles[0] = (new WXModel.WXTransmitData.ResponseData.Article { Description = "第一个描述", PicUrl = "图片1", Url = "跳转url1", Title = "第一个" });
                    //model.Articles[1] = (new WXModel.WXTransmitData.ResponseData.Article { Description = "第2个描述", PicUrl = "图片2", Url = "跳转url2", Title = "第2个" });
                    //resuponsexml = model.ToResponseXml<WXModel.WXTransmitData.ResponseData.Image_TextResponseMsg>();
                    _requestBusiness.AddResponseMsgLog(responsemodel, requestid, resuponsexml);

                    //                    resuponsexml = string.Format(@"<xml>
                    //            <Content><![CDATA[你好，这是一条测试回复信息]]></Content>
                    //            <ToUserName><![CDATA[{0}]]></ToUserName>
                    //            <FromUserName><![CDATA[{1}]]></FromUserName>
                    //            <CreateTime><![CDATA[12345678]]></CreateTime>
                    //            <MsgType><![CDATA[text]]></MsgType>           
                    //            </xml>", requestData.FromUserName, requestData.ToUserName);
                    return Content(resuponsexml, "text/xml");
                }
                else
                {
                    _requestBusiness.AddRequestParserFail(requestStr, requestJson);
                }

                return Content(requestJson, "text/xml"); //将随机生成的 echostr 参数 原样输出就能通过token验证了。
            }
            catch (Exception ex)
            {
                GlobalBusiness.AddGlobalError(ex.Message + ex.StackTrace);
                throw ex;
            }
            return Content("");
        }
        #region 验证token 只在配置时用一次
        /// <summary>
        /// 验证token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Valid(WXModel.WXRequestModel model)
        {
            WX_Access_tokenBusiness wxaccesstokenbusiness = new WX_Access_tokenBusiness();
            wxaccesstokenbusiness.GetAccess_token();
            //return Content(model.echostr);//输出echostr 表明验证通过。若确认此次GET请求来自微信服务器，请原样返回echostr参数内容，则接入生效，成为开发者成功，否则接入失败。
            //获取请求来的 echostr 参数
            string echoStr = model.echostr;
            //通过验证
            if (CheckSignature(model))
            {
                if (!string.IsNullOrEmpty(echoStr))
                {
                    //将随机生成的 echostr 参数 原样输出
                    return Content(echoStr);
                }
            }
            return Content("未通过验证");
        }

        /// <summary>
        /// 验证签名，检验是否是从微信服务器上发出的请求
        /// </summary>
        /// <param name="model">请求参数模型 Model</param>
        /// <returns>是否验证通过</returns>
        private bool CheckSignature(WXRequestModel model)
        {
            string signature, timestamp, nonce, tempStr;
            //获取请求来的参数
            signature = model.signature;
            timestamp = model.timestamp;
            nonce = model.nonce;
            //创建数组，将 Token, timestamp, nonce 三个参数加入数组
            string[] array = { WXCommon.WX_TOKEN, timestamp, nonce };
            //进行排序
            Array.Sort(array);
            //拼接为一个字符串
            tempStr = String.Join("", array);
            //对字符串进行 SHA1加密
            tempStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tempStr, "SHA1").ToLower();
            //判断signature 是否正确
            if (tempStr.Equals(signature))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}