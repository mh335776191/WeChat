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

namespace WeChat.Controllers
{
    public class WeiXinController : Controller
    {

        public ActionResult Action()
        {
            //            string xml = @"<xml>
            //<ToUserName><![CDATA[SuperRookier]]></ToUserName>
            //<FromUserName><![CDATA[evalibusiness]]></FromUserName>
            //<CreateTime>12345678</CreateTime>
            //<MsgType><![CDATA[text]]></MsgType>
            //<Content><![CDATA[你好，这是一条测试回复信息]]></Content>
            //</xml>";

            try
            {
                #region 获取请求xml内容
                Stream requestStream = Request.InputStream;
                long requestlength = requestStream.Length;
                byte[] requestBytes = new byte[requestlength];
                requestStream.Read(requestBytes, 0, (int)requestlength);
                string requestStr = Encoding.UTF8.GetString(requestBytes);
                #endregion
                string requestJson = MsgXMLHelper.ToXMLJson(requestStr);

                BaseData requestData = WXQueryFactory.GetRequestModel(requestJson);
                WX_RequestBusiness _requestBusiness = new WX_RequestBusiness();
                if (requestData != null)
                {
                    _requestBusiness.AddRequestMsgLog(requestData, requestJson);
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