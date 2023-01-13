using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpenseTrackerMVC.Models
{
    public class mvcLimitModel
    {
        public int limitId { get; set; }


        [Required(ErrorMessage = "Amount is required for setting the limit")] 
        public double limit_amount { get; set; }
    }
}