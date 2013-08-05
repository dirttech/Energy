<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PowerConsumption.aspx.cs" Inherits="Users_PowerConsumption" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Power Consumption</title>
    <link rel="shortcut icon" href="../images/dashboard_icon.png" />
    <style type="text/css">
      a
      {
          font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
          text-decoration:none;
      }
        a:hover
        {
             text-decoration:none;
        }
    .topBarNavigation a:hover
{
  font-size: x-large;   
  color:White;
  text-decoration:none;
     
}
    </style>

    <link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />
    
    <script type="text/javascript"   src="../Scripts/jquery-1.4.1.min.js"></script>
       <script type="text/javascript">
  
    var energyData = <%=new JavaScriptSerializer().Serialize(energyArray)%>;
  
    var sD = <%=new JavaScriptSerializer().Serialize(startDate)%>;
    var startDate=sD*1000;
   
    var interval = <%= new JavaScriptSerializer().Serialize(timeInterval) %> ;
    interval=interval/100;

     jQuery(document).ready(function ($) {
     Highcharts.setOptions({
	global: {
		useUTC: false
	}
});
     $('#container').highcharts({
            chart: {
            renderTo: 'container',
                zoomType: 'x',
                spacingRight: 20
            },
             
            title: {
                text: 'Power consumption data between given time interval'
            },
            subtitle: {
                text: document.ontouchstart === undefined ?
                    'Click and drag in the plot area to zoom in' :
                    'Drag your finger over the plot to zoom in'
            },
            xAxis: {
        
                type: 'datetime',
                
               // maxZoom: 14 * 24 * 3600000 * 60 * 60, // fourteen days
                title: {
                    text: 'Time'
                }
            },
             scrollbar: {
    enabled: true
  },
            yAxis: {
                title: {
                    text: 'Power Consumption (Watts)'
                }
            },
            tooltip: {
                valueSuffix: 'W',
                shared: true
            },
            legend: {
                enabled: false
            },
            plotOptions: {
                area: {
                    fillColor: {
                           linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1},
                         stops: [
                            [0, Highcharts.getOptions().colors[0]],
                            [1, Highcharts.Color(Highcharts.getOptions().colors[0]).setOpacity(0).get('rgba')]
                        ]
                        
                    },
                    lineWidth: 1,
                    marker: {
                        enabled: false
                    },
                    shadow: false,
                    states: {
                        hover: {
                            lineWidth: 1
                        }
                    },
                    threshold: null
                }
            },
    
            series: [{
                type: 'area',
                name: 'Power Consumption',
                pointInterval: interval,
                pointStart:startDate,
                data:energyData
            }]
        });

    });

    </script>
</head>
<body>
<script src="../Scripts/high_charts/js/highcharts.js"></script>
    <script src="../Scripts/high_charts/js/modules/exporting.js"></script>
    <form id="form1" runat="server" style="margin:0px;">

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
     <br/>
 
    <div class="HeadingLeftTop">
    <label id="Heading" runat="server" style=" font-size:x-large;">Last 24 Hours</label>    
    <label id="subHeading" runat="server" style="font-size:small;" ></label>
    </div>


    
    
     <div id="container" style="width: 1100px; height: 550px; max-width:1100px; margin: 0 auto"></div>
    

    </form>
</body>
</html>
