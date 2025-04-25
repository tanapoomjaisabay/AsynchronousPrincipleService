using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceA.Services.Interfaces;

namespace ServiceA.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RobotFactoryController : ControllerBase
    {
        private readonly IRobotFactoryService service;

        public RobotFactoryController(IRobotFactoryService service)
        { 
            this.service = service;
        }

        [HttpGet]
        public async Task<string> CreateRobot(string colour = "Red") 
        {
            return await service.CreateRobot(colour);
        }

        [HttpGet]
        public async Task<string> CreateRobotAsync(string colour = "Green")
        {
            return await service.CreateRobotAsync(colour);
        }

        [HttpGet]
        public async Task<string> ScheduleRobotCreationAsync(string colour = "Blue")
        {
            return await service.ScheduleRobotCreationAsync(colour);
        }
    }
}
