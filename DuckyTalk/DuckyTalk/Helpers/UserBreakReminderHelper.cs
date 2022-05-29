using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;

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
        public static void Notify(string msg)
        {
            //var client = new RestClient("https://onesignal.com/api/v1/notifications");

            //var request = new RestRequest("https://onesignal.com/api/v1/notifications", Method.Post);
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Authorization", "Basic YjU5NWVjYTktNTA5OS00NDE5LWE3NTgtZGMyNzIwYWQ5NTI0");
            //request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Content-Lenght", "charset=utf-8");
            //Newtonsoft.Json.Linq.JObject _meetingRequestJson = new Newtonsoft.Json.Linq.JObject();
            //_meetingRequestJson.Add(new Newtonsoft.Json.Linq.JProperty("app_id", "12b493b0-41d7-4bb4-8d6b-0d0e0c80f33b"));
            //_meetingRequestJson.Add(new Newtonsoft.Json.Linq.JProperty("included_segments", "Subscribed Users"));
            //_meetingRequestJson.Add(new Newtonsoft.Json.Linq.JProperty("contents", "\"en\":\"{msg}\""));
            //_meetingRequestJson.Add(new Newtonsoft.Json.Linq.JProperty("name", "duckytalk"));
            //string gtmJSON = Newtonsoft.Json.JsonConvert.SerializeObject(_meetingRequestJson);

            //request.AddParameter("application/json", gtmJSON, ParameterType.RequestBody);



            //RestResponse response = await client.ExecuteAsync(request);


            string onesignalAppID = "12b493b0-41d7-4bb4-8d6b-0d0e0c80f33b";
            string onesignalRestID = "YjU5NWVjYTktNTA5OS00NDE5LWE3NTgtZGMyNzIwYWQ5NTI0";

            var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;
            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.Headers.Add("authorization", "Basic " + onesignalRestID);
            var contentsMessage = new { en = msg };


            List<string> segmentsEnum = new List<string>()
            {
                "Subscribed Users"
            };

            var obj = new
            {
                app_id = onesignalAppID,
                contents = contentsMessage,
                included_segments = segmentsEnum 
            };

            var json = JsonConvert.SerializeObject(obj);

            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            string responseContent = null;

            try
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
            }

            System.Diagnostics.Debug.WriteLine(responseContent);
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