using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frm_feedback : System.Web.UI.Page
{
    dbconnectDataContext db = new dbconnectDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            var maxid = db.QueryTabs.OrderByDescending(o => o.Query_no).Select(s => new { s.Query_no }).Take(1);
            if (maxid.Count() <= 0)
            {
                txt_qno.Text = "1";
            }

            foreach (var item in maxid)
            {
                decimal str = item.Query_no;
                txt_qno.Text = (str + 1).ToString();
            }
        }
    }
    protected void btn_post_Click(object sender, EventArgs e)
    {
        QueryTab qt = new QueryTab();
        qt.Query_no = Convert.ToDecimal(txt_qno.Text);
        qt.Query_heading = txt_qheading.Text;
        qt.Detailed_Query = txt_query.Text;
        qt.Com_number = txt_number.Text;
        qt.User_id = Convert.ToDecimal(lbl_userid.Text);
        db.QueryTabs.InsertOnSubmit(qt);
        db.SubmitChanges();
        Response.Redirect("frm_feedback.aspx");
    }
}