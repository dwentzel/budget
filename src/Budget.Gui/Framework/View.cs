namespace Budget.Gui.Framework
{
    using System.Diagnostics.Contracts;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    public class View : ContentControl
    {
        public T FindChildByName<T>(string controlName)
            where T : FrameworkElement
        {
            var control = FindVisualChild<T>(this, controlName);
            if (control == null)
            {
                return default(T);
            }

            return (T)control;
        }

        protected T FindVisualChild<T>(DependencyObject obj, string name)
            where T : FrameworkElement
        {
            Contract.Requires(obj != null);

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                T element = child as T;
                if (element != null && element.Name == name)
                {
                    return element;
                }
                else
                {
                    T childOfChild = FindVisualChild<T>(child, name);
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
