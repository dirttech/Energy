using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using App_Code.BillSettings;

public partial class admin_BillConfiguration : System.Web.UI.Page
{
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
    }
    protected void SaveConfiguration_Click(object sender, EventArgs e)
    {
        BillConfigure billobj = new BillConfigure();

        billobj.ApplicableDate = DateTime.ParseExact(fromDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                           System.Globalization.CultureInfo.InvariantCulture);
        billobj.FixedCharge = Convert.ToDouble(fixedCharge.Text);
        billobj.AdjCharge = Convert.ToDouble(adjCharge.Text);
        billobj.DefCharge = Convert.ToDouble(defCharge.Text);
        billobj.ElectricityTax = Convert.ToDouble(electricityTax.Text);
        billobj.SlabSize = slabsizes.Value.TrimEnd(',');
        billobj.SlabPrice = slabprices.Value.TrimEnd(',');

        bool sts = Bill_Configure.InsertConfiguration(billobj);
        if (sts == true)
        {
            status.Text = "Added Successfully";
        }
        else
        {
            status.Text = "Sorry! Something went wrong";
        }
        
    }
    protected void slabSize_TextChanged(object sender, EventArgs e)
    {
        slabsizeBox.Controls.Clear();
        slabpriceBox.Controls.Clear();
        int num = Convert.ToInt32(slabSize.Text);
        for (int i = 0; i < num; i++)
        {
            HtmlGenericControl slabsize = new HtmlGenericControl("input");
            slabsize.Attributes.Add("type", "text");
            slabsize.Attributes.Add("pattern", "[0-9.]+");
            slabsize.Attributes.Add("placeholder", "Slab "+(i+1)+" Units");
            slabsize.Attributes.Add("required", "required");
            slabsize.ID = "slabsize" + i;

            HtmlGenericControl slabprice = new HtmlGenericControl("input");
            slabprice.Attributes.Add("pattern", "[0-9.]+");
            slabprice.Attributes.Add("type", "text");
            slabprice.Attributes.Add("placeholder", "Price");
            slabprice.Attributes.Add("required", "required");
           
            slabprice.ID = "slabprice" + i;

            slabsizeBox.Controls.Add(slabsize);
            slabpriceBox.Controls.Add(slabprice);

            HtmlGenericControl br = new HtmlGenericControl("br");
          
            HtmlGenericControl br2 = new HtmlGenericControl("br");
      


        }
    }
}