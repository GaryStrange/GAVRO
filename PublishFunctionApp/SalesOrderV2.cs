using System;
using System.Collections.Generic;
using System.Text;

namespace PublishFunctionApp
{
    internal static class Extensions
    {
        public static string RandomElement(this string[] array) =>
            array[(new System.Random()).Next(array.Length)];
    }

    public class SalesOrderV2 : SalesOrder
    {
        public static string[] CurrenciesISO4217 =
        {
            "GBP", "USD"
        };

        public string Currency = CurrenciesISO4217.RandomElement();

        public new static SalesOrderV2 NewOrder()
        {
            return new SalesOrderV2();
        }

        public new static string GetSchemaVersion() { return "v2.0"; }
    }
}
