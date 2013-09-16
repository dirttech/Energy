<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Reset Password</title>
    
<link rel="shortcut icon" href="../images/dashboard_icon.png" />
    <link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />
    <script type="text/javascript">
        function CopyHidden(ths) {

            var hid = ths.getAttribute("UID");
            document.getElementById('<%=Hidden1.ClientID%>').setAttribute("value", hid);
        }

    </script>
    <script src="http://crypto-js.googlecode.com/svn/tags/3.1.2/build/rollups/md5.js"></script>
<script>
    function extractPass() {


        var msg1 = document.getElementById('<%=pwd2.ClientID%>').value;
        var hash1 = CryptoJS.MD5(msg1);
        document.getElementById('<%=newHidPwd.ClientID%>').value = hash1;


    }
    </script>

     <style type="text/css">

    td
{
  font-family:Verdana;
      
}

span
{
 margin:0px;
 padding:0px;
 font-family:Verdana;
}

select {
    -webkit-appearance:none;
    border: 1;
   background-color: #92CDF1;
   font-weight:normal;
   font-size:large;
   cursor:pointer;
    padding-right: 30px;
    width:123px;
    height:27px;
    color:white;
}
.pops
{   
    background-color:#265D85;  opacity:0.95; display:none;  padding:10px; padding-right:0px;box-shadow: 0px 0px 8px 1px #000000;
    width:330px;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    
        <div class="SideBar" style="top:0px; left:10px;">
    <div class="HeadingLeftTop" style="opacity:0.9; width:93.3%">
     <label id="Heading" runat="server" style=" font-size:x-large;">    Users</label>    
    <label id="subHeading" runat="server" style="font-size:small;" ></label>
    </div>
      <div id="sideBar" runat="server" style="background-color:skyblue; padding-left:20px;">
      
    
    </div>
    </div>

    <table id="mapUser" runat="server" class="pops">
    
    <tr>
    <td colspan="3" >
    <div class="HeadingLeftTop" style="background-color:White;"  >
                <asp:Label ID="Top2" runat="server" Font-Bold="False" style="font-size:large; color:#265D85;line-height:19px;" >Reset Password</asp:Label>
                <img src="../images/closeButton.png" id="closer" alt="close" style="cursor:pointer; vertical-align:top;" align="right"  width  ="20px"/>
            </div>
            </td>
    </tr>
    
    <tr>

    <td>Password</td><td>Confirm Password<input type="hidden" runat="server" id="hiddenUser" /></td><td></td>
    </tr>
    <tr>
    <td>
    <asp:TextBox ID="pwd1" runat="server" TextMode="Password"></asp:TextBox>
    </td><td>
    <asp:TextBox ID="pwd2" runat="server" TextMode="Password"></asp:TextBox>
    </td><td>
            &nbsp;</td>
    </tr>
    <tr>
    <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="pwd1" Display="Dynamic" ErrorMessage="*Required" 
                    SetFocusOnError="True" ForeColor="white"></asp:RequiredFieldValidator>
                </td><td align="right">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="pwd2" Display="Dynamic" ErrorMessage="*Required" 
                    SetFocusOnError="True" ForeColor="white"></asp:RequiredFieldValidator>
               
                <asp:Label ID="green0" runat="server" Font-Bold="False" ForeColor="white"></asp:Label>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="pwd1" ControlToValidate="pwd2" Display="Dynamic" 
                    ErrorMessage="Password mismatch" ForeColor="White" SetFocusOnError="True"></asp:CompareValidator>
        <asp:Button ID="store" runat="server" Text="Store" class="customButton" onClientClick="extractPass()" 
                onclick="store_Click" />
                    <input id="newHidPwd" type="hidden" runat="server" />
    
        </td><td>
                &nbsp;
        <input id="Hidden1" type="hidden" runat="server"/></td>
    </tr>
    
    
    </table>
      <script type="text/javascript"
     src="../Scripts/calender/jquery.min.js">
    </script> 
       <script type="text/jscript">
           jQuery(document).ready(function ($) {


               $('.clicker').hover(function () {
                   $('.clicker').css('font-size', 'large');
                   $(this).css('font-size', 'x-large');


               });
               $('.clicker').click(function () {
                   var offset = $(this).offset();
                   $("#mapUser").hide();
                   $("#mapUser").show("slow");
                   $("#mapUser").offset({ top: offset.top - 4, left: offset.left + 145 });
                   $("#green0").text("");

               });
               $('#closer').click(function () {
                   $("#mapUser").hide("drop");
               });
           });
           </script>  

    </form>
</body>
</html>
