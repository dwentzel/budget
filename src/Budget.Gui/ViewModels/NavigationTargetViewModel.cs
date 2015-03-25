namespace Budget.Gui.ViewModels
{
    using Budget.Framework;

    public class NavigationTargetViewModel : ViewModel
    {
        private string caption;
        private string target;

        public string Caption
        {
            get
            {
                return caption;
            }

            set
            {
                if (caption != value)
                {
                    caption = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Target
        {
            get
            {
                return target;
            }

            set
            {
                if (target != value)
                {
                    target = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
