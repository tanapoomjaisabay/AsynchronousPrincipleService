using ServiceA.Models;

namespace ServiceA.Services.Interfaces
{
    public interface IHttpConnectService
    {
        Task<ResponseModel> CallServiceBAsync(string url, string json);
    }
}
