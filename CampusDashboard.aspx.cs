using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using App_Code.FetchingEnergySmap;
using App_Code.Utility;


public partial class CampusDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GenerateSideBarItems();
    }
    protected void ImageMap1_Click(object sender, ImageMapEventArgs e)
    {
        Session["Building-Selected"] = e.PostBackValue;

        Response.Redirect("CampusDashboardPlot.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GenerateSideBarItems();
    }

    protected void GenerateSideBarItems()
    {
        updt.Controls.Clear();

        int time1,time2, time3,time4;
        double value1, value2, value3, value4;
        double diff,Total=0;
        double v1, v2, v3, v4, v5, v6,v7;
        v1 = v2 = v3 = v4 = v5 = v6 = v7 = 0;

        string endTime = "now -5minutes";
        string startTime1 = "now -" + (Convert.ToInt32((DateTime.Now - DateTime.Today).TotalMinutes)).ToString() + "minutes";
        string startTime2 = "now -" + (Convert.ToInt32((DateTime.Now - DateTime.Today.AddMinutes(5)).TotalMinutes)).ToString() + "minutes";

        HtmlGenericControl sideDiv = new HtmlGenericControl("div");
        sideDiv.ID = "sideDiv";
        sideDiv.Attributes.Add("class", "sideDiv");

        HtmlGenericControl divHeader = new HtmlGenericControl("h3");
        divHeader.ID = "divHeader";
        divHeader.Attributes.Add("class", "divHeader");
        divHeader.InnerText = "Today's Consumption";

        HtmlTable buildingTable = new HtmlTable();
        buildingTable.ID = "buildingTable";
        buildingTable.Attributes.Add("class", "buildingTable");

        FetchEnergyDataS_Map.FetchBuildingTotal(endTime ,"now", "Academic Building", "Academic Block", "Energy", "Building Total Mains",out time1,out value1);
        FetchEnergyDataS_Map.FetchBuildingTotal(startTime1, startTime2, "Academic Building", "Academic Block", "Energy", "Building Total Mains", out time2, out value2);

        HtmlTableRow row1 = new HtmlTableRow();
        HtmlTableCell cell1 = new HtmlTableCell();
        if (time1 > 0 && time2 > 0)
        {
            diff = (value1 - value2)/1000;
            Total = Total + diff;
            v1 = diff;
           
            cell1.InnerHtml = "Academic Block"+"<font color='skyblue'>&nbsp;(" + Math.Round(diff, 2).ToString() + " KWh)</font>";
            row1.Cells.Add(cell1);
            buildingTable.Rows.Add(row1);

        }

        FetchEnergyDataS_Map.FetchBuildingTotal( endTime, "now", "Academic Building", "Lecture Block", "Energy", "Building Total Mains", out time1, out value1);
        FetchEnergyDataS_Map.FetchBuildingTotal(startTime1, startTime2, "Academic Building", "Lecture Block", "Energy", "Building Total Mains", out time2, out value2);

        HtmlTableRow row2 = new HtmlTableRow();
        HtmlTableCell cell2 = new HtmlTableCell();
        if (time1 > 0 && time2 > 0)
        {
            diff = (value1 - value2)/1000;
            Total = Total + diff;
            v2 = diff;
           
            cell2.InnerHtml = "Class-rooms" + "<font color='skyblue'>&nbsp;(" + Math.Round(diff, 2).ToString() + " KWh)";
            row2.Cells.Add(cell2);
            buildingTable.Rows.Add(row2);
       
        }

        FetchEnergyDataS_Map.FetchBuildingTotal( endTime, "now", "Library Building", null, "Energy", "Building Total Mains", out time1, out value1);
        FetchEnergyDataS_Map.FetchBuildingTotal(startTime1, startTime2, "Library Building", null, "Energy", "Building Total Mains", out time2, out value2);

        HtmlTableRow row3 = new HtmlTableRow();
        HtmlTableCell cell3 = new HtmlTableCell();
        if (time1 > 0 && time2 > 0)
        {
            diff = (value1 - value2) / 1000;
            Total = Total + diff;
            v3 = diff;

            
            cell3.InnerHtml = "Library" + "<font color='skyblue'>&nbsp;(" + Math.Round(diff, 2).ToString() + " KWh)";
            row3.Cells.Add(cell3);
            buildingTable.Rows.Add(row3);
        }

        FetchEnergyDataS_Map.FetchBuildingTotal(endTime, "now", "Faculty Housing", null, "Energy", "Building Total Mains", out time1, out value1);
        FetchEnergyDataS_Map.FetchBuildingTotal(startTime1, startTime2, "Faculty Housing", null, "Energy", "Building Total Mains", out time2, out value2);

        HtmlTableRow row4 = new HtmlTableRow();
        HtmlTableCell cell4 = new HtmlTableCell();
        if (time1 > 0 && time2 > 0)
        {
            diff = (value1 - value2) / 1000;
            Total = Total + diff;
            v4 = diff;

           
            cell4.InnerHtml = "Faculty Housing" + "<font color='skyblue'>&nbsp;(" + Math.Round(diff, 2).ToString() + " KWh)";
            row4.Cells.Add(cell4);
            buildingTable.Rows.Add(row4);
        }

        FetchEnergyDataS_Map.FetchBuildingTotal(endTime, "now", "Girls Hostel", "AB", "Energy", "Building Total Mains", out time1, out value1);
        FetchEnergyDataS_Map.FetchBuildingTotal(startTime1, startTime2, "Girls Hostel", "AB", "Energy", "Building Total Mains", out time2, out value2);

        FetchEnergyDataS_Map.FetchBuildingTotal(endTime, "now", "Girls Hostel", "BC", "Energy", "Building Total Mains", out time3, out value3);
        FetchEnergyDataS_Map.FetchBuildingTotal(startTime1, startTime2, "Girls Hostel", "BC", "Energy", "Building Total Mains", out time4, out value4);

        HtmlTableRow row5 = new HtmlTableRow();
        HtmlTableCell cell5 = new HtmlTableCell();
        if (time1 > 0 && time2 > 0 && time3>0 && time4 > 0)
        {
            double diff1 = (value1 - value2) / 1000;
            double diff2 = (value3 - value4) / 1000;
            diff = diff1 + diff2;
            Total = Total + diff;
            v5 = diff;

            
            cell5.InnerHtml = "Girls Hostel" + "<font color='skyblue'>&nbsp;(" + Math.Round(diff, 2).ToString() + " KWh)";
            row5.Cells.Add(cell5);
            buildingTable.Rows.Add(row5);
        }

        FetchEnergyDataS_Map.FetchBuildingTotal(endTime, "now", "Boys Hostel", "A", "Energy", "Building Total Mains", out time1, out value1);
        FetchEnergyDataS_Map.FetchBuildingTotal(startTime1, startTime2, "Boys Hostel", "A", "Energy", "Building Total Mains", out time2, out value2);

        FetchEnergyDataS_Map.FetchBuildingTotal(endTime, "now", "Boys Hostel", "BC", "Energy", "Building Total Mains", out time3, out value3);
        FetchEnergyDataS_Map.FetchBuildingTotal(startTime1, startTime2, "Boys Hostel", "BC", "Energy", "Building Total Mains", out time4, out value4);

        HtmlTableRow row6 = new HtmlTableRow();
        HtmlTableCell cell6 = new HtmlTableCell();
        if (time1 > 0 && time2 > 0 && time3 > 0 && time4 > 0)
        {
            double diff1 = (value1 - value2) / 1000;
            double diff2 = (value3 - value4) / 1000;
            diff = diff1 + diff2;
            Total = Total + diff;
            v6 = diff;

            
            cell6.InnerHtml = "Boys Hostel" + "<font color='skyblue'>&nbsp;(" + Math.Round(diff, 2).ToString() + " KWh)";
            row6.Cells.Add(cell6);
            buildingTable.Rows.Add(row6);
        }

        FetchEnergyDataS_Map.FetchBuildingTotal(endTime, "now", "Mess Building", null, "Energy", "Building Total Mains", out time1, out value1);
        FetchEnergyDataS_Map.FetchBuildingTotal(startTime1, startTime2, "Mess Building", null, "Energy", "Building Total Mains", out time2, out value2);

        HtmlTableRow row7 = new HtmlTableRow();
        HtmlTableCell cell7 = new HtmlTableCell();
        if (time1 > 0 && time2 > 0)
        {
            diff = (value1 - value2) / 1000;
            Total = Total + diff;
            v7 = diff;

            
            cell7.InnerHtml = "Mess Building" + "<font color='skyblue'>&nbsp;(" + Math.Round(diff, 2).ToString() + " KWh)";  
            row7.Cells.Add(cell7);
            buildingTable.Rows.Add(row7);
        }


        HtmlTableRow row8 = new HtmlTableRow();
        HtmlTableCell cell8 = new HtmlTableCell();
        cell8.InnerHtml = "<font color='orange'>Total  =  " + Math.Round(Total,2).ToString() + " KWh";
        row8.Cells.Add(cell8);
        buildingTable.Rows.Add(row8);

        v1=((v1)/Total)*100;
        HtmlGenericControl p1=new HtmlGenericControl("span");
        p1.InnerHtml="&nbsp;<font color='orange'>("+Math.Round(v1,2).ToString()+"%)";
        cell1.Controls.Add(p1);

        v2 = ((v2) / Total) * 100;
        HtmlGenericControl p2 = new HtmlGenericControl("span");
        p2.InnerHtml = "&nbsp;<font color='orange'>(" + Math.Round(v2, 2).ToString() + "%)";
        cell2.Controls.Add(p2);

        v3 = ((v3) / Total) * 100;
        HtmlGenericControl p3 = new HtmlGenericControl("span");
        p3.InnerHtml = "&nbsp;<font color='orange'>(" + Math.Round(v3, 2).ToString() + "%)";
        cell3.Controls.Add(p3);

        v4 = ((v4) / Total) * 100;
        HtmlGenericControl p4 = new HtmlGenericControl("span");
        p4.InnerHtml = "&nbsp;<font color='orange'>(" + Math.Round(v4, 2).ToString() + "%)";
        cell4.Controls.Add(p4);

        v5 = ((v5) / Total) * 100;
        HtmlGenericControl p5 = new HtmlGenericControl("span");
        p5.InnerHtml = "&nbsp;<font color='orange'>(" + Math.Round(v5, 2).ToString() + "%)";
        cell5.Controls.Add(p5);

        v6 = ((v6) / Total) * 100;
        HtmlGenericControl p6 = new HtmlGenericControl("span");
        p6.InnerHtml = "&nbsp;<font color='orange'>(" + Math.Round(v6, 2).ToString() + "%)";
        cell6.Controls.Add(p6);

        v7 = ((v7) / Total) * 100;
        HtmlGenericControl p7 = new HtmlGenericControl("span");
        p7.InnerHtml = "&nbsp;<font color='orange'>(" + Math.Round(v7, 2).ToString() + "%)";
        cell7.Controls.Add(p7);

        sideDiv.Controls.Add(divHeader);
        sideDiv.Controls.Add(buildingTable);

        updt.Controls.Add(sideDiv);
    }
}