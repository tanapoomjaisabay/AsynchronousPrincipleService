using ServiceA.Models;

namespace ServiceA.Services.Interfaces
{
    public interface IRobotFactoryService
    {
        Task<ResponseModel> CreateRobot(string colour);
        Task<ResponseModel> CreateRobotAsync(string colour);
        Task<ResponseModel> ScheduleRobotCreationAsync(string colour);
    }
}
