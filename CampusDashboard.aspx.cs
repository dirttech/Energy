using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
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
        double[] value1, value2, value3, value4, diff;
        double Total=0, val1=0, val2=0, val3=0, val4=0;
        value1 = new double[7];
        value2 = new double[7];
        value3 = new double[7];
        value4 = new double[7];
        diff = new double[7];

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

        FetchEnergyDataS_Map.FetchBuildingTotal(endTime ,"now", "Academic Building", "Academic Block", "Energy", "Building Total Mains",out time1,out val1);
        FetchEnergyDataS_Map.FetchBuildingTotal(startTime1, startTime2, "Academic Building", "Academic Block", "Energy", "Building Total Mains", out time2, out val2);

        value1[0] = val1;
        value2[0] = val2;

        HtmlTableRow row1 = new HtmlTableRow();
        HtmlTableCell cell1 = new HtmlTableCell();
        if (time1 > 0 && time2 > 0)
        {           
            row1.Cells.Add(cell1);
            buildingTable.Rows.Add(row1);

        }

        FetchEnergyDataS_Map.FetchBuildingTotal(endTime, "now", "Academic Building", "Lecture Block", "Energy", "Building Total Mains", out time1, out val1);
        FetchEnergyDataS_Map.FetchBuildingTotal(startTime1, startTime2, "Academic Building", "Lecture Block", "Energy", "Building Total Mains", out time2, out val2);
        value1[1] = val1;
        value2[1] = val2;
        HtmlTableRow row2 = new HtmlTableRow();
        HtmlTableCell cell2 = new HtmlTableCell();
        if (time1 > 0 && time2 > 0)
        {
            row2.Cells.Add(cell2);
            buildingTable.Rows.Add(row2);
       
        }

        FetchEnergyDataS_Map.FetchBuildingTotal( endTime, "now", "Library Building", null, "Energy", "Building Total Mains", out time1, out val1);
        FetchEnergyDataS_Map.FetchBuildingTotal(startTime1, startTime2, "Library Building", null, "Energy", "Building Total Mains", out time2, out val2);
        value1[2] = val1;
        value2[2] = val2;
        HtmlTableRow row3 = new HtmlTableRow();
        HtmlTableCell cell3 = new HtmlTableCell();
        if (time1 > 0 && time2 > 0)
        {
            row3.Cells.Add(cell3);
            buildingTable.Rows.Add(row3);
        }

        FetchEnergyDataS_Map.FetchBuildingTotal(endTime, "now", "Faculty Housing", null, "Energy", "Building Total Mains", out time1, out val1);
        FetchEnergyDataS_Map.FetchBuildingTotal(startTime1, startTime2, "Faculty Housing", null, "Energy", "Building Total Mains", out time2, out val2);
        value1[3] = val1;
        value2[3] = val2;
        HtmlTableRow row4 = new HtmlTableRow();
        HtmlTableCell cell4 = new HtmlTableCell();
        if (time1 > 0 && time2 > 0)
        {
            row4.Cells.Add(cell4);
            buildingTable.Rows.Add(row4);
        }

        FetchEnergyDataS_Map.FetchBuildingTotal(endTime, "now", "Girls Hostel", "AB", "Energy", "Building Total Mains", out time1, out val1);
        FetchEnergyDataS_Map.FetchBuildingTotal(startTime1, startTime2, "Girls Hostel", "AB", "Energy", "Building Total Mains", out time2, out val2);
        value1[4] = val1;
        value2[4] = val2;
        FetchEnergyDataS_Map.FetchBuildingTotal(endTime, "now", "Girls Hostel", "BC", "Energy", "Building Total Mains", out time3, out val3);
        FetchEnergyDataS_Map.FetchBuildingTotal(startTime1, startTime2, "Girls Hostel", "BC", "Energy", "Building Total Mains", out time4, out val4);
        value3[4] = val3;
        value4[4] = val4;
        HtmlTableRow row5 = new HtmlTableRow();
        HtmlTableCell cell5 = new HtmlTableCell();
        if (time1 > 0 && time2 > 0 && time3>0 && time4 > 0)
        {
            row5.Cells.Add(cell5);
            buildingTable.Rows.Add(row5);
        }

        FetchEnergyDataS_Map.FetchBuildingTotal(endTime, "now", "Boys Hostel", "A", "Energy", "Building Total Mains", out time1, out val1);
        FetchEnergyDataS_Map.FetchBuildingTotal(startTime1, startTime2, "Boys Hostel", "A", "Energy", "Building Total Mains", out time2, out val2);
        value1[5] = val1;
        value2[5] = val2;
        FetchEnergyDataS_Map.FetchBuildingTotal(endTime, "now", "Boys Hostel", "BC", "Energy", "Building Total Mains", out time3, out val3);
        FetchEnergyDataS_Map.FetchBuildingTotal(startTime1, startTime2, "Boys Hostel", "BC", "Energy", "Building Total Mains", out time4, out val4);
        value3[5] = val3;
        value4[5] = val4;
        HtmlTableRow row6 = new HtmlTableRow();
        HtmlTableCell cell6 = new HtmlTableCell();
        if (time1 > 0 && time2 > 0 && time3 > 0 && time4 > 0)
        {
            row6.Cells.Add(cell6);
            buildingTable.Rows.Add(row6);
        }

        FetchEnergyDataS_Map.FetchBuildingTotal(endTime, "now", "Mess Building", null, "Energy", "Building Total Mains", out time1, out val1);
        FetchEnergyDataS_Map.FetchBuildingTotal(startTime1, startTime2, "Mess Building", null, "Energy", "Building Total Mains", out time2, out val2);
        value1[6] = val1;
        value2[6] = val2;
        HtmlTableRow row7 = new HtmlTableRow();
        HtmlTableCell cell7 = new HtmlTableCell();
        if (time1 > 0 && time2 > 0)
        {            
            row7.Cells.Add(cell7);
            buildingTable.Rows.Add(row7);
        }

        diff[0] = (value1[0] - value2[0])/1000; diff[1] = (value1[1] - value2[1])/1000; diff[2] = (value1[2] - value2[2])/1000; 
        diff[3] = (value1[3] - value2[3])/1000; diff[6] = (value1[6] - value2[6])/1000; 
        diff[4] = ((value1[4] - value2[4])+(value3[4]-value4[4]))/1000; 
        diff[5] = ((value1[5] - value2[5])+(value3[5]-value4[5]))/1000;
        Total = diff[0] + diff[1] + diff[2] + diff[3] + diff[4] + diff[5] + diff[6];
        //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Projects\Energy\App_Data\WriteLine7.txt",true))
        //{
        //    for (int a = 0; a < 1; a++)
        //    {
        //        file.WriteLine(value1[a].ToString() + "------" + value2[a].ToString() + "------" + value3[a].ToString() + "-------" + value4[a].ToString() + "------" + diff[a].ToString());
        //    }
        //}

        HtmlTableRow row8 = new HtmlTableRow();
        HtmlTableCell cell8 = new HtmlTableCell();
        cell8.InnerHtml = "<font color='orange'>Total  =  " + Math.Round(Total,2).ToString() + " KWh";
        row8.Cells.Add(cell8);
        buildingTable.Rows.Add(row8);

        
        HtmlGenericControl p1=new HtmlGenericControl("span");
        p1.InnerHtml ="Academic Block" + "<font color='skyblue'>&nbsp;(" + Math.Round(diff[0], 2).ToString() + " KWh)</font>&nbsp;<font color='orange'>(" + Math.Round((diff[0]/Total)*100, 2).ToString() + "%)</font>";
        cell1.Controls.Add(p1);

        HtmlGenericControl p2 = new HtmlGenericControl("span");
        p2.InnerHtml = "Class-rooms" + "<font color='skyblue'>&nbsp;(" + Math.Round(diff[1], 2).ToString() + " KWh)</font>&nbsp;<font color='orange'>(" + Math.Round((diff[1] / Total) * 100, 2).ToString() + "%)</font>";
        cell2.Controls.Add(p2);

        HtmlGenericControl p3 = new HtmlGenericControl("span");
        p3.InnerHtml = "Library" + "<font color='skyblue'>&nbsp;(" + Math.Round(diff[2], 2).ToString() + " KWh)</font>&nbsp;<font color='orange'>(" + Math.Round((diff[2] / Total) * 100, 2).ToString() + "%)</font>";
        cell3.Controls.Add(p3);

        HtmlGenericControl p4 = new HtmlGenericControl("span");
        p4.InnerHtml = "Faculty Housing" + "<font color='skyblue'>&nbsp;(" + Math.Round(diff[3], 2).ToString() + " KWh)</font>&nbsp;<font color='orange'>(" + Math.Round((diff[3] / Total) * 100, 2).ToString() + "%)</font>";
        cell4.Controls.Add(p4);

        HtmlGenericControl p5 = new HtmlGenericControl("span");
        p5.InnerHtml = "Girls Hostel" + "<font color='skyblue'>&nbsp;(" + Math.Round(diff[4], 2).ToString() + " KWh)</font>&nbsp;<font color='orange'>(" + Math.Round((diff[4] / Total) * 100, 2).ToString() + "%)</font>";
        cell5.Controls.Add(p5);

        HtmlGenericControl p6 = new HtmlGenericControl("span");
        p6.InnerHtml = "Boys Hostel" + "<font color='skyblue'>&nbsp;(" + Math.Round(diff[5], 2).ToString() + " KWh)</font>&nbsp;<font color='orange'>(" + Math.Round((diff[5] / Total) * 100, 2).ToString() + "%)</font>";
        cell6.Controls.Add(p6);

        HtmlGenericControl p7 = new HtmlGenericControl("span");
        p7.InnerHtml = "Mess Building" + "<font color='skyblue'>&nbsp;(" + Math.Round(diff[6], 2).ToString() + " KWh)</font>&nbsp;<font color='orange'>(" + Math.Round((diff[6] / Total) * 100, 2).ToString() + "%)</font>";
        cell7.Controls.Add(p7);

        sideDiv.Controls.Add(divHeader);
        sideDiv.Controls.Add(buildingTable);

        updt.Controls.Add(sideDiv);
    }
}