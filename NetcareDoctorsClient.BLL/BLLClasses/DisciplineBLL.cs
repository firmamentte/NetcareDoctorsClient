using NetcareDoctorsClient.BLL.DataContract;

namespace NetcareDoctorsClient.BLL.BLLClasses
{
    public class DisciplineBLL: SharedBLL
    {
        private readonly IHttpClientFactory HttpClientFactory;
        private readonly ApplicationUserBLL ApplicationUserBLL;

        public DisciplineBLL(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
            ApplicationUserBLL = new(HttpClientFactory);
        }

        public async Task<List<DisciplineResp>> GetDisciplines()
        {
            HttpClient _httpClient = CreateHttpClient(HttpClientFactory);
            _httpClient.DefaultRequestHeaders.Add("AccessToken", await ApplicationUserBLL.GetAccessToken());

            using HttpResponseMessage _httpResponseMessage = await _httpClient.GetAsync($"api/Discipline/V1/GetDisciplines");

            if (!_httpResponseMessage.IsSuccessStatusCode)
                throw new Exception(ConstructClientError(await _httpResponseMessage.Content.ReadAsAsync<ApiErrorResp>()));

            return await _httpResponseMessage.Content.ReadAsAsync<List<DisciplineResp>>();
        }
    }
}
