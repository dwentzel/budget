namespace Budget.Gui.Services
{
    using System.Diagnostics.Contracts;

    public class NavigationService
    {
        private readonly INavigationTarget navigationTarget;

        public NavigationService(INavigationTarget navigationTarget)
        {
            Contract.Requires(navigationTarget != null);

            this.navigationTarget = navigationTarget;
        }

        public void NavigateTo(string target)
        {
            navigationTarget.NavigateTo(target);
        }
    }
}
