<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="attendance.aspx.cs" Inherits="WebApp.attendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid text-center">
        <div class="well row" style="background-color: rgba(255, 255, 255, 0.7)">
            <h3>Attendance records</h3>
            <br />
            <div class="col-md-4 col-md-offset-4">
                <div>
                    <div>
                        <fieldset>
                            <asp:Button ID="btnSubjectAverage" CssClass="btn btn-lg btn-success btn-block" runat="server" Text="Subject Average" OnClick="btnSubjectAverage_Click" />
                            <br /><br />
                            <asp:Button ID="btnStudentAverage" CssClass="btn btn-lg btn-success btn-block" runat="server" Text="Student Average" OnClick="btnStudentAverage_Click" />
                            <br /><br />
                            <asp:Button ID="btnStudentDetail" CssClass="btn btn-lg btn-success btn-block" runat="server" Text="Student Detailed" OnClick="btnStudentDetail_Click" />
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
