using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ExpenseTrackerMVC.Models;
using ExpenseTrackerWebApi.Models;

namespace ExpenseTrackerWebApi.Controllers
{
    public class ExpenseController : ApiController
    {
        private expenseDbEntities db = new expenseDbEntities();

        // GET: api/Expense
        /*public IQueryable<Expense> GetExpenses()
        {
            return db.Expenses;
        }*/

        public IHttpActionResult GetExpense()
        {
            var expense=db.Expenses.Join(db.Categories, e => e.categoryId, c => c.categoryId, (e,c) => new {e,c} )
                .Select(ec => new ExpenseModelClass(){
                expenseId=ec.e.expenseId,
                    title = ec.e.title,
                    description = ec.e.description,
                    expense_amount = ec.e.expense_amount,
                    categoryName = ec.c.categoryName,
                    date= ec.e.date,
            }).ToList();
                
            return Ok(expense);
        }

        // GET: api/Expense/5
        [ResponseType(typeof(Expense))]
        public IHttpActionResult GetExpense(int id)
        {
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return NotFound();
            }

            return Ok(expense);
        }

        // PUT: api/Expense/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExpense(int id, Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expense.expenseId)
            {
                return BadRequest();
            }

            db.Entry(expense).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Expense
        [ResponseType(typeof(Expense))]
        public IHttpActionResult PostExpense(Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Expenses.Add(expense);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = expense.expenseId }, expense);
        }

        // DELETE: api/Expense/5
        [ResponseType(typeof(Expense))]
        public IHttpActionResult DeleteExpense(int id)
        {
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return NotFound();
            }

            db.Expenses.Remove(expense);
            db.SaveChanges();

            return Ok(expense);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExpenseExists(int id)
        {
            return db.Expenses.Count(e => e.expenseId == id) > 0;
        }
    }
}