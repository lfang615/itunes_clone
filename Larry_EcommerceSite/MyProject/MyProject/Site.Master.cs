using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using API_2._0.Managers;
using Data;
using System.Web.Security;

namespace MyProject
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.User.Identity.IsAuthenticated && Page.User.Identity.Name != null)
            {
                CartManager manager = new CartManager();
                UserManager userManager = new UserManager();
                CustomerManager customerManager = new CustomerManager();
                ProductManager productManager = new ProductManager();

                string userName = Page.User.Identity.Name;
                Data.User currentUser = userManager.GetUserByUsername(userName);


                int customerId = customerManager.GetCustomerIdByUserName(userName);

                int cartId = manager.GetCartIdByCustomerId(customerId);

                if (!Page.IsPostBack)
                {
                    if (cartId == 0)
                    {
                        DataList1.DataSource = null;
                        DataList1.DataBind();
                    }
                    else
                    {
                        DataList1.DataSource = productManager.GetProductDataByCartId(cartId);
                        DataList1.DataBind();
                    }
                }
                else
                {
                    DataList1.DataSource = productManager.GetProductDataByCartId(cartId);
                    DataList1.DataBind();
                }




            }


            if (Page.User.Identity.IsAuthenticated &&  Page.User.IsInRole("Admin"))
            {

                hlUsername.Text = Page.User.Identity.Name;
                hlUsername.NavigateUrl = "~/Admin/Admin.aspx";
                login.Text = "Sign Out";
                hlUsername.Visible = true;

            }
            else if (Page.User.Identity.IsAuthenticated && Page.User.IsInRole("Customer"))
            {
                hlUsername.Text = Page.User.Identity.Name;
                hlUsername.NavigateUrl = "~/User/Profile.aspx";
                login.Text = "Sign Out";
                hlUsername.Visible = true;
            }
            else
            {
                hlUsername.Visible = false;
                login.Text = "Sign In";
            }

        }

        protected void btnmen_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mens.aspx");
        }

        protected void btnMenTop_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mens.aspx?typeid=1");
        }

        protected void btnMenBottom_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mens.aspx?typeid=2");
        }

        protected void btnMenAccess_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mens.aspx?typeid=3");
        }

        protected void btnwomen_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Womens.aspx");
        }

        protected void btnWomTop_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Womens.aspx?typeid=4");
        }

        protected void btnWomBottom_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Womens.aspx?typeid=5");
        }

        protected void btnWomAccess_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Womens.aspx?typeid=6");
        }

        protected void btnLogo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void login_Click(object sender, EventArgs e)
        {
            if (login.Text == "Sign Out")
            {
                FormsAuthentication.SignOut();
                hlUsername.Visible = false;
                login.Text = "Sign In";
                Response.Redirect("~/default.aspx");
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
 
        }


        protected void btnSaleMen_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mens.aspx?typeid=1004");
        }

        protected void btnSaleWomen_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Womens.aspx?typeid=1005");
        }

        protected void btnTrendMen_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mens.aspx?typeid=1006");
        }

        protected void btnTrendWomen_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Womens.aspx?typeid=1007");
        }

        protected void btnSale_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Unisex.aspx?typeName=Sale");
        }

        protected void linkBtnTrend_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Unisex.aspx?typeName=Trending");
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                string userName = Page.User.Identity.Name;
                CartManager cartManager = new CartManager();

                var lblId = (Label)e.Item.FindControl("cartId");

                int id = int.Parse(lblId.Text);

                Cart theCart = cartManager.GetCartItemById(id);

                cartManager.DeleteCart(theCart);

            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                var cartCount = (Label)e.Item.FindControl("lblCount");

                var data1 = (List<API_2._0.Model.CartInfo>)DataList1.DataSource;

                var countSum = data1.Sum(x => x.Quantity);

                cartCount.Text = countSum.ToString();
            }

            if (e.Item.ItemType == ListItemType.Footer)
            {
                var cartTotal = (Label)e.Item.FindControl("lblCartTotal");

                var data = (List<API_2._0.Model.CartInfo>)DataList1.DataSource;

                var cartSum = data.Sum(x => x.ProductPrice);

                cartTotal.Text = cartSum.ToString("C");
            }


        }
    }
}