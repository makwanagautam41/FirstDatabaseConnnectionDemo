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
    public partial class AddProduct : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                fillCategory();
            }
        }

        void get_con()
        {
            con = new SqlConnection(con_str);
            con.Open();
        }

        void img_upload()
        {
            if (FileUpload.HasFile)
            {
                img_file_name = "images/product_image/" + FileUpload.FileName;
                FileUpload.SaveAs(Server.MapPath(img_file_name));
            }
        }

        void clear()
        {
            txtpnm.Text = "";
            txtconfig.Text = "";
            txtprice.Text = "";
        }

        void fillCategory()
        {
            get_con();
            da = new SqlDataAdapter("select * from category_tbl", con);
            ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DropDownList.Items.Add(ds.Tables[0].Rows[i][1].ToString());
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string prod_name = txtpnm.Text;
            string prod_config = txtconfig.Text;
            int price = Convert.ToInt32(txtprice.Text);
            img_upload();

            string query = "INSERT INTO product_tbl (prod_name,prod_config,prod_image,category_id,price) " +
                           "VALUES('" + prod_name + "','" + prod_config + "','" + img_file_name + "','" + ViewState["cid"] + "','" + price + "')";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            clear();
        }

        protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("SELECT * FROM category_tbl WHERE Cat_name='" + DropDownList.SelectedItem.ToString() + "'", con);
            ds = new DataSet();
            da.Fill(ds);

            ViewState["cid"] = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
        }
    }
}