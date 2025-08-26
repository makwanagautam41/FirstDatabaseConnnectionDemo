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
    public partial class AddCategory : System.Web.UI.Page
    {
        String con_str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        String img_file_name;

        void get_con()
        {
            con = new SqlConnection(con_str);
            con.Open();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            get_con();
            cmd = new SqlCommand("insert into category_tbl values('"+ TextBox1.Text+ "')", con);
            cmd.ExecuteNonQuery();
            TextBox1.Text = "";
        }
    }
}