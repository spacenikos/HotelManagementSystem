using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using BraintreeHttp;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPal.Api;


namespace HotelProctors.Models
{
    public class PaypalSample
    {
        /**
           Set up PayPal environment with sandbox credentials.
           In production, use LiveEnvironment.
        */
        public static PayPalEnvironment environment()
        {
            return new SandboxEnvironment("ARRkYrk6k5Pw1XmuUcGuFHKnUqWvRHDO6LzJUBN7JJsbjgYdNgECbh18XD-s_ybT9ptFZDdXDWq3-tQ3","EAwQSsEendpmaD67aqvMHvTASnPLtsMf6tYclQkmF9CsndruwYDJRqesM_xQnDKM9ATvyjBgJ6nL3YCZ");
        }

        /**
            Returns PayPalHttpClient instance to invoke PayPal APIs.
         */
        public static PayPalHttpClient client()
        {
            return new PayPalHttpClient(environment());
        }

        public static PayPalHttpClient client(string refreshToken)
        {
            return new PayPalHttpClient(environment(), refreshToken);
        }

        /**
            Use this method to serialize Object to a JSON string.
        */
        public static String ObjectToJSONString(Object serializableObject)
        {
            MemoryStream memoryStream = new MemoryStream();
            var writer = JsonReaderWriterFactory.CreateJsonWriter(
                memoryStream, Encoding.UTF8, true, true, "  ");
            DataContractJsonSerializer ser = new DataContractJsonSerializer(serializableObject.GetType(), new DataContractJsonSerializerSettings{UseSimpleDictionaryFormat = true});
            ser.WriteObject(writer, serializableObject);
            memoryStream.Position = 0;
            StreamReader sr = new StreamReader(memoryStream);
            return sr.ReadToEnd();
        }
    }
}