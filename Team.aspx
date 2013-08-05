<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Team.aspx.cs" Inherits="Team" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        hr
        {
            display:block;
            position:relative;
            left:280px;
            
        }
        h4
        {
             position:relative;
             left:300px;   
             line-height:normal;
             color:skyblue; 
        }
        .sideLine
        {
             left:0px;
             position:absolute;
             width:240px;
             background-color:Silver;
             height:300px;
             margin-top:5px;
             padding:10px;
        }
        .sideLine>a
        {
          color:navy;
          line-height:30px;   
        }
        .sideLine>ul>li>a:hover
        {
          
          text-decoration:underline;
          cursor:pointer;   
        }
    .personal-wrapper
    {
       -webkit-box-shadow: 2px 2px 0px 0px #CCDCDC;
 	-moz-box-shadow: 2px 2px 0px 0px #CCDCDC;
 	box-shadow: 2px 2x 0px 0px #CCDCDC;
 	width:300px;
 	height:175px;
    border:1px groove gray;
    position:inherit;
 	margin:5px;
 	margin-top:0px;
 	margin-bottom:0px;
     float:left;
    }
    .nameWrapper
    {
        color:#4682B4;
        
         text-align:left;
           
    }
    .below-info
    {
      font-size:small;   
    }
    .teamWrapper
    {
        position:relative;
        left:250px;
        max-width:1000px;
        margin-left:50px;
        
    }
    .personalImage
    {
         height:137px;   
         width:120px; 
    }
    .toHideWrapper
    {
       background-color:#DCDCDC;
       width:300px;
       height:30px;   
       color:#4682B4;
       cursor:pointer;
       text-align:right;
       font-size:medium;
       
    }
    .infoWrapper
    {
         text-align:left;
         vertical-align:top;   
         width:55%;
         height:130px;
         background-color:White;
    }
    .namePosition
    {
        color:Gray;
        font-family:Calibri;
    }
    .hidden-wrapper
    {
        width:300px;
        height:100px;
        display:none;
             
    }
    .description
    {
           font-size:small;
           font-family:arial;
           font-weight:lighter;
    }
    </style>

    <script type="text/jscript">

        function scrollTo(hash) {
            location.hash = "#" + hash;
        }
    </script>
    
