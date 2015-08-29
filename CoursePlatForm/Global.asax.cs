using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentScheduler;

namespace CoursePlatForm
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    

    public class MvcApplication : System.Web.HttpApplication
    {
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            TaskManager.Initialize(new MyRegistry()); 
        }
    }

    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            // Schedule an ITask to run at an interval
            //Schedule<MyTask>().ToRunNow().AndEvery(2).Seconds();

            // Schedule an ITask to run once, delayed by a specific time interval.
            //Schedule<MyTask>().ToRunOnceIn(5).Seconds();

            // Schedule a simple task to run at a specific time
            //Schedule(() => Pdf2Swf.PDFToSWF(pdfpath, swfpath)).ToRunEvery(1).Days().At(23, 60);

            // Schedule a more complex action to run immediately and on an monthly interval
            //Schedule(() =>
            //{
            //    Console.WriteLine("Complex Action Task Starts: " + DateTime.Now);
            //    Thread.Sleep(1000);
            //    Console.WriteLine("Complex Action Task Ends: " + DateTime.Now);
            //}).ToRunNow().AndEvery(1).Months().OnTheFirst(DayOfWeek.Monday).At(3, 0);

            //Schedule multiple tasks to be run in a single schedule
            //Schedule<MyTask>().AndThen<MyOtherTask>().ToRunNow().AndEvery(5).Minutes();
        }
    }
}