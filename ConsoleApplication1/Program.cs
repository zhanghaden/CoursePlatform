using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string LoginName = "user";
            string time = DateTime.Now.ToString("yyhhddmmMM");
            Random randomNum = new Random();
            LoginName += (time + randomNum.Next(100, 999).ToString());
            Console.WriteLine(LoginName);
            Console.Read();
        }
        public string RandomLoginName()
        {
            //seqcode是传过来的流水号
            string LoginName = "user";
            string time = DateTime.Now.ToString("mmyydd hhmmss");
            Random randomNum = new Random();
            LoginName+=(time+randomNum.Next(000, 999).ToString());
            return LoginName;
        }
    }
}
