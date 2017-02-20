<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminProducts.aspx.cs" Inherits="MyProject.Admin.adminProducts" MasterPageFile="~/Admin/AdminMaster.Master" %>


<asp:Content ID="addNew" runat="server" ContentPlaceHolderID="btnPlaceholder">
    <asp:LinkButton ID="btnAddNew" CssClass="addNew" runat="server" OnClick="btnAddNew_Click" Text="Add New Product"></asp:LinkButton>
</asp:Content>

<asp:Content ID="contentMain" runat="server" ContentPlaceHolderID="content2">           
            <asp:GridView runat="server" ID="adminGrid" AutoGenerateColumns="false" OnRowEditing="adminGrid_RowEditing" OnRowUpdating="adminGrid_RowUpdating"
                OnRowDeleting="adminGrid_RowDeleting" OnRowCancelingEdit="adminGrid_RowCancelingEdit" OnRowCommand="adminGrid_RowCommand">
                <Columns>
                    <asp:CommandField ButtonType="Link" EditText="Edit" ShowEditButton="true" ShowDeleteButton="true" DeleteText="Delete" />
                    <asp:TemplateField HeaderText="ProductId">
                        <ItemTemplate>
                            <asp:Label ID="lblProductId" runat="server" Text='<%#Eval ("Id") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblProductId" runat="server" Text='<%# Bind ("Id") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="label2" runat="server" Text='<%#Eval ("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProductName" runat="server" Text='<%# Bind ("Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <asp:Label ID="label3" runat="server" Text='<%#Eval ("Price", "{0:C}") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind ("Price", "{0:2}") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image Location">
                        <ItemTemplate>
                            <asp:Label ID="label4" runat="server" Text='<%#Eval ("Photo") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPhoto" runat="server" Text='<%# Bind ("Photo") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="label5" runat="server" Text='<%#Eval ("Quantity") %>'></asp:Label>
                        </ItemTemplate>
                         <EditItemTemplate>
                             <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Bind ("Quantity") %>'></asp:TextBox>
                         </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Revenue">
                        <ItemTemplate>
                            <asp:Label ID="label6" runat="server" Text='<%#Eval ("Revenue", "{0:C}") %>'></asp:Label>
                        </ItemTemplate>
                         <EditItemTemplate>
                             <asp:TextBox ID="txtRevenue" runat="server" Text='<%# Bind ("Revenue", "{0,2}") %>'></asp:TextBox>
                         </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="UPC Code">
                        <ItemTemplate>
                            <asp:Label ID="label7" runat="server" Text='<%#Eval ("UPC_Code") %>'></asp:Label>
                        </ItemTemplate>
                         <EditItemTemplate>
                             <asp:TextBox ID="txtUPC" runat="server" Text='<%# Bind ("UPC_Code") %>'></asp:TextBox>
                         </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ProductTypeId">
                        <ItemTemplate>
                            <asp:Label ID="label8" runat="server" Text='<%#Eval ("ProductTypeId") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                             <asp:TextBox ID="txtTypeId" runat="server" Text='<%# Bind ("ProductTypeId") %>'></asp:TextBox>
                         </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>     
</asp:Content>

