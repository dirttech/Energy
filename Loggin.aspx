<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Loggin.aspx.cs" Inherits="LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="Stylesheet" type="text/css" href="Scripts/LoginStyle.css" />
    <noscript>
        <body scroll="no" style="text-align: center; overflow: hidden; z-index: 1000;">
            <center>
                <table border="0" style="height: 98%; top: 50px; z-index: 1000; width: 100%; right: 1%; left: 1%; background: #F5E391; position: fixed">
                    <tr>
                        <td align="center">
                            <div style="position: fixed; font-size: 18px; z-index: 2; cursor: help; background: #F5E391; width: 480px; color: black; padding: 5px 5px 5px 5px; border: 1px solid; border-color: #000000; height: auto; text-align: left; left: 15%; top: 30%;">
                                <span style="font: bold 20px Arial; color: #000000; background: #F5E391; vertical-align: top">NO SCRIPT ERROR:</span><br />
                                Sorry this site will not function properly without the use of scripts.
                                The scripts are safe and will not harm your computer in anyway. 
                                Adjust your settings to allow scripts for this site and reload the site.
                            </div>
                        </td>
                    </tr>
                </table>
            </center>
        </body>
    </noscript>
    <script src="http://crypto-js.googlecode.com/svn/tags/3.1.2/build/rollups/md5.js"></script>
    <script>
        function extractPass() {
            var msg = document.getElementById('<%=pwd.ClientID%>').value;
            var hash = CryptoJS.MD5(msg);
            document.getElementById('<%=psHid.ClientID%>').value = hash;
        }
    </script>

    <link rel="shortcut icon" href="images/dashboard_icon.png" />
    <style type="text/css">
        a
        {
            text-decoration: underline;
            color: White;
        }

        li#log
        {
            background-color: skyblue;
        }

        a:hover
        {
            color: orange;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="background-image: url('images/ene.jpg'); background-repeat: no-repeat; -webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover; width: 100%; height: 630px;">
        <tr>
            <td style="width: 600px; vertical-align: top; padding-top: 50px; padding-left: 40px;">
                <h3>Average indian house is consuming <font color="red">1100 KWhr </font>of energy every year.</h3>
                <br />
                Want to know yours?&nbsp;&nbsp;<a href="Register.aspx">Register here  </a>
                <br />
                <br />
                <h3>Do you know?</h3>
                <br />
                A front loading washing machine is always more efficient than a top load washing machine!
                <br />
                <br />
                Try some of these <a href="Tips.aspx">energy-saving ideas </a>
            </td>
            <td style="vertical-align: top;">
                <div class="LoginContainer">
                    <div class="login">
                        <h1>Login</h1>
                        <p>
                            <input type="text" name="login" value="" placeholder="Username   " runat="server" id="usrName" /></p>
                        <p>
                            <input type="password" name="password" value="" placeholder="Password" runat="server" id="pwd" />
                            <input runat="server" type="hidden" id="psHid" />
                        </p>
                        <p class="submit">
                            <asp:Button ID="loginUser" runat="server" Text="Login"
                                OnClick="loginUser_Click" OnClientClick="extractPass()" />
                        </p>
                        <p>
                            <asp:Label ID="msg" Text="" runat="server" Style="color: #c4376b; font-weight: bold;"></asp:Label>
                        </p>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

