namespace Budget.Gui.Presenters
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Windows.Controls;
    using Budget.Gui.Framework;
    using Budget.Gui.ViewModels;
    using Budget.Gui.Views;
    using StructureMap;

    public sealed class MainWindowPresenter : IDisposable
    {
        private readonly Container container;

        private readonly MainWindow mainWindow;
        private readonly MainWindowViewModel mainWindowViewModel;

        public MainWindowPresenter()
        {
            Contract.Ensures(container != null);
            Contract.Ensures(mainWindow != null);
            Contract.Ensures(mainWindowViewModel != null);

            this.mainWindow = new MainWindow();
            this.mainWindowViewModel = new MainWindowViewModel();

            container = new Container(c =>
            {
                c.For<IViewContainer>().Use<ContentPresenterViewContainer>();
                //c.For<SideBarView>().Use<SideBarView>();
                //c.For<SideBarViewModel>().Use<SideBarViewModel>();
            });
        }

        public void Show()
        {
            SideBarPresenter sideBarPresenter = ResolvePresenter<SideBarPresenter>();
            PurchasePresenter purchasePresenter = ResolvePresenter<PurchasePresenter>();
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
    }
}
