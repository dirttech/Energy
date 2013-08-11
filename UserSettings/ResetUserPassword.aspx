<%@ Page Title="" Language="C#" MasterPageFile="~/UserSettings/SettingsMaster.master" AutoEventWireup="true" CodeFile="ResetUserPassword.aspx.cs" Inherits="UserSettings_ResetUserPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="http://crypto-js.googlecode.com/svn/tags/3.1.2/build/rollups/md5.js"></script>
<script>
    function extractPass() {
        var msg = document.getElementById('<%=confirmNewpassword.ClientID%>').value;

        var hash = CryptoJS.MD5(msg);

        document.getElementById('<%=psHid.ClientID%>').value = hash;

        var msg1 = document.getElementById('<%=oldPassword.ClientID%>').value;

        var hash1 = CryptoJS.MD5(msg1);

        document.getElementById('<%=psHidOld.ClientID%>').value = hash1;

    }
</script>

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
    We advice you to change both of them now for security reasons.  <a href="EditUserProfile.aspx">Skip<<</a></p>
   
       
     
    <div class="skindiv">
        <div>
        <br />
        <h2>Reset Username</h2>
        <table id="usrnameTable" runat="server">
        <tr><td>
        
        Username
                </td><td>
                    <asp:TextBox ID="username" runat="server" ReadOnly="True"></asp:TextBox>
        
        </td></tr>
         <tr><td>
        
          New Username
                </td><td>
        
                 <asp:TextBox ID="newUsername" runat="server" 
                     ontextchanged="newUsername_TextChanged"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                     ControlToValidate="newUsername" Display="Dynamic" ErrorMessage="*Required" 
                     SetFocusOnError="True" ValidationGroup="usr"></asp:RequiredFieldValidator>
                     <asp:Label ID="valid" runat="server" style="color:Red;"></asp:Label>
        </td></tr>
         <tr><td>
        
             <asp:Label ID="green0" runat="server" Text="" style="color:Green;"></asp:Label>
                </td><td>
        
                    <asp:Button ID="changeUsername" runat="server" Text="Reset Username" 
                        class="customButton" ValidationGroup="usr" 
                        onclick="changeUsername_Click" />
        </td></tr>
        
        </table>


                        </div>
                        <div>
                        <hr />
                        <h2>Reset Password</h2>
        <table id="pwdTable"  runat="server" >
        <tr><td>
        Old Password
                 </td><td>
                     <asp:TextBox ID="oldPassword" runat="server" TextMode="Password"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                         ControlToValidate="oldPassword" Display="Dynamic" ErrorMessage="*Required" 
                         SetFocusOnError="True" ValidationGroup="pwd"></asp:RequiredFieldValidator>
                         <asp:Label ID="pwdCheck" runat="server" style="color:Red;"></asp:Label>
                         <input runat="server" type="hidden" id="psHidOld" />
        </td></tr>
        <tr><td>
        New Password
                 </td><td>
                     <asp:TextBox ID="newPassword" runat="server" TextMode="Password"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                         ControlToValidate="newPassword" Display="Dynamic" ErrorMessage="*Required" 
                         SetFocusOnError="True" ValidationGroup="pwd"></asp:RequiredFieldValidator>
        </td></tr>
        <tr><td>
        Confirm new password
                 </td><td>
                     <asp:TextBox ID="confirmNewpassword" runat="server" TextMode="Password"></asp:TextBox>
                     <asp:CompareValidator ID="CompareValidator1" runat="server" 
                         ControlToCompare="newPassword" ControlToValidate="confirmNewpassword" 
                         Display="Dynamic" ErrorMessage="Password mismatch" SetFocusOnError="True" 
                         ValidationGroup="pwd"></asp:CompareValidator>
        <input runat="server" type="hidden" id="psHid" />
        </td></tr>
        <tr><td>
         <asp:Label ID="green1" runat="server" Text="" style="color:Green;"></asp:Label>
             
                 </td><td>
                     <asp:Button ID="resetPassword" runat="server" Text="Reset Password" OnClientClick="extractPass()"
                         class="customButton" ValidationGroup="pwd" onclick="resetPassword_Click"/>
        </td></tr>
        
        </table>
        <br />

        </div>
    </div>

</asp:Content>

