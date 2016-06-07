using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WXModel.WXTransmitData
{
    public enum MsgType
    {
        /// <summary>
        /// 文本消息
        /// </summary>
        text,
        /// <summary>
        /// 图片消息
        /// </summary>
        image,
        /// <summary>
        /// 语音消息
        /// </summary>
        voice,
        /// <summary>
        /// 视频消息
        /// </summary>
        video,
        /// <summary>
        /// 小视频
        /// </summary>
        shortvideo,
        /// <summary>
        /// 链接消息
        /// </summary>
        link,
        /// <summary>
        /// 图文消息
        /// </summary>
        news,
        /// <summary>
        /// 事件消息
        /// </summary>
        Event,
    }
}
