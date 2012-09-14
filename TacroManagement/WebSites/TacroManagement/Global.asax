<%@ Application Language="C#" %>
<%@Import Namespace= "System.Collections.Generic"%>
<%@ Import Namespace="System.Net.Mail" %>
<%@ Import Namespace="System.Timers" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        //在应用程序启动时运行的代码
        //每隔一个小时检查一次
        System.Timers.Timer t = new System.Timers.Timer(3600000);
        t.Elapsed += new ElapsedEventHandler(t_Elapsed);
        t.AutoReset = true;
        t.Enabled = true;

    }

    private void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        BLL.SubTask subTaskManage = new BLL.SubTask();
        BLL.User userManage = new BLL.User();
        BLL.FormatString formatString = new BLL.FormatString();

        IList<Model.UserInfo> userList = userManage.GetUsersWithoutClient();
        //定为每天晚上三点到四点之间（前闭后开）发送提醒邮件
        int now_Hour = Convert.ToInt32(DateTime.Now.Hour.ToString());
        int now_Minute = Convert.ToInt32(DateTime.Now.Minute.ToString());
        if (now_Hour == 9)
        {
            foreach (Model.UserInfo userInfo in userList)
            {
                IList<Model.SubTaskInfo> subTaskInfoList = subTaskManage.GetSubTasksIsRemindNow(userInfo.UserID);
                foreach (Model.SubTaskInfo subTaskInfo in subTaskInfoList)
                {
                    int t = (formatString.FormatDate(subTaskInfo.RemindTime)).CompareTo(formatString.FormatDate(DateTime.Now.Date.ToString()));
                    if (t == 0)
                    {
                        string mailFrom = "tacro_wuhan@163.com";
                        string mailHost = "smtp.163.com";
                        string mailUserName = "tacro_wuhan@163.com";
                        string mailPss = "wp880902";
                        string mailTo = userInfo.UserEmail;
                        string mailSubject = "这是致远信息管理系统自动发送的提醒邮件，请不要回复。";
                        string mailMessage = "您好，" + "您的待办事宜 " + subTaskInfo.TaskName + " 今天到期，请注意完成。";
                        string mailAttachmentURL = "";
                        if (SendMail(mailFrom, mailHost, mailUserName, mailPss, mailTo, mailSubject, mailMessage, mailAttachmentURL))
                            return;
                    }
                }
            }
        }


    }

    /// 发送邮件
    /// </summary>
    /// <param name="arrFrom">发送邮件的邮箱地址</param>
    /// <param name="mailHost">发送邮件的邮箱host</param>
    /// <param name="mailUserName">发送邮件的邮箱用户名</param>
    /// <param name="mailPassWord">发送邮件的邮箱密码</param>
    /// <param name="mailTo">接收邮件的邮箱地址</param>
    /// <param name="mailCC">抄送邮件的邮箱地址</param>
    /// <param name="mailSubject">邮件的主题</param>
    /// <param name="mailMessage">邮件的内容</param>
    /// <param name="mailAttachmentURL">邮件的附件</param>
    /// <returns></returns>
    private bool SendMail(string mailFrom, string mailHost, string mailUserName, string mailPassWord, string mailTo, string mailSubject, string mailMessage, string mailAttachmentURL)
    {

        MailMessage emailMessage = new MailMessage();//邮件对象

        string sToEmail = mailTo.Trim();
        emailMessage = new MailMessage(mailFrom, sToEmail, mailSubject, mailMessage);
        emailMessage.IsBodyHtml = true;
        emailMessage.SubjectEncoding = System.Text.Encoding.Default;

        emailMessage.BodyEncoding = System.Text.Encoding.Default;

        if (mailAttachmentURL != null && mailAttachmentURL != "")

            emailMessage.Attachments.Add(new Attachment(mailAttachmentURL));//附件

        //加入
        //emailMessage.Headers.Add("X-Priority", "3");
        //emailMessage.Headers.Add("X-MSMail-Priority", "Normal");
        //emailMessage.Headers.Add("X-Mailer", "Microsoft Outlook Express 6.00.2900.2869");
        //emailMessage.Headers.Add("X-MimeOLE", "Produced By Microsoft MimeOLE V6.00.2900.2869");

        SmtpClient client = new SmtpClient();//邮件发送客户端smtp客户端对象
        client.Host = mailHost;//邮件服务器
        client.Port = 587;
        System.Net.NetworkCredential Credential = new System.Net.NetworkCredential();
        Credential.UserName = mailUserName;   //邮箱帐号,可以在资源文件中配置
        Credential.Password = mailPassWord;//邮箱密码
        client.Credentials = Credential;
        client.EnableSsl = true;
        try
        {
            client.Send(emailMessage);
        }
        catch (Exception e)
        {
            return false;
        }
        return true;
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        //在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e) 
    {
        //在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e) 
    {
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。

    }
       
</script>
