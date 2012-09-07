<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestLibrary.aspx.cs" Inherits="Library_TestLibrary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        #form1
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
        测试上传
    </div>
    <div class="style1">
        <asp:FileUpload ID="File1" runat="server" />
        <asp:Button ID="btnUpload" runat="server" Text="上传" onclick="btnUpload_Click" />
    </div>
    <div>
    </div>
    </form>
</body>
</html>
