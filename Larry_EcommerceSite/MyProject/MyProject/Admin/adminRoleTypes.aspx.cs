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
    public partial class adminRoleTypes : System.Web.UI.Page
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
            RoleTypeManager manager = new RoleTypeManager();
            var data = manager.GetRType();
            if (AddNewRecord != null && AddNewRecord == true)
            {
                data.Insert(0, new RoleType());
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
            RoleTypeManager manager = new RoleTypeManager();
            Label roleId = (Label)row.FindControl("lblRoleTypeId");
            TextBox roleName = (TextBox)row.FindControl("txtName");
            
            int id = int.Parse(roleId.Text);
            RoleType test = manager.GetRTypeById(id);

            if (test != null)
            {
                test.Name = roleName.Text;              
                manager.UpdateRType(test);

            }
            else
            {
                test = new RoleType();
                test.Name = roleName.Text;
                manager.UpdateRType(test);
            }

            adminGrid.EditIndex = -1;
            BindGridView();

        }

        protected void adminGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = adminGrid.Rows[e.RowIndex];
            RoleTypeManager manager = new RoleTypeManager();
            Label id = (Label)row.FindControl("lblRoleTypeId");
            int roleId = int.Parse(id.Text);


            RoleType test = manager.GetRTypeById(roleId);

            manager.DeleteRType(test);
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