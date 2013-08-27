using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using App_Code.FetchingEnergySmap;
using App_Code.Utility;
using App_Code.User_Mapping;


public partial class MeterStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DrawFaculty();
    }


    protected void DrawStatus()
    {
       
    }

    protected void DrawFaculty()
    {
        statusHolder.Controls.Clear();
        string[] allMeters;
        FetchEnergyDataS_Map.ListingMeter(out allMeters);

        bool status=false;

        if (allMeters != null)
        {
            HtmlGenericControl facultyDiv = new HtmlGenericControl("div");
            facultyDiv.ID = "facDiv";

            for (int i = 0; i < allMeters.Length; i++)
            {
                FetchEnergyDataS_Map.PingingFacultyMeter(null, allMeters[i], out status);

                HtmlGenericControl meterIdSpan = new HtmlGenericControl("span");
                meterIdSpan.Attributes.Add("class", "meterSpan");
                

                HtmlGenericControl meterIdLabel = new HtmlGenericControl("h2");
                meterIdLabel.InnerHtml = allMeters[i];
                meterIdLabel.Style.Add("background-color", "red");
                meterIdLabel.Attributes.Add("class", "meterLabel");

                if (status == true)
                {
                    meterIdLabel.Style.Add("background-color", "green");
                }

                meterIdSpan.Controls.Add(meterIdLabel);
                facultyDiv.Controls.Add(meterIdSpan);
            }
            statusHolder.Controls.Add(facultyDiv);
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DrawFaculty();
    }
}