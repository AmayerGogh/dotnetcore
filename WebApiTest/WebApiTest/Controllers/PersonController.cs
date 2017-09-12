using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

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
    }
}
