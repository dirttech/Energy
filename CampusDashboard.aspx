<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CampusDashboard.aspx.cs" Inherits="CampusDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">

li#camp
        {
          background-color:skyblue;   
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br /><center>
<h3>Click on specific building to see its energy consumption data.</h3>
<p>Labeled buildings  are clickable.</p>
 <asp:ImageMap ID="ImageMap1" runat="server" 
        ImageUrl="~/images/sitemapfinal.png" HotSpotMode="PostBack" 
        onclick="ImageMap1_Click" >
        <asp:PolygonHotSpot HotSpotMode="PostBack" PostBackValue="Boys Hostel A" Coordinates="263,106,284,44,328,52,328,92,317,92,314,67,292,62,274,110" />
        <asp:PolygonHotSpot Coordinates="350,88,350,52,398,52,404,86,394,89,388,68,361,86" 
            HotSpotMode="PostBack" PostBackValue="Girls Hostel AB" />
        <asp:PolygonHotSpot Coordinates="467,56,512,41,524,73,515,77,515,91,485,98,482,83,470,85" 
            HotSpotMode="PostBack" PostBackValue="Mess Building" />
        <asp:PolygonHotSpot Coordinates="716,49,733,38,754,73,763,115,749,122,739,86" 
            HotSpotMode="PostBack" PostBackValue="Academic" />
        <asp:PolygonHotSpot Coordinates="766,80,770,61,800,67,800,82,793,82,784,103,770,103" 
            HotSpotMode="PostBack" PostBackValue="ClassRooms" />
        <asp:PolygonHotSpot Coordinates="814,46,812,38,856,37,857,44,853,44,853,71,844,68,814,70,814,44" 
            HotSpotMode="PostBack" PostBackValue="Library Building" />
        <asp:PolygonHotSpot Coordinates="886,254,892,254,898,274,908,272,908,292,898,293,898,313,886,314,884,295,880,293,880,274,886,274" 
            HotSpotMode="PostBack" PostBackValue="Faculty Housing" />
    </asp:ImageMap>
    </center>
</asp:Content>

