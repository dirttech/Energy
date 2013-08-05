<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModernBill.aspx.cs" Inherits="admin_ModernBill" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>


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

     <script type="text/javascript">
     var energyData = <%=new JavaScriptSerializer().Serialize(myEnergy)%>;
     var avgEnergyData=<%=new JavaScriptSerializer().Serialize(avgEnergy) %>;
  
     var energyArray = <%=new JavaScriptSerializer().Serialize(energyArray)%>;
       var timeSeries=<%=new JavaScriptSerializer().Serialize(timeSeries) %>;
  


        jQuery(document).ready(function ($) {
            Highcharts.setOptions({
	global: {
		useUTC: false
	}
});

//***************backside chart ************************************************************8

 $('#container1').highcharts({
                chart: {
                    type: 'line'
                },
                 exporting:{
                    enabled:false
                },
                title: {
                    text: ''
                },
                subtitle: {
                    text: ''
                },
                xAxis: {
                     type: 'datetime',
                     categories: timeSeries
                
                },
                yAxis: {
                    
                    title: {
                        text: 'Energy(Watt Hrs)',
                        align: 'high'
                    },
                    labels: {
                        overflow: 'justify'
                    }
                },
                tooltip: {
                    valueSuffix: ' Whr'
                },
                plotOptions: {
                    line: {
                        dataLabels: {
                            enabled: true
                        }
                    }
                },
                legend: {
                    enabled: false,
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'top',
                    x: -10,
                    y: 100,
                    floating: true,
                    borderWidth: 1,
                    backgroundColor: '#FFFFFF',
                    shadow: true
                },
                credits: {
                    enabled: false
                },
               series: [{
                name: 'Energy Consumption',
                data: energyArray
            }]
            });

     //*************small chart****************************************************
            $('#container').highcharts({
                chart: {
                    type: 'bar'
                },
                exporting:{
                    enabled:false
                },
                title: {
                     text:''
                },
                subtitle: {
                    text: ''
                },
                xAxis: {
                    
                    categories: ['You','Average']
                },
                yAxis: {
                    
                    title: {
                        text: 'Energy(Watt Hrs)',
                        align: 'high'
                    },
                    labels: {
                        overflow: 'justify'
                    }
                },
                tooltip: {
                    valueSuffix: ' Whr'
                },
                plotOptions: {
                    bar: {
                        dataLabels: {
                            enabled: true
                        }
                    }
                },
                legend: {
                    enabled:false,
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'top',
                    x: -10,
                    y: 100,
                    floating: true,
                    borderWidth: 1,
                    backgroundColor: '#FFFFFF',
                    shadow: true
                },
                credits: {
                    enabled: false
                },
               series: [
               {
                name: 'You vs Avg',
                data: [{y:energyData, color:'gray'}, avgEnergyData]
               },
              
            ]
            });
        });
    
    </script>

 


    <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet" / >
   <title>Print Bills</title>
    <style type="text/css" media="all">
        h2
        {
          color:White;   
        }
        h2,select
        {
            padding-left:10px;
            margin-left:10px;
        }
        select
        {
          width:500px;   
        }
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
          color:Black;
          line-height:25px;
          padding-left:10px;
          padding-right:20px;
          float:inherit;
        }
        .billHead
        {
          color:Black !important;
          font-size:large !important;
          text-transform:capitalize; 
        }
        .billHead2
        {
          color:Black !important;
          font-size:medium !important;
          text-transform:capitalize; 
        }
        h4
        {
            color:#0d96c5 !important;
        }
        
        
        @media print
        {
            hr {page-break-before:always}
            
        }
    </style>

    
</head>
<body>

