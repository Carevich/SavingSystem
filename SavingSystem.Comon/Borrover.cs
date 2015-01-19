using System;

namespace SavingSystem.Comon
{
    public class Borrover
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public decimal Summ { get; set; }
        public string BorroverName { get; set; }
        public DateTime DateIssue { get; set; }
        public DateTime DateExpiration { get; set; }
        public string Comment { get; set; }

        public Profile Profile { get; set; }
    }
}