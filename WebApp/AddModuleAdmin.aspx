<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddModuleAdmin.aspx.cs" Inherits="WebApp.AddModuleAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid text-center">
        <div class="well row" style="background-color: rgba(255, 255, 255, 0.7)">
            <h3>Add a module</h3>
            <asp:Literal ID="litAlert" runat="server"></asp:Literal>
            <br />

            <div class="col-md-4 col-md-offset-4">
                <div>
                    <div>
                            <fieldset>
                                <div class="form-group input-group">
                                            <input id="txtSearch" runat="server" type="text" class="form-control" placeholder="Lecturer name" autofocus="autofocus" />
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-small btn-primary" OnClick="btnSearch_Click"><i class="fa fa-search">&nbsp;Search</i></asp:LinkButton>
                                            </span>
                                </div>
                                <div class="form-group">
                                    <asp:ListBox ID="lstLecturers" runat="server" CssClass="form-control required-field" ToolTip="Select a lecturer to assign a module"></asp:ListBox>
                                    <asp:Label ID="lblLecturer" runat="server" Text="" CssClass="label label-danger"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <input id="txtModuleCode" runat="server" class="form-control required-field" placeholder="Module code" type="text" required="required" />
                                </div>
                                <br />
                                <div class="form-group">
                                    <input id="dateSelect" runat="server" class="form-control required-field" placeholder="Module Date" type="date" required="required" />
                                </div>
                                <br />
                                <asp:Button ID="btnAddModule" runat="server" Text="Add module" CssClass="btn btn-success" OnClick="btnAddModule_Click" />
                            </fieldset>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
