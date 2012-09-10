<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileUpload.aspx.cs" Inherits="Library_FileUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


</head>
<body>
    <form id="form1" runat="server">
    <div>
        <iframe src="FileUpload.htm" id="ifUp"></iframe>
        <asp:Button ID="btnOK" runat="server" onclick="btnOK_Click" Text="提交" />
    </div>
    
    
    <script type="text/javascript">
        parent.document.all("ifUp").style.height = document.body.scrollHeight + 100;
        parent.document.all("ifUp").style.width = document.body.scrollWidth; 
    </script>
    
    </form>
</body>
</html>
