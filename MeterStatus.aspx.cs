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
        DrawFaculty();
        DrawGirlsHostel();
        DrawBoysHostel();
        DrawAcademic();
        DrawLibrary();
        DrawMess();
        DrawServiceBlock();
    }

    protected void DrawFaculty()
    {
        fac.Controls.Clear();
        string building = "Faculty Housing";
        string[] allFloors;

        HtmlGenericControl facultyDiv = new HtmlGenericControl("div");
        facultyDiv.ID = "grlDiv";
        facultyDiv.Attributes.Add("class", "containers");

        HtmlGenericControl heading = new HtmlGenericControl("h1");

        heading.InnerHtml = "Faculty Housing";
        facultyDiv.Controls.Add(heading);

        
        FetchEnergyDataS_Map.ListingFloors(building, out allFloors);
        var allFloor = allFloors.OrderBy(o => int.Parse(o.ToString()));
        foreach(string kfloor in allFloor)
        {
            string[] allMeters;

            FetchEnergyDataS_Map.ListingMeter(building, kfloor, out allMeters);

            bool status=false;

        if (allMeters != null)
        {

            HtmlGenericControl subHeading = new HtmlGenericControl("h4");

            subHeading.InnerHtml = "Floor: "+kfloor;
            facultyDiv.Controls.Add(subHeading);


            HtmlGenericControl hr1 = new HtmlGenericControl("hr");
            facultyDiv.Controls.Add(hr1);

            for (int i = 0; i < allMeters.Length; i++)
            {
                FetchEnergyDataS_Map.PingingMeter(building, allMeters[i], out status);

                HtmlGenericControl meterIdSpan = new HtmlGenericControl("span");
                meterIdSpan.Attributes.Add("class", "meterSpan");

                Button meterIdLabel = new Button();
                meterIdLabel.ID = "meterTick" + i.ToString()+kfloor;
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

        } fac.Controls.Add(facultyDiv);

    }

    protected void DrawGirlsHostel()
    {
        grl.Controls.Clear();
        string building = "Girls Hostel";
        string[] allFloors;

        HtmlGenericControl facultyDiv = new HtmlGenericControl("div");
        facultyDiv.ID = "facDiv";
        facultyDiv.Attributes.Add("class", "containers");

        HtmlGenericControl heading = new HtmlGenericControl("h1");

        heading.InnerHtml = "Girls Hostel";
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
            HtmlGenericControl subHeading = new HtmlGenericControl("h4");

            subHeading.InnerHtml = "Floor: " + kfloor;
            facultyDiv.Controls.Add(subHeading);


            HtmlGenericControl hr1 = new HtmlGenericControl("hr");
            facultyDiv.Controls.Add(hr1);

            for (int i = 0; i < allMeters.Length; i++)
            {
                FetchEnergyDataS_Map.PingingMeter(building, allMeters[i], out status);

                HtmlGenericControl meterIdSpan = new HtmlGenericControl("span");
                meterIdSpan.Attributes.Add("class", "meterSpan");

                Button meterIdLabel = new Button();
                meterIdLabel.ID = "meterTickGH" + i.ToString()+kfloor;
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


        } grl.Controls.Add(facultyDiv);
        }

    }

    protected void DrawBoysHostel()
    {
        boy.Controls.Clear();
        string building = "Boys Hostel";
        string[] allFloors;

        HtmlGenericControl facultyDiv = new HtmlGenericControl("div");
        facultyDiv.ID = "boyDiv";
        facultyDiv.Attributes.Add("class", "containers");

        HtmlGenericControl heading = new HtmlGenericControl("h1");

        heading.InnerHtml = "Boys Hostel";
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

                HtmlGenericControl subHeading = new HtmlGenericControl("h4");

                subHeading.InnerHtml = "Floor: " + kfloor;
                facultyDiv.Controls.Add(subHeading);

                HtmlGenericControl hr1 = new HtmlGenericControl("hr");
                facultyDiv.Controls.Add(hr1);

                for (int i = 0; i < allMeters.Length; i++)
                {
                    FetchEnergyDataS_Map.PingingMeter(building, allMeters[i], out status);

                    HtmlGenericControl meterIdSpan = new HtmlGenericControl("span");
                    meterIdSpan.Attributes.Add("class", "meterSpan");

                    Button meterIdLabel = new Button();
                    meterIdLabel.ID = "meterTickBH" + i.ToString() + kfloor;
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
            boy.Controls.Add(facultyDiv);
        }

    }

    protected void DrawAcademic()
    {
        acd.Controls.Clear();
        string building = "Academic Building";
        string[] allFloors;

            HtmlGenericControl facultyDiv = new HtmlGenericControl("div");
            facultyDiv.ID = "acdDiv";
            facultyDiv.Attributes.Add("class", "containers");

            HtmlGenericControl heading = new HtmlGenericControl("h1");
            heading.InnerHtml = "Academic Building";
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
                HtmlGenericControl subHeading = new HtmlGenericControl("h4");
                subHeading.InnerHtml = "Floor: "+kfloor;
                facultyDiv.Controls.Add(subHeading);

                    FetchEnergyDataS_Map.ListingMeter(building, kfloor, out allMeters);
                    HtmlGenericControl hr1 = new HtmlGenericControl("hr");
                    facultyDiv.Controls.Add(hr1);

                    for (int i = 0; i < allMeters.Length; i++)
                    {
                        FetchEnergyDataS_Map.PingingMeter(building, allMeters[i], out status);

                        HtmlGenericControl meterIdSpan = new HtmlGenericControl("span");
                        meterIdSpan.Attributes.Add("class", "meterSpan");

                        Button meterIdLabel = new Button();
                        meterIdLabel.ID = "meterTickAC" + i.ToString()+kfloor;
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
                    acd.Controls.Add(facultyDiv);
            }

    }

    protected void DrawLibrary()
    {
            lib.Controls.Clear();
            string building = "Library Building";
            string[] allFloors;

            HtmlGenericControl facultyDiv = new HtmlGenericControl("div");
            facultyDiv.ID = "libDiv";
            facultyDiv.Attributes.Add("class", "containers");

            HtmlGenericControl heading = new HtmlGenericControl("h1");

            heading.InnerHtml = "Library Building";
            facultyDiv.Controls.Add(heading);

            FetchEnergyDataS_Map.ListingFloors(building, out allFloors);
            var allFloor = allFloors.OrderBy(o => int.Parse(o.ToString()));
            foreach (string kfloor in allFloor) 
            {
                string[] allMeters;

                FetchEnergyDataS_Map.ListingMeter(building, kfloor, out allMeters);
                bool status = false;

                if (allMeters != null)
                {
                    HtmlGenericControl subHeading = new HtmlGenericControl("h4");
                    subHeading.InnerHtml = "Floor: " + kfloor;
                    facultyDiv.Controls.Add(subHeading);

                    for (int i = 0; i < allMeters.Length; i++)
                    {
                        FetchEnergyDataS_Map.PingingMeter(building, allMeters[i], out status);

                        HtmlGenericControl meterIdSpan = new HtmlGenericControl("span");
                        meterIdSpan.Attributes.Add("class", "meterSpan");

                        Button meterIdLabel = new Button();
                        meterIdLabel.ID = "meterTickLB" + i.ToString() + kfloor;
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
            }
            lib.Controls.Add(facultyDiv);        
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

        heading.InnerHtml = "Mess & Dining";
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
            HtmlGenericControl subHeading = new HtmlGenericControl("h4");
            subHeading.InnerHtml = "Floor: " + kfloor;
            facultyDiv.Controls.Add(subHeading);


            for (int i = 0; i < allMeters.Length; i++)
            {
                FetchEnergyDataS_Map.PingingMeter(building, allMeters[i], out status);

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

    protected void DrawServiceBlock()
    {
        serv.Controls.Clear();
        string building = "Facilities Building";
        string[] allFloors;

        HtmlGenericControl facultyDiv = new HtmlGenericControl("div");
        facultyDiv.ID = "servDiv";
        facultyDiv.Attributes.Add("class", "containers");

        HtmlGenericControl heading = new HtmlGenericControl("h1");

        heading.InnerHtml = "Facilities Building";
        facultyDiv.Controls.Add(heading);

        FetchEnergyDataS_Map.ListingFloors(building, out allFloors);
        var allFloor = allFloors.OrderBy(o => int.Parse(o.ToString()));
        foreach (string kfloor in allFloor)
        {
            string[] allMeters;
            FetchEnergyDataS_Map.ListingMeter(building, kfloor, out allMeters);
            bool status = false;

            if (allMeters != null)
            {
                HtmlGenericControl subHeading = new HtmlGenericControl("h4");
                subHeading.InnerHtml = "Floor: " + kfloor;
                facultyDiv.Controls.Add(subHeading);


                for (int i = 0; i < allMeters.Length; i++)
                {
                    FetchEnergyDataS_Map.PingingMeter(building, allMeters[i], out status);

                    HtmlGenericControl meterIdSpan = new HtmlGenericControl("span");
                    meterIdSpan.Attributes.Add("class", "meterSpan");

                    Button meterIdLabel = new Button();
                    meterIdLabel.ID = "meterTickFB" + i.ToString() + kfloor;
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
            serv.Controls.Add(facultyDiv);
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

        FetchEnergyDataS_Map.GetMeterByID(metId,building,"Energy", out val, out time);
        if (time > 0)
        {
            Utilities ut = Utilitie_S.EpochToDateTime(time);

            HtmlGenericControl lastseen = new HtmlGenericControl("span");
            lastseen.InnerHtml = "Last seen: " + ut.Date.ToString("HH:mm dd MMM");

            FetchEnergyDataS_Map.GetMeterByID(metId,building, "Power", out val2, out time);

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