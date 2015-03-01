namespace Budget.Gui.Framework
{
    using System.Diagnostics.Contracts;
    using System.Windows.Controls;

    public class ContentPresenterViewContainer : IViewContainer
    {
        private readonly ContentPresenter contentPresenter;

        public ContentPresenterViewContainer(ContentPresenter contentPresenter)
        {
            Contract.Requires(contentPresenter != null);
            this.contentPresenter = contentPresenter;
        }

        public void SetView(object view)
        {
            contentPresenter.Content = view;
        }
    }
}
