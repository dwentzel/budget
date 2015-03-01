namespace Budget.Gui.Framework
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;
    using System.Runtime.CompilerServices;

    public abstract class ViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly IDictionary<string, IList<string>> propertyErrorMap;

        protected ViewModel()
        {
            Contract.Ensures(propertyErrorMap != null);
            propertyErrorMap = new Dictionary<string, IList<string>>();
            IsNotifying = true;
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool HasErrors { get; private set; }

        protected bool IsNotifying { get; set; }

        public IEnumerable GetErrors(string propertyName)
        {
            return new[] { "error:" + propertyName };
        }

        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (IsNotifying && PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

            ValidateProperty(propertyName);
        }

        private void ValidateProperty(string propertyName)
        {
            AddError(propertyName);

            HasErrors = true;

            if (IsNotifying && ErrorsChanged != null)
            {
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        private void AddError(string propertyName)
        {
            IList<string> errors;
            if (!propertyErrorMap.TryGetValue(propertyName, out errors))
            {
                errors = new List<string>();
                propertyErrorMap[propertyName] = errors;
            }

            errors.Add("ERRROR");
        }
    }
}
