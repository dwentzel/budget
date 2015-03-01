namespace Budget.Gui.Presenters
{
    using Budget.Gui.Framework;
    using Budget.Gui.ViewModels;
    using Budget.Gui.Views;

    public class PurchasePresenter : Presenter<PurchaseView, PurchaseViewModel>
    {
        public PurchasePresenter(IViewContainer container, PurchaseView view, PurchaseViewModel viewModel)
            : base(container, view, viewModel)
        {
            view.SaveButton.Command = new DelegateCommand(() => SavePurchase());
        }

        private void SavePurchase()
        {
            throw new System.NotImplementedException();
        }
    }
}
