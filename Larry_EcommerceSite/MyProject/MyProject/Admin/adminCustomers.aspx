<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminCustomers.aspx.cs" Inherits="MyProject.adminCustomers" MasterPageFile="~/Admin/AdminMaster.Master" %>

<asp:Content ID="addNew" runat="server" ContentPlaceHolderID="btnPlaceholder">
    <asp:LinkButton ID="btnAddNew" CssClass="addNew" runat="server" OnClick="btnAddNew_Click" Text="Add New Customer"></asp:LinkButton>
</asp:Content>
<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="content2">
            <asp:GridView runat="server" ID="adminGrid" AutoGenerateColumns="false" OnRowEditing="adminGrid_RowEditing" OnRowUpdating="adminGrid_RowUpdating"
                OnRowDeleting="adminGrid_RowDeleting" OnRowCancelingEdit="adminGrid_RowCancelingEdit">
                <Columns>
                    <asp:CommandField ButtonType="Link" EditText="Edit" ShowEditButton="true" ShowDeleteButton="true" DeleteText="Delete" />
                    <asp:TemplateField HeaderText="Customer Id">
                        <ItemTemplate>
                            <asp:Label ID="lblCustomerId" runat="server" Text='<%#Eval ("Id") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblCustomerId" runat="server" Text='<%# Bind ("Id") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="First Name">
                        <ItemTemplate>
                            <asp:Label ID="label2" runat="server" Text='<%#Eval ("FName") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFName" runat="server" Text='<%# Bind ("FName") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Name">
                        <ItemTemplate>
                            <asp:Label ID="label3" runat="server" Text='<%#Eval ("LName") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLName" runat="server" Text='<%# Bind ("LName") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Birthday">
                        <ItemTemplate>
                            <asp:Label ID="label4" runat="server" Text='<%#Eval ("Birthday") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtBirthday" runat="server" Text='<%# Bind ("Birthday") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone Number">
                        <ItemTemplate>
                            <asp:Label ID="label5" runat="server" Text='<%#Eval ("PhoneNumber") %>'></asp:Label>
                        </ItemTemplate>
                         <EditItemTemplate>
                             <asp:TextBox ID="txtPhone" runat="server" Text='<%# Bind ("PhoneNumber") %>'></asp:TextBox>
                         </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address 1">
                        <ItemTemplate>
                            <asp:Label ID="label6" runat="server" Text='<%#Eval ("Address1") %>'></asp:Label>
                        </ItemTemplate>
                         <EditItemTemplate>
                             <asp:TextBox ID="txtAddress1" runat="server" Text='<%# Bind ("Address1") %>'></asp:TextBox>
                         </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address 2">
                        <ItemTemplate>
                            <asp:Label ID="label7" runat="server" Text='<%#Eval ("Address2") %>'></asp:Label>
                        </ItemTemplate>
                         <EditItemTemplate>
                             <asp:TextBox ID="txtAddress2" runat="server" Text='<%# Bind ("Address2") %>'></asp:TextBox>
                         </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="City">
                        <ItemTemplate>
                            <asp:Label ID="label8" runat="server" Text='<%#Eval ("City") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                             <asp:TextBox ID="txtCity" runat="server" Text='<%# Bind ("City") %>'></asp:TextBox>
                         </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="State">
                        <ItemTemplate>
                            <asp:Label ID="label9" runat="server" Text='<%#Eval ("State") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                             <asp:TextBox ID="txtState" runat="server" Text='<%# Bind ("State") %>'></asp:TextBox>
                         </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="City">
                        <ItemTemplate>
                            <asp:Label ID="label10" runat="server" Text='<%#Eval ("Zip") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                             <asp:TextBox ID="txtZip" runat="server" Text='<%# Bind ("Zip") %>'></asp:TextBox>
                         </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
</asp:Content>
