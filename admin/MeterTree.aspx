<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MeterTree.aspx.cs" Inherits="admin_MeterTree" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Line Diagram</title>
    
  <link rel="shortcut icon" href="../images/dashboard_icon.png" />

  <link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />
  <link rel="Stylesheet" type="text/css" media="print" href="../Scripts/Default.css" />
    
  
  
<script type="text/javascript" src="http://code.jquery.com/jquery-latest.min.js"></script>
  <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen" href="../Scripts/calender/bootstrap-datetimepicker.min.css" />

    <style type="text/css">
        
        h3
        {
            font-family:Verdena;
            font-weight:600;
        }
        .parent
        {
            font-family:Verdena;
            font-weight:600;
            color:skyblue;
        }
        .leaf
        {
            font-family: arial !important;
            font-size: medium !important;
        }
        .LeftTd
        {
            width: 175px;
            vertical-align:top;
        }
        .tree-box
        {
            vertical-align:top;
            margin-left:10px;
            padding-left:7px;
            background-color:lightcoral;
            width:inherit;
            border-radius:10px;
            min-width:450px;
            max-height:500px;
            overflow:auto !important;
            position:fixed;
            padding-bottom:10px;
        }
        
            .tree-box > h3
            {
                color:white;
            }
        scroll
        {
            padding-right:20px;
        }
        .load-box
        {
            width:250px;
            display:inline-block;
            background-color:lightgray;
            border:solid 5px white;
            box-shadow: 0px 0px 10px rgba(0,0,0,0.2);
            margin:10px;
            height:300px;
        }
        .meterid-block
        {
            background-color:orange;
            width:20px;
            text-align:center;
            font-family:verdena;
            font-weight:bolder;
            height:20px;
            margin:4px;
            display:inline-block;
            padding:4px;
        }
        .subload-name
        {
            font-family:arial;
            font-size:medium;
            font-weight:bolder;
        }
        .subload-reading
        {
            font-family:Verdena;
            padding-left:4px;
            font-size:large;
            color:maroon;
            font-weight:bolder;
        }

        .building-button
        {
            font-family:Georgia;
            font-size:medium;
            color:#0099FF;
            background-color:lightyellow;
            color:maroon;
            padding:3px;
            margin:5px;
            width:150px;
            line-height:20px;
            text-align:center;
        }
            .building-button > a
            {
                color:darkgreen;
                text-decoration:none;
                font-family:tahoma;
                font-weight:bolder;
            }
            .building-button > a:hover
            {
                color:blue;
                text-decoration:underline;
            }
        .residential-div
        {
            background-color:pink;
            border-radius:5px;
            padding:5px;
            margin-bottom:10px;
        }
        .commercial-div
        {
            background-color:lightgreen;
            border-radius:5px;
            padding:5px;
        }
        .pop-up
        {
            display:none;
            position:fixed;
            left:656px;
            top:130px;
            background-color:lightsalmon;
            background-color:black;
            color:white;
            border-radius:0px 5px 5px 0px;
            width:240px;
            height:200px;
            font-size:larger;
            padding-left:10px;
            padding-top:10px;
            opacity:0.85;
        }
        .cut-image
        {
            display:none;
            position:fixed;
            left:866px;
            top:135px;
            z-index:101;
        }
        .duplicate
        {
            padding-top:70px;
            padding-bottom: 10px;
            position:fixed;
            left:656px;
            opacity:0.9;
            top:130px;
            font-size:larger;
            background-color:lightsalmon;
            background-color:black;
            color:skyblue;
            border-radius:0px 5px 5px 0px;
            width:250px;
            height:120px;
            text-align:center;
            display:none;
        }
        .gen_label
        {
            font-size:x-large;
            color:black;
            font-family:georgia;
            margin-top:10px;
            text-align:center;
            margin-left:50px;
            padding:20px;
            background-color:skyblue;
            text-shadow:-1px -1px lightgray, 1px 1px lightgray;
        }
        .below-box
        {
            margin-left:10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
           <div id="timeDiv" runat="server" style=" display:none; position:absolute; left:205px; top:102px;-moz-border-radius:8px;	-webkit-border-radius:8px;	border-radius:8px; 
                           box-shadow: 0px 0px 10px rgba(0,0,0,0.2); width:600px; height:170px; background-color:#0d96c5; opacity:0.99; z-index:12;">
                        <img id="closeButton" runat="server" height="30" style="position:absolute; height:30px; top:5px; right:5px; cursor:pointer;" src="~/images/closeButton.png" alt="close" />
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

    <div id="topSlab" runat="server" style="background-color:skyblue;text-align:center; padding-left:50px; margin:-2px;padding:-2px;border-spacing:0px !important; width:101%; height:80px; margin-bottom:15px;">
        <table>
            <tr><td>
                
        <label class="gen_label" runat="server" id="residentialData"></label>
                </td><td>
                    
        <label class="gen_label" runat="server" id="commercialData"></label>
                     </td></tr>
        </table>
        <img src="../images/clock.png" id="timeShow" alt="Set time" style="position:absolute; height:35px; right:15px;top:15px; cursor:pointer;" title="Reset Time Period" />
        <h5 id="timePer" runat="server" style="position:absolute; height:35px; right:15px;top:45px;"></h5>
    </div>
        <table class="below-box">
            <tr>
                <td class="LeftTd" rowspan="2"> 
                    <div id="residentialDiv" class="residential-div">
                        <h3>Residential Buildings</h3>
                        <div class="building-button" id="facDiv" runat="server">   
                            <asp:LinkButton ID="FacultyHousing" runat="server" Text="Faculty Housing" OnClick="FacultyHousing_Click"   />
                        </div>
                      
                        <div class="building-button" id="grlDiv" runat="server">
                            <asp:LinkButton ID="GirlsHostel" runat="server" Text="Girls Hostel" OnClick="GirlsHostel_Click" />
                        </div>
                 
                        <div class="building-button" id="boyDiv" runat="server">
                            <asp:LinkButton ID="BoysHostel" runat="server" Text="Boys Hostel" OnClick="BoysHostel_Click"  />
                        </div>
                    </div>
                   
                    <div id="commercialDiv" class="commercial-div">
                        <h3>Commercial Buildings</h3>
                        <div class="building-button" id="facilityDiv" runat="server" >
                            <asp:LinkButton ID="FacilitiesBuilding" runat="server" Text="Facilities Building" OnClick="FacilitiesBuilding_Click" />
                        </div>
                  
                        <div class="building-button" id="acaDiv" runat="server">
                            <asp:LinkButton ID="AcademicBuilding" runat="server" Text="Academic Block" OnClick="AcademicBuilding_Click"  />
                        </div>

                         <div class="building-button" id="lecDiv" runat="server">
                            <asp:LinkButton ID="LectureBlock" runat="server" Text="Lecture Block" OnClick="LectureBlock_Click"  />
                        </div>
                   
                        <div class="building-button" id="messDiv" runat="server">
                            <asp:LinkButton ID="MessBuilding" runat="server" Text="Mess Building" OnClick="MessBuilding_Click" />
                        </div>
                    
                        <div class="building-button" id="libDiv" runat="server">
                            <asp:LinkButton ID="LibraryBuilding" runat="server" Text="Library Building" OnClick="LibraryBuilding_Click"/>        
                        </div>
                    </div> 
                     
                    
                </td>
                <td id="MainBox" runat="server">
                
                </td>
                <td></td>
            </tr>
            <tr>
                   
                <td id="TreeBox" runat="server" class="tree-box" >
                    <h3 runat="server" id="selectedBuilding" style="text-align:right; padding-right:20px; margin-top:5px; font-size:x-large;color:lightgoldenrodyellow;"></h3>
                     <h3>Loads<br /> --------> <br />Subloads(Supply Type)</h3>
                    <asp:TreeView ID="TreeView1"  runat="server" ExpandDepth="0" OnSelectedNodeChanged="LastSeenAt" ImageSet="Arrows" NodeIndent="200" NodeWrap="True" EnableViewState="true" ViewStateMode="Enabled">
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <LeafNodeStyle Font-Names="tahoma" Font-Size="Medium" BackColor="pink" ForeColor="Black" Font-Bold="false" Width="200px"/>
                        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="maroon" BackColor="WhiteSmoke" HorizontalPadding="5px" VerticalPadding="2px" NodeSpacing="4px" Width="150px"  CssClass="parent" />
                        <ParentNodeStyle Font-Bold="True" Font-Size="Medium" ForeColor="#0099FF" />
                        <SelectedNodeStyle Font-Underline="False" ForeColor="blue" BackColor="White" />
                       
                    </asp:TreeView>
                </td>
                <td>
                    <img src='../images/closeButton.png' alt='close' width='20px' align='right' class="cut-image" style='padding-right:10px;cursor:pointer;'/>
                            
                     <asp:ScriptManager ID="ScriptManager1" runat="server">
                    
                </asp:ScriptManager>
                    <asp:UpdatePanel ID="popUp" runat="server" >
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="TreeView1" EventName="SelectedNodeChanged" />
                        </Triggers>
                         <ContentTemplate>
                               <div id="realPop" runat="server" class="pop-up">
                                
                                 
                             </div>
                             <div id="duplicate" runat="server" class="duplicate"><img src="../images/loader.gif" style="height:20px;" />
                                     Loading...
                                 </div>
                             </ContentTemplate>
                    </asp:UpdatePanel>
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
         $('.dupl').click(function () {
             $(".pop-up").hide();
             $(".duplicate").show('slide', function () {
                 $(".cut-image").show("slow");
             });
            
         });
         $('.cut-image').click(function () {
             $(".pop-up").hide("slide");
             $(".cut-image").hide();
         });
        
         $('#timeShow').click(function () {
             $(".pop-up").hide("slide");
             $(".cut-image").hide();
             $(".pop-up").css("display", "none");
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
