using System.Threading.Tasks;
using Android.App;
using Android.Content;

namespace XamarinDemo8.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash",
        Icon = "@mipmap/ic_launcher",
        MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnResume()
        {
            base.OnResume();

            var startupWork = new Task(() => {
                // Do any startup code
            });

            startupWork.ContinueWith(t => {
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }
    }
}