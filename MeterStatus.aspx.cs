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
        popup.Attributes.Add("class", "abstract");
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

                Button meterIdLabel = new Button();
                meterIdLabel.ID = "meterTick" + i;
                meterIdLabel.Text = allMeters[i];

                //HtmlGenericControl meterIdLabel = new HtmlGenericControl("h2");
                //meterIdLabel.InnerHtml = allMeters[i];
                meterIdLabel.Attributes.Add("val", allMeters[i]);
                meterIdLabel.Style.Add("background-color", "red");
                meterIdLabel.Attributes.Add("class", "meterLabel");
                meterIdLabel.Click += new EventHandler(LastSeenAt);
                
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

    protected void LastSeenAt(object sender, EventArgs e)
    {
        double val = 0;
        int time = 0;
        string building = ""; string wing = ""; string floor = "";
        popup.Controls.Clear();
        popup.Attributes.Add("class", "abstractH");

        Button btn = (Button)sender;
        string metId = btn.Text;

        FetchEnergyDataS_Map.GetMeterByID(metId, out val, out time);
        if (time > 0)
        {
            Utilities ut = Utilitie_S.EpochToDateTime(time);


            HtmlGenericControl lastseen = new HtmlGenericControl("span");
            lastseen.InnerHtml ="<p style='background-color:skyblue;line-height:20px;width:35px;padding:5px;text-align:center'>"+btn.Text + "</p><br />  Last seen: " + ut.Date.ToString("HH:mm");

            popup.Controls.Add(lastseen);
        }

        FetchEnergyDataS_Map.GetMeterLocationByID(metId, out building, out floor, out wing);
        if (building == "Boys Hostel" || building == "Girls Hostel")
        {
            HtmlGenericControl winger = new HtmlGenericControl("p");
            winger.InnerHtml = "Wing: " + wing;
            popup.Controls.Add(winger);
        }
        HtmlGenericControl floorer = new HtmlGenericControl("p");
        floorer.InnerHtml = "Floor: " + floor;
        popup.Controls.Add(floorer);

        HtmlGenericControl builder = new HtmlGenericControl("p");
        builder.InnerHtml = "Building: " + building;
        popup.Controls.Add(builder);

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DrawStatus();
    }
}