using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceB.Models;
using ServiceB.Services.Interfaces;

namespace ServiceB.Controllers
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

        [HttpPost]
        public async Task<ResponseModel> HeadCreation(RequestModel model)
        {
            return await service.Head_CreationAsync(model.colour);
        }

        [HttpPost]
        public async Task<ResponseModel> BodyCreation(RequestModel model)
        {
            return await service.Body_CreationAsync(model.colour);
        }

        [HttpPost]
        public async Task<ResponseModel> ArmCreation(RequestModel model)
        {
            return await service.Arm_CreationAsync(model.colour);
        }

        [HttpPost]
        public async Task<ResponseModel> LagCreation(RequestModel model)
        {
            return await service.Lag_CreationAsync(model.colour);
        }
    }
}
