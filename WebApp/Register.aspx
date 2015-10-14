<%@ Page Title="" Language="C#" MasterPageFile="~/GuestPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApp.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid text-center">
        <div class="well row" style="background-color: rgba(255, 255, 255, 0.7)">
            <h3>Please provide registration details</h3>
            <br />

            <div class="col-md-4 col-md-offset-4">
                <div>
                    <div>
                        
                            <fieldset>
                                <div class="form-group">
                                    <input id="txtEmail" runat="server" clientidmode="Static" class="form-control required-field" placeholder="E-mail" type="email" required="required" autofocus="autofocus" />
                                    <asp:Label ID="lblInvalidEmail" runat="server" Text="" CssClass="label label-danger"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <input id="txtPassword" runat="server" clientidmode="Static" class="form-control required-field" placeholder="Password" value="" type="password" required="required" />
                                </div>
                                <div class="form-group">
                                    <input id="txtConfirmPassword" runat="server" clientidmode="Static" class="form-control required-field" placeholder="Confirm Password" value="" type="password" required="required" />
                                    <asp:Label ID="lblConfirmPassword" runat="server" Text="" CssClass="label label-danger"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <input id="txtFirstName" runat="server" clientidmode="Static" class="form-control required-field" placeholder="First Name" value="" type="text" required="required" />
                                </div>
                                <div class="form-group">
                                    <input id="txtSurname" runat="server" clientidmode="Static" class="form-control required-field" placeholder="Surname" value="" type="text" required="required" />
                                </div>
                                <br />
                                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-lg btn-success btn-block" OnClick="btnRegister_Click" />
                            </fieldset>
                        
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
