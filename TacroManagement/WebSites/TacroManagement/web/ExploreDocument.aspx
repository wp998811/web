<%@ Page Language="C#" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="ExploreDocument.aspx.cs" Inherits="web_ExploreDocument" Title="浏览文档"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css" media="screen">
        html, body
        {
            height: 100%;
        }
        body
        {
            margin: 0;
            padding: 0;
            overflow: auto;
        }
        #flashContent
        {
            display: none;
        }
    </style>

    <script type="text/javascript" src="../script/swfobject/swfobject.js"></script>

    <script type="text/javascript" src="../script/flexpaper_flash_debug.js"></script>

    <script src="../script/flexpaper_flash.js" type="text/javascript"></script>

    <script type="text/javascript" src="../script/jquery.js"></script>

    <script type="text/javascript">
        //获得参数的方法
        var request =
        {
            QueryString: function(val) {
                var uri = window.location.search;
                var re = new RegExp("" + val + "=([^&?]*)", "ig");
                return ((uri.match(re)) ? (uri.match(re)[0].substr(val.length + 1)) : null);
            }
        }
    </script>

    <script type="text/javascript">
        var swfVersionStr = "10.0.0";
        var xiSwfUrlStr = "playerProductInstall.swf";
        var emotion = request.QueryString('emotion');
        var em = decodeURIComponent(emotion);
        var swfFile = em;

        var flashvars = {
            SwfFile: escape(swfFile),
            Scale: 1.0,
            ZoomTransition: "easeOut",
            ZoomTime: 0.5,
            ZoomInterval: 0.2,
            FitPageOnLoad: true,
            FitWidthOnLoad: true,
            PrintEnabled: true,
            FullScreenAsMaxWindow: false,
            ProgressiveLoading: true,

            PrintToolsVisible: true,
            ViewModeToolsVisible: true,
            ZoomToolsVisible: true,
            FullScreenVisible: true,
            NavToolsVisible: true,
            CursorToolsVisible: true,
            SearchToolsVisible: true,
            localeChain: "en_US"
        };

        var params = {

    }
    params.quality = "high";
    params.bgcolor = "#ffffff";
    params.allowscriptaccess = "sameDomain";
    params.allowfullscreen = "true";
    var attributes = {};
    attributes.id = "FlexPaperViewer";
    attributes.name = "FlexPaperViewer";
    swfobject.embedSWF(
                "FlexPaperViewer.swf", "flashContent",
                "730", "580",
                swfVersionStr, xiSwfUrlStr,
                flashvars, params, attributes);
    swfobject.createCSS("#flashContent", "display:block;text-align:left;");
			
        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <table border="0" cellspacing="0" cellpadding="0" width="100%" >
  	<tr >
  	     <td class="docName">	
  	    <asp:Label ID="DocName" runat="server" Text=""></asp:Label>
  	    </td>
  	</tr>
  	<tr>
  	<td width="70%" align="center">
  	  	 <div align="center">
        <div id="flashContent" style="width:auto; float:right">
            <p>
                To view this page ensure that Adobe Flash Player version 10.0.0 or greater is installed.
            </p>

            <script type="text/javascript">
                var pageHost = ((document.location.protocol == "https:") ? "https://" : "http://");
                document.write("<a href='http://www.adobe.com/go/getflashplayer'><img src='"
									+ pageHost + "www.adobe.com/images/shared/download_buttons/get_flash_player.gif' alt='Get Adobe Flash player' /></a>"); 				
				</script>
        </div>
    </div>
    </td>
  	<td>
          <asp:Label ID="DocumentCate" runat="server" Text=""></asp:Label>文档说明
        <div>
            <asp:HiddenField ID="DocID" runat="server" />
  	    </div>
  	    <div>
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
  	           <asp:Label ID="UserListLabel" runat="server" Text=""></asp:Label>
  	</div>
  	  	<div>
  	           上传人：<asp:Label ID="UploadUser" runat="server" Text=""></asp:Label>
  	</div>
  	  	  	<div>
  	           上传时间：<asp:Label ID="UploadTime" runat="server" Text=""></asp:Label>
  	</div>
          <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" 
              ImageUrl="~/images/dowload.jpg" onclick="DownloadButton_Click" />
  	</tr>
  </table>

</asp:Content>
