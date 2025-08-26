using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace FirstDatabaseConnnectionDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        String con_str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        String img_file_name;


        protected void Page_Load(object sender, EventArgs e)
        {
            get_con();
            fill_grid();
        }

        void get_con()
        {
            con = new SqlConnection(con_str);
            con.Open();
        }

        void img_upload()
        {
            if (fuimg.HasFile)
            {
                img_file_name = "images/" + fuimg.FileName;
                fuimg.SaveAs(Server.MapPath(img_file_name));
            }
        }

        void clear()
        {
            txtnm.Text = "";
            txtem.Text = "";
        }

        void fill_grid()
        {
            get_con();
            da = new SqlDataAdapter("select * from stud_tbl",con);
            ds = new DataSet();
            da.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void save_Click(object sender, EventArgs e)
        {
            if (save.Text == "Save")
            {
                get_con();
                img_upload();
                cmd = new SqlCommand("INSERT INTO stud_tbl(Name,Gender,Email,City,Image)VALUES('" + txtnm.Text + "','" + genrbls.Text + "','" + txtem.Text + "','" + ctdrdls.Text + "','" + img_file_name + "')", con);
                cmd.ExecuteNonQuery();
                fill_grid();
                clear();
            }
            else
            {
                cmd = new SqlCommand("UPDATE stud_tbl SET Name='" + txtnm.Text + "', Gender='"+genrbls.Text+"',Email='"+txtem.Text+"',City='"+ctdrdls.SelectedValue+"' WHERE Id='" + ViewState["id"] +"'",con);
                cmd.ExecuteNonQuery();
                fill_grid();
                clear();
                save.Text = "Save";
            }
        }

        void select()
        {
            get_con();
            da = new SqlDataAdapter("SELECT * FROM stud_tbl WHERE Id=" + ViewState["id"] +"",con);
            ds = new DataSet();
            da.Fill(ds);

            //paring of data
            txtnm.Text = ds.Tables[0].Rows[0][1].ToString();
            txtem.Text = ds.Tables[0].Rows[0][3].ToString();
            ctdrdls.SelectedValue = ds.Tables[0].Rows[0][4].ToString();
            genrbls.SelectedValue = ds.Tables[0].Rows[0][2].ToString();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "cmd_edit")
            {
                int id = Convert.ToInt16(e.CommandArgument);
                ViewState["id"] = id;
                save.Text = "Update";
                select();
            }
            else
            {
                int id = Convert.ToInt16(e.CommandArgument);
                ViewState["id"] = id;
                cmd = new SqlCommand("DELETE FROM stud_tbl WHERE Id=" + ViewState["id"] + "", con);
                cmd.ExecuteNonQuery();
                fill_grid();
            }
        }
    }
}