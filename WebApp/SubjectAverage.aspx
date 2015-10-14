<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SubjectAverage.aspx.cs" Inherits="WebApp.SubjectAverage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/morris.js/0.5.1/morris.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid text-center">
        <div class="well row" style="background-color: rgba(255, 255, 255, 0.7)">
            <h3>Subject Average</h3>

            <div class="col-md-4 col-md-offset-4">
                <div>
                    <div>
                        <h4><div class="alert alert-info alert-dismissable">
                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                            Average attendance in percentage
                        </div></h4>

                        <asp:DropDownList ID="dlModules" CssClass="btn btn-lg btn-info" runat="server"></asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnGetReport" CssClass="btn btn-lg btn-success" runat="server" Text="View Report" OnClick="btnGetReport_Click" />
                        <br /><br />
                        <asp:Literal ID="litReport" runat="server"></asp:Literal>


                        <asp:chart ID="chart1" runat="server">
                            <Series>
                                <asp:Series Name="Series1" YValueType="Double" ChartType="Column"></asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>

                            </ChartAreas>
                        </asp:chart>

                    </div>
                </div>
            </div>

                    

            

        </div>
    </div>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/morris.js/0.5.1/morris.min.js"></script>

    <asp:Literal ID="litChart" runat="server"></asp:Literal>
</asp:Content>
