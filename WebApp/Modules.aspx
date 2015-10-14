<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Modules.aspx.cs" Inherits="WebApp.Modules" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid text-center">
        <div class="well row" style="background-color: rgba(255, 255, 255, 0.7)">
            <h3>Module Management</h3>
            <br />
            <asp:Button ID="btnAddModule" runat="server" Text="Add module" CssClass="btn btn-success" OnClick="btnAddModule_Click" />
            <br />
            <table class="table-spacing">
                <tr><td><asp:RadioButton ID="rdoShowEnabled" runat="server" Text="Display Enabled Modules" ToolTip="Check this box to display the enabled modules only" Checked="True" GroupName="ModuleDisplay" OnCheckedChanged="rdoShowEnabled_CheckedChanged" AutoPostBack="True" /><br /></td>
                <td><asp:RadioButton ID="rdoShowDisabled" runat="server" Text="Display Deleted Modules" ToolTip="Check this box to display disabled modules only" GroupName="ModuleDisplay" OnCheckedChanged="rdoShowDisabled_CheckedChanged" AutoPostBack="True" /><br /></td></tr>
            </table>
            <br />
            <div class="table-responsive">
                <table class="table table-hover table-striped tablesorter align-left">
                    <asp:Literal ID="litModuleList" runat="server"></asp:Literal>
                </table>
            </div>
            <asp:Literal ID="litAlert" runat="server"></asp:Literal>
            <br />
            
        </div>
    </div>
</asp:Content>
