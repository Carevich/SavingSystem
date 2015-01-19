using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using SavingSystem.Comon;
using SavingSystem.Models.Mapping_Model;
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
            var builder = new QueryManager();
            var income = new Income
            {
                DateCreation = DateTime.Now,
                Summ = 120,
                ProfileId = 1
            };

            IList<PropertyInfo> props = income.GetType().GetProperties();

            var test = repo.GetAll(1);

            //string select1 = builder.GenerateSelectAllQuery(income, ref props);
            //string select2 = builder.GenerateSelectAllQuery(income, ref props, 1);
            //string select3 = builder.GenerateSelectAllQuery(income, ref props, 1, 2);
            //string update = builder.GenerateUpdateQuery(income, 1);
            //string delete = builder.GenerateDeleteQuery(income, 1);


            return View();
        }
    }
}
