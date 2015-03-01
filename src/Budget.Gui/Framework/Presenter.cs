namespace Budget.Gui.Framework
{
    using System.Diagnostics.Contracts;
    using System.Reflection;
    using System.Windows.Controls;

    public abstract class Presenter<TView, TViewModel>
        where TView : UserControl
        where TViewModel : ViewModel
    {
        private readonly TView view;
        private readonly TViewModel viewModel;

        protected Presenter(IViewContainer container, TView view, TViewModel viewModel)
        {
            Contract.Requires(container != null);
            Contract.Requires(view != null);
            Contract.Requires(viewModel != null);

            this.view = view;
            this.viewModel = viewModel;

            this.view.DataContext = viewModel;

            container.SetView(this.view);

            MethodInfo method = typeof(TView).GetMethod("InitializeComponent");
            method.Invoke(this.view, null);
        }

        protected TView View
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
    }
}
