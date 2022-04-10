using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NetcareDoctorsClient.Filters
{
    public class SessionTimeOutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (string.IsNullOrWhiteSpace(context.HttpContext.Session.GetString("Username")))
            {
                context.Result = new RedirectResult("~/ApplicationUser/UserSignOut", true);
            }
            base.OnActionExecuting(context);
        }
    }
}
