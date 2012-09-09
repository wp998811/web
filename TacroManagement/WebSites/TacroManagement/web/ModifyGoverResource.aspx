<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"
    CodeFile="ModifyGoverResource.aspx.cs" Inherits="web_ModifyGoverResource" Title="修改政府资源" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
  function modifyGoverResource() 
  {
         if(confirm("确定要修改？"))
         {
            document.getElementById("<%=modifyGoverResource_Hidden.ClientID %>").click();
         }
         else
            return;
  } 
    </script>

    <div>
        <asp:Label ID="Label1" runat="server" Text="修改政府资源"></asp:Label>
    </div>
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td>
                <asp:Label ID="label_manager" runat="server" Text="负责人" />
            </td>
            <td>
                <asp:TextBox ID="textBox_manager" runat="server" />
            </td>
            <td>
                <asp:Button ID="select_manager" Text="选择负责人" runat="server" OnClick="Select_Manager" />
            </td>
            <asp:TextBox ID="UserID_TextBox" runat="server" Visible="false"></asp:TextBox>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="UserGridView" runat="server" BackColor="White" BorderColor="#DEDFDE"
                    BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                    AutoGenerateColumns="False" DataKeyNames="用户ID" AllowPaging="True" ShowFooter="false"
                    OnRowDataBound="UserGridView_RowDataBound">
                    <Columns>
                        <asp:BoundField HeaderText="序号" ReadOnly="True" />
                        <asp:BoundField DataField="用户名" HeaderText="用户名" ReadOnly="True" />
                        <asp:BoundField DataField="用户类型" HeaderText="用户类型" ReadOnly="True" />
                        <asp:BoundField DataField="邮箱" HeaderText="邮箱" ReadOnly="True" />
                        <asp:BoundField DataField="手机" HeaderText="手机" ReadOnly="True" />
                        <asp:BoundField DataField="所在部门" HeaderText="所在部门" ReadOnly="True" />
                        <asp:TemplateField HeaderText="选择">
                            <ItemTemplate>
                                <asp:CheckBox ID="User_CheckBox" runat="server" OnCheckedChanged="UserCheckBoxChanged"
                                    AutoPostBack="True" />
                                <asp:TextBox ID="User_TextBox" runat="server" Text='<%# Eval("用户ID") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#F7F7DE" />
                    <FooterStyle BackColor="#CCCC99" />
                    <PagerStyle BackColor="White" ForeColor="#66FFCC" HorizontalAlign="Center" BorderStyle="None"
                        Wrap="False" />
                    <PagerSettings Visible="False" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <asp:LinkButton ID="label_UserFirstPage" runat="server" OnClick="User_FirstPage_Click">首页</asp:LinkButton>
                <asp:LinkButton ID="label_UserPrePage" runat="server" OnClick="User_PrePage_Click">上一页</asp:LinkButton>
                <asp:Label ID="label_User_CurrentPage" runat="server"></asp:Label>
                <asp:LinkButton ID="label_UserNextPage" runat="server" OnClick="User_NextPage_Click">下一页</asp:LinkButton>
                <asp:LinkButton ID="label_UserLastPage" runat="server" OnClick="User_LastPage_Click">尾页</asp:LinkButton>
                <asp:Label ID="label_UserGoto" runat="server" Text="跳转到第" />
                <asp:DropDownList ID="ddl_UserPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="User_DropDownList_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="label_UserPage" runat="server" Text="页" />
            </td>
            <td>
                <asp:Button ID="User_Hidden" Text="收起" runat="server" OnClick="UserList_Hidden" Visible="False" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_city" runat="server" Text="城市" />
            </td>
            <td>
                <asp:TextBox ID="textBox_city" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_organName" runat="server" Text="组织名称" />
            </td>
            <td>
                <asp:TextBox ID="textBox_organName" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_organIntro" runat="server" Text="组织介绍" />
            </td>
            <td>
                <asp:TextBox ID="textBox_organIntro" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_contact" runat="server" Text="联系人" />
            </td>
            <td>
                <asp:Button ID="check_Contact" Text="查看联系人" runat="server" OnClick="Select_Contact" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="ContactGridView" runat="server" BackColor="White" BorderColor="#DEDFDE"
                    BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                    AutoGenerateColumns="False" DataKeyNames="联系人ID" AllowPaging="True" ShowFooter="false"
                    OnRowDataBound="ContactGridView_RowDataBound" OnRowDeleting="ContactGridView_RowDeleting"
                    OnRowEditing="ContactGridView_RowEditing">
                    <Columns>
                        <asp:BoundField HeaderText="序号" ReadOnly="True" />
                        <asp:BoundField DataField="联系人姓名" HeaderText="联系人姓名" ReadOnly="True" />
                        <asp:BoundField DataField="职位" HeaderText="职位" ReadOnly="True" />
                        <asp:BoundField DataField="手机" HeaderText="手机" ReadOnly="True" />
                        <asp:BoundField DataField="固定电话" HeaderText="固定电话" ReadOnly="True" />
                        <asp:BoundField DataField="邮箱" HeaderText="邮箱" ReadOnly="True" />
                        <asp:BoundField DataField="地址" HeaderText="地址" ReadOnly="True" />
                        <asp:BoundField DataField="邮编" HeaderText="邮编" ReadOnly="True" />
                        <asp:BoundField DataField="传真号" HeaderText="传真号" ReadOnly="True" />
                        <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                        <asp:TemplateField HeaderText="删除">
                            <ItemTemplate>
                                <asp:LinkButton ID="ContactDelete" runat="server" OnClientClick="return confirm('确定删除？')"
                                    CommandName="Delete" Text="删除"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#F7F7DE" />
                    <FooterStyle BackColor="#CCCC99" />
                    <PagerStyle BackColor="White" ForeColor="#66FFCC" HorizontalAlign="Center" BorderStyle="None"
                        Wrap="False" />
                    <PagerSettings Visible="False" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <asp:LinkButton ID="label_ContactFirstPage" runat="server" OnClick="Contact_FirstPage_Click">首页</asp:LinkButton>
                <asp:LinkButton ID="label_ContactPrePage" runat="server" OnClick="Contact_PrePage_Click">上一页</asp:LinkButton>
                <asp:Label ID="label_Contact_CurrentPage" runat="server"></asp:Label>
                <asp:LinkButton ID="label_ContactNextPage" runat="server" OnClick="Contact_NextPage_Click">下一页</asp:LinkButton>
                <asp:LinkButton ID="label_ContactLastPage" runat="server" OnClick="Contact_LastPage_Click">尾页</asp:LinkButton>
                <asp:Label ID="label_ContactGoto" runat="server" Text="跳转到第" />
                <asp:DropDownList ID="ddl_ContactPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Contact_DropDownList_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="label_ContactPage" runat="server" Text="页" />
                <asp:Button ID="addContact" Text="添加联系人" runat="server" OnClick="Add_GoverContact"
                    Visible="False" />
            </td>
            <td>
                <asp:Button ID="Contact_Hidden" Text="收起" runat="server" OnClick="ContactList_Hidden"
                    Visible="False" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="modifyGoverResource" Text="修改政府资源" runat="server" OnClientClick="modifyGoverResource()" />
                <asp:Button ID="modifyGoverResource_Hidden" Text="修改政府资源" runat="server" OnClick="Modify_GoverResource"
                    Style="display: none" />
            </td>
        </tr>
    </table>
</asp:Content>
