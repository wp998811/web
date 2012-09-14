<%@ Page Language="C#" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="DepartDocCate.aspx.cs" Inherits="web_AddProjDocCate" Title="增加部门文档类型" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>
    <script src="../../bootstrap/js/bootstrap-modal.js" type="text/javascript"></script>
    <script src="../../bootstrap/js/bootstrap-dropdown.js" type="text/javascript"></script>
    
    <script type="text/javascript">
            function showDocCate() 
            {
                var dropDownList = document.getElementById("<%=DocCateName.ClientID%>");
                 var dropDownListText=dropDownList.options[dropDownList.selectedIndex].text;
                 var dropDownListValue=dropDownList.options[dropDownList.selectedIndex].value;
                  document.getElementById("<%=ModifyCategoryName.ClientID%>").value =dropDownListText;
                   document.getElementById("<%=ModifyID.ClientID%>").value =dropDownListValue;
                  
            }
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div align="center">
<table  class="table-striped table-bordered table-condensed" border="0" cellspacing="0" cellpadding="0" width="50%">
	<tr>
		<td>部门</td>
		<td> <asp:DropDownList ID="DepartName" runat="server" AutoPostBack="true">
    </asp:DropDownList></td>
	</tr>
	<tr>
	<td>文档范围</td>
	<td><asp:DropDownList ID="InOutDoc" runat="server" AutoPostBack="true">
        <asp:ListItem Value="1">内部文档</asp:ListItem>
        <asp:ListItem Value="2">外部文档</asp:ListItem>
    </asp:DropDownList></td>
	</tr>
	<tr>
	<td> 文档类别名称</td>
	<td>
        <asp:DropDownList ID="DocCateName" runat="server" onclick="showDocCate()">
        </asp:DropDownList>
    </td>
	</tr>
</table>
    <i class="icon-plus-sign"></i>
    <a  data-toggle="modal" href="#myModal" data-keyboard="false" data-backdrop="false">添加</a>
    <i class="icon-pencil"></i>
    <a  data-toggle="modal" href="#modifyModal" data-keyboard="false" data-backdrop="false">修改</a>
    <i class="icon-trash"></i>
    <asp:LinkButton  ID="DeleteButton" runat="server"   
                            Text="删除" onclick="DeleteButton_Click"></asp:LinkButton>
    <div class="modal hide fade" id="myModal">
                    <div class="modal-header">
                        <a class="close" data-dismiss="modal">×</a>
                        <h3>新增部门文档类别</h3>
                    </div>
                    <div class="modal-body" style="margin:0px auto">
                        <asp:Label ID="DepartVisiblity" runat="server" ></asp:Label>
                        <asp:TextBox ID="CategoryName"
                            runat="server"></asp:TextBox>            
                    </div>
                    <div class="modal-footer">
                        <a data-dismiss="modal" href="#" class="btn">关闭</a> 
                            <asp:LinkButton class="btn btn-primary" ID="AddButton" runat="server"   
                            Text="确定" onclick="AddButton_Click"></asp:LinkButton>
                    </div>
                </div>
                    <div class="modal hide fade" id="modifyModal">
                    <div class="modal-header">
                        <a class="close" data-dismiss="modal">×</a>
                        <h3>修改部门文档类别</h3>
                    </div>
                        <div class="modal-body" style="margin: 0px auto">
                            <asp:Label ID="DepartLabel" runat="server"></asp:Label>
                            <asp:DropDownList ID="ModifyInOrOut" runat="server">
                                <asp:ListItem Value="1">内部文档</asp:ListItem>
                                <asp:ListItem Value="2">外部文档</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="ModifyCategoryName" runat="server"></asp:TextBox>
                            <asp:HiddenField ID="ModifyID" runat="server" />
                        </div>
                    <div class="modal-footer">
                        <a data-dismiss="modal" href="#" class="btn">关闭</a> 
                            <asp:LinkButton class="btn btn-primary" ID="ModifyButton" runat="server"   
                            Text="确定" onclick="ModifyButton_Click"></asp:LinkButton>
                    </div>
                </div>
</div>
    <br />

</asp:Content>

