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
    public partial class faculty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();
            string query = "select count(*) from staff where staff_id='" + TextBox1.Text + "' and password='" + TextBox2.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            string output = cmd.ExecuteScalar().ToString();
            if (output == "1")
            {
                Session["faculty_id"] = TextBox1.Text;
                Response.Redirect("faculty1.aspx");
            }
            else
            {
                Label3.Visible = true;
            }
        }
    }
}