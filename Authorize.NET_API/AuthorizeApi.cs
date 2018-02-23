using System;
using Authorize.NET_API.Code;
using Authorize.NET_API.Constants;
using Authorize.NET_API.Models;
using Authorize.NET_API.RequestSchema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Authorize.NET_API {
    public static class AuthorizeApi {
        
        public static string AuthenticateTestRequest(string urlEndpoint, MerchantAuthentication merchant) {
            JObject json = Json.AuthenticateTestRequest(merchant);
            var requestBody = JsonConvert.SerializeObject(json);
            
            string response = Rest.Request(urlEndpoint, RequestMethod.POST, ContentType.JSON, requestBody);
            PrintRequestResponse(requestBody, response);
            return response;
        }
        
        public static string CreateTransactionRequest(string urlEndpoint, Transaction transaction) {
            JObject json = Json.CreateTransactionRequest(transaction);
            var requestBody = JsonConvert.SerializeObject(json);

            string response = Rest.Request(urlEndpoint, RequestMethod.POST, ContentType.JSON, requestBody);
            PrintRequestResponse(requestBody, response);
            return response;
        }
        
        private static void PrintRequestResponse (string request, string response) {
            Console.WriteLine("Request:");
            Console.WriteLine(request);
            Console.WriteLine("");
            Console.WriteLine("Response:");
            Console.WriteLine(response);
        }
        
    }
}
