namespace Budget.Gui.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using Budget.Gui.Framework;

    public class BudgetPeriodViewModel : ViewModel
    {
        private DateTime startDate;
        private DateTime? endDate;
        private ObservableCollection<BudgetPostViewModel> budgetPosts;

        [Required]
        public DateTime StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                if (startDate != value)
                {
                    startDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime? EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                if (endDate != value)
                {
                    endDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<BudgetPostViewModel> BudgetPosts
        {
            get
            {
                return budgetPosts;
            }

            set
            {
                if (budgetPosts != value)
                {
                    budgetPosts = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
