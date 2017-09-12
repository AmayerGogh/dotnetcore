using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiTest.Controllers
{
    [RoutePrefix("api")]
    public class DogController : ApiController
    {
        [Route("GetTime")]
        public string Get()
        {
            return DateTime.Now.ToLocalTime().ToString();
        }

        [Route("Login/{username}/{password}")]
        public bool Get(string username,string password)
        {
            if (username == "admin" && password == "123")
            {
                return true;
            }
            return false;
        }
    }
}
