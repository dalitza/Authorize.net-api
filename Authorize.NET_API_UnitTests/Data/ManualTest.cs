using Authorize.NET_API;
using Authorize.NET_API.Constants;
using Authorize.NET_API.Models;
using Newtonsoft.Json.Linq;
using System;

namespace Authorize.NET_API_UnitTests.Data {
    public static class ManualTest {
        public static void Test () {
            Transaction transaction = new Transaction {
                merchant = new MerchantAuthentication {
                    apiLoginId = Endpoint.Sandbox.ApiLoginId,
                    transactionKey = Endpoint.Sandbox.TransactionKey
                },
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
                    number = "4111111111111111",
                    code = "789",
                    expirationDate = "2099-10"
                },
                orderInformation = new OrderInformation {
                    description = "test purchase",
                    invoiceNumber = "123456"
                },
                amount = 80.88m
            };

            string response = AuthorizeApi.CreateTransactionRequest(Endpoint.Sandbox.Url, transaction);
            JObject json = JObject.Parse(response);

            Console.WriteLine(response);
        }
    }
}
