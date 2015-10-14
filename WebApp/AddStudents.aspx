<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddStudents.aspx.cs" Inherits="WebApp.AddStudents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid text-center">
        <div class="well row" style="background-color: rgba(255, 255, 255, 0.7)">
            <h3>Add students to Module</h3>
            <br />

            <div class="col-md-4 col-md-offset-4">
                <div>
                    <div>
                        <asp:Literal ID="litHeader" runat="server"></asp:Literal>
                        <br />
                        <asp:FileUpload ID="fileUploadControl" runat="server" CssClass ="btn btn-primary btn-block" ToolTip="Use this to add a list of students" />
                        <br /><br />
                        <asp:Button ID="btnAddStudents" runat="server" Text="Add students" CssClass="btn btn-lg btn-success" OnClick="btnAddStudents_Click" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnModules" runat="server" Text="Skip this step" CssClass="btn btn-lg btn-warning" OnClick="btnModules_Click" />
                        <br /><br /><br />
                        <asp:Label ID="lblProgress" runat="server" Text="" CssClass="alert alert-danger"></asp:Label>
                    </div>
                </div>
            </div>

            
        </div>
    </div>
</asp:Content>
