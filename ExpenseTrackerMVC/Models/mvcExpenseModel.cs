using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpenseTrackerMVC.Models
{
    public class mvcExpenseModel
    {
        public int expenseId { get; set; }

        [Required(ErrorMessage = "Expense title is required")]
        public string title { get; set; }
        public string description { get; set; }

        [Required(ErrorMessage = "Amount spent is required")]
        public double expense_amount { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public Nullable<System.DateTime> date { get; set; }

        [Required(ErrorMessage = "Please select the category")]
        public int categoryId { get; set; }

        public virtual mvcCategoryModel Category { get; set; }
    }
}
