using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SavingSystem.Models;

namespace SavingSystem.Comon
{
    public class Profile
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        
        public DateTime ? Birthday { get; set; }
        public DateTime DateCreation { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }
        public IEnumerable<ExpenseCategory> ExpenseCategories { get; set; }
        public IEnumerable<IncomeCategory> IncomeCategories { get; set; }
    }

}