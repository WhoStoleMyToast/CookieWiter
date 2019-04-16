using System;
using System.Linq;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;

namespace MainCookieWriter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public RedirectResult SetSID()
        {
            string sessionIdToken = Request.QueryString["sidt"];

            string cookieValue = "Shazam";

            HttpCookie cookie = new HttpCookie("SID", cookieValue)
            {
                Domain = "main.com"
            };
            HttpCookie cookie2 = new HttpCookie("SID2", cookieValue)
            {
                Domain = "vikki.main.com"
            };

            Response.Cookies.Add(cookie);
            Response.Cookies.Add(cookie2);

            UriBuilder uriBuilder = new UriBuilder(HttpUtility.UrlDecode(Request.QueryString["continueWith"]));

            return new RedirectResult(uriBuilder.ToString(), false);
        }

        public RedirectResult Login()
        {
            string[] domains = new string[]
            {
                "main.com",
                "accounts.external.com/Home/SetSID",
                "accounts.main.com/Home/SetSID"
                //"accounts.external.com/Home/SetSID",
                //"accounts.main.com/Home/SetSID",
                //"accounts.external.com/Home/SetSID",
                //"accounts.main.com/Home/SetSID",
                //"accounts.external.com/Home/SetSID",
                //"accounts.main.com/Home/SetSID",
                //"accounts.external.com/Home/SetSID",
                //"accounts.main.com/Home/SetSID",
                //"accounts.external.com/Home/SetSID",
                //"accounts.main.com/Home/SetSID",
                //"accounts.external.com/Home/SetSID",
                //"accounts.main.com/Home/SetSID",
                //"accounts.external.com/Home/SetSID",
                //"accounts.main.com/Home/SetSID",
                //"accounts.external.com/Home/SetSID",
                //"accounts.main.com/Home/SetSID",
                //"accounts.external.com/Home/SetSID",
                //"accounts.main.com/Home/SetSID"
            };

            string sessionIdToken = Guid.NewGuid().ToString();

            string url = GetUrl(domains.Length - 1, domains, sessionIdToken);

            return new RedirectResult(url);
        }

        private string GetUrl(int index, string[] domains, string sessionIdToken)
        {
            UriBuilder ub = new UriBuilder();

            NameValueCollection uriValues = new NameValueCollection
            {
                { "sidt", sessionIdToken }
            };

            if (index > 0)
            {
                uriValues.Add("continueWith", GetUrl(index - 1, domains, sessionIdToken));
            }

            var uri = BuildUri(domains[index], uriValues);

            return uri.ToString();
        }

        private Uri BuildUri(string root, NameValueCollection query)
        {
            var collection = HttpUtility.ParseQueryString(string.Empty);

            foreach (var key in query.Cast<string>().Where(key => !string.IsNullOrWhiteSpace(query[key])))
            {
                collection[key] = query[key];
            }

            var builder = new UriBuilder(root) { Query = collection.ToString() };

            return builder.Uri;
        }
    }
}