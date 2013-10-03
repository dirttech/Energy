<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SMapManualBill.aspx.cs" Inherits="SMapClassicBill" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>

<%@ Register TagPrefix="uc" TagName="Spinner2" 
    Src="~/Controls/Bill.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <script type="text/javascript">
     function CopyHidden(ths) {
         var hid = ths.getAttribute("Apart");
         document.getElementById('<%=uid.ClientID%>').setAttribute("value", hid);
         var tp = ths.innerText;
         document.getElementById('<%=hidName.ClientID%>').setAttribute("value", tp);
         AllSelectedCopy();
     }
     function AllSelectedCopy() {
         var htmlSelect = document.getElementById('<%=selectedBoxes.ClientID%>');
         var list = "";
         htmlSelect.Value = "";
         for (var i = 0; i < 100; i++) {
             if (document.getElementById("check" + i).checked) {
                 var cid = document.getElementById("check"+i);
                 var pid = cid.parentNode;
                 var apt = pid.getAttribute("Apart");
                 list=list + apt + ",";
                 htmlSelect.setAttribute("value", list);
             }
         }
     }
     function printDiv(divID) {
         window.print();
     }

    
    </script>
    
<link rel="shortcut icon" href="../images/dashboard_icon.png" />

  <link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />
  <link rel="Stylesheet" type="text/css" media="print" href="../Scripts/Default.css" />
   <link rel="Stylesheet" type="text/css" media="print" href="../Scripts/printBill.css" />
  <link rel="stylesheet" type="text/css" media="screen" href="../Scripts/calender/bootstrap-datetimepicker.min.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet" / >
   <title>Print Bills</title>
    <style type="text/css" media="all">
        .SideUpperLabel
        {
          font-family:@Arial Unicode MS;
          font-size:large;
          color:Navy !important;
          -webkit-print-color-adjust: exact; 
          padding-left:5px;
          padding-top:4px;
          font-weight:normal;   
        }
        .checkB
       {
         height:20px;
            
       }
         td
        {
            font-family:Verdana; 
          
        }
        .tabStyle
        {
          min-width:700px !important;
           -webkit-print-color-adjust: exact; 
          max-width:1000px !important;
        }
        .tplbl
        {
         background-color:#FFFF99 !important;
         -webkit-print-color-adjust: exact;  
        }
        .billQ
        {
           font-weight:bolder; 
           vertical-align:top;
        }
        .billA
        {
          color:Gray;
          line-height:25px;
          padding-left:10px;
          padding-right:20px;
          vertical-align:top;
        }
        .calculations
        {
             width:100%;   
        }
        input[type="checkbox"]
        {
              -ms-transform: scale(4); /* IE */
  -moz-transform: scale(4); /* FF */
  -webkit-transform: scale(4); /* Safari and Chrome */
  -o-transform: scale(4); /* Opera */
  padding: 10px;
  margin-left:30px;
  margin-right:10px;
margin-bottom:7px;
        }
         @media print
        {
            hr {page-break-before:always}
            
        }
        
    </style>

    
</head>
<body>

    <form id="form1" runat="server">
    <div class="SideBar" style="height:500px;">
    <div class="HeadingLeftTop" style="opacity:0.9; width:93.3%">
     <label id="Heading" runat="server" style=" font-size:x-large;">
     
        <asp:RadioButtonList ID="printMode" runat="server" 
            RepeatDirection="Horizontal">
            <asp:ListItem  Value="all">All&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
            <asp:ListItem Value="selected">Selected&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
            <asp:ListItem Value="single" Selected="True">Individual</asp:ListItem>
        </asp:RadioButtonList>
     
     </label>    
    </div>
      <div id="sideBar" runat="server" style="background-color:skyblue; padding-left:20px; ">
      
    
    </div>
    </div>
    <input type="hidden" ID="selectedBoxes" runat="server" style="" />
    <input id="hidName" type="hidden" runat="server" value="LNT"/>
