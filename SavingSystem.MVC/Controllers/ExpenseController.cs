using System.Web.Mvc;

namespace SavingSystem.MVC.Controllers
{
    public class ExpenseController : Controller
    {
        //// Expense
        //public ActionResult ExpenseManagement()
        //{
        //    return View();
        //}

        //public ActionResult ViewExpenses()
        //{
        //    var profile = Session["UserSession"] as Profile;
        //    if (profile != null)
        //    {
        //        var result = _db.ViewExpenses(profile.Id);
        //        return View(result);
        //    }
        //    return View("mustAuthorize");
        //}

        //public ActionResult CreateExpense()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult CreateExpense(Expense newExpense)
        //{
        //    return RedirectToAction("ViewExpenses");
        //}

        //public ActionResult UpdateExpense(int id)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult UpdateExpense(Expense updateExpense)
        //{
        //    //_db.UpdateExpense(updateExpense);
        //    return RedirectToAction("ViewExpenses");
        //}

        //public ActionResult DeleteExpense(int id)
        //{
        //    //_db.DeleteExpense(id);
        //    return RedirectToAction("ViewExpenses");
        //}


        //// Expense Category
        //public ActionResult ViewExpenseCategories()
        //{
        //    return View();
        //}

        //public ActionResult CreateExpenseCategory()
        //{
        //    return View();
        //}

        //public ActionResult UpdateExpenseCategory()
        //{
        //    return View();
        //}

        //public ActionResult DeleteExpenseCategory()
        //{
        //    return View();
        //}

        //public ActionResult ViewExpenseCategoryByDate()
        //{
        //    return View();
        //}

        //public ActionResult ViewExpenseByCategory(ExpenseCategory category)
        //{
        //    var result = _db.ViewExpenses(1).Where(x => x.ExpenseCategory.Title == category.Title).ToList();
        //    return View("ViewExpense", result);
        //}
    }
}
