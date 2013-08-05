<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Team.aspx.cs" Inherits="Team" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
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
    <div class="teamWrapper">

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
                Ubiquitous Computing, Applied Machine Learning, ICTD, Middleware
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
</asp:Content>

