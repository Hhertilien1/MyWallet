using System;
using MY_WALLET.Models;

namespace MY_WALLET
{
	public interface IFinancialTransactionsRepo
	{
        public IEnumerable<FinancialTransactions> GetAllFinancialTransactions();
        public FinancialTransactions GetTransaction(int id);
        public void UpdateTransaction(FinancialTransactions tranaction);
        public void InsertTransaction(FinancialTransactions transactionToInsert);

    }



}

