using System;
using SavingSystem.Comon;

namespace SavingSystem.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public decimal Summ { get; set; }
        public int ExpenseCategoryId { get; set; }
        public DateTime DateCreation { get; set; }
        public string Comment { get; set; }

        public Profile Profile { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
    }
}