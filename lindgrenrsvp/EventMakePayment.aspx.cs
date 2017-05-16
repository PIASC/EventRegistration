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
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
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


            //var response = net.authorize.sample.ChargeCreditCard.Run(apiLoginId, transactionKey, 100);
            foreach (string s in Request.Form.Keys)
            {
                if (s == "fName")
                {
                    fName = Request.Form["fName"];
                }
                else if (s == "lName")
                {
                    lName = Request.Form["lName"];
                }
                else if (s == "AmountDue")
                {
                    sAmountDue = Request.Form["AmountDue"];
                    AmountDue = System.Convert.ToDecimal(sAmountDue);
                    if (AmountDue == 0.00m)
                    {
                        Server.Transfer("EventReceiptNoCharge.aspx?fName=" + fName + "&lName=" + lName + "&Meal=" + Meal, true);
                    }
                }
                else if (s == "gName" && Request.Form["gName"] != "")
                {
                    //sgName = " and " + Request.Form["gName"];
                    //sgMeal = " and " + Request.Form["gMeal"];
                    gName = Request.Form["gName"];
                    gMeal = Request.Form["gMeal"];

                }
                else if (s == "Meal")
                {
                    //sMeal = "Selected meal: " + Request.Form["rMeal"];
                    Meal = Request.Form["Meal"];
                }
                else if (s == "PIASCDonate")
                {
                    PIASC = Request.Form["PIASCDonate"];
                }
                else if (s == "IPMDonate")
                {
                    IPM = Request.Form["IPMDonate"];
                }
                else if (s == "PPACDonate")
                {
                    PPAC = Request.Form["PPACDonate"];
                }
                else
                {
                    //
                }



                //Response.Write(s.ToString() + ":" + Request.Form[s] + " ");
            }      
        }
    }
}