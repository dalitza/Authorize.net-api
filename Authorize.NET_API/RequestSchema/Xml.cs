using Authorize.NET_API.Models;
using System.Xml.Linq;

namespace Authorize.NET_API.RequestSchema {
    public static class Xml {

        public static XDocument AuthenticateTestRequest (MerchantAuthentication merchant) {
            XDocument merchantAuthentication = MerchantAuthentication(merchant);

            return 
                new XDocument(
                    new XElement(@"authenticateTestRequest",
                        new XElement("merchantAuthentication", merchantAuthentication)));
        }

        private static XDocument MerchantAuthentication (MerchantAuthentication merchant) {
            return
                new XDocument(
                    new XElement("name", merchant.apiLoginId),
                    new XElement("transactionKey", merchant.transactionKey));
        }

    }
}
