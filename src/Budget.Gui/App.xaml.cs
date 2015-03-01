namespace Budget.Gui
{
    using System.Globalization;
    using System.Windows;
    using System.Windows.Markup;
    using Budget.Gui.Presenters;

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            MainWindowPresenter presenter = new MainWindowPresenter();
            presenter.Show();
        }
    }
}
