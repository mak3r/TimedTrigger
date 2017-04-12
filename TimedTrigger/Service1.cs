using Apprenda.Services.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace TimedTrigger
{
    public partial class Service1 : ServiceBase
    {
        private static readonly ILogger log =
            LogManager.Instance().GetLogger(typeof(Service1));

        //Reuse the same client over and over again
        private static readonly HttpClient client = new HttpClient();

        //For this sample trigger we are going to have it run every 2 minutes
                private static double minFromNow = 2;

        //When should we trigger the event
        DateTime triggerTime = DateTime.Now.AddMinutes(minFromNow);

        public Service1()
        {
            InitializeComponent();

        }

        protected override void OnStart(string[] args)
        {

            //sleep until it's time to trigger
            ScheduleAction(() => PostEvent(), triggerTime);
        }


        protected override void OnStop()
        {
        }

        public async void ScheduleAction(Action action, DateTime ExecutionTime)
        {
            await Task.Delay((int)ExecutionTime.Subtract(DateTime.Now).TotalMilliseconds);
            action();
        }

        public async void PostEvent()
        {
            //Reset the trigger time for the next time it should trigger
            triggerTime = DateTime.Today.AddMinutes(minFromNow);
            var content = new FormUrlEncodedContent(new[]
                        {
                new KeyValuePair<string, string>("", "")
            });
            var result = await RESTfulPost(content);
            log.Debug(result.ToString());
        }

        private async Task<HttpContent> RESTfulPost(HttpContent content)
        {
            //fire an http GET request here 
            //todo: make this a configurable parameter based on the deployed application name
//            var responseString = await client.GetStringAsync(ConfigurationManager.AppSettings["appUrl"] + "/counter/0");

            var responseString2 = await client.PostAsync(ConfigurationManager.AppSettings["appUrl"] + "/counter/0", content);
            return responseString2.Content;
        }
    }
}
