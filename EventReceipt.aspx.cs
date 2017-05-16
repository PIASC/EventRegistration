using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuthorizeNet.Api.Contracts.V1;
using net.authorize.sample;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace LouACH
{

    public partial class EventReceipt : System.Web.UI.Page
    {
 
        public static string apiLoginId1 = Constants.API_LOGIN_ID;
        public static string transactionKey1 = Constants.TRANSACTION_KEY;
        public static string apiLoginId2 = Constants.API_LOGIN_ID2;
        public static string transactionKey2 = Constants.TRANSACTION_KEY2;
        public static string sOutput = "";
        public static creditCardType creditCard;
        public static customerAddressType customerAddress;
        public static string fName = "";
        public static string lName = "";
        public static string gName = "";
        public static string sgName = "";
        public static string Meal = "";
        public static string gMeal = "";
        public static string sgMeal = "";
        public static string sAmountDue = "0.00";
        public static decimal AmountDue = 0.00m;
        public static string TransactionCode = "";
        public static string TransactionCode1 = "";
        public static string TransactionMessage1 = "";
        public static string TransactionCode2 = "";
        public static string TransactionMessage2 = "";
        public static string TransactionCode3 = "";
        public static string TransactionMessage3 = "";
        public static string TransactionCode4 = "";
        public static string TransactionMessage4 = "";
        public static string TransactionMessage = "";
        public static string TransactionMessages = "";
        public static string Address = "";
        public static string City = "";
        public static string State = "";
        public static string Zip = "";
        public static string CC = "";
        public static string CCexpDt = "";
        public static string CCSecNo = "";
        public static string PIASC = "0.00";
        public static string IPM = "0.00";
        public static string PPAC = "0.00";
        public static lineItemType lineItems;
        public static string connectionString = Constants.CONNECTION_STRING;
        public static decimal UnitPrice = 0.00m;

        protected void Page_Load(object sender, EventArgs e)
        {
            string Item = "";
            decimal UnitPrice = 0.00m;
            customerAddress = new customerAddressType
            {
                firstName = LouACH.RegistrationPay.person.PersonfName,  //"John",
                lastName = LouACH.RegistrationPay.person.PersonlName,  //"Doe",
                address = Request.Form["txtAddress"],   //"123 My St",
                city = Request.Form["txtCity"],   //"OurTown",
                zip = Request.Form["txtZip"]   //"98004"
            };
            creditCard = new creditCardType
            {
                cardNumber = Request.Form["txtCC"],   //"4111111111111111",
                expirationDate = Request.Form["txtExpDt"], //"0718",
                cardCode = Request.Form["txtSecNo"]   //"123"
            };
            CC = creditCard.cardNumber;
            sAmountDue = Request.Form["txtAmount"];
           //Registration=new Events.Registration
           

            //List<Events.EventTransaction> allTrans = LouACH.EventMakePayment.GetTransactions();
            //foreach (var Transaction in allTrans)
            //{             

            //    lineItems = new lineItemType { itemId = "1", name = Transaction.LineItem, quantity = 1, unitPrice = Transaction.AmountPaid };
            //    var response = net.authorize.sample.ChargeCreditCard.Run(apiLoginId1, transactionKey1, System.Convert.ToInt32(Transaction.AmountPaid), Transaction.AccountID);
            //    //TransactionCode=
            //    TransactionMessages = TransactionMessages + Transaction.LineItem;
                
            //    if (Transaction.AccountID=="1")
            //    {
            //        gName = Request.Form["GuestName"];
            //        gMeal = Request.Form["GuestMeal"];       
            //        sgName = " and " + gName;
            //        sgMeal = " and " + gMeal;
            //    }
            //    //Response.Write(eTransaction.LineItem);

            //}
            
  //---------------------------------------------------------------//          
            //foreach (string s in Request.Form.Keys)
            //{

            //    if (s == "txtFName")
            //    {
            //        fName = Request.Form["txtFName"];
            //    }
            //    else if (s == "txtLName")
            //    {
            //        lName = Request.Form["txtLName"];
            //    }
            //    else if (s == "GuestName" && Request.Form["GuestName"] != "")
            //    {
            //        gName = Request.Form["GuestName"];
            //        gMeal = Request.Form["GuestMeal"];
            //        sgName = " and " + gName;
            //        sgMeal = " and " + gMeal;
            //        sAmountDue = Request.Form["txtAmount"];                 //200.00m;
            //    }
            //    else if (s == "Meal")
            //    {
            //        Meal = Request.Form["Meal"];
            //    }
            //    else if (s == "txtAddress")
            //    {
            //        Address = Request.Form["txtAddress"];
            //    }
            //     else if (s == "txtCity")
            //   {
            //       City = Request.Form["txtCity"];
            //    }
            //      else if (s == "txtState")
            //  {
            //       State = Request.Form["txtState"];
            //    }
            //     else if (s == "txtZip")
            //   {
            //       Zip = Request.Form["txtZip"];
            //    }
            //    else if (s == "txtCC")
            //    {
            //       CC = Request.Form["txtCC"];
            //    }
            //    else if (s == "txtExpDt")
            //    {
            //        CCexpDt = Request.Form["txtExpDt"];
            //    }
            //    else if (s == "txtSecNo")
            //    {
            //        CCSecNo = Request.Form["txtSecNo"];
            //    }
            //    else if (s == "PIASC")
            //    {
            //        PIASC = Request.Form["PIASC"];
            //    }
            //    else if (s == "IPM")
            //    {
            //        IPM = Request.Form["IPM"];
            //    }
            //    else if (s == "PPAC")
            //    {
            //        PPAC = Request.Form["PPAC"];
            //    }               
            //    //  FOR TEST Response.Write(s.ToString() + ":" + Request.Form[s] + " ");

            //}
                //customerAddress = new customerAddressType
                //{
                //    firstName = fName,  //"John",
                //    lastName = lName,  //"Doe",
                //    address = Address,   //"123 My St",
                //    city = City,   //"OurTown",
                //    zip = Zip   //"98004"
                //};


                //creditCard = new creditCardType
                //{
                //    cardNumber = CC,   //"4111111111111111",
                //    expirationDate = CCexpDt, //"0718",
                //    cardCode = CCSecNo   //"123"
                //};
                //Get  Transactions
                //OracleDataReader dr = LouACH.DataBaseTransactions.DataBase.GetTransactions();
                OracleDataReader dr;
                string queryString = "Select * FROM EVENT_TRANSACTIONS where RegistrationID = " + LouACH.RegistrationPay.registration.RegistrationID;
                using (OracleConnection connection = new OracleConnection(connectionString))
                using (OracleCommand command = new OracleCommand(queryString, connection))
                {
                    command.Connection.Open();
                    dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        Item = dr.GetString(5);
                        UnitPrice = dr.GetDecimal(4);
                        lineItems = new lineItemType { itemId = "1", name = Item, quantity = 1, unitPrice = UnitPrice };
                        var response = net.authorize.sample.ChargeCreditCard.Run(apiLoginId1, transactionKey1, Decimal.ToInt32(UnitPrice));
                        TransactionMessages =TransactionMessages + "<br/>" + Item + "-" + UnitPrice.ToString("C") + "<br/>    " + TransactionMessage;
                    }
                    command.Connection.Close();
                }
                //while (dr.Read())
                //{
                //    Item = dr.GetString(4).ToString();
                //    UnitPrice = dr.GetDecimal(5);
                //    lineItems = new lineItemType { itemId = "1", name = Item, quantity = 1, unitPrice = UnitPrice };
                //    var response = net.authorize.sample.ChargeCreditCard.Run(apiLoginId1, transactionKey1, Decimal.ToInt32(UnitPrice), "1"); 
                //}
            //if (gMeal !="")

            //{
            //    lineItems = new lineItemType { itemId = "1", name = "Guest Dinner", quantity = 1, unitPrice = new Decimal(200.00) };
            //    var response = net.authorize.sample.ChargeCreditCard.Run(apiLoginId, transactionKey, 200, "1"); 
            //}
            //if (PIASC != "0")
            //{
            //    lineItems = new lineItemType { itemId = "1", name = "PIACS Donation", quantity = 1, unitPrice = System.Convert.ToDecimal(PIASC) };
            //    var response2 = net.authorize.sample.ChargeCreditCard.Run(apiLoginId2, transactionKey2, System.Convert.ToInt32(PIASC), "2");
            //}
            //if (IPM != "0")
            //{
            //    lineItems = new lineItemType { itemId = "1", name = "IPM Donation", quantity = 1, unitPrice = System.Convert.ToDecimal(IPM) };
            //    var response2 = net.authorize.sample.ChargeCreditCard.Run(apiLoginId2, transactionKey2, System.Convert.ToInt32(IPM), "3");
            //}
            //if (PPAC != "0")
            //{
            //    lineItems = new lineItemType { itemId = "1", name = "PPAC Donation", quantity = 1, unitPrice = System.Convert.ToDecimal(PPAC) };
            //    var response2 = net.authorize.sample.ChargeCreditCard.Run(apiLoginId2, transactionKey2, System.Convert.ToInt32(PPAC), "4");
            //}  
            //   if (TransactionMessage1.Length > 0) 
            //   {
            //        TransactionMessages=TransactionMessage1;
            //   }
            //   if (TransactionMessage2.Length > 0) 
            //   {
            //        TransactionMessages=TransactionMessages + "<br/>" + TransactionMessage2;
            //   }
            //   if (TransactionMessage3.Length > 0) 
            //   {
            //         TransactionMessages=TransactionMessages + "<br/>" + TransactionMessage3;

            //   }
            //   if (TransactionMessage4.Length > 0) 
            //   {
            //         TransactionMessages=TransactionMessages + "<br/>" + TransactionMessage4;

            //   }
             }
        }
    }
;