using SavingSystem.Comon.Attributes;

namespace SavingSystem.Comon
{
    [TableName("IncomeCategories")]
    public class IncomeCategory
    {
        public int Id { get; set; }
        [ColumnName("Title")]
        public string Title { get; set; }
        public int ProfileId { get; set; }

        public Profile Profile { get; set; }
    }
}