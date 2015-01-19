using System;
using SavingSystem.Comon.Attributes;

namespace SavingSystem.Comon.Mapping_Model
{
    [TableName("Incomes")]
    public class IncomeModel
    {
        [ColumnName("Id")]
        public int Id { get; set; }
        [ColumnName("Summ")]
        public decimal Summ { get; set; }
        [ColumnName("Title")]
        public string CategoryName { get; set; }
        [ColumnName("DateCreation")]
        public DateTime DateCreation { get; set; }
        [ColumnName("Comment")]
        public string Comment { get; set; }
    }
}
