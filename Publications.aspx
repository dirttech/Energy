<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Publications.aspx.cs" Inherits="Publications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <style type="text/css">
     hr
     {
         display:block;
     }
    
     li#publ
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
        left:80px;
      
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

    <div class="teamWrapper">
   
    <br />

    <h3>Publications</h3>

    <ul>

           <li>Manaswi Saha, Shailja Thakur, Amarjeet Singh, Yuvraj Agarwal, “EnergyLens: Combining Smartphones with Electricity Meter for Accurate Activity Detection and User Annotation“,  In Proceedings of the Fifth International Conference on Future Energy Systems (ACM e-Energy), 2014. 
        <a val="energyLens" class="abstractLink">[Abstract]</a>
        <a href="https://dl.dropboxusercontent.com/u/95976723/papers/energylens_eenergy14.pdf"
           style="color:#6666FF;" target="_blank">[Download Link]</a><br />
            <label class="abstract" id="energyLens">
         Inferring human activity is of interest for various ubiquitous computing applications, particularly if it can be done using ambient information that can be collected non intrusively. In this paper, we explore human activity inference, in the context of energy consumption within a home, where we define an "activity" as the usage of an electrical appliance, its usage duration and its location. We also explore the dimension of identifying the occupant who performed the activity. Our goal is to answer questions such as "Who is watching TV in the Dining Room and during what times?". This information is particularly important for scenarios such as the apportionment of energy use to individuals in shared settings for better understanding of occupant's energy consumption behavioral patterns. Unfortunately, accurate activity inference in realistic settings is challenging, especially when considering ease of deployment. One of the key differences between our work and prior research in this space is that we seek to combine readily available sensor data (i.e. home level electricity meters and sensors on smartphones carried by the occupants) and metadata information (e.g. appliance power ratings and their location) for activity inference.
                <br />
Our proposed EnergyLens system intelligently fuses electricity meter data with sensors on commodity smartphones -- the WiFi radio and the microphone -- to infer, with high accuracy, which appliance is being used, when its being used, where its being used in the home, and who is using it. EnergyLens exploits easily available metadata to further improve the detection accuracy. Real world experiments show that EnergyLens significantly improves the inference of energy usage activities (average precision= 75.2%, average recall= 77.8%) as compared to traditional approaches that use the meter data only (average precision = 28.4%, average recall = 22.3%).
                </li>

           <li>Nipun Batra, Amarjeet Singh, Pushpendra Singh, Haimonti Dutta, Venkatesh Sarangan, Mani Srivastava. Data Driven Energy Efficiency in Buildings PhD. qualifiers report, IIIT Delhi
        <a val="arxiv" class="abstractLink">[Abstract]</a>
        <a href="http://arxiv.org/pdf/1404.7227v2.pdf"
           style="color:#6666FF;" target="_blank">[Download Link]</a><br />
            <label class="abstract" id="arxiv">
          Buildings across the world contribute significantly to the overall energy consumption and are thus stakeholders in grid operations. Towards the development of a smart grid, utilities and governments across the world are encouraging smart meter deployments. High resolution (often at every 15 minutes) data from these smart meters can be used to understand and optimize energy consumptions in buildings. In addition to smart meters, buildings are also increasingly managed with Building Management Systems (BMS) which control different sub-systems such as lighting and heating, ventilation, and air conditioning (HVAC). With the advent of these smart meters, increased usage of BMS and easy availability and widespread installation of ambient sensors, there is a deluge of building energy data. This data has been leveraged for a variety of applications such as demand response, appliance fault detection and optimizing HVAC schedules. Beyond the traditional use of such data sets, they can be put to effective use towards making buildings smarter and hence driving every possible bit of energy efficiency. Effective use of this data entails several critical areas from sensing to decision making and participatory involvement of occupants. Picking from wide literature in building energy efficiency, we identify five crust areas (also referred to as 5 Is) for realizing data driven energy efficiency in buildings : i) instrument optimally; ii) interconnect sub-systems; iii) inferred decision making; iv) involve occupants and v) intelligent operations. We classify prior work as per these 5 Is and dis-cuss challenges, opportunities and applications across them. Building upon these 5 Is we discuss a well studied problem in building energy efficiency -non-intrusive load monitoring (NILM) and how research in this area spans across the 5 Is.</label>
