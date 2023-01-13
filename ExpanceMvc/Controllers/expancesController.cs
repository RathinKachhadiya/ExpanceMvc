using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ExpanceMvc.Models;

namespace ExpanceMvc.Controllers
{
    public class expancesController : Controller
    {
        // GET: expances
        public ActionResult Index()
        {
            IEnumerable<expance> explist;
            HttpResponseMessage response = GlobalVariables.ExpanceApiClient.GetAsync("expances").Result;
            explist = response.Content.ReadAsAsync<IEnumerable<expance>>().Result;
            return View(explist);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            IEnumerable<category> catlist;
            HttpResponseMessage response1 = GlobalVariables.ExpanceApiClient.GetAsync("categories").Result;
            catlist = response1.Content.ReadAsAsync<IEnumerable<category>>().Result;
            
            var Categories = catlist.ToList();
            if (Categories != null)
            {
                ViewBag.data = Categories;
            };
            if (id == 0)
                return View(new expance());
            else
            {
                HttpResponseMessage response = GlobalVariables.ExpanceApiClient.GetAsync("expances/" + id.ToString()).Result;
                TempData["SuccessMessage"] = " Expance Inserted Successfully";
                return View(response.Content.ReadAsAsync<expance>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(expance exp)
        {
            IEnumerable<category> catlist;
            HttpResponseMessage response1 = GlobalVariables.ExpanceApiClient.GetAsync("categories").Result;
            catlist = response1.Content.ReadAsAsync<IEnumerable<category>>().Result;

            var Categories = catlist.ToList();
            if (Categories != null)
            {
                ViewBag.data = Categories;
            }

            if (exp.expid == 0)
            {
                HttpResponseMessage response = GlobalVariables.ExpanceApiClient.PostAsJsonAsync("expances", exp).Result;
                TempData["SuccessMessage"] = " Expance Inserted Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.ExpanceApiClient.PutAsJsonAsync("expances/" + exp.expid, exp).Result;
                TempData["SuccessMessage"] = " Expance Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.ExpanceApiClient.DeleteAsync("expances/" + id.ToString()).Result;
            TempData["SuccessMessage"] = " Expance Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}