using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyProject
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/adminProducts.aspx");
        }

        protected void btnCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/adminCustomers.aspx");
        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/adminPurchases.aspx");
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/adminUsers.aspx");
        }

        protected void btnRole_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/adminRoles.aspx");
        }

        protected void btnRoleType_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/adminRoleTypes.aspx");
        }

        protected void btnProductTypes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/adminProductTypes.aspx");
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/adminCart.aspx");
        }
    }
}