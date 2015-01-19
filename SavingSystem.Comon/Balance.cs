using System;
using SavingSystem.Comon;

namespace SavingSystem.Models
{
    public class Balance
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public decimal Summ { get; set; }
        public DateTime DateCreation { get; set; }

        public Profile Profile { get; set; }
    }
}