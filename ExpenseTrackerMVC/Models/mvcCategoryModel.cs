using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpenseTrackerMVC.Models
{
    public class mvcCategoryModel
    {
        public int categoryId { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        public string categoryName { get; set; }

        [Required(ErrorMessage = "Amount for category is required")]
        public double amount { get; set; }

        public virtual ICollection<mvcExpenseModel> Expenses { get; set; }
    }
}