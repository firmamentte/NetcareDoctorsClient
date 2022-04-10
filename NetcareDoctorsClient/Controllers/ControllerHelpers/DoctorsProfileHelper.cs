using NetcareDoctorsClient.BLL.DataContract;
using NetcareDoctorsClient.Models.DoctorProfile;

namespace NetcareDoctorsClient.Controllers.ControllerHelpers
{
    public class DoctorsProfileHelper
    {
        public List<DoctorsProfileGridModel> FillDoctorsProfileGridModel(List<DoctorProfileResp> doctorProfileResps)
        {
            List<DoctorsProfileGridModel> _model = new();

            doctorProfileResps ??= new();

            foreach (var doctorProfileResp in doctorProfileResps.OrderBy(item => item.FirstName)
                                                                .ThenBy(item => item.LastName))
            {
                _model.Add(new DoctorsProfileGridModel()
                {
                    DisciplineName = doctorProfileResp.DisciplineName,
                    LastName = doctorProfileResp.LastName,
                    FirstName = doctorProfileResp.FirstName,
                    DoctorProfileId = doctorProfileResp.DoctorProfileId,
                    HpcsaNo = doctorProfileResp.HpcsaNo,
                    IdNo = doctorProfileResp.IdNo,
                    ProvinceName = doctorProfileResp.ProvinceName,
                    TitleName = doctorProfileResp.TitleName
                });
            }

            return _model;
        }

        public List<DoctorsProfileGridModel> FillDoctorsProfileGridModel(DoctorProfileResp doctorProfileResp)
        {
            List<DoctorsProfileGridModel> _model = new();

            _model.Add(new DoctorsProfileGridModel()
            {
                DisciplineName = doctorProfileResp.DisciplineName,
                LastName = doctorProfileResp.LastName,
                FirstName = doctorProfileResp.FirstName,
                DoctorProfileId = doctorProfileResp.DoctorProfileId,
                HpcsaNo = doctorProfileResp.HpcsaNo,
                IdNo = doctorProfileResp.IdNo,
                ProvinceName = doctorProfileResp.ProvinceName,
                TitleName = doctorProfileResp.TitleName
            });

            return _model;
        }

        public EditDoctorProfileModel FillEditDoctorProfileModel(DoctorProfileResp doctorProfileResp)
        {
            return new EditDoctorProfileModel()
            {
                DoctorProfileId=doctorProfileResp.DoctorProfileId,
                DisciplineName = doctorProfileResp.DisciplineName,
                LastName = doctorProfileResp.LastName,
                FirstName = doctorProfileResp.FirstName,
                HpcsaNo = doctorProfileResp.HpcsaNo,
                IdNo = doctorProfileResp.IdNo,
                ProvinceName = doctorProfileResp.ProvinceName,
                TitleName = doctorProfileResp.TitleName
            };
        }
    }
}
