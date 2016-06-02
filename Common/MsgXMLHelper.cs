using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Linq;


public static class MsgXMLHelper
{
    public static string ToXMLJson(this string xml)
    {
        var xmldic = XDocument.Parse(xml)
              .Root.Elements().ToDictionary(
            c => c.Name.ToString(),
            c => c.Value
        );

        var json = new JavaScriptSerializer().Serialize(xmldic);
        return json;
    }
    public static string ToResponseXml<T>(this T model) where T:WXModel.WXTransmitData.ResponseData.BaseResponseData
    {
        StringBuilder xmlsb = new StringBuilder();
        xmlsb.Append("<xml>");
        Type type = typeof(T);
        var properties = type.GetProperties();
        foreach (PropertyInfo p in properties)
        {
            xmlsb.AppendFormat("<{0}><![CDATA[{1}]]</{0}>", p.Name, p.GetValue(model, null));
        }
        xmlsb.Append("</xml>");
        return xmlsb.ToString();
    }
}
