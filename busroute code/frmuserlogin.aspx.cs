using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmuserlogin : System.Web.UI.Page
{
    dbconnectDataContext db = new dbconnectDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack== false)
        {

        }
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        if (txtusername.Text != "")
        {
            var query = db.userregs.Where(x => x.username == txtusername.Text).Where(x => x.password == txtpassword.Text).FirstOrDefault();
            if (query == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Invalid Login');</script>");
                return;
            }

            else
            {
                Session["userid"] = query.Userid;
                Session["username"] = query.username;
                Response.Redirect("frmusermenu.aspx");
            }
        }
    }
}