using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace Demo1.Android
{
    public delegate void HappenedEventHandler(object sender, EventArgs e);

    [Activity(Label = "Demo1.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        public event HappenedEventHandler Happened;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var button = FindViewById<Button>(Resource.Id.btnNetworkHTTP);

            button.Click += NetworkHTTP_Click;

            button = FindViewById<Button>(Resource.Id.btnNetworkHTTPS);

            button.Click += NetworkHTTPS_Click;


            button = FindViewById<Button>(Resource.Id.btnEventTest);

            button.Click += EventTest_Click;
        }

        private void EventTest_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < 9999; i++)
            {
                using (var obj = new EventHolder(this))
                {
                    var b = obj.GetType();
                }
            }
            GC.Collect(0);
        }

        private async void NetworkHTTP_Click(object sender, EventArgs e)
        {
            var nativeResult = (await NetworkTests.NativeNetworkSpeedAsync(false)).ToString();
            var managedResult = (await NetworkTests.ManagedNetworkSpeedAsync(false)).ToString();
            ShowMessage("Network HTTP", string.Format("Native: {0}, Managed: {1}.", nativeResult, managedResult));
        }

        private async void NetworkHTTPS_Click(object sender, EventArgs e)
        {
            var nativeResult = (await NetworkTests.NativeNetworkSpeedAsync(true)).ToString();
            var managedResult = (await NetworkTests.ManagedNetworkSpeedAsync(true)).ToString();
            ShowMessage("Network HTTPS", string.Format("Native: {0}, Managed: {1}.", nativeResult, managedResult));
        }

        public void ShowMessage(string title, string message)
        {
            var builder = new AlertDialog.Builder(this);
            builder.SetTitle(title);
            builder.SetMessage(message);
            builder.SetNegativeButton("Ok", (sender, args) => { });
            builder.SetCancelable(true);
            builder.Show();
        }
    }
}

