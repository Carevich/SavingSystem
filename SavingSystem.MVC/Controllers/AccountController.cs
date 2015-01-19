using System;
using System.Net;
using System.Web.Mvc;
using SavingSystem.CustomDAL;

namespace SavingSystem.MVC.Controllers
{
    public class AccountController : Controller
    {

        //public ActionResult LogOn(string email, string password)
        //{
        //    foreach (var user in _db.ReadTable(profile, "Profiles"))
        //    {
        //        if (user.Password == password && user.Email == email)
        //        {
        //            Session["UserSession"] = user;
        //            ViewBag.UserName = user.FirstName;
        //            return Json("ok", JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //}


        //public ActionResult LogOut()
        //{
        //    Session.Remove("UserSession");
        //    if (Response.Cookies["SavSysCookie"] != null)
        //    {
        //        Response.Cookies["SavSysCookie"].Expires = DateTime.Now.AddDays(-1);
        //    }
        //    return RedirectToAction("Index", "Home");
        //}


        //public ActionResult Register()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Register(Profile newProfile)
        //{
        //    newProfile.RoleId = 2;
        //    newProfile.DateCreation = DateTime.Now;

        //    Profile prof = null;

        //    //var profiles = _db.ReadTable(prof, "Profiles");

        //    if (ModelState.IsValid)
        //    {
        //        //_db.InsertProfile(newProfile);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Register");
        //    }
        //    return View("mustAuthorize");
        //}

    }
}
