<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="WebApp.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid text-center">
        <div class="well row" style="background-color: rgba(255, 255, 255, 0.7)">
            <h3>Update Profile Details</h3>

            <br/>
            <asp:Literal ID="litAlert" runat="server"></asp:Literal>
            
            <div class="col-md-4 col-md-offset-4">
                <div>
                    <div>
                            <fieldset>
                                <div class="form-group text-left">
                                    <label>E-Mail:</label>
                                    <input id="txtEmail" runat="server" class="form-control required-field" placeholder="E-mail" type="email" required="required" />
                                </div>
                                <div class="form-group text-left">
                                    <label>Firstname:</label>
                                    <input id="txtFirstName" runat="server" class="form-control required-field" placeholder="Firstname" type="text" required="required" />
                                </div>
                                <div class="form-group text-left">
                                    <label>Surname:</label>
                                    <input id="txtSurname" runat="server" class="form-control required-field" placeholder="Surname" type="text" required="required" />
                                </div>

                                <br />
                                <h3>Change Password</h3>

                                <div class="form-group">
                                    <input id="txtPassword" runat="server" class="form-control" placeholder="New Password" type="password" />
                                </div>
                                <div class="form-group">
                                    <input id="txtConfirmPassword" runat="server" class="form-control" placeholder="Re-Enter New Password" type="password" />
                                </div>
                                <br />
                                <asp:Button ID="btnUpdateProfile" runat="server" Text="Update Profile" CssClass="btn btn-success" OnClick="btnUpdateProfile_Click" />
                            </fieldset>
                    </div>
                </div>
            </div>

            
                
            
        </div>
    </div>
</asp:Content>
