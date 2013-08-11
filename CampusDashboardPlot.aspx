<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CampusDashboardPlot.aspx.cs" Inherits="CampusDashboardPlot" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


    <link rel="stylesheet" type="text/css" media="screen" href="Scripts/calender/bootstrap-datetimepicker.min.css" />
   
    <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet" />

    
<link href="Scripts/outlook/default.css" rel="stylesheet" type="text/css" media="all" />

 <link rel="Stylesheet" type="text/css" media="screen" href="Scripts/Default.css" />
 <style type="text/css">
 select
 {
     width:200px;
 }
 a
 {
     font-size:small;
     color:Blue;
     padding:3px;   
 }
 hr
 {
     display:block;
 }
 </style>

 <script type="text/javascript">
  
    var energyData = <%=new JavaScriptSerializer().Serialize(energyArray)%>;

  
    var sD = <%=new JavaScriptSerializer().Serialize(startDate)%>;
    var timeStamps=<%=new JavaScriptSerializer().Serialize(timeSt) %>;

    var units=<%=new JavaScriptSerializer().Serialize(unit)%>;
    var dataType=<%=new JavaScriptSerializer().Serialize(plotType) %>;

    var startDate=sD*1000;

    var intervals = <%= new JavaScriptSerializer().Serialize(interval) %> ;
    var build = <%= new JavaScriptSerializer().Serialize(building) %> ;
    intervals=intervals*0.55;

    
    var readings=new Array(energyData.length);
   

    for(var i=0;i<energyData.length;i++)
    {
        readings[i]=new Array(2);
        readings[i][0]=timeStamps[i]*1000;
        readings[i][1]=energyData[i];
    }
     if(readings.length<=1)
    {
        alert("Sorry! We don't have data for your selection.");
    }
       jQuery(document).ready(function ($) {
                Highcharts.setOptions({
	global: {
		useUTC: false
	}
});
            $('#container').highcharts({
            chart: {
                type: 'line',
                 zoomType: 'x',
                spacingRight: 20
            },
            title: {
                text: build,
               
            },
            subtitle: {
                text: 'Click and Drag to Zoom in'
              
            },
            xAxis: {
             
               type:'datetime',
              
            },
            yAxis: {
                title: {
                    
                    text: dataType+"("+units+")"
                }
            },
            tooltip: {
                valueSuffix: units
            },
            plotOptions: {
                area: {
                    marker: {
                        enabled: false,
                        symbol: 'circle',
                        radius: 2,
                        states: {
                            hover: {
                                enabled: true
                            }
                        }
                    }
                }
            },
            series: [
            {
                name:  dataType+"("+units+")",
                data: readings
            }
            
            ]
        });

    });
   
   
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="Scripts/high_charts/js/highcharts.js"></script>
<script src="Scripts/high_charts/js/modules/exporting.js"></script>
<br />
<table style=" margin:0 auto;">


<tr><td style="padding-left:30px;" colspan="2">
           <table>
           <tr>         
           <td style="line-height:normal;">

           &nbsp;&nbsp;From<div id="datetimepicker1" class="input-append date" >
      <input type="text" id="fromDate" runat="server" style=" margin-left:10px;"/>
      

      <span class="add-on">
        <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
      </span>
    </div> 
           </td>     
           <td style="line-height:normal;">

               &nbsp;</td>     
           <td style="line-height:normal;">

           &nbsp;&nbsp;To<div id="datetimepicker2" class="input-append date" >
      <input type="text" id="toDate" runat="server" style=" margin-left:10px;"/>
      

      <span class="add-on">
        <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
      </span>
    </div> 

           </td>                
           <td style="padding-top:0px; padding-left:20px; line-height:30px;
           ">

               Parameter&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
               MeterType<br />

        <asp:DropDownList ID="paramList" runat="server">
        <asp:ListItem Value="Power" units="Watts">Power</asp:ListItem>
        <asp:ListItem Value="Voltage" units="Volts">Voltage</asp:ListItem>
        <asp:ListItem Value="Energy" units="FwdHr">Energy</asp:ListItem>
            <asp:ListItem Value="Frequency" units="Hertz">Frequency</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="meterList" runat="server">
        <asp:ListItem Value="Building Total Mains">Mains</asp:ListItem>
        <asp:ListItem Value="Building Total Backup">Light Backup</asp:ListItem>
    </asp:DropDownList>

           </td>                
           <td style="padding-top:20px; padding-left:20px;">
           
           <asp:Button ID="plotButton" Text="Plot" runat="server" class="customButton" 
                   onclick="plotButton_Click"/>
           </td></tr>
           </table>



            </td></tr>
            
            
<tr><td>

<p style="text-align: left;  font-weight:normal; font-size:small; line-height:13px; padding:1px; margin:1px; padding-left:40px;">Select date after 1 August only.
  </p>
            </td><td align="right" style="padding-right:20px;">
              <asp:LinkButton ID="wing1" runat="server" onclick="wing1_Click" >Wing A  |</asp:LinkButton>&nbsp;&nbsp;
    <asp:LinkButton ID="wing2" runat="server" onclick="wing2_Click">Wing BC  |</asp:LinkButton>&nbsp;&nbsp;
    
<a href="CampusDashboard.aspx" style="">Back</a>
        </td></tr>
            <tr><td colspan="2">
            
        
<div id="container" style="width: 1100px; height: 550px; max-width:1100px;"></div>

</td></tr>

<tr><td >

<br />


<table>
<tr style="border:1px solid gray; width:1100px;"><td>
    <asp:Image ID="buildingimg" runat="server" style="padding:5px; margin:5px;"/>
</td>
<td style="vertical-align:top; padding-right:10px;" runat="server" id="buildInfo">

</td>
</tr>
</table>
<br />

</td></tr>

</table>


 <script type="text/javascript"
     src="Scripts/calender/jquery.min.js">
    </script> 
    <script type="text/javascript"
     src="Scripts/calender/bootstrap.min.js">
    </script>
    <script type="text/javascript"
     src="Scripts/calender/bootstrap-datetimepicker.min.js">
    </script>
    <script type="text/javascript"
     src="Scripts/calender/bootstrap-datetimepicker.pt-BR.js">
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
</asp:Content>

