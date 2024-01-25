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
            _conn.Execute("UPDATE FinancialTransactions SET Amount = @Amount, Description = @Description, Category = @Category WHERE TransactionID = @id"
,
            new {id = tranaction.TransactionID, Description = tranaction.Description, Category = tranaction.Category, Amount = tranaction.Amount });
        }
    }
}

