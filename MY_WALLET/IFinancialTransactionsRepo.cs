using System;
using MY_WALLET.Models;

namespace MY_WALLET
{
    public interface IFinancialTransactionsRepo
    {
        // Retrieves all financial transactions.
        public IEnumerable<FinancialTransactions> GetAllFinancialTransactions();

        // Retrieves a specific financial transaction by its ID.
        public FinancialTransactions GetTransaction(int id);

        // Updates an existing financial transaction.
        public void UpdateTransaction(FinancialTransactions tranaction);

        // Inserts a new financial transaction.
        public void InsertTransaction(FinancialTransactions transactionToInsert);

        // Deletes a financial transaction.
        public void DeleteTransaction(FinancialTransactions transaction);

        // Retrieves all expenses.
        public IEnumerable<FinancialTransactions> GetAllExpenses();

        // Retrieves all income.
        public IEnumerable<FinancialTransactions> GetAllIncome();
    }
}

