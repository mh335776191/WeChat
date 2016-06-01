using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace Common
{
    public static class MsgXMLHelper
    {
        public static string ToXMLJson(string xml)
        {
            var xmldic = XDocument.Parse(xml)
                  .Root.Elements().ToDictionary(
                c => c.Name.ToString(),
                c => c.Value
            );

            var json = new JavaScriptSerializer().Serialize(xmldic);
            return json;
        }
    }
}
