<%@ Page Language="C#" Async="true"   EnableEventValidation="false" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="AdvancedSearch.aspx.cs" Inherits="web_AdvancedSearch" Title="高级查询" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>
    <script src="../../bootstrap/js/bootstrap-modal.js" type="text/javascript"></script>
    <script src="../../bootstrap/js/bootstrap-dropdown.js" type="text/javascript"></script>
     <link href="../../script/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script src="../../script/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script type="text/javascript">

        var xmlHttp=null;              
        function $(id)
        {
            return document.getElementById(id);
        }
        function createXMLHttpRequest() 
        { 
            if(xmlHttp == null){
                if(window.XMLHttpRequest) {
                    //Mozilla 浏览器
                    xmlHttp = new XMLHttpRequest();
                }else if(window.ActiveXObject) {
                    // IE浏览器
                    try {
                        xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
                    } catch (e) {
                        try {
                            xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
                        } catch (e) {
                        }
                    }
                }
            }
        } 
        
        function openAjax(val,b) 
        {   
            
            if( xmlHttp == null)
            {                
                createXMLHttpRequest();  
                if( xmlHttp == null)
                {
                    //alert('出错');
                    return ;
                }
            }
            if (b == "true") 
            {
                 $('<%=DocCate.ClientID %>').options[0]=new Option("正在加载...",""); 
                 $('<%=DocCate.ClientID %>').disabled=true; 
                 try
                {
                    xmlHttp.open("get","GetDocCateByDepartId.aspx?DepartID="+val+"&date="+new Date(),true); 
                    //xmlHttp.open("get","GetCityByProvinceID.aspx?PID="+val,true); 
                    
                    xmlHttp.onreadystatechange=xmlHttpChange;             
               
                    xmlHttp.send(null);                
                }
                catch(e)
                {            
                    $('<%=DocCate.ClientID %>').options.length=0; 
                    $('<%=DocCate.ClientID %>').disabled=false;
                }    
            
            }
            else
            {
                 $('<%=SubTaskName.ClientID %>').options[0]=new Option("正在加载...",""); 
                 $('<%=SubTaskName.ClientID %>').disabled=true; 
                 try
                {
                    xmlHttp.open("get","GetSubTaskByProjectNum.aspx?ProjectNum="+val+"&date="+new Date(),true); 
                    //xmlHttp.open("get","GetCityByProvinceID.aspx?PID="+val,true); 
                    
                    xmlHttp.onreadystatechange=xmlHttpChange;             
               
                    xmlHttp.send(null);                
                }
                catch(e)
                {            
                    $('<%=SubTaskName.ClientID %>').options.length=0; 
                    $('<%=SubTaskName.ClientID %>').disabled=false;
                }    
            }

        } 
        
        function xmlHttpChange() 
        { 
            if(xmlHttp.readyState==4) 
            {             
                if(xmlHttp.status==200) 
                {   
                   var dropDownList = document.getElementById("<%=DocDropDownList.ClientID %>");
                   var dropDownListValue=dropDownList.options[dropDownList.selectedIndex].value;
                    if (dropDownListValue=="Document" )
                     {
                        $('<%=DocCate.ClientID %>').options.length=0; 
                        $('<%=DocCate.ClientID %>').disabled=false;    
                        Bind(xmlHttp.responseText,"true"); 
                     }
                     else
                     {
                        $('<%=SubTaskName.ClientID %>').options.length=0; 
                        $('<%=SubTaskName.ClientID %>').disabled=false; 
                        Bind(xmlHttp.responseText,"false");    
                     }                         
                } 
            } 
        }    
        function getSubTask(val)
        {
            if(val=='0')
                return ;
            openAjax(val,"false");
        }
        function getDocCate(val)
        {
                if(val=='0')
                    return ;
                openAjax(val,"true");
        
        }
        function Bind(xmlStr,b)
        {    
            if (b == "true")
            {
                if(xmlStr=='')
                {
                    $('<%=DocCate.ClientID %>').disabled=true; 
                    return;
                }
                $('<%=DocCate.ClientID %>').options.add(new Option("选择文档类型", "0"));
                
                var subTaskIDAndNameList =xmlStr.split(";");
                var num =subTaskIDAndNameList[0];
                for(var i=1; i < num*2+1; i=i+2)
                {
                       $('<%=DocCate.ClientID %>').options.add(new Option(subTaskIDAndNameList[i+1],subTaskIDAndNameList[i]));

                }
                $('<%=DocCate.ClientID %>').disabled=false; 
            
            }   
            else
            {
                    if(xmlStr=='')
                    {
                        $('<%=SubTaskName.ClientID %>').disabled=true; 
                        return;
                    }
                    $('<%=SubTaskName.ClientID %>').options.add(new Option("选择子任务", "0"));
                    
                    var subTaskIDAndNameList =xmlStr.split(";");
                    var num =subTaskIDAndNameList[0];
                    for(var i=1; i < num*2+1; i=i+2)
                    {
                           $('<%=SubTaskName.ClientID %>').options.add(new Option(subTaskIDAndNameList[i+1],subTaskIDAndNameList[i]));

                    }
                    $('<%=SubTaskName.ClientID %>').disabled=false; 
             } 
       
            
            } 
            
