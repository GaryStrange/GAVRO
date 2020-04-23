using System;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace PublishFunctionApp
{
    public static class PublishToEventHubV2
    {
        #region Event Hub details
        private static string eventHubNameSpace = Environment.GetEnvironmentVariable("TargetEventHubsNamespace");
        private static readonly Uri endpointAddress = new Uri($"sb://{eventHubNameSpace}.servicebus.windows.net/");
        private static readonly string entityPath = "gavroeh";
        private static EventHubClient eventHubClient = EventHubClient.CreateWithManagedServiceIdentity(endpointAddress, entityPath);
        #endregion

        [FunctionName("PublishToEventHubV2")]
        public static void Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            SalesOrderV2 order = SalesOrderV2.NewOrder();
            EventData eventData = new EventData(order.AsJsonUTF8());
            eventData.Properties.Add("SchemaVersion", SalesOrderV2.GetSchemaVersion());
            log.LogInformation($"Sending message attempt: {order.AsJson()}");
            eventHubClient.SendAsync(eventData);
        }
    }
}
