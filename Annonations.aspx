<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Annonations.aspx.cs" Inherits="Annonations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <link rel="shortcut icon" href="images/dashboard_icon.png" />
    <link rel="Stylesheet" type="text/css" media="screen" href="Scripts/Default.css" />
     <link rel="stylesheet" type="text/css" media="screen" href="Scripts/calender/bootstrap-datetimepicker.min.css" />
     <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet" / >
    <script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
    <style type="text/css">
        .Annonated
        {
            background-color:pink !important;
        }
        .NotAnnonated
        {
            background-color:white;
            cursor:pointer !important;
        }
        p
        {
            color:white;
        }

    </style>
    <script type="text/javascript">

        function Annonating(obj)
        {
            document.getElementById('<%=frmTime.ClientID%>').setAttribute("class", "NotAnnonated");
            document.getElementById('<%=tTime.ClientID%>').setAttribute("class", "NotAnnonated");
            obj.setAttribute("class", "Annonated");
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="-webkit-border-radius:8px;	border-radius:8px; background-color:#0d96c5;  box-shadow: 0px 0px 10px rgba(0,0,0,0.2);position:fixed; left:100px; top:95px; padding:10px;">
     <img id="closeButton" runat="server" style="position:absolute; top:15px; right:15px; height:20px; cursor:pointer;" src="~/images/closeButton.png" alt="close" />
        <table>
            <tr>
                <td colspan="2"><h3>Annonate Device</h3>
                    <p>Click on "From/To Time" and select a respective point on graph.</p>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="frmTime" runat="server" Text="1001001001" class="Annonated" onClick="return Annonating(this)" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tTime" runat="server" Text="2002002002" class="NotAnnonated" onClick="return Annonating(this)" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
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
                    <asp:Button ID="annonateButton" runat="server" Text="Annonate" CssClass="customButton" OnClick="annonateButton_Click"/>
                </td>
            </tr>
        </table>
     
    </div>
    </form>
</body>
</html>
