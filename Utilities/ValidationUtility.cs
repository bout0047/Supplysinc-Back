using System;
using System.Text.RegularExpressions;

namespace SupplySyncBackend.Utilities
{
    public static class ValidationUtility
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;

            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) return false;

            var phonePattern = @"^\+?[1-9]\d{1,14}$"; // Supports E.164 format
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        public static bool IsNotNullOrEmpty(string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        public static bool IsPositiveNumber(int value)
        {
            return value > 0;
        }
    }
}
