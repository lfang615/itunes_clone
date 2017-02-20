<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminUsers.aspx.cs" Inherits="MyProject.adminUsers" MasterPageFile="~/Admin/AdminMaster.Master" %>


<asp:Content ID="addNew" runat="server" ContentPlaceHolderID="btnPlaceholder">
    <asp:LinkButton ID="btnAddNew" CssClass="addNew" runat="server" OnClick="btnAddNew_Click" Text="Add New User"></asp:LinkButton>
</asp:Content>
<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="content2">
    <asp:GridView runat="server" ID="adminGrid" AutoGenerateColumns="false" OnRowEditing="adminGrid_RowEditing" OnRowUpdating="adminGrid_RowUpdating"
        OnRowDeleting="adminGrid_RowDeleting" OnRowCancelingEdit="adminGrid_RowCancelingEdit">
        <Columns>
            <asp:CommandField ButtonType="Link" EditText="Edit" ShowEditButton="true" ShowDeleteButton="true" DeleteText="Delete" />
            <asp:TemplateField HeaderText="User Id">
                <ItemTemplate>
                    <asp:Label ID="lblUserId" runat="server" Text='<%#Eval ("Id") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblUserId" runat="server" Text='<%# Bind ("Id") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Full Name">
                <ItemTemplate>
                    <asp:Label ID="label2" runat="server" Text='<%#Eval ("FulName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtFullName" runat="server" Text='<%# Bind ("FulName") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Username">
                <ItemTemplate>
                    <asp:Label ID="label3" runat="server" Text='<%#Eval ("Username") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtUsername" runat="server" Text='<%# Bind ("Username") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Password">
                <ItemTemplate>
                    <asp:Label ID="label4" runat="server" Text='<%#Eval ("Password") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPassword" runat="server" Text='<%# Bind ("Password") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Salt">
                <ItemTemplate>
                    <asp:Label ID="label5" runat="server" Text='<%#Eval ("Salt") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtSalt" runat="server" Text='<%# Bind ("Salt") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <asp:Label ID="label6" runat="server" Text='<%#Eval ("Email") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind ("Email") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Last IP">
                <ItemTemplate>
                    <asp:Label ID="label7" runat="server" Text='<%#Eval ("LastIP") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtLastIp" runat="server" Text='<%# Bind ("LastIP") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Security Q1">
                <ItemTemplate>
                    <asp:Label ID="label8" runat="server" Text='<%#Eval ("SecurityQ1") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtSecurityQ1" runat="server" Text='<%# Bind ("SecurityQ1") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Security A1">
                <ItemTemplate>
                    <asp:Label ID="label9" runat="server" Text='<%#Eval ("SecurityQA") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtSecurityA1" runat="server" Text='<%# Bind ("SecurityQA") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Security Q2">
                <ItemTemplate>
                    <asp:Label ID="label0" runat="server" Text='<%#Eval ("SecurityQ2") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtSecurityQ2" runat="server" Text='<%# Bind ("SecurityQ2") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Security A2">
                <ItemTemplate>
                    <asp:Label ID="label11" runat="server" Text='<%#Eval ("SecurityA2") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtSecurityA2" runat="server" Text='<%# Bind ("SecurityA2") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Customer Id">
                <ItemTemplate>
                    <asp:Label ID="label12" runat="server" Text='<%#Eval ("CustomerId") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCustomerId" runat="server" Text='<%# Bind ("CustomerId") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
