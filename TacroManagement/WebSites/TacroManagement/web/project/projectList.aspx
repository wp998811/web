<%@ Page Language="C#" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="projectList.aspx.cs" Inherits="web_project_projectList" Title="无标题页" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding-top:10px"></div>
    <div class="container">
       <ul class="breadcrumb">
            <li><a href="../home/Home.aspx">首页 </a><span class="divider">/</span></li>
            <li class="active">项目列表 </li>
        </ul>
        <table class="table table-striped table-bordered table-condensed">
            <tr>
                <td>
                    项目名称
                </td>
                <td>
                    客户名称
                </td>
                <td>
                    开始日期
                </td>
                <td>
                    结束日期
                </td>
                <td>
                    项目类型
                </td>
                <td>
                    项目管理人员
                </td>
            </tr>
            <asp:Repeater runat="Server" ID="rpProject">
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href="../project/projectInfo.aspx?projectNum=<%#Eval("ProjectNum") %>">
                                <asp:Label runat="Server" ID="lblRpProjectName" Text='<%#Eval("ProjectName") %>'></asp:Label></a>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblRpClientName" Text='<%#Eval("ProjectClientName") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblBeginDate" Text='<%#Eval("BeginTime") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblEndDate" Text='<%#Eval("EndTime") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblProjectType" Text='<%#Eval("ProjectType") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblProjectManager" Text='<%#Eval("ProjectDescription") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <div style="height: 20px; text-align: center;">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" ButtonImageAlign="Middle"
                CssClass="p_num" CurrentPageButtonClass="p_num_currentPage" CustomInfoClass=""
                CustomInfoStyle="" FirstPageText="[首页]" Font-Size="9pt" Font-Underline="False"
                inputboxstyle="p_input" LastPageText="[尾页]" NextPageText="[后一页]" NumericButtonCount="8"
                NumericButtonTextFormatString="[{0}]" OnPageChanged="AspNetPager1_PageChanged"
                PageSize="8" PrevPageText="[前一页]" showinputbox="Never" ShowNavigationToolTip="True"
                ToolTip="分页" CustomInfoTextAlign="NotSet">
            </webdiyer:AspNetPager>
        </div>
    </div>
</asp:Content>

