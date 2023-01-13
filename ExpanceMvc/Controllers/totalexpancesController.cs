using ExpanceMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ExpanceMvc.Controllers
{
    public class totalexpancesController : Controller
    {
        // GET: totalexpances
        public ActionResult Index()
        {
            IEnumerable<totalexpances> totexplist;
            HttpResponseMessage response = GlobalVariables.ExpanceApiClient.GetAsync("totalexpances").Result;
            totexplist = response.Content.ReadAsAsync<IEnumerable<totalexpances>>().Result;
            return View(totexplist);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new totalexpances());
            else
            {
                HttpResponseMessage response = GlobalVariables.ExpanceApiClient.GetAsync("totalexpances/" + id.ToString()).Result;
                TempData["SuccessMessage"] = " Total Expance Inserted Successfully";
                return View(response.Content.ReadAsAsync<totalexpances>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(totalexpances totalexp)
        {
            if (totalexp.totexpid == 0)
            {
                HttpResponseMessage response = GlobalVariables.ExpanceApiClient.PostAsJsonAsync("totalexpances", totalexp).Result;
                TempData["SuccessMessage"] = " Total Expance Inserted Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.ExpanceApiClient.PutAsJsonAsync("totalexpances/" + totalexp.totexpid, totalexp).Result;
                TempData["SuccessMessage"] = " Total Expance Updated Successfully";
            }
            return RedirectToAction("Index");
        }
    }
}