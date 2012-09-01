<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"  CodeFile="projectList.aspx.cs" Inherits="web_projectList" Title="项目列表" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <iframe src="../projectList.aspx" name="mainFrame" id="mainFrame" height="100%" width="100%" frameborder="0"/>
</asp:Content>