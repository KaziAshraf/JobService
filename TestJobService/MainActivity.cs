using Android.App;
using Android.Widget;
using Android.OS;
using Android.App.Job;
using Android.Views;
using Android.Content;
using System;
using Java.Interop;

namespace TestJobService
{
    [Activity(Label = "TestJobService", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private JobScheduler Job_s;

        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Job_s = (JobScheduler)GetSystemService(JobSchedulerService);
        }

        [Export("ScheduleJob")]
        public void ScheduleJob(View v)
        {
            JobInfo.Builder builder = new JobInfo.Builder(102, new ComponentName(this, Java.Lang.Class.FromType(typeof(JobScedulerSample))));
            builder.SetPersisted(true);
            builder.SetPeriodic(5000);
            builder.SetRequiredNetworkType(NetworkType.Unmetered);
            builder.SetRequiresCharging(false);
            builder.SetRequiresDeviceIdle(false);

            try
            {
                int test = Job_s.Schedule(builder.Build());
                if (test == JobScheduler.ResultSuccess)
                {
                    Console.WriteLine("Job is working");
                }
                else
                    Console.WriteLine("Job is not working");

                
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
    }
}

