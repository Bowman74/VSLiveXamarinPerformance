using System;

namespace Demo1
{
    public class Parent : IDisposable
    {
        private Child _child;

        public Parent()
        {
            _child = new Child(this);
        }

        public void Dispose()
        {
            //_child = null;
        }
    }

#if ANDROID
    public class Child : Java.Lang.Object
    {
        private Parent _parent;
        public Child(Parent parent)
        {
            //_parent = new WeakReference(parent);
        }
    }
#else
    public class Child
    {
        private Parent _parent;
        public Child(Parent parent)
        {
            //_parent = new WeakReference(parent);
        }
    }
#endif
}
