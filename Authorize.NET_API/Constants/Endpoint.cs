namespace Authorize.NET_API.Constants {
    public static class Endpoint {

        public class EndPointData {
            private string url = string.Empty;
            private string apiLoginId = string.Empty;
            private string transactionKey = string.Empty;

            public string Url { get; set; }
            public string ApiLoginId { get; set; }
            public string TransactionKey { get; set; }
        }

        private static EndPointData sandbox = new EndPointData {
            Url = "https://apitest.authorize.net/xml/v1/request.api",
            ApiLoginId = "6x7NyN6A",
            TransactionKey = "78p6q84Xb3sL7aHj"
        };

        private static EndPointData production = new EndPointData {
            Url = "https://api.authorize.net/xml/v1/request.api",
            ApiLoginId = "",
            TransactionKey = ""
        };

        public static EndPointData Sandbox {
            get {
                return sandbox;
            }
        }

        public static EndPointData Production {
            get {
                return production;
            }
        }

    }
}
