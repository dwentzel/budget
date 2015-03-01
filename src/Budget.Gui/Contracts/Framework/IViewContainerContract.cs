namespace Budget.Gui.Contracts.Framework
{
    using System.Diagnostics.Contracts;
    using Budget.Gui.Framework;

    [ContractClassFor(typeof(IViewContainer))]
    public abstract class IViewContainerContract : IViewContainer
    {
        public void SetView(object view)
        {
            Contract.Requires(view != null);
        }
    }
}
