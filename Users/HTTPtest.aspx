<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HTTPtest.aspx.cs" Inherits="HTTPtest" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
     <script type="text/javascript">
             var timeData = <%=new JavaScriptSerializer().Serialize(timeSeries)%>;
             var energyData = <%=new JavaScriptSerializer().Serialize(val)%>;
     jQuery(document).ready(function ($) {
            Highcharts.setOptions({
	global: {
		useUTC: false
	}
});
            $('#container').highcharts({
                chart: {
                    type: 'line'
                },
                title: {
                    text: 'Energy Consumption Comparisons'
                },
                subtitle: {
                    text: ''
                },
                xAxis: {
                     type: 'datetime',
                     categories: timeData
                
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
  
<div id="container" style="min-width: 900px; height: 600px; margin: 0 auto">
         </div>
    
    </form>
</body>
</html>
