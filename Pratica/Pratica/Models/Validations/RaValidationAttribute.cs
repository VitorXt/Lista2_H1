using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Pratica.Models.Validations
{
    public class RaValidationAttribute : ValidationAttribute
    {
        private readonly string _startsWith;
        private readonly int _digitsLength;

        public RaValidationAttribute(string startsWith, int digitsLength)
        {
            _startsWith = startsWith;
            _digitsLength = digitsLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string valueString = value.ToString();
                if (!valueString.StartsWith(_startsWith, StringComparison.OrdinalIgnoreCase))
                {
                    return new ValidationResult($"O campo {validationContext.DisplayName} deve começar com {_startsWith}");
                }

                string digitsPart = valueString.Substring(_startsWith.Length);

                if (!Regex.IsMatch(digitsPart, @"^\d{" + _digitsLength + "}$"))
                {
                    return new ValidationResult($"A parte numérica do campo {validationContext.DisplayName} deve conter {_digitsLength} dígitos.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
