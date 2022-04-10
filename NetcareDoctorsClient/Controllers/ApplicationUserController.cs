using Microsoft.AspNetCore.Mvc;
using NetcareDoctorsClient.BLL.BLLClasses;
using NetcareDoctorsClient.BLL.DataContract;
using NetcareDoctorsClient.Controllers.ControllerHelpers;
using NetcareDoctorsClient.Models.ApplicationUser;

namespace NetcareDoctorsClient.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly ApplicationUserBLL ApplicationUserBLL;
        private readonly SharedHelper SharedHelper;

        public ApplicationUserController(IHttpClientFactory httpClientFactory)
        {
            ApplicationUserBLL = new(httpClientFactory);
            SharedHelper = new();
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignUp(SignUpModel model)
        {
            await ApplicationUserBLL.SignUp(new SignUpReq()
            {
                Username = model.EmailAddress,
                UserPassword = model.UserPassword
            });

            return PartialView("_Ok", SharedHelper.FillOkModel("Congrats...! You have Signed Up successful, Please use your Email Address and Password to Sign in", StaticClass.EnumHelper.GetEnumDescription(StaticClass.EnumHelper.MessageSymbol.Information)));
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignIn(SignInModel model)
        {
            SignInResp signInResp = await ApplicationUserBLL.SignIn(new SignInReq()
            {
                Username = model.EmailAddress,
                UserPassword = model.UserPassword
            });

            HttpContext.Session.SetString("Username", signInResp.Username);

            if (signInResp.ApplicationUserType == StaticClass.EnumHelper.GetEnumDescription(StaticClass.EnumHelper.ApplicationUserType.Administrator))
            {
                return Json(new { RedirectToUrl = Url.Action("ManageDoctorsProfile", "AdministratorDoctorsProfile") });
            }
            else
            {
                return Json(new { RedirectToUrl = Url.Action("DoctorsProfile", "GeneralUserDoctorsProfile") });
            }
        }

        [HttpGet]
        public ActionResult UserSignOut()
        {
            HttpContext.Session.Clear();

            return RedirectToActionPermanent("Home", "ApplicationUser");
        }
    }
}