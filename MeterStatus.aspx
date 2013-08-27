<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MeterStatus.aspx.cs" Inherits="MeterStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <script type="text/jscript">

      function scrollTo(hash) {
         
          location.hash = "#" + hash;
      }
    </script>
<style type="text/css">
.sideLine
        {
            top:85px;
             left:0px;
             position:fixed;
             width:210px;
             background-color:offwhite;
             height:210px;
             margin-top:5px;
             padding:10px;
               border-radius:0px 12px 12px 0px;  
             box-shadow:  0px 2px  2px 2px #888, 2px 3px 5px 0px #888;
        }
        .sideLine>a
        {
          color:navy;
          line-height:30px;   
        }
        .sideLine>ul>li>a:hover
        {
          
          text-decoration:underline;
          cursor:pointer;   
        }
.containers
{
    
        position:relative;
        left:250px;
        max-width:1000px;
        margin-left:50px;
}
.meterLabel
{
    width:50px;
    display:inline-block;
    margin:15px;
    text-align:center; 
    cursor:pointer;  
}

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"><br />
 <div class="sideLine">
  
    
    <a>Buildings</a><br />
      <ul >
    <li><a  onclick="scrollTo('<%=fac.ClientID %>')">Faculty Housing</a></li>
    <li><a  onclick="scrollTo('<%=grl.ClientID %>')">Girls Hostel</a></li>
    <li><a  onclick="scrollTo('<%=boy.ClientID %>')">Boys Hostel</a></li>
    <li><a  onclick="scrollTo('<%=acd.ClientID %>')">Academic Block</a></li>
     <li><a  onclick="scrollTo('<%=lib.ClientID %>')">Library</a></li>
     <li><a  onclick="scrollTo('<%=mess.ClientID %>')">Mess Building</a></li>
    
    </ul>
    </div>
<div style="text-align:right; margin-right:100px;"><asp:Button ID="Button1" runat="server" Text="Refresh" 
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
               <div id="fac" runat="server">
               
               </div>
                <div id="grl" runat="server">
               
               </div>
                <div id="boy" runat="server">
               
               </div>
                <div id="acd" runat="server">
               
               </div>
                <div id="cls" runat="server">
               
               </div>
                <div id="lib" runat="server">
               
               </div>
                <div id="mess" runat="server">
               
               </div>
            </div>
        </ContentTemplate>
        
       
    </asp:UpdatePanel>
   


</asp:Content>

