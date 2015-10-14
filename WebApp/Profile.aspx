<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebApp.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid text-center">
        <div class="well row" style="background-color: rgba(255, 255, 255, 0.7)">
            <h3><asp:Literal ID="litLecturerName" runat="server"></asp:Literal></h3>
            <br />
            
            <asp:Literal ID="litAlert" runat="server"></asp:Literal>
            
            <div class="col-md-4 col-md-offset-4">
                <div>
                    <div>
                            <fieldset>
                                <div class="form-group text-left">
                                    <label>E-Mail:</label>
                                    <input id="txtEmail" runat="server" class="form-control" placeholder="E-mail" type="email" disabled="disabled" />
                                </div>
                                <div class="form-group text-left">
                                    <label>Firstname:</label>
                                    <input id="txtFirstName" runat="server" class="form-control" placeholder="Firstname" type="text" disabled="disabled" />
                                </div>
                                <div class="form-group text-left">
                                    <label>Surname:</label>
                                    <input id="txtSurname" runat="server" class="form-control" placeholder="Surname" type="text" disabled="disabled" />
                                </div>

                                <br />
                                <asp:Button ID="btnUpdateProfile" runat="server" Text="Update Profile" CssClass="btn btn-warning" OnClick="btnUpdateProfile_Click" />
                            </fieldset>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
