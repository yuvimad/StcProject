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
    public partial class hod_staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string hod_dept=Session["hod_dept"].ToString();
            TextBox7.Text =hod_dept;
            string none_hod ="no";
            TextBox9.Text =none_hod;
        }
        SqlConnection con = new SqlConnection(" Data Source = YUVIMP3\\UVMP3; Initial Catalog = STC; Integrated Security = True");

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;
            TextBox1.Text = gr.Cells[0].Text;
            TextBox2.Text = gr.Cells[1].Text;
            TextBox3.Text = gr.Cells[2].Text;
            TextBox4.Text = gr.Cells[3].Text;
            TextBox5.Text = gr.Cells[4].Text;
            TextBox6.Text = gr.Cells[5].Text;        
            TextBox8.Text = gr.Cells[7].Text;
            TextBox10.Text = gr.Cells[9].Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
          
            cmd.CommandText = "insert into staff values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "','" + TextBox10.Text + "')";
            cmd.ExecuteNonQuery();
            GridView1.DataBind();
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "update staff set sno='" + TextBox1.Text + "',staff_name='" + TextBox3.Text + "',password='" + TextBox4.Text + "',incharge='" + TextBox5.Text + "',qualification='" + TextBox6.Text + "',department='" + TextBox7.Text + "',mobile_num='" + TextBox8.Text + "',stream='" + TextBox10.Text + "',hod='" + TextBox9.Text + "' where staff_id='" + TextBox2.Text + "' and department='"+TextBox7.Text+"'";
            cmd.ExecuteNonQuery();
            GridView1.DataBind();
            con.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
          
            cmd.CommandText = "delete from staff where staff_id='" + TextBox2.Text + "' and department='"+TextBox7.Text+"'";
            cmd.ExecuteNonQuery();
            GridView1.DataBind();
            con.Close();
        }     
    }
}