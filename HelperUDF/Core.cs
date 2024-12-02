namespace HelperUDF
{
    internal static class Core 
    {
        internal static int GetRoundDigits(double absoluteUncertainty)
        {
            var factor = GetMultiplificationFactor(absoluteUncertainty);

            var temp = Math.Truncate(absoluteUncertainty * factor);
            var firstDigit = int.Parse(temp.ToString()[0].ToString());

            var roundDigit = firstDigit switch
            {
                // Если первая значащая цифра 1, 2 или 3 - округлить до двух значащих цифр
                < 4 => - temp.ToString().Length + 1,

                // Округлить до одной значащей цифры
                _ => - temp.ToString().Length
            };
            
            var result = factor switch
            {
                1 => roundDigit,
                _ => roundDigit + (int) Math.Log10(factor) + 1
            };
            
            return result;
        }

        private static int GetMultiplificationFactor(double uncertainty)
        {
            var factor = 1;
            var temporary = uncertainty * factor;

            while (temporary < 10)
            {
                factor *= 10;
                temporary = uncertainty * factor;
            }

            return factor;
        }
    }
}
