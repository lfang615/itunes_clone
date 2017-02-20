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
    public partial class Mens : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                for (int i = 0; i <= 15; i++)
                {
                    ddlQuantity.Items.Add(i.ToString());
                }

                lvItems.DataSource = GetProductData();
                lvItems.DataBind();
            }
        }

        protected void lvItems_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowPopUp")
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

        protected void ddlSorting_SelectedIndexChanged(object sender, EventArgs e)
        {
            var data = GetProductData();
            if (ddlSorting.SelectedValue == "SortAsc")
            {
                data = data.OrderBy(x => x.Name).ToList();
            }
            else if (ddlSorting.SelectedValue == "SortDesc")
            {
                data = data.OrderByDescending(x => x.Name).ToList();
            }
            else if (ddlSorting.SelectedValue == "PriceAsc")
            {
                data = data.OrderBy(x => x.Price).ToList();
            }
            else if (ddlSorting.SelectedValue == "PriceDesc")
            {
                data = data.OrderByDescending(x => x.Price).ToList();
            }

            lvItems.DataSource = data;
            lvItems.DataBind();
        }

        private List<Product> GetProductData()
        {
            ProductManager manager = new ProductManager();

            if (Request.QueryString["typeid"] == null)
            {
                var data = manager.GetProductsByGender(1).OrderBy(x => x.Name).ToList();
                return data;
            }
            else
            {
                int typeId = int.Parse(Request.QueryString["typeid"].ToString());
                var data = manager.GetProductsByTypeId(typeId).OrderBy(x => x.Name).ToList();
                return data;
            }
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