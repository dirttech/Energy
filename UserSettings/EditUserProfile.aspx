<%@ Page Title="" Language="C#" MasterPageFile="~/UserSettings/SettingsMaster.master" AutoEventWireup="true" CodeFile="EditUserProfile.aspx.cs" Inherits="UserSettings_EditUserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
td
{
    width:200px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
 <p style="color:Black; margin-left:50px;">If you haven't changed your default username/password provided by us,<br /> 
    We advice you to change both of them now for security reasons.  <a href="ResetUserPassword.aspx">Change<<</a><br /><br />
    </p>
   <p style="color:Gray; margin-left:50px;">Please fill your Name and Contact No below.</p>
 <div class="skindiv">
 <div><br />
 <h2>Edit Profile</h2>

 <table>
 <tr><td>
    Username
            </td><td>
                <asp:TextBox ID="usrname" runat="server" ReadOnly="True"></asp:TextBox>
 
 </td></tr>
 <tr><td>
    Apartment 
            </td><td>
                <asp:TextBox ID="apartment" runat="server" ReadOnly="True"></asp:TextBox>
 
 </td></tr>
 <tr><td>
    Building
            </td><td>
                <asp:TextBox ID="building" runat="server" ReadOnly="True"></asp:TextBox>
 
 </td></tr>
 <tr><td>
    Name
            </td><td>
                <asp:TextBox ID="fullname" runat="server"></asp:TextBox>
 
 </td></tr>
 <tr><td>
    Contact No
            </td><td>
                <asp:TextBox ID="contact" runat="server"></asp:TextBox>
 
 </td></tr>
 <tr><td>
    E-Mail
            </td><td>
                <asp:TextBox ID="email" runat="server"></asp:TextBox>
 
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="email" Display="Dynamic" ErrorMessage="incorrect email" 
                    SetFocusOnError="True" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
 
 </td></tr>


 <tr><td></td><td>
     <asp:Label ID="green0" runat="server" ForeColor="Green"></asp:Label>
     </td></tr>
 <tr><td>
 <asp:Button ID="skipping" runat="server" Text="Skip & Continue" 
         class="customButton" onclick="skipping_Click" />
            </td><td>
 
                <asp:Button ID="saving" runat="server" Text="Save & Continue" 
                    class="customButton" onclick="saving_Click"/>
                
 
 </td></tr>
 </table>
 <br />
 </div>
 </div>
</asp:Content>

