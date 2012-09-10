<%@ Page Language="C#" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="ExplorePicAndTxt.aspx.cs" Inherits="web_ExplorePicAndTxt" Title="浏览图文" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table  style="border-spacing:0.5em" border="0" cellspacing="0" cellpadding="0" width="100%" >
  	<tr >
  	    <td class="docName">	
  	    <br />
  	    <asp:Label ID="DocName" runat="server" Text=""></asp:Label>
  	    </td>
  	</tr>
  	<tr>
  	<td width="70%" align="center">
        <div id="ShowContent" style="width:auto; ">
            <asp:Image ID="ShowImage" runat="server" Height="440px" Width="680px"/>
            <%--<asp:Image ID="ShowImage" runat="server" Height="100%" Width="100%"/>--%>
            <asp:TextBox ID="ShowText" runat="server" TextMode="MultiLine" Height="440px" 
                style="margin-left: 0px" Width="680px" ReadOnly="True"></asp:TextBox>
        </div>
   
    </td>
  	<td>
          <asp:Label ID="DocumentCate" runat="server" Text=""></asp:Label>文档说明
        <div>
            <asp:HiddenField ID="DocID" runat="server" />
  	    </div>
  	  	<div>
  	  	    <asp:Label ID="文档版本" runat="server" Text="文档版本："></asp:Label>
                <asp:Label ID="DocVersion" runat="server" Text=""></asp:Label>
        </div>
  	  	<div>
  	            关键字：<asp:Label ID="DocKey" runat="server" Text=""></asp:Label>
  	</div>
  	  	  	<div>
  	            文档简介：<asp:TextBox  ID="DocDescription" runat="server" Height="200px" ReadOnly="True" 
                    Width="336px" TextMode="MultiLine"></asp:TextBox>
  	</div>
  	  	<div>
  	  	<asp:Label ID="所属部门" runat="server" Text="所属部门:"></asp:Label>
         <asp:Label ID="DepartName" runat="server" Text=""></asp:Label>
  	</div>
  	  	  	<asp:Label ID="项目子任务" runat="server" Text="项目子任务:"></asp:Label>
  	         <asp:Label ID="SubTaskName" runat="server" Text=""></asp:Label>
  	</div>
  	  	<div>
  	           文档类型：<asp:Label ID="DocCate" runat="server" Text=""></asp:Label>
  	</div>
  	 <div>
  	        <asp:Label ID="文档状态" runat="server" Text="文档状态:"></asp:Label>
  	        <asp:Label ID="DocState" runat="server" Text=""></asp:Label>
  	</div>
  	<div>
  	           下载权限：<asp:Label ID="DownloadPremission" runat="server" Text=""></asp:Label>
  	</div>
  	  	<div>
  	           上传人：<asp:Label ID="UploadUser" runat="server" Text=""></asp:Label>
  	</div>
  	  	  	<div>
  	           上传时间：<asp:Label ID="UploadTime" runat="server" Text=""></asp:Label>
  	</div>
          <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" 
              ImageUrl="~/images/dowload.jpg" onclick="DownloadButton_Click" />
    </td>
  	</tr>
  </table>
    
</asp:Content>

