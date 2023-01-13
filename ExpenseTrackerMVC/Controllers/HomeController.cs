using ExpenseTrackerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTrackerMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<mvcCategoryModel> catList;
            HttpResponseMessage responses = GlobalVariables.WebApiClient.GetAsync("Category").Result;
            catList = responses.Content.ReadAsAsync<IEnumerable<mvcCategoryModel>>().Result;
            var catCount = catList.Count();
            ViewBag.CategoryCount = catCount;

            IEnumerable<ExpenseModelClass> expList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Expense").Result;
            expList = response.Content.ReadAsAsync<IEnumerable<ExpenseModelClass>>().Result;
            var expCount = expList.Count();
            ViewBag.expCount = expCount;

            IEnumerable<mvcLimitModel> limList;
            HttpResponseMessage res = GlobalVariables.WebApiClient.GetAsync("Limit").Result;
            limList = res.Content.ReadAsAsync<IEnumerable<mvcLimitModel>>().Result;
            var limit = limList.Sum(x => x.limit_amount);
            ViewBag.totlim = limit;

            CategoryList();
            ExpenseList();
            return View();
        }

        [ChildActionOnly]
        public ActionResult CategoryList()
        {
            IEnumerable<mvcCategoryModel> catList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Category").Result;
            catList = response.Content.ReadAsAsync<IEnumerable<mvcCategoryModel>>().Result;
            var catCount = catList.Sum(x => x.amount);
            ViewBag.totcat = catCount;
            return PartialView(catList);
        }

        [ChildActionOnly]
        public ActionResult ExpenseList()
        {
            IEnumerable<mvcCategoryModel> catList;
            HttpResponseMessage responses = GlobalVariables.WebApiClient.GetAsync("Category").Result;
            catList = responses.Content.ReadAsAsync<IEnumerable<mvcCategoryModel>>().Result;
            ViewBag.category = catList;

            IEnumerable<ExpenseModelClass> expList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Expense").Result;
            expList = response.Content.ReadAsAsync<IEnumerable<ExpenseModelClass>>().Result;
            //var expCount=expList.Count();
            var expCount = expList.Sum(x => x.expense_amount);
            ViewBag.totexp = expCount;
            return PartialView(expList);
        }



    }
}