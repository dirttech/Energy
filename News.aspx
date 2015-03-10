<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        hr
        {
            display: block;
        }

        h3
        {
            color: skyblue;
            font-weight: 600;
        }

        li#new
        {
            background-color: skyblue;
        }

        .fund > li
        {
            font-size: medium;
            margin-top: 10px;
        }

        .recent > li
        {
            font-size: medium;
            margin-top: 10px;
        }


        .sideLine
        {
            left: 0px;
            position: fixed;
            width: 170px;
            background-color: offwhite;
            height: 180px;
            margin-top: 5px;
            padding: 10px;
            border-radius: 0px 12px 12px 0px;
            box-shadow: 0px 2px 2px 2px #888, 2px 3px 5px 0px #888;
        }

            .sideLine > ul > li > a
            {
                color: navy;
                line-height: 30px;
                text-decoration: none;
            }

                .sideLine > ul > li > a:hover
                {
                    text-decoration: underline;
                    cursor: pointer;
                }

        .teamWrapper
        {
            position: relative;
            left: 80px;
            margin-left: 50px;
            max-width: 1000px;
        }

        .imgbox
        {
            border: 1px solid black;
        }

        .imgContainer
        {
            border: 1px solid gray;
            float: left;
            margin: 3px;
            text-align: center;
            padding-top: 10px;
            width: 220px;
            height: 170px;
        }

        .img2container
        {
        }

        .c2img
        {
            width: 480px;
            height: 320px;
        }

        .cimg
        {
            width: 200px;
            height: 120px;
        }

        .desc2
        {
            font-size: large;
            color: Gray;
            font-weight: normal;
            padding-left: 10px;
        }

        .desc
        {
            font-size: small;
            font-weight: normal;
        }

        .abstractLink
        {
            text-decoration: underline;
            cursor: pointer;
            color: #6666ff;
        }
    </style>

    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $('.abstractLink').click(function () {
                var id = $(this).attr("val");
                $('#' + id).toggle('slow', function () {

                });
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    &nbsp;<br />
    <br />
    <div class="sideLine" style="display: none;">
        <a>Whats Happening</a><br />
        <ul>
            <li><a href="#funding">Funding</a></li>
            <li><a href="#recent">Recent News<a></li>
        </ul>
    </div>
    <div class="teamWrapper" id="funding">
        <h3>Funding</h3>
        <ul class="fund">
            <li><b>Pervasive Sensing and Computing Technologies for Energy and Water Sustainability in Buildings</b>, Dr. Amarjeet Singh(PI), Dr. 	Pushpendra Singh & Dr. Vinayak Naik (Co-PI),
 funded by <b>DIT and NSF</b>, 2 years starting April 2012, App. Rs 1,30,00,000
            </li>
            <li><b>Time and Presence Based Actuation</b>, Research Project funded by <b>Telecommunication Consultants India Limited (TCIL)</b>, completed May 2013, App. Rs 2,00,000</li>
        </ul>
        <hr id="recent" />
        <h3>Recent News</h3>
        <ul class="recent">
            <li>More than <b>150 smart meters</b> installed on IIIT Delhi campus with data being collected from them every 30 seconds.
            </li>
            <li>Surveyed more than <b>1500 households</b> in Delhi for energy consumption behavior in summer 2013.</li>
            <li>Recently completed an extensive home deployment.
                <div>
                    <table style="border: 1px solid black; margin-top: 5px;">
                        <tr>
                            <td class="style1" rowspan="2">
                                <div class="img2Container" style="border: 1px solid gray;">
                                    <p class="desc2">Schematic showing overall home deployment.</p>
                                    <img class="c2img" src="images/deployments/overall_deployment1.png" />
                                </div>
                            </td>
                            <td style="display: inline-block;" class="style1">
                                <span class="imgContainer">
                                    <img class="cimg" src="images/deployments/ambient_2.png" />
                                    <p class="desc">
                                        Sensing environmental parameters & light, temprature, motion.
                                    </p>
                                </span>
                                <span class="imgContainer">
                                    <img class="cimg" src="images/deployments/cc_1.png" />
                                    <p class="desc">Current cost CT based monitoring.<br />
                                    </p>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <span class="imgContainer">
                                    <img class="cimg" src="images/deployments/electric_meter_1.png" />
                                    <p class="desc">EM6400 Smart Electric Meter</p>
                                </span>
                                <span class="imgContainer">
                                    <img class="cimg" src="images/deployments/watermeter.png">
                                    <p class="desc">Pulse output water meter</p>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center;"><span class="imgContainer">
                                <img class="cimg" src="images/deployments/jplug_2.png" />
                                <p class="desc">Appliance level monitoring using jPlug.</p>
                            </span>
                                <span class="imgContainer" style="margin-left: 20px;">
                                    <img class="cimg" src="images/deployments/led.png" />
                                    <p class="desc">Glowing LEDs in the Night.</p>
                                </span>
                                <span class="imgContainer" style="margin-left: 20px;">
                                    <img class="cimg" src="images/deployments/mcb_2.png" />
                                    <p class="desc">Split Core CT monitoring circuit level current.</p>
                                </span>
                                <span class="imgContainer">
                                    <img class="cimg" src="images/deployments/rpi_2.png" />
                                    <p class="desc">Raspberry Pi collecting pulse outputs from water meter.</p>
                                </span>
                            </td>
                        </tr>
                    </table>
                </div>
            </li>
        </ul>
        <br />
    </div>
</asp:Content>

