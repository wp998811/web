<%@ Page Language="C#" MasterPageFile="~/web/index.master" Title="无标题页" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div width="100%">
        <div width="100%">
            <span>项目信息</span>
            <a href="">编辑</a>
        </div>
        <table width="100%" id="projectInfo" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td>
                                项目名称
                            </td>
                            <td>
                                项目1
                            </td>
                            <td>
                                项目管理人员
                            </td>
                            <td>
                                管理人员1
                            </td>
                            <td>
                                客户名称
                            </td>
                            <td>
                                客户名称1
                            </td>
                        </tr>
                        <tr>
                            <td>
                                项目类型
                            </td>
                            <td>
                                临床试验
                            </td>
                            <td>
                                开始日期
                            </td>
                            <td>
                                2012-7-14
                            </td>
                            <td>
                                结束日期
                            </td>
                            <td>
                                2012-9-14
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
               <td>
                    项目简介
                </td> 
            </tr>
            <tr>
               <td>
                    项目简介项目简介项目简介项目简介项目简介项目简介项目简介项目简介项目简介项目简介项目简介项目简介项目简介
                </td> 
            </tr>
        </table>
        
        <div style="padding-top:10px;">
        </div>
       
       <div width="100%">
            <div width="100%">
                <span>项目成员</span>
                <a href="">编辑</a>
            </div>
            <div width="100%">
                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                    <tr>
                        <td>项目管理人员</td>
                        <td></td>
                        <td>其他参与人员</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>员工1</td>
                        <td></td>
                        <td>员工2</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td>员工3</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td>员工4</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td>员工5</td>
                    </tr>
                </table>
            </div>
        </div>
        
        <div style="padding-top:10px;">
        </div>
        <div>
            <div>
                <span>项目进度</span>
                <span><a>新增</a></span>
            </div>
            <div>
            </div>
        </div>
        
        <div style="padding-top:10px;">
        </div>
        
        <div>
            <table width="100%" cellspacing="0" cellpadding="0">
                <tr>
                    <td>子任务名称</td>
                    <td>工期</td>
                    <td>开始日期</td>
                    <td>结束日期</td>
                    <td>完成产物</td>
                    <td>前置任务</td>
                    <td>所需资源名称</td>
                    <td>负责人</td>
                    <td>负责人邮箱</td>
                    <td>负责人电话</td>
                    <td>自动提醒</td>
                    <td>任务状态</td>
                    <td></td>
                </tr>
                <tr>
                    <td>名称a</td>
                    <td>7</td>
                    <td>2012-7-14</td>
                    <td>2012-7-21</td>
                    <td>文档a</td>
                    <td>任务b</td>
                    <td>资源a</td>
                    <td>员工1</td>
                    <td>12345@qq.com</td>
                    <td>123456789</td>
                    <td>是</td>
                    <td>
                        <select id="select1">
                        <option value="0">待执行</option>
                        <option value="1">执行中</option>
                        <option value="0">已完成</option>
                        <option value="1">已取消</option>
                        </select>
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
        
    </div>
</asp:Content>

