using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace WebApiTest2
{
    public class VersionControllerselector:DefaultHttpControllerSelector
    {
        private HttpConfiguration _config;

        public VersionControllerselector(HttpConfiguration config):base(config)
        {
            this._config = config;
        }

        public override IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            Dictionary<string, HttpControllerDescriptor> dic = new Dictionary<string, HttpControllerDescriptor>();
            foreach (var item in _config.Services.GetAssembliesResolver().GetAssemblies())
            {
                var controllerTypes = item.GetTypes().Where(it => it.IsAbstract == false && typeof(ApiController).IsAssignableFrom(it));
                foreach (Type type in controllerTypes)
                {
                    var typeNs= type.Namespace;
                    var match = Regex.Match(typeNs, @"\.V(\d)");
                    if (!match.Success)
                    {
                        continue;
                    }
                    string version = match.Groups[1].Value;
                    string typeName = type.Name;
                    var matchControler = Regex.Match(typeName, @"^(.+)Controller$");
                    if (!matchControler.Success)
                    {
                        continue;
                    }
                    string ctrlName = matchControler.Groups[1].Value;

                    string key = ctrlName + "v" + version;
                    dic[key] = new HttpControllerDescriptor(_config, ctrlName, type);
                }
            }
            return dic;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var controller = GetControllerMapping();
            var routeData = request.GetRouteData();
            var controllerName = (string)routeData.Values["controller"];
            string verNum = Regex.Match(request.RequestUri.PathAndQuery, @"api/V(\d+)").Groups[1].Value;
            string key = controllerName + "v" + verNum;
            if (controller.ContainsKey(key))
            {
                return controller[key];
            }
            else
            {
                return null;
            }
        }
    }
}