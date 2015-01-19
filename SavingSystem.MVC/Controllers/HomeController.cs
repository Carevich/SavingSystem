using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using SavingSystem.Comon;
using SavingSystem.MsSQLRepository;
using SavingSystem.QueryBuilder;

namespace SavingSystem.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            var repo = new IncomeRepository();
            var income = new Income
            {
                DateCreation = DateTime.Now,
                Summ = 120,
                ProfileId = 1, Comment = "test"
            };

            var incomeUpdated = new Income
            {
                Id = 5,
                DateCreation = DateTime.Parse("2014-07-17 00:00:00.000"),
                Summ = 1200,
                ProfileId = 1,
                Comment = "test updated"
            };

            var test1 = repo.GetAll(1);
            var test2 = repo.Get(1, 1);
            var test3 = repo.Add(1, income);
            var test4 = repo.Update(5, incomeUpdated);
            var test5 = repo.Delete(13, income);
            
                     

            return View();
        }
    }
}
