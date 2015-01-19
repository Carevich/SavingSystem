using System;
using SavingSystem.Comon.Attributes;
using SavingSystem.Models;

namespace SavingSystem.Comon
{
    [TableName("Incomes")]
    public class Income
    {
        public int Id { get; set; }
        [ColumnName("ProfileId")]
        public int ProfileId { get; set; }
        [ColumnName("Summ")]
        public decimal Summ { get; set; }
        [ColumnName("IncomeCategoryId")]
        public int? IncomeCategoryId { get; set; }
        [ColumnName("DateCreation")]
        public DateTime DateCreation { get; set; }
        [ColumnName("Comment")]
        public string Comment { get; set; }
        
        public Profile Profile { get; set; }
        public IncomeCategory IncomeCategory { get; set; }
    }
}