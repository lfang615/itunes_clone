using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
using API_2._0.Managers;
using System.Web.Security;


namespace MyProject
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            UserManager userManager = new UserManager();

            if (userManager.Authenticate(username, password) == true)
            {
                FormsAuthentication.RedirectFromLoginPage(username, false);
            }
            else
            {
                lblError1.Text = "Username or Password was incorrect";
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtNewUser.Text.Trim();
            string password = txtNewPass.Text.Trim();
            string email = txtEmail.Text.Trim();
            string fName = txtFName.Text.Trim();
            string lName = txtLName.Text.Trim();
            string answer1 = txtA1.Text.Trim();
            string answer2 = txtA2.Text.Trim();
            string fullName = txtFName.Text.Trim() + " " + txtLName.Text.Trim();
            string dob = txtDob.Text.Trim();
            
            UserManager manager = new UserManager();

            CustomerManager custmanage = new CustomerManager();

            Customer customer = custmanage.CreateCustomer(fName, lName, DateTime.Parse(dob), null, null, null, null, null, null);
            int custId = customer.Id;



            Data.User user = manager.CreateUser(fullName, username, password, email, "Mother's maiden name", answer1, "Last name of childhood best friend",
                answer2, Page.Request.UserHostAddress, custId);

            RoleManager roleManager = new RoleManager();

            Role role = roleManager.CreateRole(2, user.Id);

            if (user == null)
            {
                lblError.Text = "Username already exists.";
            }

                     
        }
    }
}