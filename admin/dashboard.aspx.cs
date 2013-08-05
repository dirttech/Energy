using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.FetchingEnergyss;
using App_Code.Utility;
using System.Web.Script.Serialization;

public partial class admin_dashboard : System.Web.UI.Page
{
    public JavaScriptSerializer javaSerial = new JavaScriptSerializer();
    public float[] energyArray;
    public int[] timeArray;
    public static int meterId;
    public static string deviceId;
    public static int startDate;
    public static int timeInterval=0;
    public static string[] timeSeries;

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

    protected void submitDate_Click(object sender, EventArgs e)
    {
        DateTime frDate = DateTime.Today;
        DateTime tDate = DateTime.Now;
        if (fromDate.Value != "")
        {
            frDate = DateTime.ParseExact(fromDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                              System.Globalization.CultureInfo.InvariantCulture);
        }
        if (toDate.Value != "")
        {
            tDate = DateTime.ParseExact(toDate.Value + ",000", "dd/MM/yyyy HH:mm:ss,fff",
                                              System.Globalization.CultureInfo.InvariantCulture);
        }
        Utilities ut1 = Utilitie_S.DateTimeToEpoch(frDate);
        Utilities ut2 = Utilitie_S.DateTimeToEpoch(tDate);

            Plot_ALL_Graph(ut1.Epoch, ut2.Epoch, 3, "1");

    }

    protected void Plot_ALL_Graph(int frTime, int tTime, int meterId, string deviceId)
    {
        try
        {
            List<FetchingEnergy> energyObj = FetchingEnergy_s.fetchEnergyALL(frTime, tTime, meterId, deviceId);
          
            int count = energyObj.Count;
            energyArray = new float[count];
            timeArray = new int[count];
            
            startDate = energyObj[0].TimeStamp;

           

            for (int i = 0; i < count-1; i++)
            {
                energyArray[i] = energyObj[i+1].W;
            }
            //for (int i = 0; i < count; i++)
            //{
            //    timeArray[i] = energyObj[i].TimeStamp;
            //}

            timeInterval=energyObj.Count-1;

            //timeSeries = Utilitie_S.TimeFormatter(timeArray);

        }
        catch (Exception e)
        {

        }

    }
}