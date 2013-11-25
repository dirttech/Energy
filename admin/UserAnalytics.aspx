<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserAnalytics.aspx.cs" Inherits="admin_UserAnalytics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Analytics</title>
    
  <link rel="shortcut icon" href="../images/dashboard_icon.png" />

  <link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />
  <link rel="Stylesheet" type="text/css" media="print" href="../Scripts/Default.css" />
    
  
  
<script type="text/javascript" src="http://code.jquery.com/jquery-latest.min.js"></script>
  <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen" href="../Scripts/calender/bootstrap-datetimepicker.min.css" />
    <style type="text/css">
        table, td
        {
            border: 0px solid lightgray;
            background-color:none;            
        }
        th
        {
            font-family:Georgia;
            font-size:large;
            background-color:lightgray;
            height:20px;
            padding:15px;
            border:0px none;
            margin:0px;
        }
        .Thead
        {
            font-family:Georgia;
            font-size:large;
            color:white;
            background-color:#0091c2;
            height:20px;
            padding:18px;
            border-top:1px solid white;
            font-weight:bolder;
            
        }
        hr
        {
            margin:10px;
        }
        .page_names
        {
            color:#0091c2;
            font-size:large;
            font-family:Verdana;
           padding-left:10px;
           line-height:normal;
        }
        .page_no
        {
            font-size:large;
            font-family:Verdana;
        }
        .help_cell
        {
            line-height:normal;
            padding-left:25px;
            font-family:arial;
        }
        .gen_label
        {
            font-size:x-large;
            color:black;
            font-family:georgia;
            padding:20px;
            background-color:skyblue;
            text-shadow:-1px -1px lightgray, 1px 1px lightgray;
        }
        .flow_name
        {
            font-size:large;
            font-family:Verdana;
            color:#0091c2;
            padding-left:10px;
            line-height:normal;
        }
        .flow_no
        {
            font-size:large;
            font-family:Verdana;
            text-align:center;
        }
        
       
        
        </style>
</head>
<body ">
    <form id="form1" runat="server">
        
        
         <div id="timeDiv" runat="server" style=" display:none; position:absolute; left:200px; top:100px;-moz-border-radius:8px;	-webkit-border-radius:8px;	border-radius:8px; 
                           box-shadow: 0px 0px 10px rgba(0,0,0,0.2); width:600px; height:170px; background-color:#0d96c5; opacity:0.99; z-index:12;">
                        <img id="closeButton" runat="server" height="30" style="position:absolute; height:30px; top:5px; right:5px; cursor:pointer;" src="~/images/closeButton.png" alt="close" />
                        <br />
                        
                        <table style="color:white;" >
                            <tr>
                                <td class="page_names" style="color:black; line-height:normal;">&nbsp;&nbsp;&nbsp;Set time period
                                    <hr style="border-color:black;"/>
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

        
        <table style="width:100%; margin:0px;border-spacing:0px;">
            <tr >
                <td colspan="3" align="center" style="background-color:skyblue; margin:-2px;padding:-2px;border-spacing:0px !important; width:101%; height:80px;" >
                 
                    <div id="general_analytics" runat="server"></div>
                    <img src="../images/clock.png" id="timeShow" alt="Set time" style="position:absolute; height:35px; right:15px;top:25px; cursor:pointer;" title="Reset Time Period" />
                    <h5 id="timePer" runat="server" style="position:absolute; height:35px; right:15px;top:55px;"></h5>
                </td>
                
            </tr>
            <tr>
             
                <td style="vertical-align:top; " rowspan="2" >
                    <div id="user_flows" runat="server" style=""></div>
                </td>
                <td class="Thead"> 
                   Page/Event 
                                      
                </td>
                <td class="Thead"> 
                    
                       Views               
                </td>
            </tr>
            <tr>
             
                <td colspan="2" style="border-left:2px solid skyblue;"> 
                    
                     <div id="page_views" runat="server"></div>
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
                    $('#timeShow').click(function () {
                        var offset = $(this).offset();
                        $("#timeDiv").show("drop");
                    });
                    $('#closeButton').click(function () {
                        $("#timeDiv").hide("drop");
                    });
                    $('#timeSet').click(function () {
                        $("#timeDiv").hide("drop");
                    });
        });
           </script>    
        
    </form>
     
</body>
</html>
