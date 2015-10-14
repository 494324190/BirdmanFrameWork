using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using BM;

namespace BM.Common.Web
{
    public static class Email
    {
        //public static void Send(tb_Email email)
        //{
        //    MailMessage mm = new MailMessage();
        //    mm.From = new MailAddress("admin@bugback.com");//发件人地址
        //    mm.To.Add(email.SendAddress);//接收人地址集
        //    mm.Body = email.ContentStr;//正文
        //    mm.BodyEncoding = Encoding.UTF8;//正文编码规则
        //    mm.IsBodyHtml = true;//发送html格式的
        //    mm.Subject = email.Title;//主题
        //    mm.SubjectEncoding = Encoding.UTF8;//主题编码规则
        //    SmtpClient smtp = new SmtpClient("127.0.0.1", 25);//设置发送邮件的服务地址和端口
        //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;//发送方式
        //    smtp.Credentials = new System.Net.NetworkCredential("admin@bugback.com", "123*asd");//发送方的用户名和密码
        //    smtp.Timeout = 10000;
        //    smtp.Send(mm);
        //}

    }
}
