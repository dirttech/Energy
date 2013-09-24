<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="Stylesheet" type="text/css" href="Scripts/LoginStyle.css" />
    <link rel="shortcut icon" href="images/dashboard_icon.png" />
    <style type="text/css">
        a
        {
            text-decoration:underline;
            color:White;
            
        }
        a:hover
        {
            color:orange;
        }
    
    
    </style>
    
<script type="text/javascript" src="Scripts/jquery.customSelect.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {

            $('select.styled').customSelect();
            /* -OR- set a custom class name for the stylable element */
            //            $('.mySelectBoxClass').customSelect({ customClass: 'myOwnClassName' });
        });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
        <table  style="background-image:url('images/ene.jpg'); background-repeat:no-repeat; -webkit-background-size: cover;
        -moz-background-size: cover;
        -o-background-size: cover; background-size:cover; width: 100%; height:630px;">
        <tr>
        <td style="width:600px; vertical-align:top; padding-top:50px; padding-left:40px;">

      <h3>Average indian house is consuming <font color="red">1100 KWhr </font>of energy every year.</h3>  <br /> 
      
      Want to know yours?&nbsp;&nbsp;<a href="Loggin.aspx">Login here </a>

      <br /><br />

      <h3>Do you know?</h3><br />
      A front loading washing machine is always more efficient than a top load washing machine!
      <br /><br />
 Try some of these <a href="Tips.aspx">energy-saving ideas </a>

        </td>
        <td style="vertical-align:top;">

<div class="LoginContainer" >
  <div class="login" >
    <h1>Register</h1>
    <p style="line-height:normal; height:10px;">Apartment no</p>
    <p>
        <asp:DropDownList ID="apartmentList" class="styled" placeholder="Apartment" runat="server" DataSourceID="SqlDataSource1"  DataTextField="Apartment" DataValueField="Apartment">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:BillingAppConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:BillingAppConnectionString.ProviderName %>" 
            
            SelectCommand="Select Distinct (Apartment) from meter_map where Building = 'Faculty Housing'"></asp:SqlDataSource>
       </p>
    <p><asp:TextBox type="text" name="email" Text="" 
            placeholder="E-Mail (We will send your login details here)" runat="server" 
            id="email" causesvalidation="True" /><asp:RegularExpressionValidator 
            ID="RegularExpressionValidator1" runat="server" ControlToValidate="email" 
            Display="Dynamic" ErrorMessage="Invalid Email" SetFocusOnError="True" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="email" Display="Dynamic" ErrorMessage="Invalid Email" 
            SetFocusOnError="True"></asp:RequiredFieldValidator>
      </p>
      <p><input type="text" name="contactNo" value="" placeholder="Contact No (In case we need to contact you)" runat="server" id="contactNo" /></p>
     
      <p class="submit">
          <asp:Button ID="registerUser" runat="server" Text="Register" 
              onclick="registerUser_Click" /></p>
              <p><asp:Label ID="msg" Text="" runat="server" style="color:#c4376b; font-weight:bold;"></asp:Label></p>
   
  </div>
 
</div>
</td>
        </tr>      
        </table>
   





</asp:Content>

