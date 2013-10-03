using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using App_Code.FetchingEnergyss;
using App_Code.FetchingEnergySmap;
using App_Code.Login;
using App_Code.User_Mapping;
using App_Code.Utility;

public partial class SMapClassicBill : System.Web.UI.Page
{
    static int listBoxCounter = -1;

    public static string meterTyped1 = "Power";
    public static string meterTyped2 = "Light Backup";

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

    protected void calculatePrint(UserMapping userData)
    {
        var bill1 = (Controls_Bill)Page.LoadControl("~/Controls/Bill.ascx");
        double[] meter1Array = null; double[] meter2Array = null;

        bill1.Mode = "manual";
        bill1.fromDate = DateTime.ParseExact(fromDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                           System.Globalization.CultureInfo.InvariantCulture);
        bill1.toDate = DateTime.ParseExact(toDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                           System.Globalization.CultureInfo.InvariantCulture);
        if (powerCheck.Checked == true)
        {
            bill1.meter1 = "Power";
            meter1Array = new double[2];
            meter1Array[0] = Convert.ToDouble(meter_1Initial.Text);
            meter1Array[1] = Convert.ToDouble(meter_1Final.Text);
            bill1.meter1Readings = meter1Array;
        }
        else
        {
            bill1.meter1 = null;
        }
        if (lightCheck.Checked == true)
        {
            bill1.meter2 = "Light Backup";
            meter2Array = new double[2];
            meter2Array[0] = Convert.ToDouble(meter_2Initial.Text);
            meter2Array[1] = Convert.ToDouble(meter_2Final.Text);
            bill1.meter2Readings = meter2Array;
        }
        else
        {
            bill1.meter2 = null;
        }
        
        bill1.calculatePrint(userData);
        billbody.Controls.Add(bill1);
    }

    protected void generateSideBarItems()
    {

        List<UserMapping> AllApartments = UserMapping_S.ListAllBuildingApartments("Faculty Housing");
        if (AllApartments != null)
        {
            Table sideTable = new Table();
            sideTable.ID = "sideTable";

            for (int i = 0; i < AllApartments.Count; i++)
            {

                TableRow wrapper = new TableRow();
                wrapper.ID = "wrapper" + i;

                TableCell cell = new TableCell();
                cell.ID = "cell" + i;
                cell.Style.Add("width", "250px");
                cell.Style.Add("height", "40px");
                cell.Style.Add("border-bottom-style", "groove");

                CheckBox check = new CheckBox();
                check.ID = "check"+i;
                check.Checked = true;               
                check.Attributes.Add("Apart", AllApartments[i].Apartment);
                check.Style.Add("padding", "20px");

                HtmlGenericControl nameLabel = new HtmlGenericControl("label");
                nameLabel.ID = "nameLabel" + i;
                nameLabel.InnerText = AllApartments[i].Apartment;
                nameLabel.Style.Add("font-size", "large");
                nameLabel.Attributes.Add("class", "clicker");
                nameLabel.Attributes.Add("UID", AllApartments[i].UserId.ToString());
                nameLabel.Attributes.Add("Apart", AllApartments[i].Apartment);
                ListBox1.Items.Add(AllApartments[i].Apartment);
                nameLabel.Attributes.Add("onclick", "JavaScript:CopyHidden(this)");

                cell.Controls.Add(check);
                cell.Controls.Add(nameLabel);
                wrapper.Cells.Add(cell);
                sideTable.Rows.Add(wrapper);

            }
            sideBar.Controls.Add(sideTable);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
        UNameOfPrinter.InnerText = "";
        generateSideBarItems();

    }

    protected UserLogin returnUserObj(string userName)
    {
        UserLogin userObj = UserLogin_S.SeeUserInfo(userName);
        if (userObj != null)
        {
            return userObj;
        }
        else
        {
            return null;
        }


    }

    protected void prvs_Click(object sender, EventArgs e)
    {
        listBoxCounter--;
        if (listBoxCounter >= 0)
        {
            uid.Value = ListBox1.Items[listBoxCounter].Text;
            UserMapping userObj = UserMapping_S.UserMapWithApartmentBuilding("Faculty Housing", uid.Value);
            UNameOfPrinter.InnerText = userObj.Apartment;
            calculatePrint(userObj);
        }
    }
    protected void nxt_Click(object sender, EventArgs e)
    {
        listBoxCounter++;
        if (listBoxCounter >= 0)
        {
            uid.Value = ListBox1.Items[listBoxCounter].Text;
            UserMapping userObj = UserMapping_S.UserMapWithApartmentBuilding("Faculty Housing", uid.Value);
            UNameOfPrinter.InnerText = userObj.Apartment;
            calculatePrint(userObj);
        }
    }
    protected void printBill_Click(object sender, EventArgs e)
    {
        //uid.Value = ListBox1.Items[0].Text;
        if (printMode.SelectedValue == "selected")
        {
            var primeArray = selectedBoxes.Value.Split(',');
            for (int apt = 0; apt < primeArray.Length - 1; apt++)
            {
                UserMapping userObj = UserMapping_S.UserMapWithApartmentBuilding("Faculty Housing", primeArray[apt]);
                UNameOfPrinter.InnerText = userObj.Apartment;
                calculatePrint(userObj);
            }
        }
        else if (printMode.SelectedValue == "all")
        {
            for (int apt = 0; apt < ListBox1.Items.Count; apt++)
            {
                UserMapping userObj = UserMapping_S.UserMapWithApartmentBuilding("Faculty Housing", ListBox1.Items[apt].Text);
                UNameOfPrinter.InnerText = userObj.Apartment;
                calculatePrint(userObj);
            }
        }
        else
        {
            UserMapping userObj = UserMapping_S.UserMapWithApartmentBuilding("Faculty Housing", uid.Value);
            UNameOfPrinter.InnerText = userObj.Apartment;
            calculatePrint(userObj);
        }
        
    }
}