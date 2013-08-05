<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BarGraph.aspx.cs" Inherits="BarGraph" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />
<link rel="shortcut icon" href="../images/dashboard_icon.png" />
    <script type="text/javascript">
        function CopyHidden(ths) {

            var hid = ths.getAttribute("compType");
            document.getElementById('<%=hidCompType.ClientID%>').setAttribute("value", hid);
            var tp = ths.innerText;
            document.getElementById('<%=hiddenHeadingType.ClientID%>').setAttribute("value", tp);
            document.getElementById('<%=Heading.ClientID %>').innerText = tp;
            
        }
    
    </script>
    <title>Energy Consumption</title>
    
    
    <link rel="stylesheet" type="text/css" media="screen" href="../Scripts/calender/bootstrap-datetimepicker.min.css" />
   
    <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet" />

    <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript">
     var timeData = <%=new JavaScriptSerializer().Serialize(timeArray)%>;
     var energyData = <%=new JavaScriptSerializer().Serialize(energyArray)%>;
     var timeSeries=<%=new JavaScriptSerializer().Serialize(timeSeries) %>;
  
       var timeData1 = new Array;
    for(var i=0;i<timeData.length;i++){
    timeData1[i] = new Date(timeData[i]*1000);  
    d=timeData1[i];
    utc = d.getTime() + (d.getTimezoneOffset() * 60000);
      nd = new Date(utc + (3600000*5.5));
      timeData1[i]=nd.toLocaleString();
   
    }


        jQuery(document).ready(function ($) {
            Highcharts.setOptions({
	global: {
		useUTC: false
	}
});
            $('#container').highcharts({
                chart: {
                    type: 'bar'
                },
                title: {
                    text: 'Energy Consumption Comparisons'
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
                    bar: {
                        dataLabels: {
                            enabled: true
                        }
                    }
                },
                legend: {
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
                data: energyData
            }]
            });
        });
    
    </script>

 
     
  </head>

<body>
<script src="../Scripts/high_charts/js/highcharts.js"></script>
<script src="../Scripts/high_charts/js/modules/exporting.js"></script>
 
     

    <form id="form1" runat="server">
 <div id="navigationTop">
 <a href="front.aspx">Home</a>
  <a href="PowerConsumption.aspx" >Power Consumption</a>

     <a href="BarGraph.aspx">Energy Consumption</a>

     <a href="AverageComparison.aspx" >Me! vs Average</a>

     <a href="TrackBill.aspx" >Track Bill</a>
     </div>
       <asp:LinkButton ID="logOut" runat="server"  
        style="color:Black; font-weight:bold;  position:absolute; top:5px; right:20px;" 
        onclick="logOut_Click">LOG OUT</asp:LinkButton>
     <a style="color:Black;  font-size:large;  position:absolute; top:10px; left:20px;" id="nameTitle" runat="server">Welcome</a>
     
     <br />

<table>
    
<tr>
<td id="NavigationContainer">
<div class="HeadingLeftTop">
<label id="Heading" runat="server" style=" font-size:x-large;">Month Consumption</label>
<label id="subHeading" runat="server" style="font-size:small;" ></label>
</div>
<input id="hidCompType" type="hidden" runat="server" value="DTD"/>
<input id="hiddenHeadingType" type="hidden" runat="server" value="Month Consumption" />
   <div id="popsup" style=" background-color:skyblue; position:absolute; display:none; padding-top:5px; padding-right:12px; padding-bottom:15px; z-index:10; opacity:0.99;">
   <table>
   <tr><td colspan="2" style="font-size:large; color:White; padding-left:10px;" id="messg">
   Select Date
   </td></tr>
   <tr><td>
    <div id="datetimepicker" class="input-append date">
      <input type="text" id="fromDate" runat="server" style=" margin-left:10px;"/>
      

      <span class="add-on">
        <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
      </span>
    </div> 
    </td><td>
     <asp:Button ID="submitDate" runat="server" Text="Submit" class="customButton" onclick="submitDate_Click" style=" margin-left:10px; margin-bottom:5px;"/>
     </td></tr></table>
</div>

  <ul id="Navigation">
   <li><a class="navy" href="#" msg="Select month" compType="DTD" onclick="CopyHidden(this);" id="dtd" >Month Consumption</a></li>
    <li><a class="navy" href="#" msg="Select day" compType="HBH" onclick="CopyHidden(this);" id="hbh">Day Consumption</a></li>
    <li><a class="navy" href="#" msg="Select starting day" compType="7Days" onclick="CopyHidden(this);" id="sdays">7 Day Consumption</a></li>
    <li><a class="navy" href="#" msg="Select month" compType="WKND" onclick="CopyHidden(this);" id="wknd">Weekends Consumption</a></li>
    <li><a class="navy" href="#" msg="Select month" compType="WKDY" onclick="CopyHidden(this);" id="wkdy">Weekdays Consumption</a></li>
  </ul>

</td>
<td>
   
<div id="container" style="min-width: 900px; height: 600px; margin: 0 auto">
         </div>

</td>
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
            $('#datetimepicker').datetimepicker({
                format: 'dd/MM/yyyy hh:mm:ss',
                pick12HourFormat: true
            });
            $('.navy').hover(function () {
                $('.navy').css('font-size', 'large');
                $(this).css('font-size', 'x-large');


            });
            $(".navy").click(function () {
                var mesg = $(this).attr("msg");
//                $(".navy").removeClass("activeLink");
//                $(this).addClass("activeLink");
                $("#messg").text(mesg);
                $("#popsup").show("slow");

            });
            $("#submitDate").click(function () {
                $("#popsup").hide("slow");
            });

        });
       
    </script>
  

    </form>
</body>
</html>
