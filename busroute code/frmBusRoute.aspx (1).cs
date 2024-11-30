using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmBusRoute : System.Web.UI.Page
{

    dbconnectDataContext db = new dbconnectDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {

        }
    }
    protected void btn_route_Click(object sender, EventArgs e)
    {
        string busNumber = txt_busno.Text.Trim();

        // Query for GridView1 - Route Details
        var routeDetails = from stop in db.StopMasters
                           where stop.BusNumber == busNumber
                           orderby stop.Stop_no ascending
                           select new
                           {
                               stop.Stop_no,
                               stop.Stop_name,
                               stop.Arrival_time,
                               stop.Charges
                           };

        GridView1.DataSource = routeDetails;
        GridView1.DataBind();

        // Query for GridView2 - Bus Details
        var busDetails = from bus in db.BusDetails
                         where bus.BusNumber == busNumber
                         select bus;

        GridView2.DataSource = busDetails;
        GridView2.DataBind();
    }
}