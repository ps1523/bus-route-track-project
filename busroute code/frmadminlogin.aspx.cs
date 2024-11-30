using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmadminlogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        if ((txtusername.Text == "admin") && (txtpassword.Text == "admin"))
        {
            Response.Redirect("frmadminmenu.aspx");
        }

        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Password Incorrect');</script>");
        }
    }
}