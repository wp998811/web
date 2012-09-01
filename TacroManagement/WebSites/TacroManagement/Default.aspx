<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
<<<<<<< HEAD
<<<<<<< HEAD
        <asp:Button ID="btnEdit" runat="server" onclick="btnEdit_Click" Text="Edit" />
        <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" 
            Text="Delete" />
=======
=======
>>>>>>> origin/MacGrady
        <asp:Button ID="testButton" runat="server" onclick="testButton_Click" 
            Text="测试" />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/upload/a.txt">HyperLink</asp:HyperLink>
        
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
        
<<<<<<< HEAD
>>>>>>> origin/MacGrady
=======
>>>>>>> origin/MacGrady
        <br />
    
    </div>
    </form>
</body>
</html>
