using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Common;

namespace rumen.Controllers
{
    public class SendEmailController : Controller
    {
        public IActionResult Index()
        {
            SendMail mail = new SendMail();
            mail.FromEmailAddr = "g@aliyun.com";
            mail.ToEmailAddr = "s@163.com";
            mail.ServerAddr = "smtp.aliyun.com";
            mail.ServerPort = 25;
            mail.Subject = "Mailkit测试";
            mail.Text = "测试邮件";
            mail.FromEmailName = "zhang";
            mail.FromEmailPassword = "123";
            //hehiehi

            try
            {
                mail.SentEmail();
                return Content("邮件发送成功！");
            }
            catch (Exception ex)
            {
                return Content("邮件发送失败" + ex.Message);
            }
        }
    }
}