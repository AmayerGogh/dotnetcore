using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Common;

namespace rumen.Controllers
{
    public class DatabaseController : Controller
    {
        public IActionResult Index()
        {
            string connStr = "Data Source = .; User ID = stronger ; Password = 123 ; Initial Catalog = test";
            string sql = "insert into Persons(name,age) values('zz',123)";
            int res = SqlHelper.ExecuteNonQuery(connStr, sql);
            return Content(res.ToString());
        }
    }
}