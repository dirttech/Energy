<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AprooveRegistrationRequests.aspx.cs" Inherits="admin_AprooveRegistrationRequests" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Confirm Registration</title>
        <link rel="shortcut icon" href="../images/dashboard_icon.png" />
        <link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />
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

    
        </style>
</head>
<body>
    <form id="form1" runat="server">
      <table width="90%">
    <tr>
    <td>
    <div class="HeadingLeftTop">
                <asp:Label ID="Label2" runat="server" Font-Bold="False">Confirm Registration</asp:Label>
           </div>
            </td></tr>
       <tr><td style="line-height:normal;">
   
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
               BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
               CellPadding="3" DataKeyNames="Apartment" DataSourceID="SqlDataSource1" 
               ForeColor="Black" GridLines="Vertical" 
               onselectedindexchanged="GridView1_SelectedIndexChanged" PageSize="15">
               <AlternatingRowStyle BackColor="#CCCCCC" />
               <Columns>
                   <asp:BoundField DataField="Building" HeaderText="Building" 
                       SortExpression="Building" />
                   <asp:BoundField DataField="Apartment" HeaderText="Apartment" ReadOnly="True" 
                       SortExpression="Apartment" />
                   <asp:BoundField DataField="EMail" HeaderText="EMail" SortExpression="EMail" />
                   <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" 
                       SortExpression="ContactNo" />
                   <asp:CommandField HeaderText="Confirm" SelectText="confirm" 
                       ShowSelectButton="True">
                   <ControlStyle ForeColor="#3333CC" />
                   </asp:CommandField>
               </Columns>
               <FooterStyle BackColor="#CCCCCC" />
               <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
               <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
               <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
               <SortedAscendingCellStyle BackColor="#F1F1F1" />
               <SortedAscendingHeaderStyle BackColor="#808080" />
               <SortedDescendingCellStyle BackColor="#CAC9C9" />
               <SortedDescendingHeaderStyle BackColor="#383838" />
           </asp:GridView>
           <br />
           <asp:Label ID="msg" runat="server" ForeColor="Red"></asp:Label>
           <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
               ConnectionString="<%$ ConnectionStrings:BillingAppConnectionString %>" 
               ProviderName="<%$ ConnectionStrings:BillingAppConnectionString.ProviderName %>" 
               SelectCommand="SELECT Building, Apartment, EMail, ContactNo FROM register_requests WHERE status = 'pending'">
           </asp:SqlDataSource>
   
    </td></tr>
    
 
    </table>
    </form>
</body>
</html>
