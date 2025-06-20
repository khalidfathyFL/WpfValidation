using System.Globalization;
using System.Windows.Controls;

namespace WpfValidation.ValidationRules;
internal class EmptyValidationRule : ValidationRule
{

    public string ErrorMessage { get; set; } = "Value cannot be null or whitespace.";
    public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
    {
        if (string.IsNullOrWhiteSpace(value.ToString()))
        {
            return new ValidationResult(false, ErrorMessage);
        }
        return ValidationResult.ValidResult;
    }
}
