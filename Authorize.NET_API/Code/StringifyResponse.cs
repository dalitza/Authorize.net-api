using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authorize.NET_API.Code {
    public static class StringifyResponse {
        
        public static string BuildResponseResults (string response) {
            JObject json = JObject.Parse(response);

            string message = string.Empty;
            message = message +
                BuildStringJsonKeyValue(json["messages"]["resultCode"]) +
                BuildStringJsonArray(json["messages"]["message"]);
            if (json["transactionResponse"] != null) {
                message = message +
                    BuildStringJsonKeyValue(json["transactionResponse"]["responseCode"]) +
                    BuildStringJsonArray(json["transactionResponse"]["messages"]);
            }

            return message;
        }
        
        public static string BuildRequestResponse (string request, string response) {
            return "Request:\n" + request + "\n\n" + "Response:\n" + response;
        }

        /// <summary>
        /// TODO: This recursive method can be better designed
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        private static string BuildStringJsonArray (JToken json) {
            var message = string.Empty;
            WalkNode(json, objectAction => { }, propertyAction => {
                message = message + BuildStringJsonKeyValue(propertyAction);
            });
            return message;
        }

        // Reference:
        // https://stackoverflow.com/questions/16181298/how-to-do-recursive-descent-of-json-using-json-net
        private static void WalkNode (JToken node, Action<JObject> objectAction = null, Action<JProperty> propertyAction = null) {
            switch (node.Type) {
                case JTokenType.Array:
                    foreach (JToken child in node.Children()) {
                        WalkNode(child, objectAction, propertyAction);
                    }
                    break;
                case JTokenType.Object:
                    objectAction?.Invoke((JObject)node);
                    foreach (JProperty child in node.Children<JProperty>()) {
                        propertyAction?.Invoke(child);
                        WalkNode(child.Value, objectAction, propertyAction);
                    }
                    break;
            }
        }

        private static string BuildStringJsonKeyValue (JToken json) {
            return json.Path + ": " + (string)json + "\n";
        }


    }
}
