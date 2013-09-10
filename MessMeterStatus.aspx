<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MessMeterStatus.aspx.cs" Inherits="MeterStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script type="text/javascript">
  function  pageLoad() {

        $('.meterLabel').click(function () {
            $('.abstractH').hide();
            $('.duplicate').fadeIn('slow', function () {
                // Animation complete.
            });

        });
        $('.clos').click(function () {
          
            $('.abstractH').fadeOut('slow', function () {
                // Animation complete.
            });

        });
    }
    </script>

  <script type="text/jscript">

      function scrollTo(hash) {
         
          location.hash = "#" + hash;
      }
    </script>
<style type="text/css">
    .abstractH>p {

        line-height: 25px;
        margin: 0px;
    }
    .abstract
    {
         height:160px;
         width:250px;
         position:fixed;
         left:400px;
         top:200px;
         background-color:black;
         opacity:0.97;   
         z-index:100;   
         color:White;
         display:none;
    }
    br {
        line-height: 10px;
        
    }
     .abstractH
    {
        padding:10px;
         height:155px;
         width:250px;
         overflow: hidden;
         padding-right: 0px;
         line-height: 17px;
         position:fixed;
         left:400px;
         top:200px;
         background-color:black;
         opacity:0.97;   
         z-index:100;   
         color:White;
         display:block;
    }
    .duplicate
    {
        display:none;
           height:70px;
         width:250px;
         position:fixed;
         left:400px;
         top:200px;
         background-color:black;
         opacity:0.97;   
         z-index:101; 
         color:White;  
         text-align:center;
         padding-top:50px;
        padding-bottom: 10px;
    }
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
        h4
        {
          padding:1px;
          margin:1px;   
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
    border:none;
    color:#363636;
    height:30px;
    font-weight:bold;
    font-family:Sans-Serif;
    font-size:x-large;
    text-align:center; 
    cursor:pointer;  
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"><br />
 <div class="sideLine">
  
    
    <a>Buildings</a><br />
      <ul >
    <li><a  href="FacultyMeterStatus.aspx">Faculty Housing</a></li>
    <li><a  href="GirlsHostelMeterStatus.aspx">Girls Hostel</a></li>
    <li><a  href="BoysHostelMeterStatus.aspx">Boys Hostel</a></li>
    <li><a  href="AcademicMeterStatus.aspx">Academic Building</a></li>
     <li><a href="LibraryMeterStatus.aspx">Library</a></li>
     <li><a href="MessMeterStatus.aspx">Mess Building</a></li>
    
    </ul>
    </div>
<div style="text-align:right; margin-right:100px;"><asp:Button ID="Button1" runat="server" Text="Refresh" 
        onclick="Button1_Click" Width="110px" Height="25px" /></div>
    
 <asp:ScriptManager ID="ScriptManager1" runat="server">
                    
                </asp:ScriptManager>
                 
                <asp:Timer runat="server" ID="Timer1"  Interval="100000" Enabled="true" 
        ontick="Button1_Click"></asp:Timer>
    <asp:UpdatePanel  ID="updt" runat="server" class="updt">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Timer1" />
    </Triggers>
       
        <ContentTemplate>
        <div id="popup" runat="server" class="abstract"></div>
         <div id="duplicate" runat="server" class="duplicate"><img src="images/loader.gif" height="20px" />
         Loading...
         </div>

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

