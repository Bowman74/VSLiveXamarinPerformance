
using System;

namespace Demo1
{
    public class EventHolder: IDisposable
    {

#if ANDROID
        private Android.MainActivity _activity;
        
        public EventHolder(Demo1.Android.MainActivity context)
        {
            _activity = context;
            _activity.Happened += ContextOnHappened;
        }

        public void Dispose()
        {
            _activity.Happened -= ContextOnHappened;
        }
#else
        private Ios.MainViewController _viewController;

        public EventHolder(Demo1.Ios.MainViewController context)
        {
            _viewController = context;
            _viewController.Happened += ContextOnHappened;
        }

        public void Dispose()
        {
            _viewController.Happened -= ContextOnHappened;
        }
#endif
        private void ContextOnHappened(object sender, EventArgs eventArgs)
        {
            throw new NotImplementedException();
        }
    }
}