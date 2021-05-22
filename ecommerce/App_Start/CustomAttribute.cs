using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerce.App_Start
{
    public class AdminSessionExpire : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["UserID"] == null)
            {

                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.StatusCode = 401;
                    filterContext.Result = new JsonResult
                    {
                        Data = new
                        {
                            Error = "NotAuthorized",
                            LogOnUrl = "~/AccountLog/Logout"
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                    filterContext.HttpContext.Response.End();
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/AccountLog/Logout");
                }
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}