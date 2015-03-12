namespace Budget.Gui.Presenters
{
    using System;
    using System.Diagnostics.Contracts;
    using Budget.Gui.Services;
    using Budget.Gui.ViewModels;
    using Budget.Gui.Views;
    using StructureMap;

    public sealed class MainWindowPresenter : IDisposable, INavigationTarget
    {
        private readonly Container container;

        private readonly MainWindow mainWindow;
        private readonly MainWindowViewModel mainWindowViewModel;

        private SideBarPresenter sideBarPresenter;
        private ExpensePresenter purchasePresenter;
        private BudgetPeriodPresenter monthlyBudgetPresenter;

        public MainWindowPresenter()
        {
            Contract.Ensures(container != null);
            Contract.Ensures(mainWindow != null);
            Contract.Ensures(mainWindowViewModel != null);

            this.mainWindow = new MainWindow();
            this.mainWindowViewModel = new MainWindowViewModel();

            container = new Container(c =>
            {
                c.For<INavigationTarget>().Use(this);
                //c.For<IViewContainer>().Use<ContentPresenterViewContainer>();
                //c.For<SideBarView>().Use<SideBarView>();
                //c.For<SideBarViewModel>().Use<SideBarViewModel>();
            });
        }

        public void Show()
        {
            sideBarPresenter = ResolvePresenter<SideBarPresenter>();
            purchasePresenter = ResolvePresenter<ExpensePresenter>();
            monthlyBudgetPresenter = ResolvePresenter<BudgetPeriodPresenter>();

            Console.WriteLine(container.WhatDoIHave());

            mainWindow.SideBar.Content = sideBarPresenter.View;
            mainWindow.MainContent.Content = purchasePresenter.View;

            mainWindow.Show();
        }

        private T ResolvePresenter<T>()
        {
            return container.GetInstance<T>();
        }

        public void Dispose()
        {
            container.Dispose();
        }

        public void NavigateTo(string target)
        {
            if (target == "monthlybudget")
            {
                mainWindow.MainContent.Content = monthlyBudgetPresenter.View;
            }
            else if (target == "purchase")
            {
                mainWindow.MainContent.Content = purchasePresenter.View;
            }
        }
    }
}
