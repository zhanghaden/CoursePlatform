using System;
using System.Web;
using System.Web.Routing;
using Quartz;
using Quartz.Impl;

namespace SampleApp {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication {
        void Application_Start() {
            ISchedulerFactory sf = new StdSchedulerFactory();//执行者  
            IScheduler sched = sf.GetScheduler();

            JobDetail job = new JobDetail("job1", "group1", typeof(TestJob));//TestJob为实现了IJob接口的类,（工作名称，分组，那个类）  
            Trigger trigger = TriggerUtils.MakeDailyTrigger("tigger1", indexStartHour, indexStartMin);//每天10点00分执行  
            trigger.JobName = "job1";
            trigger.JobGroup = "group1";
            trigger.Group = "group1";

            sched.AddJob(job, true);
            sched.ScheduleJob(trigger);
            sched.Start();  
        }
    }
}