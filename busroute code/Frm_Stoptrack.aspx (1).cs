using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Frm_Stoptrack : System.Web.UI.Page
{

    dbconnectDataContext db = new dbconnectDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            var stopNames = db.StopMasters
                          .Select(s => s.Stop_name)
                          .Distinct()
                          .OrderBy(name => name)
                          .ToList();

            drop_stop.DataSource = stopNames;
            drop_stop.DataBind();
        }
                    
    }
    protected void btn_route_Click(object sender, EventArgs e)
    {



        string selectedStopName = drop_stop.SelectedValue;

    
        // Query to find matching bus details where the stop name matches Starting_point or Ending_point
        var query = db.BusDetails
                      .Where(bd => bd.Starting_point == selectedStopName || bd.ending_point == selectedStopName)
                      .Select(bd => new
                      {
                          bd.BusNumber,
                          bd.Starting_point,
                          bd.ending_point
                      });

        // Bind query result to GridView2
        GridView2.DataSource = query;
        GridView2.DataBind();


        // Query for GridView1 - Stop Match Details Sorted by Arrival Time
        var stopMatchDetails = from stop in db.StopMasters
                               where stop.Stop_name == selectedStopName
                               orderby Convert.ToDateTime(stop.Arrival_time) ascending
                               select new
                               {
                                   stop.BusNumber,
                                   stop.Stop_name,
                                   stop.Arrival_time,
                                   stop.Charges
                               };

        GridView1.DataSource = stopMatchDetails;
        GridView1.DataBind();

            }
}