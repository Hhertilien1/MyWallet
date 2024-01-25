using System;
namespace MY_WALLET.Models
{
	public class FinancialTransactions
	{
		public int TransactionID { get; set; }
		public DateTime TransactionDate  { get; set; }
		public string TransactionType { get; set; }
		public string Category { get; set; }
		public double Amount { get; set; }
		public string Description { get; set; }
	}
}