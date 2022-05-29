using RestSharp;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DuckyTalk.Helpers
{
    public class UserBreakReminderHelper
    {
        private static readonly CronDaemon BreakNotificationCheckerTask = new CronDaemon();
        private static readonly CronDaemon EndTimeNotificationCheckerTask = new CronDaemon();

        private static string BreakNotificationCronJob { get; set; } = "* * * * *";//"0 22 * * *";// svaki dan u 22h //"*/2 * * * *"; // svako 2 min za test //
        private static string EndTimeNotificationCronJob { get; set; } = "* * * * *";//"0 22 * * *";// svaki dan u 22h //"*/2 * * * *"; // svako 2 min za test //

        public static void BreakNotification()
        {
            string msg = "It's break time";
           
            BreakNotificationCheckerTask.AddJob(BreakNotificationCronJob, () =>
            {
                Task.Run(() => Notify(msg));
            });
            BreakNotificationCheckerTask.Start();
        }
        public async static void Notify(string msg)
        {
            var client = new RestClient("https://onesignal.com/api/v1/notifications");

            var request = new RestRequest("https://onesignal.com/api/v1/notifications", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Basic YjU5NWVjYTktNTA5OS00NDE5LWE3NTgtZGMyNzIwYWQ5NTI0");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Content-Lenght", "charset=utf-8");
            Newtonsoft.Json.Linq.JObject _meetingRequestJson = new Newtonsoft.Json.Linq.JObject();
            _meetingRequestJson.Add(new Newtonsoft.Json.Linq.JProperty("app_id", "12b493b0-41d7-4bb4-8d6b-0d0e0c80f33b"));
            _meetingRequestJson.Add(new Newtonsoft.Json.Linq.JProperty("included_segments", "Subscribed Users"));
            _meetingRequestJson.Add(new Newtonsoft.Json.Linq.JProperty("contents", "\"en\":\"{msg}\""));
            _meetingRequestJson.Add(new Newtonsoft.Json.Linq.JProperty("name", "duckytalk"));
            string gtmJSON = Newtonsoft.Json.JsonConvert.SerializeObject(_meetingRequestJson);
            
            request.AddParameter("application/json", gtmJSON, ParameterType.RequestBody);



            RestResponse response = await client.ExecuteAsync(request);
        }
        public static void EndTimeNotification(DateTime now)
        {
            string msg = "It's time to go home";
           
            EndTimeNotificationCheckerTask.AddJob(EndTimeNotificationCronJob, () =>
            {
                Task.Run(() => Notify(msg));
            });
            
            EndTimeNotificationCheckerTask.Start();
        }
    }
}