using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeChatDataRepository;

namespace WeChatBusiness
{
    public class GlobalBusiness
    {
        public static void AddGlobalError(string errortxt)
        {
            GlobalRepository _responsitory = new GlobalRepository();
            _responsitory.AddGlobalError(errortxt);
        }

    }
}
