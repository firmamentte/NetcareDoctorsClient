using NetcareDoctorsClient.BLL.DataContract;

namespace NetcareDoctorsClient.BLL.BLLClasses
{
    public class TitleBLL : SharedBLL
    {
        private readonly IHttpClientFactory HttpClientFactory;
        private readonly ApplicationUserBLL ApplicationUserBLL;

        public TitleBLL(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
            ApplicationUserBLL = new(HttpClientFactory);
        }

        public async Task<List<TitleResp>> GetTitles()
        {
            HttpClient _httpClient = CreateHttpClient(HttpClientFactory);
            _httpClient.DefaultRequestHeaders.Add("AccessToken", await ApplicationUserBLL.GetAccessToken());

            using HttpResponseMessage _httpResponseMessage = await _httpClient.GetAsync($"api/Title/V1/GetTitles");

            if (!_httpResponseMessage.IsSuccessStatusCode)
                throw new Exception(ConstructClientError(await _httpResponseMessage.Content.ReadAsAsync<ApiErrorResp>()));

            return await _httpResponseMessage.Content.ReadAsAsync<List<TitleResp>>();
        }
    }
}
