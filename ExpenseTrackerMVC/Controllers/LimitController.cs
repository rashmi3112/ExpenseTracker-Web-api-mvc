using ExpenseTrackerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTrackerMVC.Controllers
{
    public class LimitController : Controller
    {
        // GET: Limit
        public ActionResult Index()
        {
            IEnumerable<mvcLimitModel> limList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Limit").Result;
            limList = response.Content.ReadAsAsync<IEnumerable<mvcLimitModel>>().Result;
            return View(limList);
        }

        public ActionResult AddOrEditlim(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcLimitModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Limit/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcLimitModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEditlim(mvcLimitModel lim)
        {
            if (lim.limitId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Limit", lim).Result;
                TempData["SuccessMessage"] = "Expense limit added successfully";

            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Limit/" + lim.limitId, lim).Result;
                TempData["SuccessMessage"] = "Expense limit updated successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteLim(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Limit/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Expense limit deleted successfully";
            return RedirectToAction("Index");
        }
    }
}