using Microsoft.Azure.EventHubs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishFunctionApp
{
    public static class PublishToEventHub
    {
        #region Event Hub details
        private static string eventHubNameSpace = Environment.GetEnvironmentVariable("TargetEventHubsNamespace");
        private static readonly Uri endpointAddress = new Uri($"sb://{eventHubNameSpace}.servicebus.windows.net/");
        private static readonly string entityPath = "gavroeh";
        private static EventHubClient eventHubClient = EventHubClient.CreateWithManagedServiceIdentity(endpointAddress, entityPath);
        #endregion

        public static void PublishEvent(SalesOrderVersions version, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            ISalesOrder order = SalesOrder.CreateOrder(version);
            EventData eventData = new EventData(SalesOrder.AsJsonUTF8(order));
            eventData.Properties.Add("SchemaVersion", order.SchemaVersion);

            log.LogInformation($"Sending message attempt: {SalesOrder.AsJson(order)}");
            eventHubClient.SendAsync(eventData);
        }
    }
}
