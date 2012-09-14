<%@ Page Title="" Language="C#" MasterPageFile="~/web/Admin/admin.master" AutoEventWireup="true"
    CodeFile="NewResourceAdmin.aspx.cs" Inherits="web_Admin_NewResourceAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div style="padding-top: 10px;">
        </div>
        <ul class="breadcrumb">
            <li><a href="#">资源管理</a><span class="divider">/指定管理</span> </li>
        </ul>
        <div class="row">
            <form class="form-horizontal">
            <div class="form-horizontal control-group">
                <label class="control-label">
                    资源类型
                </label>
                <div class="controls">
                    <div class="input-prepend">
                        <asp:DropDownList ID="ddlResourceType" runat="server">
                            <asp:ListItem Value="客户资源"></asp:ListItem>
                            <asp:ListItem Value="临床资源"></asp:ListItem>
                            <asp:ListItem Value="合作伙伴资源"></asp:ListItem>
                            <asp:ListItem Value="政府资源"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <label class="control-label">
                    管理人员
                </label>
                <div class="controls">
                    <div class="input-prepend">
                        <asp:DropDownList ID="ddlAdmin" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="form-horizontal control-group">
                <div class="controls">
                    <asp:Button ID="btComfirm" class="btn btn-primary" runat="Server" Text="确定" OnClick="btComfirm_Click" />
                    <asp:Button ID="btnCancle" class="btn" runat="Server" Text="取消" OnClick="btnCancle_Click"
                        CausesValidation="False" />
                    <asp:Label ID="lblPrompt" Text="" runat="server" Visible="false" Style="color: Red"></asp:Label>
                </div>
            </div>
            </form>
        </div>
    </div>
</asp:Content>
