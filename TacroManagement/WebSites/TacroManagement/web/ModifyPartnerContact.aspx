<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/web/index.master"  CodeFile="ModifyPartnerContact.aspx.cs" Inherits="web_ModifyPartnerContact"  Title="修改政府联系人" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript">
  function modifyPartnerContact() 
  {
         if(confirm("确定要修改？"))
         {
            document.getElementById("<%=modifyPartnerContact_Hidden.ClientID %>").click();
         }
         else
            return;
  } 
</script>
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="修改联系人"></asp:Label>
    
    </div>
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
    	<tr>
    		<td><asp:label id="label_contactName" runat="server" Text="联系人姓名"/></td>
    		<td><asp:TextBox id="textBox_contactName" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_position" runat="server" Text="职位"/></td>
    		<td><asp:TextBox id="textBox_position" runat="server"/></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_mobilephone" runat="server" Text="手机"/></td>
    		<td><asp:TextBox id="textBox_mobilephone" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_telephone" runat="server" Text="固定电话"/></td>
    		<td><asp:TextBox id="textBox_telephone" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_email" runat="server" Text="邮箱"/></td>
    		<td><asp:TextBox id="textBox_email" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_address" runat="server" Text="地址"/></td>
    		<td><asp:TextBox id="textBox_address" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_postCode" runat="server" Text="邮政编码"/></td>
    		<td><asp:TextBox id="textBox_postCode" runat="server" /></td>
    	</tr>
    	<tr>
    		<td><asp:label id="label_faxNumber" runat="server" Text="传真号"/></td>
    		<td><asp:TextBox id="textBox_faxNumber" runat="server" /></td>
    	</tr>
    	<tr>
    	    <td>
    	    <asp:Button id="modifyPartnerContact" Text="修改合作伙伴联系人" runat="server" onclientclick="modifyPartnerContact()"/>
    	    <asp:Button id="modifyPartnerContact_Hidden" Text="修改合作伙伴联系人" runat="server"  OnClick="Modify_PartnerContact" style= "display:none"/>
    	    </td>
    	</tr>
    </table>
</asp:Content>
