using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LouACH
{
    public partial class EventReceiptNoCharge : System.Web.UI.Page
    {
        public static string fName = "";
        public static string lName = "";
        public static string Meal = "";
 
        protected void Page_Load(object sender, EventArgs e)
        {

            fName = LouACH.RegistrationPay.person.PersonfName;
            lName = LouACH.RegistrationPay.person.PersonlName;
            Meal = LouACH.RegistrationPay.registration.LineItems;

            //foreach (string s in Request.QueryString)
            //{

            //    if (s == "fName")
            //    {
            //        fName = Request.Form["fName"];
            //    }
            //    else if (s == "lName")
            //    {
            //        lName = Request.Form["lName"];
            //    }
            //    else if (s == "Meal")
            //    {
            //        Meal = Request.Form["Meal"];
            //    }

                // FOR TEST  Response.Write(s.ToString() + ":" + Request.QueryString[s] + " ");
            }
            string response = LouACH.DataBaseTransactions.DataBase.WriteEventTransactionDataNoCharge(LouACH.RegistrationPay.registration);

        }
    }
