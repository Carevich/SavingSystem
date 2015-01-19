using SavingSystem.Comon;

namespace SavingSystem.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProfileId { get; set; }

        public Profile Profile { get; set; }
    }
}