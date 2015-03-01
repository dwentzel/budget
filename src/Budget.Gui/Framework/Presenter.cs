namespace Budget.Gui.Framework
{
    using System.Diagnostics.Contracts;
    using System.Windows.Controls;

    public abstract class Presenter<TView, TViewModel>
        where TView : UserControl
        where TViewModel : ViewModel
    {
        private readonly TView view;
        private readonly TViewModel viewModel;

        protected Presenter(TViewModel viewModel, ViewLoader viewLoader)
        {
            //Contract.Requires(container != null);
            //Contract.Requires(view != null);
            Contract.Requires(viewModel != null);
            Contract.Requires(viewLoader != null);

            ////this.view = view;
            this.viewModel = viewModel;

            view = (TView)viewLoader.LoadView(viewModel);

            view.DataContext = viewModel;

            //container.SetView(this.view);
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

        //private void LoadView(TViewModel viewModel)
        //{
        //    Type viewModelType = viewModel.GetType();
        //    string viewModelTypeName = viewModelType.Name;
        //    string viewName = viewModelTypeName.Remove(viewModelTypeName.Length - 5);

        //    Uri resourceLocater = new System.Uri("/Budget.Gui;component/views/" + viewName + ".xaml", System.UriKind.Relative);
        //    Application.LoadComponent(this.view, resourceLocater);
        //}
    }
}
