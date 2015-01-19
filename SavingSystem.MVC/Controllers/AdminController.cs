using System.Web.Mvc;
using SavingSystem.CustomDAL;

namespace SavingSystem.MVC.Controllers
{
    public class AdminController : Controller
    {
        // Role
        public ActionResult ViewRoles()
        {
            return View();
        }

        public ActionResult CreateRole()
        {
            return View();
        }

        public ActionResult UpdateRole()
        {
            return View();
        }

        public ActionResult DeleteRole()
        {
            return View();
        }

        public ActionResult ManageProfileRole()
        {
            return View();
        }
    }
}
