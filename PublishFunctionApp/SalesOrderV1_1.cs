using System;
using System.Collections.Generic;
using System.Text;

namespace PublishFunctionApp
{


    public class SalesOrderV1_1 : ISalesOrder
    {
        public string OrderId = Guid.NewGuid().ToString();
        public double OrderAmount = (new System.Random()).NextDouble();
        public DateTime OrderCreatedUTC = DateTime.UtcNow;

        public string Currency = SalesOrder.CurrenciesISO4217.RandomElement();

        public string SchemaVersion { get { return "v1.1"; } }
    }
}
