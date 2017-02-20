<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mens.aspx.cs" Inherits="MyProject.Mens" MasterPageFile="~/Site.Master" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="headContent" runat="server" ContentPlaceHolderID="head">
</asp:Content>

<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="main">
        <div class="ddlFilter">
            <label for="#ddlSorting">Sort:</label>
            <asp:DropDownList ID="ddlSorting" CssClass="ddlSorting" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSorting_SelectedIndexChanged">
                <asp:ListItem Text="Alphabetically 'A-Z'" Value="SortAsc"></asp:ListItem>
                <asp:ListItem Text="Alphabetically 'Z-A" Value="SortDesc"></asp:ListItem>
                <asp:ListItem Text="Price Low to High" Value="PriceAsc"></asp:ListItem>
                <asp:ListItem Text="Price High to Low" Value="PriceDesc"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <asp:ListView ID="lvItems" runat="server" GroupItemCount="3" OnItemCommand="lvItems_ItemCommand">
            <ItemTemplate>
                <div class="itemContainer">
                    <div class="qvContainer" id="qvContain">
                        <asp:Label ID="itemId" CssClass="itemIdHidden" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                        <div class="qvContainItem">
                            <asp:Image ID="picItem" runat="server" ImageUrl='<%#Eval("Photo") %>'></asp:Image>
                        </div>
                        <div class="qvContainItem">
                            <asp:Label ID="nameItem" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                        </div>
                        <div class="qvContainItem">
                            <asp:Label ID="priceItem" runat="server" Text='<%#Eval("Price")%>'></asp:Label>
                        </div>
                    </div>
                    <div class="qv" id="qvBG">
                        <asp:LinkButton ID="btnQuickView" CssClass="btnClassQV" runat="server" Text="Quick View" CommandName="ShowPopUp"></asp:LinkButton>
                    </div>
                </div>
            </ItemTemplate>

            <LayoutTemplate>
                <div id="layoutTemplate" class="mainTemplate" runat="server">
                    <div id="groupPlaceholder" runat="server">
                    </div>
                </div>
            </LayoutTemplate>

            <GroupTemplate>
                <div id="groupTemplate" class="groupColumn" runat="server">
                    <div id="itemPlaceholder" runat="server">
                    </div>
                </div>
            </GroupTemplate>


        </asp:ListView>

        <asp:Panel ID="panelPopUp" runat="server" Visible="false">
            <div class="overlay-bg"></div>
            <div class="popupMain">
                <asp:Label ID="idItem" CssClass="idItem" runat="server"></asp:Label>
                <asp:Image ID="picItem1" CssClass="picItem1" runat="server" />
                <asp:Label ID="nameItem" CssClass="nameItem" runat="server"></asp:Label>
                <asp:Label ID="priceItem1" CssClass="priceItem1" runat="server"></asp:Label>
                <label class="lblQuantity">Quantity: </label>
                <asp:DropDownList ID="ddlQuantity" runat="server" CssClass="quantitySelect"></asp:DropDownList>
                <asp:LinkButton ID="btnAddToCart" runat="server" CssClass="btnCart" Text="Add To Cart" OnClick="btnAddToCart_Click" ></asp:LinkButton>
                <asp:ImageButton ID="btnClose" CssClass="btnClose" runat="server" OnClick="btnClose_Click" ImageUrl="~/Images/close.png" />
            </div>
        </asp:Panel>


    </div>
</asp:Content>
