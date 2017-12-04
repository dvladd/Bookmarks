<%@ Page Title="" Language="C#" MasterPageFile="~/Bookmarks.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Bookmarks.Register" %>

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
            <%--<div class="panel-heading">
                <div class="panel-title text-center">
                    <h2 class="title">Register here..</h2>
                    <hr />
                </div>ss
            </div>--%>
            <div class="main-login main-center">
                <asp:Literal ID="EroareBazaDate" runat="server"></asp:Literal>
                <div class="form-horizontal">

                    <div class="form-group">
                        <label for="name" class="cols-sm-2 control-label">Your First Name</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-user" aria-hidden="true"></i></span>
                                <asp:TextBox ID="firstname" runat="server" CssClass="form-control" placeholder="Enter your First Name"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Literal ID="EroarePrenume" runat="server"></asp:Literal>
                    </div>

                    <div class="form-group">
                        <label for="name" class="cols-sm-2 control-label">Your Last Name</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-user" aria-hidden="true"></i></span>
                                <asp:TextBox ID="name" runat="server" CssClass="form-control" placeholder="Enter your Last Name"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Literal ID="EroareNume" runat="server"></asp:Literal>
                    </div>

                    <div class="form-group">
                        <label for="email" class="cols-sm-2 control-label">Your Email</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-briefcase" aria-hidden="true"></i></span>
                                <asp:TextBox ID="email" CssClass="form-control" placeholder="Enter your Email" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Literal ID="EroareEmail" runat="server"></asp:Literal>
                    </div>

                    <div class="form-group">
                        <label for="username" class="cols-sm-2 control-label">Username</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-certificate" aria-hidden="true"></i></span>
                                <asp:TextBox ID="username" placeholder="Enter your Username" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Literal ID="EroareUsername" runat="server"></asp:Literal>
                    </div>

                    <div class="form-group">
                        <label for="password" class="cols-sm-2 control-label">Password</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-lock" aria-hidden="true"></i></span>
                                <asp:TextBox ID="password" CssClass="form-control" placeholder="Enter your Password" runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Literal ID="EroareParola" runat="server"></asp:Literal>
                    </div>

                    <div class="form-group">
                        <label for="confirm" class="cols-sm-2 control-label">Confirm Password</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-lock" aria-hidden="true"></i></span>
                                <asp:TextBox ID="passwordcon" CssClass="form-control" placeholder="Confirm your Password" runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Literal ID="EroareConfirmareParola" runat="server"></asp:Literal>
                    </div>

                    <div class="form-group ">
                        <asp:Button ID="registerButton" CssClass="btn btn-primary btn-lg btn-block login-button" runat="server" Text="Register" OnClick="registerButton_Click" />

                    </div>
                    <div class="login-register">
                        <a href="Index.aspx">Login</a>
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