<script type="text/javascript">
    jQuery(document).ready(function ($) {
        $('.toHideWrapper').click(function () {

            var container_id = "#" + $(this).parents('.personal-wrapper').attr('id');

            var hidden_id = "#" + $(container_id).find('.hidden-wrapper').attr('id');


//            if ($(hidden_id).css('display') == 'none') {
//                $(container_id).height('310px');

//                $(hidden_id).fadeIn("slow");
//            }
//            else {
    

//                $(hidden_id).hide();
//                $(container_id).height('178px');
//            }
            if ($(hidden_id).css('display') == 'none') {
                $(container_id).animate({ height: '310px' }, 1000);

                $(hidden_id).fadeIn("slow");
            }
            else {


                $(hidden_id).fadeOut("slow");
                $(container_id).animate({ height: '178px' }, 1000);
            }


        });
        //        $('.floatingDivs').mouseout(function () {

        //            $('.floatingDivs').animate({

        //                bottom: '-0px'

        //            }, 300);

        //        });
    });

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <br /><br />

    <div class="sideLine">
  
    
    <a>Our Team</a><br />
      <ul >
    <li><a  onclick="scrollTo('prof')">Faculty</a></li>
    <li><a  onclick="scrollTo('phd')">Ph.D</a></li>
    <li><a  onclick="scrollTo('ra')">Software Engineer / RA</a></li>
    <li><a  onclick="scrollTo('mtech')">M.Tech</a></li>
    <li><a  onclick="scrollTo('btech')">B.Tech</a></li>
    
    </ul>
    <a>Collabrators</a><br />
     <ul >
    <li><a onclick="scrollTo('ucla')">UCLA</a></li>
    <li><a onclick="scrollTo('ibm')">IBM Research</a></li>
    <li><a onclick="scrollTo('ccls')">IIITD-CCLS Joint</a></li>
    <li><a onclick="scrollTo('cmu')">CMU</a></li>
    </ul>
    </div>
    <div>
    <table>
    <tr><td>
    <h4 id="prof">Faculty</h4>
    <hr />
      <div id="profDiv" class="teamWrapper">
     <div class="personal-wrapper"  id="Div7">
            <table>
         
         <tr>
               
                    <td>
                        <img src="images/team-images/amarjeet.jpg" class="personalImage" />
                    </td>   
                    <td class="infoWrapper">
                    <label class="nameWrapper">Amarjeet Singh<label><br /><br />
                    <label class="namePosition">Assistant Professor</label><br />    
                    <label class="below-info">MUC - IIIT Delhi<br />
                  
                    <a href="http://www.iiitd.edu.in/~amarjeet/" target="_blank">iiitd.edu.in/~amarjeet</a>
                    </label>
                    </td>
                </tr>
                <tr class="hidden-wrapper" id="Tr7">
                <td colspan="2" style="border-top:1px groove gray;">
                <label class="description"><br />
               Mobile Sensing, Approximation Algorithms, Environmental Monitoring, Low Cost Technologies <br /><br />
                
                </label>
                <label class="below-info">
                Email -  amarjeet@iiitd.ac.in<br />

               <br /><br />
                <br />  
                </label>
                
                </td>
                </tr>
                   <tr><td colspan="2" class="toHideWrapper">More Info</td></tr>
              
                </table>
                </div>

                
     <div class="personal-wrapper"  id="Div8">
            <table>
         
         <tr>
               
                    <td>
                        <img src="images/team-images/psingh.jpg" class="personalImage" />
                    </td>   
                    <td class="infoWrapper">
                    <label class="nameWrapper">Pushpendra Singh<label><br /><br />
                    <label class="namePosition">Assistant Professor</label><br />    
                    <label class="below-info">MUC - IIIT Delhi<br />
                  
                    <a href="http://www.iiitd.edu.in/~pushpendra/" target="_blank">iiitd.edu.in/~pushpendra</a>
                    </label>
                    </td>
                </tr>
                <tr class="hidden-wrapper" id="Tr8">
                <td colspan="2" style="border-top:1px groove gray;">
                <label class="description"><br />
              Middleware, Mobile Computing<br /><br />
                </label>
                <label class="below-info">
                Email -  psingh@iiitd.ac.in<br />

               <br /><br />
                <br /><br />
                </label>
                
                </td>
                </tr>
                   <tr><td colspan="2" class="toHideWrapper">More Info</td></tr>
              
                </table>
                </div>

          
       </div>
    </td></tr>
    <tr><td>
    <h4 id="phd">Ph.D</h4>
    <hr />
     <div id="phdDiv" class="teamWrapper">

          <div class="personal-wrapper"  id="Div4">
            <table>
         
         <tr>
               
                    <td>
                        <img src="images/team-images/samy.png" class="personalImage" />
                    </td>   
                    <td class="infoWrapper">
                    <label class="nameWrapper">Pandarasamy Arjunan</label><br /><br />
                    <label class="namePosition">PHD Scholar</label><br />    
                    <label class="below-info">MUC - IIIT Delhi<br />
                   
                    <a href="http://www.iiitd.edu.in/~samy/" target="_blank">iiitd.edu.in/~samy</a>
                    </label>
                    </td>
                </tr>
                <tr class="hidden-wrapper" id="Tr4">
                <td colspan="2" style="border-top:1px groove gray;">
                <label class="description"><br />
                Energy management in buildings,
