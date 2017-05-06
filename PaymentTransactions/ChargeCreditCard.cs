using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers.Bases;
using LouACH;
    namespace net.authorize.sample

{
    public class ChargeCreditCard
    {
        public static ANetApiResponse Run(String ApiLoginID, String ApiTransactionKey, decimal amount,string Account )
        {
            //Console.WriteLine("Charge Credit Card Sample");

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
            //ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.PRODUCTION;

            // define the merchant information (authentication / transaction id)
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = ApiLoginID,
                ItemElementName = ItemChoiceType.transactionKey,
                Item = ApiTransactionKey,
            };
            ;
            //var creditCard = new creditCardType
            //{
            //    cardNumber = "0",
            //    expirationDate = "0718",
            //    cardCode = "123"
            //};

            creditCardType creditCard;
            creditCard = LouACH.EventReceipt.creditCard;

            customerAddressType billingAddress;
            billingAddress = LouACH.EventReceipt.customerAddress;


            //var billingAddress = new customerAddressType
            //{
            //    firstName = "John",
            //    lastName = "Doe",
            //    address = "123 My St",
            //    city = "OurTown",
            //    zip = "98004"
            //};

            //standard api call to retrieve response
            var paymentType = new paymentType { Item = creditCard };

            // Add line Items
            //var lineItems = new lineItemType[2];
            //lineItems[0] = new lineItemType { itemId = "1", name = "t-shirt", quantity = 2, unitPrice = new Decimal(15.00) };
            //lineItems[1] = new lineItemType { itemId = "2", name = "snowboard", quantity = 1, unitPrice = new Decimal(450.00) };
            var lineItems = new lineItemType[1];
            lineItems[0] = LouACH.EventReceipt.lineItems;
                   
            var transactionRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),    // charge the card

                amount = amount,
                payment = paymentType,
                billTo = billingAddress,
                lineItems = lineItems
            };
            
            var request = new createTransactionRequest { transactionRequest = transactionRequest };
            
            // instantiate the contoller that will call the service
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            var controller = new createTransactionController(request);
            controller.Execute();
            
            // get the response from the service (errors contained if any)
            var response = controller.GetApiResponse();

            //validate
            if (response != null)
            {
                if (response.messages.resultCode == messageTypeEnum.Ok)
                {
                    if(response.transactionResponse.messages != null)
                    {
                        //Console.WriteLine("Successfully created transaction with Transaction ID: " + response.transactionResponse.transId);
                        //Console.WriteLine("Response Code: " + response.transactionResponse.responseCode);
                        //Console.WriteLine("Message Code: " + response.transactionResponse.messages[0].code);
                        //Console.WriteLine("Description: " + response.transactionResponse.messages[0].description);
                        //Console.WriteLine("Success, Auth Code : " + response.transactionResponse.authCode);
                        if (Account=="1")
                        {LouACH.EventReceipt.TransactionCode1 = response.transactionResponse.transId;
                         LouACH.EventReceipt.TransactionMessage1 = "Guest Reservation: $200" + response.transactionResponse.messages[0].description + "(Transaction ID: " + response.transactionResponse.transId + ")";
                        }
                        else if (Account == "2")
                        {
                            LouACH.EventReceipt.TransactionCode2 = response.transactionResponse.transId;
                            LouACH.EventReceipt.TransactionMessage2 = "PIASC Donation: " + amount.ToString("C") + response.transactionResponse.messages[0].description + "(Transaction ID: " + response.transactionResponse.transId + ")";
                        }
                        else if (Account == "3")
                        {
                            LouACH.EventReceipt.TransactionCode3 = response.transactionResponse.transId;
                            LouACH.EventReceipt.TransactionMessage3 = "IPM Donation: " + amount.ToString("C") + response.transactionResponse.messages[0].description + "(Transaction ID: " + response.transactionResponse.transId + ")";
                        }
                        else if (Account == "4")
                        {
                            LouACH.EventReceipt.TransactionCode4 = response.transactionResponse.transId;
                            LouACH.EventReceipt.TransactionMessage4 = "PPAC Donation: " + amount.ToString("C") + response.transactionResponse.messages[0].description + "(Transaction ID: " + response.transactionResponse.transId + ")";
                        }
                    }
                    else
                    {
                        //Console.WriteLine("Failed Transaction.");
                       //LouACH.EventMakePayment.sOutput = "Failed Transaction.";
                        if (response.transactionResponse.errors != null)
                        {
                            //Console.WriteLine("Error Code: " + response.transactionResponse.errors[0].errorCode);
                            //Console.WriteLine("Error message: " + response.transactionResponse.errors[0].errorText);
                            
                        }
                    }
                }
                else
                {
                    //Console.WriteLine("Failed Transaction.");
                    if (response.transactionResponse != null && response.transactionResponse.errors != null)
                    {
                        //Console.WriteLine("Error Code: " + response.transactionResponse.errors[0].errorCode);
                        //Console.WriteLine("Error message: " + response.transactionResponse.errors[0].errorText);
                    }
                    else
                    {
                        //Console.WriteLine("Error Code: " + response.messages.message[0].code);
                        //Console.WriteLine("Error message: " + "Error Code: " + response.messages.message[0].Text);
                    }
                }
            }
            else
            {
                //Console.WriteLine("Null Response.");
            }

            return response;
        }
    }
}
