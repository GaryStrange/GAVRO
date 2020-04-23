using System;
using System.Collections.Generic;
using System.Text;

namespace PublishFunctionApp
{

    public class SalesOrderV2 : SalesOrder
    {
        public static string[] CurrenciesISO4217 =
        {
            "GBP", "USD"
        };

        public string Currency = CurrenciesISO4217[(new System.Random()).Next(CurrenciesISO4217.Length)];

        public new static SalesOrderV2 NewOrder()
        {
            return new SalesOrderV2();
        }

        public new static string GetSchemaVersion() { return "v2.0"; }
    }
}
