﻿using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers.Bases;
//using Oracle.ManagedDataAccess.Client;
using LouACH;
namespace net.authorize.sample
{
    public class DebitBankAccount
    {
        
        public static ANetApiResponse Run(String ApiLoginID, String ApiTransactionKey, String EmployerID, Decimal Amount)
        {
            
            //Console.WriteLine("Debit Bank Account Transaction");

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            // define the merchant information (authentication / transaction id)
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = ApiLoginID,
                ItemElementName = ItemChoiceType.transactionKey,
                Item = ApiTransactionKey
            };
           // Get bankData
                //OracleDataReader readerEmployer;
            bankAccountType bankAccount;
            bankAccount = LouACH.DataBaseTransactions.DataBase.ReadBankData();

            
            //readerEmployer.Read();
            //var bankAccount = new bankAccountType
            //    {
            //        accountNumber = Convert.ToString(readerEmployer.GetInt32(4)),
            //        routingNumber = Convert.ToString(readerEmployer.GetValue(6)),
            //        echeckType = echeckTypeEnum.WEB,   // change based on how you take the payment (web, telephone, etc)
            //        nameOnAccount = readerEmployer.GetString(7)
            //    };
            //var bankAccount = new bankAccountType
            //{
            //    accountNumber = "4111111",
            //    routingNumber = "325070760",
            //    echeckType = echeckTypeEnum.WEB,   // change based on how you take the payment (web, telephone, etc)
            //    nameOnAccount = "Test Name"
            //};

            //standard api call to retrieve response
            var paymentType = new paymentType { Item = bankAccount };

            var transactionRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),    // refund type
                payment = paymentType,
                amount = Amount
            };

            var request = new createTransactionRequest { transactionRequest = transactionRequest };

            // instantiate the contoller that will call the service
            var controller = new createTransactionController(request);
            controller.Execute();

            // get the response from the service (errors contained if any)
            var response = controller.GetApiResponse();

            //validate
            if (response != null)
            {
                if (response.messages.resultCode == messageTypeEnum.Ok)
                {
                    if (response.transactionResponse.messages != null)
                    {
                        //Console.WriteLine("Successfully created transaction with Transaction ID: " + response.transactionResponse.transId);
                        //Console.WriteLine("Response Code: " + response.transactionResponse.responseCode);
                        //Console.WriteLine("Message Code: " + response.transactionResponse.messages[0].code);
                        //Console.WriteLine("Description: " + response.transactionResponse.messages[0].description);
                        //Console.WriteLine("Success, Transaction Code : " + response.transactionResponse.transId);
                        LouACH.Main.theOutput = "Successfully created transaction with Transaction ID: " + response.transactionResponse.transId;
                        //Record transaction
                        var result = "";
                        result = LouACH.DataBaseTransactions.DataBase.WriteTransactionData(response.transactionResponse.transId,Amount,bankAccount);
                    }
                    else
                    {
                        //Console.WriteLine("Failed Transaction.");
                        if (response.transactionResponse.errors != null)
                        {
                            //Console.WriteLine("Error Code: " + response.transactionResponse.errors[0].errorCode);
                            //Console.WriteLine("Error message: " + response.transactionResponse.errors[0].errorText);
                            LouACH.Main.theOutput = response.transactionResponse.errors[0].errorText;
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
                        LouACH.Main.theOutput = response.transactionResponse.errors[0].errorText;
                    }
                    else
                    {
                        //Console.WriteLine("Error Code: " + response.messages.message[0].code);
                        //Console.WriteLine("Error message: " + response.messages.message[0].text);
                        LouACH.Main.theOutput = response.messages.message[0].text + "(" + response.transactionResponse.errors[0].errorText + ")";
                    }
                }
            }
            else
            {
                //Console.WriteLine("Null Response.");
                LouACH.Main.theOutput = "ERROR";
            }

            return response;
        }
    }

}