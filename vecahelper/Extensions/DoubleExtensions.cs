namespace HelperUDF.Extensions
{
    internal static class DoubleExtensions
    {
        public static string ToStringRoundedSafety(this double @double, int digits)
        {
            if (digits >= 0)
            {
                return Math.Round(@double, digits).ToString("f" + digits);
            }

            var safeDigits = Math.Abs(digits);

            var temp = @double / Math.Pow(10, safeDigits);

            var rounded = Math.Round(temp, 1);

            var result = rounded * Math.Pow(10, safeDigits);

            // Отбросить возможную дробную часть .000000000Х
            return Math.Truncate(result).ToString();
        }
    }
}
