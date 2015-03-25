namespace Budget.Framework
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.Contracts;
    using System.Linq;
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

        public bool HasErrors
        {
            get
            {
                return propertyErrorMap.Any();
            }
        }

        protected bool IsNotifying { get; set; }

        public IEnumerable GetErrors(string propertyName)
        {
            IList<string> errors;
            if (propertyErrorMap.TryGetValue(propertyName, out errors))
            {
                return errors;
            }

            return new string[0];
        }

        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            Contract.Requires(propertyName != null);

            PropertyChangedEventHandler handler = PropertyChanged;
            if (IsNotifying && handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }

            ValidateProperty(propertyName);
        }

        private void ValidateProperty(string propertyName)
        {
            Contract.Requires(propertyName != null);

            if (propertyErrorMap.ContainsKey(propertyName))
            {
                propertyErrorMap.Remove(propertyName);
            }

            ICollection<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationContext validationContext = new ValidationContext(this, null, null)
            {
                MemberName = propertyName
            };

            object propertyValue = GetType().GetProperty(propertyName).GetValue(this);

            if (!Validator.TryValidateProperty(propertyValue, validationContext, validationResults))
            {
                List<string> errors = new List<string>();
                foreach (ValidationResult validationResult in validationResults)
                {
                    errors.Add(validationResult.ErrorMessage);
                }

                propertyErrorMap[propertyName] = errors;
            }

            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName)
        {
            EventHandler<DataErrorsChangedEventArgs> handler = ErrorsChanged;
            if (IsNotifying && handler != null)
            {
                handler(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }
    }
}
