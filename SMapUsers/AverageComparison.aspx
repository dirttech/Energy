<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AverageComparison.aspx.cs" Inherits="AverageComparison" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <script type="text/javascript">
    var stackid=document.getElementById('<%=hiddenPlotType.ClientID %>');
    var stack=null;
//    if(stackid!=null)
//    {        
//        stack=document.getElementById('<%=hiddenPlotType.ClientID %>').value;
//        if(stack!="normal")
//        {
//          stack=null;
//        }
//    }

    var timeSeries=<%=new JavaScriptSerializer().Serialize(timeSeries) %>;
    
     var timeData = <%=new JavaScriptSerializer().Serialize(timeStamps)%>;
    var avgEn=<%=new JavaScriptSerializer().Serialize(avgValues) %>;
    var en=<%=new JavaScriptSerializer().Serialize(values) %>;
    avgEn.splice(avgEn.length-1,1);
    en.splice(en.length-1,1);

    var timeData1 = new Array;
  
  
    for(var i=0;i<timeData.length;i++){
    timeData1[i] = new Date(timeData[i]*1000);   
    d=timeData1[i];
    utc = d.getTime() + (d.getTimezoneOffset() * 60000);
      nd = new Date(utc + (3600000*5.5));
      timeData1[i]=nd.toUTCString();    
    }


      jQuery(document).ready(function ($) {
            

            $('#container').highcharts({
            chart: {
                type: 'bar',
                marginRight: 130,
                marginBottom: 50
            },
            title: {
                text: 'Energy Consumption Comparisons',
                x: -20 //center
            },
            subtitle: {
                text: '',
                x: -20
            },
            xAxis: {
             
               categories: timeSeries
               
                   },
            yAxis: {
                title: {
                    
                    text: 'Energy(Kilo-Watt Hrs)'
                },
                plotLines: [{
                    value: 0,
                    width: 1,
                    color: '#808080'
                }]
            },
            tooltip: {
                valueSuffix: 'KWHr'
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
                data: en
            },
            {
                name:'Average Consumption',
                data: avgEn
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
      <img src="../images/icons/option-icon.png" height="20px" style=" height:20px;color:Black; font-weight:bold;  position:absolute; top:15px; right:20px; cursor:pointer;" id="options" />
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
    <div>
    <table ><tr ><td style="width:200px;">
    <div class="HeadingLeftTop" style="width:220px;">
    <label id="Heading" runat="server" style=" font-size:x-large;">Last 7 Days</label>    
    <label id="subHeading" runat="server" style="font-size:small;" ></label>
    </div>
    <input id="hidCompType" type="hidden" runat="server" value="LWK"/>
<input id="hiddenHeadingType" type="hidden" runat="server" value="Last 7 Days" />
        <asp:Button ID="plot" runat="server" Text="Plot Now" onclick="plot_Click" class="customButton" style="display:none; position:absolute;" />
    </td><td align="right">
 
 
       <asp:DropDownList ID="viewTypeList" runat="server" AutoPostBack="True" 
        class="styled" onselectedindexchanged="viewTypeList_SelectedIndexChanged">
        <asp:ListItem Value="null" Selected="True">Normal View</asp:ListItem>
        <asp:ListItem Value="normal">Stack View</asp:ListItem>
        
    </asp:DropDownList>

           <asp:DropDownList ID="meterTypeList" runat="server" AutoPostBack="True" 
        class="styled" onselectedindexchanged="meterTypeList_SelectedIndexChanged">
       <asp:ListItem>Power</asp:ListItem>
        <asp:ListItem>Light Backup</asp:ListItem>
    </asp:DropDownList>

   
            <input type="hidden" value="null" id="hiddenPlotType" runat="server" />
    </td><td>
    </td></tr>
    
    <tr><td id="NavigationContainer" width="200px">
  
  <ul id="Navigation">
    <li><a class="navy" href="#" msg="Select month" compType="LWK" onclick="CopyHidden(this);" runat="server" onserverclick="plot_Click" id="lwk">Last 7 Days</a></li>
    <li><a class="navy" href="#" msg="Select month" compType="THMNT" onclick="CopyHidden(this);" runat="server" onserverclick="plot_Click" id="thmnt">This Month</a></li>
     <li><a class="navy" href="#" msg="Select month" compType="LMNTH" onclick="CopyHidden(this);" runat="server" onserverclick="plot_Click" id="lmnth">Last Month</a></li>
      <li><a class="navy" href="#" msg="Select month" compType="THYR" onclick="CopyHidden(this);" runat="server" onserverclick="plot_Click" id="thyr">This Year</a></li>
  </ul>


    </td><td>
    
     <div id="container" style="min-width: 900px; height: 550px; margin: 0 auto"></div>
    
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
//            $('.navy').click(function () {
//                var offset = $(this).offset();
//                $("#plot").hide();
//                $("#plot").show("drop");
//                $("#plot").offset({ top: offset.top, left: offset.left + 130 });
//            });

//            $('.plotType').click(function () {
//                var typ = $(this).attr('txt');

//                $('#hiddenPlotType').text(typ);
//            });

        });
       
    </script>
    </form>
</body>
</html>
