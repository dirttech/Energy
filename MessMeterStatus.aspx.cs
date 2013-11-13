using System;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using App_Code.FetchingEnergySmap;
using App_Code.Utility;


public partial class MeterStatus : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        DrawStatus();

    }


    protected void DrawStatus()
    {
        popup.Attributes.Add("class", "abstract");
        DrawMess();
    }

    protected void DrawMess()
    {
        mess.Controls.Clear();
        string building = "Mess Building";
        string[] allFloors;

        HtmlGenericControl facultyDiv = new HtmlGenericControl("div");
        facultyDiv.ID = "messDiv";
        facultyDiv.Attributes.Add("class", "containers");

        HtmlGenericControl heading = new HtmlGenericControl("h1");

        heading.InnerHtml = "Mess Building";
        facultyDiv.Controls.Add(heading);

         FetchEnergyDataS_Map.ListingFloors(building, out allFloors);
         var allFloor = allFloors.OrderBy(o => int.Parse(o.ToString()));
        foreach(string kfloor in allFloor)
        {
            string[] allMeters;
            FetchEnergyDataS_Map.ListingMeter(building, kfloor, out allMeters);
            bool status = false;

        if (allMeters != null)
        {
            HtmlGenericControl hr1 = new HtmlGenericControl("hr");
            facultyDiv.Controls.Add(hr1);

            HtmlGenericControl subHeading = new HtmlGenericControl("h4");
            subHeading.InnerHtml = "Floor: " + kfloor;
            facultyDiv.Controls.Add(subHeading);

            for (int i = 0; i < allMeters.Length; i++)
            {
                FetchEnergyDataS_Map.PingingMeter(null, allMeters[i], out status);

                HtmlGenericControl meterIdSpan = new HtmlGenericControl("span");
                meterIdSpan.Attributes.Add("class", "meterSpan");

                Button meterIdLabel = new Button();
                meterIdLabel.ID = "meterTickMS" + i.ToString()+kfloor;
                meterIdLabel.Text = allMeters[i];
                meterIdLabel.Attributes.Add("build", building);

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

        }
            mess.Controls.Add(facultyDiv);
        }

    }

    protected void LastSeenAt(object sender, EventArgs e)
    {
        double val = 0;
        double val2 = 0;
        int time = 0;
        string building = ""; string wing = ""; string floor = "";
        string type = ""; string block = ""; string flat = "";
        popup.Controls.Clear();
        popup.Attributes.Add("class", "abstractH");

        Button btn = (Button)sender;
        string metId = btn.Text;

        Button btnt = (Button)sender;
        building = btnt.Attributes["build"];

        FetchEnergyDataS_Map.GetMeterLocationByID(metId, building, out building, out floor, out wing, out flat, out block, out type);

        HtmlGenericControl metertype = new HtmlGenericControl("p");
        metertype.InnerHtml = "<p><font style='background-color:skyblue;line-height:20px;width:35px;padding:5px;text-align:center'>" + btn.Text + "</font>&nbsp;&nbsp;" + type + "&nbsp;<img src='images/closeButton.png' alt='close' width='20px' align='right'style='padding-right:10px;cursor:pointer;' class='clos'/></p></br>";
        popup.Controls.Add(metertype);

        FetchEnergyDataS_Map.GetMeterByID(metId, "Mess Building", "Energy", out val, out time);
        if (time > 0)
        {
            Utilities ut = Utilitie_S.EpochToDateTime(time);

            HtmlGenericControl lastseen = new HtmlGenericControl("span");
            lastseen.InnerHtml = "Last seen: " + ut.Date.ToString("HH:mm dd MMM");

            FetchEnergyDataS_Map.GetMeterByID(metId, "Mess Building", "Power", out val2, out time);

            HtmlGenericControl readings = new HtmlGenericControl("span");
            if (building != "Faculty Housing")
            {
                readings.InnerHtml = "<font style='font-size:small; line-height:25px;color:gray;font-weight:bolder;'><br />" + Math.Round(val / 1000, 2).ToString() + " KWh, " + Math.Round(val2, 2).ToString() + "W</font>";
            }
            popup.Controls.Add(lastseen);
            popup.Controls.Add(readings);
        }

        if (building == "Boys Hostel" || building == "Girls Hostel")
        {
            HtmlGenericControl winger = new HtmlGenericControl("p");
            winger.InnerHtml = "Wing: " + wing;
            popup.Controls.Add(winger);
        }
        if (building == "Faculty Housing")
        {
            HtmlGenericControl flatter = new HtmlGenericControl("p");
            flatter.InnerHtml = "Apartment: " + flat;
            popup.Controls.Add(flatter);
        }
        if (building == "Academic Building")
        {
            HtmlGenericControl blocker = new HtmlGenericControl("p");
            blocker.InnerHtml = "Block: " + block;
            popup.Controls.Add(blocker);   
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