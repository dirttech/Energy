<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <style type="text/css">
     hr
     {
         display:block;
     }
     h3
     {
         color:skyblue;
     }
     li#new
        {
          background-color:skyblue;   
        }
     .abstract
     {
         display:block;
        font-size:small;
        color:Gray;
        display:none;   
        border:1px dotted gray;
        text-align:justify;
     }
     
        .sideLine
        {
             left:0px;
             position:fixed;
             width:170px;
             background-color:offwhite;
             
             height:180px;
             margin-top:5px;
             padding:10px;
             border-radius:0px 12px 12px 0px;  
             box-shadow:  0px 2px  2px 2px #888, 2px 3px 5px 0px #888;
             
        }
        .sideLine>ul>li>a
        {
          color:navy;
          line-height:30px;  
          text-decoration:none; 
        }
        .sideLine>ul>li>a:hover
        {
          
          text-decoration:underline;
          cursor:pointer;   
        }
  
    .teamWrapper
    {
        position:relative;
        left:180px;
      
        max-width:1000px;
        margin-left:50px;
        
    }
    .imgbox
    {
         border:1px solid black;
    }
    .imgContainer
    {
         border:1px solid gray;
          float:left;   
         margin:3px;
         text-align:center;
         padding-top:10px;
         width:220px;
         height:170px;
    }
    .img2container
    {
         
    }
    .c2img
    {
        width:480px;
        height:320px;
    }
    .cimg
    {
        width:200px;
        height:120px;
    }
    .desc2
    {
      font-size:large;
      color:Gray;
      font-weight:normal; 
       padding-left:10px;  
    }
    
    .desc
    {
      font-size:small;
      font-weight:normal;   
    }
    
    .abstractLink
    {
      text-decoration:underline;
      cursor:pointer;
      color:#6666ff;
    }
     
    
    </style>

    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $('.abstractLink').click(function () {

                var id = $(this).attr("val");
                $('#'+id).toggle('slow', function() {
   
                    });
            });

        });

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">&nbsp;<br /><br />

    <div class="sideLine">
  
    
    <a>Whats Happening</a><br />
      <ul >
    <li><a href="#recent">Recent News<a></li>
    <li><a href="#funding">Funding</a></li>
    <li><a href="#publications">Publications</a></li>
    
    </ul>
 
    </div>
    <div class="teamWrapper" id="recent">
    <h3>Recent News</h3>
    <ul>
    <li>More than 120 smart meters installed on IIIT Delhi campus with data being collected from them every 30 seconds.
</li>
<li> Recently completed an extensive home deployment.
<div >
<table  style="border:1px solid black;">
<tr><td class="style1" rowspan="2">
<div class="img2Container" style="border: 1px solid gray;">
<p class="desc2">Schematic showing overall home deployment.</p>
        <img class="c2img" src="images/deployments/overall_deployment1.png"/>
        
</div>
</td>
<td style="display:inline-block;" class="style1">

<span class="imgContainer">
        <img class="cimg" src="images/deployments/ambient_2.png"/>
        <p class="desc"> Sensing environmental parameters & light, temprature, motion.
</p>
</span>
<span class="imgContainer">
        <img class="cimg" src="images/deployments/cc_1.png"/>
        <p class="desc">Current cost CT based monitoring.<br /></p>
</span>


</td>
</tr>
<tr>
<td  class="style1">

<span class="imgContainer">
        <img class="cimg" src="images/deployments/electric_meter_1.png"/>
        <p class="desc">EM6400 Smart Electric Meter</p>
        </span>
        <span class="imgContainer">
        <img class="cimg" src="images/deployments/watermeter.png">
        <p class="desc"> Pulse output water meter</p>
</span>


</td>
</tr>
<tr><td colspan="2" style="text-align:center;"><span class="imgContainer">
        <img class="cimg" src="images/deployments/jplug_2.png"/>
        <p class="desc">Appliance level monitoring using jPlug.</p>
</span>
<span class="imgContainer" style="margin-left:20px;">
        <img class="cimg" src="images/deployments/led.png" />
        <p class="desc">Glowing LEDs in the Night.</p>
</span>
<span class="imgContainer" style="margin-left:20px;">
        <img class="cimg" src="images/deployments/mcb_2.png"/>
        <p class="desc">Split Core CT monitoring circuit level current.</p>
</span>

<span class="imgContainer">
        <img class="cimg" src="images/deployments/rpi_2.png"/>
        <p class="desc">Raspberry Pi collecting pulse outputs from water meter.</p>
</span>
</td></tr>

</table>



