<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Datasets.aspx.cs" Inherits="Datasets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <style type="text/css">
          li#data
        {
          background-color:skyblue;   
        }
          .linkContainer {
              position: relative;
              width:80%;
              left: 130px;
              right: 30px;
            
          }
          p {
              font-weight: normal;
              font-size: small;
              color: black;
          }
          
         
          br {

              line-height: normal;
              height: 5px;
          }
       hr
        {
            display:block;
            position:relative;
            left:280px;
        }
        .sideLine
        {
             left:0px;
             position:fixed;
             width:180px;
             background-color:offwhite;
             height:180px;
             margin-top:5px;
             padding:10px;
               border-radius:0px 12px 12px 0px;  
             box-shadow:  0px 2px  2px 2px #888, 2px 3px 5px 0px #888;
             
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
         .uselink {
              text-decoration: none;
              color: skyblue;
          }
         a:hover {
              text-decoration: underline;
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
      </style>
     <script type="text/jscript">

         function scrollTo(hash) {
             location.hash = "#" + hash;
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <br /><br />

    <div class="sideLine" style="display:none;">
  
    
    <a>Useful Links</a><br />
      <ul >
    <li><a  onclick="scrollTo('radv')">Research advice</a></li>
    <li><a  onclick="scrollTo('stat')">Statistical links</a></li>
    <li><a  onclick="scrollTo('tech')">Technical Writing</a></li>
    
    </ul>
    </div>
    
    <div id="linkDiv" class="linkContainer" runat="server">
               <div id="radv">
               <h3>Data sets</h3>
                   <ul><li>
                            <a href="http://iawe.github.io/" target="_blank" class="uselink"> Indian data set for ambient water and energy sensing (iAWE) </a>
                        </li><li>
                            <a href="http://nipunbatra.github.io/downloads/files/commercial_dataset.zip" target="_blank" class="uselink">Commercial NILM dataset</a>
                        </li><li>
                            <a href="https://www.iiitd.edu.in/~amarjeet/Datasets/eadivino/" target="_blank" class="uselink"> IIIT Delhi electricity consumption</a>
                        </li><li>
                            <a href="https://www.iiitd.edu.in/~amarjeet/UrbanIndiaSurvey/Data.zip" target="_blank" class="uselink">Urban India Survey Dataset</a>
                   </li></ul>
                 
                
            </div>
        </div>
</asp:Content>

