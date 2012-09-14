<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="CustomerDetail.aspx.cs" Inherits="web_CustomerDetail" Title="详细客户信息" %>

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
            <li><a href="#">客户管理</a> <span class="divider">/</span> </li>
            <li class="active">
                <asp:Label ID="lblProjectName2" runat="Server" Text="客户详细信息"></asp:Label></li>
        </ul>
        <div width="100%">
            <span><strong>客户信息</strong> </span>
        </div>
        <table class="table table-striped table-bordered table-condensed" width="100%" cellspacing="0"
            cellpadding="0" border="0">
            <tr>
                <td>
                    <strong>客户名称</strong>
                </td>
                <td>
                    <asp:Label ID="lblCustomerName" runat="Server" Text=""></asp:Label>
                </td>
                <td>
                    <strong>所在城市</strong>
                </td>
                <td>
                    <asp:Label ID="lblCity" runat="Server" Text=""></asp:Label>
                </td>
                <td>
                    <strong>客户类别</strong>
                </td>
                <td>
                    <asp:Label ID="lblCustomerType" runat="Server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>级别</strong>
                </td>
                <td>
                    <asp:Label ID="lblCustomerRank" runat="Server" Text=""></asp:Label>
                </td>
                <td>
                    <strong>产品范围</strong>
                </td>
                <td>
                    <asp:Label ID="lblProductRange" runat="Server" Text=""></asp:Label>
                </td>
                <td>
                    <strong>税务登记号</strong>
                </td>
                <td>
                    <asp:Label ID="lblTaxID" runat="Server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>组织机构代码</strong>
                </td>
                <td>
                    <asp:Label ID="lblOrganCode" runat="Server" Text=""></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label runat="Server" Text=""></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label runat="Server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <div width="100%">
            <div width="100%">
                <span><strong>客户负责人</strong> </span>
            </div>
            <div width="100%">
                <div style="padding-top: 10px;">
                </div>
                <table class="table table-striped table-bordered table-condensed" cellspacing="0"
                    cellpadding="0" border="0" style="width: 100%">
                    <tr align="center">
                        <td align="center">
                            <strong>员工</strong>
                        </td>
                        <td align="center">
                            <strong>员工类别</strong>
                        </td>
                        <td align="center">
                            <strong>电子邮件</strong>
                        </td>
                        <td align="center">
                            <strong>电话</strong>
                        </td>
                        <td align="center">
                            <strong>所在部门</strong>
                        </td>
                    </tr>
                    <asp:Repeater runat="Server" ID="rpUserList">
                        <ItemTemplate>
                            <tr align="center">
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpUserName" Text='<%#Eval("用户名") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpUserType" Text='<%#Eval("用户类型") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <a>
                                        <asp:Label runat="Server" ID="lblRpUserEmail" Text='<%#Eval("邮箱") %>'></asp:Label></a>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpUserPhone" Text='<%#Eval("手机") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpDepartment" Text='<%#Eval("所在部门") %>'></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div width="100%">
                <span><strong>客户联系人</strong> </span>
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
                    <webdiyer:aspnetpager id="ContactPager" runat="server" alwaysshow="True" buttonimagealign="Middle"
                        cssclass="p_num" currentpagebuttonclass="p_num_currentPage" custominfoclass=""
                        custominfostyle="" firstpagetext="[首页]" font-size="9pt" font-underline="False"
                        inputboxstyle="p_input" lastpagetext="[尾页]" nextpagetext="[后一页]" numericbuttoncount="8"
                        numericbuttontextformatstring="[{0}]" onpagechanged="Contact_PageChanged" pagesize="5"
                        prevpagetext="[前一页]" showinputbox="Never" shownavigationtooltip="True" tooltip="分页"
                        custominfotextalign="NotSet">
                    </webdiyer:aspnetpager>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