</li>


         <li>Nipun Batra, Jack Kelly, Oliver Parson, Haimonti Dutta, William Knottenbelt, Alex Rogers, Amarjeet Singh, Mani Srivastava. NILMTK: An Open Source Toolkit for Non-intrusive Load Monitoring. In: 5th International Conference on Future Energy Systems (ACM e-Energy), Cambridge, UK. 2014 
        <a val="nilmtk" class="abstractLink">[Abstract]</a>
        <a href="http://arxiv.org/pdf/1404.3878v1.pdf"
           style="color:#6666FF;" target="_blank">[Download Link]</a><br />
            <label class="abstract" id="nilmtk">
           Non-intrusive load monitoring, or energy disaggregation, aims to separate household energy consumption data collected from a single point of measurement into appliance-level consumption data. In recent years, the field has rapidly expanded due to increased interest as national deployments of smart meters have begun in many countries. However, empirically comparing disaggregation algorithms is currently virtually impossible. This is due to the different data sets used, the lack of reference implementations of these algorithms and the variety of accuracy metrics employed. To address this challenge, we present the Non-intrusive Load Monitoring Toolkit (NILMTK); an open source toolkit designed specifically to enable the comparison of energy disaggregation algorithms in a reproducible manner. This work is the first research to compare multiple disaggregation approaches across multiple publicly available data sets. Our toolkit includes parsers for a range of existing data sets, a collection of preprocessing algorithms, a set of statistics for describing data sets, two reference benchmark disaggregation algorithms and a suite of accuracy metrics. We demonstrate the range of reproducible analyses which are made possible by our toolkit, including the analysis of six publicly available data sets and the evaluation of both benchmark disaggregation algorithms across such data sets.
</label>
</li>

         <li>Nipun Batra, Haimonti Dutta, Amarjeet Singh, “INDiC: Improved Non-Intrusive load monitoring using load Division and Calibration”, to appear at the 12th International Conference on Machine Learning and Applications (ICMLA’13) will be held in Miami, Florida, USA, December 4 – December 7, 2013
<a val="loadDiv" class="abstractLink">[Abstract]</a>
        <a href="http://nipunbatra.files.wordpress.com/2013/09/icmla.pdf"
           style="color:#6666FF;" target="_blank">[Download Link]</a><br />
            <label class="abstract" id="loadDiv">
            Residential buildings contribute signiﬁcantly to the
overall energy consumption across most parts of the world. While
smart monitoring and control of appliances can reduce the overall
energy consumption, management and cost associated with such
systems act as a big hindrance. Prior work has established that
detailed feedback in the form of appliance level consumption
to building occupants improves their awareness and paves the
way for reduction in electricity consumption. Non-Intrusive
Load Monitoring (NILM), i.e. the process of disaggregating
the overall home electricity usage measured at the meter level
into constituent appliances, provides a simple and cost effective
methodology to provide such feedback to the occupants. In this
paper we present Improved Non-Intrusive load monitoring using
load Division and Calibration (INDiC) that simpliﬁes NILM
by dividing the appliances across multiple instrumented points
(meters/phases) and calibrating the measured power. Proposed
approach is used together with the Combinatorial Optimization
framework and evaluated on the popular REDD dataset. Empirical evaluation, using INDiC based Combinatorial Optimization,
demonstrate signiﬁcant improvement in disaggregation accuracy.
</label>
</li>


        <li>Nipun Batra, Manoj Gulati, Amarjeet Singh, Mani Srivastava, “It’s Different: Insights into home energy consumption in India” to appear at the 5th ACM Workshop On Embedded Systems For Energy-Efficient Buildings, will be held in Rome, Italy, November 13-14, 2013
<a val="itsDiff" class="abstractLink">[Abstract]</a>
        <a href="http://manojgulati.files.wordpress.com/2013/09/buildsys.pdf"
           style="color:#6666FF;" target="_blank">[Download Link]</a><br />
            <label class="abstract" id="itsDiff">
            Residential buildings contribute signiﬁcantly to the overall energy usage across the world. Real deployments, and
collected data thereof, play a critical role in providing insights into home energy consumption and occupant behavior.
Existing datasets from real residential deployments are all
from the developed countries. Developing countries, such as
India, present unique opportunities to evaluate the scalability
of existing research in diverse settings. Building upon more
than a year of experience in sensor network deployments, we
undertake an extensive deployment in a three storey home in
Delhi, spanning 73 days from May-August 2013, measuring
electrical, water and ambient parameters. We used 33 sensors across the home, measuring these parameters, collecting
a total of approx. 400 MB of data daily. We discuss the architectural implications on the deployment systems that can be
used for monitoring and control in the context of developing
countries. Addressing the unreliability of electrical grid and
internet in such settings, we present Sense Local-store Upload architecture for robust data collection. While providing several unique aspects, our deployment further validates
the common considerations from similar residential deployments, discussed previously in the literature.
</label>
</li>

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
   
</div>

</asp:Content>

