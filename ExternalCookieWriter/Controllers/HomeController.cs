using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExternalCookieWriter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public RedirectResult SetSID()
        {
            var sessionIdToken = Request.QueryString["sidt"];

            var cookieValue = "Shazam";

            var cookie = new HttpCookie("SID", cookieValue)
            {
                Domain = "external.com"
            };

            Response.Cookies.Add(cookie);


            var uriBuilder = new UriBuilder(HttpUtility.UrlDecode(Request.QueryString["continueWith"]));

            return new RedirectResult(uriBuilder.ToString(), false);
        }
    }
}