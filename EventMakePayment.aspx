<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventMakePayment.aspx.cs" Inherits="LouACH.EventMakePayment" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Payment</title>
    <link rel="stylesheet" href="StyleSheetMIN.css"  type="text/css" />
     <script type="text/javascript">
         function GoToNext()
         {
             var Address, City, State, Zip, CCNo, CCExp, CCCode;
             
             Address = document.getElementById('txtAddress').value;
             
             City = document.getElementById('txtCity').value;
             State = document.getElementById('txtState').value;
             Zip = document.getElementById('txtZip').value;
             CCNo = document.getElementById('txtCC').value;
             CCExp = document.getElementById('txtExpDt').value;
             CCCode = document.getElementById('txtSecNo').value;
             
             if (Address == '' && City == '' && State == '' && Zip == '' && CCNo == '' && CCExp == '' && CCCode == '')
             {
                 alert('Enter All Fields');
                 return false;
             }
             if (Address == '') {
                 alert('Please Enter Address');
                 return false;
             }
             if (City == '') {
                 alert('Please Enter City');
                 return false;
             }
              if (State.length!=2)
             {
                 alert('Please Enter State Abbreviation');
                 return false;
             }

             if (Zip == '' || isNaN(Zip)) {
                 alert('Please enter Zip Code');
                 return false;
             }

             if (CCNo == '' || isNaN(CCNo)) {
                 alert('Please Credit Card No (no spaces)');
                 return false;
             }
             //if (CCExp == '' || CCExp.substring(2, 3) !== '/') {
               if (CCExp == ''||  isNaN(CCExp)) {
                     alert('Please Credit Card Expiration date (mmyy)');
                 return false;
             }
             if (CCCode == '' || isNaN(CCCode)) {
                 alert('Please Credit Card security code');
                 return false;
             }

             fPayment.action = 'EventReceipt.aspx';
             fPayment.submit();
                    }
</script>
</head>
<body>
    <form id="fPayment" runat="server">
    <div>
    <%--<%=sOutput %>--%>
        <div class="box2">
        <label for="txtAmount">Amount Due:</label><input class="TxtArea" name="txtAmount" id="txtAmount" ="10" value="<%=sAmountDue %>"/><br/><br/>
        <label for="txtCoName">Name:</label><input class="TxtArea" name="txtFName" value="<%=fName %>" style="width:150px" placeholder="First Name"/><input class="TxtArea" name="txtLName" value="<%=lName %>" style="width:150px"  placeholder="Last Name"/><br/>
        <label for="txtAddress">Address:</label><input class="TxtArea" name="txtAddress"  id="txtAddress" value="" style="width:300px"/><br />
        <label for="txtCity">City:</label><input class="TxtArea" name="txtCity"  id="txtCity" value=""/ style="width:300px"/><br />
        <label for="txtState">State:</label><input class="StateArea" name="txtState"  id="txtState" value="" style="width:50px"/>
        <label for="txtZip">Zip:</label><input class="StateArea" name="txtZip"  id="txtZip" value="" style="width:100px"/><br /><br />
        <label for="txtCC">Card Number:</label><input class="StateArea" name="txtCC"  id="txtCC" value="4111111111111111"  style="width:250px"/><br />
        <label for="txtExpDt">Expiration:</label><input class="StateArea" name="txtExpDt"  id="txtExpDt" value=""  style="width:75px"  placeholder="  mmyy"/><label for="txtSecNo">Security Code:</label><input class="StateArea" name="txtSecNo"  id="txtSecNo" value="" style="width:75px"/><br />
        <br /><br />
            <input type="hidden" id="GuestName"  name="GuestName" value="<%=gName%>" /><input type="hidden" id="GuestMeal"  name="GuestMeal" value="<%=gMeal%>" /><input type="hidden" id="Meal"  name="Meal" value="<%=Meal%>"/>
            <input type="hidden" id="PIASC"  name="PIASC" value="<%=PIASC%>" /><input type="hidden" id="IPM"  name="IPM" value="<%=IPM%>" /><input type="hidden" id="PPAC"  name="PPAC" value="<%=PPAC%>" />
            <input id="ButtonPay" type="button" value="Make Payment" onclick="GoToNext()" />
          </div>  
    </div>
    </form>
</body> 
</html>
