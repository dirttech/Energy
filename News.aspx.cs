using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class News : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=ISSNIP.pdf");
            Response.TransmitFile(Server.MapPath("~/App_Data/ISSNIP.pdf"));
            Response.End();
        }
        catch (Exception exp)
        {

        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try
        {
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=Buildsys.pdf");
            Response.TransmitFile(Server.MapPath("~/App_Data/Buildsys.pdf"));
            Response.End();
        }
        catch (Exception exp)
        {

        }
    }
}