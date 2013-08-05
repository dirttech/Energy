<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminLogin.aspx.cs" Inherits="admin_adminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
     <link rel="Stylesheet" type="text/css" href="../Scripts/LoginStyle.css"/>
     <style type="text/css">
      p, h2, h3,h1
        {
         font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
        }
     
     </style>
<link rel="shortcut icon" href="../images/dashboard_icon.png" />
</head>
<body>
    

<div class="container">
  <div class="login">
    <h1>Admin Login</h1>

    <form id="form2" runat="server">
    <p><input type="text" name="login" value="" placeholder="Username" runat="server" id="usrName" /></p>
      <p><input type="password" name="password" value="" placeholder="Password" runat="server" id="pwd" /></p>
      <p class="remember_me">
        
      </p>
      <p class="submit">
          <asp:Button ID="loginUser" runat="server" Text="Login" 
              onclick="loginUser_Click" /></p>
              <p><asp:Label ID="msg" Text="" runat="server" style="color:#c4376b;  font-weight:bold;"></asp:Label></p>
</form>
  </div>
 
  
</div>
   
</body>
</html>
