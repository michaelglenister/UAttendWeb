<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewStudents.aspx.cs" Inherits="WebApp.ViewStudents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid text-center">
        <div class="well row" style="background-color: rgba(255, 255, 255, 0.7)">
            <h3>Students list for:</h3>
            <br/>
            

            <div class="col-md-4 col-md-offset-4">
                <div>
                    <div>
                            <fieldset>
                                <asp:Literal ID="litHeader" runat="server"></asp:Literal>
                                <br />
                                <asp:Button ID="btnAddStudents" CssClass="btn btn-lg btn-success" runat="server" Text="Add students" OnClick="btnAddStudents_Click" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnModule" CssClass="btn btn-lg btn-warning" runat="server" Text="View Modules" OnClick="btnModule_Click" />
                                <br/><br/><br/>
                                <div class="table-responsive">
                                    <table class="table table-hover table-striped tablesorter align-left">
                                        <asp:Literal ID="litStudentList" runat="server"></asp:Literal>
                                    </table>
                                </div>
                            </fieldset>
                        
                    </div>
                </div>
            </div>

            
        </div>
    </div>
</asp:Content>
