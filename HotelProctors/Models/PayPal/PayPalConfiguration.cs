using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using PayPal.Api;

namespace HotelProctors.Models
{
    public class PaypalConfiguration
    {
        public readonly static string ClientId;
        public readonly static string ClientSecret;
        
  
        static PaypalConfiguration()
        {
            var config = GetConfig();
            ClientId = config["clientId"];
            ClientSecret = config["clientSecret"];
        }

        public static Dictionary<string, string> GetConfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }
        //Create Access Token
        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(ClientId, ClientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }
        //this will return APIContext object
        public static APIContext GetAPIContext()
        {
            var apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;
        }

    }  
}   
    
