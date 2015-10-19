<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="rollcallHistory.aspx.cs" Inherits="WebApp.rollcallHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid text-center">
        <div class="well row" style="background-color: rgba(255, 255, 255, 0.7)">
            <h3>Roll Call History</h3>
            <br />
            <div class="col-md-6 col-md-offset-3">
                <div>
                    <div>
                        
                        <asp:DropDownList ID="dlModules" CssClass="btn btn-lg btn-info" runat="server"></asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnGetHistory" CssClass="btn btn-lg btn-success" runat="server" Text="View History" OnClick="btnGetHistory_Click" />
                        <br /><br />
                        <div class="table-responsive">
                            <table class="table table-hover table-striped tablesorter align-left">
                                <asp:Literal ID="litRollCallList" runat="server"></asp:Literal>
                            </table>
                        </div>
                        <asp:Literal ID="litAlert" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
