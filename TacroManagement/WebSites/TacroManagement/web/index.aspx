<%@ Page Language="C#" MasterPageFile="~/web/index.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="web_index" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="width: 100%;">
        <div style="width: 100%; height: 10px;">
        </div>
        <div style="width: 100%">
            <div style="width: 40%; float: left;">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="30" background="../images/tab_05.gif">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="12" height="30">
                                        <img src="../images/tab_03.gif" width="12" height="30" />
                                    </td>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="46%" valign="middle">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="5%">
                                                                <div align="center">
                                                                    <img src="../images/tb.gif" width="16" height="16" /></div>
                                                            </td>
                                                            <td width="90%" class="STYLE1">
                                                                <span class="STYLE3">待办事宜</span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="54%">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="16">
                                        <img src="../images/tab_07.gif" width="16" height="30" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="8" background="../images/tab_12.gif">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="b5d6e6" onmouseover="changeto()"
                                            onmouseout="changeback()">
                                            <tr>
                                                <td width="40%" height="22" background="../images/bg.gif" bgcolor="#FFFFFF">
                                                    <div align="center">
                                                        <span class="STYLE_TABLE_WORD">事宜名称</span></div>
                                                </td>
                                                <td width="40%" height="22" background="../images/bg.gif" bgcolor="#FFFFFF">
                                                    <div align="center">
                                                        <span class="STYLE_TABLE_WORD">到期时间</span></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="20" bgcolor="#FFFFFF">
                                                    <div align="center" class="STYLE_TABLE_WORD">
                                                        <div align="center">
                                                            xx注册证到期提醒</div>
                                                    </div>
                                                </td>
                                                <td height="20" bgcolor="#FFFFFF">
                                                    <div align="center">
                                                        <span class="STYLE_TABLE_WORD">2012/8/20</span></div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="8" background="../images/tab_15.gif">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="35" background="../images/tab_19.gif">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="12" height="35">
                                        <img src="../images/tab_18.gif" width="12" height="35" />
                                    </td>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        </table>
                                    </td>
                                    <td width="16">
                                        <img src="../images/tab_20.gif" width="16" height="35" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="width: 60%; float: right;">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="30" background="../images/tab_05.gif">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="12" height="30">
                                        <img src="../images/tab_03.gif" width="12" height="30" />
                                    </td>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="46%" valign="middle">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="5%">
                                                                <div align="center">
                                                                    <img src="../images/tb.gif" width="16" height="16" /></div>
                                                            </td>
                                                            <td width="90%" class="STYLE1">
                                                                <span class="STYLE3">项目最新动态</span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="54%">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="16">
                                        <img src="../images/tab_07.gif" width="16" height="30" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="8" background="../images/tab_12.gif">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="b5d6e6" onmouseover="changeto()"
                                            onmouseout="changeback()">
                                            <tr>
                                                <td width="30%" height="22" background="../images/bg.gif" bgcolor="#FFFFFF">
                                                    <div align="center">
                                                        <span class="STYLE_TABLE_WORD">文件名称</span></div>
                                                </td>
                                                <td width="20%" height="22" background="../images/bg.gif" bgcolor="#FFFFFF">
                                                    <div align="center">
                                                        <span class="STYLE_TABLE_WORD">上传时间</span></div>
                                                </td>
                                                <td width="20%" height="22" background="../images/bg.gif" bgcolor="#FFFFFF">
                                                    <div align="center">
                                                        <span class="STYLE_TABLE_WORD">负责人</span></div>
                                                </td>
                                                <td width="30%" height="22" background="../images/bg.gif" bgcolor="#FFFFFF">
                                                    <div align="center">
                                                        <span class="STYLE_TABLE_WORD">项目名称</span></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="20" bgcolor="#FFFFFF">
                                                    <div align="center" class="STYLE_TABLE_WORD">
                                                        <div align="center">
                                                            文件1</div>
                                                    </div>
                                                </td>
                                                <td height="20" bgcolor="#FFFFFF">
                                                    <div align="center">
                                                        <span class="STYLE_TABLE_WORD">2012/8/15</span></div>
                                                </td>
                                                <td height="20" bgcolor="#FFFFFF">
                                                    <div align="center">
                                                        <span class="STYLE_TABLE_WORD">员工1</span>
                                                    </div>
                                                </td>
                                                <td height="20" bgcolor="#FFFFFF">
                                                    <div align="center">
                                                        <span class="STYLE_TABLE_WORD">项目1</span>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="8" background="../images/tab_15.gif">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="35" background="../images/tab_19.gif">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="12" height="35">
                                        <img src="../images/tab_18.gif" width="12" height="35" />
                                    </td>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        </table>
                                    </td>
                                    <td width="16">
                                        <img src="../images/tab_20.gif" width="16" height="35" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div style="width: 100%;">
            <table width="100%" cellpadding="0" cellspacing="0">
            </table>
        </div>
        <div style="width: 100%; margin-top: 10px;">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="30" background="../images/tab_05.gif">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="12" height="30">
                                    <img src="../images/tab_03.gif" width="12" height="30" />
                                </td>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="46%" valign="middle">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="5%">
                                                            <div align="center">
                                                                <img src="../images/tb.gif" width="16" height="16" /></div>
                                                        </td>
                                                        <td width="90%" class="STYLE1">
                                                            <span class="STYLE3">知识库</span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="54%">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="16">
                                    <img src="../images/tab_07.gif" width="16" height="30" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="8" background="../images/tab_12.gif">
                                    &nbsp;
                                </td>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="b5d6e6" onmouseover="changeto()"
                                        onmouseout="changeback()">
                                        <tr>
                                            <td width="25%" height="22" background="../images/bg.gif" bgcolor="#FFFFFF">
                                                <div align="center">
                                                    <span class="STYLE_TABLE_WORD">文件名称</span></div>
                                            </td>
                                            <td width="15%" height="22" background="../images/bg.gif" bgcolor="#FFFFFF">
                                                <div align="center">
                                                    <span class="STYLE_TABLE_WORD">文件类别</span></div>
                                            </td>
                                            <td width="20%" height="22" background="../images/bg.gif" bgcolor="#FFFFFF">
                                                <div align="center">
                                                    <span class="STYLE_TABLE_WORD">部门</span></div>
                                            </td>
                                            <td width="20%" height="22" background="../images/bg.gif" bgcolor="#FFFFFF">
                                                <div align="center">
                                                    <span class="STYLE_TABLE_WORD">上传人</span></div>
                                            </td>
                                            <td width="20%" height="22" background="../images/bg.gif" bgcolor="#FFFFFF">
                                                <div align="center">
                                                    <span class="STYLE_TABLE_WORD">上传时间</span></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="20" bgcolor="#FFFFFF">
                                                <div align="center" class="STYLE_TABLE_WORD">
                                                    <div align="center">
                                                        文档一</div>
                                                </div>
                                            </td>
                                            <td height="20" bgcolor="#FFFFFF">
                                                <div align="center">
                                                    <span class="STYLE_TABLE_WORD">类别a</span></div>
                                            </td>
                                            <td height="20" bgcolor="#FFFFFF">
                                                <div align="center">
                                                    <span class="STYLE_TABLE_WORD">部门a</span></div>
                                            </td>
                                            <td height="20" bgcolor="#FFFFFF">
                                                <div align="center">
                                                    <span class="STYLE_TABLE_WORD">员工a</span></div>
                                            </td>
                                            <td height="20" bgcolor="#FFFFFF">
                                                <div align="center">
                                                    <span class="STYLE_TABLE_WORD">2012/8/9</span></div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="8" background="../images/tab_15.gif">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="35" background="../images/tab_19.gif">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="12" height="35">
                                    <img src="../images/tab_18.gif" width="12" height="35" />
                                </td>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    </table>
                                </td>
                                <td width="16">
                                    <img src="../images/tab_20.gif" width="16" height="35" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div style="width: 100%;">
            <table width="100%" cellpadding="0" cellspacing="0">
            </table>
        </div>
        <div style="width: 100%; margin-top: 10px;">
            <div style="width: 40%; float: left;">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="30" background="../images/tab_05.gif">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="12" height="30">
                                        <img src="../images/tab_03.gif" width="12" height="30" />
                                    </td>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="46%" valign="middle">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="5%">
                                                                <div align="center">
                                                                    <img src="../images/tb.gif" width="16" height="16" /></div>
                                                            </td>
                                                            <td width="90%" class="STYLE1">
                                                                <span class="STYLE3">项目管理</span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="54%">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="16">
                                        <img src="../images/tab_07.gif" width="16" height="30" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="8" background="../images/tab_12.gif">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="b5d6e6" onmouseover="changeto()"
                                            onmouseout="changeback()">
                                            <tr>
                                                <td width="40%" height="22" background="../images/bg.gif" bgcolor="#FFFFFF">
                                                    <div align="center">
                                                        <span class="STYLE_TABLE_WORD">项目名称</span></div>
                                                </td>
                                                <td width="40%" height="22" background="../images/bg.gif" bgcolor="#FFFFFF">
                                                    <div align="center">
                                                        <span class="STYLE_TABLE_WORD">客户名称</span></div>
                                                </td>
                                                <td width="20%" height="22" background="../images/bg.gif" bgcolor="#FFFFFF">
                                                    <div align="center">
                                                        <span class="STYLE_TABLE_WORD">创建时间</span></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="20" bgcolor="#FFFFFF">
                                                    <div align="center" class="STYLE_TABLE_WORD">
                                                        <div align="center">
                                                            项目1</div>
                                                    </div>
                                                </td>
                                                <td height="20" bgcolor="#FFFFFF">
                                                    <div align="center">
                                                        <span class="STYLE_TABLE_WORD">客户1</span></div>
                                                </td>
                                                <td height="20" bgcolor="#FFFFFF">
                                                    <div align="center">
                                                        <span class="STYLE_TABLE_WORD">2007-11-16</span>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="8" background="../images/tab_15.gif">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="35" background="../images/tab_19.gif">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="12" height="35">
                                        <img src="../images/tab_18.gif" width="12" height="35" />
                                    </td>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        </table>
                                    </td>
                                    <td width="16">
                                        <img src="../images/tab_20.gif" width="16" height="35" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
