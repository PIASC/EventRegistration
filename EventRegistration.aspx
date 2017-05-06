<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventRegistration.aspx.cs" Inherits="LouACH.EventRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta content="text/html; charset=ISO-8859-1"  http-equiv="content-type"/>
  <title>Event Registration</title>
  <link rel="stylesheet" href="StyleSheetMIN.css"  type="text/css" />
 <script type="text/javascript">
     function ShowHideDiv(CheckGuest) {
         var guest = document.getElementById("guest");
         var button = document.getElementById("ButtonReserve");
         guest.style.display = CheckGuest.checked ? "block" : "none";
         button.style.display = CheckGuest.checked ? "none" : "block";
     }
     function ShowHideButton() {
         var button = document.getElementById("ButtonReserve");
         //donation.style.display = RadioB.checked ? "block" : "none";
         
         button.style.display = "block";
     }
     function ShowHideGuest(RadioB) {
         var button = document.getElementById("ButtonReserve");
         //donation.style.display = RadioB.checked ? "block" : "none";
         button.style.display = "block";
     }
     function GoToNext() 
     {
         var FName,LName ,Company, Email, emailExp, cGuest,gName;

         FName = document.getElementById('txtFName').value;
         LName = document.getElementById('txtLName').value;
         Company = document.getElementById('txtCoName').value;
         Email = document.getElementById('txtEMail').value;
         emailExp = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([com\co\.\in])+$/; // to validate email id
         cGuest = document.getElementById('CheckGuest').value;
         gName = document.getElementById('txtGuestName').value;
         
         if (FName == '' && LName == '' && Company == '' && Email == '') 
         {
             alert('Enter All Fields');
             return false;
         }
         if (FName == '') 
         {
             alert('Please Enter First Name');
             return false;
         }
         if (LName == '') 
         {
             alert('Please Enter Last Name');
             return false;
         }
         if (Company == '') 
         {
             alert('Please Enter Company or NA');
             return false;
         }

         if (Email == '')
         {
             alert('Email Is Required');
             return false;
         }
         if (Email != '')
         {
             if (!Email.match(emailExp))
             {
                 alert('Invalid Email');
                 return false;
             }
         }
         if (cGuest == '1' && gName=='') {
             alert('Please Enter Guest Name');
             return false;
         }
         fRegister.action = 'RegistrationPay.aspx';
         fRegister.submit();
         //window.location.href = 'RegistrationPay.aspx';
     }

 
</script>

</head>
<body style="height: 600px;">
   <form id="fRegister" runat="server">
<h3>Let us know you’ll be in attendance by choosing the options below! <br />If you have any questions, please don’t hesitate to email us!</h3>
<div class="box2">
<label for="txtCoName">Your Name:</label><input class="TxtArea" id="txtFName" name="txtFName" size="50"/><input class="TxtArea" id="txtLName"  name="txtLName"  size="50"/><br/>
<label for="txtCoName">Company:</label><input class="TxtArea" name="txtCoName" id="txtCoName"/><br/>
<label for="txtCoName">EMail:</label><input class="TxtArea" id="txtEMail" name="txtEMail"/><br/><label class="RadioLabel">Select Meal:</label>
    <input id="Radio1" type="radio" name="rMeal"  value="Filet Mignon" onchange="ShowHideButton()"/><label class="RadioLabel">Filet Mignon  </label><input id="Radio2" type="radio" name="rMeal" value="Chilean Sea Bass" onchange="ShowHideButton()" /><label class="RadioLabel">Chilean Sea Bass</label>  <input id="Radio3" type="radio" name="rMeal" value="Vegetarian Pasta"  onchange="ShowHideButton()"/><label class="RadioLabel">Vegetarian Pasta</label><br/>
<br /><input id="CheckGuest"  name="CheckGuest" type="checkbox" value="1" onchange="ShowHideDiv(this)"/><label class="QuestionLabel">I will be bringing spouse/guest ($200 charge). </label><br /><br />

<div id="guest" class="box3" <%--style="display: none"--%>> 
<label for="txtCoName">Guest Name:</label><input class="TxtArea" id="txtGuestName" name="txtGuestName" value=""/><br/><label class="RadioLabel">Select Meal:</label><br />
        <input id="Radiog1" type="radio" name="gMeal" value="Filet Mignon" onchange="ShowHideButton()" /><label class="RadioLabel">Filet Mignon  </label><input id="Radiog2" type="radio" name="gMeal" value="Chilean Sea Bass" onchange="ShowHideButton()"  /><label class="RadioLabel">Chilean Sea Bass</label>  <input id="Radiog3" type="radio" name="gMeal" value="Vegetarian Pasta"  onchange="ShowHideButton()" /><label class="RadioLabel">Vegetarian Pasta</label><br/>
</div>
<%--<div id="donation" class="box4" style="display: none"> 
<label for="txtCoName">In lieu of gifts, please support one of Bob Lindgren’s favorite foundations and causes: </label>
 
</div>--%>
    <div>
    <input id="ButtonReserve" type="button" class="ResButton" value="Make Reservation" onclick="GoToNext()" />
 </div>
</div>
       </form>
</body>
</html>
