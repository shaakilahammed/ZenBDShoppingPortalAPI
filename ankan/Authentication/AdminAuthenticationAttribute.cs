using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using ZenBD_API.Repositories;

namespace ZenBD_API.Authentication
{
    public class AdminAuthenticationAttribute:AuthorizationFilterAttribute
    {
        UserRepository userRepo = new UserRepository();
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string encodedString = actionContext.Request.Headers.Authorization.Parameter;
                int usertype = userRepo.Validdata(encodedString);
                if (usertype == 0)
                {

                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}