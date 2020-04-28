﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PublishFunctionApp
{
    public enum SalesOrderVersions
    {
        V1, V1_1, V2
    }

    public interface ISalesOrder
    {
        string GetSchemaVersion { get; }
    }

    public class SalesOrder
    {
        public static string AsJson(ISalesOrder order)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(order);
        }

        public static byte[] AsJsonUTF8(ISalesOrder order)
        {
            return Encoding.UTF8.GetBytes(SalesOrder.AsJson(order));
        }

        public static ISalesOrder CreateOrder(SalesOrderVersions version)
        {
            switch (version)
            {
                case SalesOrderVersions.V1: return new SalesOrderV1();
                case SalesOrderVersions.V1_1: return new SalesOrderV1_1();
                case SalesOrderVersions.V2: return new SalesOrderV2();
                default: throw new NotSupportedException();
            }
        }
    }
}
