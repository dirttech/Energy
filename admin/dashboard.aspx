<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="admin_dashboard" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Energy Dashboard</title>
    
  <link rel="Stylesheet" type="text/css" href="../Scripts/Default.css" />
   <link rel="stylesheet" type="text/css" href="../Scripts/calender/bootstrap-datetimepicker.min.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet" / >
        <script type="text/javascript">
  
    var energyData = <%=new JavaScriptSerializer().Serialize(energyArray)%>;
  
    var sD = <%=new JavaScriptSerializer().Serialize(startDate)%>;
    var startDate=sD*1000;
   
    var interval = <%= new JavaScriptSerializer().Serialize(timeInterval) %> ;
    interval=interval/100;

     jQuery(document).ready(function ($) {
     $('#container').highcharts({
            chart: {
            renderTo: 'container',
                zoomType: 'x',
                spacingRight: 20
            },
             
            title: {
                text: 'Energy consumption data between given time interval'
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
                    text: 'Energy Consumption (Watt hrs)'
                }
            },
            tooltip: {
                valueSuffix: 'WHr',
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
                name: 'Energy Consumption',
                pointInterval: interval,
                pointStart:startDate,
                data:energyData
            }]
        });

    });

    </script>


<link rel="shortcut icon" href="../images/dashboard_icon.png" />
</head>

<body>
<script src="../Scripts/high_charts/js/highcharts.js"></script>
    <script src="../Scripts/high_charts/js/modules/exporting.js"></script>
    <form id="form1" runat="server">
    <table>
    <tr>
    <td>
     From<br />
    <div id="datetimepicker1" class="input-append date">
      <input type="text" id="fromDate" runat="server" style=" margin-left:30px;"/>
      

      <span class="add-on">
        <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
      </span>
    </div> 
    
    </td>
    <td>
    To<br />
    <div id="datetimepicker2" class="input-append date">
      <input type="text" id="toDate" runat="server" style=" margin-left:10px;"/>
      

      <span class="add-on">
        <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
      </span>
    </div> 
    </td>
        <td>
     <br />
       <asp:Button ID="submitDate" runat="server" Text="Submit" class="customButton" 
                style=" margin-left:10px; margin-bottom:5px;" onclick="submitDate_Click"/>
    </td>
    </tr>
     <tr>
    <td colspan="3">
    
     <div id="container" style="width: 900px; height: 500px; margin: 0 auto"></div>
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

           
            $('#datetimepicker1').datetimepicker({
                format: 'dd/MM/yyyy hh:mm:ss',
                pick12HourFormat: true
            });
            $('#datetimepicker2').datetimepicker({
                format: 'dd/MM/yyyy hh:mm:ss',
                pick12HourFormat: true
            });

        });
           </script>    



      
    
    </form>
</body>
</html>
