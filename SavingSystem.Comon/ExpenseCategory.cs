namespace SavingSystem.Comon
{
    public class ExpenseCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ProfileId { get; set; }

        public Profile Profile { get; set; }
    }
}