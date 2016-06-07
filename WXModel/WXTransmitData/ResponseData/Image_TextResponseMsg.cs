using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WXModel.WXTransmitData.ResponseData
{
    public class Image_TextResponseMsg : BaseResponseData
    {
        public string Title { get; set; }
        public int ArticleCount { get { return Articles.Length; } }
        public Article[] Articles { get; set; }
    }
    public class Article
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PicUrl { get; set; }
        public string Url { get; set; }

    }
}
