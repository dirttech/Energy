<%@ Page Language="C#" AutoEventWireup="true" CodeFile="front.aspx.cs" Inherits="Users_front" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />
<link rel="shortcut icon" href="../images/dashboard_icon.png" />
 <link rel="Stylesheet" type="text/css" href="../Scripts/wheather/weather.css" />
    <script type="text/jscript" src="../Scripts/jquery-1.4.1.min.js"></script>
    
    
    <title>Dashboard Home</title>
  
    <style type="text/css">
        #weather
        {
              font: 13px 'Open Sans', "Helvetica Neue", Helvetica, Arial, "Lucida Grande", sans-serif;
              background: #0091c2;
              
              height:350px;
              opacity:0.9;
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
    p, h2, h3
        {
          font-family:Verdana;  
          color:White; 
        }
        
        h3
        {
             color:#265D85;
        }
        .bill-wrapper
        {
            position:relative;
           background-color:black;
           width:230px;  
           padding:0px;
           padding-left:15px;
           margin:10px;
           line-height:13px;
            opacity:0.7;
            float:left;
            height:80px;
        }
    
    </style>


     <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
     
</head>
<body>
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
     <script type="text/javascript" src="../Scripts/wheather/wheather.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $.simpleWeather({
                zipcode: '',
                woeid: '28743736',
                location: '',
                unit: 'c',
                success: function (weather) {
                    html = '<h2>' + weather.temp + '&deg;' + weather.units.temp + '</h2>';
                    html += '<ul><li>' + weather.city + ', ' + weather.region + '</li>';
                    html += '<li class="currently">' + weather.currently + '</li>';
                    html += '<li>' + weather.tempAlt + '&deg;F</li></ul>';
                    html += '<br /><ul><li>Humid - ' + weather.humidity + '%</li>';
                    html += '<li class="currently">' + weather.forecast + '</li></ul>';

                    $("#weather").html(html);
                },
                error: function (error) {
                    $("#weather").html('<p>' + error + '</p>');
                }
            });
        });

    </script>

    <table>
    <tr><td style="vertical-align:top;">
    <div style="background-color:#0091c2; opacity:0.9;padding:5px;margin:10px; margin-top:0px; ">
     <h3 id="topLine" runat="server" style="color:white; line-height:20px;"></h3>
    
    </div>
    </td><td rowspan="2">
     <div id="weather"></div>
     </td></tr>
    <tr><td style="vertical-align:top;">
     <div id="dashes" runat="server"></div>
     </td>
     </tr></table>


   
     
    




    </form>
</body>
</html>
