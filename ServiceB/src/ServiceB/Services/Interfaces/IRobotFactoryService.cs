using ServiceB.Models;

namespace ServiceB.Services.Interfaces
{
    public interface IRobotFactoryService
    {
        Task<ResponseModel> Head_CreationAsync(string colour);
        Task<ResponseModel> Body_CreationAsync(string colour);
        Task<ResponseModel> Arm_CreationAsync(string colour);
        Task<ResponseModel> Lag_CreationAsync(string colour);
    }
}
