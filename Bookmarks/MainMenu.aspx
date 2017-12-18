﻿<%@ Page Title="" Language="C#" MasterPageFile="~/BookmarksMainMenu.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="Bookmarks.MainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .widget-products li > a:after {
            content: "\f138";
            font-family: FontAwesome;
            font-size: 0.875em;
            font-style: normal;
            font-weight: normal;
            margin-top: 32px;
            position: absolute;
            right: 10px;
            text-decoration: inherit;
            top: 0;
            color: #cccccc;
            font-size: 1.3em;
        }

        .btn-success {
            background-color: #2ecc71;
            border-color: #27ae60;
        }

        .btn {
            border: none;
            padding: 6px 12px;
            border-bottom: 4px solid;
            -webkit-transition: border-color 0.1s ease-in-out 0s,background-color 0.1s ease-in-out 0s;
            transition: border-color 0.1s ease-in-out 0s,background-color 0.1s ease-in-out 0s;
            outline: none;
        }

        .checkbox-nice label {
            padding-top: 3px;
        }

        label {
            font-weight: 400;
            font-size: 0.875em;
        }

        .checkbox-nice input[type=checkbox] {
            visibility: hidden;
        }

        .checkbox-nice {
            position: relative;
            padding-left: 15px;
        }

        .widget-todo .name {
            float: left;
        }

        .widget-todo > li {
            border-bottom: 1px solid #ebebeb;
            padding: 10px 5px;
        }

        .widget-todo {
            list-style: none;
            margin: 0;
            padding: 0;
        }

        .widget-products li .product > .warranty > i {
            color: #f1c40f;
        }

        .widget-products li .product > .warranty {
            display: block;
            text-decoration: none;
            width: 50%;
            float: left;
            font-size: 0.875em;
        }

        .widget-products li .product > .price > i {
            color: #2ecc71;
        }

        .widget-products li .product > .price {
            display: block;
            text-decoration: none;
            width: 50%;
            float: left;
            font-size: 0.875em;
        }

        .widget-products li .product > .name {
            display: block;
            font-weight: 600;
            padding-bottom: 7px;
        }

        .widget-products li .product {
            display: block;
            margin-left: 90px;
            margin-top: 19px;
        }

        .widget-products li .img {
            display: block;
            float: left;
            text-align: center;
            width: 70px;
            height: 68px;
            overflow: hidden;
            margin-top: 7px;
        }

        .widget-products li > a {
            height: 88px;
            display: block;
            width: 100%;
            color: #344644;
            padding: 3px 10px;
            position: relative;
            -webkit-transition: border-color 0.1s ease-in-out 0s,background-color 0.1s ease-in-out 0s;
            transition: border-color 0.1s ease-in-out 0s,background-color 0.1s ease-in-out 0s;
        }

        .widget-products li {
            border-bottom: 1px solid #ebebeb;
        }

        .widget-products {
            list-style: none;
            margin: 0;
            padding: 0;
        }

        .widget-users li {
            border-bottom: 1px solid #ebebeb;
            padding: 15px 0;
            height: 96px;
        }

        .label {
            border-radius: 3px;
            font-size: 0.875em;
            font-weight: 600;
        }

        .widget-users li > .details > .time {
            color: #3498db;
            font-size: 0.75em;
            padding-bottom: 7px;
        }

        .widget-users li > .details > .name > a {
            color: #344644;
        }

        .widget-users li > .details > .name {
            font-weight: 600;
        }

        .widget-users li > .details {
            margin-left: 60px;
        }

        .widget-users li > .img {
            float: left;
            margin-top: 8px;
            width: 50px;
            height: 50px;
            overflow: hidden;
            border-radius: 50%;
        }

        .widget-users {
            list-style: none;
            margin: 0;
            padding: 0;
        }

        .tabs-wrapper.tabs-no-header .tab-content {
            padding: 0 20px 20px;
        }

        .nav-tabs > li > a {
            border-radius: 0;
            font-size: 1.125em;
            font-weight: 300;
            outline: none;
            color: #555;
            margin-right: 3px;
        }

        .nav > li {
            float: left;
        }

        .tabs-wrapper .nav-tabs {
            margin-bottom: 15px;
        }

        .nav-tabs {
            background: #d0d8de;
            border-color: transparent;
            -moz-border-radius: 3px 3px 0 0;
            -webkit-border-radius: 3px 3px 0 0;
            border-radius: 3px 3px 0 0;
        }

        .main-box {
            background: #FFFFFF;
            -webkit-box-shadow: 1px 1px 2px 0 #CCCCCC;
            -moz-box-shadow: 1px 1px 2px 0 #CCCCCC;
            box-shadow: 1px 1px 2px 0 #CCCCCC;
            margin-bottom: 16px;
            -moz-border-radius: 3px;
            border-radius: 3px;
        }
    </style>


    <div class="row">


    <div class="col-md-6 col-lg-6 col-xs-6 col-sm-6"  style="border-color:#337ab7;border-style:double">
        <h4 class="product clearfix">Last Posted</h4>
        <ul class="widget-products">
            <li>
                <a href="#">
                    <span class="img">
                        <img class="img-thumbnail" src="#" alt="" />
                    </span>
                    <span class="product clearfix">
                        <span runat="server" class="name" id="TBL1">Product name 1
                        </span>

                    </span>
                </a>
            </li>
            <li>
                <a href="#">
                    <span class="img">
                        <img class="img-thumbnail" src="#" alt="" />
                    </span>
                    <span class="product clearfix">
                        <span runat="server" class="name" id="TBL2">Product name 2
                        </span>
                        <span class="price">
                            <i class="fa fa-money"></i>
                        </span>
                    </span>
                </a>
            </li>
            <li>
                <a href="#">
                    <span class="img">
                        <img class="img-thumbnail" src="#" alt="" />
                    </span>
                    <span class="product clearfix">
                        <span runat="server" class="name" id="TBL3">Product name 3
                        </span>
                        <span class="price">
                            <i class="fa fa-money"></i>
                        </span>
                    </span>
                </a>
            </li>
            <li>
                <a href="#">
                    <span class="img">
                        <img class="img-thumbnail" src="#" alt="" />
                    </span>
                    <span class="product clearfix">
                        <span id="TBL4" runat="server" class="name">Product name 4
                        </span>
                        <span runat="server" class="price">
                            <i class="fa fa-money"></i>
                        </span>
                    </span>
                </a>
            </li>
        </ul>
    </div>

    <div class="col-md-6 col-lg-6 col-xs-6 col-sm-6"  style="border-color:#337ab7;border-style:double;">
        <h4 class="product clearfix">Most Voted</h4>
        <ul class="widget-products">
            <li>
                <a href="#">
                    <span class="img">
                        <img class="img-thumbnail" src="#" alt="" />
                    </span>
                    <span class="product clearfix">
                        <span runat="server" class="name" id="TBR1">Product name 1
                        </span>
                        <span class="price">
                            <i class="fa fa-money"></i>
                        </span>
                    </span>
                </a>
            </li>
            <li>
                <a href="#">
                    <span class="img">
                        <img class="img-thumbnail" src="#" alt="" />
                    </span>
                    <span class="product clearfix">
                        <span runat="server" class="name" id="TBR2">Product name 2
                        </span>
                        <span class="price">
                            <i class="fa fa-money"></i>
                        </span>
                    </span>
                </a>
            </li>
            <li>
                <a href="#">
                    <span class="img">
                        <img class="img-thumbnail" src="#" alt="" />
                    </span>
                    <span runat="server" class="product clearfix">
                        <span runat="server" class="name" id="TBR3">Product name 3
                        </span>
                        <span class="pricie">
                            <i class="fa fa-money"></i>
                        </span>
                    </span>
                </a>
            </li>
            <li>
                <a href="#">
                    <span class="img">
                        <img class="img-thumbnail" src="#" alt="" />
                    </span>
                    <span runat="server" class="product clearfix">
                        <span runat="server" class="name" id="TBR4">Product name 4
                        </span>
                        <span class="price">
                            <i class="fa fa-money"></i>
                        </span>
                    </span>
                </a>
            </li>
        </ul>
    </div>
        </div>
    <div class="container" id="tourpackages-carousel" style="margin-top:50px">
        <div class="row" id="roww1" runat="server">
        </div>

      
    </div>
</asp:Content>
