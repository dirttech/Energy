<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MeterStatus.aspx.cs" Inherits="MeterStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">

.meterSpan
{
    
}
.meterLabel
{
    width:50px;
    display:inline-block;
    margin:15px;
    text-align:center;   
}

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"><br />
<div style="text-align:right; margin-right:20px;"><asp:Button ID="Button1" runat="server" Text="Refresh" 
        onclick="Button1_Click" Width="110px" Height="25px" /></div>
    
 <asp:ScriptManager ID="ScriptManager1" runat="server">
                    
                </asp:ScriptManager>
                 
                <asp:Timer runat="server" ID="Timer1"  Interval="10000" Enabled="true" 
        ontick="Button1_Click"></asp:Timer>
    <asp:UpdatePanel  ID="updt" runat="server" class="updt">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Timer1" />
    </Triggers>
       
        <ContentTemplate>
            <div id="statusHolder" runat="server">
               
            </div>
        </ContentTemplate>
        
       
    </asp:UpdatePanel>
   


</asp:Content>

