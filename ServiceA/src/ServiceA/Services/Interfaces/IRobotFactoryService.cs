namespace ServiceA.Services.Interfaces
{
    public interface IRobotFactoryService
    {
        Task<string> CreateRobot(string colour);
        Task<string> CreateRobotAsync(string colour);
        Task<string> ScheduleRobotCreationAsync(string colour);
    }
}
