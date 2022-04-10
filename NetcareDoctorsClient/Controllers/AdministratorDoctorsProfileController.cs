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
    public class AdministratorDoctorsProfileController : Controller
    {
        private readonly TitleBLL TitleBLL;
        private readonly DisciplineBLL DisciplineBLL;
        private readonly ProvinceBLL ProvinceBLL;
        private readonly DoctorProfileBLL DoctorProfileBLL;
        private readonly DoctorsProfileHelper DoctorsProfileHelper;
        private readonly SharedHelper SharedHelper;

        public AdministratorDoctorsProfileController(IHttpClientFactory httpClientFactory)
        {
            TitleBLL = new(httpClientFactory);
            DisciplineBLL = new(httpClientFactory);
            ProvinceBLL = new(httpClientFactory);
            DoctorProfileBLL = new(httpClientFactory);
            DoctorsProfileHelper = new();
            SharedHelper = new();
        }

        private string? GetUsernameFromSession
        {
            get
            {
                return HttpContext.Session.GetString("Username") ?? null;
            }
        }

        [HttpGet]
        public IActionResult ManageDoctorsProfile()
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

        [HttpGet]
        public async Task<ActionResult> CreateDoctorProfile()
        {
            ViewBag.Titles = SharedHelper.FillTitles(await TitleBLL.GetTitles(), "Select Title");
            ViewBag.Disciplines = SharedHelper.FillDisciplines(await DisciplineBLL.GetDisciplines(), "Select Discipline");
            ViewBag.Provinces = SharedHelper.FillProvinces(await ProvinceBLL.GetProvinces(), "Select Province");

            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateDoctorProfile(CreateDoctorProfileModel model)
        {
            DoctorProfileResp doctorProfileResp = await DoctorProfileBLL.CreateDoctorProfile(GetUsernameFromSession, new CreateDoctorProfileReq()
            {
                DisciplineName = model.DisciplineName,
                ProvinceName = model.ProvinceName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                HpcsaNo = model.HpcsaNo,
                IdNo = model.IdNo,
                TitleName = model.TitleName
            });

            return PartialView("DoctorsProfileGridRow", DoctorsProfileHelper.FillDoctorsProfileGridModel(doctorProfileResp));
        }

        [HttpGet]
        public async Task<ActionResult> EditDoctorProfile(Guid doctorProfileId)
        {
            ViewBag.Titles = SharedHelper.FillTitles(await TitleBLL.GetTitles(), "Select Title");
            ViewBag.Disciplines = SharedHelper.FillDisciplines(await DisciplineBLL.GetDisciplines(), "Select Discipline");
            ViewBag.Provinces = SharedHelper.FillProvinces(await ProvinceBLL.GetProvinces(), "Select Province");

            return PartialView(DoctorsProfileHelper.FillEditDoctorProfileModel(await DoctorProfileBLL.GetDoctorProfileByDoctorProfileId(doctorProfileId)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditDoctorProfile(EditDoctorProfileModel model)
        {
            DoctorProfileResp doctorProfileResp = await DoctorProfileBLL.EditDoctorProfile(GetUsernameFromSession, new EditDoctorProfileReq()
            {
                DoctorProfileId = model.DoctorProfileId,
                DisciplineName = model.DisciplineName,
                ProvinceName = model.ProvinceName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                HpcsaNo = model.HpcsaNo,
                IdNo = model.IdNo,
                TitleName = model.TitleName
            });

            return PartialView("DoctorsProfileGridRowLine", DoctorsProfileHelper.FillDoctorsProfileGridModel(doctorProfileResp));
        }

        [HttpPost]
        public async Task DeleteDoctorProfile(Guid actionValue)
        {
            await DoctorProfileBLL.DeleteDoctorProfile(GetUsernameFromSession, actionValue);
        }
    }
}
