using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SaamApp.Maui.Client.Common
{
    public class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private string _errorMessage;
        private Dictionary<string, List<string>> _errors = new();
        private bool _isBusy;
        private bool _isValid;

        public virtual bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public virtual bool IsValid
        {
            set => SetProperty(ref _isValid, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public bool HasErrors => _errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !_errors.ContainsKey(propertyName))
            {
                return null;
            }

            return _errors[propertyName];
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual bool GetIsValid()
        {
            return _isValid;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            backingStore = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        protected virtual void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void ValidateProperty<T>(T value, [CallerMemberName] string propertyName = null)
        {
            var validationContext = new ValidationContext(this) { MemberName = propertyName };
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateProperty(value, validationContext, validationResults);

            if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
            }

            OnErrorsChanged(propertyName);

            HandleValidationResults(validationResults);
        }

        protected void AddError(string propertyName, string error)
        {
            if (!_errors.ContainsKey(propertyName))
            {
                _errors[propertyName] = new List<string>();
            }

            if (!_errors[propertyName].Contains(error))
            {
                _errors[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        protected void RemoveError(string propertyName, string error)
        {
            if (_errors.ContainsKey(propertyName) && _errors[propertyName].Contains(error))
            {
                _errors[propertyName].Remove(error);
                if (!_errors[propertyName].Any())
                {
                    _errors.Remove(propertyName);
                }

                OnErrorsChanged(propertyName);
            }
        }

        private void HandleValidationResults(List<ValidationResult> validationResults)
        {
            var propertyNames = validationResults.SelectMany(r => r.MemberNames).Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyErrors = validationResults
                    .Where(r => r.MemberNames.Contains(propertyName))
                    .Select(r => r.ErrorMessage)
                    .Distinct()
                    .ToList();

                _errors[propertyName] = propertyErrors;

                OnErrorsChanged(propertyName);
            }
        }
    }
}