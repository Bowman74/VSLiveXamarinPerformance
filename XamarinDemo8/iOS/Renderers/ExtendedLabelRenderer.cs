using System.ComponentModel;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinDemo8.Controls;
using XamarinDemo8.iOS.Renderers;

[assembly: Preserve(typeof(ExtendedLabelRenderer))]
[assembly: ExportRenderer(typeof(ExtendedLabel), typeof(ExtendedLabelRenderer))]
namespace XamarinDemo8.iOS.Renderers
{
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
                SetUnderline(view, Control);
            }
        }

        private static void SetUnderline(ExtendedLabel view, UILabel label)
        {
            var attrString = new NSMutableAttributedString(label.Text);

            if (view.Underline)
            {
                attrString.AddAttribute(UIStringAttributeKey.UnderlineStyle,
                                        NSNumber.FromInt32((int)NSUnderlineStyle.Single),
                                        new NSRange(0, attrString.Length));
            }

            label.AttributedText = attrString;
        }
    }
}