<input id="uid" type="hidden" runat="server" />
    <asp:ListBox ID="ListBox1" runat="server" Visible="false"></asp:ListBox>

    <div id="hoverDiv"><br />
    <table class="printHide">

    <tr><td style="color:White; font-size:x-large;">Billing Interval</td><td>
         <div id="datetimepicker1" class="input-append date">
                  <input type="text" id="fromDate" runat="server" style=" margin-left:30px;"/>
      

                  <span class="add-on">
                    <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                  </span>
                </div>       
                <td>
                 <div id="datetimepicker2" class="input-append date">
                  <input type="text" id="toDate" runat="server" style=" margin-left:30px;"/>
      

                  <span class="add-on">
                    <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                  </span>
                </div>       
                
                </td>
            </td>
            <td>
            &nbsp;&nbsp;<asp:Button ID="calc" runat="server" Text="Calculate" class="customButton" style="padding-top:3px; margin-bottom:4px; padding-left:10px;" />
            &nbsp;&nbsp;<asp:Button ID="prvs" runat="server" Text="<< Previous" 
                    class="customButton" 
                    style="padding-top:3px; margin-bottom:4px; padding-left:10px;" 
                    onclick="prvs_Click" />
            &nbsp;&nbsp;<asp:Button ID="nxt" runat="server" Text="Next >>" class="customButton" 
                    style="padding-top:3px; margin-bottom:4px; padding-left:10px;" 
                    onclick="nxt_Click" />
            &nbsp;&nbsp; <input type="button" value="Print" 
                    class="customButton" 
                    style="padding-top:3px; margin-bottom:4px; padding-left:10px;" 
                    onclick="javascript:printDiv('printingDiv')" />
            </td>
            
            </tr></table>     
    </div>
    <div class="HeadingLeftTop" style="opacity:0.9; width:200px; position:absolute; right:300px;display:none; ">
       
      <label id="Label1" runat="server" style=" font-size:x-large;">Current Bill</label> 
     <label id="UNameOfPrinter" runat="server" style=" font-size:large;"></label>  
       </div>


    <div>
    <div id="billbody" runat="server"></div>
     

     <div id="printOptions" runat="server" style=" display:none; position:absolute; left:700px; top:120px;-moz-border-radius:8px;
	-webkit-border-radius:8px;
	border-radius:8px; 
  box-shadow: 0px 0px 10px rgba(0,0,0,0.2); width:280px; height:380px; background-color:#0d96c5; opacity:0.9; z-index:12;">

                     <h4 align="center">
                     Select Meters
                         </h4>
                         <hr />
                         <h5><asp:CheckBox ID="powerCheck" runat="server" Checked="true" Height="20px" val="Power"/>&nbsp;Power</h5>
        <p style="padding-left:30px;"> <asp:TextBox ID="meter_1Initial" placeholder="Initial Reading" runat="server"></asp:TextBox><asp:TextBox ID="meter_1Final" placeholder="Final Reading" runat="server"></asp:TextBox></p>
                       <h5>  <asp:CheckBox ID="lightCheck" runat="server" Checked="true" Height="20px" val="Light Backup"/>&nbsp;Light Backup</h5>
          <p style="padding-left:30px;"><asp:TextBox ID="meter_2Initial" placeholder="Initial Reading" runat="server"></asp:TextBox><asp:TextBox ID="meter_2Final" placeholder="Final Reading" runat="server"></asp:TextBox></p>
                       <asp:Button ID="printBill" runat="server" Text="Calculate" 
        class="customButton" style=" position:relative; display:block; top: -2px; left: 89px;" 
                         onclick="printBill_Click" />
                     
                        
                     </div>
     <script type="text/javascript"
     src="../Scripts/calender/jquery.min.js">
    </script> 
    <script type="text/javascript"
     src="../Scripts/calender/bootstrap.min.js">
    </script>
    <script type="text/javascript"
     src="../Scripts/calender/bootstrap-datetimepicker.min.js">
    </script>
    <script type="text/javascript"
     src="../Scripts/calender/bootstrap-datetimepicker.pt-BR.js">
    </script>
    <script type="text/jscript">
        jQuery(document).ready(function ($) {
            $('#datetimepicker1').datetimepicker({
                format: 'dd/MM/yyyy hh:mm:ss',
                pick12HourFormat: true
            });
            $('#datetimepicker2').datetimepicker({
                format: 'dd/MM/yyyy hh:mm:ss',
                pick12HourFormat: true
            });

            $('.clicker').hover(function () {
                $('.clicker').css('font-size', 'large');
                $(this).css('font-size', 'x-large');


            });
            $('.clicker').click(function () {
                var offset = $(this).offset();
                $("#printOptions").hide();
                $("#printOptions").fadeIn("drop");
                //$("#printOptions").offset({ top: offset.top - 4, left: offset.left + 145 });
            });
        });
           </script>    

    </div>
    </form>
</body>
</html>