Embedded sensing networks,
Cyber-Physical Systems,
Internet of Things.
                <br /><br />
                
                </label>
                <label class="below-info">
                Email -  pandarasamya@iiitd.ac.in<br />

               <br /><br />
                
                </label>
                
                </td>
                </tr>
                   <tr><td colspan="2" class="toHideWrapper">More Info</td></tr>
              
                </table>
                </div>

                  <div class="personal-wrapper"  id="Div3">
            <table>
         
         <tr>
               
                    <td>
                        <img src="images/team-images/nipun-img.jpg" class="personalImage" />
                    </td>   
                    <td class="infoWrapper">
                    <label class="nameWrapper">Nipun Batra</label><br /><br />
                    <label class="namePosition">PHD Scholar</label><br />    
                    <label class="below-info">MUC - IIIT Delhi<br />
                    TCS PhD Fellowship<br />
                    <a href="http://nipunbatra.wordpress.com/" target="_blank">nipunbatra.wordpress.com</a>
                    </label>
                    </td>
                </tr>
                <tr class="hidden-wrapper" id="Tr3">
                <td colspan="2" style="border-top:1px groove gray;">
                <label class="description"><br />
                Machine Learning, Data Analytics, Algorithms, Computational Sustainability & Information Processing in Sensor Systems
                <br /><br />
                
                </label>
                <label class="below-info">
                Email -  nipunb@iiitd.ac.in<br />

               <br /><br />
                
                </label>
                
                </td>
                </tr>
                   <tr><td colspan="2" class="toHideWrapper">More Info</td></tr>
              
                </table>
                </div>

          <div class="personal-wrapper"  id="Div5">
            <table>
         
         <tr>
               
                    <td>
                        <img src="images/team-images/manoj.jpg" class="personalImage" />
                    </td>   
                    <td class="infoWrapper">
                    <label class="nameWrapper">Manoj Gulati</label><br /><br />
                    <label class="namePosition">PHD Scholar</label><br />    
                    <label class="below-info">ECE - IIIT Delhi<br />
                   
                    <a href="http://manojgulati.wordpress.com/" target="_blank">manojgulati.wordpress.com</a>
                    </label>
                    </td>
                </tr>
                <tr class="hidden-wrapper" id="Tr5">
                <td colspan="2" style="border-top:1px groove gray;">
                <label class="description"><br />
               Embedded Systems, Sensor networks, Signal processing, Electromagnetics.
                <br /><br />
                
                </label>
                <label class="below-info">
                Email -  manojg@iiitd.ac.in<br />

               <br /><br /><br />
                
                </label>
                
                </td>
                </tr>
                   <tr><td colspan="2" class="toHideWrapper">More Info</td></tr>
              
                </table>
                </div>
                </div>
    </td></tr>
    <tr><td>
    <h4 id="ra">SoftWare Engineer / RA</h4>
    <hr />
      <div id="raDiv" class="teamWrapper">

                   <div class="personal-wrapper"  id="Div2">
            <table>
         
         <tr>
               
                    <td>
                        <img src="images/team-images/manaswi.jpg" class="personalImage" />
                    </td>   
                    <td class="infoWrapper">
                    <label class="nameWrapper">Manaswi Saha</label><br /><br />
                    <label class="namePosition">Research Scholar</label><br />    
                    <label class="below-info">MUC - IIIT Delhi<br />
                    <a href="http://manaswisaha.wordpress.com/" target="_blank">manaswisaha.wordpress.com</a>
                    </label>
                    </td>
                </tr>
                <tr class="hidden-wrapper" id="Tr2">
                <td colspan="2" style="border-top:1px groove gray;">
                <label class="description"><br />
                Ubiquitous Computing, Applied Machine Learning, ICTD
                <br />
              <br />
                
                </label>
                <label class="below-info">
                Email -  manaswis@iiitd.ac.in<br />

               <br /><br /><br />
                
                </label>
                
                </td>
                </tr>
                   <tr><td colspan="2" class="toHideWrapper">More Info</td></tr>
              
                </table>
                </div>

         <div class="personal-wrapper"  id="Div6">
            <table>
         
         <tr>
               
                    <td>
                        <img src="images/team-images/inderpal.jpg" class="personalImage" />
                    </td>   
                    <td class="infoWrapper">
                    <label class="nameWrapper">Inderpal Singh</label><br /><br />
                    <label class="namePosition">Software Engineer</label><br />    
                    <label class="below-info">MUC - IIIT Delhi<br />
                   
                    <a href="http://en.gravatar.com/inderpalsinghs" target="_blank">gravatar.com/inderpalsinghs</a>
                    </label>
                    </td>
                </tr>
                <tr class="hidden-wrapper" id="Tr6">
                <td colspan="2" style="border-top:1px groove gray;">
                <label class="description"><br />
                Web Development, Web Interfaces, System Programming.
                <br /><br />
                
                </label>
                <label class="below-info">
                Email -  inderpals@iiitd.ac.in<br />
                Mobile - +91 - 7503225406

               <br /><br /><br />
                
                </label>
                
                </td>
                </tr>
                   <tr><td colspan="2" class="toHideWrapper">More Info</td></tr>
              
                </table>
                </div>

                </div>
    </td></tr>
    <tr><td>
    <h4 id="mtech">M.Tech</h4>
    <hr />
     <div id="mtechDiv" class="teamWrapper">
         <div class="personal-wrapper"  id="milanDiv">
            <table>
            
                <tr>
               
                    <td>
                        <img src="images/team-images/milan.png" class="personalImage" />
                    </td>
                    <td class="infoWrapper">
                    <label class="nameWrapper">Milan Jain</label><br /><br />
                    <label class="namePosition">M.Tech</label><br />    
                    <label class="below-info">CSE(MUC),<br />IIIT Delhi
                    <br /><a href=" http://milanjainblog.wordpress.com/" target="_blank">milanjainblog.wordpress.com</a>
                    </label>
                    </td>
                </tr>
                <tr class="hidden-wrapper" id="milan-hide">
                <td colspan="2" style="border-top:1px groove gray;">
                <label class="description"><br />
                 Home Automation based on Z-Wave,
                Wireless Communication, Algorithms, Web Interfaces<br /><br />
                
                </label>
                <label class="below-info">
                Email - milanjain81@gmail.com<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                milan1267@iiitd.ac.in<br />
                Mobile - +91 - 9999663099<br /><br />
                
                </label>
                
                </td>
                </tr>
                <tr><td colspan="2" class="toHideWrapper">More Info</td></tr>
                
                
            </table>
        </div>

         <div class="personal-wrapper"  id="Div1">
            <table>
         
         <tr>
               
                    <td>
                        <img src="images/team-images/shailja-fn.jpg" class="personalImage" />
                    </td>   
                    <td class="infoWrapper">
                    <label class="nameWrapper">Shailja Thakur</label><br /><br />
                    <label class="namePosition">M.Tech</label><br />    
                    <label class="below-info">CSE(MUC),<br />IIIT Delhi
                     <br /><a href="http://shailjathakur.wordpress.com/" target="_blank">ShailjaThakur.wordpress.com</a>
                    </label>
                    </td>
                </tr>
                <tr class="hidden-wrapper" id="Tr1">
                <td colspan="2" style="border-top:1px groove gray;">
                <label class="description"><br />
                Indoor Occupancy,
                Java Applications, Data Analysis <br /><br />
                
                </label>
                <label class="below-info">
                Email - shailja.thakur90@gmail.com<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               shailja1275@iiitd.ac.in<br /><br />
               <br />
                
                </label>
                
                </td>
                </tr>
                   <tr><td colspan="2" class="toHideWrapper">More Info</td></tr>
              
                </table>
                </div>

      </div>
    </td></tr>
    <tr><td>
    <h4 id="btech">B.Tech</h4>
    <hr />
      <div id="btechDiv" class="teamWrapper">
                  <div class="personal-wrapper"  id="Div9">
            <table>
         
         <tr>
               
                    <td>
                        <img src="images/team-images/prateek.jpg" class="personalImage" />
                    </td>   
                    <td class="infoWrapper">
                    <label class="nameWrapper">Prateek Malhotra</label><br /><br />
                    <label class="namePosition">B.Tech</label><br />    
                    <label class="below-info">CSE - IIIT Delhi<br />
                    </label>
                    </td>
                </tr>
                <tr class="hidden-wrapper" id="Tr9">
                <td colspan="2" style="border-top:1px groove gray;">
                <label class="description"><br />
                 Backend Development and Deployment
                <br />
              <br />
                
                </label>
                <label class="below-info">
                Email -  prateek11077@iiitd.ac.in<br />

               <br /><br /><br /><br />
                
                </label>
                
                </td>
                </tr>
                   <tr><td colspan="2" class="toHideWrapper">More Info</td></tr>
              
                </table>
                </div>

                    <div class="personal-wrapper"  id="Div10">
            <table>
         
         <tr>
               
                    <td>
                        <img src="images/team-images/vinayak.jpg" class="personalImage" />
                    </td>   
                    <td class="infoWrapper">
                    <label class="nameWrapper">Vinayak Shukl</label><br /><br />
                    <label class="namePosition">B.Tech</label><br />    
                    <label class="below-info">CSE - IIIT Delhi<br />
                    </label>
                    </td>
                </tr>
                <tr class="hidden-wrapper" id="Tr10">
                <td colspan="2" style="border-top:1px groove gray;">
                <label class="description"><br />
                 Backend Development and Deployment
                <br />
              <br />
                
                </label>
                <label class="below-info">
                Email -  vinayak11118@iiitd.ac.in<br />

               <br /><br /><br /><br />
                
                </label>
                
                </td>
                </tr>
                   <tr><td colspan="2" class="toHideWrapper">More Info</td></tr>
              
                </table>
                </div>

                <div class="personal-wrapper"  id="Div11">
            <table>
         
         <tr>
               
                    <td>
                        <img src="images/team-images/romil.jpg" class="personalImage" />
                    </td>   
                    <td class="infoWrapper">
                    <label class="nameWrapper">Romil Bhardwaj</label><br /><br />
                    <label class="namePosition">B.Tech</label><br />    
                    <label class="below-info">CSE - IIIT Delhi<br />
                    </label>
                    </td>
                </tr>
                <tr class="hidden-wrapper" id="Tr11">
                <td colspan="2" style="border-top:1px groove gray;">
                <label class="description"><br />
                 Backend Development and Deployment
                <br />
              <br />
                
                </label>
                <label class="below-info">
                Email -  romil11092@iiitd.ac.in<br />

               <br /><br /><br /><br />
                
                </label>
                
                </td>
                </tr>
                   <tr><td colspan="2" class="toHideWrapper">More Info</td></tr>
              
                </table>
                </div>
                </div>
    </td></tr>
     <tr><td>
    <h4 id="ucla">UCLA</h4>
    <hr />
      <div id="Div12" class="teamWrapper">
                  <div class="personal-wrapper"  id="Div13">
            <table>
         
         <tr>
               
                    <td>
                        <img src="images/team-images/mani-srivastava.gif" class="personalImage" />
                    </td>   
                    <td class="infoWrapper">
                    <label class="nameWrapper">Mani B Srivastava</label><br /><br />
                    <label class="namePosition">Professor and Area Director</label><br />    
                    <label class="below-info">EE Department, UCLA<br />
                    <a href="http://nesl.ee.ucla.edu/people/mbs/" target="_blank">nesl.ee.ucla.edu/people/mbs</a>
                    </label>
                    </td>
                </tr>
                <tr class="hidden-wrapper" id="Tr12">
                <td colspan="2" style="border-top:1px groove gray;">
                <label class="description"><br />
                Low-power and energy-aware embedded systems, 
