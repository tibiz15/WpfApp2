using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp2.controlls
{
    abstract class ColorControll : TextBox
    {
        public ColorControll()
        {
            base.SetValue(BackgroundProperty, new SolidColorBrush(Color.FromArgb(80, 90, 90, 200)));
            IsValid = false;
        }

        public static readonly DependencyProperty IsValidProperty =
            DependencyProperty.Register("IsValid", typeof(bool), typeof(ColorControll));

        public bool IsValid
        {
            get
            {
                return (bool)base.GetValue(IsValidProperty);
            }
            set
            {
                base.SetValue(IsValidProperty, value);
            }
        }

        protected abstract bool ValidText(string text);

        protected override void OnPreviewKeyUp(KeyEventArgs e)
        {
            
            if (ValidText(base.GetValue(TextProperty).ToString()))
            {
                base.SetValue(BackgroundProperty, new SolidColorBrush(Color.FromArgb(150, 90, 200, 90)));
                IsValid = true;
            }
            else
            {
                base.SetValue(BackgroundProperty, new SolidColorBrush(Color.FromArgb(150, 200, 90, 90)));
                IsValid = false;
            }
        }
    }
}
