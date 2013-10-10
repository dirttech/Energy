<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PowerConsumption.aspx.cs" Inherits="Users_PowerConsumption" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Power Consumption</title>
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
    <link rel="shortcut icon" href="../images/dashboard_icon.png" />
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
    .topBarNavigation a:hover
{
  font-size: x-large;   
  color:White;
  text-decoration:none;
     
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
            $('#container').highcharts({
            chart: {
                type: 'area',
                 zoomType: 'x',
                spacingRight: 20
            },
            title: {
                text: 'Click and Drag to Zoom in'
               
            },
            subtitle: {
                text: ''              
            },
            xAxis: {
             
               type:'datetime',
              
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
                name: 'Power Consumption',
                data: readings
            }
            
            ]
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
    <label id="Heading" runat="server" style=" font-size:x-large;">Last 24 Hours</label>    
    <label id="subHeading" runat="server" style="font-size:small;" ></label>
    </div>
 </td>
 <td align="right">
 
  <asp:DropDownList ID="meterTypeList" runat="server" AutoPostBack="True" 
        class="styled" onselectedindexchanged="meterTypeList_SelectedIndexChanged" 
         ViewStateMode="Enabled">
        <asp:ListItem>Power</asp:ListItem>
        <asp:ListItem>Light Backup</asp:ListItem>
    </asp:DropDownList>
 </td>
 </tr>
   
<tr>

</tr>
    
      </table>
      <div id="container" style="width: 1100px; height: 550px; max-width:1100px; margin:0 auto"></div>
    </form>
</body>
</html>
