using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmuserregistration : System.Web.UI.Page
{

    dbconnectDataContext db = new dbconnectDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            var maxid = db.userregs.OrderByDescending(o => o.Userid).Select(s => new { s.Userid }).Take(1);
            if (maxid.Count() <= 0)
            {
                txt_userid.Text = "1";
            }

            foreach (var item in maxid)
            {
                decimal str = item.Userid;
                txt_userid.Text = (str + 1).ToString();
            }
        }

    }

    protected void btnregister_Click(object sender, EventArgs e)
    {
        userreg ur = new userreg();
        ur.Userid = Convert.ToDecimal(txt_userid.Text);
        ur.name_user = txt_name.Text;
        ur.gender = drop_gender.Text;
        ur.email_id = txt_emailid.Text;
        ur.mobile_number = Convert.ToDecimal(txt_mobile.Text);
        ur.username = txt_username.Text;
        ur.password = txt_pwd.Text;
        db.userregs.InsertOnSubmit(ur);
        db.SubmitChanges();
         Response.Redirect("frmuserlogin.aspx"); 
       }
}