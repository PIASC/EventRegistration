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
using System.Net;
using System.Net.Mail;
using Microsoft.Office.Interop.Word;


namespace LouACH
{

    public partial class EventReceipt : System.Web.UI.Page
    {

        public static string apiLoginId;
        public static string transactionKey;

        //public static string apiLoginId1 = Constants.API_LOGIN_ID;
        //public static string transactionKey1 = Constants.TRANSACTION_KEY;
        //public static string apiLoginId2 = Constants.API_LOGIN_ID2;
        //public static string transactionKey2 = Constants.TRANSACTION_KEY2;
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
        public static string connectionString = Constants.CONNECTION_STRING_Local;
        public static decimal UnitPrice = 0.00m;

        protected void Page_Load(object sender, EventArgs e)
        {
            string Item = "";
            //decimal UnitPrice = 0.00m;
            int Account = 1;
            email_send();
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
            Meal = Request.Form["Meal"];
            
            if (Request.Form["GuestName"] != "")
                {
                    gName = Request.Form["GuestName"];
                    gMeal = Request.Form["GuestMeal"];
                    sgName = " and " + gName;
                    sgMeal = " and " + gMeal;
                    sAmountDue = Request.Form["txtAmount"];                 //200.00m;
                }
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
                        Account = dr.GetInt32(6);
                        switch (Account)
                        {
                            case 1:
                               apiLoginId = Constants.API_LOGIN_ID;
                               transactionKey = Constants.TRANSACTION_KEY;
                                break;
                            case 2:
                               apiLoginId = Constants.API_LOGIN_ID2;
                               transactionKey = Constants.TRANSACTION_KEY2;
                                break;
                        }
                        var response = net.authorize.sample.ChargeCreditCard.Run(apiLoginId, transactionKey, Decimal.ToInt32(UnitPrice));
                        TransactionMessages = TransactionMessages + "<br/>" + Item + "-" + UnitPrice.ToString("C") + "<br/>&nbsp;&nbsp;" + TransactionMessage;
                    }
                    command.Connection.Close();
                }
             }


            public void email_send()
            {


                //Microsoft.Office.Interop.Word.Document wordDocument = new Microsoft.Office.Interop.Word.Document();
                
                //Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
                //wordDocument = appWord.Documents.Open(@"D:\desktop\xxxxxx.docx");

                //this.FindAndReplace(wordDocument, "<Date>", "06/12/2017");
                //wordDocument.ExportAsFixedFormat(@"D:\desktop\DocTo.pdf", WdExportFormat.wdExportFormatPDF);
                
                
                
                
                
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("your mail@gmail.com");
                mail.To.Add("hgoodman@cgc-intl.com");
                mail.Subject = "Test Mail - 1";
                mail.Body = "mail with attachment";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment("D:\\HSG\\GPa.txt");
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("hgood", "harvey");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

            }
            private void FindAndReplace(Microsoft.Office.Interop.Word.Application wordApp, object findText, object replaceText)
            {
                object matchCase = true;
                object matchWholeWord = true;
                object matchWildCards = false;
                object matchSoundsLike = false;
                object matchAllWordForms = false;
                object forward = true;
                object format = false;
                object matchKashida = false;
                object matchDiacritics = false;
                object matchAlefHamza = false;
                object matchControl = false;
                object read_only = false;
                object visible = true;
                object replace = 2;
                object wrap = 1;
                wordApp.Selection.Find.Execute(ref findText, ref matchCase,
                    ref matchWholeWord, ref matchWildCards, ref matchSoundsLike,
                    ref matchAllWordForms, ref forward, ref wrap, ref format,
                    ref replaceText, ref replace, ref matchKashida,
                            ref matchDiacritics,
                    ref matchAlefHamza, ref matchControl);
            }
        }
    }
;