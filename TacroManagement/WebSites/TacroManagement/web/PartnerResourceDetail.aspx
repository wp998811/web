<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="PartnerResourceDetail.aspx.cs" Inherits="web_PartnerResourceDetail"
    Title="详细合作伙伴资源信息" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <script src="../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>

    <script src="../bootstrap/js/bootstrap-modal.js" type="text/javascript"></script>

    <script src="../bootstrap/js/bootstrap-dropdown.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container" width="100%">
        <div style="padding-top: 10px;">
        </div>
        <ul class="breadcrumb">
            <li><a href="PartnerResourceList.aspx">合作伙伴资源管理</a> <span class="divider">/</span> </li>
            <li class="active">
                <asp:Label ID="Label1" runat="Server" Text="合作伙伴资源信息"></asp:Label></li>
        </ul>
        <div width="100%">
            <span><strong>合作伙伴资源信息</strong> </span>
        </div>
        <table class="table table-striped table-bordered table-condensed" width="100%" cellspacing="0"
            cellpadding="0" border="0">
            <tr>
                <td>
                    <strong>负责人姓名</strong>
                </td>
                <td>
                    <asp:Label ID="lblManager" runat="Server" Text=""></asp:Label>
                </td>
                <td>
                    <strong>所在城市</strong>
                </td>
                <td>
                    <asp:Label ID="lblCity" runat="Server" Text=""></asp:Label>
                </td>
                <td>
                    <strong>机构名称</strong>
                </td>
                <td>
                    <asp:Label ID="lblOrganName" runat="Server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <div>
            <div>
                <span><strong>机构简介</strong></span>
            </div>
            <div class="well">
                <asp:Label ID="lblOrganIntro" runat="Server" Text=""></asp:Label>
            </div>
        </div>
        <div width="100%">
            <div width="100%">
                <div width="100%">
                    <span><strong>合作伙伴资源联系人</strong> </span>
                </div>
                <div width="100%">
                    <div style="padding-top: 10px;">
                    </div>
                    <table class="table table-striped table-bordered table-condensed" cellspacing="0"
                        cellpadding="0" border="0" style="width: 100%">
                        <tr align="center">
                            <td align="center">
                                <strong>联系人姓名</strong>
                            </td>
                            <td align="center">
                                <strong>职位</strong>
                            </td>
                            <td align="center">
                                <strong>手机</strong>
                            </td>
                            <td align="center">
                                <strong>固定电话</strong>
                            </td>
                            <td align="center">
                                <strong>邮箱</strong>
                            </td>
                            <td align="center">
                                <strong>地址</strong>
                            </td>
                            <td align="center">
                                <strong>邮编</strong>
                            </td>
                            <td align="center">
                                <strong>传真号</strong>
                            </td>
                        </tr>
                        <asp:Repeater runat="Server" ID="rpContactList">
                            <ItemTemplate>
                                <tr align="center">
                                    <td align="center">
                                        <asp:Label runat="Server" ID="lblRpContactName" Text='<%#Eval("联系人姓名") %>'></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label runat="Server" ID="lblRpPosition" Text='<%#Eval("职位") %>'></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label runat="Server" ID="lblRpMobilephone" Text='<%#Eval("手机") %>'></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label runat="Server" ID="lblRpTelephone" Text='<%#Eval("固定电话") %>'></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label runat="Server" ID="lblRpEmail" Text='<%#Eval("邮箱") %>'></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label runat="Server" ID="lblRpAddress" Text='<%#Eval("地址") %>'></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label runat="Server" ID="lblPostCode" Text='<%#Eval("邮编") %>'></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label runat="Server" ID="lblFaxNumber" Text='<%#Eval("传真号") %>'></asp:Label>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div style="height: 20px; text-align: center;">
                        <webdiyer:aspnetpager id="PartnerContactPager" runat="server" alwaysshow="True" buttonimagealign="Middle"
                            cssclass="p_num" currentpagebuttonclass="p_num_currentPage" custominfoclass=""
                            custominfostyle="" firstpagetext="[首页]" font-size="9pt" font-underline="False"
                            inputboxstyle="p_input" lastpagetext="[尾页]" nextpagetext="[后一页]" numericbuttoncount="8"
                            numericbuttontextformatstring="[{0}]" onpagechanged="PartnerContact_PageChanged" pagesize="5"
                            prevpagetext="[前一页]" showinputbox="Never" shownavigationtooltip="True" tooltip="分页"
                            custominfotextalign="NotSet">
                    </webdiyer:aspnetpager>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

