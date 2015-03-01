namespace Budget.Gui.Presenters
{
    using System;
    using System.Diagnostics.Contracts;
    using Budget.Gui.Framework;
    using Budget.Gui.ViewModels;
    using Budget.Gui.Views;

    public class SideBarPresenter : Presenter<SideBarView, SideBarViewModel>
    {
        public SideBarPresenter(SideBarViewModel viewModel, ViewLoader viewLoader)
            : base(viewModel, viewLoader)
        {
            Contract.Requires(viewModel != null);

            View.Button1.Command = new DelegateCommand<object>(_ => ChangeText(), __ => { return true; });
        }

        private void ChangeText()
        {
            Guid guid = Guid.NewGuid();
            ViewModel.Text = guid.ToString();
        }
    }
}
