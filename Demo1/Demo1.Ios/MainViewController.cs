using System;
using System.Drawing;
using CoreGraphics;
using UIKit;
using Foundation;

namespace Demo1.Ios
{
    [Register("UniversalView")]
    public class UniversalView : UIView
    {
        public UniversalView()
        {
            Initialize();
        }

        public UniversalView(RectangleF bounds) : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            BackgroundColor = UIColor.White;
        }
    }

    public delegate void HappenedEventHandler(object sender, EventArgs e);

    [Register("MainViewController1")]
    public class MainViewController : UIViewController
    {
        public event HappenedEventHandler Happened;

        public MainViewController()
        {
        }

        public bool TouchInside { get; private set; }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            View = new UniversalView();

            var button = new UIButton(new CGRect(10, 10, 200, 50));
            button.SetTitleColor(UIColor.DarkTextColor, UIControlState.Normal);
            button.SetTitle("Network HTTP", UIControlState.Normal);
            button.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            button.TouchUpInside += NetworkHTTP_TouchUpInside;
            View.AddSubview(button);

            button = new UIButton(new CGRect(10, 70, 200, 50));
            button.SetTitleColor(UIColor.DarkTextColor, UIControlState.Normal);
            button.SetTitle("Network HTTPS", UIControlState.Normal);
            button.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            button.TouchUpInside += NetworkHTTPS_TouchUpInside;
            View.AddSubview(button);

            button = new UIButton(new CGRect(10, 130, 200, 50));
            button.SetTitleColor(UIColor.DarkTextColor, UIControlState.Normal);
            button.SetTitle("Event Test", UIControlState.Normal);
            button.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            button.TouchUpInside += EventTest_TouchUpInside;
            View.AddSubview(button);

            button = new UIButton(new CGRect(10, 190, 200, 50));
            button.SetTitleColor(UIColor.DarkTextColor, UIControlState.Normal);
            button.SetTitle("Circular Reference", UIControlState.Normal);
            button.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            button.TouchUpInside += CircularReferenceTest_TouchUpInside;
            View.AddSubview(button);

            button = new UIButton(new CGRect(10, 260, 200, 50));
            button.SetTitleColor(UIColor.DarkTextColor, UIControlState.Normal);
            button.SetTitle("Am I Responsive?", UIControlState.Normal);
            button.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            button.TouchUpInside += AmIResponsive_TouchUpInside;
            View.AddSubview(button);
            base.ViewDidLoad();

            // Perform any additional setup after loading the view
        }

        private void AmIResponsive_TouchUpInside(object sender, EventArgs e)
        {
            ShowMessage("I am responsive", "Responding...");
        }

        private void CircularReferenceTest_TouchUpInside(object sender, EventArgs e)
        {
            for (var i = 0; i < 999; i++)
            {
                var obj = new Tests.SomeController();
                    var b = obj.GetType();

            }
            GC.Collect();
            ShowMessage("Circular Reference", "Circular Reference Test Complete");
        }

        private void EventTest_TouchUpInside(object sender, EventArgs e)
        {
            for (var i = 0; i < 9999; i++)
            {
                using (var obj = new EventHolder(this))
                {
                    var b = obj.GetType();
                }
            }
            GC.Collect(0);
            ShowMessage("Event Test", "Event Test Complete");
        }

        private async void NetworkHTTP_TouchUpInside(object sender, EventArgs e)
        {
            var nativeResult = (await NetworkTests.NativeNetworkSpeedAsync(false)).ToString();
            var managedResult = (await NetworkTests.ManagedNetworkSpeedAsync(false)).ToString();
            ShowMessage("Network HTTP", $"Native: {nativeResult}, Managed: {managedResult}.");
        }

        private async void NetworkHTTPS_TouchUpInside(object sender, EventArgs e)
        {
            var nativeResult = (await NetworkTests.NativeNetworkSpeedAsync(true)).ToString();
            var managedResult = (await NetworkTests.ManagedNetworkSpeedAsync(true)).ToString();
            ShowMessage("Network HTTPS", $"Native: {nativeResult}, Managed: {managedResult}.");
        }

        public void ShowMessage(string title, string message)
        {
            var alert = new UIAlertView(title, message, null, "Ok", null);
            InvokeOnMainThread(alert.Show);
        }
    }
}