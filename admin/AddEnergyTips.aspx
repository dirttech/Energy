<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddEnergyTips.aspx.cs" Inherits="admin_AddEnergyTips" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Import Energy Tips</title>
    <link rel="shortcut icon" href="../images/dashboard_icon.png" />
    <link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />
    <style type="text/css">
    
 td
{
  font-family:Verdana; 
}
hr
{
    display:block;
}

span
{
 margin:0px;
 padding:0px;
 font-family:Verdana;
}

    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="90%" >
    <tr>
    <td>
     <div class="HeadingLeftTop">
                <asp:Label ID="Label2" runat="server" Font-Bold="False" 
           >Import Tips</asp:Label>
           </div>
    </td></tr>
       <tr><td style="line-height:normal;">
    Choose CSV in format "ID, Tips&quot; to be upload in Database.
    First line should be header/empty which will be ignored while uploading. Leave ID empty.
    
    </td></tr>
    <tr>
    <td>
    <asp:FileUpload ID="FileUpload1" runat="server" />
         
    </td>
    </tr>
    <tr><td align="right">
    <asp:Label ID="green" runat="server" Font-Bold="False" ForeColor="#009933"></asp:Label>
     <asp:Button ID="importData" runat="server" Text="Import" class="customButton" OnClick="importData_Click"/>
    
    </td></tr>
    <tr><td>
    
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1">
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BillingAppConnectionString %>"></asp:SqlDataSource>
    
    </td></tr>
 
    </table>
   
    </form>
</body>
</html>
