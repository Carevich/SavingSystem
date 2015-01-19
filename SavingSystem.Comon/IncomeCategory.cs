using SavingSystem.Comon;

namespace SavingSystem.Models
{
    public class IncomeCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ProfileId { get; set; }

        public Profile Profile { get; set; }
    }
}