Wireless sensor and actuator networks, 
Mobile and wireless computing and networking, Pervasive computing
                <br />
              <br />
                
                </label>
                <label class="below-info">
                Email - mbs@ucla.edu<br />

               <br />
                
                </label>
                
                </td>
                </tr>
                   <tr><td colspan="2" class="toHideWrapper">More Info</td></tr>
              
                </table>
                </div>
  
                  <div class="personal-wrapper"  id="Div17">
            <table>
         
         <tr>
               
                    <td>
                        <img src="images/team-images/magali_delmas.gif" class="personalImage" />
                    </td>   
                    <td class="infoWrapper">
                    <label class="nameWrapper">Magali Delmas</label><br /><br />
                    <label class="namePosition">Professor of Management</label><br />    
                    <label class="below-info">UCLA<br />
                    <a href="http://www.ioe.ucla.edu/delmas" target="_blank">ioe.ucla.edu/delmas</a>
                    </label>
                    </td>
                </tr>
                <tr class="hidden-wrapper" id="Tr15">
                <td colspan="2" style="border-top:1px groove gray;">
                <label class="description"><br />
                Energy Conservation and Efficiency, Eco-labels, Environmental and Corporate Performance
Socially Responsible Investing
                <br />
              <br />
                
                </label>
                <label class="below-info">
                Email - delmas(at)ioe.ucla.edu<br />
                <br />
               <br />
                
                </label>
                
                </td>
                </tr>
                   <tr><td colspan="2" class="toHideWrapper">More Info</td></tr>
              
                </table>
                </div>

                 <div class="personal-wrapper"  id="Div14">
            <table>
         
         <tr>
               
                    <td>
                        <img src="images/team-images/Haksoo_Choi.jpg" class="personalImage" />
                    </td>   
                    <td class="infoWrapper">
                    <label class="nameWrapper">Haksoo Choi</label><br /><br />
                    <label class="namePosition">Graduate Student Researcher</label><br />    
                    <label class="below-info">Networked Embedded Systems Lab, UCLA<br />
                    <a href="http://nesl.ee.ucla.edu/person/show/264" target="_blank">nesl.ee.ucla.edu/person/264</a>
                    </label>
                    </td>
                </tr>
                <tr class="hidden-wrapper" id="Tr13">
                <td colspan="2" style="border-top:1px groove gray;">
                <label class="description"><br />
                Networked Embedded Systems, Sensor Data Privacy, Operating Systems, Database Systems, Machine Learning
                <br />
              <br />
                
                </label>
                <label class="below-info">
                Email - haksoo@cs.ucla.edu<br />
                <br />
               <br />
                
                </label>
                
                </td>
                </tr>
                   <tr><td colspan="2" class="toHideWrapper">More Info</td></tr>
              
                </table>
                </div>

   
                 <div class="personal-wrapper" style="margin-top:10px;"  id="Div15">
            <table>
         
         <tr>
               
                    <td>
                        <img src="images/team-images/victor_chen.jpg" class="personalImage" />
                    </td>   
                    <td class="infoWrapper">
                    <label class="nameWrapper">Victor Chen</label><br /><br />
                    <label class="namePosition">Ph.D Student </label><br />    
                    <label class="below-info">EE Department, UCLA<br />
                   </label>
                    </td>
                </tr>
                <tr class="hidden-wrapper" id="Tr14">
                <td colspan="2" style="border-top:1px groove gray;">
                <label class="description"><br />
              
                <br />
              <br />
                
                </label>
                <label class="below-info">
               <br /><br />
                <br />
               <br />
                
                </label>
                
                </td>
                </tr>
                   <tr><td colspan="2" class="toHideWrapper"></td></tr>
              
                </table>
                </div>
                </div>
                 
    </td></tr>

       <tr><td>
    <h4 id="ibm">IBM Research</h4>
    <hr />
      <div id="Div16" class="teamWrapper">
                  <div class="personal-wrapper"  id="Div18">
            <table>
         
         <tr>
               
                    <td>
                        <img src="images/team-images/zainul.jpg" class="personalImage" />
                      </td>   
                    <td class="infoWrapper">
                    <label class="nameWrapper">Zainul M Charbiwala</label><br /><br />
                    <label class="namePosition">Researcher</label><br />    
                    <label class="below-info">IBM Research, India<br />
                    <a style="" href="http://researcher.watson.ibm.com/researcher/view.php?person=in-zainulcharbiwala" target="_blank">researcher.ibm.com/zainul</a>
                    </label>
                    </td>
                </tr>
                <tr class="hidden-wrapper" id="Tr16">
                <td colspan="2" style="border-top:1px groove gray;">
                <label class="description"><br />
               Electrical Engineering, 
