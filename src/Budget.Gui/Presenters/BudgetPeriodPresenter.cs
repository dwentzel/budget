namespace Budget.Gui.Presenters
{
    using System.Diagnostics.Contracts;
    using Budget.Framework;
    using Budget.Gui.ViewModels;
    using Budget.Gui.Views;

    public class BudgetPeriodPresenter : Presenter<BudgetPeriodView, BudgetPeriodViewModel>
    {
        public BudgetPeriodPresenter(BudgetPeriodViewModel viewModel, ViewLoader viewLoader)
            : base(viewModel, viewLoader)
        {
            Contract.Requires(viewModel != null);
            Contract.Requires(viewLoader != null);
        }
    }
}
