using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ecommerce.Controllers
{
    public class ErrorController : Controller
    {        
        public ActionResult Fire404Error()
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            ViewBag.Satus = Response.StatusDescription;
            //ViewBag.URL = RouteData.Values["url"].ToString();
            return View();
        }
        public ActionResult Errors500error()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            ViewBag.Message = "Error occured!";
            return View();
        }
        public ActionResult NotFound()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            ViewBag.Message = "Error occured!";
            return View();
        }
    }
}