<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminPanel.aspx.cs" Inherits="admin_adminPanel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Panel</title>
    
<link rel="shortcut icon" href="../images/dashboard_icon.png" />
    <script type="text/javascript">
        function pagleLoad(page1) {
            frames['belowFrame'].location.href = page1;
        }
    
    </script>
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
    
<link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="navigationTop">
   <a id="userInf" runat="server" onserverclick="usrInfo_Click" >User Info</a>

     <a id="dashbrd" runat="server" onserverclick="dashbrd_Click">Energy Dashboard</a>

     <a id="mnthlyBill" runat="server" href="MonthlyBill.aspx" target="_blank">Print Bills</a>
     
     </div>
       <asp:LinkButton ID="logOut" runat="server"  
        style="color:Black; font-weight:bold;  position:absolute; top:5px; right:20px;" 
        onclick="logOut_Click">LOG OUT</asp:LinkButton>
     <a style="color:Black;  font-size:large;  position:absolute; top:10px; left:20px;" id="nameTitle" runat="server">Welcome</a>
     
     <br />
     <iframe id="belowFrame"   runat="server" style="height:700px; width:1000px; border:none;" src="userInfo.aspx"></iframe>

    </form>
</body>
</html>
