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
    }
}

