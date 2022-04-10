using Microsoft.AspNetCore.Mvc;
using NetcareDoctorsClient.BLL.BLLClasses;
using NetcareDoctorsClient.BLL.DataContract;
using NetcareDoctorsClient.Controllers.ControllerHelpers;
using NetcareDoctorsClient.Filters;
using NetcareDoctorsClient.Models.DoctorProfile;

namespace NetcareDoctorsClient.Controllers
{
    [ResponseCache(NoStore = true, Duration = 0, Location = ResponseCacheLocation.None, VaryByHeader = "*")]
    [SessionTimeOut]
    public class GeneralUserDoctorsProfileController : Controller
    {
        private readonly TitleBLL TitleBLL;
        private readonly DisciplineBLL DisciplineBLL;
        private readonly ProvinceBLL ProvinceBLL;
        private readonly DoctorProfileBLL DoctorProfileBLL;
        private readonly DoctorsProfileHelper DoctorsProfileHelper;
        private readonly SharedHelper SharedHelper;

        public GeneralUserDoctorsProfileController(IHttpClientFactory httpClientFactory)
        {
            TitleBLL = new(httpClientFactory);
            DisciplineBLL = new(httpClientFactory);
            ProvinceBLL = new(httpClientFactory);
            DoctorProfileBLL = new(httpClientFactory);
            DoctorsProfileHelper = new();
            SharedHelper = new();
        }

        [HttpGet]
        public IActionResult DoctorsProfile()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> SearchDoctorsProfile()
        {
            ViewBag.Titles = SharedHelper.FillTitles(await TitleBLL.GetTitles(), "All Titles");
            ViewBag.Disciplines = SharedHelper.FillDisciplines(await DisciplineBLL.GetDisciplines(), "All Disciplines");
            ViewBag.Provinces = SharedHelper.FillProvinces(await ProvinceBLL.GetProvinces(), "All Provinces");

            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SearchDoctorsProfile(SearchDoctorsProfileModel model)
        {
            List<DoctorProfileResp> doctorProfileResps = await DoctorProfileBLL.
            GetDoctorProfileByCriteria(model.IdNo, model.TitleName, model.FirstName, model.LastName, model.HpcsaNo, model.DisciplineName, model.ProvinceName);

            if (!doctorProfileResps.Any())
                ViewBag.GridViewMessage = "Search yielded no results...";

            return PartialView("DoctorsProfileGrid", DoctorsProfileHelper.FillDoctorsProfileGridModel(doctorProfileResps));
        }
    }
}
