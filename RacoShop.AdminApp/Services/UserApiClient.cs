using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RacoShop.ViewModel.Common;
using RacoShop.ViewModel.System.Users;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RacoShop.AdminApp.Services
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _iconfiguration;
        public UserApiClient(IHttpClientFactory httpClientFactory, IConfiguration iconfiguration)
        {
            _httpClientFactory = httpClientFactory;
            _iconfiguration = iconfiguration;
        }
        public async Task<string> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_iconfiguration["BaseAddress"]);
            var response = await client.PostAsync("/api/users/authenticate",httpContent );
            var token = await response.Content.ReadAsStringAsync();
            return token;
        }

        public async Task<PagedResult<UserVm>> GetUsersPaging(GetUsersPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_iconfiguration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", request.BearerToken);

            var response = await client.GetAsync($"/api/users/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}&keyword={request.Keyword}");

            var body = await response.Content.ReadAsStringAsync();

            var users = JsonConvert.DeserializeObject<PagedResult<UserVm>>(body);
            return users;
        }
    }
}
