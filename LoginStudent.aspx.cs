using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstDatabaseConnnectionDemo
{
    public partial class LoginStudent : System.Web.UI.Page
    {
        string con_str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            get_connection();
        }

        void get_connection()
        {
            con = new SqlConnection(con_str);
            con.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            get_connection();
            if (txtem.Text != null && txtpw.Text != null)
            {
                cmd = new SqlCommand("SELECT COUNT(*) FROM stud_tbl WHERE Email='" + txtem.Text + "' AND Password='" + txtpw.Text + "'", con);
                int i = Convert.ToInt32(cmd.ExecuteScalar());
                if (i > 0)
                {
                    Session["student"] = txtem.Text;
                    Response.Redirect("Display_products.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Email or Password!');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Enter both values please!');</script>");
            }
        }
    }
}