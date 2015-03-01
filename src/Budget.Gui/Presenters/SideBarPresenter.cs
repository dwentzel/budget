namespace Budget.Gui.Presenters
{
    using System;
    using Budget.Gui.Framework;
    using Budget.Gui.ViewModels;
    using Budget.Gui.Views;

    public class SideBarPresenter : Presenter<SideBarView, SideBarViewModel>
    {
        public SideBarPresenter(IViewContainer container, SideBarView sideBarView, SideBarViewModel sideBarViewModel)
            : base(container, sideBarView, sideBarViewModel)
        {
            //Contract.Requires(control != null);
            //Contract.Requires(sideBarView != null);
            //Contract.Requires(sideBarViewModel != null);

            //sideBarView.InitializeComponent();
            sideBarView.DataContext = sideBarViewModel;
            sideBarView.Button1.Command = new DelegateCommand<object>(_ => ChangeText(), __ => { return true; });
            //control.Content = sideBarView;
        }

        private void ChangeText()
        {
            Guid guid = Guid.NewGuid();
            ViewModel.Text = guid.ToString();
        }
    }
}
