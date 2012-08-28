<%@ Page Language="C#" MasterPageFile="~/web/index.master" Title="无标题页" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="../script/My97DatePicker/WdatePicker.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table>
            <tr>
                <td><span>项目名称</span></td>
                <td><input type="text" maxlength="50" id="txtClientName" class="text" width="30px" /> </td>
            </tr>
            <tr>
                <td><span>项目管理人员</span></td>
                <td>
                    <select id="selectProjectManager">
                        <option value="0">员工1</option>
                        <option value="1">员工2</option>
                        <option value="2">员工3</option>
                        <option value="3">员工4</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>客户名称</td>
                <td>
                    <input type="text" maxlength="50" id="Text1" class="text" width="30px" />
                </td>
            </tr>
            <tr>
                <td>项目类型</td>
                <td>
                    <select id="selectProjectType">
                        <option value="0">临床试验</option>
                        <option value="1">注册</option>
                        <option value="2">咨询</option>
                        <option value="3">其他</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>项目简介</td>
                <td>
                    <asp:TextBox ID="tbProjectDescription" runat="Server" Height="100px" TextMode="MultiLine" Width="150px" EnableTheming=true></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>开始日期</td>
                <td>
                    <input class="Wdate" id="projectBeginTime" type="text" onFocus="WdatePicker({isShowClear:false,readOnly:true})" />
                </td>
            </tr>
            <tr>
                <td>结束日期</td>
                <td>
                    <input class="Wdate" id="projectEndTime" type="text"  onFocus="WdatePicker({isShowClear:false,readOnly:true})"/>
                </td>
            </tr>
            <tr>
                <td><asp:Button ID="btnOk" runat="Server" Text="确定"/> </td>
                <td><asp:Button ID="btnCancel" runat="Server" Text="取消"/> </td>
            </tr>
        </table>
    </div>
</asp:Content>

