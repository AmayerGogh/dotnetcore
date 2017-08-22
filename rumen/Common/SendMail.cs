using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common
{
    /// <summary>
    /// 发送邮件配置信息类
    /// </summary>
    public class SendMail
    {
        /// <summary>
        /// 发送人邮件地址
        /// </summary>
        public string FromEmailAddr { get; set; }
        /// <summary>
        /// 发送人名称
        /// </summary>
        public string FromEmailName { get; set; }
        /// <summary>
        /// 收件人邮箱地址
        /// </summary>
        public string ToEmailAddr { get; set; }
        /// <summary>
        /// 收件人名称
        /// </summary>
        public string ToEmailName { get; set; }
        /// <summary>
        /// 邮件主题
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 邮件附件地址
        /// </summary>
        public string AttachmentPath { get; set; }
        /// <summary>
        /// 邮件正文
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 发送邮件的服务器地址
        /// </summary>
        public string ServerAddr { get; set; }
        /// <summary>
        /// 发送邮件的服务器端口号
        /// </summary>
        public int ServerPort { get; set; }
        /// <summary>
        /// 是否使用ssl
        /// </summary>
        public bool IsSslUsed { get; set; } = false;
        /// <summary>
        /// 发送人密码
        /// </summary>
        public string FromEmailPassword { get; set; }

        /// <summary>
        /// 发送邮件
        /// Nuget安装MailKit组件
        /// Install-Package NETCore.MailKit -Version 2.0.0
        /// </summary>
        /// <param name="path"></param>
        public void SentEmail()
        {
            var message = new MimeMessage();
            //获取From标头中的地址列表，添加指定的地址
            message.From.Add(new MailboxAddress(FromEmailName, FromEmailAddr));
            //获取To头中的地址列表，添加指定的地址
            message.To.Add(new MailboxAddress(ToEmailName, ToEmailAddr));
            //获取或设置消息的主题
            message.Subject = Subject;
            // 创建我们的消息文本，就像以前一样（除了不设置为message.Body）
            var body = new TextPart("plain")
            {
                Text = @"Hey Alice-- Joey"
            };

            // 为位于路径的文件创建图像附件
            MimePart attachment = null;
            if (!string.IsNullOrEmpty(AttachmentPath))
            {
                attachment = new MimePart("image", "gif")
                {
                    ContentObject = new ContentObject(File.OpenRead(AttachmentPath), ContentEncoding.Default),
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    ContentTransferEncoding = ContentEncoding.Base64,
                    FileName = Path.GetFileName(AttachmentPath)
                };
            }

            // 现在创建multipart / mixed容器来保存消息文本和图像附件
            var multipart = new Multipart("mixed")
            {
                body
            };
            
            // 现在将multipart / mixed设置为消息正文 
            message.Body = multipart;

            using (var client= new MailKit.Net.Smtp.SmtpClient())
            {
                //链接发送邮件的服务器
                client.Connect(ServerAddr, ServerPort, IsSslUsed);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                //验证邮箱密码
                client.Authenticate(FromEmailAddr, FromEmailPassword);
                //发送信息
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
