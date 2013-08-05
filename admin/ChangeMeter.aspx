<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeMeter.aspx.cs" Inherits="admin_ChangeMeter" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Update Meter/Device ID's</title>
    
<link rel="shortcut icon" href="../images/dashboard_icon.png" />
    <link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />
    <script type="text/javascript">
        function CopyHidden(ths) {

            var hid = ths.getAttribute("UID");
            document.getElementById('<%=Hidden1.ClientID%>').setAttribute("value", hid);
        }

    </script>
     <style type="text/css">

    td
{
  font-family:Verdana;
      
}

span
{
 margin:0px;
 padding:0px;
 font-family:Verdana;
}

select {
    -webkit-appearance:none;
    border: 1;
   background-color: #92CDF1;
   font-weight:normal;
   font-size:large;
   cursor:pointer;
    padding-right: 30px;
    width:123px;
    height:27px;
    color:white;
}
.pops
{   
    background-color:#265D85; opacity:0.95; display:none; padding:10px; padding-right:0px;box-shadow: 0px 0px 8px 1px #000000;
    width:330px;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    
        <div class="SideBar" style="top:0px; left:10px;">
    <div class="HeadingLeftTop" style="opacity:0.9; width:93.3%">
     <label id="Heading" runat="server" style=" font-size:x-large;">    Users</label>    
    <label id="subHeading" runat="server" style="font-size:small;" ></label>
    </div>
      <div id="sideBar" runat="server" style="background-color:skyblue; padding-left:20px;">
      
    
    </div>
    </div>

    <table id="mapUser" runat="server" class="pops">
    
    <tr>
    <td colspan="3" >
    <div class="HeadingLeftTop" style="background-color:White;" >
                <asp:Label ID="Top2" runat="server" Font-Bold="False" style="font-size:large; color:#265D85; line-height:19px;" >Change Meter</asp:Label>
                <img src="../images/closeButton.png" id="closer" alt="close" style="cursor:pointer; vertical-align:top;" align="right"  width  ="20px"/>
            </div>
            </td>
    </tr>
    
    <tr visible="false">

    <td >Apartment</td><td>
    <asp:TextBox ID="apartmentText" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="devId" Display="Dynamic" ErrorMessage="*Required" 
                    SetFocusOnError="True" ForeColor="white"></asp:RequiredFieldValidator>
                </td><td></td>
    </tr>
    <tr>
    <td>
        Meter No</td><td>
    <asp:TextBox ID="metId" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="metId" Display="Dynamic" ErrorMessage="*Required" 
                    SetFocusOnError="True" ForeColor="white"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" 
                ControlToValidate="metId" Display="Dynamic" ErrorMessage="integer b/w 1-1000" 
                MaximumValue="1000" MinimumValue="1" SetFocusOnError="True" Type="Integer" 
                ForeColor="white"></asp:RangeValidator>
    </td><td>
            &nbsp;</td>
    </tr>
    <tr visible="false">
    <td>
        Floor</td><td>
            <asp:DropDownList ID="floorList" runat="server">
                <asp:ListItem>0</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
            </asp:DropDownList>
    </td><td>
            &nbsp;</td>
    </tr>
    <tr visible="false">
    <td>
        Building</td><td>
            <asp:DropDownList ID="buildingList" runat="server">
                <asp:ListItem>Faculty Housing</asp:ListItem>
                <asp:ListItem>BoysHostel</asp:ListItem>
                <asp:ListItem>GirlsHostel</asp:ListItem>
                <asp:ListItem>MessDining</asp:ListItem>
                <asp:ListItem>Academic</asp:ListItem>
                <asp:ListItem>Library</asp:ListItem>
                <asp:ListItem>ServiceBlock</asp:ListItem>
            </asp:DropDownList>
    </td><td>
            &nbsp;</td>
    </tr>
    <tr>
    <td>
        Meter Type</td><td>
            <asp:DropDownList ID="meterTypeList" runat="server">
                <asp:ListItem>Unused</asp:ListItem>
                <asp:ListItem>ResidentialMains</asp:ListItem>
                <asp:ListItem>ResidentialBackup</asp:ListItem>
                <asp:ListItem>Lift</asp:ListItem>
                <asp:ListItem>Power</asp:ListItem>
                <asp:ListItem>Light Backup</asp:ListItem>
            </asp:DropDownList>
    </td><td>
            &nbsp;</td>
    </tr>
    <tr>
    <td>
                &nbsp;</td><td align="right">
                <asp:Label ID="green0" runat="server" Font-Bold="False" ForeColor="white"></asp:Label>
        <asp:Button ID="store" runat="server" Text="Update" class="customButton" 
                onclick="store_Click" />
    
        </td><td>
                &nbsp;
        <input id="Hidden1" type="hidden" runat="server"/></td>
    </tr>
    
    
    </table>

      <script type="text/javascript"
     src="../Scripts/calender/jquery.min.js">
    </script> 
       <script type="text/jscript">
           jQuery(document).ready(function ($) {


               $('.clicker').hover(function () {
                   $('.clicker').css('font-size', 'large');
                   $(this).css('font-size', 'x-large');


               });
               $('.clicker').click(function () {
                   var offset = $(this).offset();
                   $("#mapUser").hide();
                   $("#mapUser").show("slow");
                   $("#mapUser").offset({ top: offset.top - 4, left: offset.left + 145 });
                   $("#green0").text("");
               });
               $('#closer').click(function () {
                   $("#mapUser").hide("drop");
               });
           });


           </script>  

    </form>
</body>
</html>
