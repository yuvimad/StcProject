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
    public partial class student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();
            string query= "select count(*) from student where regno='" + TextBox1.Text + "' and password='" + TextBox2.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            string output = cmd.ExecuteScalar().ToString();
            if (output == "1")
            {
                Session["reg_no"] =TextBox1.Text;
                Response.Redirect("student1.aspx");
            }
            else
            {
                Label3.Visible = true;
            }
        }
    }
}