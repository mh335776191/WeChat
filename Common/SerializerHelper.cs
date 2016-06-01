using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;


public static class SerializerHelper
{
    /// <summary>
    /// json字符串转换为对象
    /// </summary>
    /// <typeparam name="T">转换的类型</typeparam>
    /// <param name="json">待转化的json</param>
    /// <returns></returns>
    public static T ToModel<T>(this string json)
    {
        try
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            T model = js.Deserialize<T>(json);
            return model;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}
