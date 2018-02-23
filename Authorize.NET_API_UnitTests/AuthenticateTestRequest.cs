using Authorize.NET_API;
using Authorize.NET_API.Models;
using Authorize.NET_API.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace Authorize.NET_API_UnitTests {
    [TestClass]
    public class AuthenticateTestRequest {
        
        [TestMethod]
        public void SuccessfulRequest () {
            MerchantAuthentication merchant = new MerchantAuthentication {
                apiLoginId = Endpoint.Sandbox.ApiLoginId,
                transactionKey = Endpoint.Sandbox.TransactionKey
            };
            string response = AuthorizeApi.AuthenticateTestRequest(Endpoint.Sandbox.Url, merchant);
            JObject json = JObject.Parse(response);

            Assert.AreEqual("Ok", (string)json["messages"]["resultCode"]);
        }
    }
}

