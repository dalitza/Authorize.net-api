using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Authorize.NET_API_UnitTests.Data {
    public static class Random {

        public static string String () {
            return Path.GetRandomFileName()
                .Replace(".", "");
        }

        public static string FutureDate () {
            return DateTime.Now
                .AddYears(new System.Random().Next(1, 15))
                .ToString("yyyy-MM");
        }

        public static string CreditCardNumber () {
            var creditCards = new string[] {
                "370000000000002",
                "6011000000000012",
                "3088000000000017",
                "38000000000006",
                "4007000000027",
                "4012888818888",
                "4111111111111111",
                "5424000000000015",
                "2223000010309703",
                "2223000010309711"
            };
            return creditCards[new System.Random().Next(0, creditCards.Length - 1)];
        }

    }
}
