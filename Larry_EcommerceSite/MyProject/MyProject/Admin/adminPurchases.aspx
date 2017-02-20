<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminPurchases.aspx.cs" Inherits="MyProject.adminPurchases" MasterPageFile="~/Admin/AdminMaster.Master" %>

<asp:Content ID="addNew" runat="server" ContentPlaceHolderID="btnPlaceholder">
    <asp:LinkButton ID="btnAddNew" CssClass="addNew" runat="server" OnClick="btnAddNew_Click" Text="Add New Purchase"></asp:LinkButton>
</asp:Content>
<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="content2">
    <asp:GridView runat="server" ID="adminGrid" AutoGenerateColumns="false" OnRowEditing="adminGrid_RowEditing" OnRowUpdating="adminGrid_RowUpdating"
        OnRowDeleting="adminGrid_RowDeleting" OnRowCancelingEdit="adminGrid_RowCancelingEdit">
        <Columns>
            <asp:CommandField ButtonType="Link" EditText="Edit" ShowEditButton="true" ShowDeleteButton="true" DeleteText="Delete" />
            <asp:TemplateField HeaderText="Purchase Id">
                <ItemTemplate>
                    <asp:Label ID="lblPurchaseId" runat="server" Text='<%#Eval ("Id") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblPurchaseId" runat="server" Text='<%# Bind ("Id") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total Amount">
                <ItemTemplate>
                    <asp:Label ID="label2" runat="server" Text='<%#Eval ("Amount") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAmount" runat="server" Text='<%# Bind ("Amount") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Label ID="label3" runat="server" Text='<%#Eval ("Quantity") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Bind ("Quantity") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Id">
                <ItemTemplate>
                    <asp:Label ID="label4" runat="server" Text='<%#Eval ("ProductId") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductId" runat="server" Text='<%# Bind ("ProductId") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Customer Id">
                <ItemTemplate>
                    <asp:Label ID="label5" runat="server" Text='<%#Eval ("CustomerId") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCustomerId" runat="server" Text='<%# Bind ("CustomerId") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
