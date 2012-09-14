<%@ Page Language="C#"  Async="true" enableEventValidation="false" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="UploadDoc.aspx.cs" Inherits="web_UploadDoc" Title="上传文档" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../../bootstrap/js/jquery-1.8.1.min.js" type="text/javascript"></script>
    <script src="../../bootstrap/js/bootstrap-modal.js" type="text/javascript"></script>

    <script src="../../bootstrap/js/bootstrap-dropdown.js" type="text/javascript"></script>
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
                if (dropDownListValue=="ProjectDoc")
                {
                    setPojectDoc();
                }
                else
                {
                    dropDownList.selectedIndex=0;
                    setDocumentDoc();
                }
            }
            showUsers();
        }
        function setPojectDoc()
        {
        
            document.getElementById("<%=DownLoadPremission.ClientID%>").options[2].text = "本项目用户";
            document.getElementById("项目名称").style.display ="";
            document.getElementById("<%=ProjectName.ClientID%>").style.display ="";
            document.getElementById("子任务名").style.display ="";
            document.getElementById("<%=SubTaskName.ClientID%>").style.display ="";
             document.getElementById("<%=ProjectDocCate.ClientID%>").style.display ="";
             
            
            document.getElementById("文档版本").style.display ="none";
            document.getElementById("<%=DocVersionText.ClientID%>").style.display ="none";          
            document.getElementById("文档所属部门").style.display ="none";
            document.getElementById("<%=DepartName.ClientID%>").style.display ="none";
             document.getElementById("文档状态").style.display ="none";
            document.getElementById("<%=DocState.ClientID%>").style.display ="none";
            document.getElementById("<%=DocCate.ClientID%>").style.display ="none";
        }
        
        function setDocumentDoc()
        {
            document.getElementById("<%=DownLoadPremission.ClientID%>").options[2].text = "本部门用户";
            document.getElementById("项目名称").style.display ="none";
            document.getElementById("<%=ProjectName.ClientID%>").style.display ="none";
            document.getElementById("子任务名").style.display ="none";
            document.getElementById("<%=SubTaskName.ClientID%>").style.display ="none";
             document.getElementById("<%=ProjectDocCate.ClientID%>").style.display ="none";
             
            
            document.getElementById("文档版本").style.display ="";
            document.getElementById("<%=DocVersionText.ClientID%>").style.display ="";          
            document.getElementById("文档所属部门").style.display ="";
            document.getElementById("<%=DepartName.ClientID%>").style.display ="";
            document.getElementById("文档状态").style.display ="";
            document.getElementById("<%=DocState.ClientID%>").style.display ="";
            document.getElementById("<%=DocCate.ClientID%>").style.display ="";
            
        }
        
        function showUsers() 
        {   
            var index = document.getElementById("<%=DownLoadPremission.ClientID%>").selectedIndex;
            if ( index == 3) 
            {
              document.getElementById("users").style.display="";
            }
            else
            {
             document.getElementById("users").style.display="none";
            }
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
<legend>上传文档</legend>
<form class="form-horizontal">

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
                <asp:RequiredFieldValidator ID="rfvDocName" runat="server" ErrorMessage="请输文档名称"
                    ControlToValidate="DocNameText" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revDocName" runat="server" ControlToValidate="DocNameText"
                    ErrorMessage="文档名称字符数小于50" ValidationExpression="(.|\s){0,50}" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>
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
            <label class="control-label">
                关键词</label>
            <div class="controls">
                <asp:TextBox ID="DocKeyText" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revDocKey" runat="server" ControlToValidate="DocKeyText"
                    ErrorMessage="关键字字符数小于50" ValidationExpression="(.|\s){0,50}" Display="Dynamic"></asp:RegularExpressionValidator>
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
            <label class="control-label" id="文档状态">
                文档状态</label>
            <div class="controls">
                <asp:DropDownList ID="DocState" runat="server">
                    <asp:ListItem>受控</asp:ListItem>
                    <asp:ListItem>作废留用</asp:ListItem>
                    <asp:ListItem>作废</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="control-group form-horizontal">
            <label class="control-label">
                下载权限</label>
            <div class="controls">
                <asp:DropDownList ID="DownLoadPremission" onchange="showUsers()" runat="server">
                    <asp:ListItem Value="0">下载权限</asp:ListItem>
                    <asp:ListItem Value="1">所有用户</asp:ListItem>
                    <asp:ListItem Value="2">本项目用户</asp:ListItem>
                    <asp:ListItem Value="3">自定义用户</asp:ListItem>
                </asp:DropDownList>
                <a id="users" data-toggle="modal" href="#myModal" data-keyboard="false" data-backdrop="false">
                    选择</a>
            </div>
        </div>
        <div class="control-group form-horizontal">
            <label class="control-label">
                文档简介</label>
            <div class="controls">
                <asp:TextBox ID="DocDescription" runat="server" Height="100px" Width="250px" TextMode="MultiLine"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revDocDescription" runat="server" ControlToValidate="DocDescription"
                    ErrorMessage="输入字符数必须小于200" ValidationExpression="(.|\s){0,200}" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="control-group form-horizontal">
            <div class="controls">
            <asp:FileUpload  ID="FileUpload1" runat="server" />
             <asp:CompareValidator ID="cvFileUpload" runat="server" ControlToValidate="FileUpload1"
                        ErrorMessage="请选择文件" ValueToCompar="未选择文件" Display="Dynamic" Operator="NotEqual"
                        Type="String"></asp:CompareValidator>
             </div>
        </div>
        <div class="control-group form-horizontal">
            <div class="controls">
            <asp:Button class="btn btn-primary" ID="UploadButton" runat="server" Text="上传文档" OnClick="UploadButton_Click" />
             </div>
        </div>
</form>
</div>
<div align="center">
    
</div >
    <div align="center">
        <table class="table-striped table-bordered table-condensed" border="0" cellspacing="0" cellpadding="0" width="50%">
            <tr>
                <td>
                    
                </td>
                
                <td>
                   
                </td>
            </tr>
        </table>
    </div>
     <div>  
         <asp:HiddenField ID="SubTaskIDText" runat="server" />
         <asp:HiddenField ID="DocCateIDText" runat="server" />
    </div>
    <div class="modal hide fade" id="myModal">
        <div class="modal-header">
            <a class="close" data-dismiss="modal"></a>
            <h3>
                自定义用户</h3>
        </div>
        <div class="modal-body" style="margin: 0px auto">
            <div align="center">
                <asp:Repeater ID="UserRepeater" runat="server">
                    <HeaderTemplate>
                        <table class="table-striped table-bordered table-condensed" border="0" cellspacing="0" cellpadding="0" width="100%">
                            <tr>
                            <td>
                            </td>
                                <td>
                                    用户编号
                                </td>
                                <td>
                                    姓名
                                </td>
                                <td>
                                    用户类别
                                </td>
                                <td>
                                    联系方式
                                </td>
                                <td>
                                    所属部门
                                </td>
                                <td>
                                    电子邮箱
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                        <td>
                         <asp:CheckBox ID="ckb" runat="server" />  
                        </td>
                            <td>
                                <asp:Label ID="UserIDLabel" runat="Server" Text='<%# DataBinder.Eval( Container.DataItem, "UserID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="Server" Text='<%# DataBinder.Eval( Container.DataItem, "姓名") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="Server" Text='<%# DataBinder.Eval( Container.DataItem, "用户类别") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="Server" Text='<%# DataBinder.Eval( Container.DataItem, "联系方式") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="Server" Text='<%# DataBinder.Eval( Container.DataItem, "所属部门") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label6" runat="Server" Text='<%# DataBinder.Eval( Container.DataItem, "电子邮箱") %>'></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div>
            </div>
        </div>
        <div class="modal-footer">
            <a data-dismiss="modal" href="#" class="btn">关闭</a>
            <a class="btn btn-primary" data-dismiss="modal"href="#">确定</a>
        </div>
    </div>
    <script type="text/javascript">setDocCate();</script>
</asp:Content>

