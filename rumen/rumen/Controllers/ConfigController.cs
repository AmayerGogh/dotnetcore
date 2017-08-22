using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace rumen.Controllers
{
    public class ConfigController : Controller
    {
        public IActionResult Index()
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configRoot = config.Build();
            var name = configRoot.GetSection("connStr").GetSection("name").Value;
            var value = configRoot.GetSection("connStr").GetSection("value").Value;
            return Content(name+","+value);
        }
    }
}