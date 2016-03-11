using Xamarin.Forms;
using XamarinDemo8.Attibutes;

namespace XamarinDemo8.Controls
{
    //[Preserve(AllMembers = true)]
    public class ExtendedLabel : Label
    {
        public static readonly BindableProperty UnderlineProperty = BindableProperty.Create(
            propertyName: "Underline",
            returnType: typeof(bool),
            declaringType: typeof(ExtendedLabel),
            defaultValue: false);

        public bool Underline
        {
            get { return (bool)GetValue(UnderlineProperty); }
            set { SetValue(UnderlineProperty, value); }
        }
    }
}