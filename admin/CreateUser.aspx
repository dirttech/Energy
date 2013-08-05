<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateUser.aspx.cs" Inherits="CreateUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />
  
    <title>Create User</title>
    
<link rel="shortcut icon" href="../images/dashboard_icon.png" />
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


    </style>
</head>
<body>
    <form id="form1" runat="server">

    <table id="creat" runat="server">
        <tr>
            <td colspan="2">
                  <div class="HeadingLeftTop">
                <asp:Label ID="Label2" runat="server" Font-Bold="False" 
           >Create User</asp:Label>
            </div></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                UserName</td>
            <td>
                <asp:TextBox ID="usrName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="usrName" Display="Dynamic" ErrorMessage="*Required" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:Label ID="Label1" runat="server" Font-Bold="False" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Full Name</td>
                        <td>
                <asp:TextBox ID="fullName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="fullName" Display="Dynamic" ErrorMessage="*Required" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Password</td>
            <td>
                <asp:TextBox ID="pwd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="pwd" Display="Dynamic" ErrorMessage="*Required" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Confirm Password</td>
            <td>
                <asp:TextBox ID="pwd1" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="pwd1" Display="Dynamic" ErrorMessage="*Required" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="pwd" ControlToValidate="pwd1" Display="Dynamic" 
                    ErrorMessage="Password Dont match" SetFocusOnError="True"></asp:CompareValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Mobile No</td>
            <td>
                <asp:TextBox ID="mobi" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Address</td>
            <td>
                <asp:TextBox ID="addr" runat="server" Rows="3" TextMode="MultiLine" 
                    Width="150px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
                <asp:Button ID="insertUser" runat="server" onclick="insertUser_Click" 
                    Text="Create" class="customButton"  />
                <asp:Label ID="green" runat="server" Font-Bold="False" ForeColor="#009933"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>



    <div>
    
    
    </div>
    </form>
</body>
</html>
