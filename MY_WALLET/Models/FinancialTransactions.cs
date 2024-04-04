using System;
using System.ComponentModel.DataAnnotations;

namespace MY_WALLET.Models
{
	public class FinancialTransactions
	{
		public int TransactionID { get; set; } // Unique identifier for the financial transactions

        [Required(ErrorMessage = "Date is required")] // Date transaction was carried out
        public DateTime TransactionDate  { get; set; }


        [Required(ErrorMessage = "Transaction type is required")]
        [RegularExpression("^(Expense|Income)$", ErrorMessage = "Transaction Type must be 'Expense', or 'Income'")]
        public string TransactionType { get; set; } // Type of transaction (Expence, or Income)

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }// Category of transaction

        [Required(ErrorMessage = "Amount is required")]
        public double Amount { get; set; } // Amount of transaction

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } // Description to describe transaction
	}
}