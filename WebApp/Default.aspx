<%@ Page Title="" Language="C#" MasterPageFile="~/GuestPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid text-center">
        <div class="well row" style="background-color: rgba(255, 255, 255, 0.7)">
            <h3>Please Sign In</h3>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn-success btnHome" Width="250px" Height="50px" OnClick="btnLogin_Click" /><br /><br />
            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn-success btnHome" Width="250px" Height="50px" OnClick="btnRegister_Click" /><br /><br />
        </div>
    </div>
</asp:Content>
