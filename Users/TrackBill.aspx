<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrackBill.aspx.cs" Inherits="TrackBill" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />
  <link rel="shortcut icon" href="../images/dashboard_icon.png" />
  <style type="text/css">
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


     <asp:LinkButton ID="logOut" runat="server"  
        style="color:Black; font-weight:bold;  position:absolute; top:5px; right:20px;" 
        onclick="logOut_Click">LOG OUT</asp:LinkButton>
     <a style="color:Black;  font-size:large;  position:absolute; top:10px; left:20px;" id="nameTitle" runat="server">Welcome</a>
     
     <br />

       <div class="HeadingLeftTop" style=" width:300px;">
    <label id="Heading" runat="server" style=" font-size:x-large;">Last Night</label>    
    <label id="subHeading" runat="server" style="font-size:small;" ></label>
    </div>

     <div id="billingContainer" runat="server"></div>

    </form>
</body>
</html>
