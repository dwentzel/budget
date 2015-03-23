namespace Budget.Gui.Framework
{
    using System.Diagnostics.Contracts;

    public abstract class Presenter<TView, TViewModel>
        where TView : View
        where TViewModel : ViewModel
    {
        private readonly TView view;
        private readonly TViewModel viewModel;

        protected Presenter(TViewModel viewModel, ViewLoader viewLoader)
        {
            Contract.Requires(viewModel != null);
            Contract.Requires(viewLoader != null);

            this.viewModel = viewModel;

            view = (TView)viewLoader.LoadView(viewModel);

            view.DataContext = viewModel;

            view.Loaded += OnViewLoaded;
        }

        public TView View
        {
            get
            {
                return view;
            }
        }

        protected TViewModel ViewModel
        {
            get
            {
                return viewModel;
            }
        }

        private void OnViewLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            OnViewLoaded();
        }

        protected virtual void OnViewLoaded()
        {
        }
    }
}
