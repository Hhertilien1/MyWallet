using System;
using System.Data;
using Dapper;
using MY_WALLET.Models;

namespace MY_WALLET
{
    public class FinancialTransactionsRepo : IFinancialTransactionsRepo
    {
        private readonly IDbConnection _conn;

        public FinancialTransactionsRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<FinancialTransactions> GetAllFinancialTransactions()
        {
            return _conn.Query<FinancialTransactions>("SELECT * FROM FinancialTransactions;");
        }

        public FinancialTransactions GetTransaction(int id)
        {
            return _conn.QuerySingle<FinancialTransactions>("SELECT * FROM FinancialTransactions WHERE TransactionID = @id", new { id = id });
        }

        public void UpdateTransaction(FinancialTransactions tranaction)
        {
            _conn.Execute("UPDATE FinancialTransactions SET TransactionType = @TransactionType, TransactionDate = @TransactionDate, Category = @Category, Amount = @Amount, Description = @Description WHERE TransactionID = @id",
            new { TransactionDate = tranaction.TransactionDate, TransactionType = tranaction.TransactionType, id = tranaction.TransactionID, Category = tranaction.Category, Amount = tranaction.Amount });
        }
    }
}

