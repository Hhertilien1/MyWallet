using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using Dapper;
using MY_WALLET.Models;
using Mysqlx.Crud;

namespace MY_WALLET
{
    public class FinancialTransactionsRepo : IFinancialTransactionsRepo
    {
        // This class represents a repository for financial transactions, providing methods to interact with the database.

        private readonly IDbConnection _conn;

        // Constructor for FinancialTransactionsRepo class.
        public FinancialTransactionsRepo(IDbConnection conn)
        {
            // Assigning the database connection to the private field _conn.
            _conn = conn;
        }

        // Retrieves all financial transactions from the database.
        public IEnumerable<FinancialTransactions> GetAllFinancialTransactions()
        {
            // Execute SQL query to select all rows from the FinancialTransactions table.
            return _conn.Query<FinancialTransactions>("SELECT * FROM FinancialTransactions;");
        }

        // Retrieves a specific financial transaction by its ID from the database.
        public FinancialTransactions GetTransaction(int id)
        {
            // Execute SQL query to select a single row from the FinancialTransactions table based on the provided ID.
            return _conn.QuerySingle<FinancialTransactions>("SELECT * FROM FinancialTransactions WHERE TransactionID = @id", new { id = id });
        }

        // Updates an existing financial transaction in the database.
        public void UpdateTransaction(FinancialTransactions tranaction)
        {
            // Execute SQL query to update a row in the FinancialTransactions table based on the provided transaction object.
            _conn.Execute("UPDATE FinancialTransactions SET Amount = @Amount, Description = @Description, Category = @Category WHERE TransactionID = @id",
                new { id = tranaction.TransactionID, Description = tranaction.Description, Category = tranaction.Category, Amount = tranaction.Amount });
        }

        // Inserts a new financial transaction into the database.
        public void InsertTransaction(FinancialTransactions transactionToInsert)
        {
            // Execute SQL query to insert a new row into the FinancialTransactions table with the provided transaction details.
            _conn.Execute("INSERT INTO FinancialTransactions (Amount, Description, Category, TransactionType, TransactionDate) VALUES (@Amount, @Description, @category, @TransactionType, @TransactionDate);",
                new { Amount = transactionToInsert.Amount, Description = transactionToInsert.Description, Category = transactionToInsert.Category, TransactionType = transactionToInsert.TransactionType, TransactionDate = transactionToInsert.TransactionDate });
        }

        // Deletes a financial transaction from the database.
        public void DeleteTransaction(FinancialTransactions transaction)
        {
            // Execute SQL query to delete a row from the FinancialTransactions table based on the provided transaction object's ID.
            _conn.Execute("DELETE FROM FinancialTransactions WHERE TransactionID = @id;", new { id = transaction.TransactionID });
        }

        // Retrieves all expenses from the database.
        public IEnumerable<FinancialTransactions> GetAllExpenses()
        {
            // Execute SQL query to select all rows from the FinancialTransactions table where TransactionType is 'Expense'.
            return _conn.Query<FinancialTransactions>("SELECT * FROM FinancialTransactions WHERE TransactionType = 'Expense'");
        }

        // Retrieves all income from the database.
        public IEnumerable<FinancialTransactions> GetAllIncome()
        {
            // Execute SQL query to select all rows from the FinancialTransactions table where TransactionType is 'Income'.
            return _conn.Query<FinancialTransactions>("SELECT * FROM FinancialTransactions WHERE TransactionType = 'Income'");
        }
    }
}


