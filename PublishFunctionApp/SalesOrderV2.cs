﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PublishFunctionApp
{
    public class SalesOrderV2 : ISalesOrder
    {
        public string OrderId = Guid.NewGuid().ToString();
        public int[] OrderedProducts = Enumerable.Range(0, RandomArraySize(10)).ToArray();
        public DateTime OrderCreatedUTC = DateTime.UtcNow;

        private static int RandomArraySize(int max, int min = 0) => (new System.Random()).Next(min, max);
         
        public string GetSchemaVersion { get { return "v2.0"; } }
    }
}
