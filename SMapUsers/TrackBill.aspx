<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrackBill.aspx.cs" Inherits="TrackBill" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />
    <script type="text/javascript" src="http://code.jquery.com/jquery-latest.min.js"></script>

  <link rel="shortcut icon" href="../images/dashboard_icon.png" />

   <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $('#options').click(function () {

                $('#optionsDiv').toggle("slow");
            });

           
        });
        </script>
  <style type="text/css">
       #optionsDiv
    {
      display:none;  
      text-decoration:none;
      border-radius:2px;
      -webkit-box-shadow: 0px 0px 8px 0px #000000;
-moz-box-shadow: 0px 0px 8px 0px #000000;
box-shadow: 0px 0px 8px 0px #000000;
 text-align:center;
 vertical-align:bottom;
 color:#1a9cc8;
 line-height:20px;

    }
       a
      {
          font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
          text-decoration:none;
      }
        a:hover
        {
             text-decoration:none;
        }
        p, h2, h3
        {
          font-family:Verdana;   
        }
        
        h3
        {
             color:#265D85;
        }
        .bill-wrapper
        {
            position:relative;
           background-color:#1a9cc8;
           width:300px;  
           padding:5px;
           margin:15px;
            box-shadow: 0px 0px 8px 1px #000000;
            opacity:0.9;
            float:left;
        }
        
  
  </style>
    <title>Track Bill</title>
</head>
<body>
    <form id="form1" runat="server">
  <div id="navigationTop">
  <a href="front.aspx">Home</a>
   <a href="PowerConsumption.aspx" >Power Consumption</a>

     <a href="BarGraph.aspx">Energy Consumption</a>

     <a href="AverageComparison.aspx" >Me! vs Average</a>

     <a href="TrackBill.aspx" >Track Bill</a>
     
     </div>


     <img src="../images/icons/option-icon.png" height="20px" style=" height:20px;color:Black; font-weight:bold;  position:absolute; top:15px; right:20px; cursor:pointer;" id="options" />
     <div style="position:absolute; right:15px; top:45px; background-color:White; width:150px; height:170px; z-index:10;" id="optionsDiv">
     <br /> 
     <hr />
      <a href="../UserSettings/EditUserProfile.aspx" style=" color:#1a9cc8;">Edit Profile</a>
     <hr />
     <a href="../UserSettings/ResetUserPassword.aspx" style=" color:#1a9cc8;" >Reset Password</a><br />
      <hr />
    
     <asp:LinkButton ID="logOut" runat="server"  
        
      style=" color:black;"  onclick="logOut_Click">LOG OUT</asp:LinkButton>
     
     <hr />
     </div>  <a style="color:Black;  font-size:large;  position:absolute; top:10px; left:20px;" id="nameTitle" runat="server">Welcome</a>
     
     <br />

       <div class="HeadingLeftTop" style=" width:300px;">
    <label id="Heading" runat="server" style=" font-size:x-large;">Last Night</label>    
    <label id="subHeading" runat="server" style="font-size:small;" ></label>
    </div>

     <div id="billingContainer" runat="server" style="display:none;"></div>

    </form>
</body>
</html>
