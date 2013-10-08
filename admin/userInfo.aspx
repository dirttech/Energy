<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userInfo.aspx.cs" Inherits="admin_userInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="shortcut icon" href="../images/dashboard_icon.png" />
    <title>User Info</title>
    <style type="text/css">
     a
      {
          text-decoration:none;
          cursor:pointer;
          line-height:20px;
      }
    
    </style>
     <script type="text/javascript">
         function pageLoad(page1) {
             frames['sideFrame'].location.href = page1;
         }
    
    </script>
     <link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />
    
</head>
<body>
    <form id="form1" runat="server">
    <table >
    <tr>
    <td style="vertical-align:top; " align="left">
    
<div class="HeadingLeftTop">
<label id="Heading" runat="server" style=" font-size:x-large;">User Info</label>
<label id="subHeading" runat="server" style="font-size:small; " ></label>
</div>
    <div id="NavigationContainer">
    <ul id="Navigation" style="padding:0px; margin-top:4px;">
    <li><a class="navy" onclick="pageLoad('ImportBuildingSchema.aspx')">Import Building Schema</a></li>
    <li><a class="navy" onclick="pageLoad('AprooveRegistrationRequests.aspx')">Confirm Registration</a></li>
    <li><a class="navy" onclick="pageLoad('AddEnergyTips.aspx')">Energy Saving Tips</a></li>
   <li><a class="navy" onclick="pageLoad('CreateUser.aspx')" style="display:none;">Create User</a></li>
    <li><a class="navy" onclick="pageLoad('AssignMeter.aspx')" style="display:none;">Assign Meter</a></li>
    <li><a class="navy" onclick="pageLoad('ChangeMeter.aspx')" style="display:none;" >Change Meter</a></li>
    <li><a class="navy" onclick = "pageLoad('ResetPassword.aspx')">Reset Password</a></li>
  </ul>

    </div>
    </td>
    <td style="vertical-align:top; margin-top:0px; padding-top:0px;">
       <iframe id="sideFrame" style="border:none; height:800px;  width:1000px; overflow:visible;"></iframe>
    </td>
    </tr>
    </table>
    
     <script type="text/javascript"
     src="../Scripts/calender/jquery.min.js">
     </script>
   <script type="text/jscript">
       jQuery(document).ready(function ($) {
        
           $('.navy').hover(function () {
               $('.navy').css('font-size', 'large');
               $(this).css('font-size', 'x-large');


           });
           $(".navy").click(function () {
               var mesg = $(this).attr("msg");
               //                $(".navy").removeClass("activeLink");
               //                $(this).addClass("activeLink");
               $("#messg").text(mesg);
               $("#popsup").show("slow");

           });
       

       });
       
    </script>


    </form>
</body>
</html>
