<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ToggleRollCall.aspx.cs" Inherits="WebApp.ToggleRollCall" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid text-center">
        <div class="well row" style="background-color: rgba(255, 255, 255, 0.7)">
            <h3>Toggle Roll Call Status</h3>
            <br />
            <div class="col-md-4 col-md-offset-4">
                <div>
                    <div>
                        <asp:Literal ID="litHeader" runat="server"></asp:Literal>
                        <br />
                        <asp:Button ID="btnConfirm" CssClass="btn btn-lg btn-success" runat="server" Text="Yes" OnClick="btnConfirm_Click" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnDeny" CssClass="btn btn-lg btn-danger" runat="server" Text="No" OnClick="btnDeny_Click" />
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
