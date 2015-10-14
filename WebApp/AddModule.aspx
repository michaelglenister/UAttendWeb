<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddModule.aspx.cs" Inherits="WebApp.AddModule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid text-center">
        <div class="well row" style="background-color: rgba(255, 255, 255, 0.7)">
            <asp:Literal ID="litHeader" runat="server"></asp:Literal><br /><br />
            <h3>Add Module</h3>
            <br />

            <div class="col-md-4 col-md-offset-4">
                <div>
                    <div>
                            <fieldset>
                                <asp:Literal ID="litAlert" runat="server"></asp:Literal>
                                <div class="form-group">
                                    <input id="txtModuleCode" runat="server" class="form-control required-field" placeholder="Module code" required="required" autofocus="autofocus" />
                                </div>
                                <br />
                                <asp:Button ID="btnAddModule" runat="server" Text="Add module" CssClass="btn btn-lg btn-success" OnClick="btnAddModule_Click" />
                            </fieldset>
                        
                    </div>
                </div>
            </div>

            
            
        </div>
    </div>
</asp:Content>
