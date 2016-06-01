using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeChatORM;
using WXModel.WXTransmitData;

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
                wxdb.WX_RequestParserFail.Add(new WX_RequestParserFail { RequestXML = requeststr, RequestJson = failjson });
                return wxdb.SaveChanges();
            }
        }
        /// <summary>
        /// 添加请求信息记录
        /// </summary>
        /// <param name="data">信息实体</param>
        /// <param name="json">信息json串</param>
        /// <returns></returns>
        public int AddRequestMsgLog(BaseData data, string json)
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
                wxdb.WX_RequestMsgLog.Add(log);
                return wxdb.SaveChanges();
            }
        }
        /// <summary>
        /// 添加回复信息记录
        /// </summary>
        /// <param name="data">回复实体</param>
        /// <param name="requestid">回复的请求id</param>
        /// <param name="json">回复json串</param>
        /// <returns></returns>
        public int AddResponseMsgLog(BaseData data, int requestid, string json)
        {
            using (var wxdb = new WXDBEntity())
            {
                WX_ResponseMsgLog log = new WX_ResponseMsgLog();
                log.ToUserName = data.ToUserName;
                log.FromUserName = data.FromUserName;
                log.CreateTime = data.CreateTime;
                log.MsgType = data.MsgType;
                log.MsgId = data.MsgId;
                log.RequestId = requestid;
                log.RequestJson = json;
                wxdb.WX_ResponseMsgLog.Add(log);
                return wxdb.SaveChanges();
            }
        }
    }
}
