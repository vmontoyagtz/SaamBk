using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SaamApp.Maui.Client.Common
{
    public class ValidationBehavior : Behavior<Entry>
    {
        public string PropertyName { get; set; }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            var context = new ValidationContext(entry.BindingContext) { MemberName = PropertyName };
            var results = new Collection<ValidationResult>();

            var isValid = Validator.TryValidateProperty(e.NewTextValue, context, results);

            entry.TextColor = !isValid ? Color.FromArgb("#EA7C69") : Color.FromArgb("#FF7CA3");
        }
    }
}