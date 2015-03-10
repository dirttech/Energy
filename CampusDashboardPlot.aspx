<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CampusDashboardPlot.aspx.cs" Inherits="CampusDashboardPlot" %>

<%@ Import Namespace="System.Web.Script.Serialization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" media="screen" href="Scripts/calender/bootstrap-datetimepicker.min.css" />
    <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet" />
    <link href="Scripts/outlook/default.css" rel="stylesheet" type="text/css" media="all" />
    <link rel="Stylesheet" type="text/css" media="screen" href="Scripts/Default.css" />
    <style type="text/css">
        select
        {
            width: 200px;
        }
        a
        {
            font-size: small;
            color: Blue;
            padding: 3px;
        }
        hr
        {
            display: block;
        }
        .style1
        {
            width: 100%;
        }
    </style>
    <script type="text/javascript">
  
        var energyData = <% =new JavaScriptSerializer().Serialize(slab2Val)%>;  
        var powerData = <% =new JavaScriptSerializer().Serialize(energyArray)%>;
        var sD = <%=new JavaScriptSerializer().Serialize(startDate)%>;
        var timeStamps=<%=new JavaScriptSerializer().Serialize(timeSt) %>;
        var units=<%=new JavaScriptSerializer().Serialize(unit)%>;
        var dataType=<%=new JavaScriptSerializer().Serialize(plotType) %>;
        var startDate=sD*1000;
        var intervals = <%= new JavaScriptSerializer().Serialize(interval) %> ;
        var build = <%= new JavaScriptSerializer().Serialize(building) %> ;
        intervals=intervals*0.55;

        var barTime=<%=new JavaScriptSerializer().Serialize(energyTimeSeries)%>;
        var barEnergy=<%=new JavaScriptSerializer().Serialize(slab2Val)%>;
        var slab3En = <% =new JavaScriptSerializer().Serialize(slab3Val)%>;
        var slab1En = <% =new JavaScriptSerializer().Serialize(slab1Val)%>;
        var slab4En = <% =new JavaScriptSerializer().Serialize(slab4Val)%>;

        var slab1Text=<%=new JavaScriptSerializer().Serialize(slab1Txt)%>;
        var slab2Text=<%=new JavaScriptSerializer().Serialize(slab2Txt)%>;
        var slab3Text=<%=new JavaScriptSerializer().Serialize(slab3Txt)%>;
        var slab4Text=<%=new JavaScriptSerializer().Serialize(slab4Txt)%>;

        try
        {
        
            var readings=new Array(powerData.length);
            for(var i=0;i<powerData.length;i++)
            {
                readings[i]=new Array(2);
                readings[i][0]=timeStamps[i]*1000;
                readings[i][1]=powerData[i];
            }
            if(readings.length<=1)
            {
                alert("Sorry! We don't have data for your selection.");
            }
            barEnergy.splice(barEnergy.length-1,1);    
            slab1En.splice(slab1En.length-1,1);
            //        slab3En.splice(slab3En.length-1,1);
            //        slab4En.splice(slab4En.length-1,1);
        }
        catch(exp)
        {

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
                    line: {
                        allowPointSelect: true ,
                        cursor:'pointer',
                   
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
                credits:false,
                series: [
                {
                    name:  dataType+"("+units+")",
                    data: readings
                }
            
                ]
            });

            $('#container2').highcharts({
                chart: {
                    type: 'column'
                },
                title: {
                    text: 'Energy Consumption'
                },

                subtitle: {
                    text: ''
                },
                xAxis: {
                    type: 'datetime',
                    categories: barTime
                
                },
                yAxis: {
                    
                    title: {
                        text: 'Energy(Kilowatt Hrs)',
                        align: 'high'
                    },
                    labels: {
                        rotation: -90,
                        align: 'right',
                        style: {
                            fontSize: '13px',
                            fontFamily: 'Verdana, sans-serif'
                        }
                    }
                },
                tooltip: {
                    valueSuffix: ' KWh'
                },
                plotOptions: {
                    column: {
                        dataLabels: {
                            enabled: true,
                            rotation: -90,
                            color: '#FFFFFF',
                            align: 'justify',
                            x: 4,
                            y: 10,
                            style: {
                                fontSize: '13px',
                                fontFamily: 'Verdana, sans-serif',
                                textShadow: '0 0 3px black'
                            }
                        }
                    },
                    series: {
                        stacking:"normal"
                    }
                },
                
                credits: {
                    enabled: false
                },
                series: [{
                    name: 'Normal Hours('+slab2Text+')',
                    data: barEnergy
                },
             {
                 name: 'Peak Hours('+slab3Text+')',
                 data: slab3En,
                 color: 'maroon'
             },
             {
                 name: 'Off-Peak Hours('+slab1Text+')',
                 data: slab1En,
                 color: 'black'
             },
             {
                 name: 'Off-Peak Hours('+slab4Text+')',
                 data: slab4En,
                 color: 'black'
             }]
            });
        });   
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="Scripts/high_charts/js/highcharts.js"></script>
    <script src="Scripts/high_charts/js/modules/exporting.js"></script>
    <br />
    <table style="margin: 0 auto;">
        <tr>
            <td style="padding-left: 30px;" colspan="2">
                <table>
                    <tr>
                        <td style="line-height: normal;">&nbsp;&nbsp;From<div id="datetimepicker1" class="input-append date">
                            <input type="text" id="fromDate" runat="server" style="margin-left: 10px;" />
                            <span class="add-on">
                                <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                            </span>
                        </div>
                        </td>
                        <td style="line-height: normal;">&nbsp;</td>
                        <td style="line-height: normal;">&nbsp;&nbsp;To<div id="datetimepicker2" class="input-append date">
                            <input type="text" id="toDate" runat="server" style="margin-left: 10px;" />
                            <span class="add-on">
                                <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                            </span>
                        </div>
                        </td>
                        <td style="padding-top: 0px; padding-left: 20px; line-height: 30px;">Parameter&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
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
                        <td style="padding-top: 20px; padding-left: 20px;">
                            <asp:Button ID="plotButton" Text="Plot" runat="server" class="customButton"
                                OnClick="plotButton_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <p style="text-align: left; font-weight: normal; font-size: small; line-height: 13px; padding: 1px; margin: 1px; padding-left: 40px;">
                    Select date after 1 August only.
                </p>
            </td>
            <td align="right" style="padding-right: 20px;">
                <asp:LinkButton ID="wing1" runat="server" OnClick="wing1_Click">Wing A  |</asp:LinkButton>&nbsp;&nbsp;
    <asp:LinkButton ID="wing2" runat="server" OnClick="wing2_Click">Wing BC  |</asp:LinkButton>&nbsp;&nbsp;
                <a href="CampusDashboard.aspx" style="">Back</a>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="container" style="width: 1100px; height: 550px; max-width: 1100px;"></div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
                <table>
                    <tr>
                        <td align="right">Meter Type &nbsp;
                            <asp:DropDownList ID="loadType" runat="server">
                                <asp:ListItem Value="Building Total Mains">Mains</asp:ListItem>
                                <asp:ListItem Value="Building Total Backup">Light Backup</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="months" runat="server">
                                <asp:ListItem Value="1">Jan</asp:ListItem>
                                <asp:ListItem Value="2">Feb</asp:ListItem>
                                <asp:ListItem Value="3">Mar</asp:ListItem>
                                <asp:ListItem Value="4">Apr</asp:ListItem>
                                <asp:ListItem Value="5">May</asp:ListItem>
                                <asp:ListItem Value="6">Jun</asp:ListItem>
                                <asp:ListItem Value="7">Jul</asp:ListItem>
                                <asp:ListItem Value="8">Aug</asp:ListItem>
                                <asp:ListItem Value="9">Sep</asp:ListItem>
                                <asp:ListItem Value="10">Oct</asp:ListItem>
                                <asp:ListItem Value="11">Nov</asp:ListItem>
                                <asp:ListItem Value="12">Dec</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="years" runat="server">
                                <asp:ListItem>2013</asp:ListItem>
                                <asp:ListItem>2014</asp:ListItem>
                                <asp:ListItem>2015</asp:ListItem>
                                <asp:ListItem>2016</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="plotBar" runat="server" Style="margin-bottom: 13px;" Text="Plot" class="customButton"
                                OnClick="plotBar_Click" />
                            <a href="CampusDashboard.aspx" style="">Back</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="container2" style="width: 1100px; height: 550px; max-width: 1100px;"></div>
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <br />
                <table>
                    <tr style="border: 1px solid gray; width: 1100px;">
                        <td>
                            <asp:Image ID="buildingimg" runat="server" Style="padding: 5px; margin: 5px;" />
                        </td>
                        <td style="vertical-align: top; padding-right: 10px;" runat="server" id="buildInfo"></td>
                    </tr>
                </table>
                <br />

            </td>
        </tr>
        <tr>
            <td style="border-top: 1px solid gray;" colspan="2">
                <span style="color: rgb(34, 34, 34); font-family: arial, sans-serif; font-size: small; font-style: italic; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
                    <br />
                    Supported through extensive efforts by IIIT-Delhi Admin Department and research 
    grant from Department of Electronic and Information Technology (DEITy),
                    <br />
                    Government of India (Grant Number DeitY/R&amp;D/ITEA/4(2)/2012).</span></td>
        </tr>
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

