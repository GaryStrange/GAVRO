using System;
using System.Collections.Generic;
using System.Text;

namespace PublishFunctionApp
{
    public class SalesOrder
    {
        public string OrderId = Guid.NewGuid().ToString();
        public string AsJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public byte[] AsJsonUTF8()
        {
            return Encoding.UTF8.GetBytes(this.AsJson());
        }

        public static SalesOrder NewOrder()
        {
            return new SalesOrder();
        }

        public static string GetSchemaVersion() { return "v1.0"; }
    }
}
