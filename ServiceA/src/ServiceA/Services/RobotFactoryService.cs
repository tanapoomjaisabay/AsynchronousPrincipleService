using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using ServiceA.Models;
using ServiceA.Services.Interfaces;

namespace ServiceA.Services
{
    public class RobotFactoryService : IRobotFactoryService
    {
        private readonly IHttpConnectService _httpClient;

        public RobotFactoryService(IHttpConnectService httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseModel> CreateRobot(string colour)
        {
            string robotDetail = "";
            DateTime start = DateTime.Now;

            try
            {
                var stopwatch = Stopwatch.StartNew();

                var head = await Head_Creation(colour);
                var body = await Body_Creation(colour);
                var arm = await Arm_Creation(colour);
                var lag = await Lag_Creation(colour);

                robotDetail += head;
                robotDetail += ", " + body;
                robotDetail += ", " + arm;
                robotDetail += ", " + lag;
                stopwatch.Stop();
                var elapsedMs = stopwatch.ElapsedMilliseconds;

                return new ResponseModel
                {
                    result = $"Request took {elapsedMs / 1000} s",
                    robotDetail = robotDetail,
                    startTime = start,
                    finishTime = DateTime.Now
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    result = "Error, " + ex.Message,
                    robotDetail = "",
                    startTime = start,
                    finishTime = DateTime.Now
                };
            }
        }

        public async Task<ResponseModel> CreateRobotAsync(string colour)
        {
            string robotDetail = "";
            DateTime start = DateTime.Now;

            try
            {
                var stopwatch = Stopwatch.StartNew();

                var head = Head_Creation(colour);
                var body = Body_Creation(colour);
                var arm = Arm_Creation(colour);
                var lag =  Lag_Creation(colour);

                robotDetail += await head;
                robotDetail += ", " + await body;
                robotDetail += ", " + await arm;
                robotDetail += ", " + await lag;
                stopwatch.Stop();
                var elapsedMs = stopwatch.ElapsedMilliseconds;

                return new ResponseModel
                {
                    result = $"Request took {elapsedMs / 1000} s",
                    robotDetail = robotDetail,
                    startTime = start,
                    finishTime = DateTime.Now
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    result = "Error, " + ex.Message,
                    robotDetail = "",
                    startTime = start,
                    finishTime = DateTime.Now
                };
            }
        }

        public async Task<ResponseModel> ScheduleRobotCreationAsync(string colour)
        {
            string robotDetail = "";
            DateTime start = DateTime.Now;

            try
            {
                var stopwatch = Stopwatch.StartNew();

                _ = Head_Creation(colour);
                _ = Body_Creation(colour);
                _ = Arm_Creation(colour);
                _ = Lag_Creation(colour);

                await Task.Delay(2000);
                robotDetail = "This robot add in queue.";
                stopwatch.Stop();
                var elapsedMs = stopwatch.ElapsedMilliseconds;

                return new ResponseModel 
                {
                    result= $"Request took {elapsedMs / 1000} s",
                    robotDetail = robotDetail,
                    startTime = start,
                    finishTime = DateTime.Now
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    result = "Error, " + ex.Message,
                    robotDetail = "",
                    startTime = start,
                    finishTime = DateTime.Now
                };
            }
        }

        public async Task<string> Head_Creation(string colour)
        {
            string url = "HeadCreation";
            string data = JsonSerializer.Serialize(new RequestModel { colour = colour });
            var response = await _httpClient.CallServiceBAsync(url, data);

            return response.result;
        }

        public async Task<string> Body_Creation(string colour)
        {
            string url = "BodyCreation";
            string data = JsonSerializer.Serialize(new RequestModel { colour = colour });
            var response = await _httpClient.CallServiceBAsync(url, data);

            return response.result;
        }

        public async Task<string> Arm_Creation(string colour)
        {
            string url = "ArmCreation";
            string data = JsonSerializer.Serialize(new RequestModel { colour = colour });
            var response = await _httpClient.CallServiceBAsync(url, data);

            return response.result;
        }

        public async Task<string> Lag_Creation(string colour)
        {
            string url = "LagCreation";
            string data = JsonSerializer.Serialize(new RequestModel { colour = colour });
            var response = await _httpClient.CallServiceBAsync(url, data);

            return response.result;
        }
    }
}
