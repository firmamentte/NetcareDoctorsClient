﻿using Microsoft.Extensions.Primitives;
using NetcareDoctorsClient.BLL.DataContract;

namespace NetcareDoctorsClient.BLL.BLLClasses
{
    public class ApplicationUserBLL : SharedBLL
    {
        private readonly IHttpClientFactory HttpClientFactory;

        public ApplicationUserBLL(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        private async Task<AuthenticateResp> Authenticate()
        {
            HttpClient _httpClient = CreateHttpClient(HttpClientFactory);

            using HttpResponseMessage _httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ApplicationUser/V1/Authenticate", string.Empty);

            if (!_httpResponseMessage.IsSuccessStatusCode)
                throw new Exception(ConstructClientError(await _httpResponseMessage.Content.ReadAsAsync<ApiErrorResp>()));

            _httpResponseMessage.Headers.TryGetValues("AccessToken", out IEnumerable<string> _accessToken);
            _httpResponseMessage.Headers.TryGetValues("AccessTokenExpiryDate", out IEnumerable<string> _accessTokenExpiryDate);

            return new AuthenticateResp()
            {
                AccessToken = _accessToken.FirstOrDefault(),
                ExpiryDate = Convert.ToDateTime(_accessTokenExpiryDate.FirstOrDefault())
            };
        }

        public async Task<string> GetAccessToken()
        {
            if (string.IsNullOrWhiteSpace(StaticClass.AccessToken))
            {
                AuthenticateResp _authenticateResp = await Authenticate();
                StaticClass.AccessToken = _authenticateResp.AccessToken;
            }

            return StaticClass.AccessToken;
        }

        public async Task SignUp(SignUpReq signUpReq)
        {
            HttpClient _httpClient = CreateHttpClient(HttpClientFactory);
            _httpClient.DefaultRequestHeaders.Add("AccessToken", await GetAccessToken());
            _httpClient.DefaultRequestHeaders.Add("Username", signUpReq.Username);
            _httpClient.DefaultRequestHeaders.Add("UserPassword", signUpReq.UserPassword);

            using HttpResponseMessage _httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ApplicationUser/V1/SignUp", string.Empty);

            if (!_httpResponseMessage.IsSuccessStatusCode)
                throw new Exception(ConstructClientError(await _httpResponseMessage.Content.ReadAsAsync<ApiErrorResp>()));
        }

        public async Task<SignInResp> SignIn(SignInReq signInReq)
        {
            HttpClient _httpClient = CreateHttpClient(HttpClientFactory);
            _httpClient.DefaultRequestHeaders.Add("AccessToken", await GetAccessToken());
            _httpClient.DefaultRequestHeaders.Add("Username", signInReq.Username);
            _httpClient.DefaultRequestHeaders.Add("UserPassword", signInReq.UserPassword);

            using HttpResponseMessage _httpResponseMessage = await _httpClient.PutAsJsonAsync("api/ApplicationUser/V1/SignIn", string.Empty);

            if (!_httpResponseMessage.IsSuccessStatusCode)
                throw new Exception(ConstructClientError(await _httpResponseMessage.Content.ReadAsAsync<ApiErrorResp>()));

            _httpResponseMessage.Headers.TryGetValues("Username", out IEnumerable<string> _username);
            _httpResponseMessage.Headers.TryGetValues("ApplicationUserType", out IEnumerable<string> _applicationUserType);

            return new SignInResp()
            {
                Username= _username.FirstOrDefault(),
                ApplicationUserType= _applicationUserType.FirstOrDefault()
            };
        }
    }
}
