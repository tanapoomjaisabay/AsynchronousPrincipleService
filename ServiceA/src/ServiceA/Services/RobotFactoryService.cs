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
        public RobotFactoryService() { }

        public async Task<string> CreateRobot(string colour)
        {
            string robotDetail = "";

            try
            {
                var stopwatch = Stopwatch.StartNew();

                var head = await Head_Creation(colour);
                var body = await Body_Creation(colour);
                var arm = await Arm_Creation(colour);
                var lag = await Lag_Creation(colour);

                robotDetail += head;
                robotDetail += "" + body;
                robotDetail += "" + arm;
                robotDetail += "" + lag;
                stopwatch.Stop();
                var elapsedMs = stopwatch.ElapsedMilliseconds;

                Console.WriteLine(robotDetail);
                return $"Request took {elapsedMs / 1000} s";
            }
            catch (Exception ex)
            {
                return "Error, " + ex.Message;
            }
        }

        public async Task<string> CreateRobotAsync(string colour)
        {
            string robotDetail = "";

            try
            {
                var stopwatch = Stopwatch.StartNew();

                var head = Head_Creation(colour);
                var body = Body_Creation(colour);
                var arm = Arm_Creation(colour);
                var lag =  Lag_Creation(colour);

                robotDetail += await head;
                robotDetail += "" + await body;
                robotDetail += "" + await arm;
                robotDetail += "" + await lag;
                stopwatch.Stop();
                var elapsedMs = stopwatch.ElapsedMilliseconds;

                Console.WriteLine(robotDetail);
                return $"Request took {elapsedMs / 1000} s";
            }
            catch (Exception ex)
            {
                return "Error, " + ex.Message;
            }
        }

        public async Task<string> ScheduleRobotCreationAsync(string colour)
        {
            string robotDetail = "";

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

                Console.WriteLine(robotDetail);
                return $"Request took {elapsedMs / 1000} s";
            }
            catch (Exception ex)
            {
                return "Error, " + ex.Message;
            }
        }

        public async Task<string> Head_Creation(string colour)
        {
            string url = "HeadCreation";
            string data = JsonSerializer.Serialize(new RequestModel { colour = colour });
            var response = await CallServiceBAsync(url, data);

            return response.result;
        }

        public async Task<string> Body_Creation(string colour)
        {
            string url = "BodyCreation";
            string data = JsonSerializer.Serialize(new RequestModel { colour = colour });
            var response = await CallServiceBAsync(url, data);

            return response.result;
        }

        public async Task<string> Arm_Creation(string colour)
        {
            string url = "ArmCreation";
            string data = JsonSerializer.Serialize(new RequestModel { colour = colour });
            var response = await CallServiceBAsync(url, data);

            return response.result;
        }

        public async Task<string> Lag_Creation(string colour)
        {
            string url = "LagCreation";
            string data = JsonSerializer.Serialize(new RequestModel { colour = colour });
            var response = await CallServiceBAsync(url, data);

            return response.result;
        }

        public async Task<ResponseModel> CallServiceBAsync(string url, string json)
        {
            using (var client = new HttpClient())
            {
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"http://localhost:5007/api/RobotFactory/{url}", httpContent);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadFromJsonAsync<ResponseModel>();
                return content!;
            }
        }
    }
}
