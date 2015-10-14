<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WebApp.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid text-center">
        <div class="well row" style="background-color: rgba(255, 255, 255, 0.7)">
            <h3>Welcome to UAttend</h3>
            <br />
            <div class="alert alert-success alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                <asp:Literal ID="litMotd" Text="Message of the day" runat="server"></asp:Literal>
            </div>
            
            <br />
            <asp:Literal ID="litAdminMenu" runat="server"></asp:Literal>
           
        </div>
    </div>
</asp:Content>
