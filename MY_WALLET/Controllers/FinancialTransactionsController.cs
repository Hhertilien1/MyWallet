using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MY_WALLET.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MY_WALLET.Controllers
{
    // FinancialTransactionsController handles HTTP requests related to financial transactions.

    public class FinancialTransactionsController : Controller
    {
        private readonly IFinancialTransactionsRepo repo;

        // Constructor for FinancialTransactionsController class.
        public FinancialTransactionsController(IFinancialTransactionsRepo repo)
        {
            // Assigning the repository instance passed as parameter to the private field 'repo'.
            this.repo = repo;
        }

        // Action method to display all financial transactions.
        public IActionResult Index()
        {
            // Retrieving all financial transactions from the repository.
            var transactions = repo.GetAllFinancialTransactions();
            return View(transactions);
        }

        // Action method to view details of a specific financial transaction.
        public IActionResult ViewTransaction(int id)
        {
            // Retrieving the financial transaction with the given ID from the repository.
            var transaction = repo.GetTransaction(id);
            return View(transaction);
        }

        // Action method to display the form for updating a financial transaction.
        public IActionResult UpdateTransaction(int id)
        {
            // Retrieving the financial transaction with the given ID from the repository.
            FinancialTransactions mytransaction = repo.GetTransaction(id);
            if (mytransaction == null)
            {
                // If the transaction is not found, return a view indicating that the transaction was not found.
                return View("TransactionNotFound");
            }
            return View(mytransaction);
        }

        // Action method to update a financial transaction in the database.
        [HttpPost]
        public IActionResult UpdateTransactionToDatabase(FinancialTransactions transaction)
        {
            // Checking if the model state is valid before proceeding with the update.
            if (ModelState.IsValid)
            {
                // Updating the financial transaction in the repository.
                repo.UpdateTransaction(transaction);
                return RedirectToAction("ViewTransaction", new { id = transaction.TransactionID });
            }
            // If model state is not valid, return to the update view with validation errors.
            return View("UpdateTransaction", transaction);
        }

        // Action method to display the form for inserting a new financial transaction.
        public IActionResult InsertTransaction()
        {
            return View();
        }

        // Action method to insert a new financial transaction into the database.
        [HttpPost]
        public IActionResult InsertTransactionToDatabase(FinancialTransactions transactionToInsert)
        {
            // Checking if the model state is valid before proceeding with the insertion.
            if (ModelState.IsValid)
            {
                // Inserting the new financial transaction into the repository.
                repo.InsertTransaction(transactionToInsert);
                return RedirectToAction("Index");
            }
            // If model state is not valid, return to the insert view with validation errors.
            return View("InsertTransaction", transactionToInsert);
        }

        // Action method to delete a financial transaction from the database.
        [HttpPost]
        public IActionResult DeleteTransaction(FinancialTransactions transaction)
        {
            // Deleting the financial transaction from the repository.
            repo.DeleteTransaction(transaction);
            return RedirectToAction("Index");
        }

        // Action method to display all income transactions.
        public IActionResult GetAllIncome()
        {
            // Retrieving all income transactions from the repository.
            var getIncome = repo.GetAllIncome();
            return View(getIncome);
        }

        // Action method to display all expense transactions.
        public IActionResult GetAllExpenses()
        {
            // Retrieving all expense transactions from the repository.
            var getExpenses = repo.GetAllExpenses();
            return View(getExpenses);
        }
    }
}