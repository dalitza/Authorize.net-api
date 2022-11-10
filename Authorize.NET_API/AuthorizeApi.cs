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

            string request = JsonConvert.SerializeObject(json);
            string response = Rest.Request(urlEndpoint, RequestMethod.POST, ContentType.JSON, request);

            //Console.WriteLine(StringifyResponse.BuildResponseResults(response));
            Console.WriteLine(StringifyResponse.BuildRequestResponse(request, response));

            return response;
        }
        
        public static string CreateTransactionRequest(string urlEndpoint, Transaction transaction) {
            JObject json = Json.CreateTransactionRequest(transaction);

            string request = JsonConvert.SerializeObject(json);
            string response = Rest.Request(urlEndpoint, RequestMethod.POST, ContentType.JSON, request);

            //Console.WriteLine(StringifyResponse.BuildResponseResults(response));
            Console.WriteLine(StringifyResponse.BuildRequestResponse(request, response));

            return response;
        }

        public static void test()
        {
            AuthenticateTestRequest(Constants.Endpoint.Sandbox.Url, new MerchantAuthentication { apiLoginId = Constants.Endpoint.Sandbox.ApiLoginId, transactionKey = Constants.Endpoint.Sandbox.TransactionKey });
        }
    }
}
