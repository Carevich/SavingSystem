using System;
using SavingSystem.Comon.Attributes;
using SavingSystem.Models;

namespace SavingSystem.Comon
{
    [TableName("Incomes")]
    public class Income
    {
        public int Id { get; set; }
        [ColumnName("ProfileId", "ProfileId")]
        public int ProfileId { get; set; }
        [ColumnName("Summ", "Summ")]
        public decimal Summ { get; set; }
        [ColumnName("IncomeCategoryId", "IncomeCategoryId")]
        public int ? IncomeCategoryId { get; set; }
        [ColumnName("DateCreation", "DateCreation")]
        public DateTime DateCreation { get; set; }
        [ColumnName("Comment", "Comment")]
        public string Comment { get; set; }

        public Profile Profile { get; set; }
        public IncomeCategory IncomeCategory { get; set; }
    }
}