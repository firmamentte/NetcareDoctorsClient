using Microsoft.AspNetCore.Mvc;
using NetcareDoctorsClient.Controllers.ControllerHelpers;
using NetcareDoctorsClient.Filters;

namespace NetcareDoctorsClient.Controllers
{
    public class SharedController : Controller
    {
        private readonly SharedHelper SharedHelper;

        public SharedController()
        {
            SharedHelper = new();
        }

        [HttpGet]
        [SessionTimeOut]
        public ActionResult YesNo(string actionController, string actionMethod, string actionValue, string yesNoMessage)
        {
            return PartialView("_YesNo", SharedHelper.FillYesNoModel(actionController, actionMethod, actionValue, yesNoMessage));
        }

        [HttpGet]
        public ActionResult Ok(string okMessage, string messageSymbol)
        {
            return PartialView("_Ok", SharedHelper.FillOkModel(okMessage, messageSymbol));
        }

        [HttpGet]
        public ActionResult UserAccount()
        {
            return PartialView("_UserAccount");
        }
    }
}
