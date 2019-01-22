using System.Collections.Generic;
using System.Linq;

using Yaringa.ViewModels;

namespace Yaringa.Validations {
    public class ValidatableObject<T> : ExtendedBindableObject, IValidity {

        public List<IValidationRule<T>> ValidationRules { get; }

        private List<string> _errors;
        public List<string> Errors { get => _errors; set => SetProperty(ref _errors, value); }

        private T _value;
        public T Value { get => _value; set => SetProperty(ref _value, value); }

        private bool _isValid;
        public bool IsValid { get => _isValid; set => SetProperty(ref _isValid, value); }

        public ValidatableObject() {
            _isValid = true;
            _errors = new List<string>();
            ValidationRules = new List<IValidationRule<T>>();
        }

        public bool Validate() {
            Errors.Clear();

            IEnumerable<string> errors = ValidationRules
                .Where(rule => !rule.Check(Value))
                .Select(v => v.ValidationMessage);

            Errors = errors.ToList();
            IsValid = !Errors.Any();

            return this.IsValid;
        }
    }
}
