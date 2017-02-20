using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using API_2._0.Managers;
using Data;

namespace MyProject.Admin
{
    public partial class adminProducts : System.Web.UI.Page
    {

        public bool? AddNewRecord { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGridView();
            }
        }

        protected void BindGridView()
        {
            ProductManager manager = new ProductManager();
            var data = manager.GetProducts();
            if (AddNewRecord != null && AddNewRecord == true)
            {
                
                data.Insert(0, new Product());
                adminGrid.EditIndex = 0;
            }

            adminGrid.DataSource = data;
            adminGrid.DataBind();
        }

        protected void adminGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            adminGrid.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void adminGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = adminGrid.Rows[e.RowIndex];
            ProductManager manager = new ProductManager();
            Label productId = (Label)row.FindControl("lblProductId");
            TextBox name = (TextBox)row.FindControl("txtProductName");
            TextBox price = (TextBox)row.FindControl("txtPrice");
            TextBox photo = (TextBox)row.FindControl("txtPhoto");
            TextBox quantity = (TextBox)row.FindControl("txtQuantity");
            TextBox revenue = (TextBox)row.FindControl("txtRevenue");
            TextBox upc = (TextBox)row.FindControl("txtUPC");
            TextBox typeId = (TextBox)row.FindControl("txtTypeId");

            
            int proId = int.Parse(productId.Text);
            Product product = manager.GetProductById(proId);

            if (product != null)
            {
                product.Name = name.Text;
                product.Price = decimal.Parse(price.Text);
                product.Photo = photo.Text;
                product.Quantity = int.Parse(quantity.Text);
                product.Revenue = decimal.Parse(revenue.Text);
                product.UPC_Code = int.Parse(upc.Text);
                product.ProductTypeId = int.Parse(typeId.Text);

                manager.UpdateProduct(product);
            }
            else
            {
                product = new Product();
                product.Name = name.Text;
                product.Price = decimal.Parse(price.Text);
                product.Photo = photo.Text;
                product.Quantity = int.Parse(quantity.Text);
                product.Revenue = decimal.Parse(revenue.Text);
                product.UPC_Code = int.Parse(upc.Text);
                product.ProductTypeId = int.Parse(typeId.Text);

                manager.UpdateProduct(product);
            }

           

            adminGrid.EditIndex = -1;
            BindGridView();

        }

        protected void adminGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = adminGrid.Rows[e.RowIndex];
            ProductManager manager = new ProductManager();
            Label id = (Label)row.FindControl("lblProductId");
            int proId = int.Parse(id.Text);
           

            Product product = manager.GetProductById(proId);

            manager.DeleteProduct(product);
            BindGridView();
        }

        protected void adminGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            adminGrid.EditIndex = -1;
            BindGridView();
        }


        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            AddNewRecord = true;
            BindGridView();
        }

        protected void adminGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}