<%@ Page Language="C#" MasterPageFile="~/web/client/client.master" AutoEventWireup="true"
    CodeFile="clientProjectInfo.aspx.cs" Inherits="web_client_clientProjectInfo"
    Title="无标题页" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container" width="100%">
        <div style="padding-top: 10px;">
        </div>
        <ul class="breadcrumb">
            <li><a href="clientProjectList.aspx">项目列表</a> <span class="divider">/</span> </li>
            <li class="active">
                <asp:Label ID="lblProjectName2" runat="Server" Text=""></asp:Label></li>
        </ul>
        <div width="100%">
            <span><strong>项目信息</strong> </span><i id="icon1" runat="Server" class="icon-pencil">
            </i><a runat="Server" id="a1" href="">编辑</a>
        </div>
        <table class="table table-striped table-bordered table-condensed" width="100%" cellspacing="0"
            cellpadding="0" border="0">
            <tr>
                <td>
                    <strong>项目名称</strong>
                </td>
                <td>
                    <asp:Label ID="lblProjectName" runat="Server" Text=""></asp:Label>
                </td>
                <td>
                    <strong>项目管理人员</strong>
                </td>
                <td>
                    <asp:Label ID="lblProjectAdmin" runat="Server" Text=""></asp:Label>
                </td>
                <td>
                    <strong>客户名称</strong>
                </td>
                <td>
                    <asp:Label ID="lblClientName" runat="Server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>项目类型</strong>
                </td>
                <td>
                    <asp:Label ID="lblProjectType" runat="Server" Text=""></asp:Label>
                </td>
                <td>
                    <strong>开始日期</strong>
                </td>
                <td>
                    <asp:Label ID="lblBeginDate" runat="Server" Text=""></asp:Label>
                </td>
                <td>
                    <strong>结束日期</strong>
                </td>
                <td>
                    <asp:Label ID="lblEndDate" runat="Server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <div>
            <div>
                <span>项目简介 </span>
            </div>
            <div class="well">
                <asp:Label ID="lblProjectDescription" runat="Server" Text=""></asp:Label>
            </div>
        </div>
        <div width="100%">
            <div width="100%">
                <span><strong>项目成员</strong> </span><i id="icon3" runat="Server" class="icon-plus-sign">
                </i><a id="a3" runat="Server" data-toggle="modal" href="#myModal" data-keyboard="false"
                    data-backdrop="false">添加</a>
                <div class="modal hide fade" id="myModal">
                    <div class="modal-header">
                        <a class="close" data-dismiss="modal">×</a>
                        <h3>
                            新增项目员工</h3>
                    </div>
                    <div class="modal-body" style="margin: 0px auto">
                        <asp:DropDownList runat="server" ID="ddlUser">
                        </asp:DropDownList>
                    </div>
                    <div class="modal-footer">
                        <a data-dismiss="modal" href="#" class="btn">关闭</a>
                        <asp:LinkButton class="btn btn-primary" ID="lbtnAddUser" runat="Server" CommandName="add"
                            CausesValidation="false" Text="确定" OnCommand="lbtnAddUser_Command"></asp:LinkButton>
                    </div>
                </div>
            </div>
            <div width="100%">
                <div style="padding-top: 10px;">
                </div>
                <table class="table table-striped table-bordered table-condensed" cellspacing="0"
                    cellpadding="0" border="0" style="width: 100%">
                    <tr align="center">
                        <td align="center">
                            员工
                        </td>
                        <td align="center">
                            电子邮件
                        </td>
                        <td align="center">
                            电话
                        </td>
                        <td align="center">
                        </td>
                    </tr>
                    <asp:Repeater runat="Server" ID="rpUserList">
                        <ItemTemplate>
                            <tr align="center">
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpUserName" Text='<%#Eval("UserName") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <a>
                                        <asp:Label runat="Server" ID="lblRpUserEmail" Text='<%#Eval("UserEmail") %>'></asp:Label></a>
                                </td>
                                <td align="center">
                                    <asp:Label runat="Server" ID="lblRpUserPhone" Text='<%#Eval("UserPhone") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:LinkButton OnCommand="lbtnRpDelete_Command" runat="Server" ID="lbtnRpDelete"
                                        CommandName="del" Text="删除" CausesValidation="false" CommandArgument='<%#Eval("UserID") %>'></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
        <div style="padding-top: 10px;">
        </div>
        <div>
            <div>
                <span><strong>项目子任务</strong> </span><i id="icon2" runat="Server" class="icon-plus-sign">
                </i>
                <asp:LinkButton ID="a2" runat="server" CommandName="addSubTask" Text="添加" OnCommand="addSubTask_Command"></asp:LinkButton>
                <table class="table table-striped table-bordered table-condensed">
                    <tr>
                        <td>
                            名称
                        </td>
                        <td>
                            工期
                        </td>
                        <td>
                            开始日期
                        </td>
                        <td>
                            结束日期
                        </td>
                        <td>
                            产物
                        </td>
                        <td>
                            前置任务
                        </td>
                        <td>
                            资源名称
                        </td>
                        <td>
                            负责人
                        </td>
                        <td>
                            自动提醒
                        </td>
                        <td>
                            任务状态
                        </td>
                        <td>
                        </td>
                    </tr>
                    <asp:Repeater ID="rpSubTask" runat="Server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label runat="Server" ID="rpLblSubTaskName" Text='<%#Eval("TaskName") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="Server" ID="rpLblPeriod" Text='<%#Eval("Period") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="Server" ID="rpLblBeginDate" Text='<%#Eval("StartTime") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="Server" ID="rpLblEndDate" Text='<%#Eval("EndTime") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="Server" ID="rpLblProduct" Text='<%#Eval("Product") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="Server" ID="rpLblForeTask" Text='<%#Eval("ForeTask") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="Server" ID="rpLblResource" Text='<%#Eval("Resource") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="Server" ID="rpLblAdminName" Text='<%#Eval("AdminName") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="Server" ID="rpLblIsRemind" Text='<%#Eval("IsRemind") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="Server" ID="rpLblTaskState" Text='<%#Eval("TaskState") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:LinkButton OnCommand="rpLbtnModify_Command" runat="Server" ID="rpLbtnModify"
                                        CausesValidation="false" Text="编辑" CommandName="modify" CommandArgument='<%# Eval("TaskId") %>'></asp:LinkButton>
                                    <asp:LinkButton OnCommand="rpLbtnDel_Command" ID="rpLbtnDel" runat="Server" OnClientClick="return confirm('确定删除？');"
                                        CausesValidation="false" Text="删除" CommandName="del" CommandArgument='<%# Eval("TaskId") %>'></asp:LinkButton>
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
            <div>
            </div>
        </div>
        <div style="padding-top: 10px;">
        </div>
        <div>
            <span><strong>项目进度</strong> </span>
        </div>
        <div>
            <div>
                时间进度：<asp:Label runat="server" ID="lblRate" Text=""></asp:Label></div>
            <div class="well progress progress-striped active">
                <%=strProgress %>
            </div>
            <div style="padding-top: 10px;">
            </div>
            <div>
                子任务完成进度：</div>
            <div class="well">
                <asp:Button ID="Button1" runat="Server" class="btn btn-primary disabled" Style="margin-top: 10px;"
                    Text="开始" /><i style="margin-top: 8px;" class="icon-arrow-right"></i>
                <asp:Repeater runat="Server" ID="rpSubTaskState">
                    <ItemTemplate>
                        <asp:Button runat="Server" Style="margin-top: 10px;" ID="btnSubTaskState" class='<%#Eval("TaskState") %>'
                            Text='<%#Eval("TaskName") %>' /><i style="margin-top: 8px;" class="icon-arrow-right"></i>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Button ID="Button2" runat="Server" class="btn btn-primary disabled" Style="margin-top: 10px;"
                    Text="结束" />
            </div>
        </div>
    </div>
</asp:Content>
