namespace Budget.Framework
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
            int index = viewModelTypeName.LastIndexOf("Model");
            string viewName = viewModelTypeName.Substring(0, index);

            Uri resourceLocator = new System.Uri("/Views/" + viewName + ".xaml", System.UriKind.Relative);
            return Application.LoadComponent(resourceLocator);
        }
    }
}
