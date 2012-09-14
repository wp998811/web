<%@ Page Language="C#" Async="true" enableEventValidation="false" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="ModifyProjectDoc.aspx.cs" Inherits="web_ModifyProjectDoc" Title="修改项目文档" %>

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
        
        function openAjax(val) 
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
        
        function xmlHttpChange() 
        { 
            if(xmlHttp.readyState==4) 
            {             
                if(xmlHttp.status==200) 
                {         
                    $('<%=SubTaskName.ClientID %>').options.length=0; 
                    $('<%=SubTaskName.ClientID %>').disabled=false; 
                    Bind(xmlHttp.responseText);                     
                } 
            } 
        }    
        function getSubTask(val)
        {
            if(val=='0')
                return ;
            openAjax(val);
        }
        function Bind(xmlStr)
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
      
      function setSubTaskID(val)
        {
            document.getElementById("<%=SubTaskIDText.ClientID%>").value = val;
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
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" >
        <legend>修改文档</legend>
        <form class="form-horizontal">
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
            <label class="control-label">
                项目名称</label>
            <div class="controls">
                <asp:DropDownList ID="ProjectName" onchange="getSubTask(this.value)" runat="server">
                </asp:DropDownList>
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
            <label class="control-label">
                子任务名
            </label>
            <div class="controls">
                <asp:DropDownList ID="SubTaskName" runat="server" onchange="setSubTaskID(this.value)">
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
                文档类别</label>
            <div class="controls">
                <asp:DropDownList ID="ProjectDocCate" runat="server">
                    <asp:ListItem Value="0">选择类别</asp:ListItem>
                    <asp:ListItem Value="1">临床试验</asp:ListItem>
                    <asp:ListItem Value="2">注册</asp:ListItem>
                    <asp:ListItem Value="3">咨询</asp:ListItem>
                    <asp:ListItem Value="4">其他</asp:ListItem>
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
                上传时间</label>
            <div class="controls">
                <span class="add-on"><i class="icon-calendar"></i></span>
                <input id="uploadTime" runat="Server" onfocus="WdatePicker({isShowClear:false,readOnly:true})"
                    type="text" />
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
                <asp:Button class="btn btn-primary" ID="ModifyButton" runat="server" Text="保存修改"
                    OnClick="ModifyButton_Click" />
            </div>
        </div>
        <div>
            <asp:HiddenField ID="SubTaskIDText" runat="server" />
        </div>
        <div>
            <asp:Label ID="DocID" runat="server" Visible="False"></asp:Label>
        </div>
        <div class="modal hide fade" id="myModal">
            <div class="modal-header">
                <a class="close" data-dismiss="modal">×</a>
                <h3>
                    自定义用户</h3>
            </div>
            <div class="modal-body" style="margin: 0px auto">
                <div align="center">
                    <asp:Repeater ID="UserRepeater" runat="server">
                        <HeaderTemplate>
                            <table class="table-striped table-bordered table-condensed" border="0" cellspacing="0"
                                cellpadding="0" width="100%">
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
                <a data-dismiss="modal" href="#" class="btn">关闭</a> <a class="btn btn-primary" data-dismiss="modal"
                    href="#">确定</a>
            </div>
        </div>
        </form>

        <script type="text/javascript">showUsers();</script>

    </div>
</asp:Content>

