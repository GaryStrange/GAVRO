using System;
using System.Collections.Generic;
using System.Text;

namespace PublishFunctionApp
{
    public class SalesOrderV1 : ISalesOrder
    {
        public string OrderId = Guid.NewGuid().ToString();
        public double OrderAmount = (new System.Random()).NextDouble();
        public DateTime OrderCreatedUTC = DateTime.UtcNow;

        public string GetSchemaVersion { get { return "v1.0"; } }
    }
}
