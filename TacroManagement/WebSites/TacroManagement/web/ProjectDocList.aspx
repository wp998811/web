<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProjectDocList.aspx.cs" Inherits="web_ProjectDocList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div align="center">   
    <asp:GridView ID="DocGridView" runat="server" CellPadding="4" 
        ForeColor="#333333" GridLines="None" onrowcommand="DocGridView_RowCommand"  >
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
           <asp:BoundField DataField="名称" HeaderText="名称" />
            <asp:BoundField DataField="类别" HeaderText="类别" />
            <asp:BoundField DataField="所属部门" HeaderText="所属部门" />
            <asp:BoundField DataField="项目子任务" HeaderText="项目子任务" />
            <asp:BoundField DataField="上传人" HeaderText="上传人" />
            <asp:BoundField DataField="上传时间" HeaderText="上传时间" />  
            <asp:TemplateField>
            <ItemTemplate>
            <asp:LinkButton ID="ExploreButton" runat="server" 
                  NavigateUrl="~/Search.aspx" 
                  CommandName="ExploreDocument" 
                  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                  Text="浏览" />
             </ItemTemplate>
             </asp:TemplateField>
            <asp:TemplateField>
            <ItemTemplate>
            <asp:LinkButton ID="ModifyButton" runat="server"
                CommandName="ModifyDocument"
                CommandArgument ="<%# ((GridViewRow) Container).RowIndex %>"
               Text="修改" />
             </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField>
            <ItemTemplate>
            <asp:LinkButton ID="DownloadButton" runat="server" 
                  CommandName="DownloadDocument" 
                  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                  Text="下载" /> 
              </ItemTemplate>
             </asp:TemplateField>  
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    </div>
    </div>
    </form>
</body>
</html>
