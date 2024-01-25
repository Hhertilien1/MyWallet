using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
    }
}

