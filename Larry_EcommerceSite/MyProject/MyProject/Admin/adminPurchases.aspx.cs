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
    public partial class adminPurchases : System.Web.UI.Page
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
            PurchaseManager manager = new PurchaseManager();
            var data = manager.GetPurchases();
            if (AddNewRecord != null && AddNewRecord == true)
            {
                data.Insert(0, new Purchase());
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
            PurchaseManager manager = new PurchaseManager();
            Label purchaseId = (Label)row.FindControl("lblPurchaseId");
            TextBox amount = (TextBox)row.FindControl("txtAmount");
            TextBox quantity = (TextBox)row.FindControl("txtQuantity");
            TextBox productId = (TextBox)row.FindControl("txtPurchaseId");
            TextBox customerId = (TextBox)row.FindControl("txtCustomerId");
           
            int id = int.Parse(purchaseId.Text);
            Purchase purchase = manager.GetPurchaseById(id);

            if (purchase != null)
            {
                purchase.Amount = decimal.Parse(amount.Text);
                purchase.Quantity = int.Parse(quantity.Text);
                purchase.ProductId = int.Parse(productId.Text);
                purchase.CustomerId = int.Parse(customerId.Text);

                manager.UpdatePurchase(purchase);
            }
            else
            {
                purchase = new Purchase();
                purchase.Amount = decimal.Parse(amount.Text);
                purchase.Quantity = int.Parse(quantity.Text);
                purchase.ProductId = int.Parse(productId.Text);
                purchase.CustomerId = int.Parse(customerId.Text);

                manager.UpdatePurchase(purchase);
            }

            adminGrid.EditIndex = -1;
            BindGridView();

        }

        protected void adminGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = adminGrid.Rows[e.RowIndex];
            CustomerManager manager = new CustomerManager();
            Label id = (Label)row.FindControl("lblCustomerId");
            int custId = int.Parse(id.Text);


            Customer customer = manager.GetCustomerById(custId);

            manager.DeleteCustomer(customer);
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