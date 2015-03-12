namespace Budget.Gui.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Diagnostics.Contracts;
    using Budget.Gui.Framework;

    public class SideBarViewModel : ViewModel
    {
        private string text;
        private ObservableCollection<NavigationTargetViewModel> navigationTargets;

        public SideBarViewModel()
        {
            navigationTargets = new ObservableCollection<NavigationTargetViewModel>();
        }

        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                if (text != value)
                {
                    text = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<NavigationTargetViewModel> NavigationTargets
        {
            get
            {
                return navigationTargets;
            }

            set
            {
                if (navigationTargets != value)
                {
                    navigationTargets = value;
                    OnPropertyChanged();
                }
            }
        }

        [ContractInvariantMethod]
        private void ObjectInvariants()
        {
            Contract.Invariant(navigationTargets != null);
        }
    }
}
