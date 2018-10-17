using ApiVitechd.Conector;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace ApiVitechd.Filters
{
    public class ValidateSession : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
            return;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string userName ="";
            string sessionKey="";
            
            var Paramas = context.HttpContext.Request.Query;
            if (Paramas.Keys.Contains("userName") && Paramas.Keys.Contains("sessionKey"))
            {
                 userName = Paramas["userName"];
                 sessionKey = Paramas["sessionKey"];
                try
                {
                    var values = new Dictionary<string, string>
                {
                   { "iam", userName },
                   { "sessionKey", sessionKey }
                };
                    ApiConnect api = new ApiConnect();
                    JToken jObjet = api.PostApi(values, "users", "users_confirm_session_vilidity");
                    var valid = (string)jObjet;
                    if (valid != "1")
                    {
                        context.Result = new UnauthorizedResult();

                    }
                }
                catch (Exception e)
                {
                    context.Result = new NotFoundObjectResult(e.Message);
                }

            }
            else
            {
                context.Result = new UnauthorizedResult();

            }
            return;
        }
    }
}
