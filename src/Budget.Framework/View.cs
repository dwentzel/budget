namespace Budget.Framework
{
    using System.Windows;
    using System.Windows.Controls;

    public class View : ContentControl
    {
        public T FindName<T>(string name) where T : FrameworkElement
        {
            return (T)FindName(name);
        }

        //    public T FindChildByName<T>(string elementName)
        //        where T : FrameworkElement
        //    {
        //        Contract.Requires(elementName != null);

        //        T control = FindVisualChild<T>(this, elementName);
        //        if (control == null)
        //        {
        //            return default(T);
        //        }

        //        return (T)control;
        //    }

        //    protected T FindVisualChild<T>(DependencyObject obj, string elementName)
        //        where T : FrameworkElement
        //    {
        //        Contract.Requires(obj != null);

        //        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
        //        {
        //            DependencyObject child = VisualTreeHelper.GetChild(obj, i);
        //            T element = child as T;
        //            if (element != null && element.Name == elementName)
        //            {
        //                return element;
        //            }
        //            else
        //            {
        //                T childOfChild = FindVisualChild<T>(child, elementName);
        //                if (childOfChild != null)
        //                {
        //                    return childOfChild;
        //                }
        //            }
        //        }

        //        return null;
        //    }
    }
}
