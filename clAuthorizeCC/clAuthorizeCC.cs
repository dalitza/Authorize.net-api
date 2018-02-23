using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.Collections.Specialized;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using Authorize.NET_API;
using Authorize.NET_API;

namespace ME.Mexicard
{
    /// <summary>
    /// This class is meant to be an interface for legacy applications that
    /// are still using the 3.5 .NET runtime. 
    /// 
    /// It updates the API for Authorize.NET which updates connection security 
    /// to a defacto 1.2 TLS connection. More info about this:
    /// https://support.authorize.net/authkb/index?page=content&id=A1623&utm_campaign=18%20Q2%20Jan%20Merchant%20Notice%20TLS%20Disablement%20&utm_medium=email&utm_source=Eloqua
    /// 
    /// Input and output comming from this class is mostly identical to the now
    /// deprecated ClassLibrary: 
    /// https://bitbucket.org/creatsol_dev/clauthorizecc
    /// 
    /// Some differences may be found given that this new API might return 
    /// different messages or identifiers.
    /// 
    /// </summary>
    public class clAuthorizeCC {
        public string firstName, lastName, address, city, state, zip, country;
        const decimal amount = 25.84m;
        public string orderDescription, invoiceNo;
        public string CCno, CCExpDate, CCcode, CCtype;
        public string netCode, netTransid, msg;
        public string isTest;

        const string sandboxApiEndpoint = "https://apitest.authorize.net/xml/v1/request.api";
        const string productionApiEndpoint = "https://api.authorize.net/xml/v1/request.api";

        const string apiLoginId = "6x7NyN6A";
        const string transactionKey = "78p6q84Xb3sL7aHj";
        
        public clAuthorizeCC () {
            isTest = "False";
        }
        
    }

}

