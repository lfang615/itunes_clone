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
    public partial class adminUsers : System.Web.UI.Page
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
            UserManager manager = new UserManager();
            var data = manager.GetUsers();
            if (AddNewRecord != null && AddNewRecord == true)
            {
                data.Insert(0, new Data.User());
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
            UserManager manager = new UserManager();
            Label userId = (Label)row.FindControl("lblUserId");
            TextBox fullName = (TextBox)row.FindControl("txtFulName");
            TextBox username = (TextBox)row.FindControl("txtUsername");
            TextBox password = (TextBox)row.FindControl("txtPassword");
            TextBox salt = (TextBox)row.FindControl("txtSalt");
            TextBox email = (TextBox)row.FindControl("txtEmail");
            TextBox lastIp = (TextBox)row.FindControl("txtLastIp");
            TextBox securityQ1 = (TextBox)row.FindControl("txtSecurityQ1");
            TextBox securityA1 = (TextBox)row.FindControl("txtSecurityA1");
            TextBox securityQ2 = (TextBox)row.FindControl("txtSecurityQ2");
            TextBox securityA2 = (TextBox)row.FindControl("txtSecurityA2");
            TextBox customerId = (TextBox)row.FindControl("txtCustomerId");

            int id = int.Parse(userId.Text);
            Data.User test = manager.GetUserById(id);

            if (test != null)
            {
                test.FulName = fullName.Text;
                test.Username = username.Text;
                test.Password = password.Text;
                test.Salt = salt.Text;
                test.Email = email.Text;
                test.LastIp = lastIp.Text;
                test.SecurityQ1 = securityQ1.Text;
                test.SecurityQA = securityA1.Text;
                test.SecurityQ2 = securityQ2.Text;
                test.SecurityA2 = securityA2.Text;
                test.CustomerId = int.Parse(customerId.Text);

                manager.UpdateUser(test);
                
            }
            else
            {
                test = new Data.User();
                test.FulName = fullName.Text;
                test.Username = username.Text;
                test.Password = password.Text;
                test.Salt = salt.Text;
                test.Email = email.Text;
                test.LastIp = lastIp.Text;
                test.SecurityQ1 = securityQ1.Text;
                test.SecurityQA = securityA1.Text;
                test.SecurityQ2 = securityQ2.Text;
                test.SecurityA2 = securityA2.Text;
                test.CustomerId = int.Parse(customerId.Text);

                manager.UpdateUser(test);
            }

            adminGrid.EditIndex = -1;
            BindGridView();

        }

        protected void adminGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = adminGrid.Rows[e.RowIndex];
            UserManager manager = new UserManager();
            Label id = (Label)row.FindControl("lblUserId");
            int userId = int.Parse(id.Text);


            Data.User test = manager.GetUserById(userId);

            manager.DeleteUser(test);
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