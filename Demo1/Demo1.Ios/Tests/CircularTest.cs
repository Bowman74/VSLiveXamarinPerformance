using System;
using UIKit;

namespace Demo1.Ios.Tests
{
    public class SomeController : UIViewController
    {

        public SomeController()
        {
            Add(new SomeLabel(this));
        }
    }

    public class SomeLabel : UILabel
    {
        //private SomeController _parent;
        private WeakReference<SomeController> _parent;

        public SomeLabel(SomeController controller)
        {
            //_parent = controller;
            _parent = new WeakReference<SomeController>(controller);
        }
    }
}
