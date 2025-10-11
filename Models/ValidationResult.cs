using System.Collections.Generic;
using System.Linq;

namespace Social_Sport_Hub.Common
{
    // Encapsulates validation results for service and viewmodel operations.
    public sealed class ValidationResult
    {
        public bool IsValid => !Errors.Any();
        public List<string> Errors { get; } = new();

        public static ValidationResult Success() => new();

        public static ValidationResult Fail(params string[] errorMessages)
        {
            var result = new ValidationResult();
            result.Errors.AddRange(errorMessages);
            return result;
        }
    }
}
