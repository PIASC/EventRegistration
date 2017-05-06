﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventReceipt.aspx.cs" Inherits="LouACH.EventReceipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Receipt</title>
      <link rel="stylesheet" href="StyleSheetMIN.css"  type="text/css" />
</head>
<body>
    <form id="fReceipt" runat="server">
    <div style="align-content:center">
   <h2> RECEIPT<br />for<br />Bob Lindgrin's Retirement Dinner<br />
       June 4, 2017  7:30PM<br/>
       Lou's House<br/>
       1 Main street<br/>
       San Juan Capistrano CA 92675<br/>
   </h2>

        <div class="divCentered">
            <h2>
        Reservation for <%=customerAddress.firstName %> <%=customerAddress.lastName %><br />
        Meal Selection: <%=Meal %> <br /><br />
                ***PAYMENT SUMMARY***</h2><br />

        Transaction Date: <%=DateTime.Now.ToString("MMM dd,yyyy HH:mm")%><br />
        Credit Card: ****<%=CC.Substring(CC.Length - 4)%><br />
        Total Amount:<%="$100.00" %><br /><br />

            ITEM<br />
        Guest Charge:<% =TransactionMessage1%>:<% =TransactionCode1%><br />
        Donation:<% =TransactionMessage2%>:<% =TransactionCode2%><br /> 
        </div>
    </div>
    </form>
</body>
</html>
