﻿<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtPassword" runat="server" ></asp:TextBox>
        <br />
        <asp:Button ID="btnLogin" runat="server" onclick="btnLogin_Click" 
            Text="Login" />
    
        <br />
        <br />
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="password" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="type" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="email" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="phone" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="departID" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnAddUser" runat="server" onclick="btnAddUser_Click" 
            Text="Add" />
        <asp:Button ID="btnUserLogin" runat="server" onclick="btnUserLogin_Click" 
            Text="Login" />
        <br />
    
    </div>
    </form>
</body>
</html>
