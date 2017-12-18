<%@ Page Title="" Language="C#" MasterPageFile="~/BookmarksMainMenu.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Bookmarks.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <div class="container">
        <div class="form-group">
            <label for="confirm" class="cols-sm-2 control-label">Old Password</label>
            <div class="cols-sm-10">
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock" aria-hidden="true"></i></span>
                    <asp:TextBox ID="oldPassWord" CssClass="form-control" placeholder="Confirm your Password" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>
         
        </div>
        <div class="form-group">
            <label for="confirm" class="cols-sm-2 control-label">New  Password</label>
            <div class="cols-sm-10">
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock" aria-hidden="true"></i></span>
                    <asp:TextBox ID="newPassWord" CssClass="form-control" placeholder="Confirm your Password" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <%--<asp:Literal ID="Literal1" runat="server"></asp:Literal>--%>
        </div>
        <div class="form-group">
            <label for="confirm" class="cols-sm-2 control-label">Confirm  Password</label>
            <div class="cols-sm-10">
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock" aria-hidden="true"></i></span>
                    <asp:TextBox ID="confirmNewPassWord" CssClass="form-control" placeholder="Confirm your Password" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </div>
        <div class="form-group ">
            <asp:Button ID="ChangePasswordButton" CssClass="btn btn-primary btn-lg btn-block login-button" runat="server" Text="Change Password" OnClick="ChangePasswordButton_Click" />

        </div>

        <h3 runat="server" id="FinishUpdate"></h3>
   
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
