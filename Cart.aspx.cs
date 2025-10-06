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
    public partial class Cart : System.Web.UI.Page
    {
        String con_str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        int uid = 0;

        void get_con()
        {
            con = new SqlConnection(con_str);
            if (con.State == ConnectionState.Closed)
                con.Open();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                get_con();
                fillGrid();
            }
        }

        void fillGrid()
        {
            get_con();

            da = new SqlDataAdapter("SELECT * FROM stud_tbl WHERE Email='" + Session["student"].ToString() +"'", con);
            ds = new DataSet();
            da.Fill(ds);
            uid = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            

            da = new SqlDataAdapter("SELECT *, (Cart_prod_price * Cart_prod_quantity) AS Total FROM cart_tbl WHERE Cart_user_id='"+uid+"'", con);
            ds = new DataSet();
            da.Fill(ds);
            gvCart.DataSource = ds;
            gvCart.DataBind();

            decimal finalTotal = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["Total"] != DBNull.Value)
                {
                    finalTotal += Convert.ToDecimal(dr["Total"]);
                }
            }

            lblFinnalTotal.Text = "Final Total: " + finalTotal.ToString("0.00");
        }

        protected void update_cart_btn_Click(object sender, EventArgs e)
        {
            get_con();
            foreach (GridViewRow row in gvCart.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    int cart_prod_id = Convert.ToInt32(gvCart.DataKeys[row.RowIndex].Value);
                    TextBox txtQty = (TextBox)row.FindControl("TextBox1");

                    int quantity = 1;
                    int.TryParse(txtQty.Text, out quantity);
                    if (quantity < 1) quantity = 1;

                    cmd = new SqlCommand("UPDATE cart_tbl SET Cart_prod_quantity='" + quantity + "', Cart_prod_total=(Cart_prod_price * '" + quantity + "') WHERE Cart_prod_id='" + cart_prod_id + "'", con);
                    cmd.ExecuteNonQuery();
                }
            }
            fillGrid();
        }

        protected void gvCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RemoveItem")
            {
                get_con();
                int cart_id = Convert.ToInt32(e.CommandArgument);
                cmd = new SqlCommand("DELETE FROM cart_tbl WHERE Cart_id='" + cart_id + "'", con);
                cmd.ExecuteNonQuery();
                fillGrid();
            }
        }

        protected void back_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Display_products.aspx");
        }
    }
}
