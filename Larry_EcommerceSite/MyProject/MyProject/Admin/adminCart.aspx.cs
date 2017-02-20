using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using API_2._0.Managers;
using Data;

namespace MyProject
{
    public partial class adminCart : System.Web.UI.Page
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
            CartManager manager = new CartManager();
            var data = manager.GetCart();
            if (AddNewRecord != null && AddNewRecord == true)
            {
                data.Insert(0, new Cart());
                adminGrid.EditIndex = 0;
            }
            
            adminGrid.DataSource = data.ToList();
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
            CartManager manager = new CartManager();
            Label cartId = (Label)row.FindControl("lblCartId");
            TextBox custId = (TextBox)row.FindControl("txtCustomerId");
            TextBox productId = (TextBox)row.FindControl("txtProductId");
            TextBox quantity = (TextBox)row.FindControl("txtQuantity");
            TextBox total = (TextBox)row.FindControl("txtTotal");

            int id = int.Parse(cartId.Text);
            Cart test = manager.GetCartItemById(id);

            if (test != null)
            {
                test.CustomerId = int.Parse(custId.Text);
                test.ProductId = int.Parse(productId.Text);
                test.Quantity = int.Parse(quantity.Text);
                test.Total = decimal.Parse(total.Text);

                manager.UpdateCart(test);

            }
            else
            {
                test = new Cart();
                test.CustomerId = int.Parse(custId.Text);
                test.ProductId = int.Parse(productId.Text);
                test.Quantity = int.Parse(quantity.Text);
                test.Total = decimal.Parse(total.Text);

                manager.UpdateCart(test);
            }

            adminGrid.EditIndex = -1;
            BindGridView();

        }

        protected void adminGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = adminGrid.Rows[e.RowIndex];
            CartManager manager = new CartManager();
            Label id = (Label)row.FindControl("lblCartId");
            int cartId = int.Parse(id.Text);


            Cart test = manager.GetCartItemById(cartId);

            manager.DeleteCart(test);
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
    }
}