using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using App_Code.FetchingEnergySmap;
using App_Code.Utility;

public partial class admin_MeterTree : System.Web.UI.Page
{
    public static string buildingSelected;
    public static string blockSelected = "";

    public static double residentialValue = 0;
    public static double commercialValue = 0;

    protected void CheckLogin()
    {
       
        if (Session["AdminUserName"] == null || Session["AdminUserName"] == "")
        {
            Response.Redirect("adminLogin.aspx");
        }
        else
        {

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
        if (ViewState["SelectedNodePath"] != null)
        {
            TreeNode node = TreeView1.FindNode(ViewState["SelectedNodePath"].ToString());
            if (node != null)
            {
                TreeView1.FindNode(node.ValuePath).Expand();
                //node.ExpandAll();
            }
        }
        if (IsPostBack == false)
        {
            buildingSelected = "Faculty Housing";
            fromDate.Value = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy hh:mm:ss");
            toDate.Value = DateTime.Today.ToString("dd/MM/yyyy hh:mm:ss");
            GenerateTree();            
        }
        GetMainsData();
    }
   
    /*
    protected void GenerateBox()
    {
        TreeBox.Controls.Clear();
        string[] loadTypes;
        string[] subLoadTypes;
        string meterId;
        int currentNode=0;
        FetchEnergyDataS_Map.ListingLoadTypes(buildingSelected, out loadTypes);
        foreach (string load in loadTypes)
        {
            HtmlGenericControl loadBox = new HtmlGenericControl("span");
            loadBox.Attributes.Add("class", "load-box");

            HtmlGenericControl loadHeading = new HtmlGenericControl("h3");
            loadHeading.ID = "loadHeading" + currentNode;
            loadHeading.InnerHtml = load;

            HtmlGenericControl hr1 = new HtmlGenericControl("hr");
            FetchEnergyDataS_Map.ListingSubLoadTypes(buildingSelected, load, out subLoadTypes);

            Table subLoadBox = new Table();
            foreach (string subLoad in subLoadTypes)
            {
                TableRow subloadRow = new TableRow();
                TableCell subloadCell = new TableCell();

                HtmlGenericControl subloadName = new HtmlGenericControl("span");
                subloadName.InnerHtml = subLoad;
                subloadName.Attributes.Add("class", "subload-name");

                FetchEnergyDataS_Map.ListingMeterByLoadSubLoad(buildingSelected, load, subLoad, out meterId);
                bool sts=false;
                FetchEnergyDataS_Map.PingingMeter(buildingSelected, meterId, out sts);

                HtmlGenericControl subLoadId = new HtmlGenericControl("label");
                subLoadId.InnerHtml = meterId;
                subLoadId.Attributes.Add("class", "meterid-block");
                if (sts == true)
                {
                    subLoadId.Style.Add("background-color", "lightgreen");
                }
                int time1=0;double reading1=0;
                FetchEnergyDataS_Map.GetMeterByID(meterId, buildingSelected, "Power", out reading1, out time1);

                HtmlGenericControl subloadReading = new HtmlGenericControl("span");
                subloadReading.Attributes.Add("class", "subload-reading");
                subloadReading.InnerHtml = "("+ (Math.Round(reading1 / 1000,1)).ToString() + " %)";

                subloadCell.Controls.Add(subLoadId);
                subloadCell.Controls.Add(subloadName);
                subloadCell.Controls.Add(subloadReading);
                subloadRow.Cells.Add(subloadCell);
                subLoadBox.Rows.Add(subloadRow);
            }

            loadBox.Controls.Add(loadHeading);
            loadBox.Controls.Add(hr1);
            loadBox.Controls.Add(subLoadBox);
            TreeBox.Controls.Add(loadBox);
            currentNode++;
        }
        
    }
    */

    protected void GetMainsData()
    {
        residentialValue = 0;
        commercialValue = 0;

        string[] localSubloads;
        double val1=0,val2=0;
        int tim1=0,tim2=0;
        
        DateTime frDate = DateTime.ParseExact(fromDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                               System.Globalization.CultureInfo.InvariantCulture);
        DateTime tDate = DateTime.ParseExact(toDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                           System.Globalization.CultureInfo.InvariantCulture);
        if (tDate != null && frDate != null)
        {
            FetchEnergyDataS_Map.ListingSubLoadTypes("Facilities Building", "Campus Total Commercial", out localSubloads);
            foreach (string subload in localSubloads)
            {
                FetchEnergyDataS_Map.GetParamByLoadSubloadBuilding("Campus Total Commercial", subload, "Energy", "Facilities Building", frDate.ToString("MM/dd/yyyy HH:mm"), out val1, out tim1);
               FetchEnergyDataS_Map.GetParamByLoadSubloadBuilding("Campus Total Commercial", subload, "Energy", "Facilities Building", tDate.ToString("MM/dd/yyyy HH:mm"), out val2, out tim2);
               
                    if (tim1 > 0 && tim2>0)
                    {
                        commercialValue = commercialValue + (val2 - val1);
                    }
              
                commercialData.InnerHtml = "Commercial Mains: " + (Math.Round(commercialValue / 1000, 2)).ToString() + " KWh";
            }

            FetchEnergyDataS_Map.ListingSubLoadTypes("Facilities Building", "Campus Total Residential", out localSubloads);
            foreach (string subload in localSubloads)
            {
                FetchEnergyDataS_Map.GetParamByLoadSubloadBuilding("Campus Total Residential", subload, "Energy", "Facilities Building", frDate.ToString("MM/dd/yyyy HH:mm"), out val1, out tim1);
               FetchEnergyDataS_Map.GetParamByLoadSubloadBuilding("Campus Total Residential", subload, "Energy", "Facilities Building", tDate.ToString("MM/dd/yyyy HH:mm"), out val2, out tim2);
               
                    if (tim1 > 0 && tim2>0)
                    {
                        residentialValue = residentialValue+(val2-val1);
                    }
               
                residentialData.InnerHtml = "Residential Mains: " + (Math.Round(residentialValue / 1000, 2)).ToString() + " KWh";
            }
            
            timePer.InnerHtml = frDate.ToString("dd MMM yy") + " - " + tDate.ToString("dd MMM yy");
        }
    }

    protected void GenerateTree()
    {
        TreeView1.Nodes.Clear();
        realPop.Style.Add("display", "none");
       
        string[] loadTypes;
        string[] subLoadTypes;
        string[] supplyTypes;
        string meterId;
        int currentNode = 0;

        if (buildingSelected == "Academic Building")
        {
            selectedBuilding.InnerHtml = blockSelected;  
            FetchEnergyDataS_Map.ListingLoadTypesAcademia(blockSelected, out loadTypes);
            foreach (string load in loadTypes)
            {
                TreeView1.Nodes.Add(new TreeNode(load));
                TreeView1.Nodes[currentNode].SelectAction = TreeNodeSelectAction.Expand;

                FetchEnergyDataS_Map.ListingSubLoadTypesAcademia(blockSelected, load, out subLoadTypes);

                foreach (string subLoad in subLoadTypes)
                {
                    FetchEnergyDataS_Map.ListingSupplyTypesByLoadSubLoad(buildingSelected, load, subLoad, out supplyTypes);
                    int currentChild = 0;
                    foreach (string supply in supplyTypes)
                    {
                        FetchEnergyDataS_Map.ListingMeterByLoadSubLoadAndSupplyAcademia(blockSelected, load, subLoad, supply, out meterId);

                        TreeNode child1 = new TreeNode("<span class='dupl'>" + subLoad + "(" + supply + ")</span>");
                        child1.Value = meterId;
                        TreeView1.Nodes[currentNode].ChildNodes.Add(child1);
                        TreeView1.Nodes[currentNode].ChildNodes[currentChild].SelectAction = TreeNodeSelectAction.Select;
                       
                        bool sts = false;
                        FetchEnergyDataS_Map.PingingMeter(buildingSelected, meterId, out sts);

                        int time1 = 0; double reading1 = 0;
                        FetchEnergyDataS_Map.GetMeterByID(meterId, buildingSelected, "Power", out reading1, out time1);
                        currentChild++;
                    }
                }
                currentNode++;
            }
        }
        else
        {
            selectedBuilding.InnerHtml = buildingSelected;    
            FetchEnergyDataS_Map.ListingLoadTypes(buildingSelected, out loadTypes);
            foreach (string load in loadTypes)
            {
                TreeView1.Nodes.Add(new TreeNode(load));
                TreeView1.Nodes[currentNode].SelectAction = TreeNodeSelectAction.Expand;
              
                FetchEnergyDataS_Map.ListingSubLoadTypes(buildingSelected, load, out subLoadTypes);

                foreach (string subLoad in subLoadTypes)
                {
                    FetchEnergyDataS_Map.ListingSupplyTypesByLoadSubLoad(buildingSelected, load, subLoad, out supplyTypes);
                    int currentChild = 0;   
                    foreach (string supply in supplyTypes)
                    {
                        FetchEnergyDataS_Map.ListingMeterByLoadSubLoadAndSupply(buildingSelected, load, subLoad, supply, out meterId);

                        TreeNode child1 = new TreeNode("<span class='dupl'>" + subLoad + "(" + supply + ")</span>");
                        child1.Value = meterId;
                    
                        TreeView1.Nodes[currentNode].ChildNodes.Add(child1);
                        TreeView1.Nodes[currentNode].ChildNodes[currentChild].SelectAction = TreeNodeSelectAction.Select;

                        bool sts = false;
                        FetchEnergyDataS_Map.PingingMeter(buildingSelected, meterId, out sts);

                        int time1 = 0; double reading1 = 0;
                        FetchEnergyDataS_Map.GetMeterByID(meterId, buildingSelected, "Power", out reading1, out time1);
                        currentChild++;
                    }                   
                }
                currentNode++;
            }
        }
       

    }

    protected void LastSeenAt(object sender, EventArgs e)
    {
        realPop.Style.Add("display", "block");
        DateTime frDate = DateTime.ParseExact(fromDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                               System.Globalization.CultureInfo.InvariantCulture);
        DateTime tDate = DateTime.ParseExact(toDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                           System.Globalization.CultureInfo.InvariantCulture);

        //SaveViewState();
        double energy1 = 0, energy2 = 0;
        int tim1 = 0, tim2 = 0;
        double val = 0;
        double val2 = 0;
        int time = 0;
        double percentage = 0;
        string building = ""; string wing = ""; string floor = "";
        string type = ""; string block = ""; string flat = "";
        realPop.Controls.Clear();
        TreeView view = (TreeView)sender;
        TreeNode btn = view.SelectedNode;
        string metId = btn.Value;

        HtmlGenericControl metertype = new HtmlGenericControl("p");
        bool sts = false;
        FetchEnergyDataS_Map.PingingMeter(buildingSelected, metId, out sts);
        if (sts == true)
        {
            metertype.InnerHtml = "<p><font style='background-color:lightgreen;color:black;font-weight:bolder;font-size:larger;line-height:10px;width:35px;padding:5px;padding-left:10px;padding-right:10px;text-align:center'>" + metId + "</font> </p>";
        }
        else
        {
            metertype.InnerHtml = "<p><font style='background-color:lightsalmon;color:black;font-weight:bolder;font-size:larger;line-height:10px;width:35px;padding:5px;padding-left:10px;padding-right:10px;text-align:center'>" + metId + "</font> </p>";
        }
        realPop.Controls.Add(metertype);

        FetchEnergyDataS_Map.GetMeterByID(metId, buildingSelected, "Energy", out val, out time);
        if (time > 0)
        {
            Utilities ut = Utilitie_S.EpochToDateTime(time);

            HtmlGenericControl lastseen = new HtmlGenericControl("span");
            lastseen.InnerHtml = "Last seen: " + ut.Date.ToString("HH:mm dd MMM");

            FetchEnergyDataS_Map.GetMeterByID(metId, buildingSelected, "Power", out val2, out time);

            HtmlGenericControl readings = new HtmlGenericControl("span");
            readings.InnerHtml = "<font style='font-size:small; line-height:25px;color:skyblue;font-weight:bolder;'><br />" + Math.Round(val / 1000, 2).ToString() + " KWh, " + Math.Round(val2, 2).ToString() + "W</font><br />";

            HtmlGenericControl per = new HtmlGenericControl("span");
            per.Style.Add("line-height", "normal");
            FetchEnergyDataS_Map.GetSingleParambyIDBuilding(metId, buildingSelected, "Energy", frDate.ToString("MM/dd/yyyy HH:mm"), out energy1, out tim1);
            FetchEnergyDataS_Map.GetSingleParambyIDBuilding(metId, buildingSelected, "Energy", tDate.ToString("MM/dd/yyyy HH:mm"), out energy2, out tim2);
            if (tim1 > 0 && tim2 > 0)
            {
                Utilities ut1 = Utilitie_S.EpochToDateTime(tim1);
                Utilities ut2 = Utilitie_S.EpochToDateTime(tim2);
                if (ut1 != null && ut2 != null)
                {
                    if (buildingSelected == "Faculty Housing" || buildingSelected == "Girls Hostel" || buildingSelected == "Boys Hostel" || (buildingSelected=="Facilities Building" && metId=="21"))
                    {
                        if (residentialValue > 0)
                        {
                            percentage = Math.Round(((energy2 - energy1) * 100) / (residentialValue), 3);
                            string s= percentage.ToString() + "% of the Total Residential Usage(" + (Math.Round((energy2 - energy1) / 1000)).ToString() + "KWh) ";
                            s = s + "between <font style='color:yellow'>" + ut1.Date.ToString("ddMMM HH:mm") + " and " + ut2.Date.ToString("ddMMM HH:mm")+"</font>";
                            per.InnerHtml = s;
                        }
                    }
                    else
                    {
                        if (commercialValue > 0)
                        {
                            percentage = Math.Round(((energy2 - energy1) * 100) / (commercialValue), 3);
                            string s = percentage.ToString() + "% of the Total Commercial Usage(" + (Math.Round((energy2 - energy1) / 1000)).ToString() + "KWh)";
                            s = s + "between <font style='color:yellow'>" + ut1.Date.ToString("ddMMM HH:mm") + " and " + ut2.Date.ToString("ddMMM HH:mm") + "</font>";
                            per.InnerHtml = s;
                        }
                    }               
                }
            }

            realPop.Controls.Add(lastseen);
            realPop.Controls.Add(readings);
            realPop.Controls.Add(per);


        }
        if (TreeView1.SelectedNode != null)
        {
            TreeView1.SelectedNode.Selected = false;
        }    
    }
   
    protected void Select_Change_Tree(object sender, EventArgs e)
    {
        Response.Write("You selected: " + TreeView1.SelectedNode.Text);
    }

    protected void FacultyHousing_Click(object sender, EventArgs e)
    {
        buildingSelected = "Faculty Housing";
        GenerateTree();
    }
    protected void GirlsHostel_Click(object sender, EventArgs e)
    {
        buildingSelected = "Girls Hostel";
        GenerateTree();
    }
    protected void BoysHostel_Click(object sender, EventArgs e)
    {
        buildingSelected = "Boys Hostel";
        GenerateTree();
    }
    protected void FacilitiesBuilding_Click(object sender, EventArgs e)
    {
        buildingSelected = "Facilities Building";
        GenerateTree();
    }
    protected void AcademicBuilding_Click(object sender, EventArgs e)
    {
        buildingSelected = "Academic Building";
        blockSelected = "Academic Block";
        GenerateTree();
    }
    protected void LectureBlock_Click(object sender, EventArgs e)
    {
        buildingSelected = "Academic Building";
        blockSelected = "Lecture Block";
        GenerateTree();
    }

    protected void MessBuilding_Click(object sender, EventArgs e)
    {
        buildingSelected = "Mess Building";
        GenerateTree();
    }
    protected void LibraryBuilding_Click(object sender, EventArgs e)
    {
        buildingSelected = "Library Building";
        GenerateTree();
    }
    protected override object SaveViewState()
    {
        if (TreeView1.SelectedNode != null)
        {
            ViewState["SelectedNodePath"] = TreeView1.SelectedNode.ValuePath;
         }
        return base.SaveViewState();
    }

    protected void Page_PreLoad(object sender, EventArgs e)
    {
        
    }
    protected void timeSet_Click(object sender, EventArgs e)
    {
        realPop.Style.Add("display", "none");
        if (TreeView1.SelectedNode != null)
        {
            TreeView1.SelectedNode.Selected = false;
        }   
    }
}