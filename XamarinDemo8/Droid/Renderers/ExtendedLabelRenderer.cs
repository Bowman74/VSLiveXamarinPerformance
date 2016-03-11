using System.ComponentModel;
using Android.Graphics;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinDemo8.Controls;
using XamarinDemo8.Droid.Renderers;

[assembly: ExportRenderer(typeof(ExtendedLabel), typeof(ExtendedLabelRenderer))]
namespace XamarinDemo8.Droid.Renderers
{
    [Android.Runtime.Preserve(AllMembers = true)]
    public class ExtendedLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var view = (ExtendedLabel)Element;
            var label = Control;

            SetUnderline(view, label);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var view = (ExtendedLabel)Element;
            var label = Control;

            if (e.PropertyName == ExtendedLabel.UnderlineProperty.PropertyName)
            {
                SetUnderline(view, label);
            }
        }

        static void SetUnderline(ExtendedLabel view, TextView label)
        {
            label.PaintFlags = view.Underline ? label.PaintFlags | PaintFlags.UnderlineText : label.PaintFlags &= ~PaintFlags.UnderlineText;
        }
    }
}