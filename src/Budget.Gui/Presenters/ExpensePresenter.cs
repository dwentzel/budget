namespace Budget.Gui.Presenters
{
    using System.Diagnostics.Contracts;
    using System.Windows.Controls;
    using Budget.Gui.Framework;
    using Budget.Gui.ViewModels;
    using Budget.Gui.Views;

    public class ExpensePresenter : Presenter<ExpenseView, ExpenseViewModel>
    {
        public ExpensePresenter(ExpenseViewModel viewModel, ViewLoader viewLoader)
            : base(viewModel, viewLoader)
        {
            Contract.Requires(viewModel != null);
            Contract.Requires(viewLoader != null);
        }

        protected override void OnViewLoaded()
        {
            Button saveButton = View.FindChildByName<Button>("SaveButton");
            saveButton.Command = new DelegateCommand(() => SavePurchase());
        }

        private void SavePurchase()
        {
            throw new System.NotImplementedException();
        }
    }
}
