namespace Budget.Gui.Framework
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

        public bool HasErrors { get { return propertyErrorMap.Any(); } }

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
            if (IsNotifying && PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

            ValidateProperty(propertyName);
        }

        private void ValidateProperty(string propertyName)
        {
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
        }

        private void OnErrorsChanged(string propertyName)
        {
            if (IsNotifying && ErrorsChanged != null)
            {
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        //private void AddError(string propertyName)
        //{
        //    IList<string> errors;
        //    if (!propertyErrorMap.TryGetValue(propertyName, out errors))
        //    {
        //        errors = new List<string>();
        //        propertyErrorMap[propertyName] = errors;
        //    }

        //    errors.Add("ERRROR");
        //}
    }
}
