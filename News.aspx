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
             position:absolute;
             width:170px;
             background-color:Silver;
             height:180px;
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
  
    .teamWrapper
    {
        position:relative;
        left:180px;
      
        max-width:1000px;
        margin-left:50px;
        
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br /><br />

    <div class="sideLine">
  
    
    <a>Whats Happening</a><br />
      <ul >
    <li><a>Recent News<a></li>
    <li><a>Funding</a></li>
    <li><a>Publications</a></li>
    
    </ul>
 
    </div>
    <div class="teamWrapper">
    <h3>Recent News</h3>
    <ul>
    <li>More than 120 smart meters installed on IIIT Delhi campus with data being collected from them every 30 seconds.
</li>
<li> Recently completed an extensive home deployment.
</li>    
<li>Surveyed more than 1500 households in Delhi for energy consumption behavior in summer 2013.</li>
    </ul>
    <br />
    <hr />
    <br />
    <h3>Funding</h3>
    <ul>
    <li>Pervasive Sensing and Computing Technologies for Energy and Water Sustainability in Buildings,Joint project with Prof. Mani Srivastava, UCLA funded by DIT and NSF (PI), 2 years starting April 2012, App. Rs 1,30,00,000
</li>
<li>Time and Presence Based Actuation, Research Project funded by Telecommunication Consultants India Limited (TCIL), 3 months starting November 2012, App. Rs 2,00,000</li>
    </ul>

     <br />
    <hr />
    <br />

    <h3>Publications</h3>

    <ul>
    <li>Pandarasamy Arjunan, Manaswi Saha, Manoj Gulati, Nipun Batra, Amarjeet Singh, Pushpendra Singh, “SensorAct: Design and Implementation of Fine-grained Sensing and Control Sharing in Buildings”, to appear as Poster at  10th USENIX Symposium on Networked Systems Design and Implementation (NSDI ’13), 2013.</li>
    <li>Nipun Batra, Pandarasamy Arjunan, Amarjeet Singh, Pushpendra Singh. Experiences with Occupancy Based Building
Management Systems. ISSNIP, Australia, 2013</li>
    <li>Pandarasamy Arjunan, Nipun Batra, Haksoo Choi, Amarjeet Singh, Pushpendra Singh, Mani Srivastava. SensorAct: A Privacy and Security Aware Federated Middleware for Building Management. Buildsys, USA, 2012 </li>
    </ul>

</div>

</asp:Content>

