<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminRoleTypes.aspx.cs" Inherits="MyProject.adminRoleTypes" MasterPageFile="~/Admin/AdminMaster.Master" %>

<asp:Content ID="addNew" runat="server" ContentPlaceHolderID="btnPlaceholder">
    <asp:LinkButton ID="btnAddNew" CssClass="addNew" runat="server" OnClick="btnAddNew_Click" Text="Add New Role Type"></asp:LinkButton>
</asp:Content>
<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="content2">
    <asp:GridView runat="server" ID="adminGrid" AutoGenerateColumns="false" OnRowEditing="adminGrid_RowEditing" OnRowUpdating="adminGrid_RowUpdating"
        OnRowDeleting="adminGrid_RowDeleting" OnRowCancelingEdit="adminGrid_RowCancelingEdit">
        <Columns>
            <asp:CommandField ButtonType="Link" EditText="Edit" ShowEditButton="true" ShowDeleteButton="true" DeleteText="Delete" />
            <asp:TemplateField HeaderText="Role Type Id">
                <ItemTemplate>
                    <asp:Label ID="lblRoleTypeId" runat="server" Text='<%#Eval ("Id") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblRoleTypeId" runat="server" Text='<%# Bind ("Id") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Role Name">
                <ItemTemplate>
                    <asp:Label ID="label2" runat="server" Text='<%#Eval ("Name") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind ("Name") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
