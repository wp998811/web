<%@ Page Language="C#" MasterPageFile="~/web/index.master"  AutoEventWireup="true" CodeFile="childProjectModify.aspx.cs" Inherits="web_childProjectModify" Title="无标题页"  %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="../script/My97DatePicker/WdatePicker.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div width="100%">
        <div>
            <span>某某项目添加子任务/某某项目>某某子任务编辑</span>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td>子任务名称</td>
                <td><input type="text" maxlength="50" id="txtClientName" class="text" width="30px" value="名字a" /></td>
            </tr>
            <tr>
                <td>工期（单位：天）</td>
                <td><input type="text" maxlength="50" id="Text1" class="text" width="30px" value="7" /></td>
            </tr>
            <tr>
                <td>开始日期</td>
                <td><input class="Wdate" id="projectEndTime" type="text" value="2012-7-6"  onFocus="WdatePicker({isShowClear:false,readOnly:true})"/></td>
            </tr>
            <tr>
                <td>结束日期</td>
                <td><input class="Wdate" id="Text2" type="text" value="2012-7-13"  onFocus="WdatePicker({isShowClear:false,readOnly:true})"/></td>
            </tr>
            <tr>
                <td>完成产物</td>
                <td><input type="text" maxlength="50" id="Text3" class="text" width="30px" value="文档a" /></td>
            </tr>
            <tr>
                <td>前置任务</td>
                <td><input type="text" maxlength="50" id="Text4" class="text" width="30px" value="任务b" /></td>
            </tr>
            <tr>
                <td>所需资源名称</td>
                <td><input type="text" maxlength="50" id="Text5" class="text" width="30px" value="资源a" /></td>
            </tr>
            <tr>
                <td>负责人</td>
                <td>
                    <select id="selectProjectType">
                        <option value="0">员工1</option>
                        <option value="1">员工2</option>
                        <option value="2">员工3</option>
                        <option value="3">员工4</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>负责人邮箱</td>
                <td><input type="text" maxlength="50" id="Text6" class="text" width="30px" value="12345@qq.com" /></td>
            </tr>
            <tr>
                <td>负责人电话</td>
                <td><input type="text" maxlength="50" id="Text7" class="text" width="30px" value="123456789" /></td>
            </tr>
            <tr>
                <td>自动提醒</td>
                <td>
                <select id="select1">
                        <option value="0">否</option>
                        <option value="1">是</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td><asp:Button ID="btnOk" runat="Server" Text="确定" /></td>
                <td><asp:Button ID="btnCancel" runat="Server" Text="取消" /></td>
            </tr>
        </table>
    </div>
</asp:Content>


