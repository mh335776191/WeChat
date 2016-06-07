using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeChatORM;

namespace WeChatDataRepository
{
    public class ResponseDataRepository
    {
        /// <summary>
        /// 随机取一个笑话
        /// </summary>
        /// <returns></returns>
        public JokeDetail GetJoke(bool withimg)
        {
            using (var jokedb = new WXDBEntity())
            {
                IQueryable<JokeDetail> joke;
                if (withimg)
                {
                    joke = jokedb.JokeDetail.Where(m => m.ImgUrl.Length > 0);
                }
                else
                {
                    joke = jokedb.JokeDetail.Where(m => m.ImgUrl.Length == 0);
                }
                var count = joke.Count();
                if (count > 0)
                {
                    var randnum = new Random().Next(count);
                    var jokedetail = joke.OrderBy(m => m.Id).Skip(randnum - 1).Take(1).FirstOrDefault();
                    return jokedetail;
                }
                return new JokeDetail { Content = "暂无笑话资源" };
            }
        }

    }
}