<script src="../Scripts/high_charts/js/highcharts.js"></script>
<script src="../Scripts/high_charts/js/modules/exporting.js"></script>

    <form id="form1" runat="server">
    <div id="tipsDiv" runat="server" style=" display:none; position:absolute; left:150px; top:50px;-moz-border-radius:8px;
	-webkit-border-radius:8px;
	border-radius:8px; 
  box-shadow: 0px 0px 10px rgba(0,0,0,0.2); width:550px; height:400px; background-color:#0d96c5; opacity:0.9; z-index:12;">
    <img id="closeButton" runat="server" style="position:absolute; top:5px; right:5px; height:30px; cursor:pointer;" src="~/images/closeButton.png" alt="close" />
    <br />
    <table id="tbl">
    <tr>
    <td>
    <h2>Tip of month</h2>
        <asp:DropDownList ID="tipOfMonth" runat="server" DataSourceID="SqlDataSource1" 
            DataTextField="tips" DataValueField="tips">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:BillingAppConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:BillingAppConnectionString.ProviderName %>" 
            SelectCommand="Select (tips) from energy_tips"></asp:SqlDataSource>
    </td>
    </tr>  
    <tr>
    <td>
    <h2>More Tips</h2>
    <p> <asp:DropDownList ID="tip1" runat="server" DataSourceID="SqlDataSource1" 
            DataTextField="tips" DataValueField="tips">
        </asp:DropDownList></p>
        <p> <asp:DropDownList ID="tip2" runat="server" DataSourceID="SqlDataSource1" 
                DataTextField="tips" DataValueField="tips">
        </asp:DropDownList></p>
        <p> <asp:DropDownList ID="tip3" runat="server" DataSourceID="SqlDataSource1" 
                DataTextField="tips" DataValueField="tips">
        </asp:DropDownList></p>
     
    </td>
    </tr>  
    <tr>
    <td align="right">
        <input type="button" id="tipsOk" runat="server" value="Done!" class="customButton" onserverclick="DoneTipsClick" />
    </td>
    </tr>  
    </table>
    <img runat="server" id="loader" src="~/images/loader.gif" alt="Loading.." style=" height:200px; display:none; position:absolute; left:250px; top:150px;"/>
    </div>


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
            &nbsp;&nbsp;<asp:Button ID="calc" runat="server" Text="Calculate" class="customButton" style="padding-top:3px; margin-bottom:4px; padding-left:5px;" />
            &nbsp;&nbsp;<asp:Button ID="prvs" runat="server" Text="<< Previous" 
                    class="customButton" 
                    style="padding-top:3px; margin-bottom:4px; padding-left:10px;" 
                    onclick="prvs_Click" />
            &nbsp;&nbsp;<asp:Button ID="nxt" runat="server" Text="Next >>" class="customButton" 
                    style="padding-top:3px; margin-bottom:4px; padding-left:5px;" 
                    onclick="nxt_Click" />
            &nbsp;&nbsp; <input type="button" value="Print" 
                    class="customButton" 
                    style="padding-top:3px; margin-bottom:4px; padding-left:5px;" 
                    onclick="javascript:printDiv('printingDiv')" />&nbsp;&nbsp;

                     <input type="button" ID="tips" runat="server" value="Energy Tips" class="customButton" 
                    style="padding-top:3px; margin-bottom:4px; padding-left:5px;" 
                    />
            </td>
            <td>
           
            </td>
            </tr></table>     
    </div>
    <div class="HeadingLeftTop" style="opacity:0.9; width:200px; position:absolute; right:300px; background-color:skyblue; ">
       
      <label id="Label1" runat="server" style=" font-size:x-large;">Current Bill</label> 
     <label id="UNameOfPrinter" runat="server" style=" font-size:large;"></label>  
       </div>


    <div>
    
        <table class="tabStyle" id="printingDiv">
            <tr>
                <td >
                <img src="../images/iiitd_logo.png" height="50px" alt="IIITD"/>
                                   </td>
                <td>
                    &nbsp;</td>
                
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
                                                 
               <h4>Tip of month:</h4>    
               <p id="monthTip" runat="server">Put you air fans on hold and use flouroscent lights instead of incandescent lamps.</p>                    
               
                   
                   </td>
              
            </tr>
            <tr style=" background-color:#f6f0f0 !important; opacity:0.85;">
                <td >
                <h4 style=" ">Billing Details:</h4>
                <h5>
                  Meter No. &nbsp;&nbsp;<label runat="server" id="meterNo" class="billA"></label>
                  Bill No.  &nbsp;&nbsp;  <label runat="server" id="billNo" class="billA"></label>
                  Bill Period &nbsp;&nbsp;  <label runat="server" id="billPeriod" class="billA"></label>
                  Bill Date &nbsp;&nbsp; <label runat="server" id="billDate" class="billA"></label>
                  </h5>
                    </td>
                <td >
                <h5>
                 Units Consumed &nbsp;&nbsp;   <label runat="server" id="unitsConsumed" class="billA"></label>
                 Unit Price &nbsp;&nbsp;   <label runat="server" id="unitRate" class="billA"></label>
                 Total &nbsp;&nbsp;   <label runat="server" id="total" class="billA"></label>
                 </h5>
                    </td>
                <td >
                    &nbsp;</td>
            
            </tr>
            <tr>
                <td colspan="2" align="left">
                    
                    <h4>Last Month Consumption:</h4>


                    <div id="container" style="width: 350px; height: 200px;">
                    </div>
                    
                    </td>
                <td id="co2" runat="server" style=" font-size:larger; line-height:25px !important; vertical-align:top; padding-top:50px; color:Gray !important;">
                  
                  
                  </td>
            
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            
            </tr>
        </table>
            <hr />
            <table>
            <tr><td>
               <h4>Wondering about ways to reduce your energy consumption? Try some of these energy-saving ideas!</h4>
        <ol type="1">
        <li runat="server" id="tipp1">Become A Cyber Security Expert And Excel In Information Security.</li>
        <li runat="server" id="tipp2"> Buy and sell, it's 100% free: Apartments, jobs, cars, anything!</li>
        <li runat="server" id="tipp3">Learn HTML, Javascript & Flash Join course at Arena!</li>
        </ol>
            </td></tr>
            <tr><td>
            <h4>Last 6 weeks:</h4>
            </td></tr>
            <tr><td>
             <div id="container1" style="width: 650px; height: 400px;">
                    
                    
                    </div>
                    <br /><br />
            <center>For more details visit www.EnergyDashboard.com
            </center>
            </td></tr>
            <tr><td>
            
            </td></tr>
            
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

            $('#tips').click(function () {
                var offset = $(this).offset();
                $("#tipsDiv").show("drop");
            });
            $('#closeButton').click(function () {
                $("#tipsDiv").hide("drop");
            });
            $('#tipsOk').click(function () {
                $("#tipsDiv").hide("drop");
            });


        });
           </script>    

    </div>
    </form>
</body>
</html>
