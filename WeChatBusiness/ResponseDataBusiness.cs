using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeChatDataRepository;
using WeChatORM;

namespace WeChatBusiness
{
    public class ResponseDataBusiness
    {
        ResponseDataRepository _respository = new ResponseDataRepository();
        /// <summary>
        /// 随机获取一个笑话
        /// </summary>
        /// <returns></returns>
        public string GetRandomJoke(bool withimg)
        {
            var jokedetail = GetJoke(withimg);
            string content = jokedetail.Content;
            if (!string.IsNullOrWhiteSpace(jokedetail.ImgUrl))
            {
                content += string.Format("<img src='{0}'/>", jokedetail.ImgUrl);
            }
            return content;
        }
        /// <summary>
        /// 获取一个随机的笑话
        /// </summary>
        /// <returns></returns>
        public JokeDetail GetJoke(bool withimg)
        {
            return _respository.GetJoke(withimg);
        }
    }
}
