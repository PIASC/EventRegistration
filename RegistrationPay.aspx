<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationPay.aspx.cs" Inherits="LouACH.RegistrationPay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Summary</title>
     <script type="text/javascript">
         function GoToNext()
         {
             fSummary.action = 'EventMakePayment.aspx';
             fSummary.submit();
         }

</script>
    <link rel="stylesheet" href="StyleSheetMIN.css"  type="text/css" />
</head>
<body>
    <form id="fSummary" runat="server">
     <h3>Reservation Summary</h3>
<div class="box1"  style="text-align:left">
    <label >Reservation For <%=fName%> <%=lName%> <%=sgName%></label><br/>
    <label ><%=sMeal%> <%=sgMeal%></label><br />
    <label> Amount Due: <%=AmountDue %></label><br />
    <h2>
        In lieu of gifts, please support one of Bob Lindgren’s favorite foundations and causes:</h2>
        <p>PIASC/RAISE Foundation   
       
            <asp:DropDownList ID="PIASCDonate" name="PIASCDonate" AutoPostBack="True"  OnSelectedIndexChanged="PIASCAddToTotal" runat="server">
                        <asp:ListItem Text="0" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="$50" Value="50"></asp:ListItem>
                        <asp:ListItem Text="$100" Value="100"></asp:ListItem>
                        <asp:ListItem Text="$200" Value="200"></asp:ListItem>
                        <asp:ListItem Text="$300" Value="300"></asp:ListItem>
                        <asp:ListItem Text="$400" Value="400"></asp:ListItem>
                        <asp:ListItem Text="$500" Value="500"></asp:ListItem>
           </asp:DropDownList></p> 
           <div class="donationList">
               The Foundation’s goal is to foster graphic communications careers in primary, secondary and post-secondary educational institutions. RAISE is, and has been over the years, sustained by individual companies, industry employees, and other foundations.
           </div>   
       <p>International Printing Museum   
       
            <asp:DropDownList ID="IPMDonate" name="IPMDonate" AutoPostBack="True"  OnSelectedIndexChanged="PIASCAddToTotal" runat="server">
                        <asp:ListItem Text="0" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="$50" Value="50"></asp:ListItem>
                        <asp:ListItem Text="$100" Value="100"></asp:ListItem>
                        <asp:ListItem Text="$200" Value="200"></asp:ListItem>
                        <asp:ListItem Text="$300" Value="300"></asp:ListItem>
                        <asp:ListItem Text="$400" Value="400"></asp:ListItem>
                        <asp:ListItem Text="$500" Value="500"></asp:ListItem>
           </asp:DropDownList></p> 
           <div class="donationList">
This dynamic museum is devoted to bringing the history of books, printing, and the book arts to life for diverse audiences. The staff and volunteers make it their mission to take one of the world’s most significant collections of antique printing machinery and interpret it for today’s audiences through working demonstrations and theater presentations.
           </div>   

       <p>PrintPAC   
       
            <asp:DropDownList ID="PPACDonate" name="PPACDonate" AutoPostBack="True"  OnSelectedIndexChanged="PIASCAddToTotal" runat="server" >
                        <asp:ListItem Text="0" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="$50" Value="50"></asp:ListItem>
                        <asp:ListItem Text="$100" Value="100"></asp:ListItem>
                        <asp:ListItem Text="$200" Value="200"></asp:ListItem>
                        <asp:ListItem Text="$300" Value="300"></asp:ListItem>
                        <asp:ListItem Text="$400" Value="400"></asp:ListItem>
                        <asp:ListItem Text="$500" Value="500"></asp:ListItem>
           </asp:DropDownList></p> 
           <div class="donationList">
The official political action committee of Printing Industries of America, is the industry’s most important means of impacting public policy direction and debate pertaining to issues affecting printing and graphic communications companies. PIA member company CEOs, presidents and executive management unite through PrintPAC to support federal candidates that are willing to defend and advance pro-print, pro-business legislation in Washington, DC.

          <%-- </div>      
</div>--%>

        <input type="hidden" id="fName" name="fName" value="<%=fName%>" /><input type="hidden" id="lName" name="lName" value="<%=lName%>" /><input type="hidden" id="gName"  name="gName" value="<%=gName%>" /><input type="hidden" id="Meal"  name="Meal" value="<%=Meal%>" /><input type="hidden" id="gMeal"  name="gMeal" value="<%=gMeal%>" /><input type="hidden" id="AmountDue"  name="AmountDue" value="<%=AmountDue%>" />
  <div>
    <br /><input id="ButtonComplete" type="button" class="Button" value="Complete Registration" onclick="GoToNext()" style="align-self:center"/>
 </div>
    </form>
</body>
</html>