Communications & Networking, 
Mobile Computing, 
Signal Processing
                <br />
              <br />
                
                </label>
                <label class="below-info">
                Email - zainulcharbiwalaat[at]in.ibm.com<br />

               <br />
                <br /><br />
                </label>
                
                </td>
                </tr>
                   <tr><td colspan="2" class="toHideWrapper">More Info</td></tr>
              
                </table>
                </div>
  
                  <div class="personal-wrapper"  id="Div19">
            <table>
         
         <tr>
               
                    <td>
                        <img src="images/team-images/magali_delmas.gif" class="personalImage" />
                    </td>   
                    <td class="infoWrapper">
                    <label class="nameWrapper">Magali Delmas</label><br /><br />
                    <label class="namePosition">Professor of Management</label><br />    
                    <label class="below-info">UCLA<br />
                    <a href="http://www.ioe.ucla.edu/delmas" target="_blank">ioe.ucla.edu/delmas</a>
                    </label>
                    </td>
                </tr>
                <tr class="hidden-wrapper" id="Tr17">
                <td colspan="2" style="border-top:1px groove gray;">
                <label class="description"><br />
                Energy Conservation and Efficiency, Eco-labels, Environmental and Corporate Performance
Socially Responsible Investing
                <br />
              <br />
                
                </label>
                <label class="below-info">
                Email - delmas(at)ioe.ucla.edu<br />
                <br />
               <br />
                
                </label>
                
                </td>
                </tr>
                   <tr><td colspan="2" class="toHideWrapper">More Info</td></tr>
              
                </table>
                </div>

       </div>
                 
    </td></tr>

       <tr><td>
    <h4 id="ccls">IIIT Delhi and CCLS Columbia Joint</h4>
    <hr />
      <div id="Div20" class="teamWrapper">
                  <div class="personal-wrapper"  id="Div21">
            <table>
         
         <tr>
               
                    <td>
                        <img src="images/team-images/dutta_haimonti.png" class="personalImage" />
                      </td>   
                    <td class="infoWrapper">
                    <label class="nameWrapper">Haimonti Dutta</label><br /><br />
                    <label class="namePosition">Associate Research Scientist</label><br />    
                    <label class="below-info">CCLS, Columbia<br />
                    <a style="" href="http://www1.ccls.columbia.edu/~dutta/" target="_blank">ccls.columbia.edu/~dutta</a>
                    </label>
                    </td>
                </tr>
                <tr class="hidden-wrapper" id="Tr18">
                <td colspan="2" style="border-top:1px groove gray;">
                <label class="description"><br />
              Data Mining, Machine Learning and Pattern Recognition,
