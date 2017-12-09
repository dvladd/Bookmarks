<%@ Page Title="" Language="C#" MasterPageFile="~/BookmarksMainMenu.Master" AutoEventWireup="true" CodeBehind="AddBookmark.aspx.cs" Inherits="Bookmarks.AddBookmark" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        body, html {
            height: 100%;
            background-repeat: no-repeat;
            background-color: #d3d3d3;
            font-family: 'Oxygen', sans-serif;
        }

        .main {
            margin-top: 0px;
        }

        .allingPhoto {
            margin-top: 5px;
            margin-left: 10px;
        }

        h1.title {
            font-size: 50px;
            font-family: 'Passion One', cursive;
            font-weight: 400;
        }

        hr {
            width: 10%;
            color: #fff;
        }

        .form-group {
            margin-bottom: 15px;
        }

        label {
            margin-bottom: 15px;
        }

        input,
        input::-webkit-input-placeholder {
            font-size: 11px;
            padding-top: 0px;
        }

        .main-login {
            background-color: #fff;
            /* shadows and rounded borders */
            -moz-border-radius: 2px;
            -webkit-border-radius: 2px;
            border-radius: 2px;
            -moz-box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
            -webkit-box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
            box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
        }

        .main-center {
            margin-top: 30px;
            margin: 0 auto;
            max-width: 330px;
            padding: 40px 40px;
        }

        .login-button {
            margin-top: 5px;
        }

        .login-register {
            font-size: 11px;
            text-align: center;
        }
    </style>

    <div class="container">
        <div class="row main">
            <div class="main-login main-center">
                <div class="form-horizontal">
                    <div class="form-group">
                        <asp:Literal ID="EroareBazaDate" runat="server"></asp:Literal>
                        <label for="name" class="cols-sm-2">Who should see this bookmark?</label>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Private &nbsp;&nbsp;" Value="private" />
                            <asp:ListItem Text="Public &nbsp;&nbsp;" Value="public" />
                            <asp:ListItem Text="Both" Value="both" />
                        </asp:RadioButtonList>
                        <asp:Label ID="EroareRadio" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="form-group">
                        <label for="title" class="cols-sm-2 control-label">Bookmark's Title</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-font" aria-hidden="true"></i></span>
                                <asp:TextBox ID="title" runat="server" CssClass="form-control" placeholder="Enter bookmark's title"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Literal ID="EroareTitle" runat="server"></asp:Literal>
                    </div>

                    <div class="form-group">
                        <label for="link" class="cols-sm-2 control-label">Bookmark's Link</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-link" aria-hidden="true"></i></span>
                                <asp:TextBox ID="link" CssClass="form-control" placeholder="Enter bookmark's link" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Literal ID="EroareLink" runat="server"></asp:Literal>
                    </div>

                    <div class="form-group">
                        <label for="description" class="cols-sm-2 control-label">Bookmark's Description</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-question-sign" aria-hidden="true"></i></span>
                                <asp:TextBox ID="description" Style="height: 200px;" placeholder="Enter bookmark's description" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Literal ID="EroareDescriere" runat="server"></asp:Literal>
                    </div>

                    <div class="form-group">
                        <label for="tags" class="cols-sm-2 control-label">Bookmark's Tags</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-tags" aria-hidden="true"></i></span>
                                <asp:TextBox ID="tags" placeholder="Enter bookmark's tags (separated by space)" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Literal ID="EroareTags" runat="server"></asp:Literal>
                    </div>

                    <div class="form-group">
                        <label for="category" class="cols-sm-2 control-label">Bookmark's Category</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-th" aria-hidden="true"></i></span>
                                <asp:TextBox ID="category" placeholder="Enter bookmark's category" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Literal ID="EroareCategorie" runat="server"></asp:Literal>
                    </div>

                    <div class="form-group">
                        <label for="photo" class="cols-sm-2 control-label">Bookmark's Thumbnail</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-picture" aria-hidden="true"></i></span>
                                <asp:FileUpload ID="photoUpload" runat="server" CssClass="allingPhoto" />
                            </div>
                        </div>
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </div>

                    <div class="form-group ">
                        <asp:Button ID="addBookmarkButton" CssClass="btn btn-primary btn-lg btn-block login-button" runat="server" Text="Add Bookmark" OnClick="addBookmarkButton_Click" />
                        <%--https://www.w3schools.com/icons/bootstrap_icons_glyphicons.asp--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

