<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RollCallSession.aspx.cs" Inherits="WebApp.RollCallSession" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function makeVisible() {
            document.getElementById("txtTime").style.visibility = "visible";
            document.getElementById("txtDate").style.visibility = "visible";
        }
        function makeInvisible() {
            document.getElementById("txtTime").style.visibility = "hidden";
            document.getElementById("txtDate").style.visibility = "hidden";
        }
    </script>
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
                        <asp:Button ID="btnBeginRollCall" CssClass="btn btn-lg btn-success" runat="server" Text="Begin" OnClick="btnBeginRollCall_Click" formnovalidate="formnovalidate"/>
                        
                        <input id='txtTime' runat='server' class='form - control required - field' placeholder='Minutes' type='time' required='required' visible="false"/>
                        <input id = 'txtDate' runat = 'server' class='form - control required - field' placeholder='Date' type='date' required='required' visible="false"/>
                        <br /><br />
                        <asp:Button ID="btnAutoDisable" CssClass="btn btn-lg btn-success" runat="server" Text="Set Auto Disable" Visible="False" OnClick="btnAutoDisable_Click" />
                        <br /><br />
                        <asp:Button ID="btnPauseRollCall" CssClass="btn btn-lg btn-warning" runat="server" Text="Pause Roll Call" Visible="False" OnClick="btnPauseRollCall_Click" formnovalidate="formnovalidate" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnEndRollCall" CssClass="btn btn-lg btn-danger" runat="server" Text="End Roll Call" Visible="False" OnClick="btnEndRollCall_Click" formnovalidate="formnovalidate" />
                        <br />
                        <h3><asp:Literal ID="litPin" runat="server"></asp:Literal></h3>
                        <br />
                    </div>
                </div>
            </div>
            
            <asp:Image ID="QRcode" runat="server" Height="640px" Width="640px"  />
            
        </div>
    </div>
</asp:Content>
