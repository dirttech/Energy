<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClassicBill.aspx.cs" Inherits="admin_ClassicBill" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <script type="text/javascript">
     function CopyHidden(ths) {

         var hid = ths.getAttribute("UID");
         document.getElementById('<%=uid.ClientID%>').setAttribute("value", hid);
         var tp = ths.innerText;
         document.getElementById('<%=hidName.ClientID%>').setAttribute("value", tp);
         // document.getElementById('<%=Heading.ClientID %>').innerText = tp;

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
        }
        .billA
        {
          color:Gray;
          line-height:25px;
          padding-left:10px;
          padding-right:20px;
        }
        
    </style>

    
</head>
<body>

    <form id="form1" runat="server">
    <div class="SideBar">
    <div class="HeadingLeftTop" style="opacity:0.9; width:93.3%">
     <label id="Heading" runat="server" style=" font-size:x-large;">List of Users</label>    
    <label id="subHeading" runat="server" style="font-size:small;" ></label>
    </div>
      <div id="sideBar" runat="server" style="background-color:skyblue; padding-left:20px;">
      
    
    </div>
    </div>

    <asp:Button ID="printBill" runat="server" Text="Calculate" 
        class="customButton" style=" position:absolute; display:none;" onclick="printBill_Click" />
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
    <div class="HeadingLeftTop" style="opacity:0.9; width:200px; position:absolute; right:400px; ">
       
      <label id="Label1" runat="server" style=" font-size:x-large;">Current Bill</label> 
     <label id="UNameOfPrinter" runat="server" style=" font-size:large;"></label>  
       </div>


    <div>
    
        <table class="tabStyle" id="printingDiv">
            <tr>
                <td >
                <img src="../images/iiitd_logo.png" height="5opx" alt="IIITD"/>
                                   </td>
                <td>
                    &nbsp;</td>
                
                <td class="tplbl">
                    <p id="billAmount" runat="server" class="SideUpperLabel"></p>
                   
                    <p id="dueDate" runat="server" class="SideUpperLabel"></p>
                </td>
            </tr>
            <tr style="vertical-align: top">
                <td >
                    <table>
                    <tr> <td class="billQ">  Name  </td> 
                     <td>  <label runat="server" id="fullName" class="billA"></label>  </td> </tr>
                    <tr> <td class="billQ">  Address  </td> 
                     <td>  <label runat="server" id="address" class="billA"></label> </td> </tr>
                    <tr> <td class="billQ">  Mobile  </td> 
                     <td>  <label runat="server" id="mobile" class="billA"></label>  </td>  </tr>
                    </table>
                    
                    </td>
            
                <td>                   
                   <table>
                    <tr><td class="billQ">MeterNo.</td>
                    <td><label runat="server" id="meterNo" class="billA"></label></td>
                    </tr>
                    <tr><td class="billQ">Units Consumed </td>
                    <td><label runat="server" id="unitsConsumed" class="billA"></label></td></tr>
                    <tr><td class="billQ">Unit Price</td>
                    <td><label runat="server" id="unitRate" class="billA"></label></td></tr>
                    <tr><td class="SideUpperLabel billQ">Total</td>
                    <td><label runat="server" id="total" class="billA"></label></td></tr>
                    </table>                                   
                   </td>
              
                <td>                  
                                       
                    <table>
                    <tr><td class="billQ">Bill No.</td>
                    <td><label runat="server" id="billNo" class="billA"></label></td></tr>
                    <tr><td class="billQ">Bill Period</td>
                    <td><label runat="server" id="billPeriod" class="billA"></label></td></tr>
                    <tr><td class="billQ">Bill Date</td>
                    <td><label runat="server" id="billDate" class="billA"></label></td></tr>
                    </table>
                   
                   </td>
               
            </tr>
            <tr>
                <td style="border-bottom-style: dotted">
                    &nbsp;</td>
                <td style="border-bottom-style: dotted">
                    &nbsp;</td>
                <td style="border-bottom-style: dotted">
                    &nbsp;</td>
            
            </tr>
            <tr style="border-top:2px dotted black; border-top-color: #000000;">
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            
            </tr>
        </table>
     
                     
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
                $("#printBill").hide();
                $("#printBill").show("drop");
                $("#printBill").offset({ top: offset.top - 4, left: offset.left + 145 });
            });
        });
           </script>    

    </div>
    </form>
</body>
</html>
