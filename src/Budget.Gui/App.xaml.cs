namespace Budget.Gui
{
    using System.Windows;
    using Budget.Gui.Presenters;

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindowPresenter presenter = new MainWindowPresenter();
            presenter.Show();
        }
    }
}
