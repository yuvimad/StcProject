using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;



namespace stc
{
    public partial class admin1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Session["adminid"].ToString();
            Label5.Text = id;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();

            string query = "select name from admin where admin_id='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            Label4.Text = cmd.ExecuteScalar().ToString();


            string query1 = "select dept from admin where admin_id='" +id + "'";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            Label6.Text = cmd1.ExecuteScalar().ToString();

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_stud.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_faculty.aspx");
        }
    }
}