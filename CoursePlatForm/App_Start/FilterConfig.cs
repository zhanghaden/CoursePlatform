﻿using CoursePlatForm.Controllers;
using System.Web;
using System.Web.Mvc;

namespace CoursePlatForm
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new CheckAccountAttribute());
        }
    }
}