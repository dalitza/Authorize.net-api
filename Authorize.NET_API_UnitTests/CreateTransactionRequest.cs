using Newtonsoft.Json.Linq;
using Authorize.NET_API;
using Authorize.NET_API.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Authorize.NET_API_UnitTests.Data;
using Authorize.NET_API.Models;

namespace Authorize.NET_API_UnitTests {
    [TestClass]
    public class CreateTransactionRequest {
        
        [TestMethod]
        public void SuccessfulRequest () {
            string response = AuthorizeApi.CreateTransactionRequest(Endpoint.Sandbox.Url, Mockup.Transaction());
            JObject json = JObject.Parse(response);

            Assert.AreEqual("Ok", (string)json["messages"]["resultCode"]);
        }

        [TestMethod]
        public void DeclinedTransactionRequest () {
            Transaction transaction = Mockup.Transaction();
            transaction.address.zip = "46282";

            string response = AuthorizeApi.CreateTransactionRequest(Endpoint.Sandbox.Url, transaction);
            JObject json = JObject.Parse(response);

            Assert.AreEqual("Ok", (string)json["messages"]["resultCode"]);
            Assert.AreEqual("2", (string)json["transactionResponse"]["responseCode"]);
        }


    }
}