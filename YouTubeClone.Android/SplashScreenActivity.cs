using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace YouTubeClone.Droid
{
    [Activity(Theme = "@style/Splash",
       MainLauncher = true,
       NoHistory = true)]
    public class SplashScreenActivity : Activity
    {
        static readonly string TAG = "X:" + typeof(SplashScreenActivity).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
        }
        protected override void OnResume()
        {
            try
            {
                base.OnResume();
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
                Finish();
            }
            catch
            {

            }
        }
    }
}