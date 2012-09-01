<<<<<<< HEAD
﻿<%@ Page Language="C#" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="web_Search" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div align="center">
        <asp:TextBox ID="SearchText" runat="server"></asp:TextBox>
        <asp:Button ID="SearchSubmit" runat="server" Text="查找" 
            onclick="SearchSubmit_Click" /> 
        <asp:HyperLink ID="AdvancedSearch" runat="server" NavigateUrl="~/AdvancedSearch.aspx" 
            Target="_blank">高级查询</asp:HyperLink>  
            </div>
            <div align="center">
                <asp:RadioButtonList ID="DocRadioButtonList" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="Document">资料文档</asp:ListItem>
                    <asp:ListItem Value="ProjectDoc">项目文档</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div align="center">   
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
    </div>
</asp:Content>

=======
﻿<%@ Page Language="C#" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="web_Search" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div align="center">
        <asp:TextBox ID="SearchText" runat="server"></asp:TextBox>
        <asp:Button ID="SearchSubmit" runat="server" Text="查找" 
            onclick="SearchSubmit_Click" /> 
        <asp:HyperLink ID="AdvancedSearch" runat="server" NavigateUrl="~/AdvancedSearch.aspx" 
            Target="_blank">高级查询</asp:HyperLink>  
            </div>
            <div align="center">
                <asp:RadioButtonList ID="DocRadioButtonList" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="Document">资料文档</asp:ListItem>
                    <asp:ListItem Value="ProjectDoc">项目文档</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div align="center">   
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
    </div>
</asp:Content>

>>>>>>> origin/MacGrady
