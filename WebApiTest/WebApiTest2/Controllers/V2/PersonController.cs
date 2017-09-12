using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiTest2.Controllers.V2
{
    public class PersonController : ApiController
    {
        public string Get()
        {
            return "我是版本V2！";
        }
    }
}
