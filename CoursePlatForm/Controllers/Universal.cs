using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursePlatForm.Controllers
{
    public class Universal
    {
        public static string ConvertNullToEmpty(string temp)
        {
            if (temp == null)
            {
                return "";
            }
            else
            {
                return temp;
            }
        }
    }
}