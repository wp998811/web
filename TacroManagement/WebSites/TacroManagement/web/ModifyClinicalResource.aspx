<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="ModifyClinicalResource.aspx.cs" Inherits="web_ModifyClinicalResource"
    Title="修改临床资源" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <script src="../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>

    <script src="../bootstrap/js/bootstrap-modal.js" type="text/javascript"></script>

    <script src="../bootstrap/js/bootstrap-dropdown.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <form class="form-horizontal">
            <ul class="breadcrumb">
                <li>
                    <a href="ClinicalResourceList.aspx">临床资源管理</a> <span class="divider">/</span>
                </li>
                <li class="active">
                    <asp:Label runat="Server" Text="编辑临床资源"></asp:Label></li>
            </ul>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    负责人
                </label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtManager" onfocus="$('#myModal').modal({backdrop:false, keyboard:true,show:true})"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtManager"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="负责人不能为空"
                        ControlToValidate="txtManager" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="controls">
                    <asp:TextBox ID="txtHiddenUserID" runat="server" Visible="false"></asp:TextBox>
                </div>
                <div class="modal hide fade" id="myModal">
                    <div class="modal-header">
                        <a class="close" data-dismiss="modal">×</a>
                        <h3>
                            修改临床资源负责人</h3>
                    </div>
                    <div class="modal-body" style="margin: 0px auto">
                        <asp:DropDownList runat="server" ID="ddlUser">
                        </asp:DropDownList>
                    </div>
                    <div class="modal-footer">
                        <asp:LinkButton class="btn btn-primary" ID="lbtnSelectUser" runat="Server" CommandName="select"
                            CausesValidation="false" Text="确定" OnCommand="lbtnSelectUser_Command"></asp:LinkButton>
                        <a data-dismiss="modal" href="#" class="btn">关闭</a>
                    </div>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    所在城市
                </label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtCity"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCity"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    医院名称
                </label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtHospital">
                    </asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtHospital"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    科室名称
                </label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtDepartmentName"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtDepartmentName"
                        ErrorMessage="输入不正确" ValidationExpression="(.){0,30}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    科室简介
                </label>
                <div class="controls">
                    <asp:TextBox runat="Server" ID="txtDepartmentIntro" Width="300px" Height="120px" TextMode="MultiLine">
                    </asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtDepartmentIntro"
                        ErrorMessage="输入过长" ValidationExpression="(.|\s){0,200}" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <div class="controls">
                    <asp:Button class="btn btn-primary" ID="addCustomer" Text="确定" runat="server" OnClick="Modify_ClinicalResource" />
                    <asp:Button class="btn" ID="btnCancel" Text="取消" runat="Server" OnClick="Abort" />
                </div>
            </div>
            <div width="100%">
                <span><strong>临床资源联系人信息</strong> </span><i class="icon-plus-sign"></i><a href="AddClinicalContact.aspx?clinicalResourceID=<%=clinicalResourceID %>">添加</a>
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
                    <td align="center">
                    </td>
                </tr>
                <asp:Repeater runat="Server" ID="rpContactList" OnItemCommand="rpContactList_ItemCommand">
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
                            <td align="center">
                                <asp:LinkButton runat="Server" ID="lbtnRpAddVisitRecord" CommandName="addVisitRecord"
                                    Text="添加拜访记录" CausesValidation="false" CommandArgument='<%#Eval("联系人ID") %>'></asp:LinkButton>
                                <asp:LinkButton runat="Server" ID="lbtnRpEdit" CommandName="edit" Text="编辑" CausesValidation="false"
                                    CommandArgument='<%#Eval("联系人ID") %>'></asp:LinkButton>
                                <asp:LinkButton runat="Server" ID="lbtnRpDelete" CommandName="delete" Text="删除" CausesValidation="false"
                                    CommandArgument='<%#Eval("联系人ID") %>' OnClientClick="return confirm('确定删除？')"></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <div style="height: 20px; text-align: center;">
                <webdiyer:AspNetPager ID="ContactPager" runat="server" AlwaysShow="True" ButtonImageAlign="Middle"
                    CssClass="p_num" CurrentPageButtonClass="p_num_currentPage" CustomInfoClass=""
                    CustomInfoStyle="" FirstPageText="[首页]" Font-Size="9pt" Font-Underline="False"
                    InputBoxStyle="p_input" LastPageText="[尾页]" NextPageText="[后一页]" NumericButtonCount="8"
                    NumericButtonTextFormatString="[{0}]" OnPageChanged="Contact_PageChanged" PageSize="5"
                    PrevPageText="[前一页]" ShowInputBox="Never" ShowNavigationToolTip="True" ToolTip="分页"
                    CustomInfoTextAlign="NotSet">
                </webdiyer:AspNetPager>
            </div>
            </form>
        </div>
    </div>
</asp:Content>
