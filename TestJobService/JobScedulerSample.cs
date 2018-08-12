using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.App.Job;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TestJobService
{
    [Service(Name = "TestJobService.JobSchedulerSample", Permission = "android.permission.BIND_JOB_SERVICE", Exported = true)]
    public class JobScedulerSample : JobService
    {
        private JobTask tsk;
        public JobParameters parameters;
        public override bool OnStartJob(JobParameters @params)
        {
            this.parameters = @params;
            tsk = new JobTask(this);
            Toast.MakeText(Application.Context.ApplicationContext, "oops it has been sttttt", ToastLength.Short).Show();
            tsk.Execute();
            return true;
        }

        public override bool OnStopJob(JobParameters @params)
        {
            tsk.Cancel(false);
            Toast.MakeText(Application.Context.ApplicationContext, "oops it has been stopped", ToastLength.Short).Show();
            return true;
        }
    }
}