//            var xmlDoc;
//            if(window.ActiveXObject)
//            {
//                xmlDoc    = new ActiveXObject('MSXML2.DOMDocument');
//                xmlDoc.async    = false;    
//                xmlDoc.loadXML(xmlStr);                 
//                if(xmlDoc.parseError.errorCode!=0)   
//                {                     
//                    alert("出错！"+xmlDoc.parseError.reason);   
//                }           
//            }
//            else if (document.implementation&&document.implementation.createDocument)
//            {
//                xmlDoc  = document.implementation.createDocument('', '', null);
//                xmlDoc.async=false;
//                xmlDoc.loadXML(xmlStr);   
//            }
//            var elementList;
//            elementList = xmlDoc.getElementsByTagName('City');
//            // 遍历
//            for (var j = 0;j < elementList.length; j++) {                        
//                if(elementList[j].childNodes.length==3)
//                {
//                    $('<%=SubTaskName.ClientID %>').options.add(new Option(elementList[j].childNodes[1].text,elementList[j].childNodes[0].text));
//                }                        
//            }
//            $('<%=SubTaskName.ClientID %>').options[1].selected=true;
        
        function setDocCate()
        {
           var dropDownList = document.getElementById("<%=DocDropDownList.ClientID %>");
           var dropDownListValue=dropDownList.options[dropDownList.selectedIndex].value;
            if (dropDownListValue=="Document" )
            {   
                setDocumentDoc();
            }
            else 
            {
                if (dropDownListValue=="ProjectDoc" )
                {
                    setPojectDoc();
                }
                else
                {
                    dropDownList.selectedIndex=0;
                    setDocumentDoc();
                }
            }
        }
        function setPojectDoc()
        {       
            document.getElementById("项目名称").style.display ="";
            document.getElementById("<%=ProjectName.ClientID%>").style.display ="";
            document.getElementById("子任务名").style.display ="";
            document.getElementById("<%=SubTaskName.ClientID%>").style.display ="";
             document.getElementById("<%=ProjectDocCate.ClientID%>").style.display ="";
             
            document.getElementById("<%=DocVersionText.ClientID%>").style.display ="none";
            document.getElementById("文档版本").style.display ="none";
            document.getElementById("<%=DocCate.ClientID%>").style.display ="none";
            document.getElementById("文档所属部门").style.display ="none";
            document.getElementById("<%=DepartName.ClientID%>").style.display ="none";
            
        }
        
        function setDocumentDoc()
        {
            document.getElementById("<%=DocVersionText.ClientID%>").style.display ="";
            document.getElementById("文档版本").style.display ="";
            document.getElementById("<%=DocCate.ClientID%>").style.display ="";
            document.getElementById("文档所属部门").style.display ="";
            document.getElementById("<%=DepartName.ClientID%>").style.display ="";
            
            document.getElementById("项目名称").style.display ="none";
            document.getElementById("<%=ProjectName.ClientID%>").style.display ="none";
            document.getElementById("子任务名").style.display ="none";
            document.getElementById("<%=SubTaskName.ClientID%>").style.display ="none";
             document.getElementById("<%=ProjectDocCate.ClientID%>").style.display ="none";
            
        }

