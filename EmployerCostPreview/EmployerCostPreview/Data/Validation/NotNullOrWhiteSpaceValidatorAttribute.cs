using System.ComponentModel.DataAnnotations;

namespace EmployerCostPreview.Data.Validation
{
    public class NotNullOrWhiteSpaceValidatorAttribute : ValidationAttribute
    {
        public NotNullOrWhiteSpaceValidatorAttribute() : base("Invalid Field") { }
        public NotNullOrWhiteSpaceValidatorAttribute(string message) : base(message) { }

        public override bool IsValid(object value) => !string.IsNullOrWhiteSpace(value?.ToString());

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) => IsValid(value)
            ? ValidationResult.Success
            : new ValidationResult("Value cannot be empty or white space.");
    }
}
