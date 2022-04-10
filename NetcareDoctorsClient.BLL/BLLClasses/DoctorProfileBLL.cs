using NetcareDoctorsClient.BLL.DataContract;

namespace NetcareDoctorsClient.BLL.BLLClasses
{
    public class DoctorProfileBLL : SharedBLL
    {
        private readonly IHttpClientFactory HttpClientFactory;
        private readonly ApplicationUserBLL ApplicationUserBLL;
        public DoctorProfileBLL(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
            ApplicationUserBLL = new(HttpClientFactory);
        }

        public async Task<DoctorProfileResp> CreateDoctorProfile(string username, CreateDoctorProfileReq createDoctorProfileReq)
        {
            HttpClient _httpClient = CreateHttpClient(HttpClientFactory);
            _httpClient.DefaultRequestHeaders.Add("AccessToken", await ApplicationUserBLL.GetAccessToken());
            _httpClient.DefaultRequestHeaders.Add("Username", username);

            using HttpResponseMessage _httpResponseMessage = await _httpClient.PostAsJsonAsync("api/DoctorProfile/V1/CreateDoctorProfile", createDoctorProfileReq);

            if (!_httpResponseMessage.IsSuccessStatusCode)
                throw new Exception(ConstructClientError(await _httpResponseMessage.Content.ReadAsAsync<ApiErrorResp>()));

            return await _httpResponseMessage.Content.ReadAsAsync<DoctorProfileResp>();
        }

        public async Task<DoctorProfileResp> EditDoctorProfile(string username, EditDoctorProfileReq editDoctorProfileReq)
        {
            HttpClient _httpClient = CreateHttpClient(HttpClientFactory);
            _httpClient.DefaultRequestHeaders.Add("AccessToken", await ApplicationUserBLL.GetAccessToken());
            _httpClient.DefaultRequestHeaders.Add("Username", username);

            using HttpResponseMessage _httpResponseMessage = await _httpClient.PutAsJsonAsync("api/DoctorProfile/V1/EditDoctorProfile", editDoctorProfileReq);

            if (!_httpResponseMessage.IsSuccessStatusCode)
                throw new Exception(ConstructClientError(await _httpResponseMessage.Content.ReadAsAsync<ApiErrorResp>()));

            return await _httpResponseMessage.Content.ReadAsAsync<DoctorProfileResp>();
        }

        public async Task DeleteDoctorProfile(string username, Guid doctorProfileId)
        {
            HttpClient _httpClient = CreateHttpClient(HttpClientFactory);
            _httpClient.DefaultRequestHeaders.Add("AccessToken", await ApplicationUserBLL.GetAccessToken());
            _httpClient.DefaultRequestHeaders.Add("Username", username);

            string _parameters = "?doctorProfileId=" + doctorProfileId;

            using HttpResponseMessage _httpResponseMessage = await _httpClient.DeleteAsync($"api/DoctorProfile/V1/DeleteDoctorProfile{_parameters}");

            if (!_httpResponseMessage.IsSuccessStatusCode)
                throw new Exception(ConstructClientError(await _httpResponseMessage.Content.ReadAsAsync<ApiErrorResp>()));
        }

        public async Task<DoctorProfileResp> GetDoctorProfileByDoctorProfileId(Guid doctorProfileId)
        {
            HttpClient _httpClient = CreateHttpClient(HttpClientFactory);
            _httpClient.DefaultRequestHeaders.Add("AccessToken", await ApplicationUserBLL.GetAccessToken());

            string _parameters = "?doctorProfileId=" + doctorProfileId;

            using HttpResponseMessage _httpResponseMessage = await _httpClient.GetAsync($"api/DoctorProfile/V1/GetDoctorProfileByDoctorProfileId{_parameters}");

            if (!_httpResponseMessage.IsSuccessStatusCode)
                throw new Exception(ConstructClientError(await _httpResponseMessage.Content.ReadAsAsync<ApiErrorResp>()));

            return await _httpResponseMessage.Content.ReadAsAsync<DoctorProfileResp>();
        }

        public async Task<List<DoctorProfileResp>> GetDoctorProfileByCriteria(
            string? idNo,
            string? titleName,
            string? firstname,
            string? lastname,
            string? hpcsaNo,
            string? disciplineName,
            string? provinceName)
        {
            HttpClient _httpClient = CreateHttpClient(HttpClientFactory);
            _httpClient.DefaultRequestHeaders.Add("AccessToken", await ApplicationUserBLL.GetAccessToken());

            string _parameters = "?idNo=" + idNo +
                                 "&titleName=" + titleName +
                                 "&firstname=" + firstname +
                                 "&lastname=" + lastname +
                                 "&hpcsaNo=" + hpcsaNo +
                                 "&disciplineName=" + disciplineName +
                                 "&provinceName=" + provinceName;

            using HttpResponseMessage _httpResponseMessage = await _httpClient.GetAsync($"api/DoctorProfile/V1/GetDoctorProfileByCriteria{_parameters}");

            if (!_httpResponseMessage.IsSuccessStatusCode)
                throw new Exception(ConstructClientError(await _httpResponseMessage.Content.ReadAsAsync<ApiErrorResp>()));

            return await _httpResponseMessage.Content.ReadAsAsync<List<DoctorProfileResp>>();
        }
    }
}
