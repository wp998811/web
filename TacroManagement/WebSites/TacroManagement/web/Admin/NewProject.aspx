<%@ Page Title="" Language="C#" MasterPageFile="~/web/Admin/admin.master" AutoEventWireup="true" CodeFile="NewProject.aspx.cs" Inherits="web_Admin_NewProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>新建项目</title>

    <script type="text/javascript" src="../../script/My97DatePicker/WdatePicker.js"></script>

    <link rel="stylesheet" type="text/css" href="../../script/My97DatePicker/skin/WdatePicker.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <h3>
        项目管理 > 新建项目</h3>
    <div>
        <table>
            <tr>
                <td>
                    <span>项目代号 </span>
                </td>
                <td>
                    <asp:TextBox runat="Server" ID="txtProjectNum" Text=""></asp:TextBox>
                    <asp:Label ID="lblStar" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvProjectNum" runat="server" ErrorMessage="请输入项目代号"
                        ControlToValidate="txtProjectNum" Display="Dynamic"></asp:RequiredFieldValidator>
                        
                   <asp:Label ID="lblProjectNum" Text="项目已存在" runat="server" Visible="false" Style="color: Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <span>项目名称 </span>
                </td>
                <td>
                    <asp:TextBox runat="Server" ID="txtProjectName" Text=""></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvProjectName" runat="server" ErrorMessage="请输入项目名称"
                        ControlToValidate="txtProjectName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <span>管理人员 </span>
                </td>
                <td>
                    <asp:DropDownList runat="Server" ID="ddlAdmin">
                    </asp:DropDownList>
                    
            
                    <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td>
             
                </td>
            </tr>
            <tr>
                <td>
                    <span>客户名称 </span>
                </td>
                <td>
                    <asp:DropDownList runat="Server" ID="ddlClient">
                    </asp:DropDownList>
                    <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td>
                    <span>项目类型</span>
                </td>
                <td>
                    <asp:DropDownList runat="Server" ID="ddlProjectType">
                        <asp:ListItem Value="临床试验"></asp:ListItem>
                        <asp:ListItem Value="注册"></asp:ListItem>
                        <asp:ListItem Value="咨询"></asp:ListItem>
                        <asp:ListItem Value="其他"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <span>项目简介 </span>
                </td>
                <td>
                    <asp:TextBox ID="txtProjectDes" class="span4" runat="Server" Rows="6" Text=" " TextMode="MultiLine"
                        EnableTheming="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <span>开始日期</span>
                </td>
                <td>
                    <div class="input-prepend">
                        <span class="add-on"><i class="icon-calendar"></i></span>
                        <input id="iBeginDate" runat="Server" type="text" onfocus="WdatePicker({isShowClear:false,readOnly:true})" />
                    </div>
                </td>
                 <td>
                
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                         ControlToValidate="iBeginDate" ErrorMessage="请选择开始日期"></asp:RequiredFieldValidator>
                
                </td>
            </tr>
            <tr>
                <td>
                    <span>结束日期</span>
                </td>
                <td>
                    <div class="input-prepend">
                        <span class="add-on"><i class="icon-calendar"></i></span>
                        <input id="iEndDate" runat="Server" type="text" style="margin: 0" onfocus="WdatePicker({isShowClear:false,readOnly:true})" />
                    </div>
                </td>
                <td>
                
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="iEndDate" ErrorMessage="请选择结束日期"></asp:RequiredFieldValidator>
                
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
                <td>
                    <asp:Button ID="btnOk" runat="Server" Text="确定" OnClick="btnOk_Click" class="btn-primary" />
                    <asp:Button ID="btnCancel" runat="Server" Text="取消" OnClick="btnCancel_Click" class="btn" />
                </td>
                
                 <td>
                     <asp:Label ID="lblPrompt" Text="" runat="server" Visible="false" Style="color: Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>


</asp:Content>

