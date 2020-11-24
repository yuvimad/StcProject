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
    public partial class faculty1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Session["faculty_id"].ToString();
            Label9.Text = id;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();

            string query = "select staff_name from staff where staff_id='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            Label8.Text = cmd.ExecuteScalar().ToString();

            string query1 = "select department from staff where staff_id='" + id + "'";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            Label10.Text = cmd1.ExecuteScalar().ToString();

            string query2 = "select qualification from staff where staff_id='" + id + "'";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            Label11.Text = cmd2.ExecuteScalar().ToString();

            string query3 = "select mobile_num from staff where staff_id='" + id + "'";
            SqlCommand cmd3 = new SqlCommand(query3, con);
            Label12.Text = cmd3.ExecuteScalar().ToString();

            string query4 = "select incharge from staff where staff_id='" + id + "'";
            SqlCommand cmd4  = new SqlCommand(query4, con);
            string incharge = cmd4.ExecuteScalar().ToString();
            if (incharge != "no" && incharge != "director")
            {            
                {
                    Label6.Visible = true;
                    Label7.Visible = true;
                    Label7.Text = incharge;
                    ImageButton1.Visible = true;
                }
            }
            


            string query5 = "select hod from staff where staff_id='" + id + "'";
            SqlCommand cmd5 = new SqlCommand(query5, con);
            string hod = cmd5.ExecuteScalar().ToString();
            if (hod == "yes")
            {
                string query9 = "select department from staff where staff_id='" + id + "'";
                SqlCommand cmd9 = new SqlCommand(query9, con);
                string hod_dept = cmd9.ExecuteScalar().ToString();
                Label13.Visible = true;
                Label15.Visible = true;
                Label15.Text =hod_dept;
                ImageButton2.Visible = true;
            }
            string query6 = "select incharge from staff where staff_id='" + id + "'";
            SqlCommand cmd6 = new SqlCommand(query6, con);
            string incharge1 = cmd6.ExecuteScalar().ToString();

            if (incharge1 == "director")
            {
                Label14.Visible = true;
                Label16.Visible = true;
                Label16.Text = incharge1;
                ImageButton3.Visible = true;
                string query8 = "select stream from staff where staff_id='" + id + "'";
                SqlCommand cmd8 = new SqlCommand(query8, con);
                string stream = cmd8.ExecuteScalar().ToString();
                Label17.Visible = true;
                Label17.Text = stream + "   stream";
            }

        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session["incharge_dept"] = Label7.Text;
            Session["department_of_stdandstaff"] = Label10.Text;
            Response.Redirect("faculty_stud.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Session["hod_dept"] = Label15.Text;
            Response.Redirect("hod_staff.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Session["incharge1"] = Label16.Text;
            Session["dir_stream"] = Label17.Text;
            Response.Redirect("dir_hod.aspx");
        }
    }
}