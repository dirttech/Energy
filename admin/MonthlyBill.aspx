    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonthlyBill.aspx.cs" Inherits="MonthlyBill" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  
<link rel="shortcut icon" href="../images/dashboard_icon.png" />

  <link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />
 <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <title>Print Bills</title>
    
     <style type="text/css">
      a
      {
          font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
          text-decoration:none;
          cursor:pointer;
      }
        a:hover
        {
             text-decoration:none;
        }
        
        
  
  </style>
</head>
<body>

    <form id="form1" runat="server">
   <div id="navigationTop">
   <a id="classic" runat="server" onserverclick="classic_Click" >Simple</a>

     <a id="modern" runat="server" onserverclick="modern_Click">Modern</a>

     <a id="latest" runat="server" onserverclick="latest_Click">Latest</a>
     
     </div>
    
     <iframe id="belowFrame"   runat="server" style="width:100%; height:1000px; border:none;" src="SMapClassicBill.aspx"></iframe>

    </form>
</body>
</html>
