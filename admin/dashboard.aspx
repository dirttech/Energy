<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="admin_dashboard" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Energy Dashboard</title>
    <style type="text/css">
        .select
    {
        padding-top:5px;
            margin-left: 40px;
        }
    hr
    {
        margin:0px;
    }
    
    </style>
    
  <link rel="Stylesheet" type="text/css" href="../Scripts/Default.css" />
   <link rel="stylesheet" type="text/css" href="../Scripts/calender/bootstrap-datetimepicker.min.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet" / >
    <script type="text/javascript">
        function CopyChecked() {
            var htmlSelect = document.getElementById('<%=selectedBoxes.ClientID%>');
            var list = "";
            htmlSelect.Value = "";
            for (var i = 0; i < 100; i++) {
                if (document.getElementById("check" + i).checked) {
                    var cid = document.getElementById("check" + i);
                    var pid = cid.parentNode;
                    var apt = pid.getAttribute("MeterId");
                    list = list + apt + ",";
                    htmlSelect.setAttribute("value", list);
                }
            }
            
        }
    </script>
        <script type="text/javascript">
    
    var energyData = <%=new JavaScriptSerializer().Serialize(a2D)%>;

    var sD = <%=new JavaScriptSerializer().Serialize(startDate)%>;
    var startDate=new Date(sD*1000);
    var interval = <%= new JavaScriptSerializer().Serialize(timeInterval) %> ;
   
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
                    pointInterval: interval,
                    pointStart:Date.UTC(startDate.getFullYear(),startDate.getMonth(),startDate.getDate()),
                           
                        
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
               type:'line',
                data:energyData[0]
            },
            {
            type:'line',
                data:energyData[1]
            },{
                 type:'line',
                data:energyData[2]
            },
            {
            type:'line',
                data:energyData[3]
            },
            {
             type:'line',
                data:energyData[4]
            },
            {
            type:'line',
                data:energyData[5]
            },
            {
             type:'line',
                data:energyData[6]
            },
            {
             type:'line',
                data:energyData[7]
            },
            {
             type:'line',
                data:energyData[8]
            },
            {
             type:'line',
                data:energyData[9]
            },
            {
             type:'line',
                data:energyData[10]
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
    <div id="datetimepicker1" class="input-append date">
      <input type="text" id="fromDate" runat="server" style=" margin-left:30px;"/>     

      <span class="add-on">
        <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
      </span>
    </div> 
       
    
    </td>
    <td>       
           
       <div id="datetimepicker2" class="input-append date">
      <input type="text" id="toDate" runat="server" style=" margin-left:10px;"/>
      

      <span class="add-on">
        <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
      </span>
    </div> 
        </td>
        <td class="select">
        &nbsp;
         <asp:DropDownList ID="buildingList" runat="server">
             <asp:ListItem>Faculty Housing</asp:ListItem>
             <asp:ListItem>Boys Hostel</asp:ListItem>
             <asp:ListItem>Academic Building</asp:ListItem>
             <asp:ListItem>Girls Hostel</asp:ListItem>
             <asp:ListItem>Mess Building</asp:ListItem>
             <asp:ListItem>Library Building</asp:ListItem>
             <asp:ListItem>Service Block</asp:ListItem>

        </asp:DropDownList>
&nbsp;
        <asp:DropDownList ID="criteriaList" runat="server">
         <asp:ListItem Value="Power" units="Watts">Power</asp:ListItem>
        <asp:ListItem Value="Voltage" units="Volts">Voltage</asp:ListItem>
        <asp:ListItem Value="Energy" units="FwdHr">Energy</asp:ListItem>
            <asp:ListItem Value="Frequency" units="Hertz">Frequency</asp:ListItem>
        </asp:DropDownList>
&nbsp; 
              <asp:Button ID="submitDate" runat="server" Text="Submit" class="customButton" OnClientClick="CopyChecked()"
                style=" margin-left:5px; margin-bottom:10px;" onclick="submitDate_Click"/>  </td>
    </tr>
   
     <tr>
     <td style="vertical-align:top;">
     <div class="HeadingLeftTop">
    <label id="Heading" runat="server" style=" font-size:x-large;">Select Meters</label>
    </div>
    <input type="hidden" ID="selectedBoxes" runat="server" style="" />
    
    <div id="checkboxDiv" runat="server" style="height:500px; overflow:scroll;" >
    
    </div>

    </td>
    <td colspan="2">
    
     <div id="container" style="width: 900px; height: 500px; "></div>
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