function setDocCateID(val)
{
    document.getElementById("<%=DocCateIDText.ClientID%>").value = val;
}
function setSubTaskID(val)
{
    document.getElementById("<%=SubTaskIDText.ClientID%>").value = val;

}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="container">
<legend>高级查询</legend>
 
    <form class="form-horizontal">
    <div style="float: right">
     
        <asp:LinkButton ID="ExportExcel" runat="server" OnClick="ExportExcel_Click">导出Excel</asp:LinkButton>
    </div>
    <div class="control-group form-horizontal">
            <label class="control-label">搜索类别</label>
            <div class="controls">
            <asp:DropDownList ID="DocDropDownList" runat="server" onclick="setDocCate()">
                        <asp:ListItem Value="Document">资料文档</asp:ListItem>
                        <asp:ListItem Value="ProjectDoc">项目文档</asp:ListItem>
                    </asp:DropDownList>
            </div>
        </div>
        <div class="control-group form-horizontal">
            <label class="control-label">
                文档名称</label>
            <div class="controls">
                <asp:TextBox ID="DocNameText" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revDocName" runat="server" ControlToValidate="DocNameText"
                    ErrorMessage="文档名称字符数小于50" ValidationExpression="(.|\s){0,50}" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>
    
    <div class="control-group form-horizontal">
            <label class="control-label">
                关键词</label>
            <div class="controls">
                <asp:TextBox ID="DocKeyText" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revDocKey" runat="server" ControlToValidate="DocKeyText"
                    ErrorMessage="关键字字符数小于50" ValidationExpression="(.|\s){0,50}" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
</div >
<div class="control-group form-horizontal">
            <label class="control-label" id="文档版本">
                文档版本</label>
            <div class="controls">
                <asp:TextBox ID="DocVersionText" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revDocVersion" runat="server" ControlToValidate="DocVersionText"
                    ErrorMessage="文档版本字符数小于50" ValidationExpression="(.|\s){0,50}" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>
<div class="control-group form-horizontal">
            <label class="control-label" id="文档所属部门">
                文档所属部门</label>
            <div class="controls">
                <asp:DropDownList ID="DepartName" onchange="getDocCate(this.value)" runat="server">
                </asp:DropDownList>
            </div>
        </div>
<div class="control-group form-horizontal">
            <label class="control-label" id="项目名称">
                项目名称</label>
            <div class="controls">
                <asp:DropDownList ID="ProjectName" onchange="getSubTask(this.value)" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="control-group form-horizontal">
            <label class="control-label" id ="子任务名" >
                子任务名
            </label>
            <div class="controls">
                <asp:DropDownList ID="SubTaskName" runat="server" onchange="setSubTaskID(this.value)">
                </asp:DropDownList>
            </div>
            </div>
        <div class="control-group form-horizontal">
            <label class="control-label">
                文档类别</label>
            <div class="controls">
                <asp:DropDownList ID="ProjectDocCate" runat="server">
                    <asp:ListItem Value="0">选择类别</asp:ListItem>
                    <asp:ListItem Value="1">临床试验</asp:ListItem>
                    <asp:ListItem Value="2">注册</asp:ListItem>
                    <asp:ListItem Value="3">咨询</asp:ListItem>
                    <asp:ListItem Value="4">其他</asp:ListItem>
                </asp:DropDownList>
                 <asp:DropDownList ID="DocCate" runat="server" onchange="setDocCateID(this.value)">
                    </asp:DropDownList>
            </div>
        </div>
        <div class="control-group form-horizontal">
            <label class="control-label">
                上传人</label>
            <div class="controls">
                <asp:DropDownList ID="UploadUserList" runat="server">
                </asp:DropDownList>
            </div>
        </div>
         <div class="control-group form-horizontal">
            <label class="control-label">
                起始时间</label>
            <div class="controls">
                <span class="add-on"><i class="icon-calendar"></i></span>
                <input id="UploadTimeBeginText" runat="Server" onfocus="WdatePicker({isShowClear:false,readOnly:true})"
                    type="text" />
            </div>
        </div>
         <div class="control-group form-horizontal">
            <label class="control-label">
                结束时间</label>
            <div class="controls">
                <span class="add-on"><i class="icon-calendar"></i></span>
                <input id="UploadTimeEndText" runat="Server" onfocus="WdatePicker({isShowClear:false,readOnly:true})"
                    type="text" />
                <asp:CompareValidator ID="cvUploadTime" ControlToValidate="UploadTimeEndText" runat="server"
                    ErrorMessage="起始时间应该早于结束之间" ControlToCompare="UploadTimeBeginText" Operator="GreaterThanEqual"></asp:CompareValidator>
            </div>
        </div>
        <div class="control-group form-horizontal">
            <div class="controls">
             <asp:Button class="btn btn-primary" ID="AdvancedSearchButton" runat="server" Text="高级查询"
                    OnClick="AdvancedSearchButton_Click" />
            </div>
            </div>
        <div>
       
        
