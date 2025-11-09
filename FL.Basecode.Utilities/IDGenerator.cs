using System;

namespace FL.Basecode.Utilities
{
    public static class IDGenerator
    {
        /// <summary>
        /// Generates a dynamic ID with prefix and zero-padded number.
        /// Example: GenerateId("ICON", 1, 7) => ICON-0000001
        /// </summary>
        /// <param name="prefix">Prefix for the ID, e.g., ICON, USER</param>
        /// <param name="number">The numeric part of the ID</param>
        /// <param name="length">Total digits for numeric part (zero-padded)</param>
        /// <returns>Formatted ID string</returns>
        public static string GenerateId(string prefix, int number, int length = 7)
        {
            if (string.IsNullOrWhiteSpace(prefix))
                throw new ArgumentException("Prefix cannot be empty", nameof(prefix));

            string numberPart = number.ToString().PadLeft(length, '0');
            return $"{prefix}-{numberPart}";
        }
    }
}
