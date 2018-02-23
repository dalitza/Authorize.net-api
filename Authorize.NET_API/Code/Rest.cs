using System;
using System.IO;
using System.Net;
using System.Text;

namespace Authorize.NET_API.Code {
    public static class Rest {

        public static string Request (string urlEndpoint, string requestMethod, string contentType) {
            return Request(urlEndpoint, requestMethod, contentType, "");
        }

        public static string Request (string urlEndpoint, string requestMethod, string contentType, string body) {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            
            // Initialize request parameters
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlEndpoint);
            request.Method = requestMethod;
            request.ContentType = contentType;

            // Attach a body to our request
            byte[] bytes = Encoding.ASCII.GetBytes(body);
            using (Stream requestStream = request.GetRequestStream()) {
                requestStream.Write(bytes, 0, bytes.Length);

                // Get a response
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) {
                    Stream responseStream = response.GetResponseStream();

                    return response.StatusCode == HttpStatusCode.OK ? ToString(responseStream) : string.Empty;
                }
            }
        }

        private static string ToString (Stream stream) {
            return new StreamReader(stream).ReadToEnd();
        }

    }
}
