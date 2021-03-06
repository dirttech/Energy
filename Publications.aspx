﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Publications.aspx.cs" Inherits="Publications" %>

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

        h4
        {
            line-height: normal;
            padding-left: 10px;
            color: white;
            background-color: black;
            opacity: 0.5;
        }

        li#publ
        {
            background-color: skyblue;
        }

        .publ > li
        {
            font-size: medium;
            font-weight: normal;
            margin-top: 10px;
        }

        li > publ
        {
            font-weight: bolder;
        }

        .abstract
        {
            display: block;
            font-size: medium;
            color: black;
            background-color: lightgray;
            padding: 5px;
            margin-top: 5px;
            opacity: 0.95;
            display: none;
            border: 1px none gray;
        }

        b
        {
            font-weight: normal;
        }
        .sideLine
        {
            top: 40px;
            z-index: 100;
            position: fixed;
            width: 100%;
            background-color: whitesmoke;
            height: 30px;
            margin-top: 5px;
            padding: 10px;
        }
            .sideLine > a
            {
                color: navy;
                line-height: 30px;
                padding-left: 100px;
            }

        .ul
        {
            margin: 0px;
            padding-left: 120px;
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
                    font-size: large;
                }
                    .ul > li > a:hover
                    {
                        text-decoration: underline;
                        cursor: pointer;
                    }

        .teamWrapper
        {
            position: relative;
            left: 80px;
            max-width: 1000px;
            margin-left: 50px;
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
            var id = "";
            $('.abstractLink').click(function () {
                id = $(this).attr("val");
                $('#' + id).slideToggle('slow', function () { });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    &nbsp;<br />
    <br />
    <div class="sideLine">
        <ul class="ul">
            <li><a onclick="scrollTo('2014')" name="2014" class="lnk">2014</a></li>
            <li><a onclick="scrollTo('2013')" name="2013" class="lnk">2013</a></li>
            <li><a onclick="scrollTo('2012')" name="2012" class="lnk">2012</a></li>
        </ul>
    </div>
    <div class="teamWrapper">
        <br />
        <h3>Publications</h3>
        <h4 id="2014">2014</h4>
        <ul class="publ 2014">
            <li><b>Shailja Thakur</b>, Manaswi Saha, Amarjeet Singh, Yuvraj Agarwal, 
               <publ>WattShare: Detailed Energy Apportionment in Shared Living Spaces within Commercial Buildings</publ>
                ,To appear in First ACM International Conference on Embedded Systems for Energy-Efficient Buildings (BuildSys). Memphis, TN, USA, November 2014        
        <a val="watts" class="abstractLink">[Abstract]</a>
                <a href="https://dl.dropboxusercontent.com/u/95976723/papers/wattshare_buildsys14.pdf"
                    style="color: #6666FF;" target="_blank">[Download Link]</a><br />
                <label class="abstract" id="watts">
                    Increasing energy consumption of commercial buildings has motivated numerous energy tracking and monitoring sys- tems in the recent years. 
                A particular area that is less explored in this domain is that of energy apportionment whereby total energy usage of a shared space such as a build- ing is disaggregated
                 to attribute it to an individual occupant. This particular scenario of individual apportionment is im- portant for increased transparency in the actual energy 
                con- sumption of shared living spaces in commercial buildings e.g. hotels, student dormitories and hospitals amongst oth- ers. Accurate energy accounting is a 
                difﬁcult problem to solve using only a single smart meter. In this paper, we present a novel, scalable and a low cost energy apportion- ment system called 
                WattShare that builds upon our Ener- gyLens architecture, where data from a common electricity meter and smartphones (carried by the occupants) is fused, 
                and then used for detailed energy disaggregation. This infor- mation is then used to measure the room-level energy con- sumption. We evaluate WattShare 
                using a week long deploy- ment conducted in a student dormitory in a campus in India. We show that WattShare is able to disaggregate the total en- ergy 
                usage from a single smart meter to individual rooms with an average precision of 96.42% and average recall of 94.96%. WattShare achieves 86.42% energy 
                apportionment accuracy which increases to 94.57% when an outlier room is removed. 
                </label>
            </li>
            <li><b>Jack Kelly</b>, Nipun Batra, Oliver Parson, Haimonti Dutta, William Knottenbelt, Alex Rogers, Amarjeet Singh, Mani Srivastava,
               <publ>NILMTK v0.2: A Non-intrusive Load Monitoring Toolkit for Large Scale Data Sets</publ>
                , to appear as demo paper at the 1st ACM International Conference on Embedded Systems For Energy-Efficient Buildings (BuildSys' 2014), to be held in Memphis, USA on 5-6 November, 2014.    
        <a val="nimltk2" class="abstractLink">[Abstract]</a>
                <a href=""
                    style="color: #6666FF;" target="_blank">[Download Link]</a><br />
                <label class="abstract" id="nimltk2">
                </label>
            </li>
            <li><b>Nipun Batra</b>, Manoj Gulati, Puneet Jain, Kamin Whitehouse, Amarjeet Singh, 
               <publ>Bits and Watts: Improving energy disaggregation performance using power line communication modems</publ>
                , to appear as poster paper at the 1st ACM International Conference on Embedded Systems For Energy-Efficient Buildings (BuildSys' 2014), to be held in Memphis, USA on 5-6 November, 2014.    
        <a val="bits_watts" class="abstractLink">[Abstract]</a>
                <a href=""
                    style="color: #6666FF;" target="_blank">[Download Link]</a><br />
                <label class="abstract" id="bits_watts">
                </label>
            </li>
            <li><b>Manoj Gulati</b>, Shobha Sundar Ram, Amarjeet Singh,
               <publ>An In Depth Study into Using EMI Signatures for Appliance Identification</publ>
                , to appear as full paper at the 1st ACM International Conference on Embedded Systems For Energy-Efficient Buildings (BuildSys' 2014), to be held in Memphis, USA on 5-6 November, 2014.
        <a val="emi_signatures" class="abstractLink">[Abstract]</a>
                <a href="https://www.dropbox.com/s/5hgzgcwk9c67bc7/BuildSys14_Draft_CR_ver1.10_MG_Final.pdf?dl=0"
                    style="color: #6666FF;" target="_blank">[Download Link]</a><br />
                <label class="abstract" id="emi_signatures">
                    Energy conservation is a key factor towards long term energy sustainability. Real-time end user energy feedback, using disaggregated electric load composition, can play a pivotal role in motivating consumers towards energy conservation. Recent works have explored using high frequency conducted electromagnetic interference (EMI) on power lines as a single point sensing parameter for monitoring common home appliances. However, key questions regarding the reliability and feasibility of using EMI signatures for non-intrusive load monitoring over multiple appliances across different sensing paradigms remain unanswered. This work presents some of the key challenges towards using EMI as a unique and time invariant feature for load disaggregation. In-depth empirical evaluations of a large number of appliances in different sensing configurations are carried out, in both laboratory and real world settings. Insights into the effects of external parameters such as line impedance, background noise and appliance coupling on the EMI behavior of an appliance are realized through simulations and measurements. A generic approach for simulating the EMI behavior of an appliance that can then be used to do a detailed analysis of real world phenomenology is presented. The simulation approach is validated with EMI data from a router. Our EMI dataset - High Frequency EMI Dataset (HFED) is also released. 
                </label>
            </li>
            <li><b>Shailja Thakur</b>, Thesis committee - Amarjeet Singh (Chair), Pushpendra Singh, Zainul M Charbiwala 
               <publ>WattShare: Detailed Energy Apportionment in Shared Living Spaces within Commercial Buildings</publ>
                , IIIT Delhi
        <a val="wattshare" class="abstractLink">[Abstract]</a>
                <a href="https://drive.google.com/file/d/0B5SRRTp1j_lGd1V0V0hrMDE2YUU2SW5HUFRUb01adlJ5UmFN/view?usp=sharing"
                    style="color: #6666FF;" target="_blank">[Download Link]</a><br />
                <label class="abstract" id="wattshare">
                    Increasing energy consumption of commercial buildings has motivated numerous energy tracking and monitoring systems in the recent years. A particular area that is less explored in this domain
                is that of energy apportionment whereby total energy usage of a shared space such as a building is disaggregated to attribute it to an individual occupant. This particular scenario of individual
                apportionment is important for increased transparency in the actual energy consumption of shared living spaces in commercial buildings e.g. hotels, student dormitories and hospitals
                amongst others. Accurate energy accounting is a difficult problem to solve using only a single smart meter. In this paper, we present a novel, scalable and a low cost energy apportionment
                system called WattShare that builds upon our EnergyLens architecture, where data from a common electricity meter and smartphones (carried by the occupants) is fused, and then used
                for detailed energy disaggregation. This information is then used to measure the room-level energy consumption. We evaluate WattShare using a week long deployment conducted in a
                student dormitory in a campus in India. We show that WattShare is able to disaggregate the total energy usage from a single smart meter to individual rooms with an average precision
                of 96.42% and average recall of 94.96%. WattShare achieves 86.42% energy apportionment accuracy which increases to 94.57% when an outlier room is removed.
                </label>
            </li>
            <li><b>Manaswi Saha</b>, Shailja Thakur, Amarjeet Singh, Yuvraj Agarwal, 
               <publ>EnergyLens: Combining Smartphones with Electricity Meter for Accurate Activity Detection and User Annotation</publ>
                ,  In Proceedings of the Fifth International Conference on Future Energy Systems (ACM e-Energy), 2014. 
        <a val="energyLens" class="abstractLink">[Abstract]</a>
                <a href="https://dl.dropboxusercontent.com/u/95976723/papers/energylens_eenergy14.pdf"
                    style="color: #6666FF;" target="_blank">[Download Link]</a><br />
                <label class="abstract" id="energyLens">
                    Inferring human activity is of interest for various ubiquitous computing applications, particularly if it can be done using ambient information that can be collected non intrusively. In this paper, we explore human activity inference, in the context of energy consumption within a home, where we define an "activity" as the usage of an electrical appliance, its usage duration and its location. We also explore the dimension of identifying the occupant who performed the activity. Our goal is to answer questions such as "Who is watching TV in the Dining Room and during what times?". This information is particularly important for scenarios such as the apportionment of energy use to individuals in shared settings for better understanding of occupant's energy consumption behavioral patterns. Unfortunately, accurate activity inference in realistic settings is challenging, especially when considering ease of deployment. One of the key differences between our work and prior research in this space is that we seek to combine readily available sensor data (i.e. home level electricity meters and sensors on smartphones carried by the occupants) and metadata information (e.g. appliance power ratings and their location) for activity inference.
                <br />
                    Our proposed EnergyLens system intelligently fuses electricity meter data with sensors on commodity smartphones -- the WiFi radio and the microphone -- to infer, with high accuracy, which appliance is being used, when its being used, where its being used in the home, and who is using it. EnergyLens exploits easily available metadata to further improve the detection accuracy. Real world experiments show that EnergyLens significantly improves the inference of energy usage activities (average precision= 75.2%, average recall= 77.8%) as compared to traditional approaches that use the meter data only (average precision = 28.4%, average recall = 22.3%).
                </label>
            </li>
            <li><b>Nipun Batra</b>, Amarjeet Singh, Pushpendra Singh, Haimonti Dutta, Venkatesh Sarangan, Mani Srivastava. 
               <publ>Data Driven Energy Efficiency in Buildings PhD. qualifiers report</publ>
                , IIIT Delhi
        <a val="arxiv" class="abstractLink">[Abstract]</a>
                <a href="http://arxiv.org/pdf/1404.7227v2.pdf"
                    style="color: #6666FF;" target="_blank">[Download Link]</a><br />
                <label class="abstract" id="arxiv">
                    Buildings across the world contribute significantly to the overall energy consumption and are thus stakeholders in grid operations. Towards the development of a smart grid, utilities and governments across the world are encouraging smart meter deployments. High resolution (often at every 15 minutes) data from these smart meters can be used to understand and optimize energy consumptions in buildings. In addition to smart meters, buildings are also increasingly managed with Building Management Systems (BMS) which control different sub-systems such as lighting and heating, ventilation, and air conditioning (HVAC). With the advent of these smart meters, increased usage of BMS and easy availability and widespread installation of ambient sensors, there is a deluge of building energy data. This data has been leveraged for a variety of applications such as demand response, appliance fault detection and optimizing HVAC schedules. Beyond the traditional use of such data sets, they can be put to effective use towards making buildings smarter and hence driving every possible bit of energy efficiency. Effective use of this data entails several critical areas from sensing to decision making and participatory involvement of occupants. Picking from wide literature in building energy efficiency, we identify five crust areas (also referred to as 5 Is) for realizing data driven energy efficiency in buildings : i) instrument optimally; ii) interconnect sub-systems; iii) inferred decision making; iv) involve occupants and v) intelligent operations. We classify prior work as per these 5 Is and dis-cuss challenges, opportunities and applications across them. Building upon these 5 Is we discuss a well studied problem in building energy efficiency -non-intrusive load monitoring (NILM) and how research in this area spans across the 5 Is.</label>
            </li>
            <li><b>Milan Jain</b>, Thesis committee - Amarjeet Singh (Chair), Pushpendra Singh, Zainul M Charbiwala 
               <publ>PACMAN : Predicting AC Consumption Minimizing Aggregate eNergy Consumption M.tech thesis report</publ>
                , IIIT Delhi
        <a val="pacman" class="abstractLink">[Abstract]</a>
                <a href="https://drive.google.com/file/d/0B5SRRTp1j_lGUkN6aUN0TlJ0b3RoZ21BdUlueXRUcmtkdHpj/edit?usp=sharing"
                    style="color: #6666FF;" target="_blank">[Download Link]</a><br />
                <label class="abstract" id="pacman">
                    Buildings account for a significant proportion of overall energy consumption across the world. Heating Ventilation and Air Conditioning (HVAC) typically consumes a major proportion (e.g. 32% in India) of the total building energy consumption. While centralized HVAC systems
are more prevalent in developed countries, separate room level Air Conditioners (ACs) are a commonplace in developing countries, such as India. Poor building insulation in developing countries, together with an option to easily control room level air conditioning, presents a
major opportunity for energy conservation in these countries. We propose PACMAN - a novel approach for predicting the energy consumption of room level AC. PACMAN involves learning a thermal model of the room from historical usage and combines this model with the weather
forecast for user’s location to guide the user towards optimized AC settings in order to balance user comfort and energy efficiency. Empirical validation was performed using a real world study, conducted across 7 homes in India, with collective data for a duration of 2200 hours in
total. PACMAN achieved more than 90% accuracy in predicting the energy consumption across different ACs, room types and set temperatures used during the data collection. We further describe a prototype realization of the proposed PACMAN system towards achieving reduced AC energy consumption with better feedback and control.
                </label>
            </li>
            <li><b>Nipun Batra</b>, Jack Kelly, Oliver Parson, Haimonti Dutta, William Knottenbelt, Alex Rogers, Amarjeet Singh, Mani Srivastava. 
             <publ>NILMTK: An Open Source Toolkit for Non-intrusive Load Monitoring.</publ>
                In: 5th International Conference on Future Energy Systems (ACM e-Energy), Cambridge, UK. 2014 
        <a val="nilmtk" class="abstractLink">[Abstract]</a>
                <a href="http://arxiv.org/pdf/1404.3878v1.pdf"
                    style="color: #6666FF;" target="_blank">[Download Link]</a><br />
                <label class="abstract" id="nilmtk">
                    Non-intrusive load monitoring, or energy disaggregation, aims to separate household energy consumption data collected from a single point of measurement into appliance-level consumption data. In recent years, the field has rapidly expanded due to increased interest as national deployments of smart meters have begun in many countries. However, empirically comparing disaggregation algorithms is currently virtually impossible. This is due to the different data sets used, the lack of reference implementations of these algorithms and the variety of accuracy metrics employed. To address this challenge, we present the Non-intrusive Load Monitoring Toolkit (NILMTK); an open source toolkit designed specifically to enable the comparison of energy disaggregation algorithms in a reproducible manner. This work is the first research to compare multiple disaggregation approaches across multiple publicly available data sets. Our toolkit includes parsers for a range of existing data sets, a collection of preprocessing algorithms, a set of statistics for describing data sets, two reference benchmark disaggregation algorithms and a suite of accuracy metrics. We demonstrate the range of reproducible analyses which are made possible by our toolkit, including the analysis of six publicly available data sets and the evaluation of both benchmark disaggregation algorithms across such data sets.
                </label>
            </li>
            <li><b>Mohit Jain</b>, Deepika Chabra, Jennifer Mankoff, Amarjeet Singh. 
            <publ>Energy Usage Attitudes of Urban India.</publ>
                In: ICT4S-2014 
        <a val="ict4s" class="abstractLink">[Abstract]</a>
                <a href="https://www.iiitd.edu.in/~amarjeet/Papers/ICT4S-2014-IndiaSurvey.pdf"
                    style="color: #6666FF;" target="_blank">[Download Link]</a><br />
                <label class="abstract" id="ict4s">
                    Though rapid increase in energy consumption has become a global problem, most of the solutions developed to address it for residential consumers are based on qualitative 
studies conducted with small numbers of users, typically in the developed world. Recent work has begun to explore consumption practices, and motivations, barriers and other factors affecting 
energy consumption in urban India. However, the small numbers of participants in those studies limit their generality. Our work contributes to this picture through a survey of 1724 residents of 
urban India, exploring the motivations and barriers affecting energy conservation and their opinions about sharing energy consumption data and future technologies for conservation. We 
found that urban Indians practice conservation because it is a learned habit and to save money, while comfort and convenience are the major barriers in conserving energy. Contrary to 
previous findings, we did not find a major influence of tradition, spirituality or moral reasons for conservation. Moreover, participants have minimal privacy concerns regarding sharing 
energy data. Interestingly, participants were not only interested in energy monitoring solutions, but were also positive about automated energy controlling systems, which contrasts previous 
findings. We conclude with design opportunities for this demographic such as information-sharing opportunities, appliance level consumption disaggregation, and convenient 
manual controls.</label>
            </li>
        </ul>
        <h4 id="2013">2013</h4>
        <ul class="publ 2013">
            <li><b>Nipun Batra</b>, Haimonti Dutta, Amarjeet Singh, 
             <publ>INDiC: Improved Non-Intrusive load monitoring using load Division and Calibration</publ>
                , to appear at the 12th International Conference on Machine Learning and Applications (ICMLA’13) will be held in Miami, Florida, USA, December 4 – December 7, 2013
                <a val="loadDiv" class="abstractLink">[Abstract]</a>
                <a href="http://nipunbatra.files.wordpress.com/2013/09/icmla.pdf"
                    style="color: #6666FF;" target="_blank">[Download Link]</a><br />
                <label class="abstract" id="loadDiv">
                    Residential buildings contribute signiﬁcantly to the overall energy consumption across most parts of the world. While smart monitoring and control of appliances can reduce the overall
energy consumption, management and cost associated with such systems act as a big hindrance. Prior work has established that detailed feedback in the form of appliance level consumption
to building occupants improves their awareness and paves the way for reduction in electricity consumption. Non-Intrusive Load Monitoring (NILM), i.e. the process of disaggregating
the overall home electricity usage measured at the meter level into constituent appliances, provides a simple and cost effective methodology to provide such feedback to the occupants. In this
paper we present Improved Non-Intrusive load monitoring using load Division and Calibration (INDiC) that simpliﬁes NILM by dividing the appliances across multiple instrumented points
(meters/phases) and calibrating the measured power. Proposed approach is used together with the Combinatorial Optimization framework and evaluated on the popular REDD dataset. Empirical evaluation, using INDiC based Combinatorial Optimization,
demonstrate signiﬁcant improvement in disaggregation accuracy.
                </label>
            </li>
            <li><b>Nipun Batra</b>, Manoj Gulati, Amarjeet Singh, Mani Srivastava, 
            <publ>It’s Different: Insights into home energy consumption in India</publ>
                to appear at the 5th ACM Workshop On Embedded Systems For Energy-Efficient Buildings, will be held in Rome, Italy, November 13-14, 2013
                <a val="itsDiff" class="abstractLink">[Abstract]</a>
                <a href="http://manojgulati.files.wordpress.com/2013/09/buildsys.pdf"
                    style="color: #6666FF;" target="_blank">[Download Link]</a><br />
                <label class="abstract" id="itsDiff">
                    Residential buildings contribute signiﬁcantly to the overall energy usage across the world. Real deployments, and collected data thereof, play a critical role in providing insights into home energy consumption and occupant behavior.
Existing datasets from real residential deployments are all from the developed countries. Developing countries, such as India, present unique opportunities to evaluate the scalability
of existing research in diverse settings. Building upon more than a year of experience in sensor network deployments, we undertake an extensive deployment in a three storey home in
Delhi, spanning 73 days from May-August 2013, measuring electrical, water and ambient parameters. We used 33 sensors across the home, measuring these parameters, collecting
a total of approx. 400 MB of data daily. We discuss the architectural implications on the deployment systems that can be used for monitoring and control in the context of developing
countries. Addressing the unreliability of electrical grid and internet in such settings, we present Sense Local-store Upload architecture for robust data collection. While providing several unique aspects, our deployment further validates
the common considerations from similar residential deployments, discussed previously in the literature.
                </label>
            </li>
            <li><b>Pandarasamy Arjunan</b>, Manaswi Saha, Manoj Gulati, Nipun Batra, Amarjeet Singh, Pushpendra Singh, 
        <publ>SensorAct: Design and Implementation of Fine-grained Sensing and Control Sharing in Buildings</publ>
                , to appear as Poster at  10th USENIX Symposium on Networked Systems Design and Implementation (NSDI ’13), 2013.    
            </li>
            <li><b>Nipun Batra</b>, Pandarasamy Arjunan, Amarjeet Singh, Pushpendra Singh.
                <publ>Experiences with Occupancy Based Building
Management Systems.</publ>
                In ISSNIP, Australia, 2013
                <a val="issnipAbs" class="abstractLink">[Abstract]</a>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"
                    ForeColor="#6666FF">[Download Link]</asp:LinkButton><br />
                <label class="abstract" id="issnipAbs">
                    Buildings are one of the largest consumers of electricity. Dominant electricity consumption within the buildings, contributed by plug loads, lighting and air conditioning, can be
significantly improved using Occupancy-based Building Management Systems (Ob-BMS). In this paper, we address three critical aspects of Ob-BMS i.e. 1) Modular sensor node design to support
diverse deployment scenarios; 2) Building architecture to support and scale fine resolution monitoring; and 3) Detailed analysis of the collected data for smarter actuation. We present key learning
across these three aspects evolved over more than one year of design and deployment experiences. The sensor node design evolved over a period of time to address specific deployment requirements. With an opportunity
at the host institute where two dorm buildings were getting constructed, we planned for the support infrastructure required for fine resolution monitoring embedded in the design phase
and share our preliminary experiences and key learning thereof. Prototype deployment of the sensing system as per the planned support infrastructure was performed at two faculty offices with
effective data collection worth 45 days. Collected data is analyzed accounting for efficient switching of appliances, in addition to energy conservation and user comfort as performed in the earlier
occupancy based frameworks. Our analysis shows that occupancy prediction using simple heuristic based modeling can achieve similar performance as more complex Hidden Markov Models, thus simplifying the analytic framework.
                </label>
            </li>
        </ul>
        <h4 id="2012">2012</h4>
        <ul class="publ 2012">
            <li><b>Pandarasamy Arjunan</b>, Nipun Batra, Haksoo Choi, Amarjeet Singh, Pushpendra Singh, Mani Srivastava. 
        <publ>SensorAct: A Privacy and Security Aware Federated Middleware for Building Management.</publ>
                In Buildsys, USA, 2012 
       <a val="buildsys" class="abstractLink">[Abstract]</a>
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"
                    ForeColor="#6666FF">[Download Link]</asp:LinkButton><br />
                <label class="abstract" id="buildsys">
                    The archaic centralized software systems, currently used to manage buildings, make it hard to incorporate advances in sensing technology and user-level applications, and present
hurdles for experimental validation of open research in building information technology. Motivated by this, we — a transnational collaboration of researchers engaged in development
and deployment of technologies for sustainable buildings—have developed SensorAct, an open-source federated middleware incorporating features targeting three specific
requirements: (i) Accommodating a richer ecosystem of sensors, actuators, and higher level third-party applications (ii) Participatory engagement of stakeholders other than
the facilities department, such as occupants, in setting policies for management of sensor data and control of electrical systems, without compromising on the overall privacy
and safety, and (iii) Flexible interfacing and information exchange with systems external to a building, such as communication networks, transportation system, electrical grid,
and other buildings, for better management, by exploiting the teleconnections that exist across them. SensorAct is designed to scale from small homes to network of buildings,
making it suitable not only for production use but to also seed a global-scale network of building testbeds with appropriately constrained and policed access. This paper describes
SensorAct’s architecture, current implementation, and preliminary performance results.
                </label>
            </li>
        </ul>
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

