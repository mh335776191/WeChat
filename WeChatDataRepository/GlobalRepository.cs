using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeChatORM;

namespace WeChatDataRepository
{
   public  class GlobalRepository
    {
       public void AddGlobalError(string errortxt)
       {
           using (var wxdb = new WXDBEntity())
           {
               wxdb.Global_Error.Add(new Global_Error { Content = errortxt });
               wxdb.SaveChanges();
           }
       }
    }
}
