namespace Budget.Gui.Framework
{
    using System.Diagnostics.Contracts;
    using Budget.Gui.Contracts.Framework;

    [ContractClass(typeof(IViewContainerContract))]
    public interface IViewContainer
    {
        void SetView(object view);
    }
}
