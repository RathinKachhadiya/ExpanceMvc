using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ExpanceMvc.Models;
namespace ExpanceMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<category> catlist;
            HttpResponseMessage response1 = GlobalVariables.ExpanceApiClient.GetAsync("categories").Result;
            catlist = response1.Content.ReadAsAsync<IEnumerable<category>>().Result;

            var Categories = catlist.ToList();
            if (Categories != null)
            {
                ViewBag.categories = Categories;
            }

            IEnumerable<totalexpances> totexplist;
            HttpResponseMessage response2 = GlobalVariables.ExpanceApiClient.GetAsync("totalexpances").Result;
            totexplist = response2.Content.ReadAsAsync<IEnumerable<totalexpances>>().Result;
            var totalexpances = totexplist.ToList();
            if (totalexpances != null)
            {
                ViewBag.totalexpances = totalexpances;
            }

            IEnumerable<expance> explist;
            HttpResponseMessage response = GlobalVariables.ExpanceApiClient.GetAsync("expances").Result;
            explist = response.Content.ReadAsAsync<IEnumerable<expance>>().Result;

            var Expances = explist.ToList();
            if (Expances != null)
            {
                ViewBag.expances = Expances;
            }

            int kj = 0;
            foreach (var i in explist)
            {
                kj += ((int)i.expamount);

            }
            ViewBag.kj = kj;
            return View();
        }
      
    }
}