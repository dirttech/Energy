﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Team.aspx.cs" Inherits="Team" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .reHead
        {
            color: #4682B4;
            line-height: normal;
            margin: 0px;
            font-size: medium;
        }

        hr
        {
            display: block;
            position: relative;
            left: 130px;
        }

        li#tem
        {
            background-color: skyblue;
        }

        h4
        {
            position: relative;
            left: 130px;
            line-height: normal;
            color: skyblue;
            margin-bottom: 0px;
        }

        .sideLine
        {
            top: 40px;
            z-index: 100;
            position: fixed;
            width: 100%;
            background-color: whitesmoke;
            height: 110px;
            margin-top: 5px;
            padding: 10px;
        }

            .sideLine > a
            {
                color: navy;
                line-height: 30px;
                padding-left: 120px;
            }

        .ul
        {
            margin: 0px;
            padding-left: 150px;
        }

            .ul > li
            {
                padding-right: 50px;
                display: inline-block;
                /* You can also add some margins here to make it look prettier */
                zoom: 1;
                display: inline;
                /* this fix is needed for IE7- */
            }

                .ul > li > a
                {
                    font-size: medium;
                }

                    .ul > li > a:hover
                    {
                        text-decoration: underline;
                        cursor: pointer;
                    }

        .personal-wrapper
        {
            -webkit-box-shadow: 2px 2px 0px 0px #CCDCDC;
            -moz-box-shadow: 2px 2px 0px 0px #CCDCDC;
            box-shadow: 2px 2x 0px 0px #CCDCDC;
            width: 300px;
            height: 175px;
            border: 1px groove gray;
            position: inherit;
            margin: 5px;
            margin-top: 0px;
            margin-bottom: 0px;
            float: left;
        }

        .nameWrapper
        {
            color: #4682B4;
            text-align: left;
        }

        .below-info
        {
            font-size: small;
        }

        .bottomSec
        {
            position: absolute;
            top: 160px;
        }

        .teamWrapper
        {
            position: relative;
            left: 90px;
            max-width: 1000px;
            margin-left: 50px;
        }

        .personalImage
        {
            height: 137px;
            width: 120px;
        }

        .toHideWrapper
        {
            background-color: #DCDCDC;
            width: 300px;
            height: 30px;
            color: #4682B4;
            cursor: pointer;
            text-align: right;
            font-size: medium;
        }

        .infoWrapper
        {
            text-align: left;
            vertical-align: top;
            width: 55%;
            height: 130px;
            background-color: White;
        }

        .namePosition
        {
            color: Gray;
            font-family: Calibri;
        }

        .hidden-wrapper
        {
            width: 300px;
            height: 100px;
            display: none;
        }

        .description
        {
            font-size: small;
            font-family: arial;
            font-weight: lighter;
        }
    </style>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $('.toHideWrapper').click(function () {
                var container_id = "#" + $(this).parents('.personal-wrapper').attr('id');
                var hidden_id = "#" + $(container_id).find('.hidden-wrapper').attr('id');
                if ($(hidden_id).css('display') == 'none') {
                    $(container_id).animate({ height: '310px' }, 1000);
                    $(hidden_id).fadeIn("slow");
                }
                else {
                    $(hidden_id).fadeOut("slow");
                    $(container_id).animate({ height: '178px' }, 1000);
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="sideLine">
        <a>Our Team</a>
        <ul class="ul">
            <li><a onclick="scrollTo('prof')" name="prof" class="lnk">Faculty</a></li>
            <li><a onclick="scrollTo('phd')" name="phd" class="lnk">Ph.D</a></li>
            <li><a onclick="scrollTo('ra')" name="ra" class="lnk">Software Engineer / RA</a></li>
            <li style="display: none;"><a onclick="scrollTo('mtech')" name="mtech" class="lnk">M.Tech</a></li>
            <li style="display: none;"><a onclick="scrollTo('btech')" name="btech" class="lnk">B.Tech</a></li>
            <li><a onclick="scrollTo('alumni')" name="alumni" class="lnk">Alumni</a></li>
        </ul>
        <a>Collaborators</a><br />
        <ul class="ul">
            <li><a onclick="scrollTo('ucla')" name="ucla" class="lnk">UCLA</a></li>
            <li><a onclick="scrollTo('ibm')" name="ibm" class="lnk">IBM Research</a></li>
            <li><a onclick="scrollTo('ccls')" name="ccls" class="lnk">CCLS Columbia</a></li>
            <li><a onclick="scrollTo('cmu')" name="cmu" class="lnk">CMU</a></li>
        </ul>
    </div>
    <div class="bottomSec">
        <table>
            <tr>
                <td>
                    <h4 id="prof">Faculty</h4>
                    <hr />
                    <div id="profDiv" class="teamWrapper">
                        <div class="personal-wrapper" id="Div7">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <a target="_blank" class="nameWrapper" href="http://www.iiitd.edu.in/~amarjeet/">Amarjeet Singh</a><br />
                                        <label class="namePosition">Assistant Professor</label><br />
                                        <label class="below-info">
                                            MUC - IIIT Delhi<br />
                                            <br />
                                        </label>
                                        <label class="description">
                                            <p class="reHead">Research Interests -</p>
                                            Mobile Sensing, Approximation Algorithms, Environmental Monitoring, Low Cost Technologies
                                            <br />
                                            <br />
                                        </label>
                                        <label class="below-info">
                                        Email -  amarjeet [at] iiitd [dot] ac [dot] in              
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="personal-wrapper" id="Div8">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <a target="_blank" href="http://www.iiitd.edu.in/~pushpendra/" class="nameWrapper">Pushpendra Singh</a><br />
                                        <label class="namePosition">Assistant Professor</label>
                                        <br />
                                        <label class="below-info">
                                            MUC - IIIT Delhi<br />
                                            <br />
                                        </label>
                                        <label class="description">
                                            <p class="reHead">Research Interests -</p>
                                            Middleware, Mobile Computing<br />
                                        </label>
                                        <br />
                                        <label class="below-info">
                                            Email -  psingh[at] iiitd [dot] ac [dot] in
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <h4 id="phd">Ph.D</h4>
                    <hr />
                    <div id="phdDiv" class="teamWrapper">
                        <div class="personal-wrapper" id="Div4">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <a target="_blank" class="nameWrapper" href="http://www.iiitd.edu.in/~samy/">Pandarasamy Arjunan</a><br />
                                        <label class="namePosition">Ph.D Scholar</label><br />
                                        <label class="below-info">
                                            MUC - IIIT Delhi<br />
                                        </label>
                                        <br />
                                        <label class="description">
                                            <p class="reHead">Research Interests -</p>
                                            Energy management in buildings,
                                            Embedded sensing networks,
                                            Cyber-Physical Systems,
                                            Internet of Things.
                                            <br />
                                        </label>
                                        <label class="below-info">
                                            Email -  pandarasamya[at] iiitd [dot] ac [dot] in
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="personal-wrapper" id="Div3">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <a target="_blank" href="http://nipunbatra.github.io/" class="nameWrapper">Nipun Batra</a><br />
                                        <label class="namePosition">Ph.D Scholar</label><br />
                                        <label class="below-info">
                                            MUC - IIIT Delhi<br />
                                        </label>
                                        <br />
                                        <label class="description">
                                            <p class="reHead">Research Interests -</p>
                                            Machine Learning, Data Analytics, Algorithms, Computational Sustainability & Information Processing in Sensor Systems
                
                                        </label>
                                        <br />
                                        <label class="below-info">
                                            Email -  nipunb[at] iiitd [dot] ac [dot] in
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="personal-wrapper" id="Div5">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <a target="_blank" href="http://manojgulati.wordpress.com/" class="nameWrapper">Manoj Gulati</a><br />
                                        <label class="namePosition">Ph.D Scholar</label><br />
                                        <label class="below-info">
                                            ECE - IIIT Delhi<br />
                                        </label>
                                        <br />
                                        <label class="description">
                                            <p class="reHead">Research Interests -</p>
                                            Embedded Systems, Sensor networks, Signal processing, Electromagnetics.
                                            <br />
                                            <br />
                                        </label>
                                        <label class="below-info">
                                            Email -  manojg[at] iiitd [dot] ac [dot] in                
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="personal-wrapper" style="margin-top: 10px;" id="milanDiv">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <a target="_blank" href=" http://milanjainblog.wordpress.com/" class="nameWrapper">Milan Jain</a><br />
                                        <label class="namePosition">Ph.D Scholar</label><br />
                                        <label class="below-info">
                                            CSE(MUC), IIIT Delhi
                                        </label>
                                        <br />
                                        <br />
                                        <label class="description">
                                            <p class="reHead">Research Interests -</p>
                                            Home Automation based on Z-Wave,
                                            Wireless Communication, Algorithms, Web Interfaces
                                            <br />
                                            <br />
                                        </label>
                                        <label class="below-info">
                                            Email - milan1267 [at] iiitd [dot] ac [dot] in               
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <h4 id="ra">Software Engineer / RA</h4>
                    <hr />
                    <div id="raDiv" class="teamWrapper">
                        <div class="personal-wrapper" id="Div2">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <a target="_blank" href="http://manaswisaha.wordpress.com/" class="nameWrapper">Manaswi Saha</a><br />
                                        <label class="namePosition">Research Scholar</label><br />
                                        <label class="below-info">
                                            MUC - IIIT Delhi<br />
                                        </label>
                                        <br />
                                        <label class="description">
                                            <p class="reHead">Research Interests -</p>
                                            Ubiquitous Computing, Applied Machine Learning, ICTD
                                            <br />
                                            <br />
                                        </label>
                                        <label class="below-info">
                                            Email -  manaswis[at] iiitd [dot] ac [dot] in                
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="personal-wrapper" id="Div6">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <a target="_blank" href="http://in.linkedin.com/pub/inderpal-singh/27/798/b46" class="nameWrapper">Inderpal Singh</a><br />
                                        <label class="namePosition">Software Engineer</label><br />
                                        <label class="below-info">
                                            MUC - IIIT Delhi<br />
                                        </label>
                                        <br />
                                        <label class="description">
                                            <p class="reHead">Tech Involvement -</p>
                                            Web & Software Programming, Web Interfaces, Web Crawling, Systems & Android devices, HCI
                                            <br />
                                            <br />
                                        </label>
                                        <label class="below-info">
                                            Email -  inderpals [at] iiitd [dot] ac [dot] in          
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="personal-wrapper" id="Div25">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <a target="_blank" href="http://www.shubhamsaini.com/" class="nameWrapper">Shubham Saini</a><br />
                                        <label class="namePosition">Research Scholar</label><br />
                                        <label class="below-info">
                                            MUC - IIIT Delhi<br />
                                        </label>
                                        <br />
                                        <label class="description">
                                            <p class="reHead">Research Interests -</p>
                                            Machine Learning, Data Mining and Analytics (with applications in Computational Sustainability and Anomaly Detection)
                                        <br />
                                        </label>
                                        <label class="below-info">
                                            Email - shubhams [at] iiitd [dot] ac [dot] in                
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="display: none;">
                    <h4 id="mtech">M.Tech</h4>
                    <hr />
                    <div id="mtechDiv" class="teamWrapper">
                    </div>
                </td>
            </tr>
            <tr>
                <td style="display: none;">
                    <h4 id="btech">B.Tech</h4>
                    <hr />
                    <div id="btechDiv" class="teamWrapper">
                    </div>

                </td>
            </tr>
            <tr>
                <td>
                    <h4 id="alumni">Alumni</h4>
                    <hr />
                    <div id="alumniDiv" class="teamWrapper">
                        <div class="personal-wrapper" id="Div1">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <a target="_blank" href="http://shailjathakur.wordpress.com/" class="nameWrapper">Shailja Thakur</a><br />
                                        <label class="namePosition">Alumni (M.Tech)</label><br />
                                        <label class="below-info">
                                            CSE(MUC),IIIT Delhi
                                        </label>
                                        <br />
                                        <br />
                                        <label class="description">
                                            <p class="reHead">Research Interests -</p>
                                            Indoor Occupancy,
                                            Java Applications, Data Analysis
                                            <br />
                                            <br />
                                        </label>
                                        <label class="below-info">
                                            Email - shailja1275 [at] iiitd [dot] ac [dot] in                
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="personal-wrapper" id="Div24">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <a target="_blank" href="#" class="nameWrapper">Deepika Chabra</a><br />
                                        <label class="namePosition">Alumni (M.Tech)</label><br />
                                        <label class="below-info">
                                            CSE(MUC),IIIT Delhi
                                        </label>
                                        <br />
                                        <br />
                                        <label class="description">
                                            <p class="reHead">Research Interests -</p>
                                            Human Computer Interaction, Data Analysis
                                            <br />
                                            <br />
                                        </label>
                                        <label class="below-info">
                                            Email - Deepika1264 [at] iiitd [dot] ac [dot] in                
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="personal-wrapper" id="Div9">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <label class="nameWrapper">Prateek Malhotra</label><br />
                                        <label class="namePosition">Alumni (B.Tech)</label><br />
                                        <label class="below-info">
                                            CSE - IIIT Delhi<br />
                                        </label>
                                        <br />
                                        <label class="description">
                                            <p class="reHead">Research Interests -</p>
                                            Backend Development and Deployment
                                            <br />
                                            <br />
                                        </label>
                                        <label class="below-info">
                                            Email -  prateek11077 [at] iiitd [dot] ac [dot] in              
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="personal-wrapper" style="margin-top: 10px;" id="Div10">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <label class="nameWrapper">Vinayak Shukl</label><br />
                                        <label class="namePosition">Alumni (B.Tech)</label><br />
                                        <label class="below-info">
                                            CSE - IIIT Delhi<br />
                                        </label>
                                        <br />
                                        <label class="description">
                                            <p class="reHead">Research Interests -</p>
                                            Backend Development and Deployment
                                            <br />
                                            <br />
                                        </label>
                                        <label class="below-info">
                                            Email -  vinayak11118 [at] iiitd [dot] ac [dot] in   
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="personal-wrapper" style="margin-top: 10px;" id="Div11">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <label class="nameWrapper">Romil Bhardwaj</label><br />
                                        <label class="namePosition">Alumni (B.Tech)</label><br />
                                        <label class="below-info">
                                            CSE - IIIT Delhi<br />
                                            <br />
                                        </label>
                                        <label class="description">
                                            <p class="reHead">Research Interests -</p>
                                            Backend Development and Deployment
                                            <br />
                                        </label>
                                        <br />
                                        <label class="below-info">
                                            Email -  romil11092 [at] iiitd [dot] ac [dot] in
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <h4 id="ucla">UCLA</h4>
                    <hr />
                    <div id="Div12" class="teamWrapper">
                        <div class="personal-wrapper" id="Div13">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <a target="_blank" href="http://nesl.ee.ucla.edu/people/mbs/" class="nameWrapper">Mani B Srivastava</a><br />
                                        <label class="namePosition">Professor and Area Director</label><br />
                                        <label class="below-info">
                                            EE Department, UCLA<br />
                                        </label>
                                        <br />
                                        <label class="description">
                                            <p class="reHead">Research Interests -</p>
                                            Low-power & energy-aware embedded systems, 
                                            Wireless sensor & actuator networks, 
                                            Mobile & wireless computing, Pervasive computing              
                                        </label>
                                        <br />
                                        <label class="below-info">
                                            Email - mbs [at] ucla [dot] edu
                                        </label>

                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="personal-wrapper" id="Div17">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <a target="_blank" href="http://www.ioe.ucla.edu/delmas" class="nameWrapper">Magali Delmas</a><br />
                                        <label class="namePosition">Professor of Management</label><br />
                                        <label class="below-info">
                                            UCLA<br />
                                        </label>
                                        <br />
                                        <label class="description">
                                            <p class="reHead">Research Interests -</p>
                                            Energy Conservation and Efficiency, Eco-labels, Environmental and Corporate Performance
                                            Socially Responsible Investing
                                            <br />
                                        </label>
                                        <label class="below-info">
                                            Email - delmas [at] ioe [dot] ucla [dot] edu         
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <div class="personal-wrapper" id="Div14">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <a target="_blank" href="http://nesl.ee.ucla.edu/person/show/264" class="nameWrapper">Haksoo Choi</a><br />
                                        <label class="namePosition">Graduate Student Researcher</label><br />
                                        <label class="below-info">
                                            Networked Embedded Systems Lab, UCLA<br />
                                        </label>
                                        <br />
                                        <label class="description">
                                            <p class="reHead">Research Interests -</p>
                                            Networked Embedded Systems, Sensor Data Privacy, Operating Systems, Database Systems, Machine Learning
                                            <br />
                                        </label>
                                        <label class="below-info">
                                            Email - haksoo [at] cs [dot] ucla [dot] edu             
                                        </label>

                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="personal-wrapper" style="margin-top: 10px;" id="Div15">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <label class="nameWrapper">Victor Chen</label><br />
                                        <label class="namePosition">Ph.D Student </label>
                                        <br />
                                        <label class="below-info">
                                            EE Department, UCLA<br />
                                        </label>
                                        <label class="description">
                                            <br />
                                        </label>
                                        <label class="below-info">
                                            Email - victor.l.chen [at] gmail [dot] com
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <h4 id="ibm">IBM Research</h4>
                    <hr />
                    <div id="Div16" class="teamWrapper">
                        <div class="personal-wrapper" id="Div18">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <a target="_blank" href="http://researcher.watson.ibm.com/researcher/view.php?person=in-zainulcharbiwala" class="nameWrapper">Zainul M Charbiwala</a><br />
                                        <label class="namePosition">Researcher</label><br />
                                        <label class="below-info">
                                            IBM Research, India<br />
                                        </label>
                                        <br />
                                        <label class="description">
                                            <p class="reHead">Research Interests -</p>
                                            Electrical Engineering, 
                                            Communications & Networking, 
                                            Mobile Computing, 
                                            Signal Processing
                                                        <br />
                                        </label>
                                        <label class="below-info">
                                            Email - zainulcharbiwalaat [at] in [dot] ibm [dot] com
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="personal-wrapper" id="Div19">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <a href="http://alumni.media.mit.edu/~deva/" target="_blank" class="nameWrapper">Deva P. Seetharam</a><br />
                                        <label class="namePosition"></label>
                                        <br />
                                        <label class="below-info">
                                            IBM Research<br />
                                        </label>
                                        <label class="description">
                                            <br />
                                        </label>
                                        <label class="below-info">
                                            Email - dseetharamat[at] in [dot] ibm [dot] com              
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <h4 id="ccls">CCLS Columbia</h4>
                    <hr />
                    <div id="Div20" class="teamWrapper">
                        <div class="personal-wrapper" id="Div21">
                            <table>

                                <tr>
                                    <td class="infoWrapper">
                                        <a href="http://www1.ccls.columbia.edu/~dutta/" target="_blank" class="nameWrapper">Haimonti Dutta</a><br />
                                        <label class="namePosition">Associate Research Scientist</label><br />
                                        <label class="below-info">
                                            CCLS, Columbia<br />
                                        </label>
                                        <label class="description">
                                            <p class="reHead">Research Interests -</p>
                                            Data Mining, Machine Learning and Pattern Recognition,
                                            Distributed Optimization,
                                            Distributed and Parallel Machine Learning,
                                            Mining Big Data,
                                            Data Intensive Computing
                                            <br />
                                        </label>
                                        <label class="below-info">
                                            Email - haimonti [at] ccls [dot] columbia [dot] edu
                                        </label>

                                    </td>
                                </tr>

                            </table>
                        </div>
                    </div>

                </td>
            </tr>

            <tr>
                <td>
                    <h4 id="cmu">CMU</h4>
                    <hr />
                    <div id="Div22" class="teamWrapper">
                        <div class="personal-wrapper" id="Div23">
                            <table>
                                <tr>
                                    <td class="infoWrapper">
                                        <a href="http://www.cs.cmu.edu/~yuvraja/" target="_blank" class="nameWrapper">Yuvraj Agarwal</a><br />
                                        <label class="namePosition">Assistant Professor </label>
                                        <br />
                                        <label class="below-info">
                                            CMU<br />
                                        </label>
                                        <br />
                                        <label class="description">
                                            <p class="reHead">Research Interests -</p>
                                            Smart Buildings, Energy Efficient and Resilient Computer Systems, Mobile Computing             
                                        </label>
                                        <label class="below-info">
                                            <br />
                                            Email - yuvraj [at] cs [dot] ucsd [dot] edu
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <script type="text/jscript">
        jQuery(document).ready(function ($) {

            $('.lnk').click(function () {
                var namer = $(this).attr('name');
                $('html, body').animate({
                    scrollTop: $('#' + namer).offset().top - 150
                }, 700);
                $('.sideLine').animate({ top: -10 }, 500, function () { });
            });
            $(window).scroll(function () {
                if ($(window).scrollTop() == 0) {
                    $('.sideLine').animate({ top: 40 }, 100, function () { });
                }
                else if ($(window).scrollTop() > 10) {
                    $('.sideLine').animate({ top: -10 }, 100, function () { });
                }
            });
        });
    </script>
</asp:Content>

