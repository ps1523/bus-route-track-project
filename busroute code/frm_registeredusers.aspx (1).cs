using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frm_registeredusers : System.Web.UI.Page
{
    dbconnectDataContext db = new dbconnectDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView();
        }
    }

    private void BindGridView()
    {
 
        var query = from user in db.userregs
                    select user;
                    
        GridView1.DataSource = query;
        GridView1.DataBind();
   
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
       
    }


    private void BindGrid()
    {
        using (dbconnectDataContext db = new dbconnectDataContext())
        {
            GridView1.DataSource = db.userregs.ToList();
            GridView1.DataBind();
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
      
            using (dbconnectDataContext db = new dbconnectDataContext())
            {
                var item = db.userregs.FirstOrDefault(x => x.Userid == userid);
                if (item != null)
                {
                    db.userregs.DeleteOnSubmit(item);
                    db.SubmitChanges();
                }
                else
                {
                   
                }
            }
            BindGrid(); // Re-bind data to the GridView
       
        //int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
       
    }
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindGrid(); // Re-bind data to the GridView
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Assuming Userid is the key field and it's hidden in GridView
        int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());

        // Retrieving other values from GridView editing row
        TextBox txtName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtName");
        TextBox txtGender = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtGender");
        TextBox txtEmail = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEmailId");
        TextBox txtMobileNumber = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtMobileNumber");
        TextBox txtUsername = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtUsername");
        TextBox txtPassword = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPassword");

        using (dbconnectDataContext db = new dbconnectDataContext())
        {
            var user = db.userregs.FirstOrDefault(u => u.Userid == userid);
            if (user != null)
            {
                // Updating user details
                user.name_user = string.IsNullOrEmpty(txtName.Text) ? null : txtName.Text;
                user.gender = string.IsNullOrEmpty(txtGender.Text) ? null : txtGender.Text;
                user.email_id = string.IsNullOrEmpty(txtEmail.Text) ? null : txtEmail.Text;

                // Handling mobile_number considering it might be nullable or not
                if (string.IsNullOrEmpty(txtMobileNumber.Text))
                {
                    // Assuming mobile_number is nullable in your database
                    user.mobile_number = null; // Set to null if empty and your database allows null for this field
                }
                else
                {
                    // Parse the number if the textbox is not empty
                    user.mobile_number = Convert.ToInt64(txtMobileNumber.Text); // Assuming mobile_number is of type long/Int64
                }

                user.username = string.IsNullOrEmpty(txtUsername.Text) ? null : txtUsername.Text;
                user.password = string.IsNullOrEmpty(txtPassword.Text) ? null : txtPassword.Text;

                // Submitting changes to the database
                db.SubmitChanges();

                // Resetting the edit index
                GridView1.EditIndex = -1;

                // Rebinding the GridView to show updated data
                BindGridView();
            }
        }
    }
}