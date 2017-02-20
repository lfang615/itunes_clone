<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="MyProject.Admin.Profile" MasterPageFile="~/User/UserMaster.Master" %>

<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="content2">
    <h2 id="profileHeader">Edit Account Information
    </h2>

    <div class="profileForm">
        <div class="editProfile">
            <p class="editInfo">New Password:</p>
            <asp:TextBox ID="txtUser" runat="server" CssClass="txtEdit" TextMode="Password"></asp:TextBox>
        </div>
        <div class="editProfile">
            <p class="editInfo">Re-enter New Password:</p>
            <asp:TextBox ID="txtPass" runat="server" CssClass="txtEdit" TextMode="Password"></asp:TextBox>
        </div>
        <div class="editProfile">
            <p class="editInfo">Phone Number:</p>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="txtEdit"></asp:TextBox>
        </div>
        <div class="editProfile">
            <p class="editInfo">Email:</p>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="txtEdit"></asp:TextBox>
        </div>
    </div>
</asp:Content>
