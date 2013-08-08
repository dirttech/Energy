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
         position:relative;
         text-align:center;
         padding-top:10px;
    }
    .img2container
    {
         
        
    }
    .c2img
    {
        width:480px;
        height:295px;
    }
    .cimg
    {
        width:200px;
        height:120px;
    }
    .desc2
    {
      font-size:medium;
      color:Gray;
      font-weight:normal; 
       padding-left:10px;  
    }
    
    .desc
    {
      font-size:small;
      font-weight:normal;   
    }
    
    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br /><br />

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
<tr><td>
<div class="img2Container" style="border: 1px solid gray;">
<p class="desc2">Description - Add your description here</p>
        <img class="c2img" src="images/deployments/overall_deployment.png"/>
        
</div>
</td>
<td>

<span class="imgContainer">
        <img class="cimg" src="images/deployments/ambient_2.png"/>
        <p class="desc">Description - Add your description here</p>
</span>
<span class="imgContainer">
        <img class="cimg" src="images/deployments/cc_1.png"/>
        <p class="desc">Description - Add your description here</p>
</span>
<span class="imgContainer">
        <img class="cimg" src="images/deployments/ct_interference.png"/>
        <p class="desc">Description - Add your description here</p>
</span>
<span class="imgContainer">
        <img class="cimg" src="images/deployments/electric_meter_1.png"/>
        <p class="desc">Description - Add your description here</p>
</span>


</td>
</tr>
<tr><td colspan="2" style="text-align:center;"><span class="imgContainer">
        <img class="cimg" src="images/deployments/jplug_2.png"/>
        <p class="desc">Description - Add your description here</p>
</span>
<span class="imgContainer">
        <img class="cimg" src="images/deployments/led.png"/>
        <p class="desc">Description - Add your description here</p>
</span>
<span class="imgContainer" style="margin-left:20px;">
        <img class="cimg" src="images/deployments/mcb_2.png"/>
        <p class="desc">Description - Add your description here</p>
</span>

<span class="imgContainer">
        <img class="cimg" src="images/deployments/rpi_2.png"/>
        <p class="desc">Description - Add your description here</p>
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
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
            ForeColor="#6666FF">[Download Link]</asp:LinkButton>
</li>
    <li>Pandarasamy Arjunan, Nipun Batra, Haksoo Choi, Amarjeet Singh, Pushpendra Singh, Mani Srivastava. SensorAct: A Privacy and Security Aware Federated Middleware for Building Management. Buildsys, USA, 2012 
        <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" 
            ForeColor="#6666FF">[Download Link]</asp:LinkButton>
        </li>
    </ul>
    <br />
</div>

</asp:Content>

