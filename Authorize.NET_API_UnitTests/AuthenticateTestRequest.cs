using Newtonsoft.Json.Linq;
using Authorize.NET_API;
using Authorize.NET_API.Constants;
using Authorize.NET_API_UnitTests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Authorize.NET_API_UnitTests {
    [TestClass]
    public class AuthenticateTestRequest {
        
        [TestMethod]
        public void SuccessfulRequest () {
            string response = AuthorizeApi.AuthenticateTestRequest(Endpoint.Sandbox.Url, Mockup.Merchant());
            JObject json = JObject.Parse(response);

            Assert.AreEqual("Ok", (string)json["messages"]["resultCode"]);
        }

    }
}

