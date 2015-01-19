using System;
using System.Web.Mvc;
using SavingSystem.MsSQLRepository;

namespace SavingSystem.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var iRepo = new IncomeModelRepository();
            var t = iRepo.GetByDate(1, DateTime.Parse("2014-07-15"), DateTime.Parse("2014-07-19"));
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}
