using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MY_WALLET.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MY_WALLET.Controllers
{
    public class FinancialTransactionsController : Controller
    {
        private readonly IFinancialTransactionsRepo repo;

        public FinancialTransactionsController(IFinancialTransactionsRepo repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var transactions = repo.GetAllFinancialTransactions();
            return View(transactions);
        }

        public IActionResult ViewTransaction(int id)
        {
            var transaction = repo.GetTransaction(id);
            return View(transaction);
        }

        public IActionResult UpdateTransaction(int id)
        {
            FinancialTransactions ta = repo.GetTransaction(id);
            if (ta == null)
            {
                return View("TransactionNotFound");
            }
            return View(ta);
        }

        public IActionResult UpdateTransactionToDatabase(FinancialTransactions transaction)
        {
            repo.UpdateTransaction(transaction);

            return RedirectToAction("ViewTransaction", new { id = transaction.TransactionID });
        }

        public IActionResult InsertTransactionToDatabase(FinancialTransactions transactionToInsert)
        {
            repo.InsertTransaction(transactionToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult InsertTransaction(FinancialTransactions transactionToInsert)
        {
            return View(transactionToInsert);
        }

        public IActionResult DeleteTransaction(FinancialTransactions transaction)
        {
            repo.DeleteTransaction(transaction);
            return RedirectToAction("Index");
        }
    }
}