</div>
</li>    
<br />
<li>Surveyed more than 1500 households in Delhi for energy consumption behavior in summer 2013.</li>
    </ul>
    <br />
    <hr id="funding"/>
    <br />
    <h3>Funding</h3>
    <ul>
    <li>Pervasive Sensing and Computing Technologies for Energy and Water Sustainability in Buildings, Dr. Amarjeet Singh(PI), Dr. 	Pushpendra Singh & Dr. Vinayak Naik (Co-PI),
 funded by DIT and NSF, 2 years starting April 2012, App. Rs 1,30,00,000
</li>
<li>Time and Presence Based Actuation, Research Project funded by Telecommunication Consultants India Limited (TCIL), completed May 2013, App. Rs 2,00,000</li>
    </ul>

     <br />
    <hr id="publications"/>
    <br />

    <h3>Publications</h3>

    <ul>
    <li>Pandarasamy Arjunan, Manaswi Saha, Manoj Gulati, Nipun Batra, Amarjeet Singh, Pushpendra Singh, “SensorAct: Design and Implementation of Fine-grained Sensing and Control Sharing in Buildings”, to appear as Poster at  10th USENIX Symposium on Networked Systems Design and Implementation (NSDI ’13), 2013.
    
    </li>
    <li>Nipun Batra, Pandarasamy Arjunan, Amarjeet Singh, Pushpendra Singh. Experiences with Occupancy Based Building
Management Systems. ISSNIP, Australia, 2013
<a val="issnipAbs" class="abstractLink">[Abstract]</a>
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
            ForeColor="#6666FF">[Download Link]</asp:LinkButton><br />
            <label class="abstract" id="issnipAbs">
Buildings are one of the largest consumers of electricity.
Dominant electricity consumption within the buildings,
contributed by plug loads, lighting and air conditioning, can be
significantly improved using Occupancy-based Building Management
Systems (Ob-BMS). In this paper, we address three critical
aspects of Ob-BMS i.e. 1) Modular sensor node design to support
diverse deployment scenarios; 2) Building architecture to support
and scale fine resolution monitoring; and 3) Detailed analysis of
the collected data for smarter actuation. We present key learning
across these three aspects evolved over more than one year of
design and deployment experiences.
The sensor node design evolved over a period of time to
address specific deployment requirements. With an opportunity
at the host institute where two dorm buildings were getting
constructed, we planned for the support infrastructure required
for fine resolution monitoring embedded in the design phase
and share our preliminary experiences and key learning thereof.
Prototype deployment of the sensing system as per the planned
support infrastructure was performed at two faculty offices with
effective data collection worth 45 days. Collected data is analyzed
accounting for efficient switching of appliances, in addition to
energy conservation and user comfort as performed in the earlier
occupancy based frameworks. Our analysis shows that occupancy
prediction using simple heuristic based modeling can achieve
similar performance as more complex Hidden Markov Models,
thus simplifying the analytic framework.
</label>
</li>
    <li>Pandarasamy Arjunan, Nipun Batra, Haksoo Choi, Amarjeet Singh, Pushpendra Singh, Mani Srivastava. SensorAct: A Privacy and Security Aware Federated Middleware for Building Management. Buildsys, USA, 2012 
       <a val="buildsys" class="abstractLink">[Abstract]</a>
        <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" 
            ForeColor="#6666FF">[Download Link]</asp:LinkButton><br />
<label class="abstract" id="buildsys">
 
The archaic centralized software systems, currently used
to manage buildings, make it hard to incorporate advances in
sensing technology and user-level applications, and present
hurdles for experimental validation of open research in building
information technology. Motivated by this, we — a
transnational collaboration of researchers engaged in development
and deployment of technologies for sustainable
buildings—have developed SensorAct, an open-source federated
middleware incorporating features targeting three specific
requirements: (i) Accommodating a richer ecosystem
of sensors, actuators, and higher level third-party applications
(ii) Participatory engagement of stakeholders other than
the facilities department, such as occupants, in setting policies
for management of sensor data and control of electrical
systems, without compromising on the overall privacy
and safety, and (iii) Flexible interfacing and information exchange
with systems external to a building, such as communication
networks, transportation system, electrical grid,
and other buildings, for better management, by exploiting
the teleconnections that exist across them. SensorAct is designed
to scale from small homes to network of buildings,
making it suitable not only for production use but to also
seed a global-scale network of building testbeds with appropriately
constrained and policed access. This paper describes
SensorAct’s architecture, current implementation, and preliminary
performance results.
</label>


      
        </li>
    </ul>
    <br />
</div>

</asp:Content>

