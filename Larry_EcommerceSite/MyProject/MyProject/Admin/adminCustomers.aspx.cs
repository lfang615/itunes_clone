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
    public partial class adminCustomers : System.Web.UI.Page
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
            CustomerManager manager = new CustomerManager();
            var data = manager.GetCustomers();
            if (AddNewRecord != null && AddNewRecord == true)
            {

                data.Insert(0, new Customer());
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
            CustomerManager manager = new CustomerManager();
            Label customerId = (Label)row.FindControl("lblCustomerId");
            TextBox fName = (TextBox)row.FindControl("txtFName");
            TextBox lName = (TextBox)row.FindControl("txtLName");
            TextBox birthday = (TextBox)row.FindControl("txtBirthday");
            TextBox phone = (TextBox)row.FindControl("txtPhone");
            TextBox address1 = (TextBox)row.FindControl("txtAddress1");
            TextBox address2 = (TextBox)row.FindControl("txtAddress2");
            TextBox city = (TextBox)row.FindControl("txtCity");
            TextBox state = (TextBox)row.FindControl("txtState");
            TextBox zip = (TextBox)row.FindControl("txtZip");


            int custId = int.Parse(customerId.Text);
            Customer customer = manager.GetCustomerById(custId);

            if (customer != null)
            {
                customer.FName = fName.Text;
                customer.LName = lName.Text;
                customer.Birthday = DateTime.Parse(birthday.Text);
                customer.PhoneNumber = phone.Text;
                customer.Address1 = address1.Text;
                customer.Address2 = address2.Text;
                customer.City = city.Text;
                customer.State = state.Text;
                customer.Zip = zip.Text;
  
                manager.UpdateCustomer(customer);
            }
            else
            {
                customer = new Customer();
                customer.FName = fName.Text;
                customer.LName = lName.Text;
                customer.Birthday = DateTime.Parse(birthday.Text);
                customer.PhoneNumber = phone.Text;
                customer.Address1 = address1.Text;
                customer.Address2 = address2.Text;
                customer.City = city.Text;
                customer.State = state.Text;
                customer.Zip = zip.Text;

                manager.UpdateCustomer(customer);
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