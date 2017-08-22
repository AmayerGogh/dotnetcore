using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rumen.Models;
using Common;
using System.Reflection;
using System.Text;

namespace rumen.Controllers
{
    public class AttrTestController : Controller
    {
        public IActionResult Index()
        {
            StringBuilder sb = new StringBuilder();
            Person p = new Person();
            var info = p.GetType();
            PropertyInfo[] props = info.GetProperties();
            for (int i = 0; i < props.Length; i++)
            {
                sb.AppendLine(props[i].Name);
            }
            var att =(TestAttribute)Attribute.GetCustomAttribute(info, typeof(TestAttribute));
            return Content(att.Name+","+sb.ToString());
        }
    }
}