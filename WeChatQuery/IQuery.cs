using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeChatQuery
{
    public interface IQuery<T>
    {
        T GetQueryResult(Dictionary<string, string> param);
    }
}
