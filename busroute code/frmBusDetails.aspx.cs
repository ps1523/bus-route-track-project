using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmBusDetails : System.Web.UI.Page
{
    dbconnectDataContext db = new dbconnectDataContext();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            var maxid = db.BusDetails.OrderByDescending(o => o.auto_id).Select(s => new { s.auto_id }).Take(1);
            if (maxid.Count() <= 0)
            {
                txt_autoid.Text = "1";
            }

            foreach (var item in maxid)
            {
                decimal str = item.auto_id;
                txt_autoid.Text = (str + 1).ToString();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        BusDetail bd = new BusDetail();
        bd.auto_id = Convert.ToDecimal(txt_autoid.Text);
        bd.BusNumber = txt_busno.Text;
        bd.Starting_point = txt_startingPoint.Text;
        bd.ending_point = txt_endingpoint.Text;
        db.BusDetails.InsertOnSubmit(bd);
        db.SubmitChanges();
        Response.Redirect("frmBusDetails.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
      
            var bd = db.BusDetails.FirstOrDefault(record => record.auto_id == Convert.ToDecimal(txt_autoid.Text));
            if (bd != null)
            {
                db.BusDetails.DeleteOnSubmit(bd);
                db.SubmitChanges();
            }
            Response.Redirect("frmBusDetails.aspx");
       }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txt_autoid.Text = GridView1.SelectedRow.Cells[0].Text;
        txt_busno.Text = GridView1.SelectedRow.Cells[1].Text;
        txt_startingPoint.Text = GridView1.SelectedRow.Cells[2].Text;
        txt_endingpoint.Text = GridView1.SelectedRow.Cells[3].Text;
    }
}
