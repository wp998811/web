<%@ Page Language="C#" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="ModifyPassword.aspx.cs" Inherits="web_ModifyPassword" Title="用户密码修改" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />

    <script src="../../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>

    <script src="../../bootstrap/js/bootstrap-modal.js" type="text/javascript"></script>

    <script src="../../bootstrap/js/bootstrap-dropdown.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
    <legend>修改密码</legend>
    <form class="form-horizontal">
     <div class="control-group form-horizontal">
            <label class="control-label">
                旧密码</label>
            <div class="controls">
                <asp:TextBox ID="OldPassword" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvOldPassword" runat="server" ErrorMessage="请输入旧密码"
                    ControlToValidate="OldPassword" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revOldPassword" runat="server" ControlToValidate="OldPassword"
                    ErrorMessage="密码字符数小于50" ValidationExpression=".{0,50}" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>
         <div class="control-group form-horizontal">
            <label class="control-label">
                新密码</label>
            <div class="controls">
                <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ErrorMessage="请输入新密码"
                    ControlToValidate="NewPassword" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revNewPassword" runat="server" ControlToValidate="NewPassword"
                    ErrorMessage="密码字符数小于50" ValidationExpression=".{0,50}" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>
         <div class="control-group form-horizontal">
            <label class="control-label">
                确认密码</label>
             <div class="controls">
                 <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                 <asp:CompareValidator ID="cvConfirmPassword" ControlToValidate="ConfirmPassword"
                     ControlToCompare="NewPassword" runat="server" ErrorMessage="两次输入密码不一致"></asp:CompareValidator>
             </div>
        </div>
        <div class="control-group form-horizontal">
            <div class="controls">
             <asp:Button class="btn btn-primary" ID="ModifyButton" runat="server" Text="确定" 
                    onclick="ModifyButton_Click" />
               <asp:HyperLink class="btn" ID="CancelLink" runat="server" NavigateUrl="../Home/Home.aspx">返回</asp:HyperLink>
            </div>
            </div>
    </form>
        <div class="modal hide fade" id="FailedModal">
            <div class="modal-header">
                <a class="close" data-dismiss="modal"></a>
                <h3>
                   </h3>
            </div>
            <div class="modal-body" style="margin: 0px auto">
                 旧密码不正确
            </div>
            <div class="modal-footer">
                <a data-dismiss="modal" href="#" class="btn">关闭</a>
                <a data-dismiss="modal" href="#" class="btn btn-primary">确定</a>
                
            </div>
        </div>
        <div class="modal hide fade" id="SuccessModal">
            <div class="modal-header">
                <a class="close" data-dismiss="modal"></a>
                <h3>
                   </h3>
            </div>
            <div class="modal-body" style="margin: 0px auto">
               修改成功返回
            </div>
            <div class="modal-footer">
                <a data-dismiss="modal" href="#" class="btn">关闭</a>
                <asp:LinkButton class="btn btn-primary" ID="ReturnHome" runat="Server" 
                            CommandName="Return" CausesValidation="false" Text="确定" 
                            oncommand="ReturnHome_Command"></asp:LinkButton>
                
            </div>
        </div>
<%--<script type="text/javascript">$("#FailedModal").modal();</script>--%>
<%--<script type="text/javascript">document.getElementById("#FailedModal").modal();</script>--%>
    </div>
</asp:Content>

