using NetcareDoctorsClient.BLL.DataContract;

namespace NetcareDoctorsClient.BLL.BLLClasses
{
    public class ProvinceBLL: SharedBLL
    {
        private readonly IHttpClientFactory HttpClientFactory;
        private readonly ApplicationUserBLL ApplicationUserBLL;

        public ProvinceBLL(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
            ApplicationUserBLL = new(HttpClientFactory);
        }

        public async Task<List<ProvinceResp>> GetProvinces()
        {
            HttpClient _httpClient = CreateHttpClient(HttpClientFactory);
            _httpClient.DefaultRequestHeaders.Add("AccessToken", await ApplicationUserBLL.GetAccessToken());

            using HttpResponseMessage _httpResponseMessage = await _httpClient.GetAsync($"api/Province/V1/GetProvinces");

            if (!_httpResponseMessage.IsSuccessStatusCode)
                throw new Exception(ConstructClientError(await _httpResponseMessage.Content.ReadAsAsync<ApiErrorResp>()));

            return await _httpResponseMessage.Content.ReadAsAsync<List<ProvinceResp>>();
        }
    }
}
