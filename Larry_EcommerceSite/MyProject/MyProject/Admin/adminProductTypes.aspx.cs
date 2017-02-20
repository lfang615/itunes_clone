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
    public partial class adminProductTypes : System.Web.UI.Page
    {
        public bool? AddNewRecord { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                BindGridView();
            }

        }

        protected List<Gender> DropdownData()
        {
            using(Model1Container1 context = new Model1Container1())
            {
                var data = context.Genders.ToList();

                return data;
                           
            }
        }

        protected void BindGridView()
        {
            
            ProductTypeManager manager = new ProductTypeManager();
            
            var data = manager.GetProductTypes();
            if (AddNewRecord != null && AddNewRecord == true)
            {
                data.Insert(0, new ProductType());
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
            ProductTypeManager manager = new ProductTypeManager();
            Label typeId = (Label)row.FindControl("lblProductTypeId");
            TextBox name = (TextBox)row.FindControl("txtName");
            TextBox genderId = (TextBox)row.FindControl("txtGenderId");

            int id = int.Parse(typeId.Text);
            ProductType productType = manager.GetProductTypeById(id);

            if (productType != null)
            {
                productType.Name = name.Text;

                manager.UpdateProductTypes(productType);

            }
            else
            {
                productType = new ProductType();
                productType.Name = name.Text;
                productType.GenderId = int.Parse(genderId.Text);
                

                manager.UpdateProductTypes(productType);
            }

            adminGrid.EditIndex = -1;
            BindGridView();

        }

        protected void adminGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = adminGrid.Rows[e.RowIndex];
            ProductTypeManager manager = new ProductTypeManager();
            Label id = (Label)row.FindControl("lblProductTypeId");
            int typeId = int.Parse(id.Text);


            ProductType test = manager.GetProductTypeById(typeId);

            manager.DeleteProductType(test);
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