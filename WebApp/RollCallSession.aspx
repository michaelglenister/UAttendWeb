<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RollCallSession.aspx.cs" Inherits="WebApp.RollCallSession" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid text-center">
        <div class="well row" style="background-color: rgba(255, 255, 255, 0.7)">
            <h3>Roll Call Session</h3>
            <br />
            
            <div class="col-md-4 col-md-offset-4">
                <div>
                    <div>
                        <asp:DropDownList ID="dlModules" CssClass="btn btn-lg btn-info" runat="server"></asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnBeginRollCall" CssClass="btn btn-lg btn-success" runat="server" Text="Begin" OnClick="btnBeginRollCall_Click" />
                        <asp:Literal ID="litHeadSpace" runat="server" Text="<br /><br />"></asp:Literal>

                        <asp:Button ID="btnPauseRollCall" CssClass="btn btn-lg btn-warning" runat="server" Text="Pause Roll Call" Visible="False" OnClick="btnPauseRollCall_Click" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnEndRollCall" CssClass="btn btn-lg btn-danger" runat="server" Text="End Roll Call" Visible="False" OnClick="btnEndRollCall_Click" />
                        <br /><br />
                        <h3><asp:Literal ID="litPin" runat="server"></asp:Literal></h3>
                        <br /><br />
                    </div>
                </div>
            </div>
            
            <asp:Image ID="QRcode" runat="server" Height="640px" Width="640px"  />
            
        </div>
    </div>
</asp:Content>
