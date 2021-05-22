using ecommerce.App_Start;
using ecommerce.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ecommerce
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            Context.Response.Clear();
            Context.ClearError();
            var httpException = ex as HttpException;
            RequestContext requestContext = ((MvcHandler)Context.CurrentHandler).RequestContext;
            if (requestContext.HttpContext.Request.IsAjaxRequest())
            {
                Context.Response.Write("Ajax request failed due to server error!");
                Context.Response.End();
            }
            else
            {
                var routeData = new RouteData();
                routeData.Values["controller"] = "Error";
                routeData.Values["action"] = "NotFound";
                routeData.Values.Add("url", Context.Request.Url.OriginalString);
                if (httpException != null)
                {
                    switch (httpException.GetHttpCode())
                    {
                        case 404:
                            routeData.Values["action"] = "Fire404Error";
                            break;
                        case 403:
                            routeData.Values["action"] = "Errors500error";
                            break;
                        case 500:
                            routeData.Values["action"] = "Errors500error";
                            break;
                        default:
                            routeData.Values.Add("action", "NotFound");
                            break;
                    }
                }
                IController controller = new ErrorController();
                controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
            }
        }
    }
}
