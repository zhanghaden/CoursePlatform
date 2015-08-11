using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursePlatForm.Common
{
    /// <summary>
    /// 用于生成指定数量的User账户
    /// </summary>
    public class GenerateUser
    {
        /// <summary>
        /// 生成指定数量的user账户
        /// </summary>
        /// <param name="GenerateNum">要生成的数量</param>
        public void GenUserByNum(int GenerateNum)
        {
            
        }


        /// <summary>
        /// 返回一个用户名，由时间和随机码共同组成，最前面加user
        /// </summary>
        /// <param name="seqcode"></param>
        /// <returns></returns>
        public static string RandomLoginName()
        {
            string LoginName = "user";
            string time = DateTime.Now.ToString("hhyyddmmMM");
            Random randomNum = new Random();
            LoginName += (time + randomNum.Next(100, 999).ToString());
            return LoginName;
        }

        /// <summary>
        /// 返回一个随机的密码
        /// </summary>
        /// <returns></returns>
        public static string RandomPassword()
        {
            Random r = new Random();
            int x = r.Next(999999);
            string a = x.ToString();
            return a;
        }
    }
}