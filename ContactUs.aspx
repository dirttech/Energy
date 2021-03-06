﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        .style1
        {
            margin: 0 auto;
            border-left: 2px solid gray;
            padding-left: 50px;
        }

        li#cont
        {
            background-color: skyblue;
        }

        td, p, h3, h4
        {
            font-weight: normal;
            font-variant: normal;
            font-style: normal;
            line-height: normal;
            font-size: medium;
        }

        h4
        {
            font-weight: normal;
            font-size: large;
            margin: 0px;
        }
        input
        {
            width: 200px;
            height: 20px;
        }
        h3
        {
            font-weight: normal;
            color: skyblue;
            font-size: x-large;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <table style="margin: 0 auto;">
        <tr>
            <td style="vertical-align: top; width: 550px; padding-right: 50px;">
                <h3>Energy Lab</h3>
                <p>3rd Floor, B-Wing, Academic Block<br />
                    IIIT Delhi</p>
                <hr style="display: block;" />
                <br />
                <p>
                    Okhla Industrial Estate,Phase III<br />
                    (Near Govind Puri Metro Station)<br />
                    New Delhi, India - 110020
                </p>
            </td>
            <td style="vertical-align: top;">
                <table class="style1">
                    <tr>
                        <td colspan="2">
                            <h4>Got Query / Suggestion / Opinion?</h4>
                            <font style="color: skyblue; padding-top: 10px; padding-bottom: 10px;">Share with us.</font><br />
                            <hr style="display: block" />
                        </td>
                    </tr>
                    <tr>
                        <td>Name</td>
                        <td>
                            <asp:TextBox ID="names" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="names" ErrorMessage="*" Font-Bold="True"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Contact</td>
                        <td>
                            <asp:TextBox ID="contact" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="contact" ErrorMessage="*" Font-Bold="True"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Message</td>
                        <td>
                            <asp:TextBox ID="message" runat="server" TextMode="MultiLine" Width="198px"
                                Height="70"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                ControlToValidate="message" ErrorMessage="*" Font-Bold="True"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="msg" runat="server" ForeColor="#009933"></asp:Label>
                        </td>
                        <td align="justify">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                                ConnectionString="<%$ ConnectionStrings:BillingAppConnectionString %>"
                                ProviderName="<%$ ConnectionStrings:BillingAppConnectionString.ProviderName %>"
                                SelectCommand="SELECT ID FROM suggestions"></asp:SqlDataSource>
                            <asp:Button ID="Button1" runat="server" Text="Share" Style="margin-left: 105px"
                                Width="100px" Height="35px" OnClick="Button1_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

