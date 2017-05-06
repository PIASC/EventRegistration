using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LouACH
{
    public partial class RegistrationPay : System.Web.UI.Page
    {
        public static string fName = "";
        public static string lName = "";
        public static string gName = "";
        public static string sgName = "";
        public static string Meal = "";
        public static string sMeal = "";
        public static string gMeal = "";
        public static string sgMeal = "";
        public static decimal AmountDue = 0.00m;
        public static decimal gAmount = 0.00m;
        public static decimal Amount1 = 0.00m;
        public static decimal Amount2 = 0.00m;
        public static decimal Amount3 = 0.00m;

        protected void Page_Load(object sender, EventArgs e)
        {

            foreach (string s in Request.Form.Keys)
            {
                if (s == "txtFName")
                {
                    fName = Request.Form["txtFName"];
                }
                else if (s == "txtLName")
                {
                    lName = Request.Form["txtLName"];
                }
                else if (s == "txtGuestName" && Request.Form["txtGuestName"] != "")
                {
                    gName = Request.Form["txtGuestName"];
                    gMeal =Request.Form["gMeal"];
                    sgName = " and " + Request.Form["txtGuestName"];
                    sgMeal = " and " + Request.Form["gMeal"];
                    gAmount = 200.00m;
                    AmountDue = 200.00m;
                }
                else if (s == "rMeal")
                {
                    sMeal = "Selected meal: " + Request.Form["rMeal"];
                    Meal = Request.Form["rMeal"];
                }
                else
                {
                    //
                }



                //Response.Write(s.ToString() + ":" + Request.Form[s] + " ");
            }
            
        }
                protected void PIASCAddToTotal(object sender, EventArgs e)
                {
                    Amount1 = System.Convert.ToDecimal(PIASCDonate.SelectedItem.Value);
                    Amount2 = System.Convert.ToDecimal(IPMDonate.SelectedItem.Value);
                    Amount3 = System.Convert.ToDecimal(PPACDonate.SelectedItem.Value);
                    AmountDue = gAmount + Amount1;     // System.Convert.ToDecimal(PIASCDonate.SelectedItem.Value);
                    AmountDue = AmountDue + Amount2;   // System.Convert.ToDecimal(IPMDonate.SelectedItem.Value);
                    AmountDue = AmountDue + Amount3;   // System.Convert.ToDecimal(PPACDonate.SelectedItem.Value);
                    
                }
            }
}