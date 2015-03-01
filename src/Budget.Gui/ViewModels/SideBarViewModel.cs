namespace Budget.Gui.ViewModels
{
    using Budget.Gui.Framework;

    public class SideBarViewModel : ViewModel
    {
        private string text;

        public SideBarViewModel()
        {
            Text = "TESTING";
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
    }
}
