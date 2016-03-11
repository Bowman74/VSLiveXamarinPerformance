using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using XamarinDemo8.Controls;

namespace XamarinDemo8.Droid
{
    [Activity(Label = "XamarinDemo8", 
        Icon = "@mipmap/ic_launcher", 
        Theme="@android:style/Theme.Holo.Light",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
        }
    }
}