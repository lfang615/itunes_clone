<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Address.aspx.cs" Inherits="MyProject.User.Address" MasterPageFile="~/User/UserMaster.Master" %>

<asp:Content ID="maincontent" runat="server" ContentPlaceHolderID="content2">
     <h2 id="profileHeader">Edit Address Information
    </h2>

    <div class="profileForm">
        <div class="editProfile">
            <p class="editInfo">Address</p>
            <asp:TextBox ID="txtUser" runat="server" CssClass="txtEdit" TextMode="Password"></asp:TextBox>
        </div>
        <div class="editProfile">
            <p class="editInfo">Address Line 2</p>
            <asp:TextBox ID="txtPass" runat="server" CssClass="txtEdit" TextMode="Password"></asp:TextBox>
        </div>
        <div class="editProfile">
            <p class="editInfo">City</p>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="txtEdit"></asp:TextBox>
        </div>
        <div class="editProfile">
            <p class="editInfo">State</p>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="txtEdit"></asp:TextBox>
        </div>
    </div>
</asp:Content>
