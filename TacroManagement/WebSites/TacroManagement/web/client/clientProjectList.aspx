<%@ Page Language="C#" MasterPageFile="~/web/client/client.master" AutoEventWireup="true"
    CodeFile="clientProjectList.aspx.cs" Inherits="web_client_clientProjectList"
    Title="无标题页" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding-top: 10px">
    </div>
    <div class="container">
        <ul class="breadcrumb">
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
                            <a href="clientProjectInfo.aspx?projectNum=<%#Eval("ProjectNum") %>">
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
            <webdiyer:aspnetpager id="AspNetPager1" runat="server" alwaysshow="True" buttonimagealign="Middle"
                cssclass="p_num" currentpagebuttonclass="p_num_currentPage" custominfoclass=""
                custominfostyle="" firstpagetext="[首页]" font-size="9pt" font-underline="False"
                inputboxstyle="p_input" lastpagetext="[尾页]" nextpagetext="[后一页]" numericbuttoncount="8"
                numericbuttontextformatstring="[{0}]" onpagechanged="AspNetPager1_PageChanged"
                pagesize="8" prevpagetext="[前一页]" showinputbox="Never" shownavigationtooltip="True"
                tooltip="分页" custominfotextalign="NotSet">
            </webdiyer:aspnetpager>
        </div>
    </div>
</asp:Content>
