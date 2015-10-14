<%@ Page Title="" Language="C#" MasterPageFile="~/GuestPage.Master" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="WebApp.Recover" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid text-center">
        <div class="well row" style="background-color: rgba(255, 255, 255, 0.7)">
            <h3>Please enter your email address</h3>
            <br /><br />
            <asp:Literal ID="litAlert" runat="server"></asp:Literal>

            <div class="col-md-4 col-md-offset-4">
                <div>
                    <div>
                            <fieldset>
                                <div class="form-group">
                                    <input id="txtEmail" runat="server" clientidmode="Static" class="form-control required-field" placeholder="E-mail" type="email" required="required" autofocus="autofocus" />
                                </div>
                                <div class="form-group">
                                    <input id="txtPassword" runat="server" clientidmode="Static" class="form-control required-field" placeholder="Password" type="password" required="required" />
                                </div>                               
                                <asp:Button ID="btnRecoverPassword" runat="server" CssClass="btn btn-lg btn-success" Text="Recover Password" OnClick="btnRecoverPassword_Click" />
                            </fieldset>
                        
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
