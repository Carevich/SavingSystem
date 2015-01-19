using System.Web;
using System.Web.Mvc;

namespace SavingSystem.MVC.Domain
{
    public class SavSysAuthorizeAttribute : AuthorizeAttribute
    {
        private string[] _roles;
        public SavSysAuthorizeAttribute(params string[] listRoles)
        {
            _roles = listRoles;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //bool resultUserLogin = SavSysAuthentication.IsLogin(_roles);
            //var url = new UrlHelper(filterContext.RequestContext);
            //if (resultUserLogin != true)
            //{
            //    HttpContext.Current.Response.Redirect(url.Action("LogOn", "Account"));
            //}
        }
    }
}