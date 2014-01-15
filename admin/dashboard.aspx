<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="admin_dashboard" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Energy Dashboard</title>
    <style type="text/css">
        .select
    {
        padding-bottom:10px;
            margin-left: 40px;
        }
    hr
    {
        margin:0px;
    }
    .meterInput
    {
         width:50px;   
    }
    </style>
    
  <link rel="Stylesheet" type="text/css" href="../Scripts/Default.css" />
   <link rel="stylesheet" type="text/css" href="../Scripts/calender/bootstrap-datetimepicker.min.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet" / >
    <script type="text/javascript">
        function CopyChecked() {
//            var htmlSelect = document.getElementById('<%=selectedBoxes.ClientID%>');
//            var list = "";
//            htmlSelect.Value = "";
//            for (var i = 0; i < 100; i++) {
//                if (document.getElementById("check" + i).checked) {
//                    var cid = document.getElementById("check" + i);
//                    var pid = cid.parentNode;
//                    var apt = pid.getAttribute("MeterId");
//                    list = list + apt + ",";
//                    htmlSelect.setAttribute("value", list);
//                }
//            }
            
        }
    </script>
        <script type="text/javascript">
    
    var valueArr1 = <%=new JavaScriptSerializer().Serialize(valueArray1)%>;
    var timeArr1 = <%=new JavaScriptSerializer().Serialize(timeArray)%>;
    var valueArr2 = <%=new JavaScriptSerializer().Serialize(valueArray2)%>;
   
    var valueArr3 = <%=new JavaScriptSerializer().Serialize(valueArray3)%>;
   
    var valueArr4 = <%=new JavaScriptSerializer().Serialize(valueArray4)%>;
   
    var valueArr5 = <%=new JavaScriptSerializer().Serialize(valueArray5)%>;
  

    var mD = <%=new JavaScriptSerializer().Serialize(midArr)%>;
    
    var interval = <%= new JavaScriptSerializer().Serialize(timeInterval) %> ;
    try{
            if(valueArr1!=null)
            {
                var readings1=new Array(valueArr1.length);
                for(var i=0;i<valueArr1.length;i++)
                {
                    readings1[i]=new Array(2);
                    readings1[i][0]=timeArr1[i]*1000;
                    readings1[i][1]=valueArr1[i];
                }  
            }  
         }
    catch(err1)  {

    }
    try{    
            if(valueArr2!=null)
            {
                var readings2=new Array(valueArr2.length);
                for(var i=0;i<valueArr2.length;i++)
                {
                    readings2[i]=new Array(2);
                    readings2[i][0]=timeArr1[i]*1000;
                    readings2[i][1]=valueArr2[i];
                }
            }
       }
            catch(err2)
            {

            }
      
    try{   
            if(valueArr3!=null)
            {
                var readings3=new Array(valueArr3.length);
                for(var i=0;i<valueArr3.length;i++)
                {
                    readings3[i]=new Array(2);
                    readings3[i][0]=timeArr1[i]*1000;
                    readings3[i][1]=valueArr3[i];
                }
            }
        }
        catch(err3)  {

    }
    try{   
            if(valueArr4!=null)
            {
                var readings4=new Array(valueArr4.length);
                for(var i=0;i<valueArr4.length;i++)
                {
                    readings4[i]=new Array(2);
                    readings4[i][0]=timeArr1[i]*1000;
                    readings4[i][1]=valueArr4[i];
                }
            }
        }
        catch(err4)  {

    }
    try{   
            if(valueArr5!=null)
            {
                var readings5=new Array(valueArr5.length);
                for(var i=0;i<valueArr5.length;i++)
                {
                    readings5[i]=new Array(2);
                    readings5[i][0]=timeArr1[i]*1000;
                    readings5[i][1]=valueArr5[i];
                } 
            }
        }
   
    catch(err5){

    }
     jQuery(document).ready(function ($) {
     var suffix=document.getElementById('<%=criteriaList.ClientID%>');
     var suffx=suffix.options[suffix.selectedIndex].getAttribute('units');
   
     $('#container').highcharts({
            chart: {
            renderTo: 'container',
                zoomType: 'x',
                spacingRight: 20
            },
             
            title: {
                text: document.ontouchstart === undefined ?
                    'Click and drag in the plot area to zoom in' :
                    'Drag your finger over the plot to zoom in'
            },
            subtitle: {
                
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
                    text: 'Energy Parameter'
                }
            },
            tooltip: {
                valueSuffix: suffx,
                shared: true
            },
            legend: {
                enabled: true
            },
            plotOptions: {
                line: {
                    fillColor: {
                   
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
                name:mD[0],
                data:readings1
            },
            {
            type:'line',
            name:mD[1],
            data:readings2
            },{
                 type:'line',
                 name:mD[2],
                data:readings3
            },
            {
            type:'line',
                name:mD[3],
                data:readings4
            },         
            {
             type:'line',
             name:mD[4],
             data:readings5
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
        <br />
    <table>
    <tr>
    <td>
   
       
    
    </td>
    <td colspan="2">       
           
     
        </td>
      
    </tr>
   
     <tr>
     <td style="vertical-align:top;" rowspan="2">
     <div class="HeadingLeftTop">
    <label id="Heading" runat="server" style=" font-size:x-large;">Select Buildings</label>
         <label id="subHeading" style="font-size:small;">and enter their respective meter ids.</label>
    </div>
    <input type="hidden" ID="selectedBoxes" runat="server" style="" />
    <br />
    <table>
    <tr><td>   <asp:DropDownList ID="build1" runat="server">
             <asp:ListItem>Faculty Housing</asp:ListItem>
             <asp:ListItem>Boys Hostel</asp:ListItem>
             <asp:ListItem>Academic Building</asp:ListItem>
             <asp:ListItem>Girls Hostel</asp:ListItem>
             <asp:ListItem>Mess Building</asp:ListItem>
             <asp:ListItem>Library Building</asp:ListItem>
             <asp:ListItem>Facilities Building</asp:ListItem>

        </asp:DropDownList>
        <asp:TextBox ID="meterTxt1" class="meterInput" runat="server" placeholder="Meter Id"></asp:TextBox>
        
        </td></tr>
         <tr><td>   <asp:DropDownList ID="build2" runat="server">
             <asp:ListItem>Faculty Housing</asp:ListItem>
             <asp:ListItem>Boys Hostel</asp:ListItem>
             <asp:ListItem>Academic Building</asp:ListItem>
             <asp:ListItem>Girls Hostel</asp:ListItem>
             <asp:ListItem>Mess Building</asp:ListItem>
             <asp:ListItem>Library Building</asp:ListItem>
             <asp:ListItem>Facilities Building</asp:ListItem>

        </asp:DropDownList>
        <asp:TextBox ID="meterTxt2" class="meterInput" runat="server" placeholder="Meter Id"></asp:TextBox>
        
        </td></tr>
           <tr><td>   <asp:DropDownList ID="build3" runat="server">
             <asp:ListItem>Faculty Housing</asp:ListItem>
             <asp:ListItem>Boys Hostel</asp:ListItem>
             <asp:ListItem>Academic Building</asp:ListItem>
             <asp:ListItem>Girls Hostel</asp:ListItem>
             <asp:ListItem>Mess Building</asp:ListItem>
             <asp:ListItem>Library Building</asp:ListItem>
             <asp:ListItem>Facilities Building</asp:ListItem>

        </asp:DropDownList>
        <asp:TextBox ID="meterTxt3" class="meterInput" runat="server" placeholder="Meter Id"></asp:TextBox>
        
        </td></tr>
           <tr><td>   <asp:DropDownList ID="build4" runat="server">
             <asp:ListItem>Faculty Housing</asp:ListItem>
             <asp:ListItem>Boys Hostel</asp:ListItem>
             <asp:ListItem>Academic Building</asp:ListItem>
             <asp:ListItem>Girls Hostel</asp:ListItem>
             <asp:ListItem>Mess Building</asp:ListItem>
             <asp:ListItem>Library Building</asp:ListItem>
             <asp:ListItem>Facilities Building</asp:ListItem>

        </asp:DropDownList>
        <asp:TextBox ID="meterTxt4" class="meterInput" runat="server" placeholder="Meter Id"></asp:TextBox>
        
        </td></tr>
           <tr><td>   <asp:DropDownList ID="build5" runat="server">
             <asp:ListItem>Faculty Housing</asp:ListItem>
             <asp:ListItem>Boys Hostel</asp:ListItem>
             <asp:ListItem>Academic Building</asp:ListItem>
             <asp:ListItem>Girls Hostel</asp:ListItem>
             <asp:ListItem>Mess Building</asp:ListItem>
             <asp:ListItem>Library Building</asp:ListItem>
             <asp:ListItem>Facilities Building</asp:ListItem>

        </asp:DropDownList>
        <asp:TextBox ID="meterTxt5" class="meterInput" runat="server" placeholder="Meter Id"></asp:TextBox>
        
        </td></tr>
    </table>
    <div id="checkboxDiv" runat="server" style="height:10px; display:none; overflow:scroll;" >
    
    </div>

    </td>
    <td >
    
      <div id="datetimepicker1" class="input-append date">
      <input type="text" placeholder="From Date/Time" id="fromDate" runat="server" style=" margin-left:30px; top: 0px; left: 0px;"/>     

      <span class="add-on">
        <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
      </span>
    </div> 
        &nbsp;
    
        &nbsp; 
              </td>  
   
    <td >
        <div id="datetimepicker2" class="input-append date">
      <input type="text" placeholder="To Date/Time" id="toDate" runat="server" style=" margin-left:10px;"/>
      

      <span class="add-on">
        <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
      </span>
    </div>   
&nbsp;</td>  
   
    <td class="select">
    
        <asp:DropDownList ID="criteriaList" runat="server">
         <asp:ListItem Value="Power" units="Watts">Power</asp:ListItem>
        <asp:ListItem Value="Voltage" units="Volts">Voltage</asp:ListItem>
        <asp:ListItem Value="Energy" units="Whr">Energy</asp:ListItem>
            <asp:ListItem Value="Frequency" units="Hertz">Frequency</asp:ListItem>
        </asp:DropDownList>
              <asp:Button ID="Button1" runat="server" Text="Plot" class="customButton"
                style=" margin-left:5px; margin-bottom:10px;" onclick="submitDate_Click"/>  </td>  
   
    </tr>
   
     <tr>
    <td colspan="3">
    
       <div id="container" style="width: 900px; height: 500px; "></div></td>
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
