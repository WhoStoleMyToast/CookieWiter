using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Main.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpCookieCollection cookieCollection = Request.Cookies;

            IList<HttpCookie> cookies = new List<HttpCookie>();

            for (int i = 0; i < cookieCollection.Count; i++)
            {
                cookies.Add(cookieCollection[i]);
            }

            ViewBag.Cookies = cookies;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}