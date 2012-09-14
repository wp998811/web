<%@ Page Language="C#"  EnableEventValidation = "false" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="web_Search" Title="搜索" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>
    <script src="../../bootstrap/js/bootstrap-modal.js" type="text/javascript"></script>
    <script src="../../bootstrap/js/bootstrap-dropdown.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
 <div class="container" >
    <div style="float: right">
        <asp:LinkButton ID="ExportExcel" runat="server" OnClick="ExportExcel_Click">导出Excel</asp:LinkButton>
    </div>
    <div align="center">
        <asp:Image ID="LogoImage" runat="server" Height="150px" ImageUrl="~/images/search.png"
            Width="450px" />
    </div>
    <div align="center" >
        <div class="form-search">
        <div class="input-append">  
        <asp:DropDownList class="span2 search-query"  ID="DocRadioButtonList" runat="server" Width="98px">
        <asp:ListItem Value="Document">资料文档</asp:ListItem>
         <asp:ListItem Value="ProjectDoc">项目文档</asp:ListItem>
        </asp:DropDownList>
             <asp:TextBox    ID="SearchText" runat="server" Width="266px"></asp:TextBox>
            <asp:Button class="btn btn-primary" ID="SearchSubmit" runat="server" text="搜索"
                onclick="SearchSubmit_Click"/>
        </div>
        <asp:HyperLink ID="AdvancedSearch" runat="server" NavigateUrl="~/web/Resource/AdvancedSearch.aspx">高级查询</asp:HyperLink>
        </div>
        
    </div>
   

    
    <div style="padding-top:10px;" align="center">
        <asp:Repeater ID="DocRepeater" runat="server" 
            OnItemCommand="DocRepeater_ItemCommand" 
            onitemdatabound="DocRepeater_ItemDataBound">
            <HeaderTemplate>
                <table class="table table-striped table-bordered table-condensed" border="0" cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td visible="false">
                            编号
                        </td>
                        <td>
                            名称
                        </td>
                        <td>
                            版本
                        </td>
                        <td>
                            类别
                        </td>
                        <td>
                            所属部门
                        </td>
                        <td>
                            上传人
                        </td>
                        <td>
                            上传时间
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label runat="Server" Text='<%# DataBinder.Eval( Container.DataItem, "docID") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "名称") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "版本") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "类别") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "所属部门") %>'></asp:Label>
                        <td>
                            <asp:Label ID="Label6" runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "上传人") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label7" runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "上传时间") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:LinkButton ID="ExploreBtn" runat="server" CommandName="ExploreDocument" CommandArgument='<%# DataBinder.Eval( Container.DataItem, "docID") %>'>浏览</asp:LinkButton>
                            <asp:LinkButton ID="ModifyBtn" runat="server" CommandName="ModifyDocument" CommandArgument='<%# DataBinder.Eval( Container.DataItem, "docID") %>'>修改</asp:LinkButton>
                            <asp:LinkButton ID="DownloadBtn" runat="server" CommandName="DownloadDocument" CommandArgument='<%# DataBinder.Eval( Container.DataItem, "docID") %>'>下载</asp:LinkButton>
                            <asp:LinkButton ID="DeleteBtn" runat="server" CommandName="DeleteDocument" CommandArgument='<%# DataBinder.Eval( Container.DataItem, "docID") %>'>删除</asp:LinkButton>
                        </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div>
        <asp:Repeater ID="ProjDocRepeater" runat="server" 
            OnItemCommand="ProjDocRepeater_ItemCommand" 
            onitemdatabound="ProjDocRepeater_ItemDataBound">
            <HeaderTemplate>
                <table class="table table-striped table-bordered table-condensed" border="0" cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td visible="false">
                             编号
                        </td>
                        <td>
                            名称
                        </td>
                        <td>
                            类别
                        </td>
                        <td>
                            项目子任务
                        </td>
                        <td>
                            上传人
                        </td>
                        <td>
                            上传时间
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label  runat="Server" Text='<%# DataBinder.Eval( Container.DataItem, "docID") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label  runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "名称") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label  runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "类别") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label  runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "项目子任务") %>'></asp:Label>
                        <td>
                            <asp:Label runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "上传人") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "上传时间") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:LinkButton ID="ExploreBtn" runat="server" CommandName="ExploreDocument" CommandArgument='<%# DataBinder.Eval( Container.DataItem, "docID") %>'>浏览</asp:LinkButton>
                            <asp:LinkButton ID="ModifyBtn" runat="server" CommandName="ModifyDocument" CommandArgument='<%# DataBinder.Eval( Container.DataItem, "docID") %>'>修改</asp:LinkButton>
                            <asp:LinkButton ID="DownloadBtn" runat="server" CommandName="DownloadDocument" CommandArgument='<%# DataBinder.Eval( Container.DataItem, "docID") %>'>下载</asp:LinkButton>
                            <asp:LinkButton ID="DeleteBtn" runat="server" CommandName="DeleteDocument" CommandArgument='<%# DataBinder.Eval( Container.DataItem, "docID") %>'>删除</asp:LinkButton>
                        </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div style="height: 20px; text-align: center;">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" ButtonImageAlign="Middle"
            CssClass="p_num" CurrentPageButtonClass="p_num_currentPage" CustomInfoClass=""
            CustomInfoStyle="" FirstPageText="[首页]" Font-Size="9pt" Font-Underline="False"
            InputBoxStyle="p_input" LastPageText="[尾页]" NextPageText="[后一页]" NumericButtonCount="8"
            NumericButtonTextFormatString="[{0}]" OnPageChanged="AspNetPager1_PageChanged"
            PageSize="5" PrevPageText="[前一页]" ShowInputBox="Never" ShowNavigationToolTip="True"
            ToolTip="分页" CustomInfoTextAlign="NotSet">
        </webdiyer:AspNetPager>
    </div>
    </div>
</asp:Content>
