<%@ Page Language="C#"  EnableEventValidation = "false" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="web_Search" Title="搜索" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript">
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<div style="float:right">
<asp:LinkButton ID="ExportExcel" runat="server" onclick="ExportExcel_Click" >导出Excel</asp:LinkButton>
</div>
<div align="center">
    <asp:Image ID="Image1" runat="server" Height="150px" 
        ImageUrl="~/images/search.png" Width="450px" />
</div>
    <div align="center">
        <asp:TextBox ID="SearchText" runat="server" Height="27px" Width="266px" 
            Font-Size="Larger"></asp:TextBox>
        <asp:ImageButton ID="SearchSubmit" runat="server" onclick="SearchSubmit_Click" 
            Height="30px" ImageUrl="~/images/searchButton.png"/>
        <asp:HyperLink ID="AdvancedSearch" runat="server" NavigateUrl="~/web/AdvancedSearch.aspx" 
            >高级查询</asp:HyperLink>  
            </div>
            <div align="center">
                <asp:RadioButtonList ID="DocRadioButtonList" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="Document">资料文档</asp:ListItem>
                    <asp:ListItem Value="ProjectDoc">项目文档</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div align="center">   
    <asp:GridView ID="DocGridView" runat="server" CellPadding="4" AutoGenerateColumns="false"
        ForeColor="#333333" GridLines="None" onrowcommand="DocGridView_RowCommand" 
                    datakeynames="docID" onrowdeleting="DocGridView_RowDeleting">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
           <asp:BoundField DataField="名称" HeaderText="名称" />
            <asp:BoundField DataField="版本" HeaderText="版本" />
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
          <asp:TemplateField>
            <ItemTemplate>
            <asp:LinkButton ID="DeleteButton" runat="server" 
                  CommandName="DeleteDocument" 
                  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                  Text="删除" /> 
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
