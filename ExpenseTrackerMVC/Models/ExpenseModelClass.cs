using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpenseTrackerMVC.Models
{
    public class ExpenseModelClass
    {
        public int expenseId { get; set; }

        
        public string title { get; set; }
        public string description { get; set; }

        public double expense_amount { get; set; }

        
        public Nullable<System.DateTime> date { get; set; }

        public string categoryName { get; set; }

        public virtual mvcCategoryModel Category { get; set; }
    }
}