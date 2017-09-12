using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiException.Controllers
{
    public class DefaultController : ApiController
    {
        public string Get(int id)
        {
            if (id == 0)
            {
                throw new Exception("cuowu");
            }
            else
            {
                return "hello" + id;
            }
        }
    }
}
