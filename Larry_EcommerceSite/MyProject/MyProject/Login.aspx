<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyProject.Login" MasterPageFile="~/Site.Master" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="headContent" runat="server" ContentPlaceHolderID="head">
</asp:Content>

<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="main">
        <div class="formContainer">
            <div class="loginForm">
                <p class="loginHeader">Return Customers</p>
                <asp:Label id="lblError1" runat="server" ForeColor="Red"> </asp:Label>
                <div class="user">
                    <p class="userInfo">Username</p>
                    <asp:TextBox ID="txtUser" CssClass="txtInfo" runat="server"></asp:TextBox>
                </div>
                <div class="user">
                    <p class="userInfo">Password</p>
                    <asp:TextBox ID="txtPass" CssClass="txtInfo" TextMode="Password" runat="server"></asp:TextBox>
                </div>
                <div class="btnL">
                    <asp:LinkButton ID="btnLog" CssClass="btnLog1" runat="server" Text="Login" OnClick="btnLogin_Click1"></asp:LinkButton>
                </div>
            </div>

            <div class="registerForm">
                <p class="loginHeader">New Customers</p>
                <div class="user">
                    <p class="userInfo">Username</p>
                    <asp:TextBox ID="txtNewUser" runat="server" CssClass="txtInfo"></asp:TextBox>
                </div>
                <div class="user">
                    <p class="userInfo">Password</p>
                    <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" CssClass="txtInfo"></asp:TextBox>
                </div>
                <div class="user">
                    <p class="userInfo">First Name</p>
                    <asp:TextBox ID="txtFName" runat="server" CssClass="txtInfo"></asp:TextBox>
                </div>
                 <div class="user">
                    <p class="userInfo">Last Name</p>
                    <asp:TextBox ID="txtLName" runat="server" CssClass="txtInfo"></asp:TextBox>
                </div>
                <div class="user">
                    <p class="userInfo">Email</p>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="txtInfo"></asp:TextBox>
                </div>
                <div class="user">
                    <p class="userInfo">Data of Birth <b>(Enter in MM/DD/YYYY format)</b></p>
                    <asp:TextBox ID="txtDob" runat="server" CssClass="txtInfo"></asp:TextBox>
                </div>
                <div class="user">
                    <p>Security Questions</p>
                </div>
                <div class="user">
                    <p class="userInfo">Enter your mother's maiden name.</p>
                    <asp:TextBox ID="txtA1" runat="server" CssClass="txtInfo"></asp:TextBox>
                </div>
                <div class="user">
                    <p class="userInfo">Enter the last name of your childhood best friend.</p>
                    <asp:TextBox ID="txtA2" runat="server" CssClass="txtInfo"></asp:TextBox>
                </div>
                <div class="btnL">
                    <asp:LinkButton ID="btnRegister" CssClass="btnLog1" runat="server" OnClick="btnRegister_Click" Text="Register"></asp:LinkButton>
                </div>
                <div>
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
