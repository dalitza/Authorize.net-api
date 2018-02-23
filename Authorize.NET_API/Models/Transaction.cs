using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Authorize.NET_API.Models {
    public class Transaction {
        public decimal amount = 0.0m;
        public MerchantAuthentication merchant { get; set; }
        public CreditCard creditCard { get; set; }
        public Address address { get; set; }
        public OrderInformation order { get; set; }
    }
}
