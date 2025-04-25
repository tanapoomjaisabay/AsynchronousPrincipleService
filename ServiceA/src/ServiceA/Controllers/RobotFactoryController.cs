using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceA.Models;
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
        public async Task<ResponseModel> CreateRobotWithSequence(string colour = "Red") 
        {
            return await service.CreateRobot(colour);
        }

        [HttpGet]
        public async Task<ResponseModel> CreateRobotWithParallel(string colour = "Green")
        {
            return await service.CreateRobotAsync(colour);
        }

        [HttpGet]
        public async Task<ResponseModel> ScheduleRobotCreation(string colour = "Blue")
        {
            return await service.ScheduleRobotCreationAsync(colour);
        }
    }
}
