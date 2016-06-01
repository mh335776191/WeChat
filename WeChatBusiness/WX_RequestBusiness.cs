using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeChatDataRepository;
using WXModel.WXTransmitData;

namespace WeChatBusiness
{
    public class WX_RequestBusiness
    {
        WX_RequestRepository _repository = new WX_RequestRepository();
        /// <summary>
        /// 记录转化请求对象的数据
        /// </summary>
        /// <param name="requeststr">请求字符串</param>
        /// <param name="failjson">转换对象失败的json串</param>
        /// <returns></returns>
        public int AddRequestParserFail(string requeststr, string failjson)
        {
            return _repository.AddRequestParserFail(requeststr, failjson);
        }
        /// <summary>
        /// 添加请求信息记录
        /// </summary>
        /// <param name="data">信息实体</param>
        /// <param name="json">信息json串</param>
        /// <returns></returns>
        public int AddRequestMsgLog(BaseData data, string json)
        {
            return _repository.AddRequestMsgLog(data, json);
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
            return _repository.AddResponseMsgLog(data, requestid, json);
        }
    }
}
