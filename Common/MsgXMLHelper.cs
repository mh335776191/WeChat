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
    public static string ToResponseXml<T>(this T model)
    {
        StringBuilder xmlsb = new StringBuilder();
        xmlsb.Append("<xml>");
        ModelToXml<T>(model, xmlsb);
        xmlsb.Append("</xml>");
        return xmlsb.ToString();
    }

    private static void ModelToXml<T>(T model, StringBuilder xmlsb)
    {
        Type type = typeof(T);
        var properties = type.GetProperties();
        PropertyToXmlElement(model, xmlsb, properties);
    }

    private static void PropertyToXmlElement(object model, StringBuilder xmlsb, PropertyInfo[] properties)
    {
        foreach (PropertyInfo p in properties)
        {
            if (p.PropertyType.IsArray)
            {
                xmlsb.AppendFormat("<{0}>", p.Name);
              
                var parray = p.GetValue(model, null);
                Array arg = (Array)parray;
                foreach (var a in arg)
                {
                    xmlsb.Append("<item>");
                    Type ptype = a.GetType();
                    var pproperties = ptype.GetProperties();
                    PropertyToXmlElement(a, xmlsb, pproperties);
                    xmlsb.Append("</item>");
                }
              
                xmlsb.AppendFormat("</{0}>", p.Name);
            }
            else if (!p.PropertyType.IsValueType && p.PropertyType.IsClass && p.PropertyType.Name != "String")
            {
                xmlsb.AppendFormat("<{0}>", p.Name);
                Type ptype = p.PropertyType;
                var pproperties = ptype.GetProperties();//属性的属性
                var ppval = p.GetValue(model, null);//属性的值
                PropertyToXmlElement(ppval, xmlsb, pproperties);
                xmlsb.AppendFormat("</{0}>", p.Name);
            }
            else
            {
                xmlsb.AppendFormat("<{0}><![CDATA[{1}]]></{0}>", p.Name, p.GetValue(model, null));
            }
        }
    }
}
