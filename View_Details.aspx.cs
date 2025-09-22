using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstDatabaseConnnectionDemo
{
    public partial class View_Details : System.Web.UI.Page
    {
        string con_str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        int p, row;

        PagedDataSource pg;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getConnection();
                fill();
            }
        }

        void getConnection()
        {
            con = new SqlConnection(con_str);
            con.Open();
        }

        void fill()
        {
            getConnection();
            string query = "SELECT * FROM product_tbl WHERE Id=" + Request.QueryString["id"];
            da = new SqlDataAdapter(query, con);
            ds = new DataSet();
            da.Fill(ds);
            DataList1.DataSource = ds;
            DataList1.DataBind();

            if (ds.Tables[0].Rows.Count > 0)
            {
                int cid = Convert.ToInt32(ds.Tables[0].Rows[0]["category_id"]);
                get_category(cid);
            }
        }

        void get_category(int cat_id)
        {
            getConnection();
            string query = "SELECT * FROM category_tbl WHERE Cat_id=" + cat_id;
            da = new SqlDataAdapter(query, con);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblCategoryName.Text = ds.Tables[0].Rows[0]["Cat_name"].ToString();
            }
        }
    }
}