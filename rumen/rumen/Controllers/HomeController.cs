using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rumen.Models;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;

namespace rumen.Controllers
{
    public class HomeController : Controller
    {
        private ILogger logger;

        public HomeController(ILoggerFactory logFactory)
        {
            this.logger = logFactory.CreateLogger(typeof(HomeController));
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            logger.LogDebug("this is a debug message");
            logger.LogWarning("this is a warning");
            try
            {
                string a = null;
                return Content(a.ToString());
            }
            catch (Exception ex)
            {
                logger.LogError(new EventId(), ex, ex.Message);
            }

            HtmlEncoder encoder = HtmlEncoder.Default;
            var res = encoder.Encode("<p></p>");
            return Content(res);
        }
    }
}
