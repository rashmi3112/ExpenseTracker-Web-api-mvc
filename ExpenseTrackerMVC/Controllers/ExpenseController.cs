using ExpenseTrackerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTrackerMVC.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
        public ActionResult Index()
        {
            IEnumerable<mvcCategoryModel> catList;
            HttpResponseMessage responses = GlobalVariables.WebApiClient.GetAsync("Category").Result;
            catList = responses.Content.ReadAsAsync<IEnumerable<mvcCategoryModel>>().Result;
            ViewBag.category = catList;

            IEnumerable<ExpenseModelClass> expList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Expense").Result;
            expList = response.Content.ReadAsAsync<IEnumerable<ExpenseModelClass>>().Result;
            return View(expList);
        }

        public ActionResult AddOrEditExp(int id = 0)
        {
            IEnumerable<mvcExpenseModel> expList;
            HttpResponseMessage re = GlobalVariables.WebApiClient.GetAsync("Expense").Result;
            expList = re.Content.ReadAsAsync<IEnumerable<mvcExpenseModel>>().Result;

            IEnumerable<mvcCategoryModel> catList;
            HttpResponseMessage responses = GlobalVariables.WebApiClient.GetAsync("Category").Result;
            catList = responses.Content.ReadAsAsync<IEnumerable<mvcCategoryModel>>().Result;
            ViewBag.category = catList;

            IEnumerable<mvcLimitModel> limList;
            HttpResponseMessage res = GlobalVariables.WebApiClient.GetAsync("Limit").Result;
            limList = res.Content.ReadAsAsync<IEnumerable<mvcLimitModel>>().Result;
            var limit = limList.Sum(x => x.limit_amount);
            ViewBag.totlim = limit;
            if (id == 0)
            {
                return View(new mvcExpenseModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Expense/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcExpenseModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEditExp(mvcExpenseModel exp)
        {
            IEnumerable<mvcCategoryModel> catList;
            HttpResponseMessage responses = GlobalVariables.WebApiClient.GetAsync("Category").Result;
            catList = responses.Content.ReadAsAsync<IEnumerable<mvcCategoryModel>>().Result;
            ViewBag.category = catList;
            if (exp.expenseId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Expense", exp).Result;
                TempData["SuccessMessage"] = "Expense added successfully";

            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Expense/" + exp.expenseId,exp).Result;
                TempData["SuccessMessage"] = "Expense updated successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExp(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Expense/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Expense deleted successfully";
            return RedirectToAction("Index");
        }

    }
}