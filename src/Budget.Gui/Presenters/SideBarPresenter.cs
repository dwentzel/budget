namespace Budget.Gui.Presenters
{
    using System;
    using System.Collections.Specialized;
    using System.Diagnostics.Contracts;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;
    using Budget.Gui.Framework;
    using Budget.Gui.Services;
    using Budget.Gui.ViewModels;
    using Budget.Gui.Views;

    public class SideBarPresenter : Presenter<SideBarView, SideBarViewModel>
    {
        private readonly NavigationService navigationService;
        private ItemsControl navigationTargets;

        public SideBarPresenter(SideBarViewModel viewModel, ViewLoader viewLoader, NavigationService navigationService)
            : base(viewModel, viewLoader)
        {
            Contract.Requires(viewModel != null);
            Contract.Requires(viewLoader != null);
            Contract.Requires(navigationService != null);

            this.navigationService = navigationService;

            //viewModel.NavigationTargets.Add(new NavigationTargetViewModel { Caption = "Purchase" });
            //viewModel.NavigationTargets.Add(new NavigationTargetViewModel { Caption = "Monthly budget" });

            View.Loaded += View_Loaded;
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            navigationTargets = View.FindChildByName<ItemsControl>("NavigationTargets");

            navigationTargets.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(Click));
            navigationTargets.ItemContainerGenerator.ItemsChanged += ItemContainerGenerator_ItemsChanged;

            ViewModel.NavigationTargets.Add(new NavigationTargetViewModel { Caption = "Purchase", Target = "purchase" });
            ViewModel.NavigationTargets.Add(new NavigationTargetViewModel { Caption = "Monthly budget", Target = "monthlybudget" });

            //navigationTargets.ItemContainerGenerator.
            //navigationTargets.SetValue(ButtonBase.CommandProperty, new DelegateCommand(() => Crash()));
        }

        private void ItemContainerGenerator_ItemsChanged(object sender, ItemsChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var index = ((IItemContainerGenerator)navigationTargets.ItemContainerGenerator).IndexFromGeneratorPosition(e.Position);
                FrameworkElement container = (FrameworkElement)navigationTargets.ItemContainerGenerator.ContainerFromIndex(index);
                container.ApplyTemplate();
                var button = FindChildByName<Button>(container, "NavigationButton");
                var item = navigationTargets.ItemContainerGenerator.ItemFromContainer(container);
                button.Command = new DelegateCommand<NavigationTargetViewModel>(p => Navigate(p), _ => true);
                button.CommandParameter = item;
            }
        }

        private void Navigate(NavigationTargetViewModel p)
        {
            navigationService.NavigateTo(p.Target);
        }

        private T FindChildByName<T>(DependencyObject obj, string controlName)
            where T : FrameworkElement
        {
            Contract.Requires(obj != null);

            var control = FindVisualChild<T>(obj, controlName);
            if (control == null)
            {
                return default(T);
            }

            return (T)control;
        }

        private T FindVisualChild<T>(DependencyObject obj, string name)
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

        private void Click(object sender, RoutedEventArgs e)
        {
            //e.OriginalSource
        }

        private object Crash()
        {
            throw new NotImplementedException();
        }

        private void ChangeText()
        {
            Guid guid = Guid.NewGuid();
            ViewModel.Text = guid.ToString();
        }
    }
}
