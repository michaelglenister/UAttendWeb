<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="StudentDetail.aspx.cs" Inherits="WebApp.StudentDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid text-center">
        <div class="well row" style="background-color: rgba(255, 255, 255, 0.7)">
            <h3>Student Detailed</h3>

            <div class="col-md-4 col-md-offset-4">
                <div>
                    <div>
                        <h4><div class="alert alert-info alert-dismissable">
                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                            A students attendance per roll call
                        </div></h4>

                        <asp:DropDownList ID="dlModules" CssClass="btn btn-lg btn-info" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlModules_SelectedIndexChanged"></asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:DropDownList ID="dlStudents" CssClass="btn btn-lg btn-info" runat="server"></asp:DropDownList>
                        <br /><br />
                        <asp:Button ID="btnGetReport" CssClass="btn btn-lg btn-success" runat="server" Text="View Report" OnClick="btnGetReport_Click" />
                        <br /><br />
                        <div class="table-responsive">
                            <table class="table table-hover table-striped tablesorter align-left">
                                <asp:Literal ID="litReport" runat="server"></asp:Literal>
                            </table>
                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
