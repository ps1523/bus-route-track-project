using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmStop : System.Web.UI.Page
{
    dbconnectDataContext db = new dbconnectDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            var maxid = db.StopMasters.OrderByDescending(o => o.Stop_id).Select(s => new { s.Stop_id }).Take(1);
            if (maxid.Count() <= 0)
            {
                txt_stopid.Text = "1";
            }

            foreach (var item in maxid)
            {
                decimal str = item.Stop_id;
                txt_stopid.Text = (str + 1).ToString();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        StopMaster sm = new StopMaster();
        sm.Stop_id = Convert.ToDecimal(txt_stopid.Text);
        sm.BusNumber = txt_busno.Text;
        sm.Stop_no = Convert.ToDecimal(txt_Stopno.Text);
        sm.Stop_name = txt_stopname.Text;
        sm.Arrival_time = txt_arrivaltime.Text;
        sm.Charges = txt_charges.Text;
        db.StopMasters.InsertOnSubmit(sm);
        db.SubmitChanges();
        Response.Redirect("FrmStop.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        var bd = db.StopMasters.FirstOrDefault(record => record.Stop_id == Convert.ToDecimal(txt_stopid.Text));
        if (bd != null)
        {
            db.StopMasters.DeleteOnSubmit(bd);
            db.SubmitChanges();
        }
        Response.Redirect("FrmStop.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

        txt_stopid.Text = GridView1.SelectedRow.Cells[0].Text;
        txt_busno.Text = GridView1.SelectedRow.Cells[1].Text;
        txt_Stopno.Text = GridView1.SelectedRow.Cells[2].Text;
        txt_stopname.Text = GridView1.SelectedRow.Cells[0].Text;
        txt_arrivaltime.Text = GridView1.SelectedRow.Cells[0].Text;
        txt_charges.Text = GridView1.SelectedRow.Cells[0].Text;
    }
}