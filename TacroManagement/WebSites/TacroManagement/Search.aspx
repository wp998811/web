<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" Async="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查询</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="SearchText" runat="server"></asp:TextBox>
        <asp:Button ID="SearchSubmit" runat="server" Text="查找" 
            onclick="SearchSubmit_Click" /> 
          
    <asp:GridView ID="DocGridView" runat="server" CellPadding="4" 
        ForeColor="#333333" GridLines="None" onrowcommand="DocGridView_RowCommand" >
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
           <asp:TemplateField>
              <ItemTemplate>
               <asp:LinkButton ID="ExploreButton" runat="server" 
                  NavigateUrl="~/Search.aspx" 
                  CommandName="ExploreDocument" 
                  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                  Text="浏览" />
                   <%--<asp:HyperLink ID ="ExploreLink" runat="server" NavigateUrl='<%# String.Format("~/Search.aspx?id={0}", GetDocumentName(((GridViewRow) Container).RowIndex))%>' -->
                         Target="_blank">liulan</asp:HyperLink>--%> 
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
          
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Search.aspx" 
            Target="_blank">HyperLink</asp:HyperLink>
          
    </div>
    </form>
</body>
</html>