Distributed Optimization,
Distributed and Parallel Machine Learning,
Mining Big Data,
Data Intensive Computing
                <br />
              <br />
                
                </label>
                <label class="below-info">
                Email - haimonti@ccls.columbia.edu<br />

               <br />
                </label>
                
                </td>
                </tr>
                   <tr><td colspan="2" class="toHideWrapper">More Info</td></tr>
              
                </table>
                </div>
  
               

       </div>
                 
    </td></tr>

       <tr><td>
    <h4 id="cmu">University of California, San Diego</h4>
    <hr />
      <div id="Div22" class="teamWrapper">
                  <div class="personal-wrapper"  id="Div23">
            <table>
         
         <tr>
               
                    <td>
                        <img src="images/team-images/yuvraj.jpg" class="personalImage" />
                      </td>   
                    <td class="infoWrapper">
                    <label class="nameWrapper">Yuvraj Agarwal</label><br /><br />
                    <label class="namePosition">Research Scientist</label><br />    
                    <label class="below-info">University of California, San Diego<br />
                    <a style="" href="http://mesl.ucsd.edu/yuvraj/" target="_blank">mesl.ucsd.edu/yuvraj</a>
                    </label>
                    </td>
                </tr>
                <tr class="hidden-wrapper" id="Tr19">
                <td colspan="2" style="border-top:1px groove gray;">
                <label class="description"><br /><br />
          Smart Buildings, Energy Efficient and Resilient Computer Systems, Mobile Computing
                <br /><br />    
              <br />
                
                </label>
                <label class="below-info">
                Email - yuvraj [at] cs.ucsd.edu<br />

               <br />
                </label>
                
                </td>
                </tr>
                   <tr><td colspan="2" class="toHideWrapper">More Info</td></tr>
              
                </table>
                </div>
  
               

       </div>
                 
    </td></tr>

    </table>
  
       
      
              
               
    
        
    </div>
</asp:Content>

