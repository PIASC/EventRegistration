using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace LouACH.PaymentTransactions
{
    public class CardConnectCCAuth
    {
        public static void authTransaction()
        {
            Console.WriteLine("\nAuthorization Request");

                // Create Authorization Transaction request
                Newtonsoft.Json.Linq.JObject request = new Newtonsoft.Json.Linq.JObject();
                // Merchant ID
                request.Add("merchid", "496400000840");
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
            }

            ////System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(string.Format("http://localhost:51436/api/employees"));
            ////request.Method = "PUT";
            ////request.ContentType = "application/x-www-form-urlencoded";
            ////using (var requestStream = request.GetRequestStream())
            ////{
            ////    //requestStream.Write(byte, 0, byte.Length);
            ////}
            ////var response = (System.Net.HttpWebResponse)request.GetResponse();

            ////if (response.StatusCode ==  System.Net.HttpStatusCode.OK)
            ////    //UpdateResponseLabel.Text = "Update completed";
            ////else
            ////    //UpdateResponseLabel.Text = "Error in update";   



            ////  // Create the REST client
            //LouACH.Events.CardConnectRestClient client = new LouACH.Events.CardConnectRestClient
            //{
            //    url="https://url.goeshere.com:6443/cardconnect/rest/auth",
            //    user="",
            //    password=""
            //};

            ////// Send an AuthTransaction request


            ////  foreach (var x in response) {
            ////    String key = x.Key;
            ////    JToken value = x.Value;
            ////    Console.WriteLine(key + ": " + value.ToString());
            ////}

            ////return (String)response.GetValue("retref");
        }
    }
