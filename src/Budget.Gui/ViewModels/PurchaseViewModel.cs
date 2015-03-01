﻿namespace Budget.Gui.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using Budget.Gui.Framework;

    public class PurchaseViewModel : ViewModel
    {
        private readonly ObservableCollection<string> availableCategories;
        private string category;
        private DateTime date;
        private decimal price;

        public PurchaseViewModel()
        {
            availableCategories = new ObservableCollection<string>
            {
                "Mat",
                "Bil",
                "Leksaker",
                "Övrigt"
            };
        }

        public ObservableCollection<string> AvailableCategories
        {
            get { return availableCategories; }
        }

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                if (category != value)
                {
                    category = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                if (date != value)
                {
                    date = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                if (price != value)
                {
                    price = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
