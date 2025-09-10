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
    public partial class Display_products : System.Web.UI.Page
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
                fillDataList();
            }
        }

        void getConnection()
        {
            con = new SqlConnection(con_str);
            con.Open();
        }

        protected void lnk_nxt_Click(object sender, EventArgs e)
        {
            
        }

        protected void lnk_prev_Click(object sender, EventArgs e)
        {

        }

        void fillDataList()
        {
            da = new SqlDataAdapter("SELECT * FROM product_tbl", con);
            ds = new DataSet();
            da.Fill(ds);

            row = ds.Tables[0].Rows.Count;

            pg = new PagedDataSource();  
            pg.AllowPaging = true;
            pg.PageSize = 2;
            pg.CurrentPageIndex = Convert.ToInt32(ViewState["pid"]);

            pg.DataSource = ds.Tables[0].DefaultView;
            DataList1.DataSource = pg;
            DataList1.DataBind();
        }
    }
}
