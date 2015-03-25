namespace Budget.Framework
{
    using System.Diagnostics.Contracts;
    using System.Windows;
    using System.Windows.Media;

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

        protected T FindElementByName<T>(DependencyObject obj, string elementName)
            where T : FrameworkElement
        {
            Contract.Requires(obj != null);

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                T element = child as T;
                if (element != null && element.Name == elementName)
                {
                    return element;
                }
                else
                {
                    T childOfChild = FindElementByName<T>(child, elementName);
                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                }
            }

            return null;
        }
    }
}
