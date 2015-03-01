namespace Budget.Gui.Framework
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Windows;

    public class ViewLoader
    {
        public object LoadView(ViewModel viewModel)
        {
            Contract.Requires(viewModel != null);

            Type viewModelType = viewModel.GetType();
            string viewModelTypeName = viewModelType.Name;
            string viewName = viewModelTypeName.Remove(viewModelTypeName.Length - 5);

            Uri resourceLocator = new System.Uri("/Budget.Gui;component/views/" + viewName + ".xaml", System.UriKind.Relative);
            return Application.LoadComponent(resourceLocator);
        }
    }
}
