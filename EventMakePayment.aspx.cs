using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using AuthorizeNet.Api.Contracts.V1;
using net.authorize.sample;

namespace LouACH
{
    public partial class EventMakePayment : System.Web.UI.Page
    {
        //public static string apiLoginId = Constants.API_LOGIN_ID;
        //public static string transactionKey = Constants.TRANSACTION_KEY;
        //public static string sOutput = "";
        public static creditCardType creditCard;
        public static customerAddressType customerAddress;
        public static string fName = "";
        public static string lName = "";
        public static string gName = "";
        //public static string sgName = "";
        public static string Meal = "";
        //public static string sMeal = "";
        public static string gMeal = "";
        //public static string sgMeal = "";
        public static string sAmountDue = "0.00";
        public static string PIASC = "0.00";
        public static string IPM = "0.00";
        public static string PPAC = "0.00";
        public static decimal AmountDue = 0.00m;
        public static LouACH.Events.EventTransaction Transaction1;
        public static LouACH.Events.EventTransaction Transaction2;
        public static LouACH.Events.EventTransaction Transaction3;
        public static LouACH.Events.EventTransaction Transaction4;
        public static List<Events.EventTransaction> allTransactions;
        protected void Page_Load(object sender, EventArgs e)
        {
            //customerAddress = new customerAddressType
            //{
            //    firstName = "John",
            //    lastName = "Doe",
            //    address = "123 My St",
            //    city = "OurTown",
            //    zip = "98004"
            //};

            
            //creditCard = new creditCardType
            //{
            //cardNumber = "4111111111111111",
            //expirationDate = "0718",
            //cardCode = "123"
            //};

            fName = LouACH.RegistrationPay.person.PersonfName;
            lName = LouACH.RegistrationPay.person.PersonlName;
            Meal = LouACH.RegistrationPay.registration.LineItems;

            AmountDue = LouACH.RegistrationPay.registration.Amount;
            if (AmountDue == 0.00m)
            {
                Server.Transfer("EventReceiptNoCharge.aspx?fName=" + fName + "&lName=" + lName + "&Meal=" + Meal, true);
            }
            {
                sAmountDue = AmountDue.ToString("0.##");
            }
            
            List<Events.EventTransaction> allTransactions = new List<Events.EventTransaction> ();

                    //foreach (transaction eTransaction in allTransactions)
                    //{
                    //}
                if (Request.Form["gName"] != "")
                {
                    Transaction1 = new Events.EventTransaction
                    {
                        RegistrationID = LouACH.RegistrationPay.registration.RegistrationID,
                        AmountPaid = 200.00m,
                        LineItem = "Guest " + Request.Form["gName"] + " meal(" + Request.Form["gMeal"] + ")",
                        AccountID="1"
                    };
                    
                    allTransactions.Add(Transaction1);
                    
                    gName = Request.Form["gName"];
                    gMeal = Request.Form["gMeal"];

                };
                
                if (Request.Form["PIASCDonate"] != "0")
                {  
                    Transaction2 = new Events.EventTransaction
                    {
                        RegistrationID=LouACH.RegistrationPay.registration.RegistrationID,
                        AmountPaid= System.Convert.ToDecimal(Request.Form["PIASCDonate"]),
                        LineItem = "PIASC Donation",
                        AccountID = "2"
                    };
                    allTransactions.Add(Transaction2);

                };
                if (Request.Form["IPMDonate"] != "0")
                {  
                    Transaction3 = new Events.EventTransaction
                    {
                        RegistrationID=LouACH.RegistrationPay.registration.RegistrationID,
                        AmountPaid= System.Convert.ToDecimal(Request.Form["IPMDonate"]),
                        LineItem = "IPM Donatation",
                        AccountID = "2"
                    };
                    allTransactions.Add(Transaction3);

                };
                 if (Request.Form["PPACDonate"] != "0")
                {  
                    Transaction4 = new Events.EventTransaction
                    {
                        RegistrationID=LouACH.RegistrationPay.registration.RegistrationID,
                        AmountPaid= System.Convert.ToDecimal(Request.Form["PPACDonate"]),
                        LineItem = "PPAC Donatation",
                        AccountID = "2"
                    };
                    allTransactions.Add(Transaction4);

                };

                 foreach (Events.EventTransaction eTransaction in allTransactions)
                 {
                    //Response.Write(eTransaction.LineItem);
                     //Write to DB
                     eTransaction.TransactionID = Convert.ToInt32(LouACH.DataBaseTransactions.DataBase.SaveTransaction(eTransaction));
                 }

            }

        }
    }
