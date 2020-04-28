using System;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace PublishFunctionApp
{
    public static class PublishToEventHubV1_1
    {
        [FunctionName("PublishToEventHubV1_1")]
        public static void Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            PublishToEventHub.PublishEvent(SalesOrderVersions.V1_1, log);
        }
    }
}
