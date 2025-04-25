using ServiceB.Models;
using ServiceB.Services.Interfaces;

namespace ServiceB.Services
{
    public class RobotFactoryService : IRobotFactoryService
    {
        public RobotFactoryService() { }

        public async Task<ResponseModel> Head_CreationAsync(string colour = "Black")
        {
            var start = DateTime.Now;

            await Task.Delay(5000);

            return new ResponseModel
            {
                startTime = start,
                finishTime = DateTime.Now,
                result = $"Head is {colour}"
            };
        }

        public async Task<ResponseModel> Body_CreationAsync(string colour = "Black")
        {
            var start = DateTime.Now;

            await Task.Delay(10000);

            return new ResponseModel
            {
                startTime = start,
                finishTime = DateTime.Now,
                result = $"Body is {colour}"
            };
        }

        public async Task<ResponseModel> Arm_CreationAsync(string colour = "Black")
        {
            var start = DateTime.Now;

            await Task.Delay(5000);

            return new ResponseModel
            {
                startTime = start,
                finishTime = DateTime.Now,
                result = $"Arm is {colour}"
            };
        }

        public async Task<ResponseModel> Lag_CreationAsync(string colour = "Black")
        {
            var start = DateTime.Now;

            await Task.Delay(5000);

            return new ResponseModel
            {
                startTime = start,
                finishTime = DateTime.Now,
                result = $"Arm is {colour}"
            };
        }
    }
}
