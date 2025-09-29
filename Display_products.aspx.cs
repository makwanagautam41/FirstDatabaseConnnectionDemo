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
                ViewState["Id"] = 0;
                getConnection();
                fillDataList();
            }

            if (Session["student"] != null && Session["student"].ToString() != "")
            {
                getConnection();
                da = new SqlDataAdapter("SELECT * FROM stud_tbl WHERE Email='" + Session["student"] +"'", con);
                ds = new DataSet();
                da.Fill(ds);
                int userId = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                string name = ds.Tables[0].Rows[0][1].ToString();
                lblName.Text = "Welcome " + name;
            }
            else
            {
                Response.Redirect("LoginStudent.aspx");
            }
        }

        void getConnection()
        {
            con = new SqlConnection(con_str);
            con.Open();
        }

        protected void lnk_nxt_Click(object sender, EventArgs e)
        {
            
            int currentPage = Convert.ToInt32(ViewState["Id"]);
            currentPage++;
            ViewState["Id"] = currentPage;
            fillDataList();
        }

        protected void lnk_prev_Click(object sender, EventArgs e)
        {
            
            int currentPage = Convert.ToInt32(ViewState["Id"]);
            currentPage--;
            ViewState["Id"] = currentPage;
            fillDataList();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            getConnection();
            if(e.CommandName == "cmd_view")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("View_Details.aspx?id=" + id);
            }
            if(e.CommandName == "cmd_add")
            {
                da = new SqlDataAdapter("SELECT * FROM stud_tbl WHERE Email='" + Session["student"] + "'",con);
                ds = new DataSet();
                da.Fill(ds);
                int userId = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                int productId = Convert.ToInt32(e.CommandArgument);

                da = new SqlDataAdapter("SELECT * FROM product_tbl WHERE Id='" + productId + "'", con);
                ds = new DataSet();
                da.Fill(ds);

                string productName = ds.Tables[0].Rows[0][1].ToString();
                string productPrice = ds.Tables[0].Rows[0][5].ToString();
                string productImage = ds.Tables[0].Rows[0][3].ToString();
                int quantity = 1;

                cmd = new SqlCommand("INSERT INTO cart_tbl(Cart_user_id,Cart_prod_id,Cart_prod_name,Cart_prod_quantity,Cart_prod_price,Cart_prod_image)VALUES('"+userId+"','"+productId+"','"+productName+"','"+quantity+"','"+productPrice+"','"+productImage+"')", con);
                cmd.ExecuteNonQuery();

            }
        }

        protected void cmd_add(object sender, CommandEventArgs e)
        {

        }

        void fillDataList()
        {
            getConnection();
            da = new SqlDataAdapter("SELECT * FROM product_tbl", con);
            ds = new DataSet();
            da.Fill(ds);

            row = ds.Tables[0].Rows.Count;

            pg = new PagedDataSource();
            pg.AllowPaging = true;
            pg.PageSize = 2;
            pg.CurrentPageIndex = Convert.ToInt32(ViewState["Id"]);
            pg.DataSource = ds.Tables[0].DefaultView;

            // enable/disable navigation buttons
            lnk_prev.Enabled = !pg.IsFirstPage;
            lnk_nxt.Enabled = !pg.IsLastPage;

            
            DataList1.DataSource = pg;
            DataList1.DataBind();

            con.Close();
        }
    }
}
