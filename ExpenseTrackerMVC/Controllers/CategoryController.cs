using ExpenseTrackerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTrackerMVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            IEnumerable<mvcCategoryModel> catList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Category").Result;
            catList = response.Content.ReadAsAsync<IEnumerable<mvcCategoryModel>>().Result;
            return View(catList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcCategoryModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Category/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcCategoryModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcCategoryModel cat)
        {
            if (cat.categoryId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Category", cat).Result;
                TempData["SuccessMessage"] = "Category added successfully";
                
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Category/"+cat.categoryId,cat).Result;
                TempData["SuccessMessage"] = "Category updated successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Category/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }

    }
}