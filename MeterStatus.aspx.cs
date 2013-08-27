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
        DrawStatus();
    }


    protected void DrawStatus()
    {
        DrawFaculty();
        DrawGirlsHostel();
        DrawBoysHostel();
        DrawAcademic();
        DrawLibrary();
    }

    protected void DrawFaculty()
    {
        fac.Controls.Clear();
        string building = "Faculty Housing";
        
        string[] allMeters;
        FetchEnergyDataS_Map.ListingMeter(building, out allMeters);

        bool status=false;

        if (allMeters != null)
        {
            HtmlGenericControl facultyDiv = new HtmlGenericControl("div");
            facultyDiv.ID = "grlDiv";
            facultyDiv.Attributes.Add("class", "containers");

            HtmlGenericControl heading = new HtmlGenericControl("h1");
           
            heading.InnerHtml = "Faculty Housing";
            facultyDiv.Controls.Add(heading);

            HtmlGenericControl hr1 = new HtmlGenericControl("hr");
            facultyDiv.Controls.Add(hr1);

            for (int i = 0; i < allMeters.Length; i++)
            {
                FetchEnergyDataS_Map.PingingMeter(null, allMeters[i], out status);

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


           fac.Controls.Add(facultyDiv);
        }

    }

    protected void DrawGirlsHostel()
    {
        grl.Controls.Clear();
        string building = "Girls Hostel";
        
        string[] allMeters;
        FetchEnergyDataS_Map.ListingMeter(building, out allMeters);

        bool status = false;

        if (allMeters != null)
        {
            HtmlGenericControl facultyDiv = new HtmlGenericControl("div");
            facultyDiv.ID = "facDiv";
            facultyDiv.Attributes.Add("class", "containers");

            HtmlGenericControl heading = new HtmlGenericControl("h1");
           
            heading.InnerHtml = "Girls Hostel";
            facultyDiv.Controls.Add(heading);

            HtmlGenericControl hr1 = new HtmlGenericControl("hr");
            facultyDiv.Controls.Add(hr1);

            for (int i = 0; i < allMeters.Length; i++)
            {
                FetchEnergyDataS_Map.PingingMeter(null, allMeters[i], out status);

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


           grl.Controls.Add(facultyDiv);
        }

    }

    protected void DrawBoysHostel()
    {
        boy.Controls.Clear();
        string building = "Boys Hostel";

        string[] allMeters;
        FetchEnergyDataS_Map.ListingMeter(building, out allMeters);

        bool status = false;

        if (allMeters != null)
        {
            HtmlGenericControl facultyDiv = new HtmlGenericControl("div");
            facultyDiv.ID = "boyDiv";
            facultyDiv.Attributes.Add("class", "containers");

            HtmlGenericControl heading = new HtmlGenericControl("h1");

            heading.InnerHtml = "Boys Hostel";
            facultyDiv.Controls.Add(heading);

            HtmlGenericControl hr1 = new HtmlGenericControl("hr");
            facultyDiv.Controls.Add(hr1);

            for (int i = 0; i < allMeters.Length; i++)
            {
                FetchEnergyDataS_Map.PingingMeter(null, allMeters[i], out status);

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


            boy.Controls.Add(facultyDiv);
        }

    }

    protected void DrawAcademic()
    {
        acd.Controls.Clear();
        string building = "Academic Building";

        string[] allMeters;
        FetchEnergyDataS_Map.ListingMeter(building, out allMeters);

        bool status = false;

        if (allMeters != null)
        {
            HtmlGenericControl facultyDiv = new HtmlGenericControl("div");
            facultyDiv.ID = "acdDiv";
            facultyDiv.Attributes.Add("class", "containers");

            HtmlGenericControl heading = new HtmlGenericControl("h1");

            heading.InnerHtml = "Academic Building";
            facultyDiv.Controls.Add(heading);

            HtmlGenericControl hr1 = new HtmlGenericControl("hr");
            facultyDiv.Controls.Add(hr1);

            for (int i = 0; i < allMeters.Length; i++)
            {
                FetchEnergyDataS_Map.PingingMeter(null, allMeters[i], out status);

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


            acd.Controls.Add(facultyDiv);
        }

    }

    protected void DrawLibrary()
    {
        lib.Controls.Clear();
        string building = "Library Building";

        string[] allMeters;
        FetchEnergyDataS_Map.ListingMeter(building, out allMeters);

        bool status = false;

        if (allMeters != null)
        {
            HtmlGenericControl facultyDiv = new HtmlGenericControl("div");
            facultyDiv.ID = "libDiv";
            facultyDiv.Attributes.Add("class", "containers");

            HtmlGenericControl heading = new HtmlGenericControl("h1");

            heading.InnerHtml = "Library Building";
            facultyDiv.Controls.Add(heading);

            HtmlGenericControl hr1 = new HtmlGenericControl("hr");
            facultyDiv.Controls.Add(hr1);

            for (int i = 0; i < allMeters.Length; i++)
            {
                FetchEnergyDataS_Map.PingingMeter(null, allMeters[i], out status);

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


            lib.Controls.Add(facultyDiv);
        }

    }

    protected void DrawMess()
    {
        mess.Controls.Clear();
        string building = "Mess Building";

        string[] allMeters;
        FetchEnergyDataS_Map.ListingMeter(building, out allMeters);

        bool status = false;

        if (allMeters != null)
        {
            HtmlGenericControl facultyDiv = new HtmlGenericControl("div");
            facultyDiv.ID = "messDiv";
            facultyDiv.Attributes.Add("class", "containers");

            HtmlGenericControl heading = new HtmlGenericControl("h1");

            heading.InnerHtml = "Mess Building";
            facultyDiv.Controls.Add(heading);

            HtmlGenericControl hr1 = new HtmlGenericControl("hr");
            facultyDiv.Controls.Add(hr1);

            for (int i = 0; i < allMeters.Length; i++)
            {
                FetchEnergyDataS_Map.PingingMeter(null, allMeters[i], out status);

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


            mess.Controls.Add(facultyDiv);
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DrawStatus();
    }
}