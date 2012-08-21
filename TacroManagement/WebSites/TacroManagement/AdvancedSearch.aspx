<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdvancedSearch.aspx.cs" Inherits="AdvancedSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> 高级查询</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>  
        <asp:Label ID="Label1" runat="server" Text="文档名称"></asp:Label>   
        <asp:TextBox ID="DocNameText" runat="server"></asp:TextBox> 
    </div>
    <div>  
        <asp:Label ID="Label2" runat="server" Text="文档版本"></asp:Label>   
        <asp:TextBox ID="DocVersionText" runat="server"></asp:TextBox> 
    </div>
    <div>  
        <asp:Label ID="Label3" runat="server" Text="关键词"></asp:Label>
        <asp:TextBox ID="DocKeyText" runat="server"></asp:TextBox> 
    </div>
    <div>  
        <asp:Label ID="Label4" runat="server" Text="文档所属部门"></asp:Label>   
        <asp:DropDownList ID="DepartName" runat="server">
        </asp:DropDownList>
    </div>
        <div>  
        <asp:Label ID="Label8" runat="server" Text="文档类别"></asp:Label>   
        <asp:DropDownList ID="DocCate" runat="server">
        </asp:DropDownList>
    </div>
        <div>  
        <asp:Label ID="Label5" runat="server" Text="上传人"></asp:Label>     
        <asp:TextBox ID="UploadUserName" runat="server"></asp:TextBox> 
    </div>
     <div>  
        <asp:Label ID="Label6" runat="server" Text="上传时间上限"></asp:Label>   
        <asp:TextBox ID="UploadTimeBeginText" runat="server"></asp:TextBox> 
    </div>
     <div>  
        <asp:Label ID="Label7" runat="server" Text="上传时间下限"></asp:Label>   
        <asp:TextBox ID="UploadTimeEndText" runat="server"></asp:TextBox> 
    </div>
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
    <asp:Button ID="AdvancedSearchButton" runat="server" Text="高级查询" 
        onclick="AdvancedSearchButton_Click" />
    </form>
</body>
</html>
