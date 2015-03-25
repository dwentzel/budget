namespace Budget.Gui.Presenters
{
    using System;
    using System.Collections.Specialized;
    using System.Diagnostics.Contracts;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using Budget.Framework;
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
        }

        protected override void OnViewLoaded()
        {
            navigationTargets = View.FindName<ItemsControl>("NavigationTargets"); //FindElementByName<ItemsControl>(View, "NavigationTargets");

            navigationTargets.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(Click));
            navigationTargets.ItemContainerGenerator.ItemsChanged += ItemContainerGenerator_ItemsChanged;

            ViewModel.NavigationTargets.Add(new NavigationTargetViewModel { Caption = "Purchase", Target = "purchase" });
            ViewModel.NavigationTargets.Add(new NavigationTargetViewModel { Caption = "Monthly budget", Target = "monthlybudget" });
        }

        private void ItemContainerGenerator_ItemsChanged(object sender, ItemsChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                ItemContainerGenerator generator = (ItemContainerGenerator)sender;
                int index = ((IItemContainerGenerator)generator).IndexFromGeneratorPosition(e.Position);
                FrameworkElement container = (FrameworkElement)generator.ContainerFromIndex(index);
                container.ApplyTemplate();

                Button button = FindElementByName<Button>(container, "NavigationButton");
                button.Command = new DelegateCommand<NavigationTargetViewModel>(p => Navigate(p), _ => true);

                object item = generator.ItemFromContainer(container);
                button.CommandParameter = item;
            }
        }

        private void Navigate(NavigationTargetViewModel p)
        {
            navigationService.NavigateTo(p.Target);
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
