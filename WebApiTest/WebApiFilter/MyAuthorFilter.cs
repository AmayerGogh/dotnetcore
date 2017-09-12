using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApiFilter
{
    public class MyAuthorFilter : IAuthorizationFilter
    {
        public bool AllowMultiple => true;

        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            //throw new NotImplementedException();
            IEnumerable<string> username;
            if(!actionContext.Request.Headers.TryGetValues("UserName", out username))
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
           string name = username.First();
            if (name != "admin")
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            return await continuation();
        }
    }
}