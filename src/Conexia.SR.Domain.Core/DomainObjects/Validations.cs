using System;
using System.Text.RegularExpressions;

namespace Conexia.Core.DomainObjects
{
    public static class Validations
    {
        public static void ValidateFill(string value, string message)
        {
            if (value == null || value.Trim().Length == 0)
                throw new DomainException(message);
        }

        public static void ValidateExactLenght(string value, int expected, string message)
        {
            if (value.Length != expected)
                throw new DomainException(message);
        }

        public static void ValidateEmptyGuid(Guid value, string message)
        {
            if (value == Guid.Empty)
                throw new DomainException(message);
        }

        public static void ValidateRegex(string value, string pattern, string message)
        {
            var regex = new Regex(pattern);
            if (!regex.IsMatch(value))
                throw new DomainException(message);
        }
    }
}
