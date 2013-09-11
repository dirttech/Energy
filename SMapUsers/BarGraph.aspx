<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BarGraph.aspx.cs" Inherits="BarGraph" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

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
    <script type="text/javascript" src="../Scripts/jquery.customSelect.js"></script>
<style type="text/css">

  #optionsDiv
    {
      display:none;  
      text-decoration:none;
      border-radius:2px;
      -webkit-box-shadow: 0px 0px 8px 0px #000000;
-moz-box-shadow: 0px 0px 8px 0px #000000;
box-shadow: 0px 0px 8px 0px #000000;
 text-align:center;
 vertical-align:bottom;
 color:#1a9cc8;
 line-height:20px;
    }
      hr
    {
        margin:0px;
    }
       a
      {
          font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
          text-decoration:none;
      }
        a:hover
        {
             text-decoration:none;
        }

</style>
<link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />

<link rel="shortcut icon" href="../images/dashboard_icon.png" />
<script type="text/javascript">
    jQuery(document).ready(function ($) {
        $('#options').click(function () {

            $('#optionsDiv').toggle("slow");
        });

        $('select.styled').customSelect();
        /* -OR- set a custom class name for the stylable element */
        //            $('.mySelectBoxClass').customSelect({ customClass: 'myOwnClassName' });
    });
</script>
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

    
<script type="text/javascript" src="http://code.jquery.com/jquery-latest.min.js"></script>
  
    <script type="text/javascript">
     var timeData = <%=new JavaScriptSerializer().Serialize(timeArray)%>;
     var energyData = <%=new JavaScriptSerializer().Serialize(energyArray)%>;

     energyData.splice(energyData.length-1,1);
   
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
                    text: 'Energy Consumption'
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
                        text: 'Energy(Kilo-Watt Hrs)',
                        align: 'high'
                    },
                    labels: {
                        overflow: 'justify'
                    }
                },
                tooltip: {
                    valueSuffix: ' KWhr'
                },
                plotOptions: {
                    bar: {
                        dataLabels: {
                            enabled: true
                        }
                    }
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
     
     <br />

<table>
    
<tr>
<td >
    
<div class="HeadingLeftTop">
<label id="Heading" runat="server" style=" font-size:x-large;">Month Consumption</label>
<label id="subHeading" runat="server" style="font-size:small;" ></label>
</div>


</td>
<td align="right">
    <asp:DropDownList ID="meterTypeList" runat="server" AutoPostBack="True" 
        class="styled" onselectedindexchanged="meterTypeList_SelectedIndexChanged">
        <asp:ListItem>Power</asp:ListItem>
        <asp:ListItem>Light Backup</asp:ListItem>
    </asp:DropDownList>
   

</td>
</tr>
    
<tr>
<td id="NavigationContainer">
   


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
  </ul></td>
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
