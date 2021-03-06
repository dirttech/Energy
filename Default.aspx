﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .floatingDivs
        {
            display: inline-block;
            position: relative;
            background-color: transparent;
            width: 21.7em;
            margin: 5px;
            cursor: pointer;
        }

        li#def
        {
            background-color: skyblue;
        }

        .floatContainer
        {
            margin: 0 auto;
            text-align: center;
        }

        .cutDiv1:before
        {
            content: '';
            position: absolute;
            top: 0;
            left: 0;
            border-top: 40px solid transparent;
            border-right: 40px solid transparent;
            width: 0;
        }

        .cutDiv2:before
        {
            content: '';
            position: absolute;
            top: 0;
            left: 0;
            border-top: 40px solid transparent;
            border-right: 40px solid transparent;
            width: 0;
        }

        .cutDiv3:before
        {
            content: '';
            position: absolute;
            top: 0;
            left: 0;
            border-top: 40px solid transparent;
            border-right: 40px solid transparent;
            width: 0;
        }

        .sideA
        {
            text-decoration: none;
            line-height: 40px;
            padding-left: 20px;
        }

        .image-central
        {
            width: 98%;
            height: 200px;
            padding: 4px 1px 0px 4px;
            margin: 0px 0px 0px 0px;
        }

        h3
        {
            background-color: black;
            color: White;
            margin: -0px;
            border-radius: 12px 12px 0px 0px;
            padding: 5px;
            font-weight: normal;
        }

        p
        {
            padding: 5px;
            padding-bottom: 0px;
            font-size: small;
            color: black;
            line-height: 20px;
            text-align: justify;
        }

        h2
        {
            padding-left: -1px;
        }
    </style>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $('.floatingDivs').mouseenter(function () {
                $(this).animate({
                    bottom: '60px'
                }, 300);
            });
            $('.floatingDivs').mouseleave(function () {

                $(this).animate({
                    bottom: '-0px'
                }, 300);
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="background-image: url('images/ene.jpg'); background-repeat: no-repeat; -webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover;">
        <br />
        <div id="log">
            <table style="z-index: 0;">
                <tr>
                    <td style="padding-right: 10px; opacity: 1.0;">
                        <img src="images/homeLogoAll.png" height="220px" style="png-shadow: 5px 5px 5px #222;" /></td>
                    <td style="font-family: @Batang; color: Black; text-transform: none; vertical-align: top; padding-top: 10px; padding-left: 10px;">
                        <div style="position: absolute; right: 10px; text-align: left;">
                            <a href="admin/adminLogin.aspx">
                                <img alt="Admin Login" title="Admin Login" height="75px" src="images/icons/admin.png" /></a>
                        </div>
                        <div style="position: absolute; right: 10px; top: 155px;">
                            <a href="Register.aspx">
                                <img alt="Register Here" title="Register Here" height="75x" src="images/icons/register.png" /></a>
                        </div>
                        <div style="position: absolute; right: 10px; top: 235px;">
                            <a href="Tips.aspx">
                                <img alt="Energy Saving Tips" title="Energy Saving Tips" height="75px" src="images/icons/smalltips.png" /></a>
                        </div>
                    </td>

                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
        <div class="floatContainer">
            <div class="floatingDivs" style="margin-left: 15px; bottom: -0px;">

                <h3>SensorAct - Sense, Interact, Actuate</h3>
                <div style="background-color: #4682B4; background-color: White;">
                    <img class="image-central" src="images/sensoract_image.png" />
                    <p>
                        SensorAct is an open source federated middleware which accommodates a rich ecosystem of sensors & actuators and enables building high level third party 
        applications. It also supports participation from stakeholders such as occupants to set policies for management of sensor data and control of 
        electrical/electronic systems.
                    </p>
                </div>
            </div>
            <div class="floatingDivs">
                <h3>Smart Meter - Energy Dashboards</h3>
                <div style="background-color: #DCDCDC; background-color: White;">
                    <img class="image-central" src="images/dashboard.png" />
                    <p>
                        With our energy dashboards, we collect and visualize energy consumption data and then
        investigate how real-time energy consumption feedback can be used as an effective tool for energy conservation and apply
         insights from behavioral science to design optimal interventions for changing energy use behavior. 
         We also do billing practices using this data.
                    </p>
                </div>
            </div>
            <div class="floatingDivs">
                <h3>NILM - Non Intrusive Load Monitoring</h3>
                <div style="background-color: #20B2AA; background-color: White;">
                    <img class="image-central" src="images/NILM.png" />
                    <p style="color: black">
                        Non intrusive load monitoring (NILM)  is the process of breaking down the total electrical load into constituent appliances.
             State of the art timeseries optimized machine learning techniques are being disaggregate the information collected using a smart meter.
              Each appliance has a unique power signature and we use these features for NILM.             
                    </p>
                    <%--<span style="background-color:Black; width:400px;">
        <a href="#" style="color:white; text-decoration:none; font-size:medium; padding:0px;">read more >></a>
        </span>--%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

