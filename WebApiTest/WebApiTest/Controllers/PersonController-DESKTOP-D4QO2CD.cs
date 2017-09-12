using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiTest.Models;

namespace WebApiTest.Controllers
{
    public class PersonController : ApiController
    {
        public string[] Get()
        {
            return new string[] { "rupeng", "qq", "alibaba" };
        }

        public string Get(int id)
        {
            return "hehe" + id;
        }

        public int Get(string name)
        {
            return name.Length;
        }

        public async Task<string> GetPage(string url)
        {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetStringAsync("http://www.rupeng.com");
        }

        public string Post([FromBody]string value)
        {
            return "请求的value值为" + value;
        }

        public string Put(int id,[FromBody]string value)
        {
            return string.Format("更新id为{0}的值为value为{1}",id,value);
        }

        public string Delete(int id)
        {
            return string.Format("删除id为{0}的记录",id);
        }


        public bool Login(string username,string password)
        {
            if(username=="admin"&& password == "123")
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool Login2([FromBody]LoginModel model)
        {
            if ( model.UserName== "admin" && model.Password == "123")
            {
                return true;
            }
            return false;
        }


    }
}