</form>
<div align="center">
    </div>
    <div>
        <asp:HiddenField ID="SubTaskIDText" runat="server" />
        <asp:HiddenField ID="DocCateIDText" runat="server" />
    </div>
    <div style="padding-top:10px;" align="center">
        <asp:Repeater ID="DocRepeater" runat="server" 
            OnItemCommand="DocRepeater_ItemCommand" 
            onitemdatabound="DocRepeater_ItemDataBound">
            <HeaderTemplate>
                <table class="table table-striped table-bordered table-condensed" border="0" cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td visible="false">
                            编号
                        </td>
                        <td>
                            名称
                        </td>
                        <td>
                            版本
                        </td>
                        <td>
                            类别
                        </td>
                        <td>
                            所属部门
                        </td>
                        <td>
                            上传人
                        </td>
                        <td>
                            上传时间
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="Label11" runat="Server" Text='<%# DataBinder.Eval( Container.DataItem, "docID") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "名称") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "版本") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "类别") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "所属部门") %>'></asp:Label>
                        <td>
                            <asp:Label ID="Label6" runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "上传人") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label7" runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "上传时间") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:LinkButton ID="ExploreBtn" runat="server" CommandName="ExploreDocument" CommandArgument='<%# DataBinder.Eval( Container.DataItem, "docID") %>'>浏览</asp:LinkButton>
                            <asp:LinkButton ID="ModifyBtn" runat="server" CommandName="ModifyDocument" CommandArgument='<%# DataBinder.Eval( Container.DataItem, "docID") %>'>修改</asp:LinkButton>
                            <asp:LinkButton ID="DownloadBtn" runat="server" CommandName="DownloadDocument" CommandArgument='<%# DataBinder.Eval( Container.DataItem, "docID") %>'>下载</asp:LinkButton>
                            <asp:LinkButton ID="DeleteBtn" runat="server" CommandName="DeleteDocument" CommandArgument='<%# DataBinder.Eval( Container.DataItem, "docID") %>'>删除</asp:LinkButton>
                        </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div>
        <asp:Repeater ID="ProjDocRepeater" runat="server" 
            OnItemCommand="ProjDocRepeater_ItemCommand" 
            onitemdatabound="ProjDocRepeater_ItemDataBound">
            <HeaderTemplate>
                <table class="table table-striped table-bordered table-condensed" border="0" cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td visible="false">
                             编号
                        </td>
                        <td>
                            名称
                        </td>
                        <td>
                            类别
                        </td>
                        <td>
                            项目子任务
                        </td>
                        <td>
                            上传人
                        </td>
                        <td>
                            上传时间
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="Label12"  runat="Server" Text='<%# DataBinder.Eval( Container.DataItem, "docID") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label13"  runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "名称") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label14"  runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "类别") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label15"  runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "项目子任务") %>'></asp:Label>
                        <td>
                            <asp:Label ID="Label16" runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "上传人") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label17" runat="Server" Text='<% #DataBinder.Eval( Container.DataItem, "上传时间") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:LinkButton ID="ExploreBtn" runat="server" CommandName="ExploreDocument" CommandArgument='<%# DataBinder.Eval( Container.DataItem, "docID") %>'>浏览</asp:LinkButton>
                            <asp:LinkButton ID="ModifyBtn" runat="server" CommandName="ModifyDocument" CommandArgument='<%# DataBinder.Eval( Container.DataItem, "docID") %>'>修改</asp:LinkButton>
                            <asp:LinkButton ID="DownloadBtn" runat="server" CommandName="DownloadDocument" CommandArgument='<%# DataBinder.Eval( Container.DataItem, "docID") %>'>下载</asp:LinkButton>
                            <asp:LinkButton ID="DeleteBtn" runat="server" CommandName="DeleteDocument" CommandArgument='<%# DataBinder.Eval( Container.DataItem, "docID") %>'>删除</asp:LinkButton>
                        </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div style="height: 20px; text-align: center;">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" ButtonImageAlign="Middle"
            CssClass="p_num" CurrentPageButtonClass="p_num_currentPage" CustomInfoClass=""
            CustomInfoStyle="" FirstPageText="[首页]" Font-Size="9pt" Font-Underline="False"
            InputBoxStyle="p_input" LastPageText="[尾页]" NextPageText="[后一页]" NumericButtonCount="8"
            NumericButtonTextFormatString="[{0}]" OnPageChanged="AspNetPager1_PageChanged"
            PageSize="5" PrevPageText="[前一页]" ShowInputBox="Never" ShowNavigationToolTip="True"
            ToolTip="分页" CustomInfoTextAlign="NotSet">
        </webdiyer:AspNetPager>
    </div>
     <script type="text/javascript">setDocCate();</script>
     </div>
</asp:Content>

