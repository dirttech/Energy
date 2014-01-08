<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PowerConsumption.aspx.cs" Inherits="Users_PowerConsumption" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Power Consumption</title>
    
    <link rel="stylesheet" type="text/css" media="screen" href="../Scripts/calender/bootstrap-datetimepicker.min.css" />
   
    <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet" />
    <script type="text/javascript">

        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-42987147-1']);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();

</script>

     <script type="text/javascript" src="http://code.jquery.com/jquery-latest.min.js"></script> 
    <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jquery.validate/1.11.1/jquery.validate.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.customSelect.js"></script>
    <script type="text/javascript">
        function Annonating(obj)
        {
            document.getElementById('<%=frmTime.ClientID%>').setAttribute("class", "NotAnnonated");
             document.getElementById('<%=tTime.ClientID%>').setAttribute("class", "NotAnnonated");
             obj.setAttribute("class", "Annonated");
        }

        jQuery(document).ready(function ($) {

            $('#options').click(function () {

                $('#optionsDiv').toggle("slow");             
            });

            $('select.styled').customSelect();
            /* -OR- set a custom class name for the stylable element */
            //            $('.mySelectBoxClass').customSelect({ customClass: 'myOwnClassName' });
        });


</script>
    <link rel="shortcut icon" href="../images/dashboard_icon.png" />
    <style type="text/css">
        #optionsDiv
        {
            display: none;
            text-decoration: none;
            border-radius: 2px;
            -webkit-box-shadow: 0px 0px 8px 0px #000000;
            -moz-box-shadow: 0px 0px 8px 0px #000000;
            box-shadow: 0px 0px 8px 0px #000000;
            text-align: center;
            vertical-align: bottom;
            color: #1a9cc8;
            line-height: 20px;
        }

        hr
        {
            margin: 0px;
        }

        a
        {
            font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
            text-decoration: none;
        }

       a:hover
       {
            text-decoration: none;
       }
        .topBarNavigation a:hover
        {
            font-size: x-large;
            color: White;
            text-decoration: none;
        }
        .Annonated
        {
            background-color: pink !important;
        }

        .NotAnnonated
        {
            background-color: white;
            cursor: pointer !important;
        }
        p
        {
            color: white;
        }
        #datatable> th> td
{
border: 1px solid black;
}
    </style>

    <link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />
      <link rel="stylesheet" type="text/css" media="screen" href="../Scripts/calender/bootstrap-datetimepicker.min.css" />
   
    <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet" />

       <script type="text/javascript">
  
    var energyData = <%=new JavaScriptSerializer().Serialize(energyArray)%>;
  
    var sD = <%=new JavaScriptSerializer().Serialize(startDate)%>;
    var timeStamps=<%=new JavaScriptSerializer().Serialize(timeSt) %>;
    var startDate=sD*1000;
   
    var intervals = <%= new JavaScriptSerializer().Serialize(interval) %> ;
    intervals=intervals*0.55;
    
    var readings=new Array(energyData.length);
    for(var i=0;i<energyData.length;i++)
    {
        readings[i]=new Array(2);
        readings[i][0]=timeStamps[i]*1000;
        readings[i][1]=energyData[i];
    }
   
    jQuery(document).ready(function ($) {
        Highcharts.setOptions({
            global: {
                useUTC: false
            }
        });
        $('#draggable').draggable();
        $('#closeButton').click(function() {
            $('#draggable').fadeOut();
            $('#msg').text('');
        });
        $('#container').highcharts({
            data:{table: document.getElementById('datatable')},
            chart: {
                type: 'area',
                zoomType: 'x',
                spacingRight: 20
            },
            title: {
                text: 'Click and Drag to Zoom in'
            },
            subtitle: {
                text: 'Click on certain point to annotate'              
            },
            xAxis: {
                type:'datetime'              
            },
            yAxis: {
                title: {
                    text: 'Power(Watts)'
                }
            },
            tooltip: {
                valueSuffix: 'Watts'
            },
            plotOptions: {
                area: {
                    cursor:'pointer',
                    point:{events:{click:function(){
                        $('#draggable').fadeIn();
                        var notAnnonated=$('.NotAnnonated').attr('id');
                        var annonated= $('.Annonated').attr('id');
                       
                        $('#'+annonated).val(new Date(this.x).toLocaleString());
                        $('#'+notAnnonated).attr('class','Annonated');
                        $('#'+annonated).attr('class','NotAnnonated');
                        $('#'+notAnnonated).attr('readonly','readonly');
                        $('#'+annonated).attr('readonly','readonly');
                        $("#form1").valid(); 
                    }}},
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
            }
        });

    });
   
   
    </script>
</head>
<body>

<script src="../Scripts/high_charts/js/highcharts.js"></script>
<script src="http://code.highcharts.com/modules/data.js"></script>
<script src="../Scripts/high_charts/js/modules/exporting.js"></script>
    <form id="form1" runat="server" style="margin:0px;">
              <div id="timeDiv" runat="server" style=" display:none; position:absolute; left:205px; top:102px;-moz-border-radius:8px;	-webkit-border-radius:8px;	border-radius:8px; 
                           box-shadow: 0px 0px 10px rgba(0,0,0,0.2); width:600px; height:170px; background-color:#0d96c5; opacity:0.99; z-index:12;">
                        <img id="Img1" runat="server" height="30" style="position:absolute; height:30px; top:5px; right:5px; cursor:pointer;" src="~/images/closeButton.png" alt="close" />
                        <br />
                        
                        <table style="color:white;" >
                            <tr>
                                <td class="page_names" style="color:black; "><h3 style="line-height:0px;">&nbsp;&nbsp;&nbsp;Set time period
                                    </h3><hr style="border-color:black;"/>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From:</td>
                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To:</td>
                            </tr>
                            <tr>
                                <td>
                                    <div id="datetimepicker1" class="input-append date">
                                        <input type="text" id="fromDate" runat="server" style=" margin-left:30px;"/> 
                                        <span class="add-on">
                                        </span>
                                    </div>       
                                </td>
                                <td>
                                    <div id="datetimepicker2" class="input-append date">
                                        <input type="text" id="toDate" runat="server" style=" margin-left:30px;"/>
                                        <span class="add-on">
                                        </span>
                                    </div>       
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td align="right">
                                    <asp:Button ID="timeSet" runat="server" Text="Set Time" class="customButton" OnClick="timeSet_Click" />
                                </td>
                            </tr>
                        </table>
                        
             </div>
           <div id="draggable" runat="server" style="-webkit-border-radius:8px;display:none;	border-radius:8px; z-index:100; background-color:#0d96c5; cursor:move;  box-shadow: 0px 0px 10px rgba(0,0,0,0.2);position:absolute; -khtml-user-drag: element; left:800px; top:150px; padding:10px;" draggable="true">
     <img id="closeButton" runat="server" style="position:absolute; top:15px; right:15px; height:20px; cursor:pointer;" src="~/images/closeButton.png" alt="close" />
        <table>
            <tr>
                <td colspan="2"><h3>Annotate Device</h3>
                    <p id="pmesg" runat="server"></p>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="frmTime" name="frmTime" runat="server" txt="" placeholder="From Time" class="Annonated" onClick="return Annonating(this)" ViewStateMode="Enabled" required="required"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tTime" name="tTime" runat="server" txt="" placeholder="To Time" class="NotAnnonated" onClick="return Annonating(this)"  ViewStateMode="Enabled" required="required"></asp:TextBox>
                </td>
            </tr>
            <tr id="oldDevice" runat="server">
                <td>  
                    <asp:DropDownList ID="deviceList" runat="server">
                    </asp:DropDownList>
                </td>
                <td><p>Not in list? Click to
                    <asp:LinkButton ID="addCustom" runat="server" ForeColor="Black" OnClick="addCustom_Click" >Add new device</asp:LinkButton></p>
                </td>
            </tr>
            <tr>
                <td colspan="2" >
                    <table Visible="False" runat="server" id="newDeviceTable">
                        <tr>
                            <td>
                                <asp:TextBox ID="newDeviceText" placeholder="New Device Name" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="newDeviceText" ErrorMessage="*Required" Font-Size="Larger" ForeColor="Pink"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="newDeviceDesc" placeholder="Description. Please explain this device." runat="server" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td>
                               
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="msg" runat="server" ForeColor="yellow"></asp:Label></td>
                <td>
                    <asp:Button ID="annonateButton" runat="server" Text="Annotate" CssClass="customButton" OnClick="annotateButton_Click"/>
                </td>
            </tr>
        </table>
     
    </div>

     <div id="navigationTop">
     <a href="front.aspx">Home</a>
 <a href="PowerConsumption.aspx" >Power Consumption</a>

     <a href="BarGraph.aspx">Energy Consumption</a>

     <a href="AverageComparison.aspx" >Me! vs Average</a>

     <a href="TrackBill.aspx" >Track Bill</a>
     </div>

      <img src="../images/icons/option-icon.png" height="20px" style="height:20px;color:Black; font-weight:bold;  position:absolute; top:15px; right:20px; cursor:pointer;" id="options" />
     <div style="position:absolute; right:15px; top:45px; background-color:White; width:150px; height:170px; z-index:10;" id="optionsDiv">
     <br /> 
     <hr style="margin:8px;"/>
      <a href="../UserSettings/EditUserProfile.aspx" style=" color:#1a9cc8;">Edit Profile</a>
     <hr style="margin:8px;"/>
     <a href="../UserSettings/ResetUserPassword.aspx" style=" color:#1a9cc8;" >Reset Password</a><br />
      <hr style="margin:8px;"/>
    
     <asp:LinkButton ID="logOut" runat="server"  
        
      style=" color:black;"  onclick="logOut_Click">LOG OUT</asp:LinkButton>
     
     <hr />
     </div>

     <a style="color:Black;  font-size:large;  position:absolute; top:10px; left:20px;" id="nameTitle" runat="server">Welcome</a>
     <br/>
 <table><tr>
 <td style="width:82%;">
  <div class="HeadingLeftTop">
    <label id="Heading" runat="server" style=" font-size:x-large;">Power Consmption</label>    
    <label id="subHeading" runat="server" style="font-size:small;" ></label>
    </div>
 </td>
 <td align="right">
 <img src="../images/clock.png" id="timeShow" alt="Set time" style="position:absolute; right:350px; height:35px; cursor:pointer;" title="Reset Time Period" />
  <asp:DropDownList ID="meterTypeList" runat="server" AutoPostBack="True" 
        class="styled" onselectedindexchanged="meterTypeList_SelectedIndexChanged" 
         ViewStateMode="Enabled">
    </asp:DropDownList>
 </td>
 </tr>
   
<tr>

</tr>
    
      </table>
      
      <div id="container" style="width: 1100px; height: 550px; max-width:1100px; margin:0 auto"></div>
          <div id="tableContainer" runat="server"></div>
    </form>
    
    <script type="text/javascript"
     src="../Scripts/calender/bootstrap.min.js">
    </script>
    <script type="text/javascript"
     src="../Scripts/calender/bootstrap-datetimepicker.min.js">
    </script>
    <script type="text/javascript"
     src="../Scripts/calender/bootstrap-datetimepicker.pt-BR.js">
    </script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            
            $('#datetimepicker1').datetimepicker({
                format: 'dd/MM/yyyy hh:mm:ss',
                pick12HourFormat: true
            });
            $('#datetimepicker2').datetimepicker({
                format: 'dd/MM/yyyy hh:mm:ss',
                pick12HourFormat: true
            });
            $('#Img1').click(function () {
                $("#timeDiv").hide("drop");
            });
            $('#timeSet').click(function () {
                $("#timeDiv").hide("drop");

            });
       
        $('#timeShow').click(function () {
            $("#timeDiv").show("drop");

        });

            $("#form1").validate({
                errorLabelContainer: '#pmesg',
                rules: {
                    frmTime: "required",
                    tTime:"required",
                    newDeviceText:"required",
                    deviceList:"required"
                },
                messages: {
                    frmTime: "Please specify 'From Time'",
                    tTime: "Please specify 'To Time'",
                    newDeviceText:"Please specify 'New Device'",
                    deviceList:"Please select 'Device'"
                }
            });

            $('#annonateButton').click(function () {
                $("#form1").valid(); 
            });
            $("#form1").valid(); 
        });

    </script>

</body>
</html>
