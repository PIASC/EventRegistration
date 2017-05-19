using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace LouACH.PaymentTransactions
{
    public class CardConnectAPI
    {

        public static void authTransaction()
        {
            Console.WriteLine("\nAuthorization Request");

            // Create Authorization Transaction request
            Newtonsoft.Json.Linq.JObject request = new Newtonsoft.Json.Linq.JObject();
            // Merchant ID
            request.Add("merchid", "496160873888");
            // Card Type
            request.Add("accttype", "VI");
            // Card Number
            request.Add("account", "4444333322221111");
            // Card Expiry
            request.Add("expiry", "0914");
            // Card CCV2
            request.Add("cvv2", "776");
            // Transaction amount
            request.Add("amount", "100");
            // Transaction currency
            request.Add("currency", "USD");
            // Order ID
            request.Add("orderid", "12345");
            // Cardholder Name
            request.Add("name", "Test User");
            // Cardholder Address
            request.Add("address", "123 Test St");
            // Cardholder City
            request.Add("city", "TestCity");
            // Cardholder State
            request.Add("region", "TestState");
            // Cardholder Country
            request.Add("country", "US");
            // Cardholder Zip-Code
            request.Add("postal", "11111");
            // Return a token for this card number
            request.Add("tokenize", "Y");

            // Create the REST client
            //CardConnectRestClient client = new CardConnectRestClient("fts.cardconnect.com:6443", "testing", testing123);

            // Send an AuthTransaction request
            //JObject response = client.authorizeTransaction(request);

            //foreach (var x in response)
            //{
            //    String key = x.Key;
            //    JToken value = x.Value;
            //    Console.WriteLine(key + ": " + value.ToString());
            //}

            //return (String)response.GetValue("retref");
            return;
            }
        }


    }
