using Authorize.NET_API.Constants;
using Authorize.NET_API.Models;

namespace Authorize.NET_API_UnitTests.Data {
    public static class Mockup {

        public static MerchantAuthentication Merchant () {
            return new MerchantAuthentication {
                apiLoginId = Endpoint.Sandbox.ApiLoginId,
                transactionKey = Endpoint.Sandbox.TransactionKey
            };
        }

        public static Transaction Transaction () {
            return new Transaction {
                merchant = Merchant(),
                address = new Address {
                    addressName = "test address",
                    city = "test city",
                    country = "test country",
                    firstName = "test first name",
                    lastName = "test last name",
                    state = "test state",
                    zip = "44628"
                },
                creditCard = new CreditCard {
                    number = Data.Random.CreditCardNumber(),
                    code = "789",
                    expirationDate = Data.Random.FutureDate()
                },
                orderInformation = new OrderInformation {
                    description = "test purchase",
                    invoiceNumber = Data.Random.String()
                },
                amount = 80.88m
            };
        }

    }
}
