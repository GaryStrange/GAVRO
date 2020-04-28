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

    public class SalesOrderV1_1 : SalesOrderV1
    {
        public static string[] CurrenciesISO4217 =
        {
            "GBP", "USD"
        };

        public string Currency = CurrenciesISO4217.RandomElement();

        public new string GetSchemaVersion { get { return "v1.1"; } }
    }
}
