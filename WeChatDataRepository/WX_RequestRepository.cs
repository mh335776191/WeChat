using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeChatORM;
using WXModel.WXTransmitData;
using WXModel.WXTransmitData.RequestData;
using WXModel.WXTransmitData.ResponseData;

namespace WeChatDataRepository
{
    public class WX_RequestRepository
    {
        /// <summary>
        /// 记录转化请求对象的数据
        /// </summary>
        /// <param name="requeststr">请求字符串</param>
        /// <param name="failjson">转换对象失败的json串</param>
        /// <returns></returns>
        public int AddRequestParserFail(string requeststr, string failjson)
        {
            using (var wxdb = new WXDBEntity())
            {
                wxdb.WX_RequestParserFail.Add(new WX_RequestParserFail { RequestXML = requeststr, RequestJson = failjson, CreateDate = DateTime.Now });
                return wxdb.SaveChanges();
            }
        }
        /// <summary>
        /// 添加请求信息记录
        /// </summary>
        /// <param name="data">信息实体</param>
        /// <param name="json">信息json串</param>
        /// <returns></returns>
        public int AddRequestMsgLog(BaseRequestData data, string json, string requestxml)
        {
            using (var wxdb = new WXDBEntity())
            {
                WX_RequestMsgLog log = new WX_RequestMsgLog();
                log.ToUserName = data.ToUserName;
                log.FromUserName = data.FromUserName;
                log.CreateTime = data.CreateTime;
                log.MsgType = data.MsgType;
                log.MsgId = data.MsgId;
                log.RequestJson = json;
                log.RequestXML = requestxml;
                log.CreateDate = DateTime.Now;
                wxdb.WX_RequestMsgLog.Add(log);
                wxdb.SaveChanges();
                return log.Id;
            }
        }
        /// <summary>
        /// 添加回复信息记录
        /// </summary>
        /// <param name="data">回复实体</param>
        /// <param name="requestid">回复的请求id</param>
        /// <param name="responsexml">回复json串</param>
        /// <returns></returns>
        public int AddResponseMsgLog(BaseResponseData data, int requestid, string responsexml)
        {
            using (var wxdb = new WXDBEntity())
            {
                WX_ResponseMsgLog log = new WX_ResponseMsgLog();
                log.ToUserName = data.ToUserName;
                log.FromUserName = data.FromUserName;
                log.CreateTime = data.CreateTime;
                log.MsgType = data.MsgType;
                log.RequestId = requestid;
                log.ResponseXML = responsexml;
                log.CreateDate = DateTime.Now;
                wxdb.WX_ResponseMsgLog.Add(log);
                wxdb.SaveChanges();
                return log.Id;
            }
        }
    }
}
