namespace Budget.Gui.Presenters
{
    using System.Diagnostics.Contracts;
    using Budget.Gui.Framework;
    using Budget.Gui.ViewModels;
    using Budget.Gui.Views;

    public class PurchasePresenter : Presenter<PurchaseView, PurchaseViewModel>
    {
        public PurchasePresenter(PurchaseViewModel viewModel, ViewLoader viewLoader)
            : base(viewModel, viewLoader)
        {
            Contract.Requires(viewModel != null);
            Contract.Requires(viewLoader != null);

            View.SaveButton.Command = new DelegateCommand(() => SavePurchase());
        }

        private void SavePurchase()
        {
            throw new System.NotImplementedException();
        }
    }
}
