using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp2
{
    class ColorDatePicker : DatePicker
    {
        public ColorDatePicker()
        {
            base.SetValue(BackgroundProperty, new SolidColorBrush(Color.FromArgb(80, 90, 90, 200)));
            IsValidDate = false;
        }

        public static readonly DependencyProperty IsValidDateProperty =
            DependencyProperty.Register("IsValidDate", typeof(bool), typeof(ColorDatePicker));

        public bool IsValidDate
        {
            get
            {
                return (bool)base.GetValue(IsValidDateProperty);
            }
            set
            {
                base.SetValue(IsValidDateProperty, value);
            }
        }

        protected override void OnCalendarClosed(RoutedEventArgs e)
        {
            base.OnCalendarClosed(e);
            updateValues();

        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            updateValues();
        }

        protected override void OnPreviewKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            updateValues();
        }

        protected override void OnSelectedDateChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectedDateChanged(e);
            updateValues();
        }

        private void updateValues()
        {
            if (base.GetValue(SelectedDateProperty) == null || string.IsNullOrEmpty(base.GetValue(SelectedDateProperty).ToString()) || string.IsNullOrWhiteSpace(base.GetValue(SelectedDateProperty).ToString()))
            {
                base.SetValue(BackgroundProperty, new SolidColorBrush(Color.FromArgb(150, 200, 90, 90)));
                IsValidDate = false;
            }
            else
            {
                base.SetValue(BackgroundProperty, new SolidColorBrush(Color.FromArgb(150, 90, 200, 90)));
                IsValidDate = true;
            }
        }
    }
}
