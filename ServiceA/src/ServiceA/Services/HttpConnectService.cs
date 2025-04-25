using System.Text;
using ServiceA.Models;
using ServiceA.Services.Interfaces;

namespace ServiceA.Services
{
    public class HttpConnectService : IHttpConnectService
    {
        private readonly IConfiguration _configuration;

        public HttpConnectService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public async Task<ResponseModel> CallServiceBAsync(string url, string json)
        {
            using (var client = new HttpClient())
            {
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{_configuration["ServiceB:URL"]}RobotFactory/{url}", httpContent);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadFromJsonAsync<ResponseModel>();
                return content!;
            }
        }
    }
}
