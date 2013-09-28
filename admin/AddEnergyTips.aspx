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
         
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="FileUpload1" Display="Dynamic" ErrorMessage="*Required" 
            SetFocusOnError="True" ValidationGroup="multipleTip"></asp:RequiredFieldValidator>
         
    </td>
    </tr>
    <tr><td align="right">
    <asp:Label ID="green" runat="server" Font-Bold="False" ForeColor="#009933"></asp:Label>
     <asp:Button ID="importData" runat="server" Text="Import" class="customButton" 
            OnClick="importData_Click" ValidationGroup="multipleTip"/>
    
    </td></tr>
    <tr><td>
    
        <hr />
        <div class="HeadingLeftTop">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" 
           >Add Tip</asp:Label>
           </div>
        </td></tr>
 
    <tr><td>
    
        <asp:TextBox ID="addTipText" runat="server" Rows="3" TextMode="MultiLine" 
            Width="304px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="addTipText" Display="Dynamic" ErrorMessage="*Required" 
            SetFocusOnError="True" ValidationGroup="singleTip"></asp:RequiredFieldValidator>
    <asp:Label ID="status" runat="server" Font-Bold="False" ForeColor="#3399FF"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="addTip" runat="server" style="margin-bottom:15px;" 
            CssClass="customButton" Text="Add" ValidationGroup="singleTip" OnClick="addTip_Click" />
    
    </td></tr>
 <tr><td> <hr />
        <div class="HeadingLeftTop">
                <asp:Label ID="Label3" runat="server" Font-Bold="False" 
           >Delete Tips</asp:Label>
           </div>
        </td></tr></td></tr>
    <tr><td>


        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" DataKeyNames="ID" DataSourceID="SqlDataSource1" 
            ForeColor="Black" GridLines="Vertical" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" PageSize="5">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="tips" HeaderText="Energy Tips" 
                    SortExpression="tips" />
                <asp:CommandField SelectText="Delete" ShowSelectButton="True" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:BillingAppConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:BillingAppConnectionString.ProviderName %>" SelectCommand="Select ID, tips from energy_tips
"></asp:SqlDataSource>
    
    </td></tr>
 
    </table>
   
    </form>
</body>
</html>
