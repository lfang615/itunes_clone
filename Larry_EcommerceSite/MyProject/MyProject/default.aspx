<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="MyProject.index" MasterPageFile="~/Site.Master" MaintainScrollPositionOnPostback="true" %>




<asp:Content ID="contentHead" runat="server" ContentPlaceHolderID="head">
</asp:Content>

<asp:Content ID="contentMain" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="main">
        <div class="slideshow">
            <div class="slide">
                <asp:ImageButton ID="slideMen" runat="server" class="slideImg" OnClick="slideMen_Click" ImageUrl="~/Images/ShopMen1.1.jpg" />
            </div>
            <div class="slide">
                <asp:ImageButton ID="slideWomen" runat="server" CssClass="slideImg" OnClick="slideWomen_Click" ImageUrl="~/Images/ShopWomen1.1.jpg" />
            </div>
        </div>


        <div class="imgLinks">
            <div class="imgLinkItem">
                <asp:ImageButton ID="saleLink" runat="server" CssClass="Links" OnClick="saleLink_Click" ImageUrl="~/Images/SaleLink2.jpg" />
            </div>
            <div class="imgLinkItem">
                <asp:ImageButton ID="shopAll" runat="server" CssClass="Links" OnClick="shopAll_Click" ImageUrl="~/Images/ShopAllLink2.jpg" />
            </div>
            <div class="imgLinkItem">
                <asp:ImageButton ID="trendLink" runat="server" CssClass="Links" OnClick="trendLink_Click" ImageUrl="~/Images/TrendLink2.jpg" />
            </div>
            <div class="lblLinks">
                <label id="lblSale">Shop Sale</label>
            </div>
            <div class="lblLinks">
                <label id="lblShopAll">Shop All</label>
            </div>
            <div class="lblLinks">
                <label id="lblTrend">Shop Trending</label>
            </div>
        </div>



        <div id="trendingItems">
            <h2 id="logoTrend">Trending Fashion</h2>
            <hr />
            <asp:ListView ID="lvItems" runat="server" GroupItemCount="5" OnItemCommand="lvItems_ItemCommand">
                <ItemTemplate>
                    <div class="trendContainer">
                        <div class="popupContainer">
                            <asp:Label ID="itemId" CssClass="itemIdHidden" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                            <asp:Label ID="productId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                            <div class="popupItem">
                                <asp:Image ID="picItem" runat="server" ImageUrl='<%# Eval("Photo") %>'></asp:Image>
                            </div>
                            <div class="popupItem">
                                <asp:Label ID="nameItem" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                            </div>
                            <div class="popupItem">
                                <asp:Label ID="priceItem" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="qvHome">
                            <asp:LinkButton ID="btnPopup" CssClass="btnPopupView" runat="server" Text="Quick View" CommandName="ShowPopup"></asp:LinkButton>
                        </div>
                    </div>
                </ItemTemplate>

                <LayoutTemplate>
                    <div id="layoutTemplate" class="mainTrendTemplate" runat="server">
                        <div id="groupPlaceholder" runat="server">
                        </div>
                    </div>
                </LayoutTemplate>

                <GroupTemplate>
                    <div id="groupTemplate" class="groupForm" runat="server">
                        <div id="itemPlaceholder" runat="server">
                        </div>
                    </div>
                </GroupTemplate>
            </asp:ListView>
        </div>

        <asp:Panel ID="panelPopUp" runat="server" Visible="false">
            <div class="overlay-bg"></div>
            <div class="popupMain">
                <asp:Label ID="idItem" CssClass="idItem" runat="server"></asp:Label>
                <asp:Image ID="picItem1" CssClass="picItem1" runat="server" />
                <asp:Label ID="nameItem" CssClass="nameItem" runat="server"></asp:Label>
                <asp:Label ID="priceItem1" CssClass="priceItem1" runat="server"></asp:Label>
                <label class="lblQuantity">Quantity: </label>
                <asp:DropDownList ID="ddlQuantity" runat="server" CssClass="quantitySelect"></asp:DropDownList>
                <asp:LinkButton ID="btnAddToCart" runat="server" CssClass="btnCart" Text="Add To Cart" OnClick="btnAddToCart_Click"></asp:LinkButton>
                <asp:ImageButton ID="btnClose" CssClass="btnClose" runat="server" OnClick="btnClose_Click" ImageUrl="~/Images/close.png" />
            </div>
        </asp:Panel>

    </div>
</asp:Content>





