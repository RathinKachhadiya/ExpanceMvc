    using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ExpanceMvc.Models;

namespace ExpanceMvc.Controllers
{
    public class categoriesController : Controller
    {
        // GET: categories
        public ActionResult Index()
        {
            IEnumerable<category> catlist;
            HttpResponseMessage response = GlobalVariables.ExpanceApiClient.GetAsync("categories").Result;
            catlist = response.Content.ReadAsAsync<IEnumerable<category>>().Result;
            return View(catlist);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new category());
            else
            {
                HttpResponseMessage response = GlobalVariables.ExpanceApiClient.GetAsync("categories/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<category>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(category cat)
        {
            if (cat.catid == 0)
            {
                HttpResponseMessage response = GlobalVariables.ExpanceApiClient.PostAsJsonAsync("categories", cat).Result;
                TempData["SuccessMessage"] = " Category Inserted Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.ExpanceApiClient.PutAsJsonAsync("categories/" + cat.catid, cat).Result;
                TempData["SuccessMessage"] = " Category Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.ExpanceApiClient.DeleteAsync("categories/" + id.ToString()).Result;
            TempData["SuccessMessage"] = " Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}