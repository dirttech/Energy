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
<li> Recently completed an extensive home deployment - take some pictures and description from Nipun 
</li>    
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

</div>

</asp:Content>

