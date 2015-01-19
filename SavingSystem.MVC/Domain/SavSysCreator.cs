using System.Collections.Generic;
namespace SavingSystem.MVC.Domain
{
    public class SavSysCreator
    {
        //public void CreateDefaultIncomeCategoryToProfile(int idProfile)
        //{
        //    var categories = new List<IncomeCategory>();
        //    string[] catName = { "Питание", "Проезд", "Здоровье", "Отдых", 
        //                           "Работа", "Ребенок", "Одежда", "Коммуналка" };
        //    foreach (var c in catName)
        //    {
        //        categories.Add(new IncomeCategory() { ProfileId = idProfile, Title = c });
        //    }
        //    LayerConnectDb db = new LayerConnectDb();
        //    foreach (var c in categories)
        //    {
        //        //db.InsertIncomeCategory(c);
        //    }
        //}

        //public void CreateDefaultExpenseCategoryToProfile(int idProfile)
        //{
        //    var categories = new List<ExpenseCategory>();
        //    string[] catName = { "" };
        //    foreach (var c in catName)
        //    {
        //        categories.Add(new ExpenseCategory() { ProfileId = idProfile, Title = c });
        //    }
        //    LayerConnectDb db = new LayerConnectDb();
        //    foreach (var c in categories)
        //    {
        //        //db.InsertExpenseCategory(c);
        //    }
        //}

        public void SetDefaultRoleToProfile()
        {

        }

        public void CreateBalanceOnceDay()
        {

        }
    }
}