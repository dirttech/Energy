<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAnnonateDevice.aspx.cs" Inherits="admin_AddAnnonateDevice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add new Device</title>
    <link rel="shortcut icon" href="../images/dashboard_icon.png" />
    <link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />
     <link rel="stylesheet" type="text/css" media="screen" href="../Scripts/calender/bootstrap-datetimepicker.min.css" />
     <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet" / >
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <style type="text/css">
        .auto-style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <div class="HeadingLeftTop" style="opacity: 0.9; width: 300px">
                <label id="Heading" runat="server" style="font-size: x-large;">Add Device</label>
                <label id="subHeading" runat="server" style="font-size: small;">Please don't add duplicate devices.</label>
            </div>
        </div>
        <br />

        <table width="300px;">
            <tr>
                <td>
                    <asp:TextBox ID="deviceName" runat="server" placeholder="Device Name" required="Required"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="deviceDesc" runat="server" TextMode="MultiLine" placeholder="Description. Please explain the device."></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" align="center">&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="addingDevice" runat="server" CssClass="customButton" Text="Add Device" OnClick="addingDevice_Click" />
                    <asp:Label ID="msg" runat="server" ForeColor="#0066FF"></asp:Label>
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
