//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeChatORM
{
    using System;
    using System.Collections.Generic;
    
    public partial class WX_ResponseMsgLog
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public string CreateTime { get; set; }
        public string MsgType { get; set; }
        public string ResponseXML { get; set; }
        public System.DateTime CreateDate { get; set; }
    }
}
