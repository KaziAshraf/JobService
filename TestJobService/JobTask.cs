using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace TestJobService
{
    public class JobTask : AsyncTask<Java.Lang.Void, Java.Lang.Void, System.String>
    {
        JobScedulerSample js;

        public JobTask(JobScedulerSample js)
        {
            this.js = js;
        }

        protected override void OnPostExecute(string result)
        {
            Console.WriteLine("ttttttttttttttttttt");
            js.JobFinished(js.parameters, false);
        }

        protected override string RunInBackground(params Java.Lang.Void[] @params)
        {
            return "Background Task Working";
        }
    }
}