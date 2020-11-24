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
    public partial class student1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string reg =Session["reg_no"].ToString();
            Label6.Text = reg;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();

            string query = "select name from student where regno='" + reg + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            Label5.Text = cmd.ExecuteScalar().ToString();

            string query1 = "select department from student where regno='" + reg + "'";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            Label7.Text = cmd1.ExecuteScalar().ToString();

            string query2 = "select batch from student where regno='" + reg + "'";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            Label8.Text = cmd2.ExecuteScalar().ToString();
        }

    }
}