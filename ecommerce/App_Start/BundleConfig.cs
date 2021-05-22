using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ecommerce.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/assets/css").Include(
                                       "~/assets/css/bootstrap.min.css",
                                       "~/assets/css/main.css",
                                       "~/assets/css/blue.css",
                                       "~/assets/css/owl.carousel.css",
                                       "~/assets/css/owl.transitions.css",
                                       "~/assets/css/animate.min.css",
                                       "~/assets/css/rateit.css",
                                       "~/assets/css/bootstrap-select.min.css",
                                       "~/assets/css/font-awesome.css"));

            //Admin Js
            bundles.Add(new ScriptBundle("~/assets/js").Include(
                                        "~/assets/js/jquery-1.11.1.min.js",
                                        "~/assets/js/bootstrap.min.js",
                                        "~/assets/js/bootstrap-hover-dropdown.min.js",
                                        "~/assets/js/owl.carousel.min.js",
                                        "~/assets/js/echo.min.js",
                                        "~/assets/js/jquery.easing-1.3.min.js",
                                        "~/assets/js/bootstrap-slider.min.js",
                                        "~/assets/js/jquery.rateit.min.js",
                                        "~/assets/js/lightbox.min.js",
                                        "~/assets/js/bootstrap-select.min.js",
                                        "~/assets/js/wow.min.js",
                                        "~/assets/js/scripts.js"
                                        ));
        }
    }
}