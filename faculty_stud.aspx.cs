using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace stc
{
    public partial class Faculty2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(" Data Source = YUVIMP3\\UVMP3; Initial Catalog = STC; Integrated Security = True");

        protected void Page_Load(object sender, EventArgs e)
        {
            string dept = Session["incharge_dept"].ToString();
            TextBox5.Text = Convert.ToString(dept);
            string departmentofstudstaff = Session["department_of_stdandstaff"].ToString();
            Label7.Text = Convert.ToString(departmentofstudstaff);
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;
            TextBox1.Text = gr.Cells[0].Text;
            TextBox2.Text = gr.Cells[1].Text;
            TextBox3.Text = gr.Cells[2].Text;
            TextBox4.Text = gr.Cells[3].Text;
            TextBox6.Text = gr.Cells[5].Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into student values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "')";
            cmd.ExecuteNonQuery();
            GridView1.DataBind();
            con.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from student where regno='" + TextBox2.Text + "' and department='" + TextBox5.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update student set sno='" + TextBox1.Text + "',name='" + TextBox3.Text + "',password='" + TextBox4.Text + "',batch='" + TextBox6.Text + "' where regno='" + TextBox2.Text + "' and department='" + TextBox5.Text + "'";
            cmd.ExecuteNonQuery();
            GridView1.DataBind();
            con.Close();
        }

    }
}