<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SMapClassicBill.aspx.cs" Inherits="SMapClassicBill" %>


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
    <div class="HeadingLeftTop" style="opacity:0.9; width:200px; position:absolute; right:300px; ">
       
      <label id="Label1" runat="server" style=" font-size:x-large;">Current Bill</label> 
     <label id="UNameOfPrinter" runat="server" style=" font-size:large;"></label>  
       </div>


    <div>
    
        <table class="tabStyle" id="printingDiv">
         <tr>
                <td >
                <img src="../images/iiitd_logo.png" height="50px" alt="IIITD"/>
                                   </td>
                <td style="font-size:x-large;">
                    ELECTRICITY BILL</td>
                
                <td class="tplbl" style="width:300px;">
                    <p id="billAmount" runat="server" class="SideUpperLabel"></p>
                   
                    <p id="dueDate" runat="server" class="SideUpperLabel"></p>
                </td>
            </tr>
            <tr style="vertical-align: top; ">
                
                <td>   <label runat="server" id="fullName" class="billHead"></label>
                   <label runat="server" id="address" class="billHead2"></label>
                   <label runat="server" id="mobile" class="billHead2"></label>
                        
                    
                    </td>
            
                <td colspan="2">                   
                                 
                   </td>
              
            </tr>
            <tr style=" background-color:#f6f0f0 !important; opacity:0.85;">
                <td width="35%">
                <h4 >Billing Details:</h4>
                <h5>
                  Meter No. &nbsp;&nbsp;<label runat="server" id="meterNo" class="billA"></label>
                  Bill No.  &nbsp;&nbsp;  <label runat="server" id="billNo" class="billA"></label>
                  Bill Period &nbsp;&nbsp;  <label runat="server" id="billPeriod" class="billA"></label>
                  Bill Date &nbsp;&nbsp; <label runat="server" id="billDate" class="billA"></label>
                  </h5>
                    </td>
                <td width="32%">
                <h5>
                 Power Factor &nbsp;&nbsp;<label class="billA">0.9</label>
                 Sanctioned Load &nbsp;&nbsp;<label class="billA">8 Kva</label>
                 MDI &nbsp;&nbsp;<label class="billA">1</label>
                 Supply Type&nbsp;&nbsp;<label class="billA">LT</label>
                 </h5>

                    </td>
                <td style="vertical-align:top;">
                    <h5><br />
                 Meter Status &nbsp;&nbsp;<label class="billA">OK</label>
                 Meter Type &nbsp;&nbsp;<label class="billA">Permanent</label>
                 Energisation Date &nbsp;&nbsp;<label class="billA"></label>
                 </h5>
                    
                   </td>
            
            </tr>
            <tr style=" background-color:#f6f0f0 !important; opacity:0.85;">
                <td colspan="3">
                 
                    <table>
                        <tr>                    
                            <td >
                            
                                <table style="border: thin groove #000000"  class="calculations"><tr><td class="billQ">
                                Meter Type
                                </td>
                                <td class="billQ">
                                
                                Units Consumed
                                </td>
                                <td class="billQ" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                Readings
                                <br />Initial &nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;Final
                                
                                </td>
                                <td class="billQ">
                                Total Units
                                
                                </td>
                                </tr>
                                <tr>
                                <td class="billA">
                                    <asp:Label ID="meterType1" runat="server"></asp:Label>
                                    </td>
                                <td class="billA">
                                    <asp:Label ID="metTyp1Units" runat="server"></asp:Label>
                                    </td>
                                <td class="billA">
                                    <asp:Label ID="metTyp1Units0" runat="server"></asp:Label>
                                    </td>
                                <td class="billA">
                                    <asp:Label ID="metTyp1Units1" runat="server"></asp:Label>
                                    </td>
                                <td class="billA">
                                    <asp:Label ID="totalUnits" runat="server"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                <td class="billA">
                                    <asp:Label ID="meterType2" runat="server"></asp:Label>
                                    </td>
                                <td class="billA">
                                    <asp:Label ID="metTyp2Units" runat="server"></asp:Label>
                                    </td>
                                <td class="billA">
                                    <asp:Label ID="metTyp2Units0" runat="server"></asp:Label>
                                    </td>
                                <td class="billA">
                                    <asp:Label ID="metTyp2Units1" runat="server"></asp:Label>
                                    </td>
                                <td class="billA" runat="server" id="dayTd">
                                    
                                    </td>
                                </tr>
                                
                                </table>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <table style="border: thin groove #000000"  class="calculations">
                                    <tr>
                                        <td class="billQ">
                                            Units Consumed
                                            </td>
                                        <td class="billQ">
                                            Price Cal. (Slab-wise)</td>
                                        <td class="billQ">
                                            
                                            Fixed Charge(per day)
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="billA">
                                            <asp:Label ID="totalUnitsConsumed" runat="server"></asp:Label>
                                        </td>
                                        <td id="slabText" runat="server"  class="billA">
                                            
                                        </td>
                                        <td id="fixedText" runat="server"  class="billA">
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="billQ">
                                            Total</td>
                                        <td class="billA">
                                            <asp:Label ID="totalSlabCharge" runat="server"></asp:Label>
                                        </td>
                                        <td class="billA">
                                            <asp:Label ID="totalFixCharge" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <table style="border: thin groove #000000" class="calculations">
                                    <tr>
                                        <td class="billQ">
                                            Tax Eval on</td>
                                        <td class="billQ">
                                            Price</td>
                                        <td class="billQ">
                                            Adj. Charges(1.5%)</td>
                                        <td class="billQ">
                                            Def. Charges(8%)</td>
                                        <td class="billQ">
                                            Total</td>
                                    </tr>
                                    <tr>
                                        <td class="billQ">
                                            Energy Charge</td>
                                        <td class="billA">
                                            <asp:Label ID="energyChrg" runat="server"></asp:Label>
                                            </td>
                                        <td class="billA">
                                            <asp:Label ID="adjEnrgyChrg" runat="server"></asp:Label>
                                        </td>
                                        <td class="billA">
                                            <asp:Label ID="defEnrgyChrg" runat="server"></asp:Label>
                                        </td>
                                        <td class="billA">
                                            <asp:Label ID="netEnrgyChrg" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="billQ">
                                            Fixed Charge</td>
                                        <td class="billA">
                                            <asp:Label ID="fixChrg" runat="server"></asp:Label>
                                        </td>
                                        <td class="billA">
                                            <asp:Label ID="adjFixChrg" runat="server"></asp:Label>
                                        </td>
                                        <td class="billA">
                                            <asp:Label ID="defFixChrg" runat="server"></asp:Label>
                                        </td>
                                        <td class="billA">
                                            <asp:Label ID="netFixChrg" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="billQ">
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td class="billQ">
                                            <asp:Label ID="subTotalTxt" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td id="elecTax" runat="server">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td runat="server" id="netBillAmt">
                                &nbsp;</td>
                        </tr>
                    </table>
                  
                  
                  
                  
                  </td>
            </tr>
            <tr >
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
