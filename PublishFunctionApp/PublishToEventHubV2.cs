using System;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace PublishFunctionApp
{
    public static class PublishToEventHubV2
    {
        [FunctionName("PublishToEventHubV2")]
        public static void Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            PublishToEventHub.PublishEvent(SalesOrderVersions.V2, log);
        }
    }
}
