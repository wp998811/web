<%@ Page Language="C#" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="projectInfo.aspx.cs" Inherits="web_projectInfo" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>
    <script src="../bootstrap/js/bootstrap-modal.js" type="text/javascript"></script>

    <script src="../bootstrap/js/bootstrap-dropdown.js" type="text/javascript"></script>
    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" width="100%">
        <div style="padding-top:10px;">
        </div>
        <ul class="breadcrumb">
            <li><a href="#">项目管理</a> <span class="divider">/</span> </li>
            <li class="active"><asp:Label ID="lblProjectName2" runat="Server" Text=""></asp:Label></li>
        </ul>
        <div width="100%">
            <span> <strong>项目信息</strong> </span>
            <i class="icon-pencil"></i><a href="projectModify.aspx?ProjectNum=<%=projectNum %>">编辑</a>
        </div>
        <table class="table table-striped table-bordered table-condensed" width="100%" cellspacing="0" cellpadding="0" border="0">
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
            <div><span> 项目简介 </span>
            </div>
            <div class="well">
                <asp:Label ID="lblProjectDescription" runat="Server" Text=""></asp:Label>
            </div>     
        </div>
       
       <div width="100%">
            <div width="100%">
                <span> <strong>项目成员</strong> </span><i class="icon-plus-sign"></i>
                <a  data-toggle="modal" href="#myModal" data-keyboard="false" data-backdrop="false">添加</a>
                <div class="modal hide fade" id="myModal">
                    <div class="modal-header">
                        <a class="close" data-dismiss="modal">×</a>
                        <h3>新增项目员工</h3>
                    </div>
                    <div class="modal-body" style="margin:0px auto">
                        <asp:DropDownList runat="Server" ID="ddlDepartMent"></asp:DropDownList>
                        <asp:DropDownList runat="server" ID="ddlUser"></asp:DropDownList>
                    </div>
                    <div class="modal-footer">
                        <a data-dismiss="modal" href="#" class="btn">关闭</a> <a href="#" class="btn btn-primary">确定</a>
                    </div>
                </div>
            </div>
            <div width="100%">
                    <asp:GridView ID="gvUser" runat="Server" AllowPaging="True" Width="100%" 
                        CellPadding="3" BorderWidth="1" AutoGenerateColumns="False" 
                        onrowcommand="gvUser_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="UserName" HeaderText="员工" SortExpression="UserName" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="UserEmail" HeaderText="电子邮件" SortExpression="UserEmail"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="UserPhone" HeaderText="电话" SortExpression="UserPhone"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnUserDelete"  runat="Server" OnClientClick="return confirm('确认要删除吗？');" CausesValidation="false" Text="删除" CommandName="del" CommandArgument='<%# Eval("UserID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>  
                        </Columns>
                    </asp:GridView>
                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                    
                </table>
            </div>
        </div>
        
        <div style="padding-top:10px;">
        </div>
        <div>
            <div>
                <span> <strong>项目子任务</strong> </span>
                <i class="icon-plus-sign"></i><asp:LinkButton runat="server" CommandName="addSubTask" 
                    Text="添加" oncommand="addSubTask_Command"></asp:LinkButton>
            
                <asp:GridView  ID="gvSubTask" runat="Server" AllowPaging="True" Width="100%" CellPadding="3"
                    BorderWidth="1px" AutoGenerateColumns="False" 
                    onrowcommand="gvSubTask_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="TaskName" HeaderText="名称" SortExpression="TaskName"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Period" HeaderText="工期" SortExpression="Period" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="StartTime" HeaderText="开始日期" SortExpression="StartTime" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="EndTime" HeaderText="结束日期" SortExpression="EndTime" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Product" HeaderText="产物" SortExpression="Product" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="ForeTask" HeaderText="前置任务" SortExpression="ForeTask" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Resource" HeaderText="资源名称" SortExpression="Resource"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:HyperLinkField DataTextField="AdminName" HeaderText="负责人" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="IsRemind" HeaderText="自动提醒" SortExpression="IsRemind" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="TaskState" HeaderText="任务状态" SortExpression="TaskState"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnModify" runat="Server" CausesValidation="false" Text="编辑" CommandName="modify" CommandArgument='<%# Eval("TaskId") %>'></asp:LinkButton>
                                <asp:LinkButton ID="btnDelete"  runat="Server" OnClientClick="return confirm('确认要删除吗？');" CausesValidation="false" Text="删除" CommandName="del" CommandArgument='<%# Eval("TaskId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>                     
                    </Columns>
                </asp:GridView>
            </div>
            <div>
            </div>
        </div>
        
        <div style="padding-top:10px;">
        </div>
        <div>
            <span> <strong>项目进度</strong> </span>
        </div>
        <div>
            <div>时间进度</div>
            <div class="progress progress-success">
                <div class="bar" style="width: 80%;">
                </div>
            </div>
        </div>
        
    </div>
</asp:Content>

