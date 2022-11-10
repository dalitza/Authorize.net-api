using Authorize.NET_API.Models;
using Newtonsoft.Json.Linq;

namespace Authorize.NET_API.RequestSchema {
    public static class Json {

        public static JObject AuthenticateTestRequest (MerchantAuthentication merchant) {
            JObject merchantAuthentication = MerchantAuthentication(merchant);

            return new JObject(
                new JProperty("authenticateTestRequest",
                    new JObject(
                        new JProperty("merchantAuthentication", merchantAuthentication))));
        }

        public static JObject CreateTransactionRequest (Transaction transaction) {
            JObject merchant = MerchantAuthentication(transaction.merchant);
            JObject payment = Payment(transaction.creditCard);
            JObject billTo = BillTo(transaction.address);
            JObject order = Order(transaction.orderInformation);
            
            return new JObject(
                new JProperty("createTransactionRequest",
                    new JObject(
                        new JProperty("merchantAuthentication", merchant),
                        new JProperty("transactionRequest",
                            new JObject(
                                new JProperty("transactionType", "authCaptureTransaction"),
                                new JProperty("amount", transaction.amount),
                                new JProperty("payment", payment),
                                new JProperty("order", order),
                                new JProperty("billTo", billTo)
                                )))));
        }

        private static JObject MerchantAuthentication (MerchantAuthentication merchant) {
            return
                new JObject(
                    new JProperty("name", merchant.apiLoginId),
                    new JProperty("transactionKey", merchant.transactionKey));
        }

        private static JObject Payment (CreditCard creditCard) {
            return
                new JObject(
                    new JProperty("creditCard",
                        new JObject(
                            new JProperty("cardNumber", creditCard.number),
                            new JProperty("expirationDate", creditCard.expirationDate),
                            new JProperty("cardCode", creditCard.code))));
        }

        private static JObject BillTo (Address address) {
            return
                new JObject(
                    new JProperty("firstName", address.firstName),
                    new JProperty("lastName", address.lastName),
                    new JProperty("address", address.addressName),
                    new JProperty("city", address.city),
                    new JProperty("state", address.state),
                    new JProperty("zip", address.zip),
                    new JProperty("country", address.country));
        }

        private static JObject Order (OrderInformation order) {
            return
                new JObject(
                    new JProperty("invoiceNumber", order.invoiceNumber),
                    new JProperty("description", order.description));
        }

    }
}
