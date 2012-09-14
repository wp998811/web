<%@ Page Language="C#" MasterPageFile="~/web/index.master" AutoEventWireup="true"
    CodeFile="projectStateMore.aspx.cs" Inherits="web_project_projectStateMore" Title="无标题页" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding-top: 10px">
    </div>
    <div class="container">
        <ul class="breadcrumb">
            <li><a href="../home/Home.aspx">首页 </a><span class="divider">/</span></li>
            <li class="active">项目动态 </li>
        </ul>
        <table class="table table-striped table-bordered table-condensed">
            <tr>
                <td>
                    动态
                </td>
                <td>
                    操作时间
                </td>
                <td>
                    操作人
                </td>
                <td>
                    项目名称
                </td>
            </tr>
            <asp:Repeater runat="Server" ID="rpProjectState">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label runat="Server" ID="lblAffairDes" Text='<%#Eval("AffairDescription") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblAffairTime" Text='<%#Eval("AffairTime") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="Server" ID="lblAffairOperatorName" Text='<%#Eval("AffairOperator") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblProjectName" Text='<%#Eval("ProjectName") %>'></asp:Label>
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
