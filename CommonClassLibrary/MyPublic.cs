using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CommonClassLibrary
{
    class MyPublic
    {
        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subj"></param>
        /// <param name="bodys"></param>

        public static void sendMail(string smtpserver, string userName, string pwd, string strfrom, string strto, string subj, string bodys)
        {
            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            _smtpClient.Host = smtpserver;//指定SMTP服务器
            _smtpClient.Credentials = new System.Net.NetworkCredential(userName, pwd);//用户名和密码

            MailMessage _mailMessage = new MailMessage(strfrom, strto);
            _mailMessage.Subject = subj;//主题
            _mailMessage.Body = bodys;//内容
            _mailMessage.BodyEncoding = System.Text.Encoding.Default;//正文编码
            _mailMessage.IsBodyHtml = true;//设置为HTML格式
            _mailMessage.Priority = MailPriority.High;//优先级
            _smtpClient.Send(_mailMessage);
        }


        /// <summary>
        /// 读取web.config相关数据信息
        /// </summary>
        /// <param name="xmlTargetElement">相关字节</param>
        /// <returns></returns>
        /// 编写时间2007-03-08  y.xiaobin(著)
        public static string getXmlElementValue(string xmlTargetElement)
        {
            return System.Configuration.ConfigurationManager.AppSettings[xmlTargetElement];
        }





    }
}
