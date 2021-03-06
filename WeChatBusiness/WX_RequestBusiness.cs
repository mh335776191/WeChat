﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using WeChatDataRepository;
using WXModel.WXTransmitData;
using WXModel.WXTransmitData.RequestData;
using WXModel.WXTransmitData.ResponseData;

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
        public int AddRequestMsgLog(BaseRequestData data, string json, string requestxml)
        {
            data.CreateTime = WXCommon.formtToDate(data.CreateTime);
            return _repository.AddRequestMsgLog(data, json, requestxml);
        }
        /// <summary>
        /// 添加回复信息记录
        /// </summary>
        /// <param name="data">回复实体</param>
        /// <param name="requestid">回复的请求id</param>
        /// <param name="json">回复json串</param>
        /// <returns></returns>
        public int AddResponseMsgLog(BaseResponseData data, int requestid, string responsexml)
        {
            //data.CreateTime = WXCommon.formtToDate(data.CreateTime);
            data.CreateTime = DateTime.Now.ToString();
            return _repository.AddResponseMsgLog(data, requestid, responsexml);
        }

    }
}
