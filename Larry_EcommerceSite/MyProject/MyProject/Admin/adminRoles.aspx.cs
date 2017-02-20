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
    public partial class adminRoles : System.Web.UI.Page
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
            RoleManager manager = new RoleManager();
            var data = manager.getRoles();
            if (AddNewRecord != null && AddNewRecord == true)
            {
                data.Insert(0, new Role());
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
            RoleManager manager = new RoleManager();
            Label roleId = (Label)row.FindControl("lblRoleId");
            TextBox roleTypeId = (TextBox)row.FindControl("txtRoleTypeId");
            TextBox userId = (TextBox)row.FindControl("txtUserId");
           
            int id = int.Parse(roleId.Text);
            Role test = manager.GetRoleById(id);

            if (test != null)
            {
                test.RoleTypeId = int.Parse(roleTypeId.Text);
                test.UserId = int.Parse(userId.Text);
               
                manager.UpdateRoles(test);

            }
            else
            {
                test = new Role();

                test.RoleTypeId = int.Parse(roleTypeId.Text);
                test.UserId = int.Parse(userId.Text);

                manager.UpdateRoles(test);
            }

            adminGrid.EditIndex = -1;
            BindGridView();

        }

        protected void adminGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = adminGrid.Rows[e.RowIndex];
            RoleManager manager = new RoleManager();
            Label id = (Label)row.FindControl("lblRoleId");
            int roleId = int.Parse(id.Text);


            Role test = manager.GetRoleById(roleId);

            manager.DeleteRole(test);
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