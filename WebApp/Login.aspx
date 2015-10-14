<%@ Page Title="" Language="C#" MasterPageFile="~/GuestPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">       
    <div class="container-fluid text-center">
        <div class="well row" style="background-color: rgba(255, 255, 255, 0.7)">
            <h3>Please Sign In</h3>
            <br/>
            
            <div class="col-md-4 col-md-offset-4">
                <div>
                    <div>
                            <fieldset>
                                <asp:Literal ID="litAlert" runat="server"></asp:Literal>

                                <div class="form-group">
                                    <input id="txtEmail" runat="server" class="form-control required-field" placeholder="E-mail" type="email" required="required" autofocus="autofocus" />
                                </div>
                                <div class="form-group">
                                    <input id="txtPassword" runat="server" class="form-control required-field" placeholder="Password" type="password" required="required" />
                                </div>
                                <asp:Button ID="btnLogin" CssClass="btn btn-lg btn-success btn-block" runat="server" Text="Login" OnClick="btnLogin_Click" />
                                <br />
                                &nbsp;
                                <a href="Register.aspx" class="btn btn-lg btn-warning">Register</a>
                                &nbsp;&nbsp;
                                <a href="RecoverPassword.aspx" class="btn btn-lg btn-warning">Recover Password</a>
                            </fieldset>
                        
                    </div>
                </div>
            </div>
            <br />
            
        </div>
    </div>
</asp:Content>
