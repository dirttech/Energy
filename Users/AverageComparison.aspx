﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AverageComparison.aspx.cs" Inherits="AverageComparison" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Me! vs Average</title>
    <link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />
    <link rel="shortcut icon" href="../images/dashboard_icon.png" />
     <link rel="stylesheet" type="text/css" media="screen" href="../Scripts/calender/bootstrap-datetimepicker.min.css" />
   
    <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet" />
      <script type="text/javascript">
          function CopyHidden(ths) {

              var hid = ths.getAttribute("compType");
              document.getElementById('<%=hidCompType.ClientID%>').setAttribute("value", hid);
              var tp = ths.innerText;
              document.getElementById('<%=hiddenHeadingType.ClientID%>').setAttribute("value", tp);
              document.getElementById('<%=Heading.ClientID %>').innerText = tp;

          }
    
    </script>
    <script type="text/javascript"   src="../Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript">
    var stackid=document.getElementById('<%=hiddenPlotType.ClientID %>');
    var stack="normal";
    if(stackid!=null)
    {
        stack=document.getElementById('<%=hiddenPlotType.ClientID %>').value;
    }

    var timeSeries=<%=new JavaScriptSerializer().Serialize(timeSeries) %>;
    
    var energyData = <%=new JavaScriptSerializer().Serialize(realEnergyArray)%>;
    var averageEnergyData = <%=new JavaScriptSerializer().Serialize(realAvgEnergyArr)%>;
    
    var timeData = <%=new JavaScriptSerializer().Serialize(timeArray)%>;
    var timeData1 = new Array;
  
    var enData=new Array(2);

    var avData=new Array(2);
    var ct=0;

    for(var p=0;p<energyData.length-2;p=p+2)
    {  enData[ct]=new Array(2);
       enData[ct][0]=energyData[p]*1000;
       enData[ct][1]=energyData[p+1];
       ct=ct+1;
    }
    ct=0;
    for(var p=0;p<averageEnergyData.length;p=p+2)
    {
        avData[ct]=new Array(2);
        avData[ct][0]=averageEnergyData[p]*1000;
        avData[ct][1]=averageEnergyData[p+1];
        ct=ct+1;
    }

    for(var i=0;i<timeData.length;i++){
    timeData1[i] = new Date(timeData[i]*1000);   
    d=timeData1[i];
    utc = d.getTime() + (d.getTimezoneOffset() * 60000);
      nd = new Date(utc + (3600000*5.5));
      timeData1[i]=nd.toUTCString();    
    }
   // alert(enData);
   // alert(avData);
      jQuery(document).ready(function ($) {
            

            $('#container').highcharts({
            chart: {
                type: 'bar',
                marginRight: 130,
                marginBottom: 50
            },
            title: {
                text: 'Energy Consumption',
                x: -20 //center
            },
            subtitle: {
                text: '',
                x: -20
            },
            xAxis: {
             
               type:'datetime'
            },
            yAxis: {
                title: {
                    
                    text: 'Energy(Watt Hrs)'
                },
                plotLines: [{
                    value: 0,
                    width: 1,
                    color: '#808080'
                }]
            },
            tooltip: {
                valueSuffix: 'WHr'
            },
            legend: {
                layout: 'vertical',
                align: 'right',
                verticalAlign: 'top',
                x: -10,
                y: 100,
                borderWidth: 0
            },
             plotOptions: {
                series: {
                    stacking: $('#hiddenPlotType').attr('value')
                }
            },
            series: [
            {
                name: 'Your Consumption',
                data: enData
            },
            {
                name:'Average Consumption',
                data: avData
            }
            
            ]
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
    <div>
    <table ><tr ><td style="width:250px;">
    <div class="HeadingLeftTop">
    <label id="Heading" runat="server" style=" font-size:x-large;">Last 7 Days</label>    
    <label id="subHeading" runat="server" style="font-size:small;" ></label>
    </div>
    <input id="hidCompType" type="hidden" runat="server" value="LWK"/>
<input id="hiddenHeadingType" type="hidden" runat="server" value="Last 7 Days" />
        <asp:Button ID="plot" runat="server" Text="Plot Now" onclick="plot_Click" class="customButton" style="display:none; position:absolute;" />
    </td><td align="right">
 
 
        <input id="Button1" type="button" class="customButton circleButton1 plotType" value="Stacked" txt="normal" runat="server" onserverclick="Stack_Click"/> 
          <input id="Button2" type="button" class="customButton circleButton2 plotType" value="Normal" txt="null" runat="server" onserverclick="Normal_Click" /> 
            <input type="hidden" value="normal" id="hiddenPlotType" runat="server" />
    </td><td>
    </td></tr>
    
    <tr><td id="NavigationContainer">
  
  <ul id="Navigation">
    <li><a class="navy" href="#" msg="Select month" compType="LWK" onclick="CopyHidden(this);" id="lwk">Last 7 Days</a></li>
    <li><a class="navy" href="#" msg="Select month" compType="THMNT" onclick="CopyHidden(this);" id="thmnt">This Month</a></li>
     <li><a class="navy" href="#" msg="Select month" compType="LMNTH" onclick="CopyHidden(this);" id="lmnth">Last Month</a></li>
      <li><a class="navy" href="#" msg="Select month" compType="THYR" onclick="CopyHidden(this);" id="thyr">This Year</a></li>
  </ul>


    </td><td>
    
     <div id="container" style="width: 900px; min-height: 550px; margin: 0 auto"></div>
    
    </td><td></td></tr>
    </table>

 
       
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
            $('#datetimepicker').datetimepicker({
                format: 'dd/MM/yyyy hh:mm:ss',
                pick12HourFormat: true
            });
            $('#datetimepicker2').datetimepicker({
                format: 'dd/MM/yyyy hh:mm:ss',
                pick12HourFormat: true
            });
            $('.navy').hover(function () {
                $('.navy').css('font-size', 'large');
                $(this).css('font-size', 'x-large');


            });
            $('.navy').click(function () {
                var offset = $(this).offset();
                $("#plot").hide();
                $("#plot").show("drop");
                $("#plot").offset({ top: offset.top, left: offset.left + 130 });
            });

//            $('.plotType').click(function () {
//                var typ = $(this).attr('txt');

//                $('#hiddenPlotType').text(typ);
//            });

        });
       
    </script>
    </form>
</body>
</html>
