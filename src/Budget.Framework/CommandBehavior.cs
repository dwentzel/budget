namespace Budget.Framework
{
    using System.Windows;

    public static class CommandBehavior
    {
        public static DependencyProperty EventProperty = DependencyProperty.RegisterAttached(
            "Event",
            typeof(string),
            typeof(CommandBehavior),
            new PropertyMetadata(OnEventPropertyChanged));

        private static void OnEventPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public static string GetEvent(DependencyObject d)
        {
            return (string)d.GetValue(EventProperty);
        }

        public static void SetEvent(DependencyObject d, string value)
        {
            d.SetValue(EventProperty, value);
        }
    }
}
