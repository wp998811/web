<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="ModifyCustomerProject.aspx.cs" Inherits="web_ModifyCustomerProjContact"
    Title="修改客户项目" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <script src="../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>

    <script src="../bootstrap/js/bootstrap-modal.js" type="text/javascript"></script>

    <script src="../bootstrap/js/bootstrap-dropdown.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding-top: 10px">
    </div>
    <div class="container">
        <div class="row">
            <form class="form-horizontal">
            <ul class="breadcrumb">
                <li><a href="CustomerProjList.aspx">客户项目管理</a> <span class="divider">/</span> </li>
                <li class="active">
                    <asp:Label runat="Server" Text="编辑客户项目"></asp:Label></li>
            </ul>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    客户名称
                </label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtCustomerName" onfocus="$('#myModal').modal({backdrop:false, keyboard:true,show:true})"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCustomerName"
                            ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="客户名称不能为空"
                            ControlToValidate="txtCustomerName" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="controls">
                    <asp:TextBox ID="txtHiddenCustomerID" runat="server" Visible="false"></asp:TextBox>
                </div>
                <div class="modal hide fade" id="myModal">
                    <div class="modal-header">
                        <a class="close" data-dismiss="modal">×</a>
                        <h3>
                            修改客户</h3>
                    </div>
                    <div class="modal-body" style="margin: 0px auto">
                        <asp:DropDownList runat="server" ID="ddlCustomer">
                        </asp:DropDownList>
                    </div>
                    <div class="modal-footer">
                        <asp:LinkButton class="btn btn-primary" ID="lbtnSelectCustomer" runat="Server" CommandName="select"
                            CausesValidation="false" Text="确定" OnCommand="lbtnSelectCustomer_Command"></asp:LinkButton>
                        <a data-dismiss="modal" href="#" class="btn">关闭</a>
                    </div>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    服务项目
                </label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtService"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtService"
                            ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    项目进程
                </label>
                <div class="controls">
                    <asp:DropDownList runat="Server" ID="ddlProgress">
                    </asp:DropDownList>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ddlProgress"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    产品名称
                </label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtProductName"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtProductName"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    项目类型
                </label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtProjectType">
                    </asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtProjectType"
                            ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    合同金额
                </label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtContractAmount"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtContractAmount"
                        ErrorMessage="请输入整数" ValidationExpression="([0-9]){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    付款方式
                </label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtPayment"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtPayment"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    付款情况
                </label>
                <div class="controls">
                    <asp:DropDownList runat="Server" ID="ddlPayState"></asp:DropDownList>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="ddlPayState"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div width="100%">
                <span><strong>客户联系人信息</strong> </span>
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
                <webdiyer:aspnetpager id="CustomerContactPager" runat="server" alwaysshow="True" buttonimagealign="Middle"
                    cssclass="p_num" currentpagebuttonclass="p_num_currentPage" custominfoclass=""
                    custominfostyle="" firstpagetext="[首页]" font-size="9pt" font-underline="False"
                    inputboxstyle="p_input" lastpagetext="[尾页]" nextpagetext="[后一页]" numericbuttoncount="8"
                    numericbuttontextformatstring="[{0}]" onpagechanged="CustomerContact_PageChanged" pagesize="5"
                    prevpagetext="[前一页]" showinputbox="Never" shownavigationtooltip="True" tooltip="分页"
                    custominfotextalign="NotSet">
                </webdiyer:aspnetpager>
            </div>
            <div class="form-horizontal control-group">
                <div class="controls">
                    <asp:Button class="btn btn-primary" ID="addCustomerProject" Text="确定" runat="server" OnClick="ModifyCustomerProject" />
                    <asp:Button class="btn" ID="btnCancel" Text="取消" runat="Server" OnClick="Abort"/>
                </div>
            </div>
            </form>
        </div>
    </div>
</asp:Content>
