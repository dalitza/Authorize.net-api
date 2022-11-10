using System;
using Authorize.NET_API;
using Authorize.NET_API.Models;
using Authorize.NET_API.Constants;
using Newtonsoft.Json.Linq;

namespace ME.Mexicard {
    /// <summary>
    /// This class is meant to be an interface for legacy applications that
    /// are still using the clAuthorizeCC.dll library for Authorize.NET 
    /// transactions. For new aplications its preferably to use the 
    /// Authorize.NET_API.dll in this project (which this library makes use of).
    /// 
    /// The old clAuthorizeCC.dll library was deprecated due to Authorize.NET
    /// making an update to its API, a new Solution was considered sensible.
    /// 
    /// Authorize.NET made an update to its API which updates connection security 
    /// to a defacto 1.2 TLS connection. More info about this here:
    /// https://support.authorize.net/authkb/index?page=content&id=A1623&utm_campaign=18%20Q2%20Jan%20Merchant%20Notice%20TLS%20Disablement%20&utm_medium=email&utm_source=Eloqua
    /// 
    /// Input id identical to the now deprecated clAuthorizeCC.dll: 
    /// https://bitbucket.org/creatsol_dev/clauthorizecc
    /// 
    /// Output will very likely differ in the form of response codes and reponse
    /// messages.
    /// </summary>
    public class clAuthorizeCC {
        public string firstName, lastName, address, city, state, zip, country;
        public double amount;
        public string orderDescription, invoiceNo;
        public string CCno, CCExpDate, CCcode, CCtype;
        public string netCode, netTransid, msg;
        public string isTest;

        public clAuthorizeCC () {
            isTest = "False";
        }

        /// <summary>
        /// WARNING: Contains dangerous behaviour, succesful (but not authorized) transactions
        /// will be treated as "failed". This is in order to preserve consistency with the old 
        /// clAuthorizeCC.dll logic.
        /// 
        /// For example, this response will be treated as failed: 
        /// {
        ///     "transactionResponse": {
        ///         "responseCode":"4","authCode":"","avsResultCode":"P","cvvResultCode":"","cavvResultCode":"","transId":"60099381760","refTransID":"","transHash":"388FF4212FF2634CAC8E2719673F258B","testRequest":"0","accountNumber":"XXXX9703","accountType":"MasterCard",
        ///         "messages":[{"code":"252","description":"Your order has been received. Thank you for your business!"}],"transHashSha2":""
        ///     },
        ///     "messages": {"resultCode":"Ok","message":[{"code":"I00001","text":"Successful."}]}
        /// }
        /// 
        /// </summary>
        /// <returns></returns>
        public bool AuthorizePayment() {
            Endpoint.EndPointData endpoint = (isTest == "False") ? Endpoint.Production : Endpoint.Sandbox;

            Transaction transaction = new Transaction {
                merchant = new MerchantAuthentication {
                    apiLoginId = endpoint.ApiLoginId,
                    transactionKey = endpoint.TransactionKey
                },
                address = new Address {
                    addressName = address,
                    country = country,
                    state = state,
                    city = city,
                    firstName = firstName,
                    lastName = lastName,
                    zip = zip
                },
                creditCard = new CreditCard {
                    number = CCno,
                    code = CCcode,
                    expirationDate = CCExpDate
                },
                orderInformation = new OrderInformation {
                    description = orderDescription,
                    invoiceNumber = invoiceNo
                },
                amount = (decimal)amount
            };

            try {
                string response = AuthorizeApi.CreateTransactionRequest(endpoint.Url, transaction);
                JObject json = JObject.Parse(response);
                // msg = Authorize.NET_API.Code.StringifyResponse.BuildResponseResults(response);

                msg = string.Empty +
                    "messages.resultCode = " + (string)json["messages"]["resultCode"] +
                    "messages.message = " + (string)json["messages"]["message"];

                if ((string)json["messages"]["resultCode"] == "Ok") {
                    if ((string)json["transactionResponse"]["responseCode"] == "1") {
                        netCode = (string)json["transactionResponse"]["authCode"];
                        netTransid = (string)json["transactionResponse"]["transId"];
                        return true;
                    }
                }
                return false;
            } catch (Exception ex) {
                msg = ex.Message;
                return false;
            }
        }
    }

}

