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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                for (int i = 0; i <= 15; i++)
                {
                    ddlQuantity.Items.Add(i.ToString());
                }
               
                BindData();
            }
        }

        protected void BindData()
        {
            ProductManager manager = new ProductManager();

            var data = manager.GetProductsByTypeName("Trending");

            lvItems.DataSource = data;
            lvItems.DataBind();
          
        }

        protected void slideMen_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Mens.aspx");
        }

        protected void slideWomen_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Womens.aspx");
        }

        protected void saleLink_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Unisex.aspx?typeName=Sale");
        }

        protected void shopAll_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Unisex.aspx");
        }

        protected void trendLink_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Unisex.aspx?typeName=Trending");
        }

        protected void lvItems_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
           
            if (e.CommandName == "ShowPopup")
            {

                var id = (Label)e.Item.FindControl("itemId");
                var photo = (Image)e.Item.FindControl("picItem");
                var name = (Label)e.Item.FindControl("nameItem");
                var price = (Label)e.Item.FindControl("priceItem");

                idItem.Text = id.Text;
                picItem1.ImageUrl = photo.ImageUrl;
                nameItem.Text = name.Text;
                priceItem1.Text = price.Text;

                panelPopUp.Visible = true;
            }
        }

        protected void btnClose_Click(object sender, ImageClickEventArgs e)
        {
            panelPopUp.Visible = false;

        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            CartManager cartManager = new CartManager();
            UserManager userManager = new UserManager();



            int id = int.Parse(idItem.Text);
            string name = nameItem.Text;
            Image pic = picItem1;
            string price = priceItem1.Text;
            decimal price2 = decimal.Parse(price);
            int quantity = int.Parse(ddlQuantity.SelectedValue);
            string userName = Page.User.Identity.Name;
            Data.User theUser = userManager.GetUserByUsername(userName);
            int custId = theUser.Id;
            decimal total = quantity * price2;

            cartManager.CreateCart(custId, id, quantity, total);
        }
    }
}