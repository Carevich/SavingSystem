using System;
using SavingSystem.Comon;

namespace SavingSystem.Models
{
    public class Creditor
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public decimal Summ { get; set; }
        public string CreditorName { get; set; }
        public DateTime DateIssue { get; set; }
        public DateTime DateExpiration { get; set; }
        public string Comment { get; set; }

        public Profile Profile { get; set; }
    }
}